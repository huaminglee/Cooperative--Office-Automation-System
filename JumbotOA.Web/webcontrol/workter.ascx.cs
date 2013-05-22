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
    public partial class workter : System.Web.UI.UserControl
    {
        
        JumbotOA.BLL.UserBLL user = new JumbotOA.BLL.UserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTreeView();
            }
        }
       
        //保存
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (ListBox1.Items.Count != 0)
            { 
            
            
            }
            else
            {
                System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script language='javascript'>alert('请选择人员！');</script>");
            }
        }

        void BindTreeView()
        {
            JumbotOA.BLL.DepartmentBLL dp = new JumbotOA.BLL.DepartmentBLL();
            string fenlei = "全部";
            TreeNode yiji = new TreeNode(fenlei, "-1");
            TreeView1.Nodes.Add(yiji);
            DataTable dt = new DataTable();
            dt = dp.GetList("").Tables[0];//得到部门
            for (int i = -1; i <dt.Rows.Count; i++)
            {
                TreeNode erjinote = new TreeNode();
                if (i == -1)
                {
                    erjinote.Value = "0"; erjinote.Text = "组织管理";
                }
                else
                {
                    erjinote.Value = dt.Rows[i]["Did"].ToString();
                    erjinote.Text = dt.Rows[i]["DName"].ToString();
                }
                yiji.ChildNodes.Add(erjinote);
                NextNote(erjinote);
            }
            TreeView1.ExpandDepth = 1;
        }

        void NextNote(TreeNode nextnote)
        {
            DataTable dt = new DataTable();
            //获取部门编号节的
            string nextnoteid = nextnote.Value.ToString();
            dt = user.GetList("Did=" + nextnoteid).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode node = new TreeNode();
                node.Value = dt.Rows[i]["Uid"].ToString();
                node.Text = dt.Rows[i]["Uname"].ToString();
                nextnote.ChildNodes.Add(node);
            }
        }
      

        //添加和移除
        protected void Btninsert_Command(object sender, CommandEventArgs e)
        {
            DataTable table = new DataTable();
         
            if (txtid.Text.Trim().ToString() != "")
            {

                if (txtid.Text.Trim() == "-1")
                {
                    txtuid.Text = "";
                    table = user.GetList("").Tables[0];
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        if (table.Rows.Count == 1)
                        {
                            txtuid.Text +=table.Rows[i]["Uid"].ToString().Trim();
                        }
                        else
                        {

                            if (i == table.Rows.Count - 1)
                                txtuid.Text += table.Rows[i]["Uid"].ToString().Trim();
                            else
                                txtuid.Text += table.Rows[i]["Uid"].ToString().Trim() + ",";
                        }
                    }

                }
                else
                {
                    table = user.GetList("Did=" + txtid.Text.Trim()).Tables[0];
                    if (table.Rows.Count != 0)
                    {
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            if (table.Rows.Count == 1)
                            {
                                txtuid.Text +=","+ table.Rows[i]["Uid"].ToString().Trim();
                            }
                            else
                            {
                                txtuid.Text +=","+table.Rows[i]["Uid"].ToString().Trim();
                            }
                        }
                        txtuid.Text =JumbotOA.BLL.COMDLL.filtering(txtuid.Text.Trim().ToString());
                    }
                    //else
                    //{
                    //    uid += "," + txtid.Text.Trim();
                    //}
                }
                    switch (e.CommandName)
                    {
                        case "tianjia":
                            ListBox1.DataSource = user.GetList("Uid in(" + txtuid.Text + ")").Tables[0];
                            ListBox1.DataTextField = "Uname";
                            ListBox1.DataValueField = "Uid";
                            ListBox1.DataBind();
                            break;
                        case "yichu":
                            if (ListBox1.Items.Count != 0)
                            {
                                for (int i = ListBox1.Items.Count - 1; i >= 0; i--)
                                {
                                    if (ListBox1.Items[i].Selected)
                                    {
                                        ListBox1.Items.RemoveAt(i);
                                    }
                                }
                            }
                            break;
                    }
            }
        }

        protected void TreeView1_SelectedNodeChanged1(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            TreeNode xuanzhong = TreeView1.SelectedNode;
            string bumenid = xuanzhong.Value.ToString();
            if (xuanzhong != null)
            {
                txtid.Text = xuanzhong.Value.ToString();
            }
            else
            {
                ListBox1.Items.Clear();
            }
        }

       

        protected void Button4_Click(object sender, EventArgs e)
        {
            txtuid.Text = "";
            ListBox1.Items.Clear();
        }

       

      

     
    }
}