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

namespace JumbotOA.Entity
{
    /// <summary>
    /// 实体类Operatelog 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class OperatelogEntity
    {
        public OperatelogEntity()
        { }
        #region Model
        private int _elselogid;
        private string _eupdatetitle;
        private DateTime _eupadatetime;
        private string _eupdatetype;
        private int _uid;
        private string _uname;
        /// <summary>
        /// 
        /// </summary>
        public int Operatelogid
        {
            set { _elselogid = value; }
            get { return _elselogid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Eupdatetitle
        {
            set { _eupdatetitle = value; }
            get { return _eupdatetitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Eupadatetime
        {
            set { _eupadatetime = value; }
            get { return _eupadatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Eupdatetype
        {
            set { _eupdatetype = value; }
            get { return _eupdatetype; }
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
