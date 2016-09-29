using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WxSDK.Model.Mes
{
    /// <summary>
    /// 文本消息类
    /// </summary>
    public class Wx_Text:MesAll
    {
        /// <summary>
        /// 文本消息内容
        /// </summary>
        public string Content{get;set;}

        public string Reply(string text)
        {
            XDocument XDoc = new XDocument();
            XDoc.Add(new XElement("xml"));
            XElement Root=XDoc.Element("xml");
            Root.Add(
                new XElement("FromUserName", ToUserName),
                new XElement("ToUserName", FromUserName),
                new XElement("MsgType", "text"),
                new XElement("CreateTime", DateTime.Now.ToString("yyyyMMddHHmmss"))
            );

            Root.Add(new XElement("Content", text));
            return Root.ToString();
        }

    }
}
