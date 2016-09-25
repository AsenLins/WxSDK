using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
namespace WxSDK.Helper
{
    #region 字符串加密类
    /// <summary>
    /// 字符串加密类
    /// Create By Asen
    /// 2016-09-25
    /// </summary>
    #endregion
    public static class Encrypt
    {

        #region 【方法】MD5组合字符串
        /// <summary>
        /// MD5组合字符串
        /// </summary>
        /// <param name="EncryptStr">要组合的字符串</param>
        /// <returns>MD5字符串</returns>
        public static string Get_MD5(string EncryptStr) {
            byte[] Buffer = Encoding.Default.GetBytes(EncryptStr);
            //接着，创建Md5对象进行散列计算
            var Data=MD5.Create().ComputeHash(Buffer);

             //创建一个新的Stringbuilder收集字节
            var Str = new StringBuilder();

             //遍历每个字节的散列数据 
            foreach (var t in Data)
             {
                 //格式每一个十六进制字符串
                 Str.Append(t.ToString("X2"));
             }
             //返回十六进制字符串
             return Str.ToString();
        }
        #endregion

        #region 【方法】SHA1组合字符串
        /// <summary>
        /// SHA1组合字符串
        /// </summary>
        /// <param name="EncryptStr">要组合的字符串</param>
        /// <returns>SHA1字符串</returns>
        public static string Get_SHA1(string EncryptStr)
        {
            byte[] OriginByte = Encoding.Default.GetBytes(EncryptStr);
            byte[] SHA1Byte = SHA1.Create().ComputeHash(OriginByte);
            return BitConverter.ToString(SHA1Byte).Replace("-", "");

             //var Buffer = Encoding.UTF8.GetBytes(EncryptStr);
             //var Data = SHA1.Create().ComputeHash(Buffer);
 
             //var Str = new StringBuilder();
             //foreach (var t in Data)
             //{
             //    Str.Append(t.ToString("X2"));
             //}
             //return Str.ToString();
        }
        #endregion




    }
}
