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
    /// 业务逻辑类Adminlog 的摘要说明。
    /// </summary>
    public class AdminlogBLL
    {
        private readonly DAL.AdminlogDAL dal = new DAL.AdminlogDAL();
        public AdminlogBLL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Adminlogid)
        {
            return dal.Exists(Adminlogid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.AdminlogEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Entity.AdminlogEntity model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Adminlogid)
        {

            dal.Delete(Adminlogid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.AdminlogEntity GetEntity(int Adminlogid)
        {

            return dal.GetEntity(Adminlogid);
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
        public List<Entity.AdminlogEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.AdminlogEntity> DataTableToList(DataTable dt)
        {
            List<Entity.AdminlogEntity> modelList = new List<Entity.AdminlogEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Entity.AdminlogEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Entity.AdminlogEntity();
                    if (dt.Rows[n]["Adminlogid"].ToString() != "")
                    {
                        model.Adminlogid = int.Parse(dt.Rows[n]["Adminlogid"].ToString());
                    }
                    model.Updatetitle = dt.Rows[n]["Updatetitle"].ToString();
                    if (dt.Rows[n]["Updatetime"].ToString() != "")
                    {
                        model.Updatetime = DateTime.Parse(dt.Rows[n]["Updatetime"].ToString());
                    }
                    model.Updatetype = dt.Rows[n]["Updatetype"].ToString();
                    if (dt.Rows[n]["Uid"].ToString() != "")
                    {
                        model.Uid = int.Parse(dt.Rows[n]["Uid"].ToString());
                    }
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

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        public List<Entity.AdminlogEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            return dal.getpage(pageSize, pageNum, out count, str);
        }
        #endregion  成员方法
    }
}

