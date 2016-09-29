using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WxSDK.Helper;
namespace WxSDK.Instance
{
    #region JsTicket类
    /// <summary>
    /// JsTicket类
    /// Create By Asen
    /// 2016-09-25
    /// </summary>
    #endregion
    public class JsTicket
    {
        /// <summary>
        /// 公共配置类
        /// </summary>
        Config Config = new Config();
        /// <summary>
        /// 设置全局JsTicket的锁
        /// </summary>
        static readonly object TicketLock = new object();
        /// <summary>
        /// 随机字符串数组
        /// </summary>
        string[] NoncestrArray= new string[] { "A","B","C","D","E","F","G","H","I","J","1","2","3","4","5","6","7","8","9","0" };
        /// <summary>
        /// 随机字符串
        /// </summary>
        private string noncestr;
        /// <summary>
        /// 时间戳
        /// </summary>
        private string timestamp;


        #region 【属性】获取随机字符串
        /// <summary>
        /// 获取随机字符串
        /// </summary>
        public string Noncestr {
            get {
                if (string.IsNullOrEmpty(noncestr) == false)
                {
                    return noncestr;
                }

                StringBuilder RandomStr = new StringBuilder();
                Random Rd=new Random();
                for (int i = 0; i < NoncestrArray.Length; i++)
                {
                    RandomStr.Append(NoncestrArray[Rd.Next(0,NoncestrArray.Length-1)]);
                }
                noncestr = RandomStr.ToString();
                return noncestr;
            }
        }
        #endregion

        #region 【属性】获取时间戳
        /// <summary>
        /// 获取时间戳
        /// </summary>
        public string Timestamp
        {
            get {
                if (string.IsNullOrEmpty(timestamp) == false)
                {
                    return timestamp;
                }

                TimeSpan Ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                timestamp=Convert.ToInt64(Ts.TotalSeconds).ToString();
                return timestamp;
            }
        }
        #endregion

        #region 【属性】获取JsTicket
        /// <summary>
        /// 获取JsTicket
        /// </summary>
        public string Get {
            get
            {

                if (ExpiredOrNull()==false)
                {
                    return Config.JsTicket;
                }
                else
                {
                    return Set();
                }
            }
        }
        #endregion

        #region 【方法】组建JsTicket签名
        /// <summary>
        /// 组建JsTicket签名
        /// </summary>
        /// <param name="Noncestr">随机字符串</param>
        /// <param name="Timestamp">时间戳</param>
        /// <param name="PageUrl">当前页面地址</param>
        /// <returns>SHA1字符串</returns>
        public string Sign(string Noncestr, string Timestamp, string PageUrl)
        {
            if (PageUrl.Contains("#"))
            {
                PageUrl = PageUrl.Substring(0, PageUrl.IndexOf('#') - 1);
            }

            Url Url = new Url();
            Url.Body("jsapi_ticket", Config.JsTicket);
            Url.Body("noncestr", Noncestr);
            Url.Body("timestamp", Timestamp);
            Url.Body("url", PageUrl);
            return Encrypt.Get_SHA1(Url.ToString());
        }
        #endregion

        #region 【方法】设置JsTicket与过期时间
        /// <summary>
        /// 设置JsTicket与过期时间
        /// </summary>
        /// <returns>AccessToken</returns>
        private string Set()
        {
            try
            {
                AccessToken AccessToken = new AccessToken();
                Url Url = new Url("https://api.weixin.qq.com/cgi-bin/ticket/getticket");
                Url.Head("?");
                Url.Body("access_token", AccessToken.Get);
                Url.Body("type", "jsapi");
                string JsTicketUrl = Url.ToString();

                lock (TicketLock)
                {
                    if (ExpiredOrNull())
                    {
                        Http Http = new Http();
                        dynamic AcObj = Http.PostGetObj(JsTicketUrl);
                        Config.JsTicket = AcObj.ticket;
                        Config.JsTicket_Expire = (DateTime.Now.AddSeconds(Convert.ToInt32(AcObj.expires_in))).ToString();
                    }
                }
                return Config.JsTicket;
            }
            catch (WxException WxEx)
            {
                throw WxEx;
            }
            catch (Exception ex)
            {
                throw new Exception("Wx.JsTicket.Set:设置全局JsTicket出错", ex);
            }
        }
        #endregion

        #region 【方法】判断JsTicket是否过期
        /// <summary>
        /// 判断JsTicket是否过期
        /// </summary>
        /// <returns>true/false</returns>
        private bool ExpiredOrNull()
        {
            if (string.IsNullOrEmpty(Config.JsTicket))
            {
                return true;
            }

            DateTime ExpireTime = Convert.ToDateTime(Config.JsTicket_Expire);

            if (ExpireTime.AddMinutes(-1) > DateTime.Now)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion


    }
}
