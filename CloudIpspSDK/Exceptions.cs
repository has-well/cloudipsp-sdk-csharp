using System;

namespace CloudIpspSDK
{
    /// <summary>
    /// Base Client Exception
    /// </summary>
    public class ClientException : Exception
    {
        public string ErrorMessage { get; set; }
        public string RequestId { get; set; }
        public string ErrorCode { get; set; }
    }
    /// <summary>
    /// Invalid Response signature exception
    /// </summary>
    public class SignatureException : Exception
    {
        public string SignatureString { get; set; }
        public string CalculatedSignature { get; set; }
    }
}