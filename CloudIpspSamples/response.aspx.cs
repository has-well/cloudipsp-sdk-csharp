using System;
using System.IO;
using System.Text;
using CloudIpspSDK.Models;
using CloudIpspSDK.Response;

namespace CloudIpspSamples
{
    public partial class ResponseSample : System.Web.UI.Page
    {
        protected string Data = null;
        protected string DataError = null;
        protected ResponseModel ResponeData = null;
        protected string ResponeOrderError = null;
        protected string ResponeOrderSignatureString = null;
        protected string ResponeOrderCalculatedSignatureString = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo ui = System.Globalization.CultureInfo.CurrentUICulture;
            MemoryStream memstream = new MemoryStream();
            Request.InputStream.CopyTo(memstream);
            string contentType = "form";
            if (Request.Headers["Content-type"] != null)
            {
                if (Request.Headers["Content-type"].Contains("application/x-www-form-urlencoded"))
                {
                    contentType = "form";
                }
                if (Request.Headers["Content-type"].Contains("application/json"))
                {
                    contentType = "json";
                }
                if (Request.Headers["Content-type"].Contains("application/xml"))
                {
                    contentType = "xml";
                }
            }
            memstream.Position = 0;
            string text;
            using (StreamReader reader = new StreamReader(memstream, Encoding.UTF8))
            {
                text = reader.ReadToEnd();
            }

            if (text != "")
            {
                var resp = new Response().GetResponse(text, contentType);
                if (resp.SignatureError != null)
                {
                    ResponeOrderError = "Signature error";
                    ResponeOrderSignatureString = resp.SignatureError.SignatureString;
                    ResponeOrderCalculatedSignatureString = resp.SignatureError.CalculatedSignature;
                }
                else
                {
                    ResponeData = resp;
                }
            }
        }
    }
}