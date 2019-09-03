using System.Xml.Serialization;
using Newtonsoft.Json;

namespace CloudIpspSDK.Models
{
    /// <summary>
    /// Receiver BankAccount model
    /// </summary>
    [JsonObject(Title = "bank_account")]
    [XmlRoot("bank_account")]
    public class BankAccount
    {
        [JsonProperty(PropertyName = "type")] public string type { get; set; }

        [JsonProperty(PropertyName = "requisites")]
        public BankAccountRequisites requisites { get; set; }
    }

    /// <summary>
    /// BankAccount details
    /// </summary>
    [JsonObject(Title = "requisites")]
    public class BankAccountRequisites
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "mfo")]
        public string mfo { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "edrpou")]
        public string edrpou { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "account")]
        public string account { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "bank_name")]
        public string bank_name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "name")]
        public string name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "amount")]
        public string amount { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "settlement_description")]
        public string settlement_description { get; set; }
    }
}