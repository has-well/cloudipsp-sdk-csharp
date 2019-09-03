using System.Xml.Serialization;
using Newtonsoft.Json;

namespace CloudIpspSDK.Models
{
    /// <summary>
    /// Default api error call
    /// </summary>
    [XmlRoot("response")]
    [JsonObject(Title = "response")]
    public class ErrorResponseModel
    {
        [JsonProperty(PropertyName = "response_status")]
        public string response_status { get; set; }

        [JsonProperty(PropertyName = "request_id")]
        public string request_id { get; set; }

        [JsonProperty(PropertyName = "error_message")]
        public string error_message { get; set; }

        [JsonProperty(PropertyName = "error_code")]
        public string error_code { get; set; }
    }
}