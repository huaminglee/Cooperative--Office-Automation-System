﻿/*
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
using System.Text;
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
    public partial class User_Setting : JumbotOA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("user-edit");
            if (!this.Page.IsPostBack)
            {
                Bind();
            }
        }
        //数据绑定
        void Bind()
        {
            int uid = Str2Int(q("id"), 0);
            department();
            roless();
            
            JumbotOA.Entity.UserEntity model = new JumbotOA.Entity.UserEntity();
            model = new JumbotOA.BLL.UserBLL().GetEntity(uid);
            this.txtUname.Text = model.Uname;
            this.txtUname.ReadOnly = true;
           // this.txtPosition.Text = model.Position; //职位
            this.txtIpaddress.Text = model.Uipaddress;
            string user_setting = ""; 
            string[,] menu = null;
            if (pidtxt.Text != "")
            {
                Entity.PowerEntity powerEntity = new BLL.PowerBLL().GetEntity(Convert.ToInt32(pidtxt.Text.Trim()));
                user_setting = powerEntity.Setting;
                int pid = Convert.ToInt32(pidtxt.Text);
             
                if (depid.Text != "")
                    DropDownList1.SelectedValue = depid.Text.ToString();
                else
                { DropDownList1.SelectedValue = model.Did.ToString(); }
                DropDownList2.SelectedValue = pid.ToString();
                if(pid==1)
                 menu = powerMenu1();
                if (pid == 2)
                    menu = powerMenu2();
                else if (pid == 3)
                    menu = powerMenu3();
                else if (pid == 4)
                    menu = powerMenu4();
            }
            else
            {
                DropDownList1.SelectedValue = model.Did.ToString();
              
                DropDownList2.SelectedValue = model.Pid.ToString();
                user_setting = model.Setting;
                if (model.Pid == 1)
                    menu = powerMenu1();
                if (model.Pid == 2)
                    menu = powerMenu2();
                else if (model.Pid == 3)
                    menu = powerMenu3();
                else if (model.Pid == 4)
                    menu = powerMenu4();
            }
           
            StringBuilder sb = new StringBuilder();
            sb.Append("<table cellspacing=\"0\" width=\"100%\" cellpadding=\"0\" align=\"center\">");
            for (int i = 0; i < menu.GetLength(0); i++)
            {
                sb.Append("<tr><td width=\"260\" align=\"right\"><strong>" + menu[i, 0] + "</strong></td>");
                sb.Append("<td width=\"*\">");
                for (int j = 1; j < menu.GetLength(1); j++)
                {
                    if (menu[i, j] == null)
                        break;
                    string[] _split = menu[i, j].Split('|');
                    sb.Append("<span style='float:left;height:30px;margin-left:10px;padding-top:5px;' scope='col'><input id=\"user_setting_" + i + "_" + j + "\" type=checkbox class='checkbox' name=\"user_setting\" value=\"");
                    string tPower = _split[1];
                    sb.Append(tPower + "\"");
                    if (_split.Length > 2 && _split[2] == "1")
                        sb.Append(" onclick='if(!this.checked){this.checked=true;}else{this.checked=false;}'");
                    if (user_setting.Contains("," + tPower + ","))
                        sb.Append(" checked");
                    sb.Append("><label for=\"user_setting_" + i + "_" + j + "\">" + _split[0] + "</label>");
                    sb.Append("</span>\r\n");
                }
                sb.Append("</td></tr>");
            }
            sb.Append("</td></tr>");
            sb.Append("</table>");
            this.ltMasterSetting.Text = sb.ToString();
        }

        //更新
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.UserEntity model = new Entity.UserEntity();
            model = new JumbotOA.BLL.UserBLL().GetEntity(Str2Int(q("id"), 0));
           // model.Position = this.txtPosition.Text;
            model.Setting = "," + f("user_setting") + ",";
            model.Pid = Convert.ToInt32(DropDownList2.SelectedValue.ToString());
            model.Did = Convert.ToInt32(DropDownList1.SelectedValue.ToString());
            model.Uipaddress = this.txtIpaddress.Text;
            new JumbotOA.BLL.UserBLL().Update(model);
            Addadminlog("修改用户权限");
        }

        //往管理员日志插入数据
        void Addadminlog(string type)
        {
            Entity.AdminlogEntity model = new Entity.AdminlogEntity();
            model.Uid = UserId;
            model.Updatetime = DateTime.Now;
            model.Updatetitle = this.txtUname.Text;
            model.Updatetype = type;
            int i = new JumbotOA.BLL.AdminlogBLL().Add(model);
            if (i > 0)
            {
                Response.Redirect("User_List.aspx");
            }
        }

        void department()
        {
            JumbotOA.BLL.DepartmentBLL dps = new JumbotOA.BLL.DepartmentBLL();
            DropDownList1.DataSource = dps.GetList("").Tables[0];
            DropDownList1.DataTextField = "DName";
            DropDownList1.DataValueField = "Did";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("管理部", "0"));
           
        }
        void roless()
        {
            JumbotOA.BLL.PowerBLL dp = new JumbotOA.BLL.PowerBLL();
            DropDownList2.DataSource = dp.GetList("").Tables[0];
            DropDownList2.DataTextField = "PName";
            DropDownList2.DataValueField = "Pid";
            DropDownList2.DataBind();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            pidtxt.Text = DropDownList2.SelectedValue.ToString();
            Bind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            depid.Text = DropDownList1.SelectedValue.ToString();
        }
      



    }
}
