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
    public partial class My_Summarize_Add : JumbotOA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("");
            if (!this.Page.IsPostBack)
            {
                Isfirst();
            }
        }

        //加载时判断本周是否插入过工作总结
        void Isfirst()
        {
            Entity.SummarizeEntity model = new Entity.SummarizeEntity();
            model = new BLL.SummarizeBLL().GetThisWeekModelbByUid(UserId);
            if (model != null)
            {
                this.txtTitle.Text = model.Sutitle;
                this.FCKeditor1.Value = model.Sutext;
                this.hidRecordID.Value = "update";
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.SummarizeEntity model = new Entity.SummarizeEntity();
            model = new JumbotOA.BLL.SummarizeBLL().GetModelbyuid(UserId);
            if (this.hidRecordID.Value == "update")
            {
                //不为空则，修改
                model.Sutitle = this.txtTitle.Text;
                model.Sutime = DateTime.Today;
                model.Sutext = this.FCKeditor1.Value;
                new JumbotOA.BLL.SummarizeBLL().Update(model);
                FinalMessage("操作成功", "My_Summarize_List.aspx", 0);
            }

            else
            {
                //插入
                model = new Entity.SummarizeEntity();
                model.Uid = UserId;
                model.Sutime = DateTime.Now;
                model.Sutitle = this.txtTitle.Text;
                model.Sutext = this.FCKeditor1.Value;
                int i = new JumbotOA.BLL.SummarizeBLL().Add(model);
                if (i > 0)
                {
                    FinalMessage("操作成功", "My_Summarize_List.aspx", 0);
                }
                else
                {
                    System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                    page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script language='javascript'>alert('操作失败！');</script>");
                }
            }
        }
    }
}
