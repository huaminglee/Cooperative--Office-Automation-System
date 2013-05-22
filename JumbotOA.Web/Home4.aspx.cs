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
using jmail;
namespace JumbotOA.Web
{
    public partial class Home4 : JumbotOA.UI.BasicPage
    {
        public string innerUrl = "DeskTop4.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            oktime.Text = "今天是" + DateTime.Now.ToString("yyyy年MM月dd日") + Day[Convert.ToInt16(DateTime.Now.DayOfWeek)];
            User_Load("", "/Index.aspx", 0);
            if (UserPowerId != 4)
                Response.Redirect("Home" + UserPowerId + ".aspx");
            if (q("frame") != "") innerUrl = q("frame");
            //else
            //{
            //    if (!IsPostBack)
            //    {
            //        string uid = UserId.ToString();
            //        DataTable table =JumbotOA.BLL.OA_SysMessageIn.getsysMessage(uid);
            //        if (table.Rows.Count != 0)
            //        {
            //            string id = table.Rows[0]["Id"].ToString();
            //            string title = table.Rows[0]["titles"].ToString();
            //            string remark = table.Rows[0]["remark"].ToString();
            //            string pages = table.Rows[0]["pages"].ToString();
            //            string recives = table.Rows[0]["recives"].ToString();
            //            string[] len = recives.Split(",".ToCharArray());
            //            if (len.Length > 3)
            //                JumbotOA.BLL.OA_SysMessageIn.UPsysMessage(id, recives.Replace("," + uid, ""), 0);
            //            else
            //                JumbotOA.BLL.OA_SysMessageIn.UPsysMessage(id, recives.Replace("," + uid, ""), 1);
            //            System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
            //            page.ClientScript.RegisterStartupScript(GetType(), "msg", "<script>popmsg('" + title + "','" + remark + "',escape('" + pages + "'))</script>");
            //        }
            //    }
            //}
        }
        public  string email()
        {
            string a = "";
            JumbotOA.BLL.COMDLL com = new JumbotOA.BLL.COMDLL();
            DataTable dt = com.COM_Proc_Sel1("Pc_emailsystem", "," + UserId + ",");
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["contents"].ToString() != "0")
                a = "<a href=" + "" + dt.Rows[0]["titles"].ToString() + "" + " target=\"_blank\">共有<font style=\"color:#000099;font-weight: bold\">" + dt.Rows[0]["files"].ToString() + "</font> 封邮件，今天有<font style=\"color: #FF0000;font-weight: bold\">" + dt.Rows[0]["contents"].ToString() + "</font>封邮件,请登录!" + "</a>";
                //string sid = dt.Rows[0]["Id"].ToString();
                //DataRow drw = dt.Rows[0];
                //drw["files"] = "0";
                //com.COM_Up(dt, "OA_EmailtextTB", "files=@files", sid);
            }
            return a;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            bangemmail();
        }
        void bangemmail()
        {
            JumbotOA.BLL.COMDLL com = new JumbotOA.BLL.COMDLL();
            JumbotOA.BLL.URLENCRYP urlen = new JumbotOA.BLL.URLENCRYP();
            string UserId = JumbotOA.BLL.OA_SysMessageIn.userid();
            string username = "", userpwd = "", pstr = "";
            string[] str = null;
            DataTable dt = com.COM_Proc_Sel1("PC_getOA_email", UserId.ToString());
            if (dt.Rows.Count != 0)
            {
                #region 存储了邮箱
                str = dt.Rows[0]["emailname"].ToString().Split("@".ToCharArray());
                if (str[1] == "jumbotcms.net")
                    username = str[0].ToString();
                else
                    username = dt.Rows[0]["emailname"].ToString();
                pstr = dt.Rows[0]["emailname"].ToString();
                userpwd = urlen.Decryp(dt.Rows[0]["emailpwd"].ToString());

                jmail.POP3Class popMail = new POP3Class();
                jmail.Message mailMessage;
                //取得最大时间
                DataTable dts = com.COM_Proc_Sel1("Pc_emailsystem", "," + UserId + ",");  
                string popstr = JumbotOA.BLL.Eemail.GetFormatPop3(pstr).ToString();
                int num = 0;
                try
                {
                    popMail.Connect(username, userpwd, popstr, 110); //建立连接
                    if (0 < popMail.Count)
                    {
                        #region 检索今天邮件
                     DateTime t1=  Convert.ToDateTime(DateTime.Now.ToString("yyyy-M-d").ToString() + " 01:00:00");
                       DateTime t2=Convert.ToDateTime(DateTime.Now.ToString("yyyy-M-d").ToString() + " 23:59:59");
                        for (int i = popMail.Count; i > 0; i--)
                        {
                            mailMessage = popMail.Messages[i];
                           
                            if (dts.Rows.Count != 0)
                            {
                                if (mailMessage.Date >= t1 && mailMessage.Date <= t2)
                                    num++;
                                else
                                    continue;
                            }
                            else
                            {
                                dts.Rows.Clear();
                                DataRow dr = dts.NewRow();
                                dr["uid"] = "," + UserId + ",";
                                dr["recivetime"] = DateTime.Now;
                                dr["files"] = popMail.Count.ToString();//邮件总数
                                dr["contents"] = "0";
                                dts.Rows.Add(dr);
                                com.COM_Add(dts, "OA_EmailtextTB", "@uid,@recivetime,@files,@contents");
                            }
                        }
                        #endregion
                    }
                       string titles = "";
                        switch (str[1])
                        {
                            case "jumbotcms.net":
                                titles = "http://mail.jumbotcms.net/default.jsp";
                                break;
                            case "sina.com":
                                titles = "http://mail.sina.com.cn";
                                break;
                            case "sina.cn":
                                titles = "http://mail.sina.com.cn/cnmail/index.html";
                                break;
                            case "163.com":
                                titles = "http://email.163.com";
                                break;
                            case "126.com":
                                titles = "http://email.163.com";
                                break;
                            case "yeah.net":
                                titles = "http://email.163.com";
                                break;
                            case "qq.com":
                                titles = "https://mail.qq.com/cgi-bin/loginpage?flowid=16621966528880993";
                                break;
                        }
                            string Id = dts.Rows[0]["Id"].ToString();
                            DataRow drw = dts.Rows[0];
                            drw["recivetime"] = DateTime.Now;
                            drw["titles"] = titles;
                            drw["files"] = popMail.Count.ToString();
                            drw["contents"] = num.ToString();
                            com.COM_Up(dts, "OA_EmailtextTB", "recivetime=@recivetime,titles=@titles,files=@files,contents=@contents", Id);
                    popMail.Disconnect();
                    popMail = null;
                    Tools.Common.JavaScript.MessageBox(this, "检索成功!");
                }
                catch (Exception e)
                {
                    com.ErroLog(e.ToString());
                    Tools.Common.JavaScript.MessageBox(this, "检索失败！网络连接已超时！");
                }

                #endregion
            }
            else
                Tools.Common.JavaScript.MessageBox(this, "您还没有保存过邮箱名称和密码信息！暂时无法检索！");
        }
          
       
    }
}
