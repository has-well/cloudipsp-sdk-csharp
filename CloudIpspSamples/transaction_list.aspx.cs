using System;
using CloudIpspSDK.Order;

namespace CloudIpspSamples
{
    public partial class TransactionListSample : System.Web.UI.Page
    {
        protected TransactionListResponse Data = null;
        protected string DataError = null;
        protected string DataNoList = null;
        protected string DataErrorId = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo ui = System.Globalization.CultureInfo.CurrentUICulture;

            btnSubmit.Click += Submit;
        }

        private void Submit(object sender, EventArgs e)
        {
            var req = new TransactionListRequest
            {
                order_id = Request.Form["order_id"],
            };
            var resp = new TransactionList().Post(req);
            if (resp.Error != null)
            {
                DataError = resp.Error.ErrorMessage;
                DataErrorId = resp.Error.RequestId;
            }
            else
            {
                if (resp.response.Count == 0)
                {
                    DataNoList = "No transactions";
                }
                Data = resp;
            }
        }
    }
}