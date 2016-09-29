using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WxSDK.Helper;
using System.Xml.Linq;
namespace WxSDK.Instance
{
    #region 全局基础AccessToken类
    /// <summary>
    /// 全局基础AccessToken类
    /// Create By Asen
    /// 2016-09-25
    /// </summary>
    #endregion
    public class AccessToken
    {

        /// <summary>
        /// 公共配置类
        /// </summary>
        Config Config = new Config();
        /// <summary>
        /// 设置全局AccessToken的锁
        /// </summary>
        public static readonly object TokenLock = new object();

        #region 【属性】获取全局AccessToken
        /// <summary>
        /// 获取全局AccessToken
        /// </summary>
        public string Get
        {
            get
            {
                if (ExpiredOrNull() == false)
                {
                    return Config.AccessToken;
                }
                else
                {
                    return Set();
                }
            }
        }
        #endregion

        #region 【方法】设置AccessToken与过期时间
        /// <summary>
        /// 设置AccessToken与过期时间
        /// </summary>
        /// <returns>AccessToken</returns>
        private string Set() {
            try
            {
                Url Url = new Url("https://api.weixin.qq.com/cgi-bin/token");
                Url.Head("?");
                Url.Body("grant_type", "client_credential");
                Url.Body("appid", Config.Appid);
                Url.Body("secret", Config.Secret);
                string AccessTokenUrl = Url.ToString();
                lock (TokenLock)
                {
                    if (ExpiredOrNull())
                    {
                        Http Http = new Http();
                        dynamic AcObj = Http.PostGetObj(AccessTokenUrl);
                        Config.AccessToken = AcObj.access_token;
                        Config.AccessToken_Expire = (DateTime.Now.AddSeconds(Convert.ToInt32(AcObj.expires_in))).ToString();
                    }
                }
                return Config.AccessToken;
            }
            catch (WxException WxEx)
            {
                throw WxEx;
            }
            catch (Exception ex)
            {
                throw new Exception("Wx.AccessToken.Set:设置全局AccessToken出错", ex);
            }
        }
        #endregion

        #region 【方法】判断AccessToken是否过期
        /// <summary>
        /// 判断AccessToken是否过期
        /// </summary>
        /// <returns>true/false</returns>
        private bool ExpiredOrNull()
        {
                if (string.IsNullOrEmpty(Config.AccessToken))
                {
                    return true;
                }

                DateTime ExpireTime = Convert.ToDateTime(Config.AccessToken_Expire);

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
