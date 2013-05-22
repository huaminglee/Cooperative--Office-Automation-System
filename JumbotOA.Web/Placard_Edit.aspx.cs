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
    public partial class Placard_Edit : JumbotOA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("placard-edit");
            if (!this.Page.IsPostBack)
            {
                Bind();
                MyValidate();
            }
        }
        //判断是否是发布任务的本人
        void MyValidate()
        {
            JumbotOA.Entity.PlacardEntity placardEntity = new JumbotOA.Entity.PlacardEntity();
            placardEntity = new JumbotOA.BLL.PlacardBLL().GetEntity(Str2Int(q("id")));
            if (UserName != placardEntity.Pauthor)
            {
                FinalMessage("该通知公告你无权修改", "", 1);
            }
        }

        //信息绑定
        void Bind()
        {
            JumbotOA.Entity.PlacardEntity model = new JumbotOA.Entity.PlacardEntity();
            model = new BLL.PlacardBLL().GetEntity(Str2Int(q("id")));
            this.txtTitle.Text = model.Ptitle;
            this.FCKeditor1.Value = model.Ptext;
        }
        //修改信息
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.PlacardEntity model = new Entity.PlacardEntity();
            model.Pid = Str2Int(q("id"));
            model.Pauthor = UserName;
            model.Ptitle = this.txtTitle.Text;
            model.Pdate = DateTime.Now;
            model.Ptext = this.FCKeditor1.Value;
            new JumbotOA.BLL.PlacardBLL().Update(model);
            string addtype = "修改通知公告";
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
                FinalMessage("修改成功", "Placard_List.aspx", 0);
            else
                FinalMessage("修改失败", "Placard_List.aspx", 0);
        }
    }
}
