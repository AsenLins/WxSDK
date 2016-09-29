using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxSDK.Model.Exception
{
    public class WxError
    {
        /// <summary>
        /// 微信接口错误码
        /// </summary>
        public string errcode { get; set; }
        /// <summary>
        /// 微信接口错误信息
        /// </summary>
        public string errmsg{get;set;}
    }
}
