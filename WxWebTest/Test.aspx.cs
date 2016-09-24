using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WxSDK;
using WxSDK.Instance;
using System.Threading;
namespace WxWebTest
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Pay pay = Wx.Pay;
              
            //Wx Wx = new Wx();
            //for (int i = 0; i < 100; i++)
            //{
            //    Pay pay = Wx.Pay;
              
            //}
        }
    }
}