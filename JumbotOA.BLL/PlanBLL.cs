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
using System.Collections.Generic;
using JumbotOA.Entity;
namespace JumbotOA.BLL
{
    /// <summary>
    /// 业务逻辑类Plan 的摘要说明。
    /// </summary>
    public class PlanBLL
    {
        private readonly JumbotOA.DAL.PlanDAL dal = new JumbotOA.DAL.PlanDAL();
        public PlanBLL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Pwid)
        {
            return dal.Exists(Pwid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(JumbotOA.Entity.PlanEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(JumbotOA.Entity.PlanEntity model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Pwid)
        {

            dal.Delete(Pwid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public JumbotOA.Entity.PlanEntity GetEntity(int Pwid)
        {

            return dal.GetEntity(Pwid);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<JumbotOA.Entity.PlanEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<JumbotOA.Entity.PlanEntity> DataTableToList(DataTable dt)
        {
            List<JumbotOA.Entity.PlanEntity> modelList = new List<JumbotOA.Entity.PlanEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                JumbotOA.Entity.PlanEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new JumbotOA.Entity.PlanEntity();
                    if (dt.Rows[n]["Pwid"].ToString() != "")
                    {
                        model.Pwid = int.Parse(dt.Rows[n]["Pwid"].ToString());
                    }
                    if (dt.Rows[n]["Uid"].ToString() != "")
                    {
                        model.Uid = int.Parse(dt.Rows[n]["Uid"].ToString());
                    }
                    if (dt.Rows[n]["Pwdate"].ToString() != "")
                    {
                        model.Pwdate = DateTime.Parse(dt.Rows[n]["Pwdate"].ToString());
                    }
                    model.Pwpath = dt.Rows[n]["Pwpath"].ToString();
                    model.Locked = dt.Rows[n]["Locked"].ToString();
                    model.Manager = dt.Rows[n]["Manager"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        public List<Entity.PlanEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            return dal.getpage(pageSize, pageNum, out count, str);
        }
        #endregion  成员方法
    }
}

