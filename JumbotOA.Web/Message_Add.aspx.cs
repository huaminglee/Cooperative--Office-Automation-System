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
    public partial class Message_Add : JumbotOA.UI.BasicPage
    {
        JumbotOA.BLL.UserBLL user = new JumbotOA.BLL.UserBLL();
        protected string wherestr2 = "";
        public int _uid = 0;
        public int mes = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("message-add");
            mes = Str2Int(q("mesid"));
            _uid = Str2Int(q("toid"));

            //if (UserPowerId == 2)
            //{//表示主管
            //    wherestr2 = " pid>1 and uid<>" + UserId;
            //}
            //else if (UserPowerId == 3)
            //{//表示部门主管
            //    wherestr2 = " uid<>" + UserId + " and did=" + UserDepartmentId;
            //}
            //else if (UserPowerId == 4)//表示员工
            //    wherestr2 = " uid<>" + UserId + " and did=" + UserDepartmentId;
            if (!this.Page.IsPostBack)
            {
                show();
                showdp();
            }
        }

       

      
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            JumbotOA.Entity.UserEntity userEntity = new JumbotOA.Entity.UserEntity();
           
                //可以添加
                JumbotOA.Entity.MessageEntity message = new JumbotOA.Entity.MessageEntity();
                message.Content = this.FCKeditor1.Value;
                message.FromUid = UserId;
                message.Addtime = System.DateTime.Now;
                message.Mtitle = this.txtTitle.Text;
                if (mes != 0)
                {
                    message.ToUid = _uid; 
                }
                else
                {
                 if (DropDownList1.SelectedValue =="-1")
                   {
                     System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                     page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script language='javascript'>alert('请选择收信人！');</script>");
                     return; 
                   }else
                     message.ToUid = Convert.ToInt32(DropDownList2.SelectedValue.ToString());
                }
            int i = new JumbotOA.BLL.MessageBLL().Add(message);
                if (i > 0)
                {
                    JumbotOA.BLL.OA_SysMessageIn.ADDsysMessage(0, "," + message.ToUid + ",", "新短信", JumbotOA.Utils.Strings.Left(JumbotOA.Utils.Strings.delhtml(txtTitle.Text.Trim()), 53), "Message_Show.aspx?id=" + i.ToString());
                    FinalMessage("短信发送成功", "Message_MySend.aspx", 0);
                }
                else
                {
                    FinalMessage("短信发送失败", "Message_MySend.aspx", 0);
                }
        }

        void drop()
        {
            JumbotOA.BLL.DepartmentBLL dp = new JumbotOA.BLL.DepartmentBLL();
                DropDownList1.DataSource = dp.GetList("").Tables[0];
                DropDownList1.DataTextField = "DName";
                DropDownList1.DataValueField = "Did";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(1, new ListItem("组织管理部", "0"));
                DropDownList1.Items.Insert(0, new ListItem("请选择部门", "-1"));
        }
        void show()
        {
            JumbotOA.BLL.COMDLL com=new JumbotOA.BLL.COMDLL ();
            DataTable table = com.COM_Select("OA_Message", "Mid", "", mes.ToString(), "", 4);
            if (table.Rows.Count != 0)
            {
                ren.Visible = false;
            }
            else
            {
                ren.Visible = true;
                drop();
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue != "-1")
            {
                this.DropDownList2.DataSource = new JumbotOA.BLL.UserBLL().GetList("Did=" + DropDownList1.SelectedValue.ToString());
                this.DropDownList2.DataTextField = "Uname";
                this.DropDownList2.DataValueField = "Uid";
                this.DropDownList2.DataBind();
            }
        }
        void showdp()
        {
            JumbotOA.BLL.COMDLL com = new JumbotOA.BLL.COMDLL();
            int uid = Convert.ToInt32(com.getsid("fid"));
            if (uid != -1)
            {
                int dpid = new JumbotOA.BLL.UserBLL().GetEntity(uid).Did;
                DropDownList1.SelectedValue = dpid.ToString();
                DropDownList1.Enabled = false;
                this.DropDownList2.DataSource = new JumbotOA.BLL.UserBLL().GetList("Did=" + DropDownList1.SelectedValue.ToString());
                this.DropDownList2.DataTextField = "Uname";
                this.DropDownList2.DataValueField = "Uid";
                this.DropDownList2.DataBind();
                DropDownList2.SelectedValue = uid.ToString();
                DropDownList2.Enabled = false;

            }
            else
            {
                DropDownList1.Enabled = true;
                DropDownList2.Enabled = true;
            }
        
        }

    }
}
