using System.Xml.Serialization;
using CloudIpspSDK.Utils;
using Newtonsoft.Json;

namespace CloudIpspSDK.Order
{
    /// <summary>
    /// Order capture Api
    /// </summary>
    public class Capture
    {
        public CaptureResponse Post(CaptureRequest req)
        {
            CaptureResponse response;
            req.merchant_id = Config.MerchantId;
            req.version = Config.Protocol;
            req.signature = Signature.GetRequestSignature(RequiredParams.GetHashProperties(req));
            try
            {
                response = Client.Invoke<CaptureRequest, CaptureResponse>(req, req.ActionUrl);
            }
            catch (ClientException c)
            {
                response = new CaptureResponse {Error = c};
            }
            
            if (response.data != null && Config.Protocol == "2.0")
            {
                return JsonFormatter.ConvertFromJson<CaptureResponse>(response.data, true, "order");
            }
            
            return response;
        }
    }

    [JsonObject(Title = "request")]
    [XmlRoot("request")]
    public class CaptureRequest : Models.CaptureRequestModel
    {
        [JsonIgnore] [XmlIgnore] public readonly string ActionUrl = @"capture/order_id/";
    }

    [JsonObject(Title = "response")]
    [XmlRoot("response")]
    public class CaptureResponse : Models.CaptureResponseModel
    {
    }
}