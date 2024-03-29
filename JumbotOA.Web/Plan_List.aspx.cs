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
    public partial class Plan_List : JumbotOA.UI.BasicPage
    {
        protected string wherestr, wherestr2 = "";
        public int _uid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("plan-show");
            if (!this.Page.IsPostBack)
            {
                this.txtBegintime.Text = System.DateTime.Today.ToString("yyyy-MM") + "-01";
                this.txtEndtime.Text = System.DateTime.Today.ToString("yyyy-MM-dd");
            }
            wherestr = " and [OA_Plan].Manager =" + UserId;
            _uid = Str2Int(q("uid"));
            if (_uid != 0)
            {
                wherestr += " and [OA_Plan].Uid =" + _uid;
                wherestr2 += " and Uid =" + _uid;
            }
            else
            {
                if (this.ddlUname.SelectedValue != "" && this.ddlUname.SelectedValue != "0")
                    wherestr += " and [OA_Plan].Uid =" + this.ddlUname.SelectedValue;
            }
            if (UserPowerId == 3)
            {//表示部门主管
                wherestr += " and [OA_Plan].Uid in(select Uid from [OA_User] where did=" + UserDepartmentId + ")";
                wherestr2 += " and did=" + UserDepartmentId;
            }
            wherestr += " and (Pwdate>='" + this.txtBegintime.Text + "' and Pwdate<='" + this.txtEndtime.Text + " 23:59:59')";
            if (!this.Page.IsPostBack)
            {
                Selectinfo(wherestr);
                BindMyEmployeeInfo();
                if (_uid != 0)
                    this.ddlUname.SelectedIndex = 0;
                else
                    this.ddlUname.SelectedValue = _uid.ToString();
            }
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        public void Selectinfo(string str)
        {

            int count;
            JumbotOA.BLL.AllPlanBLL bll = new JumbotOA.BLL.AllPlanBLL();
            this.Plan_repeater.DataSource = bll.getpage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, out count, str);
            this.Plan_repeater.DataBind();
            AspNetPager1.RecordCount = count;

        }

        //ddlUname绑定
        void BindMyEmployeeInfo()
        {
            DataSet ds = new JumbotOA.BLL.UserBLL().GetList(" pid=4" + wherestr2);
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.ddlUname.Items.Add(new ListItem(dt.Rows[i]["Uname"].ToString(), dt.Rows[i]["UId"].ToString()));
            }
            dt.Clear();
            dt.Dispose();
            ds.Clear();
            ds.Dispose();
        }
        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbDown_Click(object sender, CommandEventArgs e)
        {
            string path = "";
            JumbotOA.Entity.PlanEntity model = new JumbotOA.Entity.PlanEntity();
            model = new JumbotOA.BLL.PlanBLL().GetEntity(Convert.ToInt32(e.CommandArgument));
            path = model.Pwpath;
            model.Locked = "锁定";
            new JumbotOA.BLL.PlanBLL().Update(model);
            DownloadFile(path);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Selectinfo(wherestr);
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            Selectinfo(wherestr);
        }
    }
}
