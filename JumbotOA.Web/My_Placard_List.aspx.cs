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
    public partial class My_Placard_List : JumbotOA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("my_placard-show");
            if (!this.Page.IsPostBack)
            {
                Selectinfo("");
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        public void Selectinfo(string str)
        {

            int count;
            BLL.PlacardBLL bll = new JumbotOA.BLL.PlacardBLL();
            this.Repeater_Placard.DataSource = bll.getpage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, out count, str);
            this.Repeater_Placard.DataBind();
            AspNetPager1.RecordCount = count;
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Selectinfo("");
            }
        }
    }
}
