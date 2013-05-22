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
    public partial class Message_Show : JumbotOA.UI.BasicPage
    {
        public string text;
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("message-show");
            if (!this.Page.IsPostBack)
            {
                Bind_Work();
            }
        }

        void Bind_Work()
        {
            int id = Str2Int(q("id"), 0);
            Entity.MessageEntity model = new Entity.MessageEntity();
            model = new JumbotOA.BLL.MessageBLL().GetEntity(id);
            this.lblTitle.Text = model.Mtitle;
            text = model.Content;
            if (UserId == model.ToUid)
                new JumbotOA.BLL.MessageBLL().SetReadById(id);

        }
    }
}
