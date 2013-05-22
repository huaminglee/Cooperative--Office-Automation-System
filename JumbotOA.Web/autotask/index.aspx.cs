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
using System.Data;
using System.Web;
using JumbotOA.Utils;
namespace JumbotOA.Web.AutoTask
{
    public partial class _index : JumbotOA.UI.BasicPage
    {
        private string _operType = string.Empty;
        private string _response = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            this._operType = q("oper");
            switch (this._operType)
            {
                case "LockSummarize":
                    LockSummarize();
                    break;
                default:
                    DefaultResponse();
                    break;
            }
            Response.Write(this._response);
        }
        private void DefaultResponse()
        {
            this._response = "未知操作";
        }
        /// <summary>
        /// 锁定非本周的工作总结
        /// </summary>
        private void LockSummarize()
        {
            string _password = q("password");
            if (_password != System.Configuration.ConfigurationManager.AppSettings["AutoTask:Password"])
            {
                this._response = "密码错误";
                return;
            }
            int _doCount = new JumbotOA.BLL.SummarizeBLL().LockSummarize();
            if (_doCount > 0)
                this._response = "有" + _doCount + "个工作总结被锁定";
            else
                this._response = "没有工作总结被锁定";
        }
    }
}