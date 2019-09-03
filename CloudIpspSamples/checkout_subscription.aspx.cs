using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using CloudIpspSDK;
using CloudIpspSDK.Checkout;
using CloudIpspSDK.Models;

namespace CloudIpspSamples
{
    public partial class CheckoutSubscription : System.Web.UI.Page
    {
        protected string Data = null;
        protected string DataUri = null;
        protected string DataError = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo ui = System.Globalization.CultureInfo.CurrentUICulture;

            btnSubmit.Click += Submit;
        }

        private void Submit(object sender, EventArgs e)
        {
            Config.ContentType = "json";
            int amount = Convert.ToInt32(Request.Form["amount"].Substring(0,
                Request.Form["amount"].IndexOf('.') > 0
                    ? Request.Form["amount"].IndexOf('.')
                    : Request.Form["amount"].Length));
            int subamount = Convert.ToInt32(Request.Form["subscription_amount"].Substring(0,
                Request.Form["amount"].IndexOf('.') > 0
                    ? Request.Form["amount"].IndexOf('.')
                    : Request.Form["amount"].Length));
            Dictionary<string, string> merchant_data = new Dictionary<string, string>();
            merchant_data.Add("some_key", "some_value");
            merchant_data.Add("some_key2", "some_value2");
            string mdata = new JavaScriptSerializer().Serialize(merchant_data);
            var req = new SubscriptionRequest
            {
                order_id = Request.Form["order_id"],
                amount = amount * 100,
                order_desc = "checkout subscription demo",
                currency = "RUB",
                merchant_data = mdata,
                response_url = Request.Url.Scheme + "://" + Request.Url.Authority + "/response.aspx",
                server_callback_url = "https://callback.test",
                recurring_data =
                    new ReccuringData
                    {
                        every = 5,
                        period = "day",
                        amount = subamount * 100,
                        start_time = Request.Form["start_time"],
                        state = "y",
                        Readonly = "n"
                    }
            };
            DoRequest(req);
        }

        private void DoRequest(SubscriptionRequest req)
        {
            var resp = new Subscription().Post(req);
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