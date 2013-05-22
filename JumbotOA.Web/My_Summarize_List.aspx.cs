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

namespace JumbotOA.Web
{
    public partial class My_Summarize_List : JumbotOA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("");
            if (!this.Page.IsPostBack)
            {
                Selectplan(" and uid = " + UserId + " ");
            }
        }

        /// <summary>
        /// 工作总结
        /// </summary>
        public void Selectplan(string str)
        {

            int count;
            BLL.SummarizeBLL bll = new JumbotOA.BLL.SummarizeBLL();
            this.Plan_repeater.DataSource = bll.getpage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, out count, str);
            this.Plan_repeater.DataBind();
            AspNetPager1.RecordCount = count;
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Selectplan(" and uid = " + UserId + " ");
            }
        }
        public string ShowEditLink(string id, string locked)
        {
            if (locked == "0")
                return "<a href=\"My_Summarize_Edit.aspx?id=" + id + "\">编辑</a>";
            else
                return "<span style=\"color:#eee\">编辑</a>";
        }
    }
}
