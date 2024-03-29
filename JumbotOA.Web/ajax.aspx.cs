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
using System.Data;
using System.Web;
using JumbotOA.Utils;
namespace JumbotOA.Web
{
    public partial class ajax : JumbotOA.UI.BasicPage
    {
        
        private string _operType = string.Empty;
        private string _response = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            this._operType = q("oper");
            switch (this._operType)
            {
                case "ajaxUpdateTime":
                    ajaxUpdateTime();
                    break;
                case "ajaxTest":
                    ajaxTest();
                    break;
                case "ajaxUserList":
                    ajaxUserList();
                    break;
                case "ajaxBacthDelMessage":
                    ajaxBacthDelMessage();
                    break;
                default:
                    DefaultResponse();
                    break;
            }
            Response.Write(this._response);
        }
        private void DefaultResponse()
        {
            this._response = JsonResult(0, "参数错误");
        }
        private void ajaxUpdateTime()
        {
            User_Load("login");
            new BLL.UserBLL().UpdateTime(UserId);
            this._response = JsonResult(1, "10");
        }
        private void ajaxTest()
        {
            User_Load("login");
            string uid = UserId.ToString();
           // ajaxEmail();
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
                    JumbotOA.BLL.OA_SysMessageIn.UPsysMessage(id, recives.Replace("," + uid + ",", ","), 0);
                else
                    JumbotOA.BLL.OA_SysMessageIn.UPsysMessage(id, recives.Replace("," + uid + ",", ","), 1);
                this._response = "{result :\"1\",title :\"" + title + "\",remark :\"" + remark + "\",pages :\"" + pages + "\"}";
            }
            else
                this._response = "{result :\"0\",title :\"\",remark :\"\",pages :\"\"}";
        }
        private void ajaxUserList()
        {
            User_Load("login");
            string sql = "select *,datediff(s,UpdateTime,getdate()) as seconds,(select DName from [OA_Department] where Did=[OA_User].Did) as departmentname,IsNull((select top 1 tasktitle from [OA_Task] where Uid=[OA_User].Uid and Workprogress=2 order by worktime),'无安排') as TaskTitle,(select count(*) from [OA_Message] where FromUid=[OA_User].Uid and ToUid=" + UserId + " and IsRead=0) as newmessage FROM [OA_User] where Pid>2 and Uid<>" + UserId;
            if (UserPowerId > 2)
                sql += " and Did=" + UserDepartmentId;
            DataTable dt = (new JumbotOA.BLL.UserBLL().Getsta(sql)).Tables[0];
            this._response = "{result :\"1\"," +
                "returnval :\"操作成功\"," +
                JumbotOA.Utils.dtHelp.DT2JSON(dt) +
                "}";
            dt.Clear();
            dt.Dispose();
        }
        private void ajaxBacthDelMessage()
        {
            User_Load("login");
            string _ids = f("ids");
            string[] idValue;
            idValue = _ids.Split(',');
            int _doDel = 0;
            for (int i = 0; i < idValue.Length; i++)
            {
                if (new JumbotOA.BLL.MessageBLL().Delete(Convert.ToInt32(idValue[i]), UserId))
                    _doDel++;
            }
            this._response = JsonResult(1, "成功删除" + _doDel + "条信息 ");
        }
      
    }
}
