using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using Newtonsoft.Json;
using WxSDK.Helper;


namespace WxSDK.Instance
{
    #region 微信消息类
    /// <summary>
    /// 微信消息类
    /// Create By Asen
    /// 2016-09-29
    /// </summary>
    #endregion
    public class Mes
    {

 
        /// <summary>
        /// 微信消息Xml对象
        /// </summary>
        public XElement XMes;
        /// <summary>
        /// 微信消息字符串
        /// </summary>
        public string MesStr;

        public void Load(string MesStr)
        {
            try
            {
                XMes = XDocument.Parse(MesStr).Element("xml");
                foreach (XElement XNode in XMes.Elements())
                {
                    XNode.SetValue(XNode.Value);
                }
                this.MesStr = MesStr;
            }
            catch (Exception ex){
                throw new Exception("Wx.Mes.Load:加载用户信息Xml出错", ex);
            }
        }
        #region 【方法】验证是否微信消息
        /// <summary>
        /// 验证是否微信消息
        /// </summary>
        /// <param name="Token">公众号设置的消息Token</param>
        /// <param name="sign">微信发过来的前排</param>
        /// <param name="nonce">微信发过来的随机字符串</param>
        /// <param name="nonce">微信发过来的时间戳</param>
        /// <returns>true/false</returns>
        public bool Verify(string Token, string sign, string nonce,string timestamp)
        {
            try
            {
                Url Url = new Url();
                Url.Body(nonce);
                Url.Body(timestamp);
                Url.Body(Token);

                string SHA1Str = Encrypt.Get_SHA1(Url.ToString());
                if (SHA1Str == sign.ToUpper())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Wx.Mes.Verify:验证微信信息出错。", ex);
            }
        }
        #endregion

        #region 【方法】获取消息类型
        /// <summary>
        /// 获取消息类型
        /// </summary>
        /// <returns>类型名称</returns>
        public string MesType() {
            return XMes.Element("MsgType").Value;
        }
        #endregion

        #region 【方法】获取事件类型
        /// <summary>
        /// 获取事件类型
        /// </summary>
        /// <returns>类型名称</returns>
        public string EventType()
        {
            try
            {
                if (XMes.Element("Event") == null)
                {
                    return "";
                }

                if (XMes.Element("Event").Value == "subscribe" && XMes.Element("EventKey") != null)
                {
                    return "subscribeBySCAN";
                }
                return XMes.Element("Event").Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Wx.Mes.EventType:获取消息类型出错。", ex);
            }
        }
        #endregion

        #region 【方法】获取信息对象
        /// <summary>
        /// 获取信息对象
        /// </summary>
        /// <typeparam name="T">Mes对象</typeparam>
        /// <returns>消息对象</returns>
        public T GetMesObj<T>() where T:Model.Mes.MesAll
        {
            return ConvertObj<T>();
        }
        #endregion

        #region 【方法】获取事件对象
        /// <summary>
        /// 获取事件对象
        /// </summary>
        /// <typeparam name="T">Event对象</typeparam>
        /// <returns>事件对象</returns>
        public T GetEventObj<T>() where T:Model.Event.EventAll
        {
            return ConvertObj<T>();      
        }
        #endregion

        #region 【方法】转换消息/事件方法对象主体
        /// <summary>
        /// 转换消息/事件方法对象主体
        /// </summary>
        /// <typeparam name="T">消息/事件类型</typeparam>
        /// <returns>消息/事件对象</returns>
        private T ConvertObj<T>() {
            try
            {
                string MesJsonStr = JsonConvert.SerializeXNode(XMes, Newtonsoft.Json.Formatting.None, true);
                return JsonConvert.DeserializeObject<T>(MesJsonStr);
            }
            catch (Exception ex)
            {
                throw new Exception("Wx.Mes.ConvertObj:转换消息对象出错。", ex);
            }
        }
        #endregion

    }
}
