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
    public partial class Password_Edit : JumbotOA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("password-edit");
            if (!this.Page.IsPostBack)
            {
                Bind();
            }
        }

        //绑定
        void Bind()
        {
            Entity.UserEntity model = new Entity.UserEntity();
            model = new JumbotOA.BLL.UserBLL().GetEntity(UserId);
            this.txtUname.Text = model.Uname;
            ViewState["pid"] = model.Pid.ToString();
            this.txtUname.ReadOnly = true;
        }

        //个人密码修改
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.UserEntity model = new Entity.UserEntity();
            model = new JumbotOA.BLL.UserBLL().GetEntity(UserId);
            model.Upwd = JumbotOA.Utils.MD5.Lower32(this.txtAgainpwd.Text.Trim());
            new JumbotOA.BLL.UserBLL().Update(model);
            FinalMessage("操作成功", "Password_Edit.aspx", 0);
        }

    }
}
