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
    public partial class My_Callinfo_Show : JumbotOA.UI.BasicPage
    {
        public string text;
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("");
            if (!this.Page.IsPostBack)
            {
                Bind_Callinfo();
            }
        }

        void Bind_Callinfo()
        {
            int id = Str2Int(q("id"), 0);
            Entity.CallinfoEntity model = new Entity.CallinfoEntity();
            model = new JumbotOA.BLL.CallinfoBLL().GetEntity(id);
            if (model.Uid != UserId)
            {
                FinalMessage("请勿违规操作", "", 100);
            }
            this.lblTitle.Text = model.Title;
            this.lblAddtime.Text = model.Addtime.ToString();
            this.lblUnit.Text = model.Unit;
            this.lblUserinfo.Text = model.Userinfo;
            this.lblReply.Text = model.Reply;
            text = model.Remark;
        }
    }
}
