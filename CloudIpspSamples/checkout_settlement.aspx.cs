using System;
using System.Collections.Generic;
using CloudIpspSDK.Checkout;
using CloudIpspSDK.Models;

namespace CloudIpspSamples
{
    public partial class CheckoutSettlement : System.Web.UI.Page
    {
        protected SettlementResponse Data = null;
        protected string DataError = null;
        protected string RequestId = null;

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

            List<ReceiverModel> receivers = new List<ReceiverModel>(2);

            Merchant receiver1 = new Merchant();
            receiver1.amount = 100;
            receiver1.merchant_id = 600001;
            receiver1.settlement_description = "Test";

            Merchant receiver2 = new Merchant();
            receiver2.amount = 1000;
            receiver2.merchant_id = 500001;
            receiver2.settlement_description = "Test2";

            ReceiverModel res1 = new ReceiverModel()
            {
                requisites = receiver1,
                type = "merchant"
            };
            ReceiverModel res2 = new ReceiverModel()
            {
                requisites = receiver2,
                type = "merchant"
            };
            receivers.Add(res1);
            receivers.Add(res2);


            var req = new SettlementRequest
            {
                order_id = Request.Form["order_id"],
                amount = amount * 100,
                order_desc = "checkout json demo",
                currency = "RUB",
                receiver = receivers,
                operation_id = "443e7e57-d2eb-4793-842e-a45c5be8011c"
            };
            DoRequest(req);
        }

        private void DoRequest(SettlementRequest req)
        {
            var resp = new Settlement().Post(req);
            if (resp.Error != null)
            {
                DataError = resp.Error.ErrorMessage;
                RequestId = resp.Error.RequestId;
            }
            else
            {
                Data = resp;
            }
        }
    }
}