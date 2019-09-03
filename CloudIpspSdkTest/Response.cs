using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudIpspSDK;
using CloudIpspSDK.Response;

namespace CloudIpspSdkTest
{
    [TestClass]
    public class ResponseTest
    {
        public int MerchantId = 1396424;
        public string SecretKey = "test";
        public string Endpoint = "api.fondy.eu";

        [TestMethod]
        public void ResponseXml()
        {
            Config.MerchantId = MerchantId;
            Config.SecretKey = SecretKey;
            Config.ContentType = "xml";
            Config.Endpoint(Endpoint);
            string text =
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<response><rrn /><masked_card>444455XXXXXX6666</masked_card><sender_cell_phone /><response_signature_string>**********|10000|USD|10000|123456|444455|VISA|USD|7|444455XXXXXX6666|{\"XML\":{\"SomeID\":123,\"SomeString\":\"sting\"},\"XML2\":{\"SomeID\":321,\"SomeString\":\"sting2\"}}|1396424|9741eaf4-3eb7-4349-b62f-d322c891fed9|approved|02.09.2019 13:49:38|163235037|card|success|0|0|purchase</response_signature_string><response_status>success</response_status><sender_account /><fee /><rectoken_lifetime /><reversal_amount>0</reversal_amount><settlement_amount>0</settlement_amount><actual_amount>10000</actual_amount><order_status>approved</order_status><response_description /><verification_status /><order_time>02.09.2019 13:49:38</order_time><actual_currency>USD</actual_currency><order_id>9741eaf4-3eb7-4349-b62f-d322c891fed9</order_id><parent_order_id /><merchant_data>{\"XML\":{\"SomeID\":123,\"SomeString\":\"sting\"},\"XML2\":{\"SomeID\":321,\"SomeString\":\"sting2\"}}</merchant_data><tran_type>purchase</tran_type><eci>7</eci><settlement_date /><payment_system>card</payment_system><rectoken /><approval_code>123456</approval_code><merchant_id>1396424</merchant_id><settlement_currency /><payment_id>163235037</payment_id><product_id /><currency>USD</currency><card_bin>444455</card_bin><response_code /><card_type>VISA</card_type><amount>10000</amount><sender_email /><signature>5bad75ed93366df998de387188ef26c36d9502b3</signature></response>";
            var resp = new Response().GetResponse(text);

            Assert.IsNotNull(resp);
            Assert.IsNotNull(resp.order_id);
            Assert.IsNotNull(resp.order_status);
            Assert.AreEqual("approved", resp.order_status);
            Assert.AreEqual(10000, resp.amount);
        }

        [TestMethod]
        public void ResponseForm()
        {
            Config.MerchantId = MerchantId;
            Config.SecretKey = SecretKey;
            Config.ContentType = "form";
            Config.Endpoint(Endpoint);
            string text =
                "rrn=429417347068&masked_card=444455XXXXXX6666&sender_cell_phone=&response_signature_string=**********%7C10000%7CRUB%7C10000%7C027440%7C444455%7CVISA%7CRUB%7C7%7C444455XXXXXX6666%7C%7B%22cat%22%3A%22123%22%2C%22dog%22%3A%22321%22%2C%22llama%22%3A%22321%22%2C%22iguana%22%3A%22321%22%7D%7C1396424%7C1dd3c296-23fe-4efb-8fce-3b700d92192b%7Capproved%7C02.09.2019+12%3A37%3A42%7C163225480%7Ccard%7Csuccess%7C0%7C429417347068%7C0%7Cpurchase&response_status=success&sender_account=&fee=&rectoken_lifetime=&reversal_amount=0&settlement_amount=0&actual_amount=10000&order_status=approved&response_description=&verification_status=&order_time=02.09.2019+12%3A37%3A42&actual_currency=RUB&order_id=1dd3c296-23fe-4efb-8fce-3b700d92192b&parent_order_id=&merchant_data=%7B%22cat%22%3A%22123%22%2C%22dog%22%3A%22321%22%2C%22llama%22%3A%22321%22%2C%22iguana%22%3A%22321%22%7D&tran_type=purchase&eci=7&settlement_date=&payment_system=card&rectoken=&approval_code=027440&merchant_id=1396424&settlement_currency=&payment_id=163225480&product_id=&currency=RUB&card_bin=444455&response_code=&card_type=VISA&amount=10000&sender_email=&signature=a130a1605c931e7f6465db2e1fabe87f9121bf99";
            var resp = new Response().GetResponse(text);

            Assert.IsNotNull(resp);
            Assert.IsNotNull(resp.order_id);
            Assert.IsNotNull(resp.order_status);
            Assert.AreEqual("approved", resp.order_status);
            Assert.AreEqual(10000, resp.amount);
        }

        [TestMethod]
        public void ResponseJson()
        {
            Config.MerchantId = MerchantId;
            Config.SecretKey = SecretKey;
            Config.ContentType = "json";
            Config.Endpoint(Endpoint);
            string text =
                "{\"rrn\": \"429417347068\",\"masked_card\": \"444455XXXXXX6666\",\"sender_cell_phone\": \"\",\"response_signature_string\": \"**********|10000|RUB|10000|027440|444455|VISA|RUB|7|444455XXXXXX6666|{\\\"cat\\\":\\\"123\\\",\\\"dog\\\":\\\"321\\\",\\\"llama\\\":\\\"321\\\",\\\"iguana\\\":\\\"321\\\"}|1396424|1dd3c296-23fe-4efb-8fce-3b700d92192b|approved|02.09.2019 12:37:42|163225480|card|success|0|429417347068|0|purchase\",\"response_status\": \"success\",\"sender_account\": \"\",\"fee\": \"\",\"rectoken_lifetime\": \"\",\"reversal_amount\": \"0\",\"settlement_amount\": \"0\",\"actual_amount\": \"10000\",\"order_status\": \"approved\",\"response_description\": \"\",\"verification_status\": \"\",\"order_time\": \"02.09.2019 12:37:42\",\"actual_currency\": \"RUB\",\"order_id\": \"1dd3c296-23fe-4efb-8fce-3b700d92192b\",\"parent_order_id\": \"\",\"merchant_data\": \"{\\\"cat\\\":\\\"123\\\",\\\"dog\\\":\\\"321\\\",\\\"llama\\\":\\\"321\\\",\\\"iguana\\\":\\\"321\\\"}\",\"tran_type\": \"purchase\",\"eci\": \"7\",\"settlement_date\": \"\",\"payment_system\": \"card\",\"rectoken\": \"\",\"approval_code\": \"027440\",\"merchant_id\": 1396424,\"settlement_currency\": \"\",\"payment_id\": 163225480,\"product_id\": \"\",\"currency\": \"RUB\",\"card_bin\": 444455,\"response_code\": \"\",\"card_type\": \"VISA\",\"amount\": \"10000\",\"sender_email\": \"\",\"signature\": \"a130a1605c931e7f6465db2e1fabe87f9121bf99\"}";
            var resp = new Response().GetResponse(text);

            Assert.IsNotNull(resp);
            Assert.IsNotNull(resp.order_id);
            Assert.IsNotNull(resp.order_status);
            Assert.AreEqual("approved", resp.order_status);
            Assert.AreEqual(10000, resp.amount);
        }
    }
}