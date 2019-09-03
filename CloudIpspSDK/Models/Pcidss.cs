using System.Collections.Generic;
using Newtonsoft.Json;

namespace CloudIpspSDK.Models
{
    /// <summary>
    /// StepOne
    /// </summary>
    public class PcidssRequestModel
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

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "rectoken")]
        public string rectoken { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "verification")]
        public string verification { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "verification_type")]
        public string verification_type { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "reservation_data")]
        public string reservation_data { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "descriptor")]
        public string descriptor { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "lifetime")]
        public int? lifetime { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "preauth")]
        public string preauth { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sender_email")]
        public string sender_email { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "lang")]
        public string lang { get; set; }

        [JsonProperty(PropertyName = "card_number")]
        public string card_number { get; set; }

        [JsonProperty(PropertyName = "cvv2")] public string cvv2 { get; set; }

        [JsonProperty(PropertyName = "expiry_date")]
        public string expiry_date { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "response_url")]
        public string response_url { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "required_rectoken")]
        public string required_rectoken { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "client_ip")]
        public string client_ip { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "receiver")]
        public List<ReceiverModel> receiver { get; set; }
    }

    /// <summary>
    /// StepTwo
    /// </summary>
    public class PcidssAuthorizeModel
    {
        [JsonProperty(PropertyName = "order_id")]
        public string order_id { get; set; }

        [JsonProperty(PropertyName = "merchant_id")]
        public int? merchant_id { get; set; }

        [JsonProperty(PropertyName = "signature")]
        public string signature { get; set; }

        [JsonProperty(PropertyName = "pares")] public string pares { get; set; }

        [JsonProperty(PropertyName = "md")] public string md { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "version")]
        public string version { get; set; }
    }

    /// <summary>
    /// 3ds model
    /// </summary>
    public class PcidssResponseModel : ResponseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "acs_url")]
        public string acs_url { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "pareq")]
        public string pareq { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "md")]
        public string md { get; set; }
    }
}