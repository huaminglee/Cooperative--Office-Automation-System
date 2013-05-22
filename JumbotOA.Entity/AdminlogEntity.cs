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
    /// 实体类Adminlog 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class AdminlogEntity
    {
        public AdminlogEntity()
        { }
        #region Model
        private int _adminlogid;
        private string _updatetitle;
        private DateTime _updatetime;
        private string _updatetype;
        private int _uid;
        private string _uname;
        /// <summary>
        /// 
        /// </summary>
        public int Adminlogid
        {
            set { _adminlogid = value; }
            get { return _adminlogid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Updatetitle
        {
            set { _updatetitle = value; }
            get { return _updatetitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Updatetime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Updatetype
        {
            set { _updatetype = value; }
            get { return _updatetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Uid
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Uname
        {
            set { _uname = value; }
            get { return _uname; }
        }
        #endregion Model

    }
}

