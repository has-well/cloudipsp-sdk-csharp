using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace CloudIpspSDK.Models
{
    /// <summary>
    /// Default order capture request
    /// </summary>
    public class CaptureRequestModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "comment")]
        public string comment { get; set; }

        [JsonProperty(PropertyName = "order_id")]
        public string order_id { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string currency { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public int amount { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "version")]
        public string version { get; set; }

        [JsonProperty(PropertyName = "signature")]
        public string signature { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "email")]
        public string email { get; set; }

        [JsonProperty(PropertyName = "merchant_id")]
        public int merchant_id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "receiver")]
        public List<ReceiverModel> receiver { get; set; }
    }
    /// <summary>
    /// Default order capture response
    /// </summary>
    public class CaptureResponseModel : ResponseV2
    {
        [JsonProperty(PropertyName = "capture_status")]
        public string capture_status { get; set; }

        [JsonProperty(PropertyName = "order_id")]
        public string order_id { get; set; }

        [JsonProperty(PropertyName = "response_description")]
        public string response_description { get; set; }

        [JsonProperty(PropertyName = "response_code")]
        public string response_code { get; set; }

        [JsonProperty(PropertyName = "merchant_id")]
        public int merchant_id { get; set; }

        [JsonProperty(PropertyName = "response_status")]
        public string response_status { get; set; }

        [JsonIgnore] [XmlIgnore] public ClientException Error { get; set; }
    }
    /// <summary>
    /// Default reverse request
    /// </summary>
    public class ReverseRequestModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "comment")]
        public string comment { get; set; }

        [JsonProperty(PropertyName = "order_id")]
        public string order_id { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string currency { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public int amount { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "version")]
        public string version { get; set; }

        [JsonProperty(PropertyName = "signature")]
        public string signature { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "email")]
        public string email { get; set; }

        [JsonProperty(PropertyName = "merchant_id")]
        public int merchant_id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "receiver")]
        public List<ReceiverModel> receiver { get; set; }
    }
    /// <summary>
    /// Default reverse response
    /// </summary>
    public class ReverseResponseModel : ResponseV2
    {
        [JsonProperty(PropertyName = "reverse_status")]
        public string reverse_status { get; set; }

        [JsonProperty(PropertyName = "order_id")]
        public string order_id { get; set; }

        [JsonProperty(PropertyName = "response_description")]
        public string response_description { get; set; }

        [JsonProperty(PropertyName = "response_code")]
        public string response_code { get; set; }

        [JsonProperty(PropertyName = "merchant_id")]
        public int merchant_id { get; set; }

        [JsonProperty(PropertyName = "response_status")]
        public string response_status { get; set; }

        [JsonProperty(PropertyName = "signature")]
        public new string signature { get; set; }

        [JsonProperty(PropertyName = "reversal_amount")]
        public string reversal_amount { get; set; }

        [JsonIgnore] [XmlIgnore] public ClientException Error { get; set; }
    }
    /// <summary>
    /// Reverse by transaction
    /// </summary>
    public class ReverseByTransactionModel
    {
        [JsonProperty(PropertyName = "transaction_id")]
        public int transaction_id { get; set; }

        [JsonProperty(PropertyName = "email")] public string email { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public string amount { get; set; }

        [JsonProperty(PropertyName = "receiver")]
        public List<ReceiverModel> receiver { get; set; }
    }
}