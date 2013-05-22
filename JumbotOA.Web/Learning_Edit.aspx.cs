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
    public partial class Learning_Edit : JumbotOA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("learning-edit");
            if (!this.Page.IsPostBack)
            {
                Bind();
                MyValidate();
            }

        }
        //判断是否是发布任务的本人
        void MyValidate()
        {
            JumbotOA.Entity.LearningEntity learningEntity = new JumbotOA.Entity.LearningEntity();
            learningEntity = new JumbotOA.BLL.LearningBLL().GetEntity(Str2Int(q("id")));
            if (UserName != learningEntity.Sauthor)
            {
                FinalMessage("该学习资料你无权修改", "", 1);
            }
        }

        //信息绑定
        void Bind()
        {
            JumbotOA.Entity.LearningEntity model = new JumbotOA.Entity.LearningEntity();
            model = new BLL.LearningBLL().GetEntity(Str2Int(q("id")));
            this.txtTitle.Text = model.Stitle;
            this.FCKeditor1.Value = model.Spath;
        }
        //修改信息
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.LearningEntity model = new Entity.LearningEntity();
            model.Sid = Str2Int(q("id"));
            model.Sauthor = UserName;
            model.Stitle = this.txtTitle.Text;
            model.Sdate = DateTime.Now;
            model.Spath = this.FCKeditor1.Value;
            model.Did = UserDepartmentId;
            new JumbotOA.BLL.LearningBLL().Update(model);
            string addtype = "修改学习资料";
            Addlog(addtype);
        }

        //往操作日志添加信息
        void Addlog(string type)
        {
            Entity.OperatelogEntity model = new Entity.OperatelogEntity();
            model.Uid = UserId;
            model.Eupdatetitle = this.txtTitle.Text;
            model.Eupdatetype = type;
            model.Eupadatetime = DateTime.Now;
            int i = new JumbotOA.BLL.OperatelogBLL().Add(model);
            if (i > 0)
                FinalMessage("修改成功", "Learning_List.aspx", 0);
            else
                FinalMessage("修改失败", "Learning_List.aspx", 0);
        }
    }
}
