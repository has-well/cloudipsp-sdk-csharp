using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudIpspSDK;
using CloudIpspSDK.Payment;

namespace CloudIpspSdkTest
{
    [TestClass]
    public class Psidss
    {
        public int MerchantId = 1396424;
        public string SecretKey = "test";
        public string ContentType = "json";
        public string Endpoint = "api.fondy.eu";
        public string card_number = "4444555511116666";
        public string card_number_3ds = "4444555566661111";
        public string cvv2 = "111";
        public string expiry_date = "0130";

        [TestMethod]
        public void PcidssStepOne()
        {
            Config.MerchantId = MerchantId;
            Config.SecretKey = SecretKey;
            Config.ContentType = ContentType;
            Config.Endpoint(Endpoint);
            string orderId = Guid.NewGuid().ToString();
            var req = new StepOneRequest
            {
                order_id = orderId,
                amount = 10000,
                order_desc = "checkout tests",
                currency = "EUR",
                card_number = card_number,
                cvv2 = cvv2,
                expiry_date = expiry_date
            };
            var resp = new Pcidss().StepOne(req);

            Assert.IsNotNull(resp);
            Assert.AreEqual("approved", resp.order_status);
            Assert.AreEqual(orderId, resp.order_id);
            Assert.IsNotNull(resp.order_id);
        }

        [TestMethod]
        public void PcidssStepTwo()
        {
            Config.MerchantId = MerchantId;
            Config.SecretKey = SecretKey;
            Config.ContentType = "form";
            Config.Endpoint(Endpoint);
            var req = new StepOneRequest()
            {
                order_id = Guid.NewGuid().ToString(),
                amount = 10000,
                order_desc = "checkout tests",
                currency = "EUR",
                card_number = card_number_3ds,
                cvv2 = cvv2,
                expiry_date = expiry_date
            };
            var resp = new Pcidss().StepOne(req);

            Assert.IsNotNull(resp);
            Assert.IsNotNull(resp.md);
            Assert.IsNotNull(resp.pareq);
            Assert.IsNull(resp.order_id);
        }
    }
}