using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WxSDK;
using WxSDK.Model.Menu;
using WxSDK.Helper;
using Newtonsoft.Json;
namespace WxSDK.Instance
{
    #region 微信菜单类
    /// <summary>
    /// 微信菜单类
    /// Create by Asen
    /// 2016-09-29
    /// </summary>
    #endregion
    public class Menu
    {

        AccessToken _AccessToken = new AccessToken();

        Http _Http = new Http();


        #region 【方法】创建菜单
        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="Wx_Menu">菜单对象</param>
        /// <returns>ok</returns>
        public string Create(Wx_Menu Wx_Menu)
        {

            //Wx_Menu Wx_Menus = new Wx_Menu();
            //Wx_Menus.menu.button = new button[3];

            //button sonbutton = new button { name = "子菜单1", key = "menu2", type = "click" };

            //button Button1 = new button { name = "菜单1", key = "menu1", type = "click" };
            //button Button2 = new button { name = "菜单2", key = "menu2", type = "click" };
            //button Button3 = new button { name = "菜单3", key = "menu2", type = "view", url = "http://baidu.com" };
            //Button3.sub_button = new button[1];
            //Button3.sub_button[0] = sonbutton;


            //Wx_Menus.menu.button[0] = Button1;
            //Wx_Menus.menu.button[1] = Button2;
            //Wx_Menus.menu.button[2] = Button3;
            try
            {
                Url Url = new Url("https://api.weixin.qq.com/cgi-bin/menu/create");
                Url.Head("?");
                Url.Body("access_token", _AccessToken.Get);
                string PostParam = JsonConvert.SerializeObject(Wx_Menu.menu);
                return _Http.Post(Url.ToString(), "POST", PostParam);
            }
            catch(WxException WxEx){
                throw WxEx;
            }
            catch(Exception ex){
                   throw new Exception("Wx.Menu.Create:创建指定菜单出错。", ex);
            }
        }
        #endregion 

        #region 【方法】获取菜单对象
        /// <summary>
        /// 获取菜单对象
        /// </summary>
        /// <returns></returns>
        public Wx_Menu Get()
        {
            try
            {
                Url Url = new Url("https://api.weixin.qq.com/cgi-bin/menu/get");
                Url.Head("?");
                Url.Body("access_token", _AccessToken.Get);
                Wx_Menu Menu=JsonConvert.DeserializeObject<Wx_Menu>(_Http.Post(Url.ToString(), "POST"));
                return Menu;
            }
            catch (WxException WxEx)
            {
                throw WxEx;
            }

            catch(Exception ex){
                throw new Exception("Wx.Menu.Get:获取指定菜单出错。", ex);
            
            }
        }
        #endregion
    }
}
