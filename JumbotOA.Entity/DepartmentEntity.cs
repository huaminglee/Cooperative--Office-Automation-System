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
namespace JumbotOA.Entity
{
    /// <summary>
    /// 实体类Department 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class DepartmentEntity
    {
        public DepartmentEntity()
        { }
        #region Model
        private int _did;
        private string _dname;
        /// <summary>
        /// 部门ID，用于区分权限
        /// </summary>
        public int Did
        {
            set { _did = value; }
            get { return _did; }
        }
        /// <summary>
        /// 部门
        /// </summary>
        public string DName
        {
            set { _dname = value; }
            get { return _dname; }
        }
        #endregion Model

    }
}

