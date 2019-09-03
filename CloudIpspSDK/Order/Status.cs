using System.Xml.Serialization;
using CloudIpspSDK.Utils;
using Newtonsoft.Json;

namespace CloudIpspSDK.Order
{
    /// <summary>
    /// Order Status Api
    /// </summary>
    public class Status
    {
        public StatusResponse StatusByOrderId(StatusByOrderRequest req)
        {
            StatusResponse response;
            req.merchant_id = Config.MerchantId;
            req.version = Config.Protocol;
            req.signature = Signature.GetRequestSignature(RequiredParams.GetHashProperties(req));
            try
            {
                response = Client.Invoke<StatusByOrderRequest, StatusResponse>(req, req.ActionUrl);
            }
            catch (ClientException c)
            {
                response = new StatusResponse {Error = c};
            }

            if (response.data != null && Config.Protocol == "2.0")
            {
                return JsonFormatter.ConvertFromJson<StatusResponse>(response.data, true, "order");
            }

            return response;
        }

        public StatusResponse StatusByPaymentId(StatusByPaymentRequest req)
        {
            StatusResponse response;
            req.merchant_id = Config.MerchantId;
            req.version = Config.Protocol;
            req.signature = Signature.GetRequestSignature(RequiredParams.GetHashProperties(req));
            try
            {
                response = Client.Invoke<StatusByPaymentRequest, StatusResponse>(req, req.ActionUrl);
            }
            catch (ClientException c)
            {
                response = new StatusResponse {Error = c};
            }

            if (response.data != null && Config.Protocol == "2.0")
            {
                return JsonFormatter.ConvertFromJson<StatusResponse>(response.data, true, "order");
            }

            return response;
        }
    }

    [JsonObject(Title = "request")]
    [XmlRoot("request")]
    public class StatusByOrderRequest
    {
        [JsonProperty(PropertyName = "signature")]
        public string signature { get; set; }

        [JsonProperty(PropertyName = "order_id")]
        public string order_id { get; set; }

        [JsonProperty(PropertyName = "merchant_id")]
        public int merchant_id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "version")]
        public string version { get; set; }

        [JsonIgnore] [XmlIgnore] public readonly string ActionUrl = @"status/order_id";
    }

    [JsonObject(Title = "request")]
    [XmlRoot("request")]
    public class StatusByPaymentRequest
    {
        [JsonProperty(PropertyName = "signature")]
        public string signature { get; set; }

        [JsonProperty(PropertyName = "payment_id")]
        public int payment_id { get; set; }

        [JsonProperty(PropertyName = "merchant_id")]
        public int merchant_id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "version")]
        public string version { get; set; }

        [JsonIgnore] [XmlIgnore] public readonly string ActionUrl = @"status/payment_id";
    }

    [JsonObject(Title = "response")]
    [XmlRoot("response")]
    public class StatusResponse : Models.ResponseModel
    {
        [JsonIgnore] [XmlIgnore] public new ClientException Error { get; set; }
    }
}