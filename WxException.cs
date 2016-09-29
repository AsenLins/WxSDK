using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxSDK
{

    #region 微信异常类型
    /// <summary>
    /// 微信异常类型
    /// Create By Asen
    /// 2016-09-28
    /// </summary>
    #endregion
    public class WxException:Exception
    {
        private string message{get;set; }
        /// <summary>
        /// 错误代码
        /// </summary>
        public string errcode { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string errmsg { get; set; }
        /// <summary>
        /// 原错误信息
        /// </summary>
        public string errorigin { get; set; }

        internal void SetMes(string Mes) {
            message = Mes;
        }

        public override string Message
        {
            get
            {
                return message;
            }
        }

        public WxException(string Message) {
            message = Message;
        }
    }
}
