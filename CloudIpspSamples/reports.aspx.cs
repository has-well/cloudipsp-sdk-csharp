using System;
using CloudIpspSDK.Payment;

namespace CloudIpspSamples
{
    public partial class ReportSample : System.Web.UI.Page
    {
        protected ReportsResponse Data = null;
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
            var req = new ReportsRequest
            {
                date_from = Request.Form["date_from"],
                date_to = Request.Form["date_to"]
            };
            var resp = new Reports().Post(req);
            if (resp.Error != null)
            {
                DataError = resp.Error.ErrorMessage;
                DataErrorId = resp.Error.RequestId;
            }
            else
            {
                if (resp.response.Count == 0)
                {
                    DataNoList = "No data";
                }
                Data = resp;
            }
        }
    }
}