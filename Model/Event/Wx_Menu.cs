using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxSDK.Model.Event
{
    /// <summary>
    /// 自定义菜单事件
    /// </summary>
    public class Wx_Menu:EventAll
    {
        /// <summary>
        /// 事件KEY值，与自定义菜单接口中KEY值对应
        /// </summary>
        public string EventKey { get; set; }
    }
}
