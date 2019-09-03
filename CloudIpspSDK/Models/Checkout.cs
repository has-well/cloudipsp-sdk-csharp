using System.Collections.Generic;
using System.Collections.Specialized;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace CloudIpspSDK.Models
{
    /// <summary>
    /// Base checkout request
    /// </summary>
    public class CheckoutRequestModel
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

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_systems")]
        public string payment_systems { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sender_email")]
        public string sender_email { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "delayed")]
        public string delayed { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "required_rectoken")]
        public string required_rectoken { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "lang")]
        public string lang { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "default_payment_system")]
        public string default_payment_system { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "verification")]
        public string verification { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "verification_type")]
        public string verification_type { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "rectoken")]
        public string rectoken { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "reservation_data")]
        public string reservation_data { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "client_ip")]
        public string client_ip { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "descriptor")]
        public string descriptor { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "iban")]
        public string iban { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "bic")]
        public string bic { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sender_name")]
        public string sender_name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sender_familyName")]
        public string sender_familyName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "design_id")]
        public int? design_id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "subscription")]
        public string subscription { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "subscription_callback_url")]
        public string subscription_callback_url { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "order_type")]
        public string order_type { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "operation_id")]
        public string operation_id { get; set; }
        
        [XmlElement("receiver")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "receiver")]
        public List<ReceiverModel> receiver { get; set; }
    }

    /// <summary>
    /// Response
    /// </summary>
    public class CheckoutResponseModel : ResponseV2
    {
        [JsonProperty(PropertyName = "response_status")]
        public string response_status { get; set; }

        [JsonIgnore] [XmlIgnore] public ClientException Error { get; set; }
    }
}