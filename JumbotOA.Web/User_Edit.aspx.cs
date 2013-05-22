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
    public partial class User_Edit : JumbotOA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("user-edit");
            if (!this.Page.IsPostBack)
            {
                Bind();
                this.txtUname.ReadOnly = true;
            }
        }
        //数据绑定
        void Bind()
        {
            int uid = Str2Int(q("id"), 0);
            JumbotOA.Entity.UserEntity model = new JumbotOA.Entity.UserEntity();
            model = new JumbotOA.BLL.UserBLL().GetEntity(uid);
            this.txtUname.Text = model.Uname;
        }

        //更新
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.UserEntity model = new Entity.UserEntity();
            model = new JumbotOA.BLL.UserBLL().GetEntity(Str2Int(q("id"), 0));
            model.Upwd = JumbotOA.Utils.MD5.Lower32(this.txtAgainpwd.Text.Trim());
            new JumbotOA.BLL.UserBLL().Update(model);
            Addadminlog("修改用户密码");
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
                FinalMessage("操作成功", "User_List.aspx", 0);
            }
        }
    }
}
