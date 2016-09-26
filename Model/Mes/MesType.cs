using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxSDK.Model.Mes
{
   public static class MesType
    {

        public  const string text = "text";
        public  const string image = "image";
        public  const string voice = "voice";
        public  const string video = "video";
        public  const string shortvideo = "shortvideo";
        public  const string location = "location";
        public  const string link = "link";

       public static class Event
       {

           public  const string subscribe="subscribe";
           public  const string subscribeBySCAN = "subscribeBySCAN";
           public  const string SCAN = "SCAN";
           public  const string LOCATION = "LOCATION";
           public  const string CLICK = "CLICK";
           public  const string VIEW = "VIEW";

       }
       //public enum Event
       //{
       //    text=1,
       //    image=2,
       //    voice=3,
       //    video=4,
       //    shortvideo=5,
       //    location=6,
       //    link=7
       //}






    }
}
