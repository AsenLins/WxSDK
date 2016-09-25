using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using WxSDK.Helper;

namespace WxSDK.Instance
{
    #region 微信用户授权/信息类
    /// <summary>
    /// 微信用户授权/信息类
    /// Create By Asen
    /// 2016-09-23
    /// </summary>
    #endregion

    public class User
    {
        /// <summary>
        /// 微信配置类
        /// </summary>
        Config Config = new Config();

        public User() { }

        #region 【方法】获取用户静默授权地址
        /// <summary>
        /// 获取用户静默授权地址
        /// </summary>
        /// <param name="Redirect_Uri">回调地址</param>
        /// <returns>URL</returns>
        public string Snsapi_Base(string Redirect_Uri)
        {
            return Snsapi_Login(Redirect_Uri, "snsapi_base");
        }
        #endregion

        #region 【方法】获取用户授权地址
        /// <summary>
        /// 获取用户授权地址
        /// </summary>
        /// <param name="Redirect_Uri">回调地址</param>
        /// <returns>静默授权的URL</returns>
        public string Snsapi_UserInfo(string Redirect_Uri)
        {
            return Snsapi_Login(Redirect_Uri, "snsapi_userinfo");
        }
        #endregion

        #region 【方法】获取AccessToken
        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <param name="Code">Code</param>
        /// <returns>获取AccessToken的Url</returns>
        public string GetAccessToken(string Code) {
      
            Url Url = new Url("https://api.weixin.qq.com/sns/oauth2/access_token");
            Url.Head("?");
            Url.Body("appid", Config.Appid);
            Url.Body("secret", Config.Secret);
            Url.Body("code", Code);
            Url.Body("grant_type", "authorization_code");
            return Url.ToString();
        }
        #endregion

        #region 【方法】用户授权地址主体方法
        /// <summary>
        /// 用户授权地址主体方法
        /// </summary>
        /// <param name="Redirect_Uri">地址</param>
        /// <param name="Scope">授权方式</param>
        /// <returns>授权Url</returns>
        private string Snsapi_Login(string Redirect_Uri, string Scope,string State="Default")
        {
            Url Url = new Url("https://open.weixin.qq.com/connect/oauth2/authorize");
            Url.Head("?");
            Url.Body("appid", Config.Appid);
            Url.Body("redirect_uri", Redirect_Uri);
            Url.Body("response_type", "code");
            Url.Body("scope", Scope);
            Url.Body("state", State);
            Url.Body("#wechat_redirect");
            return Url.ToString();      
        }
        #endregion

        #region 【方法】获取用户信息
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="AccessToken">AccessToken</param>
        /// <param name="OpenId">OpenId</param>
        /// <param name="Lang">语言</param>
        /// <returns>获取用户信息Url</returns>
        public string GetUserMes(string AccessToken, string OpenId, string Lang = "zh_CN")
        {
            //Http.Post("");
            Url Url = new Url(" https://api.weixin.qq.com/sns/userinfo");
            Url.Head("?");
            Url.Body("access_token", AccessToken);
            Url.Body("openid", OpenId);
            Url.Body("lang", Lang);
            return Url.ToString();
        }
        #endregion

        #region 【方法】获取用户列表
        public string GetUserList(string AccessToken, string Next_Openid)
        {
            Url Url = new Url("https://api.weixin.qq.com/cgi-bin/user/get");
            Url.Head("?");
            Url.Body("access_token", AccessToken);
            Url.Body("next_openid", Next_Openid);
            return Url.ToString();
        }
        #endregion
    }
}
