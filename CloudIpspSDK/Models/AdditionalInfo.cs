using System.Xml.Serialization;
using Newtonsoft.Json;

namespace CloudIpspSDK.Models
{
    /// <summary>
    /// Client additional info in response
    /// </summary>
    [JsonObject(Title = "additional_info")]
    [XmlRoot("additional_info")]
    public class AdditionalInfo
    {
        [JsonProperty(PropertyName = "bank_name")]
        public string bank_name { get; set; }

        [JsonProperty(PropertyName = "bank_country")]
        public string bank_country { get; set; }

        [JsonProperty(PropertyName = "bank_response_code")]
        public string bank_response_code { get; set; }

        [JsonProperty(PropertyName = "card_product")]
        public string card_product { get; set; }

        [JsonProperty(PropertyName = "card_category")]
        public string card_category { get; set; }

        [JsonProperty(PropertyName = "settlement_fee")]
        public decimal? settlement_fee { get; set; }

        [JsonProperty(PropertyName = "capture_status")]
        public string capture_status { get; set; }

        [JsonProperty(PropertyName = "client_fee")]
        public decimal? client_fee { get; set; }

        [JsonProperty(PropertyName = "card_number")]
        public string card_number { get; set; }

        [JsonProperty(PropertyName = "ipaddress_v4")]
        public string ipaddress_v4 { get; set; }

        [JsonProperty(PropertyName = "capture_amount")]
        public decimal? capture_amount { get; set; }

        [JsonProperty(PropertyName = "card_type")]
        public string card_type { get; set; }

        [JsonProperty(PropertyName = "reservation_data")]
        public string reservation_data { get; set; }

        [JsonProperty(PropertyName = "bank_response_description")]
        public string bank_response_description { get; set; }

        [JsonProperty(PropertyName = "transaction_id")]
        public int? transaction_id { get; set; }

        [JsonProperty(PropertyName = "timeend")]
        public string timeend { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "order_desc")]
        public string order_desc { get; set; }
    }
}