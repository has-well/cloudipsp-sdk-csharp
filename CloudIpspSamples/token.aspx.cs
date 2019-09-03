using System;
using System.Collections.Generic;
using CloudIpspSDK;
using CloudIpspSDK.Checkout;

namespace CloudIpspSamples
{
    public partial class TokenSample : System.Web.UI.Page
    {
        protected string Data = null;
        protected string DataUri = null;
        protected string DataError = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo ui = System.Globalization.CultureInfo.CurrentUICulture;

            btnSubmit.Click += Submit;
            btnSubmitXml.Click += SubmitXml;
            btnSubmitForm.Click += SubmitForm;
        }

        private void SubmitForm(object sender, EventArgs e)
        {
            Config.ContentType = "form";
            int amount = Convert.ToInt32(Request.Form["amount"].Substring(0,
                Request.Form["amount"].IndexOf('.') > 0
                    ? Request.Form["amount"].IndexOf('.')
                    : Request.Form["amount"].Length));
            var req = new TokenRequest
            {
                order_id = Request.Form["order_id"],
                amount = amount * 100,
                order_desc = "checkout form demo",
                currency = "EUR"
            };

            DoRequest(req);
        }

        private void SubmitXml(object sender, EventArgs e)
        {
            Config.ContentType = "xml";
            int amount = Convert.ToInt32(Request.Form["amount"].Substring(0,
                Request.Form["amount"].IndexOf('.') > 0
                    ? Request.Form["amount"].IndexOf('.')
                    : Request.Form["amount"].Length));
            var req = new TokenRequest
            {
                order_id = Request.Form["order_id"],
                amount = amount * 100,
                order_desc = "checkout xml demo",
                currency = "USD"
            };

            DoRequest(req);
        }

        private void Submit(object sender, EventArgs e)
        {
            Config.ContentType = "json";
            int amount = Convert.ToInt32(Request.Form["amount"].Substring(0,
                Request.Form["amount"].IndexOf('.') > 0
                    ? Request.Form["amount"].IndexOf('.')
                    : Request.Form["amount"].Length));
            var req = new TokenRequest
            {
                order_id = Request.Form["order_id"],
                amount = amount * 100,
                order_desc = "checkout json demo",
                currency = "RUB"
            };
            DoRequest(req);
        }

        private void DoRequest(TokenRequest req)
        {
            var resp = new Token().Post(req);
            if (resp.Error != null)
            {
                DataError = resp.Error.ErrorMessage;
                Data = resp.Error.RequestId;
            }
            else
            {
                DataUri = resp.token;
            }
        }
    }
}