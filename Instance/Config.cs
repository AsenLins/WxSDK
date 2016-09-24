using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Web;
using System.IO;
namespace WxSDK.Instance
{
    #region 微信公共配置类
    /// <summary>
    /// 微信公共配置类
    /// Create By Asen
    /// 2016-09-23
    /// </summary>
    #endregion
    public class Config
    {

        #region 微信公共配置
        /// <summary>
        /// 获取/设置公众号AppID
        /// </summary>
        public  string Appid
        {
            get{
                return GetValue("Appid");
            }
            set {
                SetValue("Appid",value);
            }
        }

        /// <summary>
        /// 获取/设置公众号的AppSecret
        /// </summary>
        public string Secret
        {
            get
            {
                return GetValue("Secret");
            }
            set {
                SetValue("Secret", value);
            }

        }

        /// <summary>
        /// 获取/设置公众号授权回调地址
        /// </summary>
        public string Authorize_Url {
            get
            {
                return GetValue("Authorize_Url");
            }
            set {
                SetValue("Authorize_Url", value);
            }
        }


        /// <summary>
        /// 获取/设置AccessToken
        /// </summary>
        public string AccessToken
        {
            get
            {
                return GetValue("AccessToken");
            }
            set {
                SetValue("AccessToken",value);
            }
        }

        /// <summary>
        /// 获取/设置AccessToken过期时间
        /// </summary>
        public string AccessToken_Expire
        {
            get
            {
                return GetValue("AccessToken_Expire");
            }
            set {
                SetValue("AccessToken_Expire", value);
            }
        }

        /// <summary>
        /// 获取/设置JsTicket
        /// </summary>
        public string JsTicket
        {
            get
            {
                return GetValue("JsTicket");
            }
            set {
                SetValue("JsTicket", value);
            }
        }

        /// <summary>
        /// 获取/设置JsTicket过期时间
        /// </summary>
        public string JsTicket_Expire {
            get {
                return GetValue("JsTicket_Expire");
            }
            set {
                SetValue("JsTicket_Expire", value);
            }
        }

        /// <summary>
        /// 获取/设置微信商户号
        /// </summary>
        public string Mch_id
        {
            get
            {
                return GetValue("Mch_id");
            }
            set {
                SetValue("Mch_id",value);
            }
        }

        /// <summary>
        /// 获取/设置商户号支付Key
        /// </summary>
        public string PayKey
        {
            get
            {
                return GetValue("PayKey");
            }
            set {
                SetValue("PayKey", value);
            }
        }

        #endregion

        #region 配置文件变量

        /// <summary>
        /// Xml配置文件锁
        /// </summary>
        private static readonly object ConfigLock = new object();

        /// <summary>
        /// 配置文件根目录
        /// </summary>
        internal static string RootPath = Path.Combine(HttpRuntime.AppDomainAppPath, "WxConfig");

        /// <summary>
        /// Xml配置文件路径
        /// </summary>
        internal static string FilePath = Path.Combine(RootPath, "Config.xml");

        #endregion

        #region 【方法】初始化配置文件
        public static void Init() {

            XDocument XDoc;
            if (Directory.Exists(FilePath))
            {
                return;
            }
            lock (ConfigLock)
            {
                if (Directory.Exists(RootPath) == false)
                {
                    Directory.CreateDirectory(RootPath);
                }
                if (File.Exists(FilePath) == false)
                {
                    XDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Config"));
                    XElement Root = XDoc.Element("Config");
                    Root.Add(new XElement("Appid",""));
                    Root.Add(new XElement("Secret",""));
                    Root.Add(new XElement("Authorize_Url", ""));
                    Root.Add(new XElement("PayKey",""));
                    Root.Add(new XElement("AccessToken", ""));
                    Root.Add(new XElement("AccessToken_Expire", ""));
                    Root.Add(new XElement("JsTicket",""));
                    Root.Add(new XElement("JsTicket_Expire",""));
                    Root.Add(new XElement("Mch_id", ""));
                    Root.Add(new XElement("PayKey",""));
                    XDoc.Save(FilePath);
                }
            }
        }
        #endregion

        #region 【方法】获取配置文件指定值
        /// <summary>
        /// 【方法】获取指定配置文件配置
        /// </summary>
        /// <param name="Name">设置名称</param>
        /// <returns>string</returns>
        private static string GetValue(string Name) {
            XDocument XDoc = XDocument.Load(FilePath);
            return XDoc.Element("Config").Element(Name).Value;
        }
        #endregion

        #region 【方法】设置配置文件指定值
        /// <summary>
        /// 设置配置文件指定值
        /// </summary>
        /// <param name="Name">名称</param>
        /// <param name="Value">值</param>
        private static void SetValue(string Name,string Value) {
            XDocument XDoc = XDocument.Load(FilePath);
            lock (ConfigLock)
            {
                XDoc.Element("Config").Element(Name).SetValue(Value);
                XDoc.Save(FilePath);
            }

        }
        #endregion
    }
}
