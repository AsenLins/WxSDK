using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
namespace WxSDK.Model.Mes
{
    public class Wx_PicText:MesAll
    {

        #region 方法【回复图文消息】
        /// <summary>
        /// 回复图文消息
        /// </summary>
        /// <param name="Title">音乐标题</param>
        /// <param name="Description">音乐描述</param>
        /// <param name="MusicURL">音乐链接</param>
        /// <param name="HQMusicUrl">高质量音乐链接，WIFI环境优先使用该链接播放音乐</param>
        /// <param name="ThumbMediaId">缩略图的媒体id，通过素材管理接口上传多媒体文件，得到的id</param>
        /// <returns>Xml字符串</returns>
        public string Reply(int ArticleCount,List<Wx_Articles> Lst_Art)
        {
            XDocument XDoc = new XDocument();
            XDoc.Add(new XElement("xml"));
            XElement Root = XDoc.Element("xml");
            Root.Add(
                new XElement("FromUserName", ToUserName),
                new XElement("ToUserName", FromUserName),
                new XElement("MsgType", "news"),
                new XElement("CreateTime", DateTime.Now.ToString("yyyyMMddHHmmss")
            ));

            Root.Add(new XElement("ArticleCount", ArticleCount));
            Root.Add(new XElement("Articles"));
            foreach (Wx_Articles Articles in Lst_Art)
            {
                Root.Element("Articles").Add(new XElement("item",
                    new XElement("Title",Articles.Title),
                    new XElement("Description",Articles.Title),
                    new XElement("PicUrl",Articles.PicUrl),
                    new XElement("Url",Articles.Url)
                    ));
            }
            return Root.ToString();
        }
        #endregion

    }
}
