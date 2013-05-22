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
    public partial class Operatelog_List : JumbotOA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("operatelog-show");
            if (!this.Page.IsPostBack)
            {
                Select_log("");
            }
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        public void Select_log(string str)
        {

            int count;
            BLL.OperatelogBLL bll = new JumbotOA.BLL.OperatelogBLL();
            this.pro_repeater.DataSource = bll.getpage(20, AspNetPager1.CurrentPageIndex, out count, str);
            this.pro_repeater.DataBind();
            AspNetPager1.RecordCount = count;
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Select_log("");
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbDel_Click(object sender, CommandEventArgs e)
        {
            Entity.OperatelogEntity model = new Entity.OperatelogEntity();
            BLL.OperatelogBLL bll = new JumbotOA.BLL.OperatelogBLL();
            model = bll.GetEntity(Convert.ToInt32(e.CommandArgument));
            bll.Delete(Convert.ToInt32(e.CommandArgument));
            Addadminlog(model.Eupdatetitle, "删除日志");
        }

        //往管理员日志添加数据
        void Addadminlog(string title, string type)
        {
            Entity.AdminlogEntity model = new Entity.AdminlogEntity();
            model.Uid = UserId;
            model.Updatetime = DateTime.Now;
            model.Updatetitle = title;
            model.Updatetype = type;
            int i = new JumbotOA.BLL.AdminlogBLL().Add(model);
            if (i > 0)
            {
                Response.Redirect("Success.aspx");
            }
        }
    }
}
