using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using WxSDK.Model.Exception;
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
        public dynamic PostGetObj(string Url, string Method = "GET", string PostParam = "", string Encode = "UTF-8", string ContentType = "application/x-www-form-urlencoded")
        {

            return JsonConvert.DeserializeObject<dynamic>(PostMethod(Url, Method, PostParam, Encode, ContentType));
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
        public string Post(string Url,string Method = "GET",string PostParam="",string Encode = "UTF-8", string ContentType = "application/x-www-form-urlencoded")
        {
            return PostMethod(Url, Method,PostParam,Encode, ContentType);
        }
        #endregion

        #region 【方法】自拟Http请求
        /// <summary>
        /// 自拟Http请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="Method">请求方式（GET/POST）</param>
        private string PostMethod(string Url, string Method,string PostParam,string Encode, string ContentType)
        {
            
            Method=Method.ToUpper();
            string Param = "";

            if (string.IsNullOrEmpty(PostParam))
            {
                int ParamIndex = Url.IndexOf('?');

                if (ParamIndex > -1 && Method == "POST")
                {
                    Param = Url.Substring(ParamIndex + 1);
                    Url = Url.Substring(0, ParamIndex);
                }
            }
            else
            {
                Param = PostParam;
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

            if (ReturnStr.Contains("errcode"))
            {
                WxError WxError = JsonConvert.DeserializeObject<WxError>(ReturnStr);

                if (WxError.errcode == "0")
                {
                    return "ok";
                }
                WxException _WxException = new WxException("微信接口调用异常,errorcode："+WxError.errcode+",errmsg："+WxError.errmsg);
                _WxException.errcode = WxError.errcode;
                _WxException.errmsg = WxError.errmsg;
                _WxException.errorigin = ReturnStr;
                throw _WxException;
            }
 
            StrRead.Close();
            return ReturnStr;
        }
        #endregion




    }
}
