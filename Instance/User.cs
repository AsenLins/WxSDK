using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Web;
using WxSDK.Model.User;

using WxSDK.Helper;
using Newtonsoft.Json;

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
        /// <summary>
        /// Http发送类
        /// </summary>
        Http Http = new Http();

        public User() { }

        #region 【方法】跳转静默授权
        /// <summary>
        /// 跳转静默授权
        /// </summary>
        /// <param name="Redirect_Uri">回调地址</param>
        /// <returns>URL</returns>
        public void Snsapi_Base(string Redirect_Uri)
        {
             Snsapi_Login(Redirect_Uri, "snsapi_base");
        }
        #endregion

        #region 【方法】跳转用户授权
        /// <summary>
        /// 跳转用户授权
        /// </summary>
        /// <param name="Redirect_Uri">回调地址</param>
        /// <returns>静默授权的URL</returns>
        public void Snsapi_UserInfo(string Redirect_Uri)
        {
             Snsapi_Login(Redirect_Uri, "snsapi_userinfo");
        }
        #endregion

        #region 【方法】获取AccessToken
        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <param name="Code">Code</param>
        /// <returns>获取AccessToken的Url</returns>
        public WxAccessToken GetAccessToken(string Code) {
            try
            {
                Url Url = new Url("https://api.weixin.qq.com/sns/oauth2/access_token");
                Url.Head("?");
                Url.Body("appid", Config.Appid);
                Url.Body("secret", Config.Secret);
                Url.Body("code", Code);
                Url.Body("grant_type", "authorization_code");
                string ResultStr = Http.Post(Url.ToString());
                return JsonConvert.DeserializeObject<WxAccessToken>(ResultStr);
            }
            catch (WxException WxEx)
            {
                throw WxEx;
            }
            catch (Exception ex)
            {
                throw new Exception("Wx.User.GetAccessToken:获取用户AccessToken出错", ex);
            }
        }
        #endregion

        #region 【方法】用户授权地址主体方法
        /// <summary>
        /// 用户授权地址主体方法
        /// </summary>
        /// <param name="Redirect_Uri">地址</param>
        /// <param name="Scope">授权方式</param>
        /// <returns>授权Url</returns>
        private void Snsapi_Login(string Redirect_Uri, string Scope,string State="Default")
        {
            try
            {
                Url Url = new Url("https://open.weixin.qq.com/connect/oauth2/authorize");
                Url.Head("?");
                Url.Body("appid", Config.Appid);
                Url.Body("redirect_uri", Redirect_Uri);
                Url.Body("response_type", "code");
                Url.Body("scope", Scope);
                Url.Body("state", State);
                Url.Body("#wechat_redirect");
                HttpContext.Current.Response.Redirect(Url.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Wx.User.Snsapi_Login:用户授权/静默授权跳转出错", ex);
            }
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
        public WxUser GetUserMes(string AccessToken, string OpenId, string Lang = "zh_CN")
        {
            try
            {
                Url Url = new Url(" https://api.weixin.qq.com/sns/userinfo");
                Url.Head("?");
                Url.Body("access_token", AccessToken);
                Url.Body("openid", OpenId);
                Url.Body("lang", Lang);
                string ResultStr = Http.Post(Url.ToString());
                return JsonConvert.DeserializeObject<WxUser>(ResultStr);
            }
            catch (WxException WxEx)
            {
                throw WxEx;
            }
            catch (Exception ex)
            {
                throw new Exception("Wx.User.GetUserMes:获取用户详细信息出错", ex);
            }
        }
        #endregion

        #region 【方法】获取用户列表
        public WxUserList GetUserList(string AccessToken, string Next_Openid = "")
        {
            try
            {
                WxUserList UserList = new WxUserList();
                Url Url = new Url("https://api.weixin.qq.com/cgi-bin/user/get");
                Url.Head("?");
                Url.Body("access_token", AccessToken);
                Url.Body("next_openid", Next_Openid);
                string ResultStr = Http.Post(Url.ToString());
                return JsonConvert.DeserializeObject<WxUserList>(ResultStr);
            }
            catch (WxException WxEx)
            {
                throw WxEx;
            }
            catch (Exception ex)
            {
                throw new Exception("Wx.User.GetUserList:获取用户列表出错", ex);
            }
        }
        #endregion
    }
}
