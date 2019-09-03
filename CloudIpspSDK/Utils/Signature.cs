using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace CloudIpspSDK.Utils
{
    public static class Signature
    {
        /// <summary>
        /// Generate the signature version 2
        /// </summary>
        public static string GetRequestSignatureV2(string data, bool credit = false)
        {
            string secret = Config.SecretKey;
            if (credit)
            {
                secret = Config.CreditKey;
            }
            string signature = secret + "|" + data;
            return GetSha1(signature).ToLower();
        }
        /// <summary>
        /// Generate the signature version 1
        /// </summary>
        public static string GetRequestSignature(IEnumerable<string> hashKeys, bool credit = false)
        {
            string signature = string.Join("|", hashKeys);
            string secret = Config.SecretKey;
            if (credit)
            {
                secret = Config.CreditKey;
            }
            signature = secret + "|" + signature;
            return GetSha1(signature).ToLower();
        }

        /// <summary>
        /// Generate Sha1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string GetSha1(string value)
        {
            var data = Encoding.ASCII.GetBytes(value);
            var hashData = new SHA1Managed().ComputeHash(data);
            var hash = string.Empty;
            foreach (var b in hashData)
            {
                hash += b.ToString("X2");
            }

            return hash.ToLower();
        }
        /// <summary>
        /// Encode base64 String
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Base64Encode(string data) {
            var plainTextBytes = Encoding.UTF8.GetBytes(data);
            return Convert.ToBase64String(plainTextBytes);
        }
        
        /// <summary>
        /// Decode base64 String
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Base64Decode(string data) {
            byte[] decoded = Convert.FromBase64String(data);
            return Encoding.UTF8.GetString(decoded);
        }
    }
}