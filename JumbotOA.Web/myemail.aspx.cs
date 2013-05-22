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
    public partial class myemail :JumbotOA.UI.BasicPage
    {
        JumbotOA.BLL.COMDLL com = new JumbotOA.BLL.COMDLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("login");
            // set(); 
            if (!IsPostBack)
            {
                show();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            JumbotOA.BLL.URLENCRYP urlen = new JumbotOA.BLL.URLENCRYP();
            DataTable dt = com.COM_Proc_Sel1("PC_getOA_email", UserId.ToString());
            if (dt.Rows.Count == 0)
            {
                dt.Rows.Clear();
                DataRow dr = dt.NewRow();
                dr["emailname"] = emailname.Text.Trim() + Tpdropdown.Text.Trim();
                dr["emailpwd"] = urlen.Encryp(emailpwd.Text.Trim());
                dr["uid"] = UserId.ToString();
                dr["inserttime"] = DateTime.Now.ToString();
                dt.Rows.Add(dr);
                com.COM_Add(dt, "OA_emailTB", "@emailname,@emailpwd,@uid,@inserttime");
                emailname.Text = emailpwd.Text = "";
                Tools.Common.JavaScript.MessageBox(this, "保存成功！");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            JumbotOA.BLL.URLENCRYP urlen = new JumbotOA.BLL.URLENCRYP();
            DataTable dt = com.COM_Proc_Sel1("PC_getOA_email", UserId.ToString());
            if (dt.Rows.Count != 0)
            {
                Button1.Visible = false;
                Button2.Visible = true;
            }else
                Tools.Common.JavaScript.MessageBox(this, "温馨提示：请先保存邮箱！");

        }
        //修改
        protected void Button2_Click(object sender, EventArgs e)
        {
            JumbotOA.BLL.URLENCRYP urlen = new JumbotOA.BLL.URLENCRYP();
            DataTable dt = com.COM_Proc_Sel1("PC_getOA_email", UserId.ToString());
            string sid=dt.Rows[0]["Id"].ToString();
            DataRow dr=dt.Rows[0];
            dr["emailpwd"] = urlen.Encryp(emailpwd.Text.Trim());
            com.COM_Up(dt, "OA_emailTB", "emailpwd=@emailpwd", sid);
            Tools.Common.JavaScript.Redirect(Page,"修改成功！", "myemail.aspx");
        }

        void show()
        {
            JumbotOA.BLL.URLENCRYP urlen = new JumbotOA.BLL.URLENCRYP();
            DataTable dt = com.COM_Proc_Sel1("PC_getOA_email", UserId.ToString());
            if (dt.Rows.Count != 0)
            {
                Button1.Visible = false;
                string email = dt.Rows[0]["emailname"].ToString();
                string[] str = email.Split("@".ToCharArray());
                emailname.Text = str[0].ToString();
                Tpdropdown.Text = str[1].ToString();
                emailname.Enabled = false; Tpdropdown.Enabled = false;
            }
            else
            {
                Button1.Visible = true;
                emailname.Enabled = true;
                Tpdropdown.Enabled = true;
            }
        }
          
    }
}
