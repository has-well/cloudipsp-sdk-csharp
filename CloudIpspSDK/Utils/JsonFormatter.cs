using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace CloudIpspSDK.Utils
{
    /// <summary>
    /// Helper class that handles serializing and deserializing to and from JSON strings, respectively.
    /// </summary>
    public static class JsonFormatter
    {
        /// <summary>
        /// Converts the specified object to a JSON string.
        /// </summary>
        /// <typeparam name="T">A JSON-serializable object type.</typeparam>
        /// <param name="obj">The object to be serialized.</param>
        /// <returns>A JSON string representing the specified object.</returns>
        public static string ConvertToJson<T>(T obj, string root = null)
        {
            var attr = obj.GetType().GetCustomAttribute(typeof(JsonObjectAttribute)) as JsonObjectAttribute;
            var jv = JToken.FromObject(obj);
            if (root != null)
            {
                return new JObject(new JProperty(root, jv)).ToString(Formatting.None);
            }

            return new JObject(new JProperty(attr.Title, jv)).ToString(Formatting.None);
        }

        /// <summary>
        /// Converts the specified JSON string to the specified object.
        /// </summary>
        /// <typeparam name="T">The object type to which the JSON string will be deserialized.</typeparam>
        /// <param name="json">A JSON string.</param>
        /// <param name="root"></param>
        /// <returns>An object containing the data from the JSON string.</returns>
        public static T ConvertFromJson<T>(string json, bool isRoot = true, string root = "response")
        {
            JToken obj;
            obj = isRoot ? JObject.Parse(json).SelectToken(root) : JToken.Parse(json);
            json = obj.ToString();
            return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.None,
            });
        }
    }
}