using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxSDK.Instance
{
    public static class Helper
    {

        public static void BuildUrl(ref StringBuilder Url,string Name,string Value) {
            Url.Append(Name);
            Url.Append("=");
            Url.Append(Value);
            Url.Append("&");
        }



    }
}
