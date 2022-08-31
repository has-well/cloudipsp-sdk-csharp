using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using CloudIpspSDK;
using CloudIpspSDK.Checkout;

namespace CloudIpspSamples
{
    public partial class Checkout : System.Web.UI.Page
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
            Dictionary<string,string> merchant_data = new Dictionary<string,string>();
            merchant_data.Add("some_key", "some_value");
            merchant_data.Add("some_key2", "some_value2");
            string mdata = new JavaScriptSerializer().Serialize(merchant_data);
            var reqForm = new CheckoutRequest
            {
                order_id = Request.Form["order_id"],
                amount = amount * 100,
                order_desc = "checkout form demo",
                currency = "EUR",
                merchant_data = mdata,
                response_url = Request.Url.Scheme + "://" + Request.Url.Authority + "/response.aspx",
                server_callback_url = "https://callback.test"
            };

            DoRequest(reqForm);
        }

        private void SubmitXml(object sender, EventArgs e)
        {
            Config.ContentType = "xml";
            int amount = Convert.ToInt32(Request.Form["amount"].Substring(0,
                Request.Form["amount"].IndexOf('.') > 0
                    ? Request.Form["amount"].IndexOf('.')
                    : Request.Form["amount"].Length));
            Dictionary<string,string> merchant_data = new Dictionary<string,string>();
            merchant_data.Add("some_key", "some_value");
            merchant_data.Add("some_key2", "some_value2");
            string mdata = new JavaScriptSerializer().Serialize(merchant_data);
            var reqXml = new CheckoutRequest
            {
                order_id = Request.Form["order_id"],
                amount = amount * 100,
                order_desc = "checkout xml demo",
                currency = "USD",
                merchant_data = mdata,
                response_url = Request.Url.Scheme + "://" + Request.Url.Authority + "/response.aspx",
                server_callback_url = "https://callback.test"
            };

            DoRequest(reqXml);
        }

        private void Submit(object sender, EventArgs e)
        {
            Config.ContentType = "json";
            int amount = Convert.ToInt32(Request.Form["amount"].Substring(0,
                Request.Form["amount"].IndexOf('.') > 0
                    ? Request.Form["amount"].IndexOf('.')
                    : Request.Form["amount"].Length));
            Dictionary<string,string> merchant_data = new Dictionary<string,string>();
            merchant_data.Add("some_key", "some_value");
            merchant_data.Add("some_key2", "some_value2");
            string mdata = new JavaScriptSerializer().Serialize(merchant_data);
            var req = new CheckoutRequest
            {
                order_id = Request.Form["order_id"],
                amount = amount * 100,
                order_desc = "checkout json demo",
                currency = "UAH",
                merchant_data = mdata,
                response_url = Request.Url.Scheme + "://" + Request.Url.Authority + "/response.aspx",
                server_callback_url = "https://callback.test"
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
                Data = resp.payment_id.ToString();
                DataUri = resp.checkout_url;
            }
        }
    }
}