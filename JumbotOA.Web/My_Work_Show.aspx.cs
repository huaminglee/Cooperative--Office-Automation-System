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

namespace JumbotOA.Web
{
    public partial class My_Work_Show : JumbotOA.UI.BasicPage
    {
        public string text;
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("");
            if (!this.Page.IsPostBack)
            {
                Msgbind();
            }
        }

        void Bind_Work()
        {
            //int id = Str2Int(q("id"), 0);
            //Entity.TaskEntity model = new Entity.TaskEntity();
            //model = new JumbotOA.BLL.TaskBLL().GetEntity(id);
            //if (model.Workprogress == 1)
            //{
            //    JumbotOA.BLL.TaskBLL u = new JumbotOA.BLL.TaskBLL();
            //    u.Upworkprogress(2,id);
            //}
            //if (model.Uid != UserId)
            //{
            //    FinalMessage("请勿违规操作", "", 100);
            //}
            //this.lblTitle.Text = model.Tasktitle;
            //text = model.Content;
            //Workprogress.Text = model.Workstate;
            //classse.Text = model.Classse;
            //Plantime.Text = model.Plantime.ToString();
            //Manager.Text = model.Manager;
            //remark.Text = model.Remark;
        }
        void Msgbind()
        {
            int id = Str2Int(q("id"), 0);
            Entity.TaskEntity model = new Entity.TaskEntity();
            model = new JumbotOA.BLL.TaskBLL().GetEntity(id);
            if (model.Workprogress == 1)
            {
                JumbotOA.BLL.TaskBLL u = new JumbotOA.BLL.TaskBLL();
                u.Upworkprogress(2, id);
            }
            if (model.Uid != UserId)
            {
                FinalMessage("请勿违规操作", "", 100);
            }
            this.lblTitle.Text = model.Tasktitle;
            this.lblBegintime.Text = model.Nowtime.ToString();
            this.lblEndtime.Text = model.Plantime.ToString();
            txt.Text = model.Content;
            question.Text = model.Question;
            classse.Text = model.Classse;
            Manager.Text = model.Manager;
            labwork.Text = model.Worktime.ToString();
        }

        public string download()
        {
            string str = "";
            int id = Str2Int(q("id"), 0);
            Entity.TaskEntity model = new Entity.TaskEntity();
            model = new JumbotOA.BLL.TaskBLL().GetEntity(id);
            if (model.Filepath != null)
            {
                string[] rows = model.Filepath.ToString().Split(",".ToCharArray());
                if (rows.Length > 1)
                {
                    for (int i = 0; i < rows.Length - 1; i++)
                    {
                        str += "<a href=\"/workfile/" + rows[i].ToString() + "\" style=\"border:0\">" + rows[i].Substring(rows[i].LastIndexOf("$") + 1) + "</a><br />&nbsp;";

                    }
                }
            }
            return str;
        }
    }
}
