using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WxSDK.Instance;
using WxSDK.Helper;
namespace WxSDK
{
    public static class Wx
    {

        public static Pay Pay { get { return new Pay(); } }

        public static Menu Menu { get { return null; } }

        public static User User { get { return new User(); } }

        public static Mes Mes { get { return null; } }

        public static AccessToken AccessToken { get { return null; } }

        public static JsTicket JsTicket { get { return null; } }

        public static Config Config { get { return new Config(); } }

        public static Http Http { get { return new Http(); } }

        static Wx() {
            Config.Init();
        }
    }
}
