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
    /// 实体类Task 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class AllTaskEntity
    {
        public AllTaskEntity()
        { }
        #region Model
        private int _tlid;
        private int _uid;
        private string _uname  ;
        private string _manager;
        private string _tasktitle;
        private string _content;
        private DateTime _nowtime;
        private DateTime _plantime;
        private DateTime _worktime;
        private int _workprogress;
        private string _workstate;
        /// <summary>
        /// 
        /// </summary>
        public int Tlid
        {
            set { _tlid = value; }
            get { return _tlid; }
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
        /// <summary>
        /// 
        /// </summary>
        public string Manager
        {
            set { _manager = value; }
            get { return _manager; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tasktitle
        {
            set { _tasktitle = value; }
            get { return _tasktitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Nowtime
        {
            set { _nowtime = value; }
            get { return _nowtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Plantime
        {
            set { _plantime = value; }
            get { return _plantime; }
        }
        public DateTime Worktime
        {
            set { _worktime = value; }
            get { return _worktime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Workprogress
        {
            set { _workprogress = value; }
            get { return _workprogress; }
        }
        public string Workstate
        {
            set { _workstate = value; }
            get { return _workstate; }
        }
        #endregion Model
    }

}