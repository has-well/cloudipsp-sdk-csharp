using System.Xml.Serialization;
using CloudIpspSDK.Utils;
using Newtonsoft.Json;

namespace CloudIpspSDK.P2pcredit
{
    /// <summary>
    /// Checkout P2pcredit Api
    /// </summary>
    public class P2Pcredit
    {
        public P2PcreditResponse Post(P2PcreditRequest req)
        {
            P2PcreditResponse response;
            req.merchant_id = Config.MerchantId;
            req.version = Config.Protocol;
            req.signature = Signature.GetRequestSignature(RequiredParams.GetHashProperties(req), true);
            try
            {
                response = Client.Invoke<P2PcreditRequest, P2PcreditResponse>(req, req.ActionUrl, true, true);
            }
            catch (ClientException c)
            {
                response = new P2PcreditResponse {Error = c};
            }

            if (response.data != null && Config.Protocol == "2.0")
            {
                return JsonFormatter.ConvertFromJson<P2PcreditResponse>(response.data, true, "order");
            }

            return response;
        }
    }

    [JsonObject(Title = "request")]
    [XmlRoot("request")]
    public class P2PcreditRequest : Models.P2PcreditRequestModel
    {
        [JsonIgnore] [XmlIgnore] public readonly string ActionUrl = @"p2pcredit/";
    }


    [JsonObject(Title = "response")]
    [XmlRoot("response")]
    public class P2PcreditResponse : Models.P2PcreditResponseModel
    {
        [JsonIgnore] [XmlIgnore] public SignatureException SignatureError { get; set; }
    }
}