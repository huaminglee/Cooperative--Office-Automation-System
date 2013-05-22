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

namespace JumbotOA.Web.webcontrol
{
    public partial class address : System.Web.UI.UserControl
    {
        JumbotOA.BLL.COMDLL com = new JumbotOA.BLL.COMDLL();
        JumbotOA.UI.BasicPage bp = new JumbotOA.UI.BasicPage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (bp.getvalue(4) == "1")
            {
                c.Visible = true;
                GridView1.Columns[7].Visible = true;
                cc.Visible = false;
                GridView1.PageSize = 15;
            }
            else
            {
                if (bp.getvalue(4) == "2")
                    GridView1.PageSize = 2;
                    else
                    GridView1.PageSize = 5;
                c.Visible = false;
                GridView1.Columns[7].Visible = false;
                cc.Visible = true;
            }
            if (!IsPostBack)
            {
                GridView1.DataSource = com.COM_Proc_Sel0("Pc_SeladdressbyPower");
                GridView1.DataBind();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("./address.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            string sid = GridView1.DataKeys[e.RowIndex].Value.ToString();
            if (sid.Length != 0)
            {
                com.COM_Del("OA_Address", sid, 1);
            }
            GridView1.DataSource = com.COM_Proc_Sel0("Pc_SeladdressbyPower");
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string sid=GridView1.DataKeys[e.NewEditIndex].Value.ToString();
            Response.Redirect("./address.aspx?address="+sid);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = com.COM_Proc_Sel0("Pc_SeladdressbyPower");
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }
        }
        
    }
}