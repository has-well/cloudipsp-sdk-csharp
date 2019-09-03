using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using CloudIpspSDK.Payment;

namespace CloudIpspSamples
{
    public partial class ReccuringSample : System.Web.UI.Page
    {
        protected string Data = null;
        protected string DataOrder = null;
        protected string DataError = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo ui = System.Globalization.CultureInfo.CurrentUICulture;

            btnSubmit.Click += Submit;
        }

        private void Submit(object sender, EventArgs e)
        {
            int amount = Convert.ToInt32(Request.Form["amount"].Substring(0,
                Request.Form["amount"].IndexOf('.') > 0
                    ? Request.Form["amount"].IndexOf('.')
                    : Request.Form["amount"].Length));
            Dictionary<string,string> merchant_data = new Dictionary<string,string>();
            merchant_data.Add("some_key", "some_value");
            merchant_data.Add("some_key2", "some_value2");
            string mdata = new JavaScriptSerializer().Serialize(merchant_data);
            var req = new RectokenRequest
            {
                order_id = Request.Form["order_id"],
                amount = amount * 100,
                order_desc = "checkout json demo",
                currency = "EUR",
                merchant_data = mdata,
                rectoken = Request.Form["rectoken"]
            };
            DoRequest(req);
        }

        private void DoRequest(RectokenRequest req)
        {
            var resp = new Rectoken().Post(req);
            if (resp.Error != null)
            {
                DataError = resp.Error.ErrorMessage;
                Data = resp.Error.RequestId;
            }
            else
            {
                Data = resp.payment_id.ToString();
                DataOrder = resp.order_id;
            }
        }
    }
}