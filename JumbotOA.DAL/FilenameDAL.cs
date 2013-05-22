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
using System.Data.SqlClient;
using JumbotOA.DBUtility;
namespace JumbotOA.DAL
{
   public  class FilenameDAL
    {
       DBUtility.DbHelperSQLP sql = new DbHelperSQLP();
       public  DataTable Select(int uid,int i)
       {
           DataTable dt = sql.Query("select * from [OA_filepath] where uid=" + uid + " and isdelete="+i+" order by Id desc").Tables[0];
           return dt;
       }
     public  int Add(int uid,string names,string side)
       {
           return sql.ExecuteSql("insert into [OA_filepath](names,uid,side)values('" + names + "'," + uid + ",'"+side+"')");
       }
     public int Del(int uid, int Id)
       {
           return sql.ExecuteSql("delete from [OA_filepath] where uid="+uid+" and id="+Id+"");

       }
     public int Up(int uid,int i)
     {
         return sql.ExecuteSql("update [OA_filepath] set isdelete=" + i + " where uid=" + uid + " and isdelete=0");

     }


    }
}
