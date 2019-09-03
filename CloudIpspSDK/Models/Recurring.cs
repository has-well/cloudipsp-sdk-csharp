using System.Collections.Generic;
using Newtonsoft.Json;

namespace CloudIpspSDK.Models
{
    /// <summary>
    /// Base reccuring checkout request
    /// </summary>
    public class ReccuringRequestModel
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

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sender_cell_phone")]
        public string sender_cell_phone { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "preauth")]
        public string preauth { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "lifetime")]
        public int? lifetime { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sender_country")]
        public string sender_country { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sender_city")]
        public string sender_city { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sender_address")]
        public string sender_address { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "version")]
        public string version { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sender_phone")]
        public string sender_phone { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "response_url")]
        public string response_url { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sender_first_name")]
        public string sender_first_name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sender_last_name")]
        public string sender_last_name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "product_id")]
        public string product_id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sender_email")]
        public string sender_email { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "rectoken")]
        public string rectoken { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "reservation_data")]
        public string reservation_data { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "client_ip")]
        public string client_ip { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "descriptor")]
        public string descriptor { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "is_recurring")]
        public string is_recurring { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "cvv2")]
        public string cvv2 { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "receiver")]
        public List<ReceiverModel> receiver { get; set; }
    }
}