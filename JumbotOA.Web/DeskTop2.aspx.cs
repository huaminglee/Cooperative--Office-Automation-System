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
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using jmail;
namespace JumbotOA.Web
{
    public partial class DeskTop2 : JumbotOA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("login");
            if (UserPowerId != 2)
                Response.Redirect("DeskTop" + UserPowerId + ".aspx");
            if (!this.Page.IsPostBack)
            { 
                BindPlacard();
                UserList();
            }
        }

        ////学习资料绑定
        //void BindLearning()
        //{
        //    this.Repeater_Learning.DataSource = new JumbotOA.BLL.LearningBLL().GetList(5, "", "Sid Desc");
        //    this.Repeater_Learning.DataBind();
        //}

        //通知绑定
        void BindPlacard()
        {
            this.Repeater_Placard.DataSource = new JumbotOA.BLL.PlacardBLL().GetList(7, "", "Pid Desc");
            this.Repeater_Placard.DataBind();
        }
         void UserList()
        {
            string sql = "select *,datediff(s,UpdateTime,getdate()) as seconds,(select DName from [OA_Department] where Did=[OA_User].Did) as departmentname,IsNull((select top 1 tasktitle from [OA_Task] where Uid=[OA_User].Uid and Workprogress=2 order by worktime),'无安排') as TaskTitle,(select count(*) from [OA_Message] where FromUid=[OA_User].Uid and ToUid=" + UserId + " and IsRead=0) as newmessage FROM [OA_User] where Pid>2 and Uid<>" + UserId;
            if (UserPowerId > 2)
                sql += " and Did=" + UserDepartmentId;
            DataTable dt = (new JumbotOA.BLL.UserBLL().Getsta(sql)).Tables[0];
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
         public string Format(object seconds)
         {
             if (Convert.ToInt32(seconds.ToString())< 10)
             return "<img src='images/ico_online.gif' alt='在线' border='0' />";
         else
             return "<img src='images/ico_offline.gif' alt='离线' border='0' />";	
         
         }
      public string FormatMessage(object t,object uid)
 {
     if (Convert.ToInt32(t.ToString()) > 0)
         return "<a href='Message_List.aspx?uid=" + uid.ToString() + "'><img src='images/ico_message1.gif' alt='有" + t.ToString() + "条新短信' border='0' /></a>";
     else
         return "<img src='images/ico_message0.gif'  alt='暂无新短信' border='0' />";
 }


    }
}
