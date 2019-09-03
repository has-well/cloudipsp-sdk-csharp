using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace CloudIpspSDK.Models
{
    /// <summary>
    /// Default response Model
    /// </summary>
    [XmlRoot("response")]
    public class ResponseModel : ResponseV2
    {
        [JsonProperty(PropertyName = "order_id")]
        public string order_id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "rrn")]
        public string rrn { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "masked_card")]
        public string masked_card { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sender_cell_phone")]
        public string sender_cell_phone { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sender_account")]
        public string sender_account { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string currency { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "fee")]
        public string fee { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "reversal_amount")]
        public string reversal_amount { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "settlement_amount")]
        public string settlement_amount { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "actual_amount")]
        public string actual_amount { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "response_description")]
        public string response_description { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sender_email")]
        public string sender_email { get; set; }

        [JsonProperty(PropertyName = "order_status")]
        public string order_status { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "response_status")]
        public string response_status { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "order_time")]
        public string order_time { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "actual_currency")]
        public string actual_currency { get; set; }

        [JsonProperty(PropertyName = "tran_type")]
        public string tran_type { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "eci")]
        public string eci { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "settlement_date")]
        public string settlement_date { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "approval_code")]
        public string approval_code { get; set; }

        [JsonProperty(PropertyName = "merchant_id")]
        public int merchant_id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "settlement_currency")]
        public string settlement_currency { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_system")]
        public string payment_system { get; set; }

        [JsonProperty(PropertyName = "payment_id")]
        public int payment_id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "card_bin")]
        public int? card_bin { get; set; }

        [JsonProperty(PropertyName = "response_code")]
        public string response_code { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "card_type")]
        public string card_type { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public int? amount { get; set; }

        [JsonProperty(PropertyName = "signature")]
        public new string signature { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "response_signature_string")]
        public string response_signature_string { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "product_id")]
        public string product_id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "merchant_data")]
        public dynamic merchant_data { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "rectoken")]
        public string rectoken { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "rectoken_lifetime")]
        public string rectoken_lifetime { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "verification_status")]
        public string verification_status { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "parent_order_id")]
        public string parent_order_id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "external_ref")]
        public int? external_ref { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "additional_info")]
        public string additional_info { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "transaction")]
        public List<TransactionModel> transaction { get; set; }

        [JsonIgnore] [XmlIgnore] public SignatureException SignatureError { get; set; }

        [JsonIgnore] [XmlIgnore] public ClientException Error { get; set; }
    }
}