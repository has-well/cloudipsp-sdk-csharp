using System.Xml.Serialization;
using CloudIpspSDK.Utils;
using Newtonsoft.Json;

namespace CloudIpspSDK.Checkout
{
    /// <summary>
    /// Checkout url Api
    /// </summary>
    public class Url
    {
        public CheckoutResponse Post(CheckoutRequest req)
        {
            CheckoutResponse response;
            req.merchant_id = Config.MerchantId;
            req.version = Config.Protocol;
            req.signature = Signature.GetRequestSignature(RequiredParams.GetHashProperties(req));
            try
            {
                response = Client.Invoke<CheckoutRequest, CheckoutResponse>(req, req.ActionUrl);
            }
            catch (ClientException c)
            {
                response = new CheckoutResponse {Error = c};
            }

            if (response.data != null && Config.Protocol == "2.0")
            {
                return JsonFormatter.ConvertFromJson<CheckoutResponse>(response.data, true, "order");
            }

            return response;
        }
    }

    [XmlRoot("request")]
    [JsonObject(Title = "request")]
    public class CheckoutRequest : Models.CheckoutRequestModel
    {
        [JsonIgnore] [XmlIgnore] public readonly string ActionUrl = @"checkout/url/";
    }

    [XmlRoot("response")]
    [JsonObject(Title = "response")]
    public class CheckoutResponse : Models.CheckoutResponseModel
    {
        [JsonProperty(PropertyName = "payment_id")]
        public int payment_id { get; set; }

        [JsonProperty(PropertyName = "checkout_url")]
        public string checkout_url { get; set; }
    }
}