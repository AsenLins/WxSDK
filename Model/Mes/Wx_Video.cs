﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
namespace WxSDK.Model.Mes
{
    /// <summary>
    /// 视频消息
    /// </summary>
    public class Wx_Video : MesAll
    {
        /// <summary>
        /// 视频消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId;
        /// <summary>
        /// 视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string ThumbMediaId;

        #region 方法【回复视频消息】
        /// <summary>
        /// 回复视频消息
        /// </summary>
        /// <param name="Title">视频消息的标题</param>
        /// <param name="Description">视频消息的描述</param>
        /// <param name="Media_Id">上传的媒体ID</param>
        /// <returns>Xml字符串</returns>
        public string Reply(string Title, string Description, string Media_Id)
        {

            XDocument XDoc = new XDocument();
            XDoc.Add(new XElement("xml"));
            XElement Root = XDoc.Element("xml");
            Root.Add(
                new XElement("FromUserName", ToUserName),
                new XElement("ToUserName", FromUserName),
                new XElement("MsgType", "video"),
                new XElement("CreateTime", DateTime.Now.ToString("yyyyMMddHHmmss")
            ));

            Root.Add(new XElement("Video", 
                new XElement("MediaId", Media_Id),
                new XElement("Title", Title),
                new XElement("Description", Description)
                ));
            return Root.ToString();
        }
        #endregion

    }
}
