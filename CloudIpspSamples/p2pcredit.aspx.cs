using System;
using System.Collections.Specialized;
using CloudIpspSDK;
using CloudIpspSDK.Checkout;
using CloudIpspSDK.P2pcredit;
using CloudIpspSDK.Response;

namespace CloudIpspSamples
{
    public partial class P2pCreditSample : System.Web.UI.Page
    {
        protected string Data = null;
        protected string DataError = null;
        protected NameValueCollection ResponeData = null;
        protected string ResponeOrder = null;
        protected string ResponeOrderError = null;
        protected string ResponeOrderSignatureString = null;
        protected string ResponeOrderCalculatedSignatureString = null;
        protected P2PcreditResponse P2PResp = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo ui = System.Globalization.CultureInfo.CurrentUICulture;
            if (Request.Form["payment_id"] != null || Request.Form["data"] != null)
            {
                ResponeData = Request.Form;
                var resp = new Response().GetResponse(Request.Form.ToString(), "form");
                if (resp.SignatureError != null)
                {
                    ResponeOrderError = "Signature error";
                    ResponeOrderSignatureString = resp.SignatureError.SignatureString;
                    ResponeOrderCalculatedSignatureString = resp.SignatureError.CalculatedSignature;
                }
                else
                {
                    ResponeOrder = resp.order_id;
                    var p2PcreditReq = new P2PcreditRequest()
                    {
                        order_id = Guid.NewGuid().ToString(),
                        currency = "USD",
                        receiver_rectoken = resp.rectoken,
                        amount = 10000,
                        order_desc = "request desc"
                    };
                    Config.CreditKey = "testcredit";
                    var presp = new P2Pcredit().Post(p2PcreditReq);
                    if (presp.Error != null)
                    {
                        ResponeData = null;
                        DataError = presp.Error.ErrorMessage;
                        Data = presp.Error.RequestId;
                    }
                    else
                    {
                        P2PResp = presp;
                    }
                }
            }
            btnSubmit.Click += Submit;
        }

        private void Submit(object sender, EventArgs e)
        {
            int amount = Convert.ToInt32(Request.Form["amount"].Substring(0,
                Request.Form["amount"].IndexOf('.') > 0
                    ? Request.Form["amount"].IndexOf('.')
                    : Request.Form["amount"].Length));
            var req = new CheckoutRequest
            {
                order_id = Request.Form["order_id"],
                amount = amount * 100,
                order_desc = "checkout p2pcredit demo",
                currency = "USD",
                required_rectoken = "Y",
                response_url = Request.Url.Scheme + "://" + Request.Url.Authority + "/p2pcredit.aspx"
            };
            DoRequest(req);
        }

        private void DoRequest(CheckoutRequest req)
        {
            var resp = new Url().Post(req);
            if (resp.Error != null)
            {
                DataError = resp.Error.ErrorMessage;
                Data = resp.Error.RequestId;
            }
            else
            {
                Response.Redirect(resp.checkout_url);
            }
        }
    }
}