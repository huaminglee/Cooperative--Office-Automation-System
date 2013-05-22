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
    /// 实体类Diary 。(属性说明自动提取数据库字段的描述信息)  51aspx.com 提供下载
    /// </summary>
    [Serializable]
    public class DiaryEntity
    {
        public DiaryEntity()
        { }
        #region Model
        private long _id;
        private string _title;
        private DateTime _workdate;
        private decimal _workduration;
        private string _note;
        private int _ownerid;
        private string _comment;
        private DateTime _createtime;
        /// <summary>
        /// 
        /// </summary>
        public long ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime WorkDate
        {
            set { _workdate = value; }
            get { return _workdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal WorkDuration
        {
            set { _workduration = value; }
            get { return _workduration; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Note
        {
            set { _note = value; }
            get { return _note; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OwnerID
        {
            set { _ownerid = value; }
            get { return _ownerid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Comment
        {
            set { _comment = value; }
            get { return _comment; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        #endregion Model

    }
}
