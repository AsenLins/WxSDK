using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WxSDK.Instance;
using WxSDK.Helper;
namespace WxSDK
{
    public class Wx
    {

        /// <summary>
        /// 微信支付类
        /// </summary>
        private Pay pay;
        /// <summary>
        /// 微信菜单类
        /// </summary>
        private Menu menu;
        /// <summary>
        /// 微信用户类
        /// </summary>
        private User user;
        /// <summary>
        /// 微信用户消息类
        /// </summary>
        private Mes mes;
        /// <summary>
        /// 微信全局AccessToken类
        /// </summary>
        private AccessToken accessToken;
        /// <summary>
        /// 微信JsTicket类
        /// </summary>
        private JsTicket jsTicket;
        /// <summary>
        /// 微信全局配置类
        /// </summary>
        private Config config;
        /// <summary>
        /// 微信发送类
        /// </summary>
        private Http http;

        public Pay Pay
        {
            get
            {
                if (pay == null)
                {
                    pay = new Pay();
                }
                return pay;

            }
        }

        public Menu Menu
        {
            get
            {
                if (menu == null)
                {
                    menu = new Menu();
                }
                return menu;
            }
        }

        public User User
        {
            get
            {
                if (user == null)
                {
                    user = new User();
                }
                return user;
            }
        }

        public Mes Mes
        {
            get
            {
                if (mes == null)
                {
                    mes = new Mes();
                }
                return mes;
            }
        }

        public AccessToken AccessToken {
            get
            {
                if (accessToken == null)
                {
                    accessToken = new AccessToken();
                }
                return accessToken;
            }
        }

        public JsTicket JsTicket
        {
            get
            {
                if (jsTicket == null)
                {
                    jsTicket=new JsTicket();
                }
                return jsTicket;
            }
        }

        public Config Config
        {
            get
            {
                if (config == null)
                {
                    config = new Config();
                }
                return config;
            }
        }

        public Http Http
        {
            get
            {
                if (http == null)
                {
                    http = new Http();
                }
                return http;
            }
        }

        public Wx() { 
        
        }

        static Wx() {
            Config.Init();
        }
    }
}
