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
    public class AllSummarizeDAL
    {
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Entity.AllSummarizeEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            string select, table, where, order;

            select = " [OA_Summarize].suid,[OA_Summarize].sutitle,[OA_User].uname,[OA_Summarize].sutext,[OA_Summarize].sutime ";


            table = "  [OA_Summarize] left join [OA_User] on [OA_Summarize].uid = [OA_User].uid ";

            StringBuilder sb = new StringBuilder();
            sb.Append(" ( 1 = 1 ) " + str);

            where = sb.ToString();

            order = "Suid";

            string sql = "exec Pagination @select, @table, @where, @orderField, @orderType, @pageSize, @pageNum ";

            SqlParameter[] paras ={ 
                new SqlParameter("@select",     select),
                new SqlParameter("@table",      table),
                new SqlParameter("@where",      where),
                new SqlParameter("@orderField", order),
                new SqlParameter("@orderType",  '1'),
                new SqlParameter("@pageSize",   pageSize),
                new SqlParameter("@pageNum",    pageNum)
            };

            DataSet ds = DbHelperSQL.Query(sql, paras);

            count = Convert.ToInt32(ds.Tables[1].Rows[0][0]);

            List<Entity.AllSummarizeEntity> list = new List<Entity.AllSummarizeEntity>();
            Entity.AllSummarizeEntity model;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                model = new Entity.AllSummarizeEntity();

                if (ds.Tables[0].Rows[i]["Suid"].ToString() != "")
                {
                    model.Suid = int.Parse(ds.Tables[0].Rows[i]["Suid"].ToString());
                }
                model.Uname = ds.Tables[0].Rows[i]["Uname"].ToString();
                model.Sutime = Convert.ToDateTime(ds.Tables[0].Rows[i]["Sutime"].ToString());
                model.Sutext = ds.Tables[0].Rows[i]["Sutext"].ToString();
                model.Sutitle = ds.Tables[0].Rows[i]["Sutitle"].ToString();
                list.Add(model);
            }

            return list;
        }
    }
}
