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
using Layers.Common;

namespace JumbotOA.Web
{
    public partial class My_Callinfo_Add : JumbotOA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("");
            if (!this.Page.IsPostBack)
            {
            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.CallinfoEntity callinfo = new Entity.CallinfoEntity();
            callinfo.Uid = UserId;
            callinfo.Addtime = Convert.ToDateTime(this.txtAddtime.Text);
            callinfo.Title = this.txtTitle.Text;
            callinfo.Unit = this.txtUnit.Text;
            callinfo.Reply = this.txtReply.Text;
            callinfo.Userinfo = this.txtUserinfo.Text;
            callinfo.Remark = this.FCKeditor1.Value;
            int i = new JumbotOA.BLL.CallinfoBLL().Add(callinfo);
            if (i > 0)
            {
                FinalMessage("操作成功", "My_Callinfo_List.aspx", 0);
            }
            else
            {
                FinalMessage("操作失败", "My_Callinfo_List.aspx", 0);
            }
        }
    }
}
