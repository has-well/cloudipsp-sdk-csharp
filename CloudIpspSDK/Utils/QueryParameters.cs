using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CloudIpspSDK.Utils
{
    /// <summary>
    /// Helper class that can be converted into a URL query string.
    /// </summary>
    public abstract class QueryParameters
    {
        public static string ConvertToQuerySimple(object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                where p.GetValue(obj, null) != null
                select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());
            string queryString = String.Join("&", properties.ToArray());
            return queryString;
        }

        /// <summary>
        /// Converts the dictionary of query parameters to a URL-formatted string.
        /// </summary>
        /// <returns>A URL-formatted string containing the query parameters</returns>
        public static string ConvertToQuery<T>(T obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                where p.GetValue(obj, null) != null
                select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());
            string queryString = String.Join("&", properties.ToArray());
            return queryString;
        }

        /// <summary>
        /// Convert query string
        /// </summary>
        /// <param name="query"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T ConvertFromQuery<T>(string query)
        {
            T respObj = Deparametrize(query).ToObject<T>();
            return respObj;
        }

        /// <summary>
        /// Return as object
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static JObject Deparametrize(string input)
        {
            var obj = new JObject();
            var items = input.Replace("+", " ").Split(new[] { '&' });
            foreach (string item in items)
            {
                var param = item.Split(new[] { '=' });
                var key = HttpUtility.UrlDecode(param[0]);
                if (!string.IsNullOrEmpty(key))
                {
                    var keys = key.Split(new[] { "][" }, StringSplitOptions.RemoveEmptyEntries);
                    var keysLast = keys.Length - 1;
                    if (Regex.IsMatch(keys[0], @"\[") && Regex.IsMatch(keys[keysLast], @"\]$"))
                    {
                        keys[keysLast] = Regex.Replace(keys[keysLast], @"\]$", string.Empty);
                        keys = keys[0].Split(new[] { '[' }).Concat(keys.Skip(1)).ToArray();
                        keysLast = keys.Length - 1;
                    }
                    else
                    {
                        keysLast = 0;
                    }
                    if (param.Length == 2)
                    {
                        var val = HttpUtility.UrlDecode(param[1]);
                        if (keysLast != 0)
                        {
                            object cur = obj;
                            for (var i = 0; i <= keysLast; i++)
                            {
                                int index = -1, nextindex;
                                key = keys[i];
                                if (key == string.Empty || int.TryParse(key, out index))
                                {
                                    key = index == -1 ? "0" : index.ToString(CultureInfo.InvariantCulture);
                                }
                                if (cur is JArray)
                                {
                                    var jarr = cur as JArray;
                                    if (i == keysLast)
                                    {
                                        if (index >= 0 && index < jarr.Count)
                                        {
                                            jarr[index] = val;
                                        }
                                        else
                                        {
                                            jarr.Add(val);
                                        }
                                    }
                                    else
                                    {
                                        if (index < 0 || index >= jarr.Count)
                                        {
                                            if (keys[i + 1] == string.Empty || int.TryParse(keys[i + 1], out nextindex))
                                            {
                                                jarr.Add(new JArray());
                                            }
                                            else
                                            {
                                                jarr.Add(new JObject());
                                            }

                                            index = jarr.Count - 1;
                                        }

                                        cur = jarr.ElementAt(index);
                                    }
                                }
                                else if (cur is JObject)
                                {
                                    var jobj = cur as JObject;
                                    if (i == keysLast)
                                    {
                                        jobj[key] = val;
                                    }
                                    else
                                    {
                                        if (jobj[key] == null)
                                        {
                                            if (keys[i + 1] == string.Empty || int.TryParse(keys[i + 1], out nextindex))
                                            {
                                                jobj.Add(key, new JArray());
                                            }
                                            else
                                            {
                                                jobj.Add(key, new JObject());
                                            }
                                        }
                                        cur = jobj[key];
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (obj[key] is JArray)
                            {
                                (obj[key] as JArray).Add(val);
                            }
                            else if (obj[key] != null && val != null)
                            {
                                obj[key] = new JArray { obj[key], val };
                            }
                            else
                            {
                                if (IsJson(val))
                                {
                                    obj[key] = val.ToString();
                                }
                                else
                                {
                                    obj[key] = val;
                                }
                            }
                        }
                    }
                    else if (!string.IsNullOrEmpty(key))
                    {
                        obj[key] = null;
                    }
                }
            }
            return obj;
        }

        /// <summary>
        /// Check if string is json
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsJson(string input)
        {
            input = input.Trim();
            return input.StartsWith("{") && input.EndsWith("}");
        }
    }
}