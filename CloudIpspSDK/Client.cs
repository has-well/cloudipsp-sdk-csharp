using System;
using System.IO;
using System.Net;
using System.Text;
using CloudIpspSDK.Models;
using CloudIpspSDK.Utils;

namespace CloudIpspSDK
{
    public static class Client
    {
        private static int _statusCode;
        private static string _response;
        private static string _agent = "CloudIpsp-c-SDK";
        private static string _method = "POST";

        /// <summary>
        /// Basic Client
        /// </summary>
        /// <param name="req"></param>
        /// <param name="actionUrl"></param>
        /// <param name="isRoot"></param>
        /// <param name="isCredit"></param>
        /// <typeparam name="TCipspRequest"></typeparam>
        /// <typeparam name="TCipspResponse"></typeparam>
        /// <returns></returns>
        /// <exception cref="ClientException"></exception>
        public static TCipspResponse Invoke<TCipspRequest, TCipspResponse>(
            TCipspRequest req,
            string actionUrl,
            bool isRoot = true,
            bool isCredit = false
        )
        {
            string data;
            if (Config.Protocol == "2.0")
            {
                // In protocol v2 Only json allowed
                if (Config.ContentType != "json")
                {
                    throw new ClientException
                    {
                        ErrorMessage = "In protocol v2 only json content allowed",
                        ErrorCode = "0"
                    };
                }

                data = RequiredParams.GetParamsV2(req, isCredit);
            }
            else
            {
                data = RequiredParams.ConvertRequestByContentType(req);
            }

            string uriString = Config.Endpoint(null) + actionUrl;

            HttpWebRequest conn = WebRequest.CreateHttp(new Uri(uriString)) as HttpWebRequest;
            conn.ContentType = GetContentTypeHeader(Config.ContentType);
            conn.UserAgent = _agent;
            conn.Method = _method;
            byte[] requestData = Encoding.UTF8.GetBytes(data);
            var resultRequest = conn.BeginGetRequestStream(null, null);
            using (Stream postStream = conn.EndGetRequestStream(resultRequest))
            {
                postStream.Write(requestData, 0, requestData.Length);
                postStream.Dispose();
            }

            execute(conn);
            if (_statusCode != 200)
            {
                throw new ClientException
                {
                    ErrorCode = "500",
                    ErrorMessage = _response,
                    RequestId = "Server is gone",
                };
            }

            ErrorResponseModel errorResponse =
                RequiredParams.ConvertResponseByContentType<ErrorResponseModel>(_response, isRoot);
            if (errorResponse.response_status == "failure" || errorResponse.error_message != null)
            {
                throw new ClientException
                {
                    ErrorCode = errorResponse.error_code,
                    ErrorMessage = errorResponse.error_message,
                    RequestId = errorResponse.request_id,
                };
            }

            TCipspResponse normalResponse =
                RequiredParams.ConvertResponseByContentType<TCipspResponse>(_response, isRoot);
            return normalResponse;
        }

        /// <summary>
        /// Executes the request
        /// </summary>
        /// <param name="request"></param>
        private static void execute(HttpWebRequest request)
        {
            try
            {
                using (HttpWebResponse httpResponse = request.GetResponse() as HttpWebResponse)
                {
                    _statusCode = (int) httpResponse.StatusCode;
                    StreamReader reader = new StreamReader(httpResponse.GetResponseStream(), Encoding.UTF8, true);
                    _response = reader.ReadToEnd();
                }
            }
            catch (WebException we)
            {
                using (HttpWebResponse httpErrorResponse = (HttpWebResponse) we.Response as HttpWebResponse)
                {
                    if (httpErrorResponse == null)
                    {
                        throw new NullReferenceException("Http Response is empty " + we);
                    }

                    _statusCode = (int) httpErrorResponse.StatusCode;
                    using (StreamReader reader =
                        new StreamReader(httpErrorResponse.GetResponseStream(), Encoding.UTF8))
                    {
                        _response = reader.ReadToEnd();
                    }
                }
            }
        }

        /// <summary>
        /// Content header by type
        /// </summary>
        private static string GetContentTypeHeader(string type = null)
        {
            switch (type)
            {
                case "xml":
                    return "application/xml";
                case "form":
                    return "application/x-www-form-urlencoded";
                default:
                    return "application/json";
            }
        }
    }
}