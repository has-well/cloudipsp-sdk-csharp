using System.Xml.Serialization;
using CloudIpspSDK.Utils;
using Newtonsoft.Json;
namespace CloudIpspSDK.Order
{
    public class Atol
    {
        public AtolResponse Post(AtolRequest req)
        {
            AtolResponse response;
            req.merchant_id = Config.MerchantId;
            req.version = Config.Protocol;
            req.signature = Signature.GetRequestSignature(RequiredParams.GetHashProperties(req));
            try
            {
                response = Client.Invoke<AtolRequest, AtolResponse>(req, req.ActionUrl);
            }
            catch (ClientException c)
            {
                response = new AtolResponse {Error = c};
            }

            return response;
        }
    }
    [XmlRoot("request")]
    [JsonObject(Title = "request")]
    public class AtolRequest
    {
        [JsonProperty(PropertyName = "signature")]
        public string signature { get; set; }
        
        [JsonProperty(PropertyName = "order_id")]
        public string order_id { get; set; }

        [JsonProperty(PropertyName = "merchant_id")]
        public int merchant_id { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "version")]
        public string version { get; set; }

        [JsonIgnore] [XmlIgnore] public readonly string ActionUrl = @"get_atol_logs/";
    }

    [XmlRoot("response")]
    [JsonObject(Title = "response")]
    public class AtolResponse
    {
        [JsonIgnore] [XmlIgnore] public ClientException Error { get; set; }
    }
}