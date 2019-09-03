using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudIpspSDK;
using CloudIpspSDK.Checkout;

namespace CloudIpspSdkTest
{
    [TestClass]
    public class Checkout
    {
        public int MerchantId = 1396424;
        public string SecretKey = "test";
        public string ContentType = "json";
        public string Endpoint = "api.fondy.eu";

        [TestMethod]
        public void TestCheckout()
        {
            Config.MerchantId = MerchantId;
            Config.SecretKey = SecretKey;
            Config.ContentType = ContentType;
            Config.Endpoint(Endpoint);
            string orderId = Guid.NewGuid().ToString();
            var req = new CheckoutRequest
            {
                order_id = orderId,
                amount = 10000,
                order_desc = "checkout tests demo",
                currency = "USD"
            };
            var resp = new Url().Post(req);

            Assert.IsNotNull(resp);
            Assert.AreEqual("success", resp.response_status);
            Assert.IsNotNull(resp.payment_id);
        }

        [TestMethod]
        public void TestCheckoutXml()
        {
            Config.MerchantId = MerchantId;
            Config.SecretKey = SecretKey;
            Config.ContentType = "xml";
            Config.Endpoint(Endpoint);
            string orderId = Guid.NewGuid().ToString();
            var req = new CheckoutRequest
            {
                order_id = orderId,
                amount = 10000,
                order_desc = "checkout tests demo",
                currency = "USD"
            };
            var resp = new Url().Post(req);

            Assert.IsNotNull(resp);
            Assert.AreEqual("success", resp.response_status);
            Assert.IsNotNull(resp.payment_id);
        }

        [TestMethod]
        public void TestToken()
        {
            Config.MerchantId = MerchantId;
            Config.SecretKey = SecretKey;
            Config.ContentType = ContentType;
            Config.Endpoint(Endpoint);
            var req = new TokenRequest
            {
                order_id = Guid.NewGuid().ToString(),
                amount = 10500,
                order_desc = "checkout tests demo",
                currency = "USD"
            };
            var resp = new Token().Post(req);

            Assert.IsNotNull(resp);
            Assert.AreEqual("success", resp.response_status);
            Assert.IsNotNull(resp.token);
        }

        [TestMethod]
        public void TestXmlToken()
        {
            Config.MerchantId = MerchantId;
            Config.SecretKey = SecretKey;
            Config.ContentType = "xml";
            Config.Endpoint(Endpoint);
            var req = new TokenRequest
            {
                order_id = Guid.NewGuid().ToString(),
                amount = 10500,
                order_desc = "checkout tests demo",
                currency = "USD"
            };
            var resp = new Token().Post(req);

            Assert.IsNotNull(resp);
            Assert.AreEqual("success", resp.response_status);
            Assert.IsNotNull(resp.token);
        }

        [TestMethod]
        public void TestFormToken()
        {
            Config.MerchantId = MerchantId;
            Config.SecretKey = SecretKey;
            Config.ContentType = "form";
            Config.Endpoint(Endpoint);
            var req = new TokenRequest
            {
                order_id = Guid.NewGuid().ToString(),
                amount = 10500,
                order_desc = "checkout tests demo",
                currency = "USD"
            };
            var resp = new Token().Post(req);

            Assert.IsNotNull(resp);
            Assert.AreEqual("success", resp.response_status);
            Assert.IsNotNull(resp.token);
        }
    }
}