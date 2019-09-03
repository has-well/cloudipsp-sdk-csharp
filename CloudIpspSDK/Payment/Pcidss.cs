using System.Xml.Serialization;
using CloudIpspSDK.Utils;
using Newtonsoft.Json;

namespace CloudIpspSDK.Payment
{
    /// <summary>
    /// Pcidss api
    /// </summary>
    public class Pcidss
    {
        /// <summary>
        /// Authorization
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public PcidssResponse StepOne(StepOneRequest req)
        {
            PcidssResponse response;
            req.merchant_id = Config.MerchantId;
            req.version = Config.Protocol;
            req.signature = Signature.GetRequestSignature(RequiredParams.GetHashProperties(req));
            try
            {
                response = Client.Invoke<StepOneRequest, PcidssResponse>(req, req.ActionUrl);
            }
            catch (ClientException c)
            {
                response = new PcidssResponse {Error = c};
            }
            
            if (response.data != null && Config.Protocol == "2.0")
            {
                return JsonFormatter.ConvertFromJson<PcidssResponse>(response.data, true, "order");
            }
            
            return response;
        }

        /// <summary>
        /// Submit if card 3ds
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public PcidssResponse StepTwo(StepTwoRequest req)
        {
            PcidssResponse response;
            req.merchant_id = Config.MerchantId;
            req.version = Config.Protocol;
            req.signature = Signature.GetRequestSignature(RequiredParams.GetHashProperties(req));
            try
            {
                response = Client.Invoke<StepTwoRequest, PcidssResponse>(req, req.ActionUrl);
            }
            catch (ClientException c)
            {
                response = new PcidssResponse {Error = c};
            }
            
            if (response.data != null && Config.Protocol == "2.0")
            {
                return JsonFormatter.ConvertFromJson<PcidssResponse>(response.data, true, "order");
            }

            return response;
        }
    }

    [XmlRoot("request")]
    [JsonObject(Title = "request")]
    public class StepOneRequest : Models.PcidssRequestModel
    {
        [JsonIgnore] [XmlIgnore] public readonly string ActionUrl = @"3dsecure_step1/";
    }

    [XmlRoot("request")]
    [JsonObject(Title = "request")]
    public class StepTwoRequest : Models.PcidssAuthorizeModel
    {
        [JsonIgnore] [XmlIgnore] public readonly string ActionUrl = @"3dsecure_step2/";
    }

    [XmlRoot("response")]
    [JsonObject(Title = "response")]
    public class PcidssResponse : Models.PcidssResponseModel
    {
        [JsonIgnore] [XmlIgnore] public new ClientException Error { get; set; }
    }
}