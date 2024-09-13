using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal static class HMACGenerator
    {
        internal static byte[] GetRandomKey()
        {
            byte[] key = RandomNumberGenerator.GetBytes(32);
            return key;
        }

        internal static string GetHMAC(byte[] hmacKey, string message)
        {
            using (var hmac = new HMACSHA256(hmacKey))
            {
                byte[] byteMessage = hmac.ComputeHash(Encoding.Default.GetBytes(message));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in byteMessage)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        internal static string GetKeyToString(byte[]key) 
        {
            StringBuilder sb = new StringBuilder();
            foreach (var b in key)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}

