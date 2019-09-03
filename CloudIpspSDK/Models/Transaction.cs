using Newtonsoft.Json;

namespace CloudIpspSDK.Models
{
    /// <summary>
    /// Transaction Model
    /// </summary>
    public class TransactionModel
    {
        [JsonProperty(PropertyName = "actual_amount")]
        public decimal? actual_amount { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "protocol")]
        public string protocol { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "pares_status")]
        public string pares_status { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "ipaddress_v4")]
        public string ipaddress_v4 { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "md")]
        public string md { get; set; }

        [JsonProperty(PropertyName = "payment_id")]
        public int? payment_id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "capture_status")]
        public string capture_status { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "client_fee")]
        public string client_fee { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "preauth")]
        public string preauth { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "duration")]
        public int? duration { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "parent_tran_id")]
        public string parent_tran_id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "eci")]
        public string eci { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "rectoken")]
        public string rectoken { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sender_approval_code")]
        public string sender_approval_code { get; set; }

        [JsonProperty(PropertyName = "merchant_id")]
        public int merchant_id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "expire_month")]
        public string expire_month { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "card_bin")]
        public string card_bin { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "transaction_status")]
        public string transaction_status { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public decimal? amount { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sender_email")]
        public string sender_email { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "verification_code")]
        public string verification_code { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "ip_country")]
        public string ip_country { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "receiver_country")]
        public string receiver_country { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "fee")]
        public string fee { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "reversal_amount")]
        public decimal? reversal_amount { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "settlement_amount")]
        public decimal? settlement_amount { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "timeend")]
        public string timeend { get; set; }

        [JsonProperty(PropertyName = "actual_currency")]
        public string actual_currency { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "receiver_rrn")]
        public string receiver_rrn { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "response_code")]
        public string response_code { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "capture_amount")]
        public decimal? capture_amount { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "veres_status")]
        public string veres_status { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "settlement_status")]
        public string settlement_status { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "istest")]
        public string istest { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sender_country")]
        public string sender_country { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sender_rrn")]
        public string sender_rrn { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "timestart")]
        public string timestart { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string currency { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
        public int? id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "settlement_currency")]
        public string settlement_currency { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "expire_year")]
        public string expire_year { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "rectoken_lifetime")]
        public string rectoken_lifetime { get; set; }
    }
}