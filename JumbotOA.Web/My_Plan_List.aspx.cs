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
    public partial class My_Plan_List : JumbotOA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("");
            if (!this.Page.IsPostBack)
            {
                Selectinfo(" and uid = " + UserId + "");
            }
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        public void Selectinfo(string str)
        {

            int count;
            JumbotOA.BLL.PlanBLL bll = new JumbotOA.BLL.PlanBLL();
            this.Plan_repeater.DataSource = bll.getpage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, out count, str);
            this.Plan_repeater.DataBind();
            AspNetPager1.RecordCount = count;

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbDel_Click(object sender, CommandEventArgs e)
        {
            int pwid = Convert.ToInt32(e.CommandArgument);
            JumbotOA.Entity.PlanEntity model = new JumbotOA.Entity.PlanEntity();
            model = new JumbotOA.BLL.PlanBLL().GetEntity(pwid);
            string islock = model.Locked;
            if (islock == "未锁定")
            {
                new JumbotOA.BLL.PlanBLL().Delete(Convert.ToInt32(e.CommandArgument));
                string dirpath = Server.MapPath("~/Worddoc");
                if (Directory.Exists(dirpath) == false)
                {
                    Directory.CreateDirectory(dirpath);
                }
                string FileName = Path.GetFileName(model.Pwpath);
                string lastpath = dirpath + @"\" + FileName;
                File.Delete(lastpath);
                Selectinfo(" and uid = " + UserId + "");
            }
            else
            {
                System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script language='javascript'>alert('该文件已锁定！');</script>");
            }

        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Selectinfo(" and uid = " + UserId + "");
            }
        }
        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbDown_Click(object sender, CommandEventArgs e)
        {
            string path = "";
            JumbotOA.Entity.PlanEntity model = new JumbotOA.Entity.PlanEntity();
            model = new JumbotOA.BLL.PlanBLL().GetEntity(Convert.ToInt32(e.CommandArgument));
            path = model.Pwpath;
            DownloadFile(path);
        }
    }
}
