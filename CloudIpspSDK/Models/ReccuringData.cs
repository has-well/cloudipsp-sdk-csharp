using Newtonsoft.Json;

namespace CloudIpspSDK.Models
{
    /// <summary>
    /// Reccuring Data Model
    /// </summary>
    public class ReccuringData
    {
        [JsonProperty(PropertyName = "start_time")]
        public string start_time { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public int? amount { get; set; }

        [JsonProperty(PropertyName = "every")]
        public int? every { get; set; }

        [JsonProperty(PropertyName = "period")]
        public string period { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "state")]
        public string state { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "readonly")]
        public string Readonly { get; set; }
    }
}