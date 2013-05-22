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
    public partial class role : JumbotOA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("login");
            if (!IsPostBack)
            {
                showlist();
            }
        }

       
        void showlist()
        {
            int uid = Str2Int(q("roleid"), 0); //1==部门
            if (uid == 1)
            {
                GridView1.DataKeyNames = new string[] { "Did" };//主键
                GridView1.DataSource = new JumbotOA.BLL.DepartmentBLL().GetList("").Tables[0];
                GridView1.DataBind();
            }
            else
            {
                gvlist.DataKeyNames = new string[] { "Pid" };//主键
                gvlist.DataSource = new JumbotOA.BLL.PowerBLL().GetList("").Tables[0];
                gvlist.DataBind();
            }
        
        }
        public string sty(int i)
        {
            if (i == 1)
            {
                int uid = Str2Int(q("roleid"), 0); //1==部门
                if (uid == 1)
                    return "active";
                else
                    return "";
            }
            else
            {
                int uid = Str2Int(q("roleid"), 0); //1==部门
                if (uid == 0)
                    return "active";
                else
                    return "";
            
            }
        
        }
      public  string names(object obj)
        {
               return obj.ToString();
        }
      public string ns()
      { 
       int uid = Str2Int(q("roleid"), 0); //1==部门
       if (uid == 1)
           return "部门名称";
       else
           return "角色名称";
      }
        protected void gvlist_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            new JumbotOA.BLL.PowerBLL().Delete(Convert.ToInt32(gvlist.DataKeys[e.RowIndex].Value.ToString()));
            showlist();
        }

        protected void gvlist_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Entity.PowerEntity model = new JumbotOA.Entity.PowerEntity();
            model.Pid = Convert.ToInt32(gvlist.DataKeys[e.RowIndex].Value.ToString());
            model.PName = ((TextBox)(gvlist.Rows[e.RowIndex].Cells[2].FindControl("TextBox2"))).Text.Trim();
            new JumbotOA.BLL.PowerBLL().Update(model);
           
            gvlist.EditIndex = -1;
            showlist();

        }
        protected void gvlist_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvlist.EditIndex = e.NewEditIndex;
            showlist();
        }
        protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //鼠标经过时，行背景色变 
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#E6F5FA'");
                //鼠标移出时，行背景色变 
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            
            } 
        }

        protected void gvlist_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvlist.EditIndex = -1;
            showlist();
        }

      

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //鼠标经过时，行背景色变 
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#E6F5FA'");
                //鼠标移出时，行背景色变 
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
             
            } 
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            showlist();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            new JumbotOA.BLL.DepartmentBLL().Delete(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
            showlist();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Entity.DepartmentEntity model = new JumbotOA.Entity.DepartmentEntity();
            model.Did = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            model.DName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].FindControl("TextBox2"))).Text.Trim();
            new JumbotOA.BLL.DepartmentBLL().Update(model);
            GridView1.EditIndex = -1;
            showlist();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            showlist();
        }

      

    }
}
