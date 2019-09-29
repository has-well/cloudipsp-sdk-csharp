using CloudIpspSDK.Utils;
using Newtonsoft.Json;

namespace CloudIpspSDK.Checkout
{
    /// <summary>
    /// Settlement url Api
    /// </summary>
    public class Settlement
    {
        public SettlementResponse Post(SettlementRequest req)
        {
            SettlementResponse response;
            string defaultProtocol = Config.Protocol;
            string defaultContentType = Config.ContentType;
            Config.ContentType = "json";
            Config.Protocol = "2.0";
            req.merchant_id = Config.MerchantId;
            req.order_type = "settlement";
            try
            {
                response = Client.Invoke<SettlementRequest, SettlementResponse>(req, req.ActionUrl);
            }
            catch (ClientException c)
            {
                response = new SettlementResponse {Error = c};
            }

            if (response.data != null && Config.Protocol == "2.0")
            {
                Config.Protocol = defaultProtocol;
                Config.ContentType = defaultContentType;
                return JsonFormatter.ConvertFromJson<SettlementResponse>(response.data, true, "order");
            }

            return response;
        }
    }

    [JsonObject(Title = "request")]
    public class SettlementRequest : Models.CheckoutRequestModel
    {
        [JsonIgnore] public readonly string ActionUrl = @"settlement/";
    }

    [JsonObject(Title = "response")]
    public class SettlementResponse : Models.ResponseModel
    {
    }
}