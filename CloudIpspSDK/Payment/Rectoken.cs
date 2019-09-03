using System.Xml.Serialization;
using CloudIpspSDK.Utils;
using Newtonsoft.Json;

namespace CloudIpspSDK.Payment
{
    public class Rectoken
    {
        public RectokenResponse Post(RectokenRequest req)
        {
            RectokenResponse response;
            req.merchant_id = Config.MerchantId;
            req.version = Config.Protocol;
            req.signature = Signature.GetRequestSignature(RequiredParams.GetHashProperties(req));
            try
            {
                response = Client.Invoke<RectokenRequest, RectokenResponse>(req, req.ActionUrl);
            }
            catch (ClientException c)
            {
                response = new RectokenResponse {Error = c};
            }
            
            if (response.data != null && Config.Protocol == "2.0")
            {
                return JsonFormatter.ConvertFromJson<RectokenResponse>(response.data, true, "order");
            }

            return response;
        }
    }
    [XmlRoot("request")]
    [JsonObject(Title = "request")]
    public class RectokenRequest : Models.ReccuringRequestModel
    {
        [JsonIgnore] [XmlIgnore] public readonly string ActionUrl = @"recurring/";
    }

    [XmlRoot("response")]
    [JsonObject(Title = "response")]
    public class RectokenResponse : Models.ResponseModel
    {
        [JsonIgnore] [XmlIgnore] public new ClientException Error { get; set; }
    }
}