/*
 * ������������: ����Эͬ�칫ϵͳ���װ�
 * 
 * ����Ӣ������: JumbotOA
 * 
 * ����汾: 1.1.X
 * 
 * ��������: ���������Ŷ� (���ƿ�������ϵ��jumbot114@126.com,�������޳��ļ�������,�����)
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
    /// ʵ����Department ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// ����ID����������Ȩ��
        /// </summary>
        public int Did
        {
            set { _did = value; }
            get { return _did; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string DName
        {
            set { _dname = value; }
            get { return _dname; }
        }
        #endregion Model

    }
}

