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
    /// 业务逻辑类Power 的摘要说明。
	/// </summary>
	public class PowerBLL
	{
		private readonly DAL.PowerDAL dal=new DAL.PowerDAL();
		public PowerBLL()
		{}
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
		public bool Exists(int Pid)
		{
			return dal.Exists(Pid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Entity.PowerEntity model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Entity.PowerEntity model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int Pid)
		{
			
			dal.Delete(Pid);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.PowerEntity GetEntity(int Pid)
		{
			
			return dal.GetEntity(Pid);
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.PowerEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.PowerEntity> DataTableToList(DataTable dt)
		{
			List<Entity.PowerEntity> modelList = new List<Entity.PowerEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Entity.PowerEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Entity.PowerEntity();
					if(dt.Rows[n]["Pid"].ToString()!="")
					{
						model.Pid=int.Parse(dt.Rows[n]["Pid"].ToString());
					}
					model.PName=dt.Rows[n]["PName"].ToString();
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

		#endregion  成员方法
	}
}

