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
using System.IO;

namespace JumbotOA.Web
{
    public partial class My_Plan_Add : JumbotOA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("");
            if (!this.Page.IsPostBack)
            {
                Bind();
                this.ddlManager.SelectedIndex = 0;
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

        //插入信息
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string dirpath = Server.MapPath("~/Worddoc");

            if (Directory.Exists(dirpath) == false)
            {
                Directory.CreateDirectory(dirpath);
            }
            Random ro = new Random();
            int name = 1;
            string FileName = "";
            string FileExtention = "";
            FileName = Path.GetFileName(this.fuFile.FileName);
            string stro = ro.Next(100, 100000000).ToString() + name.ToString();//产生一个随机数用于新命名的文件
            string NewName = DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + stro;
            if (FileName.Length > 0)//有文件才执行上传操作再保存到数据库
            {
                FileExtention = Path.GetExtension(this.fuFile.FileName);
                string ppath = dirpath + @"\" + NewName + FileExtention;
                this.fuFile.SaveAs(ppath);
                JumbotOA.Entity.PlanEntity model = new JumbotOA.Entity.PlanEntity();
                model.Uid = UserId;
                model.Pwtitle = this.txtTitle.Text;
                model.Pwdate = DateTime.Now;
                model.Manager = this.ddlManager.SelectedValue;
                model.Pwpath = "Worddoc/" + NewName + FileExtention;
                model.Locked = "未锁定";
                int i = new JumbotOA.BLL.PlanBLL().Add(model);
                if (i > 0)
                {
                    FinalMessage("操作成功", "My_Plan_List.aspx", 0);
                }
                else
                {
                    System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                    page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script language='javascript'>alert('对不起，操作失败！');</script>");
                }
            }
        }
    }
}
