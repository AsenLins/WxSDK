using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WxSDK.Helper;
using WxSDK.Model.Template;
using Newtonsoft.Json;
namespace WxSDK.Instance
{
    
    public class Template
    {

        /// <summary>
        /// Http发送类
        /// </summary>
        Http _Http = new Http();
        /// <summary>
        /// AccessToken类
        /// </summary>
        AccessToken _AccessToken = new AccessToken();

        #region 【方法】设置行业属性类
        /// <summary>
        /// 设置行业属性类
        /// </summary>
        /// <param name="Industry_Id1">主行业ID</param>
        /// <param name="Industry_id2">副行业ID</param>
        /// <returns>ok代表设置成功</returns>
        public string SetIndustry(string Industry_Id1, string Industry_id2)
        {
            try
            {
                Url Url = new Url("https://api.weixin.qq.com/cgi-bin/template/api_set_industry");
                Url.Head("?");
                Url.Body("access_token", _AccessToken.Get);
                dynamic Industry = new
                {
                    industry_id1 = Industry_Id1,
                    industry_id2 = Industry_id2
                };
                string PostParam = JsonConvert.SerializeObject(Industry);
                return _Http.Post(Url.ToString(), "POST", PostParam);
            }
            catch (WxException WxEx)
            {
                throw WxEx;
            }
            catch (Exception ex)
            {
                throw new Exception("Wx.Template.SetIndustry:设置行页模板出错", ex);
            }
        }
        #endregion

        #region 【方法】获取行业属性
        /// <summary>
        /// 获取行业属性
        /// </summary>
        /// <returns>行业对象</returns>
        public Wx_Industry GetIndustry()
        { 
            try{
                Url Url = new Url("https://api.weixin.qq.com/cgi-bin/template/get_industry");
                Url.Head("?");
                Url.Body("access_token", _AccessToken.Get);
                dynamic DyObj = JsonConvert.DeserializeObject<dynamic>(_Http.Post(Url.ToString(), "POST"));
                Wx_Industry Industry=new Wx_Industry();
                Industry.P_first_class=DyObj.primary_industry.first_class;
                Industry.P_second_class=DyObj.primary_industry.second_class;
                Industry.S_first_class=DyObj.secondary_industry.first_class;
                Industry.S_second_class=DyObj.secondary_industry.second_class;
                return Industry;
            }
            catch(WxException WxEx){
                 throw WxEx;
            }
            catch(Exception ex){
                 throw new Exception("Wx.Template.GetIndustry:获取模板行业出错", ex);
            }
        }
        #endregion

        #region 【方法】获取模板ID
        /// <summary>
        /// 获取模板ID
        /// </summary>
        public void GetTemplateId() {
            try
            {
                Url Url = new Url("https://api.weixin.qq.com/cgi-bin/template/api_add_template");
                Url.Head("?");
                Url.Body("access_token", _AccessToken.Get);
                string TestStr=_Http.Post(Url.ToString(),"POST");

            }
            catch (WxException WxEx)
            {
                throw WxEx;
            }
            catch(Exception ex){
                throw new Exception("Wx.Template.GetTemplateId:获取模板ID出错", ex);
            }

        }
        #endregion

        #region 【方法】获取模板列表
        /// <summary>
        /// 获取模板列表
        /// </summary>
        public string GetTemplateList() {
            try
            {
                Url Url = new Url("https://api.weixin.qq.com/cgi-bin/template/get_all_private_template");
                Url.Head("?");
                Url.Body("access_token", _AccessToken.Get);
                return _Http.Post(Url.ToString(),"POST");

            }
            catch (WxException WxEx)
            {
                throw WxEx;
            }
            catch(Exception ex){
                throw new Exception("Wx.Template.GetTemplateList:获取模板列表出错", ex);
            }

        }
        #endregion

        #region 【方法】删除指定模板
        /// <summary>
        /// 删除指定模板列表
        /// </summary>
        public string DeleteTemplate(string TemplateId)
        {
            try
            {
                Url Url = new Url("https://api.weixin.qq.com/cgi-bin/template/del_private_template");
                Url.Head("?");
                Url.Body("access_token", _AccessToken.Get);
                dynamic DyObj = new
                {
                    template_id = TemplateId
                };
                string PostParam = JsonConvert.SerializeObject(DyObj);
                _Http.Post(Url.ToString(), "POST", PostParam);
                return "ok";
            }
            catch (WxException WxEx)
            {
                throw WxEx;
            }
            catch (Exception ex)
            {
                throw new Exception("Wx.Template.DeleteTemplate:删除指定模板出错", ex);
            }

        }
        #endregion


        #region 发送模板消息
        /// <summary>
        /// 发送模板消息
        /// </summary>
        /// <param name="OpenId">用户的OpenId</param>
        /// <param name="Template">模板消息</param>
        /// <returns>ok</returns>
        public string Send(string OpenId,string Template_id,string SkipUrl,dynamic DataObj)
        {
            try
            {
             


              //<!--拼团成功XML模板-->
              //<!--标题-->
              //"first":{"value":"_1.DATA","color":"#337b8d" },
              //<!--商品名称-->
              //"keyword1":{"value":"_2.DATA","color":"#337b8d"},
              //<!--团长-->
              //"keyword2":{"value":"_3.DATA","color":"#337b8d"},
              //<!--成团人数-->
              //"keyword3":{"value":"_4.DATA","color":"#155d10"},
              //<!--详细信息-->
              //"remark":{"value":"_5.DATA","color":"#337b8d"}
                dynamic DyObj = new
                {
                    touser = OpenId,
                    template_id = Template_id,
                    url = SkipUrl,
                    data = DataObj
                };
                Url Url = new Url("https://api.weixin.qq.com/cgi-bin/message/template/send");
                Url.Head("?");
                string PostParam = JsonConvert.SerializeObject(DyObj);
                Url.Body("access_token", _AccessToken.Get);
                _Http.Post(Url.ToString(), "POST", PostParam);
                return "ok";
            }
            catch (WxException WxEx)
            {
                throw WxEx;
            }
            catch(Exception ex){
                throw new Exception("Wx.Template.Send:发送模板消息出错", ex);
            }

        }
        #endregion




    }
}
