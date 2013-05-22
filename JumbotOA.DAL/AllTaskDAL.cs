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
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using JumbotOA.DBUtility;

namespace JumbotOA.DAL
{
    public class AllTaskDAL
    {
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Entity.AllTaskEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            string select, table, where, order;

            select = "  [OA_Task].*,[OA_User].uname,(case when ([OA_Task].Workprogress= 1) then '新的任务' when ([OA_Task].Workprogress= 2) then '正在办理' when ([OA_Task].Workprogress= 3) then '已经完成' end) as Workstate ";


            table = "  [OA_Task] left join  [OA_User] on [OA_Task].uid = [OA_User].uid ";

            StringBuilder sb = new StringBuilder();
            sb.Append(" ( 1 = 1 ) " + str);

            where = sb.ToString();

            order = "Tlid";

            string sql = "exec Pagination @select, @table, @where, @orderField, @orderType, @pageSize, @pageNum ";

            SqlParameter[] paras ={ 
                new SqlParameter("@select",     select),
                new SqlParameter("@table",      table),
                new SqlParameter("@where",      where),
                new SqlParameter("@orderField", order),
                new SqlParameter("@orderType",  '0'),
                new SqlParameter("@pageSize",   pageSize),
                new SqlParameter("@pageNum",    pageNum)
            };

            DataSet ds = DbHelperSQL.Query(sql, paras);

            count = Convert.ToInt32(ds.Tables[1].Rows[0][0]);

            List<Entity.AllTaskEntity> list = new List<Entity.AllTaskEntity>();
            Entity.AllTaskEntity model;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                model = new Entity.AllTaskEntity();

                if (ds.Tables[0].Rows[i]["Tlid"].ToString() != "")
                {
                    model.Tlid = int.Parse(ds.Tables[0].Rows[i]["Tlid"].ToString());
                }
                model.Uid = int.Parse(ds.Tables[0].Rows[i]["Uid"].ToString());
                model.Manager = ds.Tables[0].Rows[i]["Manager"].ToString();
                model.Nowtime = Convert.ToDateTime(ds.Tables[0].Rows[i]["Nowtime"].ToString());
                model.Plantime = Convert.ToDateTime(ds.Tables[0].Rows[i]["Plantime"].ToString());
                model.Tasktitle = ds.Tables[0].Rows[i]["Tasktitle"].ToString();
                model.Uname = ds.Tables[0].Rows[i]["Uname"].ToString();
                model.Worktime = Convert.ToDateTime(ds.Tables[0].Rows[i]["Worktime"].ToString());
                model.Workprogress = int.Parse(ds.Tables[0].Rows[i]["Workprogress"].ToString());
                model.Workstate = ds.Tables[0].Rows[i]["Workstate"].ToString();
                list.Add(model);
            }
            return list;
        }
    }
}