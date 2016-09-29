using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxSDK.Model.Template
{
    public class Wx_Industry
    {

        
        /// <summary>
        /// 主行业主类
        /// </summary>
        public string P_first_class { get; set; }
        /// <summary>
        /// 主行业副类
        /// </summary>
        public string P_second_class { get; set; }

        /// <summary>
        /// 副营行业主类
        /// </summary>
        public string S_first_class { get; set; }
        /// <summary>
        /// 副营行业副类
        /// </summary>
        public string S_second_class { get; set; }

    }
}
