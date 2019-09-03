using System.Xml.Serialization;
using CloudIpspSDK.Utils;
using Newtonsoft.Json;

namespace CloudIpspSDK.Checkout
{
    /// <summary>
    /// Verification url Api
    /// </summary>
    public class Verification
    {
        public VerificationResponse Post(VerificationRequest req)
        {
            VerificationResponse response;
            req.merchant_id = Config.MerchantId;
            req.verification = "Y";
            req.version = Config.Protocol;
            if (req.verification_type == null)
            {
                req.verification_type = "amount";
            }

            req.signature = Signature.GetRequestSignature(RequiredParams.GetHashProperties(req));
            try
            {
                response = Client.Invoke<VerificationRequest, VerificationResponse>(req, req.ActionUrl);
            }
            catch (ClientException c)
            {
                response = new VerificationResponse {Error = c};
            }

            if (response.data != null && Config.Protocol == "2.0")
            {
                return JsonFormatter.ConvertFromJson<VerificationResponse>(response.data, true, "order");
            }

            return response;
        }
    }

    [XmlRoot("request")]
    [JsonObject(Title = "request")]
    public class VerificationRequest : Models.CheckoutRequestModel
    {
        [JsonIgnore] [XmlIgnore] public readonly string ActionUrl = @"checkout/url/";
    }

    [XmlRoot("response")]
    [JsonObject(Title = "response")]
    public class VerificationResponse : Models.CheckoutResponseModel
    {
        [JsonProperty(PropertyName = "payment_id")]
        public int payment_id { get; set; }

        [JsonProperty(PropertyName = "Verification_url")]
        public string Verification_url { get; set; }
    }
}