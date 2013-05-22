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
namespace JumbotOA.Utils
{
    /// <summary>
    /// MD5加密
    /// </summary>
    public static class MD5
    {
        /// <summary>
        /// 32位大写
        /// </summary>
        /// <returns></returns>
        public static string Upper32(string s)
        {
            s = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(s, "md5").ToString();
            return s.ToUpper();
        }
        /// <summary>
        /// 32位小写
        /// </summary>
        /// <returns></returns>
        public static string Lower32(string s)
        {
            s = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(s, "md5").ToString();
            return s.ToLower();
        }
        /// <summary>
        /// 16位大写
        /// </summary>
        /// <returns></returns>
        public static string Upper16(string s)
        {
            s = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(s, "md5").ToString();
            return s.ToUpper().Substring(8, 16);
        }
        /// <summary>
        /// 16位小写
        /// </summary>
        /// <returns></returns>
        public static string Lower16(string s)
        {
            s = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(s, "md5").ToString();
            return s.ToLower().Substring(8, 16);
        }
    }
}
