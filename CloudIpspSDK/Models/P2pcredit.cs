using System.Xml.Serialization;
using Newtonsoft.Json;

namespace CloudIpspSDK.Models
{
    /// <summary>
    /// Default bill transfer models
    /// </summary>
    public class P2PcreditRequestModel
    {
        [JsonProperty(PropertyName = "order_id")]
        public string order_id { get; set; }

        [JsonProperty(PropertyName = "merchant_id")]
        public int merchant_id { get; set; }

        [JsonProperty(PropertyName = "signature")]
        public string signature { get; set; }

        [JsonProperty(PropertyName = "order_desc")]
        public string order_desc { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public int amount { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string currency { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "merchant_data")]
        public string merchant_data { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "server_callback_url")]
        public string server_callback_url { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "version")]
        public string version { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "product_id")]
        public string product_id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "receiver_rectoken")]
        public string receiver_rectoken { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "receiver_card_number")]
        public string receiver_card_number { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "reservation_data")]
        public string reservation_data { get; set; }
    }

    public class P2PcreditResponseModel : ResponseV2
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "product_id")]
        public string product_id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "masked_card")]
        public string masked_card { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string currency { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "response_description")]
        public string response_description { get; set; }

        [JsonProperty(PropertyName = "order_status")]
        public string order_status { get; set; }

        [JsonProperty(PropertyName = "response_status")]
        public string response_status { get; set; }

        [JsonProperty(PropertyName = "order_time")]
        public string order_time { get; set; }

        [JsonProperty(PropertyName = "order_id")]
        public string order_id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "tran_type")]
        public string tran_type { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_system")]
        public string payment_system { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "approval_code")]
        public string approval_code { get; set; }

        [JsonProperty(PropertyName = "merchant_id")]
        public int? merchant_id { get; set; }

        [JsonProperty(PropertyName = "payment_id")]
        public int? payment_id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "card_bin")]
        public string card_bin { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "response_code")]
        public string response_code { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "card_type")]
        public string card_type { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "amount")]
        public float amount { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "signature")]
        public new string signature { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "additional_info")]
        public string additional_info { get; set; }

        [JsonIgnore] [XmlIgnore] public ClientException Error { get; set; }
    }
}