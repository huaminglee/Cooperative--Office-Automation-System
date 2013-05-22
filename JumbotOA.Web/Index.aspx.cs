/*
 * 
 * 
程序中文名称: 将博协同办公系统简易版
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
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace JumbotOA.Web
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                Autologin();
            }
        }

        //判断是否自动登录
        void Autologin()
        {
            if (JumbotOA.Utils.Cookie.GetValue("oa_user") != null)
            {
                if (JumbotOA.Utils.Cookie.GetValue("oa_user", "ip") == Request.UserHostAddress)
                {
                    JumbotOA.Entity.UserEntity model = new JumbotOA.Entity.UserEntity();
                    model = new JumbotOA.BLL.UserBLL().GetEntity(Convert.ToInt32(JumbotOA.Utils.Cookie.GetValue("oa_user", "id")));
                    int pid = model.Pid;
                    new BLL.UserBLL().UpdateTime(model.Uid);
                    switch (pid)
                    {
                        case 1:
                            Response.Redirect("Home1.aspx");
                            break;
                        case 2:
                            Response.Redirect("Home2.aspx");
                            break;
                        case 3:
                            Response.Redirect("Home3.aspx");
                            break;
                        case 4:
                            Response.Redirect("Home4.aspx");
                            break;
                    }
                }
            }
        }

        // 登录
        protected void ibLogin_Click(object sender, ImageClickEventArgs e)
        {
            // 记录其IP地址，下次登录时验证，IP为空则记录，IP不为空则验证
            string uname = this.tbUname.Value;
            string upwd = this.tbPwd.Value;
            string uid = new JumbotOA.BLL.UserBLL().Existslongin(uname, JumbotOA.Utils.MD5.Lower32(upwd));
            if (uid != "")
            {
                JumbotOA.Entity.UserEntity model = new JumbotOA.Entity.UserEntity();
                model = new JumbotOA.BLL.UserBLL().GetEntity(int.Parse(uid));
                if (model.Uipaddress != "")
                {
                    if (model.Uipaddress != Page.Request.UserHostAddress)
                    {
                        Response.Write("<script>alert('非法IP，请在本机登陆！');</script>");
                        Response.End();
                    }
                }
                int iExpires = 0;
                //设置Cookies
                System.Collections.Specialized.NameValueCollection myCol = new System.Collections.Specialized.NameValueCollection();
                myCol.Add("id", uid.ToString());
                myCol.Add("name", uname);
                myCol.Add("ip", Request.UserHostAddress);
                new BLL.UserBLL().UpdateTime(model.Uid);
                int pid = model.Pid;
                myCol.Add("Powerid",pid.ToString());
                JumbotOA.Utils.Cookie.SetObj("oa_user", 60 * 60 * 15 * iExpires, myCol, "", "/");

                switch (pid)
                {
                    case 1:
                        Response.Redirect("Home1.aspx");//管理员
                        break;
                    case 2:
                        Response.Redirect("Home2.aspx");//管理组织层
                        break;
                    case 3:
                        Response.Redirect("Home3.aspx");//网站编辑
                        break;
                    case 4:
                        Response.Redirect("Home4.aspx");//美工和程序员
                        break;
                }
            }
            else
            {
                this.tbUname.Value = "";
                this.tbPwd.Value = "";
                System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script language='javascript'>alert('请正确填写用户名和密码！');</script>");
            }
        }
        //FORM验证
        public static void SetLoginCookie(string roles)
        {
            //建立身份验证票对象
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, "admin", DateTime.Now, DateTime.Now.AddMinutes(10), false, roles);
            //加密序列化验证票为字符串
            string hashTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie userCookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashTicket);
            HttpContext.Current.Response.Cookies.Add(userCookie);
        }
    }
}
