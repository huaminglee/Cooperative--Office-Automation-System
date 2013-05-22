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
using Layers.Common;

namespace JumbotOA.Web
{
    public partial class My_Worklog_Add : JumbotOA.UI.BasicPage
    {
        public string date0, date1, date2 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("");
            if (!this.Page.IsPostBack)
            {
                Bind();
                this.ddlManager.SelectedIndex = 0;
                date0 = System.DateTime.Today.ToString("yyyy-MM-dd 06:00:00");
                date1 = System.DateTime.Now.AddMinutes(-5).ToString("yyyy-MM-dd HH:mm:ss");
                date2 = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                this.txtBegintime.Text = date1;
                this.txtEndtime.Text = date2;
            }
        }

        //绑定领导
        void Bind()
        {
            this.ddlManager.DataSource = new JumbotOA.BLL.UserBLL().GetList("(did=" + UserDepartmentId + " and pid=3) OR pid=2");
            this.ddlManager.DataTextField = "Uname";
            this.ddlManager.DataValueField = "Uid";
            this.ddlManager.DataBind();
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.WorklogEntity worklog = new Entity.WorklogEntity();
            worklog.Uid = UserId;
            worklog.Begintime = Convert.ToDateTime(this.txtBegintime.Text);
            worklog.Endtime = Convert.ToDateTime(this.txtEndtime.Text);
            worklog.Title = this.txtTitle.Text;
            worklog.Content = this.txtContent.Text;
            worklog.Problem = this.txtProblem.Text;
            worklog.Manager = this.ddlManager.SelectedItem.Text;
            worklog.Remark = this.FCKeditor1.Value;
            int i = new JumbotOA.BLL.WorklogBLL().Add(worklog);
            if (i > 0)
            {
                FinalMessage("操作成功", "My_Worklog_List.aspx", 0);
            }
            else
            {
                FinalMessage("操作失败", "My_Worklog_List.aspx", 0);
            }
        }
    }
}
