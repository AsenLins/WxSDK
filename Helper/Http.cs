using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
namespace WxSDK.Helper
{
    #region 用于模拟Http请求发送类
    /// <summary>
    /// 用于模拟Http请求发送类
    /// Create By Asen
    /// 2016-09-24
    /// </summary>
    #endregion
    public class Http
    {
        #region 【方法】发送Post请求,把请求返回值转换成动态对象(dynamic)
        /// <summary>
        /// 【方法】发送Post请求,把请求返回值转换成动态对象(dynamic)
        /// </summary>
        /// <param name="Url">请求地址与参数</param>
        /// <param name="Method">请求方式</param>
        /// <param name="Encode">编码</param>
        /// <param name="ContentType">请求内容类型</param>
        /// <returns>动态对象</returns>
        public dynamic PostGetObj(string Url, string Method = "GET", string Encode = "UTF-8", string ContentType = "application/x-www-form-urlencoded")
        {
           
            return JsonConvert.DeserializeObject<dynamic>(PostMethod(Url, Method, Encode, ContentType));
        }
        #endregion


        #region 【方法】发送Post请求,直接返回请求返回值（string）
        /// <summary>
        /// 【方法】发送Post请求,直接返回请求返回值（string）
        /// </summary>
        /// <param name="Url">请求地址与参数</param>
        /// <param name="Method">请求方式</param>
        /// <param name="Encode">编码</param>
        /// <param name="ContentType">请求内容类型</param>
        /// <returns>字符串值</returns>
        public string Post(string Url, string Method = "GET", string Encode = "UTF-8", string ContentType = "application/x-www-form-urlencoded")
        {
            return PostMethod(Url, Method, Encode, ContentType);
        }
        #endregion

        #region 【方法】自拟Http请求
        /// <summary>
        /// 自拟Http请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="Method">请求方式（GET/POST）</param>
        private string PostMethod(string Url, string Method, string Encode, string ContentType)
        {
            
            Method=Method.ToUpper();
            string Param = "";
            int ParamIndex = Url.IndexOf('?');
            if (ParamIndex > -1&&Method=="POST")
            {
                Param = Url.Substring(ParamIndex + 1);
                Url = Url.Substring(0, ParamIndex - 1);
            }

            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(Url);
            Request.Method = Method;

            if (Method == "POST")
            {


                byte[] data = Encoding.GetEncoding(Encode).GetBytes(Param);
                Request.ContentType = ContentType;
                Request.ContentLength = data.Length;
                Stream newStream = Request.GetRequestStream();
                /*发送请求*/
                newStream.Write(data, 0, data.Length);
                newStream.Close();
            }
            /*获取请求返回数据*/
            Stream StrRes = null;
            StrRes = Request.GetResponse().GetResponseStream();

            StreamReader StrRead = new StreamReader(StrRes);
            string ReturnStr = StrRead.ReadToEnd();
            StrRead.Close();
            return ReturnStr;
        }
        #endregion




    }
}
