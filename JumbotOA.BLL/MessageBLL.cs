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
    /// 业务逻辑类Message 的摘要说明。
    /// </summary>
    public class MessageBLL
    {
        private readonly JumbotOA.DAL.MessageDAL dal = new JumbotOA.DAL.MessageDAL();
        public MessageBLL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Mid)
        {
            return dal.Exists(Mid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(JumbotOA.Entity.MessageEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(JumbotOA.Entity.MessageEntity model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Mid)
        {

            dal.Delete(Mid);
        }
        public bool Delete(int Mid, int Uid)
        {

            return dal.Delete(Mid, Uid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public JumbotOA.Entity.MessageEntity GetEntity(int Mid)
        {

            return dal.GetEntity(Mid);
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
        public List<JumbotOA.Entity.MessageEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<JumbotOA.Entity.MessageEntity> modelList = new List<JumbotOA.Entity.MessageEntity>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                JumbotOA.Entity.MessageEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new JumbotOA.Entity.MessageEntity();
                    if (ds.Tables[0].Rows[n]["Mid"].ToString() != "")
                    {
                        model.Mid = int.Parse(ds.Tables[0].Rows[n]["Mid"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ToUid"].ToString() != "")
                    {
                        model.ToUid = int.Parse(ds.Tables[0].Rows[n]["ToUid"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["FromUid"].ToString() != "")
                    {
                        model.FromUid = int.Parse(ds.Tables[0].Rows[n]["FromUid"].ToString());
                    }
                    model.Mtitle = ds.Tables[0].Rows[n]["Mtitle"].ToString();
                    model.Content = ds.Tables[0].Rows[n]["Content"].ToString();
                    if (ds.Tables[0].Rows[n]["Addtime"].ToString() != "")
                    {
                        model.Addtime = DateTime.Parse(ds.Tables[0].Rows[n]["Addtime"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["touser"].ToString() != "")
                    {
                        model.Touser = (ds.Tables[0].Rows[n]["touser"].ToString());
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

        public List<Entity.MessageEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            return dal.getpage(pageSize, pageNum, out count, str);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void SetReadById(int Mid)
        {
            dal.SetReadById(Mid);
        }
        #endregion  成员方法
    }
}

