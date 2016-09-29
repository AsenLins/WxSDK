using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
namespace WxSDK.Model.Mes
{
    /// <summary>
    /// 图片消息类
    /// </summary>
    public class Wx_Image:MesAll
    {
        /// <summary>
        /// 图片链接（由系统生成）
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary>
        /// 图片消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }

        #region 方法【回复图片消息】
        /// <summary>
        /// 回复图片消息
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
                new XElement("MsgType", "image"),
                new XElement("CreateTime", DateTime.Now.ToString("yyyyMMddHHmmss")
            ));
           
            Root.Add(new XElement("Image", new XElement("MediaId", Media_Id)));
            return Root.ToString();
        }
        #endregion


    }
}
