/*
 * 程序中文名称: 将博协同办公系统简易版
 * 
 * 程序英文名称: JumbotOA
 * 
 * 程序版本: 1.1.X
 * 
 * 程序作者: 将博开发团队 (定制开发请联系：jumbot114@126.com,不接受无偿的技术答疑,请见谅)
 * 
 * 
 * 
 * 
 * 
 */

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Timers;

namespace JumbotOA.Web
{
    public class Global : System.Web.HttpApplication
    {
        public static HttpContext myContext = HttpContext.Current;

        protected void Application_Start(object sender, EventArgs e)
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(TimeEvent);
            aTimer.Interval = 10000;// 设置引发时间的时间间隔　此处设置为１0秒
            aTimer.Enabled = true;
        }
        private void TimeEvent(object source, ElapsedEventArgs e)
        { 
           

        }
        private string ServerUrl()
        {
            if (myContext.Request.Url.Port == 80)
                return "http://" + myContext.Request.Url.Host;
            else
                return "http://" + myContext.Request.Url.Host + ":" + myContext.Request.Url.Port;
        }
        private string AppPath()
        {
            string _ApplicationPath = myContext.Request.ApplicationPath;
            if (_ApplicationPath != "/")
                _ApplicationPath += "/";
            return _ApplicationPath;
        }
        private string GetHttpPage(string url)
        {
            string strResult = string.Empty;
            try
            {
                System.Net.WebClient MyWebClient = new System.Net.WebClient();
                MyWebClient.Credentials = System.Net.CredentialCache.DefaultCredentials;
                MyWebClient.Encoding = System.Text.Encoding.UTF8;
                strResult = MyWebClient.DownloadString(url);
            }
            catch (Exception)
            {
                strResult = "页面获取失败";
            }
            return strResult;
        }
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}