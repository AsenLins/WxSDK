using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxSDK.Helper
{
    public class Url
    {
        private StringBuilder StrUrl;

        public Url(string Url="")
        {
            StrUrl = new StringBuilder(Url);
        }

        public void Head(string HeadStr) {
            StrUrl.Append(HeadStr);
        }

        public void Body(string Name,string Value) {
            StrUrl.Append(Name);
            StrUrl.Append("=");
            StrUrl.Append(Value);
            StrUrl.Append("&");
        }
        public void Body(string Value)
        {
            StrUrl.Append(Value);
        }

        public override string ToString() {
            string Url = StrUrl.ToString();
            if (string.IsNullOrEmpty(Url))
            {
                return "";
            }
            if (Url.IndexOf('&') > -1)
            {
                return Url.Substring(0, Url.Length - 1);
            }
            else
            {
                return Url.Substring(0, Url.Length);
            }
        }

    }
}
