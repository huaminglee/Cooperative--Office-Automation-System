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
using System.Text.RegularExpressions;
namespace JumbotOA.Utils
{
    /// <summary>
    /// 提供经常需要使用的一些验证逻辑。
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// 检查一个字符串是否可以转化为日期，一般用于验证用户输入日期的合法性。
        /// </summary>
        /// <param name="_value">需验证的字符串。</param>
        /// <returns>是否可以转化为日期的bool值。</returns>
        public static bool IsStringDate(string _value)
        {
            DateTime dTime;
            try
            {
                dTime = DateTime.Parse(_value);
            }
            catch (FormatException)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 检查一个字符串是否是纯数字构成的，一般用于查询字符串参数的有效性验证。
        /// </summary>
        /// <param name="_value">需验证的字符串。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool IsNumeric(string _value)
        {
            return Validator.QuickValidate("^[1-9]*[0-9]*$", _value);
        }

        /// <summary>
        /// 检查一个字符串是否是纯字母和数字构成的，一般用于查询字符串参数的有效性验证。
        /// </summary>
        /// <param name="_value">需验证的字符串。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool IsLetterOrNumber(string _value)
        {
            return Validator.QuickValidate("^[a-zA-Z0-9_]*$", _value);
        }

        /// <summary>
        /// 判断是否是数字，包括小数和整数。
        /// </summary>
        /// <param name="_value">需验证的字符串。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool IsNumber(string _value)
        {
            return Validator.QuickValidate("^(0|([1-9]+[0-9]*))(.[0-9]+)?$", _value);
        }

        /// <summary>
        /// 快速验证一个字符串是否符合指定的正则表达式。
        /// </summary>
        /// <param name="_express">正则表达式的内容。</param>
        /// <param name="_value">需验证的字符串。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool QuickValidate(string _express, string _value)
        {
            System.Text.RegularExpressions.Regex myRegex = new System.Text.RegularExpressions.Regex(_express);
            if (_value.Length == 0)
            {
                return false;
            }
            return myRegex.IsMatch(_value);
        }
        /// <summary>
        /// 判断一个字符串是否为邮件
        /// </summary>
        /// <param name="_value"></param>
        /// <returns></returns>
        public static bool IsEmail(string _value)
        {
            Regex regex = new Regex(@"^\w+([-+.]\w+)*@(\w+([-.]\w+)*\.)+([a-zA-Z]+)+$", RegexOptions.IgnoreCase);
            return regex.Match(_value).Success;
        }
        /// <summary>
        /// 判断一个字符串是否为ID格式
        /// </summary>
        /// <param name="_value"></param>
        /// <returns></returns>
        public static bool IsIDCard(string _value)
        {
            Regex regex;
            string[] strArray;
            DateTime time;
            if ((_value.Length != 15) && (_value.Length != 0x12))
            {
                return false;
            }
            if (_value.Length == 15)
            {
                regex = new Regex(@"^(\d{6})(\d{2})(\d{2})(\d{2})(\d{3})$");
                if (!regex.Match(_value).Success)
                {
                    return false;
                }
                strArray = regex.Split(_value);
                try
                {
                    time = new DateTime(int.Parse("19" + strArray[2]), int.Parse(strArray[3]), int.Parse(strArray[4]));
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            regex = new Regex(@"^(\d{6})(\d{4})(\d{2})(\d{2})(\d{3})([0-9Xx])$");
            if (!regex.Match(_value).Success)
            {
                return false;
            }
            strArray = regex.Split(_value);
            try
            {
                time = new DateTime(int.Parse(strArray[2]), int.Parse(strArray[3]), int.Parse(strArray[4]));
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 判断一个字符串是否为Int
        /// </summary>
        /// <param name="_value"></param>
        /// <returns></returns>
        public static bool IsInt(string _value)
        {
            Regex regex = new Regex(@"^(-){0,1}\d+$");
            if (regex.Match(_value).Success)
            {
                if ((long.Parse(_value) > 0x7fffffffL) || (long.Parse(_value) < -2147483648L))
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public static bool IsLengthStr(string _value, int _begin, int _end)
        {
            int length = _value.Length;
            if ((length < _begin) && (length > _end))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 判断一个字符串是否为手机号码
        /// </summary>
        /// <param name="_value"></param>
        /// <returns></returns>
        public static bool IsMobileNum(string _value)
        {
            Regex regex = new Regex(@"^(13|15)\d{9}$", RegexOptions.IgnoreCase);
            return regex.Match(_value).Success;
        }
        /// <summary>
        /// 判断一个字符串是否为电话号码
        /// </summary>
        /// <param name="_value"></param>
        /// <returns></returns>
        public static bool IsPhoneNum(string _value)
        {
            Regex regex = new Regex(@"^(86)?(-)?(0\d{2,3})?(-)?(\d{7,8})(-)?(\d{3,5})?$", RegexOptions.IgnoreCase);
            return regex.Match(_value).Success;
        }
        /// <summary>
        /// 判断一个字符串是否为网址
        /// </summary>
        /// <param name="_value"></param>
        /// <returns></returns>
        public static bool IsUrl(string _value)
        {
            Regex regex = new Regex(@"(http://)?([\w-]+\.)*[\w-]+(/[\w- ./?%&=]*)?", RegexOptions.IgnoreCase);
            return regex.Match(_value).Success;
        }
        /// <summary>
        /// 判断一个字符串是否为IP地址
        /// </summary>
        /// <param name="_value"></param>
        /// <returns></returns>
        public static bool IsIP(string _value)
        {
            Regex regex = new Regex(@"^(((2[0-4]{1}[0-9]{1})|(25[0-5]{1}))|(1[0-9]{2})|([1-9]{1}[0-9]{1})|([0-9]{1})).(((2[0-4]{1}[0-9]{1})|(25[0-5]{1}))|(1[0-9]{2})|([1-9]{1}[0-9]{1})|([0-9]{1})).(((2[0-4]{1}[0-9]{1})|(25[0-5]{1}))|(1[0-9]{2})|([1-9]{1}[0-9]{1})|([0-9]{1})).(((2[0-4]{1}[0-9]{1})|(25[0-5]{1}))|(1[0-9]{2})|([1-9]{1}[0-9]{1})|([0-9]{1}))$", RegexOptions.IgnoreCase);
            return regex.Match(_value).Success;
        }
        /// <summary>
        /// 判断一个字符串是否为字母加数字
        /// Regex("[a-zA-Z0-9]?"
        /// </summary>
        /// <param name="_value"></param>
        /// <returns></returns>
        public static bool IsWordAndNum(string _value)
        {
            Regex regex = new Regex("[a-zA-Z0-9]?");
            return regex.Match(_value).Success;
        }
        /// <summary>
        /// 把字符串转成日期
        /// </summary>
        /// <param name="_value">字符串</param>
        /// <param name="_defaultValue">默认值</param>
        /// <returns></returns>
        public static DateTime StrToDate(string _value, DateTime _defaultValue)
        {
            if (IsStringDate(_value))
                return Convert.ToDateTime(_value);
            else
                return _defaultValue;
        }
        /// <summary>
        /// 日期比较
        /// </summary>
        /// <param name="today">距离某个日期</param>
        /// <param name="writeDate">输入日期</param>
        /// <param name="n">比较天数</param>
        /// <returns>大于天数返回true，小于返回false</returns>
        public static bool CompareDate(string today, string writeDate, int n)
        {
            DateTime Today = Convert.ToDateTime(today);
            DateTime WriteDate = Convert.ToDateTime(writeDate);
            WriteDate = WriteDate.AddDays(n);
            if (Today >= WriteDate)
                return false;
            else
                return true;
        }
        /// <summary>
        /// 判断日期是否过期
        /// </summary>
        /// <param name="myDate">所要判断的日期</param>
        public static bool ValidDate(string myDate)
        {
            if (!IsStringDate(myDate))
                return true;
            return CompareDate(myDate, DateTime.Now.ToShortDateString(), 0);
        }
        /// <summary>
        /// 把字符串转成整型
        /// </summary>
        /// <param name="_value">字符串</param>
        /// <param name="_defaultValue">默认值</param>
        /// <returns></returns>
        public static int StrToInt(string _value, int _defaultValue)
        {
            if (IsNumber(_value))
                return int.Parse(_value);
            else
                return _defaultValue;
        }
        /// <summary>
        /// 把字符串格式化成非空
        /// </summary>
        /// <param name="_value">字符串</param>
        /// <returns></returns>
        public static string IntStr(string _value)
        {
            if (IsNumber(_value))
                return _value.ToString();
            else
                return "0";
        }
    }
}
