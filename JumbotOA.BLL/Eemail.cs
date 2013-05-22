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
using System.Data;
using System.IO;
namespace JumbotOA.BLL
{
  public static  class Eemail
    {

     public  static string GetFormatPop3(string email)
        {
            string aa = "";
            if(email!="")
            {
                string [] str=email.ToString().Split("@".ToCharArray());
                switch (str[1].ToString())
            {
                case "jumbotcms.net":
                    aa = "mail.jumbotcms.net";
                    break;
                case "sina.com":
                    aa = "pop.sina.com";
                    break;
                case "sina.cn":
                    aa = "pop.sina.cn";
                    break;
                case "163.com":
                    aa = "pop.163.com";
                    break;
                case "yeah.net":
                    aa = "pop.yeah.net";
                    break;
                case "qq.com":
                    aa = "pop.qq.com";
                    break;
                case "126.com":
                    aa = "pop.126.com";
                    break;
            }}
            return aa;

        }
   
    }
}
