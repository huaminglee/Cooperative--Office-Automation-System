﻿/*
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
using System.Web;
using System.Text;

namespace JumbotOA.Utils
{
    /// <summary>
    /// Session操作类
    /// </summary>
    public static class Session
    {
        /// <summary>
        /// 添加Session，调动有效期为20分钟
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <param name="strValue">Session值</param>
        public static void Add(string strSessionName, string strValue)
        {
            HttpContext.Current.Session[strSessionName] = strValue;
            HttpContext.Current.Session.Timeout = 20;
        }
        /// <summary>
        /// 添加Session，调动有效期为20分钟
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <param name="strValues">Session值数组</param>
        public static void Adds(string strSessionName, string[] strValues)
        {
            HttpContext.Current.Session[strSessionName] = strValues;
            HttpContext.Current.Session.Timeout = 20;
        }
        /// <summary>
        /// 添加Session
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <param name="strValue">Session值</param>
        /// <param name="iExpires">调动有效期（分钟）</param>
        public static void Add(string strSessionName, string strValue, int iExpires)
        {
            HttpContext.Current.Session[strSessionName] = strValue;
            HttpContext.Current.Session.Timeout = iExpires;
        }
        /// <summary>
        /// 添加Session
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <param name="strValues">Session值数组</param>
        /// <param name="iExpires">调动有效期（分钟）</param>
        public static void Adds(string strSessionName, string[] strValues, int iExpires)
        {
            HttpContext.Current.Session[strSessionName] = strValues;
            HttpContext.Current.Session.Timeout = iExpires;
        }
        /// <summary>
        /// 读取某个Session对象值
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <returns>Session对象值</returns>
        public static string Get(string strSessionName)
        {
            if (HttpContext.Current.Session[strSessionName] == null)
            {
                return null;
            }
            else
            {
                return HttpContext.Current.Session[strSessionName].ToString();
            }
        }
        /// <summary>
        /// 读取某个Session对象值数组
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <returns>Session对象值数组</returns>
        public static string[] Gets(string strSessionName)
        {
            if (HttpContext.Current.Session[strSessionName] == null)
            {
                return null;
            }
            else
            {
                return (string[])HttpContext.Current.Session[strSessionName];
            }
        }
        /// <summary>
        /// 删除某个Session对象
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        public static void Del(string strSessionName)
        {
            HttpContext.Current.Session[strSessionName] = null;
        }
    }
}
