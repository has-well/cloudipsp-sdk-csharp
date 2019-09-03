using System.Xml.Serialization;
using Newtonsoft.Json;

namespace CloudIpspSDK.Models
{
    [JsonObject(Title = "card")]
    [XmlRoot("card")]
    public class Card
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "merchant_id")]
        public int? card_number { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "amount")]
        public int? amount { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "settlement_description")]
        public string settlement_description { get; set; }
    }
}