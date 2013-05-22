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
    public partial class My_Summarize_Edit : JumbotOA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("");
            if (!this.Page.IsPostBack)
            {
                Sumbind();
            }
        }

        //工作总结绑定
        void Sumbind()
        {
            Entity.SummarizeEntity model = new Entity.SummarizeEntity();
            int id = Str2Int(q("id"), 0);
            model = new JumbotOA.BLL.SummarizeBLL().GetThisWeekModelbByUid(UserId);
            if (model != null)
            {
                if (model.Suid == id)
                {
                    this.txtTitle.Text = model.Sutitle;
                    this.FCKeditor1.Value = model.Sutext;
                }
                else
                {
                    FinalMessage("绑定失败", "My_Summarize_List.aspx", 0);
                }
            }
            else
            {
                FinalMessage("绑定失败", "My_Summarize_List.aspx", 0);
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.SummarizeEntity model = new Entity.SummarizeEntity();
            model = new JumbotOA.BLL.SummarizeBLL().GetThisWeekModelbByUid(UserId);
            int id = Str2Int(q("id"), 0);
            if (model != null)
            {
                if (model.Suid == id)
                {
                    //修改
                    model.Sutitle = this.txtTitle.Text;
                    model.Sutime = DateTime.Now;
                    model.Sutext = this.FCKeditor1.Value;
                    new JumbotOA.BLL.SummarizeBLL().Update(model);
                    FinalMessage("操作成功", "My_Summarize_List.aspx", 0);
                }
                else
                {
                    FinalMessage("操作失败", "My_Summarize_List.aspx", 0);
                }
            }
            else
            {
                FinalMessage("操作失败", "My_Summarize_List.aspx", 0);
            }

        }

    }
}
