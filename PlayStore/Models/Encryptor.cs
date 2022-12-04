using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.Models
{
   
        public class Encryptor
        {
            private static string GetMD5HashInString(byte[] hashCode)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashCode.Length; ++i)
                {
                    sb.Append(hashCode[i].ToString());
                }
                return sb.ToString();
            }
            public static string Encrypt(string str)
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] data = encoding.GetBytes(str);
                byte[] hash = new MD5CryptoServiceProvider().ComputeHash(data);
                return GetMD5HashInString(hash);
            }

        }
    
}
