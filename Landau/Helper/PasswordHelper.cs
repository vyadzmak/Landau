﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Landau.Helper
{
    public static class PasswordHelper
    {
        #region Password
        public static class Crypt
        {

            public static string Key = "ECQFQUE8KS2d3qUF";
            /// <summary>
            /// 
            /// </summary>
            /// <param name="data"></param>
            /// <param name="password"></param>
            /// <returns></returns>
            private static byte[] Encrypt(byte[] data, string password)
            {
                SymmetricAlgorithm sa = Rijndael.Create();
                ICryptoTransform ct = sa.CreateEncryptor(
                    (new PasswordDeriveBytes(password, null)).GetBytes(16),
                    new byte[16]);

                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);

                cs.Write(data, 0, data.Length);
                cs.FlushFinalBlock();

                return ms.ToArray();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="data"></param> 
            /// <returns></returns>
            public static string EncryptString(string data)
            {
                string password = Key;
                return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(data), password));
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="data"></param>
            /// <param name="password"></param>
            /// <returns></returns>
            private static byte[] Decrypt(byte[] data, string password)
            {
                BinaryReader br = new BinaryReader(InternalDecrypt(data, password));
                return br.ReadBytes((int)br.BaseStream.Length);
            }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="data"></param>
            /// <returns></returns>
            static public string DecryptString(string data)
            {
                string password = Key;

                CryptoStream cs = InternalDecrypt(Convert.FromBase64String(data), password);
                StreamReader sr = new StreamReader(cs);
                return sr.ReadToEnd();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="data"></param>
            /// <param name="password"></param>
            /// <returns></returns>
            private static CryptoStream InternalDecrypt(byte[] data, string password)
            {
                SymmetricAlgorithm sa = Rijndael.Create();
                ICryptoTransform ct = sa.CreateDecryptor(
                    (new PasswordDeriveBytes(password, null)).GetBytes(16),
                    new byte[16]);

                MemoryStream ms = new MemoryStream(data);
                return new CryptoStream(ms, ct, CryptoStreamMode.Read);
            }
        }
        #endregion
    }
}