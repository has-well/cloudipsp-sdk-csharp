using System.Collections.Generic;
using System.Xml.Serialization;
using CloudIpspSDK.Utils;
using Newtonsoft.Json;

namespace CloudIpspSDK.Order
{
    /// <summary>
    /// Transaction list Api
    /// </summary>
    public class TransactionList
    {
        public TransactionListResponse Post(TransactionListRequest req)
        {
            TransactionListResponse response;
            req.merchant_id = Config.MerchantId;
            req.signature = Signature.GetRequestSignature(RequiredParams.GetHashProperties(req));
            // In this api only json allowed
            Config.ContentType = "json";
            try
            {
                response = Client.Invoke<TransactionListRequest, TransactionListResponse>(req, req.ActionUrl, false);
            }
            catch (ClientException c)
            {
                response = new TransactionListResponse {Error = c};
            }

            return response;
        }
    }
    
    [JsonObject(Title = "request")]
    public class TransactionListRequest
    {
        [JsonProperty(PropertyName = "signature")]
        public string signature { get; set; }
        
        [JsonProperty(PropertyName = "order_id")]
        public string order_id { get; set; }

        [JsonProperty(PropertyName = "merchant_id")]
        public int merchant_id { get; set; }

        [JsonIgnore] [XmlIgnore] public readonly string ActionUrl = @"transaction_list/";
    }
    public class TransactionListResponse
    {
        [JsonProperty(PropertyName = "response")]
        public List<Models.TransactionModel> response { get; set; }
        [JsonIgnore] [XmlIgnore] public ClientException Error { get; set; }
    }
}