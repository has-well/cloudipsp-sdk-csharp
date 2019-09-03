using System.Xml.Serialization;
using CloudIpspSDK.Utils;
using Newtonsoft.Json;

namespace CloudIpspSDK.Checkout
{
    /// <summary>
    /// Checkout token Api
    /// </summary>
    public class Token
    {
        public TokenResponse Post(TokenRequest req)
        {
            TokenResponse response;
            req.merchant_id = Config.MerchantId;
            req.version = Config.Protocol;
            req.signature = Signature.GetRequestSignature(RequiredParams.GetHashProperties(req));
            try
            {
                response = Client.Invoke<TokenRequest, TokenResponse>(req, req.ActionUrl);
            }
            catch (ClientException c)
            {
                response = new TokenResponse {Error = c};
            }

            if (response.data != null && Config.Protocol == "2.0")
            {
                return JsonFormatter.ConvertFromJson<TokenResponse>(response.data, true, "order");
            }

            return response;
        }
    }

    [JsonObject(Title = "request")]
    [XmlRoot("request")]
    public class TokenRequest : Models.CheckoutRequestModel
    {
        [JsonIgnore] [XmlIgnore] public readonly string ActionUrl = @"checkout/token/";
    }

    [XmlRoot("response")]
    [JsonObject(Title = "response")]
    public class TokenResponse : Models.CheckoutResponseModel
    {
        [JsonProperty(PropertyName = "token")] public string token { get; set; }
    }
}