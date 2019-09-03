using System;
using System.Configuration;
using CloudIpspSDK;

namespace CloudIpspSamples
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            System.Net.ServicePointManager.SecurityProtocol =
                System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Tls11 |
                System.Net.SecurityProtocolType.Tls12;

            Config.MerchantId = Int32.Parse(ConfigurationManager.AppSettings["merchantID"]);
            Config.SecretKey = ConfigurationManager.AppSettings["secretKey"];
            Config.ContentType = ConfigurationManager.AppSettings["contentType"];
            Config.Protocol = ConfigurationManager.AppSettings["protocol"];
            Config.ApiHost = ConfigurationManager.AppSettings["ApiHost"];
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}