using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxSDK.Model.Mes
{
    public class Wx_Text:All
    {
        public string ToUserName{get;set;}
        public string FromUserName{get;set;}
        public string CreateTime{get;set;}
        public string MsgType{get;set;}
        public string Content{get;set;}
        public string MsgId{get;set;}

    }
}
