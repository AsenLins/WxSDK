using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WxSDK.Helper;
namespace WxSDK.Instance
{
    public class AccessToken
    {
        Config Config = new Config();



        public string Get() {
            if (string.IsNullOrEmpty(Config.AccessToken))
            {
                //https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=APPID&secret=APPSECRET
            }

            return "";
        
        }

        public string GetAccessToken() {
            Url Url = new Url("https://api.weixin.qq.com/cgi-bin/token");
            Url.Head("?");
            Url.Body("grant_type", "client_credential");
            Url.Body("appid", Config.Appid);
            Url.Body("secret", Config.Secret);
            return Url.Finish();
        }


    }
}
