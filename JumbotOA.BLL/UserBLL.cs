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
    /// 业务逻辑类User 的摘要说明。
    /// </summary>
    public class UserBLL
    {
        private readonly DAL.UserDAL dal = new DAL.UserDAL();
        public UserBLL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Uid)
        {
            return dal.Exists(Uid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.UserEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Entity.UserEntity model)
        {
            dal.Update(model);
        }

        public bool UpdateTime(int Uid)
        {
            return dal.UpdateTime(Uid);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Uid)
        {

            dal.Delete(Uid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.UserEntity GetEntity(int Uid)
        {

            return dal.GetEntity(Uid);
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
        public List<JumbotOA.Entity.UserEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<JumbotOA.Entity.UserEntity> modelList = new List<JumbotOA.Entity.UserEntity>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                JumbotOA.Entity.UserEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new JumbotOA.Entity.UserEntity();
                    if (ds.Tables[0].Rows[n]["Uid"].ToString() != "")
                    {
                        model.Uid = int.Parse(ds.Tables[0].Rows[n]["Uid"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Pid"].ToString() != "")
                    {
                        model.Pid = int.Parse(ds.Tables[0].Rows[n]["Pid"].ToString());
                    }
                    model.Uname = ds.Tables[0].Rows[n]["Uname"].ToString();
                    model.Upwd = ds.Tables[0].Rows[n]["Upwd"].ToString();
                    model.Uipaddress = ds.Tables[0].Rows[n]["Uipaddress"].ToString();
                    model.Setting = ds.Tables[0].Rows[n]["Setting"].ToString();
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
        /// 登入
        /// </summary>
        /// <param name="kls_uid"></param>
        /// <param name="kls_pwd"></param>
        /// <param name="kls_num"></param>
        /// <returns></returns>
        public string Existslongin(string uname, string upwd)
        {
            return dal.Existslongin(uname, upwd);
        }

        /// <summary>
        /// 获取角色
        /// </summary>
        /// <param name="kls_uid"></param>
        /// <param name="kls_pwd"></param>
        /// <param name="kls_num"></param>
        /// <returns></returns>
        public Entity.PowerEntity Getpomodel(string sql)
        {
            return dal.Getpomodel(sql);
        }

        /// <summary>
        /// 获取UID
        /// </summary>
        /// <param name="kls_uid"></param>
        /// <param name="kls_pwd"></param>
        /// <param name="kls_num"></param>
        /// <returns></returns>
        public Entity.UserEntity Getuname(string sql)
        {
            return dal.Getuname(sql);
        }

        /// <summary>
        /// 多表连接
        /// </summary>
        /// <param name="kls_uid"></param>
        /// <param name="kls_pwd"></param>
        /// <param name="kls_num"></param>
        /// <returns></returns>
        public DataSet Getall(string sql)
        {
            return dal.Getall(sql);
        }

        /// <summary>
        /// 工作状态
        /// </summary>
        /// <param name="kls_uid"></param>
        /// <param name="kls_pwd"></param>
        /// <param name="kls_num"></param>
        /// <returns></returns>
        public DataSet Getsta(string sql)
        {
            return dal.Getsta(sql);
        }
        #endregion  成员方法
    }
}

