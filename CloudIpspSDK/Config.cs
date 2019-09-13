namespace CloudIpspSDK
{
    public static class Config
    {
        /// <summary>
        /// Merchant identification
        /// </summary>
        public static int MerchantId { get; set; }

        /// <summary>
        /// Merchant Secret Key
        /// </summary>
        public static string SecretKey { get; set; }

        /// <summary>
        /// Merchant Credit Key
        /// </summary>
        public static string CreditKey { get; set; }

        /// <summary>
        /// Get content type
        /// </summary>
        private static string contentType = "json";

        public static string ContentType
        {
            get { return contentType; }
            set { contentType = value; }
        }

        /// <summary>
        /// Protocol version supported (1.0/2.0)
        /// </summary>
        public static string Protocol = "1.0";

        /// <summary>
        /// Protocol version supported (1.0/2.0)
        /// </summary>
        public static string ApiHost = "api.fondy.eu";


        /// <summary>
        /// Set api endpoint
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string Endpoint(string url)
        {
            string domain = @"https://{0}/api/";
            if (url == null)
            {
                url = ApiHost;
            }

            return string.Format(domain, url);
        }
    }
}
