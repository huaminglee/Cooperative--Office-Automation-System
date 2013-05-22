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
    /// 实体类User 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class UserEntity
    {
        public UserEntity()
        { }
        #region Model
        private int _uid;
        private int _pid;
        private int _did;
        private string _uname;
        private string _upwd;
        private string _uipaddress;
        private string _position;
        private string _setting;
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int Pid
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 部门ID
        /// </summary>
        public int Did
        {
            set { _did = value; }
            get { return _did; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Uname
        {
            set { _uname = value; }
            get { return _uname; }
        }
        /// <summary>
        /// 32位加密密码
        /// </summary>
        public string Upwd
        {
            set { _upwd = value; }
            get { return _upwd; }
        }
        /// <summary>
        /// 限制IP
        /// </summary>
        public string Uipaddress
        {
            set { _uipaddress = value; }
            get { return _uipaddress; }
        }
        /// <summary>
        /// 职位
        /// </summary>
        public string Position
        {
            set { _position = value; }
            get { return _position; }
        }
        /// <summary>
        /// 权限列表
        /// </summary>
        public string Setting
        {
            set { _setting = value; }
            get { return _setting; }
        }
        #endregion Model

    }
}

