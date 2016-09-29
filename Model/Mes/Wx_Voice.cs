using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
namespace WxSDK.Model.Mes
{
    /// <summary>
    /// 语音消息
    /// </summary>
    public class Wx_Voice : MesAll
    {
        /// <summary>
        /// 语音消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 语音格式，如amr，speex等
        /// </summary>
        public string Format { get; set; }

        #region 方法【回复语音消息】
        /// <summary>
        /// 回复语音消息
        /// </summary>
        /// <param name="Media_Id">上传的媒体ID</param>
        /// <returns>Xml字符串</returns>
        public string Reply(string Media_Id)
        {
            XDocument XDoc = new XDocument();
            XDoc.Add(new XElement("xml"));
            XElement Root = XDoc.Element("xml");
            Root.Add(
                new XElement("FromUserName", ToUserName),
                new XElement("ToUserName", FromUserName),
                new XElement("MsgType", "voice"),
                new XElement("CreateTime", DateTime.Now.ToString("yyyyMMddHHmmss")
            ));


            Root.Add(new XElement("Voice", new XElement("MediaId", Media_Id)));
            return Root.ToString();
        }
        #endregion
    }
}
