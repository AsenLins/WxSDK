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
            XMes = XDocument.Parse(MesStr).Element("xml");
            foreach (XElement XNode in XMes.Elements())
            {
                XNode.SetValue(XNode.Value);
            }
            this.MesStr = MesStr;
        }

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

            Url Url = new Url();
            Url.Body(nonce);
            Url.Body(timestamp);
            Url.Body(Token); 
            
            string SHA1Str=Encrypt.Get_SHA1(Url.ToString());
            if (SHA1Str == sign.ToUpper())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string MesType() {
            if (XMes.Element("Event") == null)
            {
                return XMes.Element("MsgType").Value;
            }
            else
            {
                if (XMes.Element("Event").Value == "subscribe" && XMes.Element("EventKey") != null)
                {
                    return "subscribeBySCAN";
                }
                return XMes.Element("Event").Value;
            }
        }

        public T GetMesObj<T>(string MesType) where T:Model.Mes.All
        {
            string MesJsonStr = JsonConvert.SerializeXNode(XMes, Newtonsoft.Json.Formatting.None, true);
            return JsonConvert.DeserializeObject<T>(MesJsonStr);
        }
    }
}
