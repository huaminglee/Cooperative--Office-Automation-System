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
    public partial class Home1 : JumbotOA.UI.BasicPage
    {
        public string innerUrl = "DeskTop1.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            oktime.Text ="今天是"+ DateTime.Now.ToString("yyyy年MM月dd日") + Day[Convert.ToInt16(DateTime.Now.DayOfWeek)];
            User_Load("", "/Index.aspx", 0);
            if (UserPowerId != 1)
                Response.Redirect("Home" + UserPowerId + ".aspx");
            if (q("frame") != "") innerUrl = q("frame");
            else
            {
                if (!IsPostBack)
                {
                    string uid = UserId.ToString();
                    DataTable table = JumbotOA.BLL.OA_SysMessageIn.getsysMessage(uid);
                    if (table.Rows.Count != 0)
                    {
                        string id = table.Rows[0]["Id"].ToString();
                        string title = table.Rows[0]["titles"].ToString();
                        string remark = table.Rows[0]["remark"].ToString();
                        string pages = table.Rows[0]["pages"].ToString();
                        string recives = table.Rows[0]["recives"].ToString();
                        string[] len = recives.Split(",".ToCharArray());
                        if (len.Length > 3)
                            JumbotOA.BLL.OA_SysMessageIn.UPsysMessage(id, recives.Replace("," + uid, ""), 0);
                        else
                            JumbotOA.BLL.OA_SysMessageIn.UPsysMessage(id, recives.Replace("," + uid, ""), 1);
                        System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                        page.ClientScript.RegisterStartupScript(GetType(), "msg", "<script>popmsg('" + title + "','" + remark + "',escape('" + pages + "'))</script>");
                    }
                }
            }
           
        }

    }
}
