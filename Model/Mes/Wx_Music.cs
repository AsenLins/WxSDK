using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
namespace WxSDK.Model.Mes
{
    public class Wx_Music:MesAll
    {

        #region 方法【回复音乐消息】
        /// <summary>
        /// 回复音乐消息
        /// </summary>
        /// <param name="Title">音乐标题</param>
        /// <param name="Description">音乐描述</param>
        /// <param name="MusicURL">音乐链接</param>
        /// <param name="HQMusicUrl">高质量音乐链接，WIFI环境优先使用该链接播放音乐</param>
        /// <param name="ThumbMediaId">缩略图的媒体id，通过素材管理接口上传多媒体文件，得到的id</param>
        /// <returns>Xml字符串</returns>
        public string Reply(string Title, string Description, string MusicURL, string HQMusicUrl,string ThumbMediaId)
        {
            XDocument XDoc = new XDocument();
            XDoc.Add(new XElement("xml"));
            XElement Root = XDoc.Element("xml");
            Root.Add(
                new XElement("FromUserName", ToUserName),
                new XElement("ToUserName", FromUserName),
                new XElement("MsgType", "music"),
                new XElement("CreateTime", DateTime.Now.ToString("yyyyMMddHHmmss")
            ));


            Root.Add(new XElement("Music",
                new XElement("Title", Title),
                new XElement("Description", Description),
                new XElement("MusicURL", MusicURL),
                new XElement("HQMusicUrl", HQMusicUrl),
                new XElement("ThumbMediaId", ThumbMediaId)
                ));
            return Root.ToString();
        }
        #endregion
    }
}
