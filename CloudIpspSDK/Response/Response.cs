using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using CloudIpspSDK.Models;
using CloudIpspSDK.Utils;

namespace CloudIpspSDK.Response
{
    /// <summary>
    /// Pare Response helper
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Parsing Response/Callback
        /// </summary>
        /// <param name="response"></param>
        /// <param name="type"></param>
        /// <param name="isCredit"></param>
        /// <returns></returns>
        public ResponseModel GetResponse(string response, string type = null, bool isCredit = false)
        {
            ResponseModel data = RequiredParams.ConvertResponseByContentType<ResponseModel>(response, false, type);
            bool v2 = ISv2Resp(data);
            try
            {
                if (v2)
                {
                    IsSignatureValidV2(data, isCredit);
                }
                else
                {
                    IsSignatureValid(data, response, type, isCredit);
                }
            }
            catch (SignatureException e)
            {
                return new ResponseModel {SignatureError = e};
            }

            if (v2)
            {
                ResponseModel dataV2 = JsonFormatter.ConvertFromJson<ResponseModel>(data.data, true, "order");
                return dataV2;
            }
            return data;
        }
        /// <summary>
        /// Checking signature v2
        /// </summary>
        /// <param name="data"></param>
        /// <param name="isCredit"></param>
        /// <exception cref="SignatureException"></exception>
        private void IsSignatureValidV2(ResponseModel data, bool isCredit)
        {
            if (data.signature == null)
            {
                throw new SignatureException
                    {SignatureString = data.signature, CalculatedSignature = "No Signature in request"};
            }

            string calculatedSign = Signature.GetRequestSignatureV2(Signature.Base64Encode(data.data), isCredit);
            if (data.signature != calculatedSign)
            {
                throw new SignatureException {SignatureString = data.signature, CalculatedSignature = calculatedSign};
            }
        }
        /// <summary>
        /// Checking signature v1
        /// </summary>
        /// <param name="data"></param>
        /// <param name="response"></param>
        /// <param name="type"></param>
        /// <param name="isCredit"></param>
        /// <exception cref="SignatureException"></exception>
        private void IsSignatureValid(ResponseModel data, string response, string type, bool isCredit)
        {
            if (data.signature == null)
            {
                throw new SignatureException
                    {SignatureString = data.signature, CalculatedSignature = "No Signature in request"};
            }

            string calculatedSign =
                Signature.GetRequestSignature(getResponseSignatrureParams(response, type), isCredit);
            if (data.signature != calculatedSign)
            {
                throw new SignatureException {SignatureString = data.signature, CalculatedSignature = calculatedSign};
            }
        }
        /// <summary>
        /// Get all required signature params
        /// </summary>
        /// <param name="response"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private IEnumerable<string> getResponseSignatrureParams(string response, string type = null)
        {
            if (type == null)
            {
                type = Config.ContentType;
            }

            NameValueCollection parsed = null;
            switch (type)
            {
                case "xml":
                    response = response.Replace("\\n", "");
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXml(new StringReader(response));
                    parsed = new NameValueCollection(dataSet.Tables[0].Columns.Count);
                    foreach (DataRow dr in dataSet.Tables[0].Rows)
                    {
                        for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
                        {
                            parsed.Add(dataSet.Tables[0].Columns[i].ColumnName,
                                dr[dataSet.Tables[0].Columns[i].ColumnName].ToString());
                        }
                    }

                    break;
                case "form":
                    parsed = HttpUtility.ParseQueryString(response);
                    break;
                default:
                    var dict = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(response);
                    if (dict != null)
                    {
                        parsed = new NameValueCollection(dict.Count);
                        foreach (var k in dict)
                        {
                            parsed.Add(k.Key, k.Value);
                        }
                    }

                    break;
            }

            var hashKeys = parsed.AllKeys
                .Where(key => key != "signature" &&
                              key != "response_signature_string" &&
                              parsed[key].ToString() != "")
                .OrderBy(key => key)
                .ToList()
                .Select(key => parsed[key]);
            return hashKeys;
        }
        /// <summary>
        /// Checking if response is v2
        /// </summary>
        /// <param name="resp"></param>
        /// <returns></returns>
        private bool ISv2Resp(ResponseModel resp)
        {
            return !string.IsNullOrEmpty(resp.data) && resp.version == "2.0";
        }
    }
}