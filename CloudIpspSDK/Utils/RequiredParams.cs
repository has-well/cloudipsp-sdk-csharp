using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using CloudIpspSDK.Models;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace CloudIpspSDK.Utils
{
    /// <summary>
    /// Class to getting params
    /// </summary>
    internal static class RequiredParams
    {
        /// <summary>
        /// Convert Response By Content Type
        /// </summary>
        /// <param name="response"></param>
        /// <param name="isRoot"></param>
        /// <param name="type"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T ConvertResponseByContentType<T>(string response, bool isRoot, string type = null)
        {
            T data;
            if (type == null)
            {
                type = Config.ContentType;
            }

            switch (type)
            {
                case "xml":
                    data = XmlFormatter.ConvertFromXml<T>(response);
                    break;
                case "form":
                    data = QueryParameters.ConvertFromQuery<T>(response);
                    break;
                default:
                    data = JsonFormatter.ConvertFromJson<T>(response, isRoot);
                    break;
            }

            return data;
        }

        /// <summary>
        /// Get V2 params
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="isCredit"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetParamsV2<T>(T obj, bool isCredit)
        {
            RequestV2 data = new RequestV2();
            data.data = Signature.Base64Encode(JsonFormatter.ConvertToJson(obj, "order"));
            data.signature = Signature.GetRequestSignatureV2(data.data, isCredit);
            data.version = "2.0";
            return JsonFormatter.ConvertToJson(data);
        }

        /// <summary>
        /// Convert Request By Content Type
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ConvertRequestByContentType<T>(T obj)
        {
            string data;
            switch (Config.ContentType)
            {
                case "xml":
                    data = XmlFormatter.ConvertToXml(obj);
                    break;
                case "form":
                    data = QueryParameters.ConvertToQuery(obj);
                    break;
                default:
                    data = JsonFormatter.ConvertToJson(obj);
                    break;
            }

            return data;
        }

        /// <summary>
        /// Get Signature params
        /// </summary>
        /// <param name="postObj"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetHashProperties(object postObj)
        {
            Type tModelType = postObj.GetType();
            PropertyInfo[] arrayProperty = tModelType.GetProperties();
            var hashKeys = arrayProperty
                .Where(o => o.Name != "signature" &&
                            o.Name != "response_signature_string" &&
                            o.GetValue(postObj) != null &&
                            o.GetValue(postObj).ToString() != ""
                )
                .OrderBy(o => o.Name)
                .ToList()
                .Select(o =>
                    o.GetGetMethod().Invoke(postObj, null).GetType() != typeof(string) &&
                    o.GetGetMethod().Invoke(postObj, null).GetType() != typeof(int)
                        ? SetAsString(o.GetGetMethod().Invoke(postObj, null))
                        : o.GetGetMethod().Invoke(postObj, null).ToString());

            return hashKeys;
        }

        /// <summary>
        /// Setting parameter as content string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static string SetAsString(object obj)
        {
            string data;
            switch (Config.ContentType)
            {
                case "xml":
                    data = XmlFormatter.ConvertToXmlSimple(obj);
                    break;
                case "form":
                    data = QueryParameters.ConvertToQuerySimple(obj);
                    break;
                default:
                    data = JsonConvert.SerializeObject(obj, Formatting.None);
                    break;
            }

            return data;
        }
    }
}