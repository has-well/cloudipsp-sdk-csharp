using System.Xml.Serialization;
using CloudIpspSDK.Utils;
using Newtonsoft.Json;

namespace CloudIpspSDK.Order
{
    /// <summary>
    /// Reverse Api
    /// </summary>
    public class Reverse
    {
        /// <summary>
        /// By Order Id
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public ReverseByOrderResponse ByOrderID(ReverseByOrder req)
        {
            ReverseByOrderResponse response;
            req.merchant_id = Config.MerchantId;
            req.version = Config.Protocol;
            req.signature = Signature.GetRequestSignature(RequiredParams.GetHashProperties(req));
            try
            {
                response = Client.Invoke<ReverseByOrder, ReverseByOrderResponse>(req, req.ActionUrl);
            }
            catch (ClientException c)
            {
                response = new ReverseByOrderResponse {Error = c};
            }
            
            if (response.data != null && Config.Protocol == "2.0")
            {
                return JsonFormatter.ConvertFromJson<ReverseByOrderResponse>(response.data, true, "order");
            }

            return response;
        }
        /// <summary>
        /// Reverse By Payment ID
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public ReverseByPaymentResponse ByPaymentID(ReverseByPayment req)
        {
            ReverseByPaymentResponse response;
            req.merchant_id = Config.MerchantId;
            req.signature = Signature.GetRequestSignature(RequiredParams.GetHashProperties(req));
            try
            {
                response = Client.Invoke<ReverseByPayment, ReverseByPaymentResponse>(req, req.ActionUrl);
            }
            catch (ClientException c)
            {
                response = new ReverseByPaymentResponse {Error = c};
            }
            
            if (response.data != null && Config.Protocol == "2.0")
            {
                return JsonFormatter.ConvertFromJson<ReverseByPaymentResponse>(response.data, true, "order");
            }

            return response;
        }
        /// <summary>
        /// Reverse By Transaction Id
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public ReverseByTransactionId ByTransactionID(ReverseByTransaction req)
        {
            ReverseByTransactionId response;
            try
            {
                response = Client.Invoke<ReverseByTransaction, ReverseByTransactionId>(req, req.ActionUrl);
            }
            catch (ClientException c)
            {
                response = new ReverseByTransactionId {Error = c};
            }
            
            if (response.data != null && Config.Protocol == "2.0")
            {
                return JsonFormatter.ConvertFromJson<ReverseByTransactionId>(response.data, true, "order");
            }

            return response;
        }
    }

    [JsonObject(Title = "request")]
    [XmlRoot("request")]
    public class ReverseByOrder : Models.ReverseRequestModel
    {
        [JsonIgnore] [XmlIgnore] public readonly string ActionUrl = @"reverse/order_id/";
    }

    [JsonObject(Title = "request")]
    [XmlRoot("request")]
    public class ReverseByPayment : Models.ReverseRequestModel
    {
        [JsonProperty(PropertyName = "payment_id")]
        public int payment_id { get; set; }

        [JsonIgnore] [XmlIgnore] public readonly string ActionUrl = @"reverse/payment_id/";
    }

    [JsonObject(Title = "request")]
    [XmlRoot("request")]
    public class ReverseByTransaction : Models.ReverseByTransactionModel
    {
        [JsonIgnore] [XmlIgnore] public readonly string ActionUrl = @"reverse/order_id/";
    }

    [JsonObject(Title = "response")]
    [XmlRoot("response")]
    public class ReverseByOrderResponse : Models.ReverseResponseModel
    {
    }

    [JsonObject(Title = "response")]
    [XmlRoot("response")]
    public class ReverseByPaymentResponse : Models.ReverseResponseModel
    {
        [JsonProperty(PropertyName = "payment_id")]
        public int payment_id { get; set; }
    }

    [JsonObject(Title = "response")]
    [XmlRoot("response")]
    public class ReverseByTransactionId : Models.ReverseResponseModel
    {
        [JsonProperty(PropertyName = "payment_id")]
        public int payment_id { get; set; }
    }
}