using System;
using System.Linq;
using System.Web.UI.WebControls;
using CloudIpspSDK.Payment;

namespace CloudIpspSamples
{
    public partial class PcidssSample : System.Web.UI.Page
    {
        protected PcidssResponse Data = null;
        protected string DataReqId = null;
        protected string DataError = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo ui = System.Globalization.CultureInfo.CurrentUICulture;
            string[] monthNames = ui.DateTimeFormat.MonthNames;
            int monthsInYear = ui.Calendar.GetMonthsInYear(DateTime.Now.Year);
            int monthNumber = 0;
            var monthsDataSource = monthNames.Take(monthsInYear).Select(monthName => new
            {
                Name = monthName,
                Value = monthNumber < 9 ? 0 + Convert.ToString(++monthNumber): Convert.ToString(++monthNumber)
            });

            card_expiry_month.DataTextField = "Name";
            card_expiry_month.DataValueField = "Value";
            card_expiry_month.DataSource = monthsDataSource;

            card_expiry_month.DataBind();
            if (Request.Form["card_expiry_month"] == null)
            {
                card_expiry_month.SelectedValue = DateTime.Now.Month.ToString();
            }

            for (int i = 0; i < 10; i++)
            {
                String year = (DateTime.Today.Year + i + 1).ToString();
                ListItem li = new ListItem(year, year.Substring(2, 2));
                card_expiry_year.Items.Add(li);
            }

            btnSubmitNon3ds.Click += new System.EventHandler(this.SubmitNon3ds);
        }

        protected void SubmitNon3ds(object sender, System.EventArgs e)
        {
            int amount = Convert.ToInt32(Request.Form["amount"].Substring(0,
                Request.Form["amount"].IndexOf('.') > 0
                    ? Request.Form["amount"].IndexOf('.')
                    : Request.Form["amount"].Length));
            var req = new StepOneRequest
            {
                order_id = Request.Form["order_id"],
                amount = amount * 100,
                order_desc = "checkout json demo",
                currency = "RUB",
                card_number = Request.Form["card_number"],
                cvv2 = Request.Form["card_cvv"],
                expiry_date = Request.Form["card_expiry_month"] + Request.Form["card_expiry_year"]
            };
            var resp = new Pcidss().StepOne(req);
            if (resp.Error != null)
            {
                DataError = resp.Error.ErrorMessage;
                DataReqId = resp.Error.RequestId;
            }
            else
            {
                Data = resp;
            }
        }
    }
}