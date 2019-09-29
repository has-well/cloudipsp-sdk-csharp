using Newtonsoft.Json;
using CloudIpspSDK.Utils;

namespace CloudIpspSDK.Models
{
    [JsonObject(Title = "request")]
    public class RequestV2
    {
        [JsonProperty(PropertyName = "version")]
        public string version { get; set; }

        [JsonProperty(PropertyName = "data")] public string data { get; set; }

        [JsonProperty(PropertyName = "signature")]
        public string signature { get; set; }
    }

    [JsonObject(Title = "response")]
    public class ResponseV2
    {
        [JsonProperty(PropertyName = "version")]
        public string version { get; set; }
        
        [JsonIgnore] private string Data { get; set; }

        [JsonProperty(PropertyName = "data")]
        public string data
        {
            get { return Data; }
            set { Data = !string.IsNullOrEmpty(value) ? Signature.Base64Decode(value) : value; }
        }

        [JsonProperty(PropertyName = "signature")]
        public string signature { get; set; }
    }
}