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
    public partial class User_Add2 : JumbotOA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("user-add");
        }

        //添加
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            int PId = 2;
            Entity.UserEntity userEntity = new Entity.UserEntity();
            Entity.PowerEntity powerEntity = new BLL.PowerBLL().GetEntity(PId);
            userEntity.Pid = PId;
            userEntity.Uname = this.txtUname.Text;
           // userEntity.Position = this.txtPosition.Text;
            userEntity.Setting = powerEntity.Setting;
            userEntity.Upwd = JumbotOA.Utils.MD5.Lower32(this.txtPwd.Text.Trim());
            if (this.txtIpaddress.Text != "")
            {
                userEntity.Uipaddress = this.txtIpaddress.Text;
            }
            int i = new JumbotOA.BLL.UserBLL().Add(userEntity);
            if (i > 0)
            {
                Addadminlog("添加用户");
            }
            else
            {
                FinalMessage("相同的用户已经存在", "", 1);
            }
        }

        //重置
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            this.txtUname.Text = "";
            this.txtPwd.Text = "";
            this.txtPwdagain.Text = "";
            this.txtUname.Focus();
        }

        //添加管理员操作记录
        void Addadminlog(string type)
        {
            Entity.AdminlogEntity model = new Entity.AdminlogEntity();
            model.Uid = UserId;
            model.Updatetime = DateTime.Now;
            model.Updatetitle = this.txtUname.Text;
            model.Updatetype = type;
            int i = new JumbotOA.BLL.AdminlogBLL().Add(model);
            if (i > 0)
                FinalMessage("用户添加成功", "User_List.aspx", 0);
            else
                FinalMessage("用户添加失败", "User_List.aspx", 0);
        }
    }
}
