using System;
using CloudIpspSDK;
using CloudIpspSDK.Checkout;
using CloudIpspSDK.Models;
using CloudIpspSDK.Order;
using CloudIpspSDK.Response;

namespace CloudIpspSamples
{
    public partial class OrderCapture : System.Web.UI.Page
    {
        protected string Data = null;
        protected string DataError = null;
        protected ResponseModel ResponeData = null;
        protected string ResponeOrder = null;
        protected string ResponeOrderError = null;
        protected string ResponeOrderSignatureString = null;
        protected string ResponeOrderCalculatedSignatureString = null;
        protected CaptureResponse CaptureResp = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo ui = System.Globalization.CultureInfo.CurrentUICulture;
            if (Request.Form["payment_id"] != null || Request.Form["data"] != null)
            {
                var resp = new Response().GetResponse(Request.Form.ToString(), "form");
                ResponeData = resp;
                if (resp.SignatureError != null)
                {
                    ResponeOrderError = "Signature error";
                    ResponeOrderSignatureString = resp.SignatureError.SignatureString;
                    ResponeOrderCalculatedSignatureString = resp.SignatureError.CalculatedSignature;
                }
                else
                {
                    ResponeOrder = resp.order_id;
                    var captureReq = new CaptureRequest
                    {
                        order_id = resp.order_id,
                        amount = Convert.ToInt32(resp.amount) - 1,
                        currency = "USD",
                    };
                    var cresp = new Capture().Post(captureReq);
                    if (cresp.Error != null)
                    {
                        ResponeData = null;
                        DataError = cresp.Error.ErrorMessage;
                        Data = cresp.Error.RequestId;
                    }
                    else
                    {
                        CaptureResp = cresp;
                    }
                }
            }
            btnSubmit.Click += Submit;
        }

        private void Submit(object sender, EventArgs e)
        {
            Config.ContentType = "json";
            int amount = Convert.ToInt32(Request.Form["amount"].Substring(0,
                Request.Form["amount"].IndexOf('.') > 0
                    ? Request.Form["amount"].IndexOf('.')
                    : Request.Form["amount"].Length));
            var req = new CheckoutRequest
            {
                order_id = Request.Form["order_id"],
                amount = amount * 100,
                order_desc = "checkout capture demo",
                currency = "USD",
                preauth = "Y",
                response_url = Request.Url.Scheme + "://" + Request.Url.Authority + "/order_capture.aspx"
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