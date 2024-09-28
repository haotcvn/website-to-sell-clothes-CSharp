using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebApplication.Models.Systems
{
    public class mapEncode
    {
        public string CreateMD5(string data)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] inputBytes = Encoding.UTF8.GetBytes(data);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string prior to .NET 5
            StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}