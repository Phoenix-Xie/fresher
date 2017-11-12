using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// sql 的摘要说明 sql的处理，更新，删除，新增的操作类
/// </summary>
public class Sql
{ 
    Safe safe = new Safe();

    string database_global, table_global;

    /// <summary>
    /// sql的使用
    /// </summary>
    public Sql(string database_get = "Liberary", string table_get = "users")
    {
        database_global = database_get;
        table_global = table_get;
    }

    /*sql处理区域*/
    /// <summary>
    ///  输入相关的sql语句，对相应数据库进行操作,无错误返回null，错误返回"数据库连接失败"
    /// </summary>
    public string Sql_deal_with(string sql, string database = "Liberary")
    {
        /// 功能介绍
        database = database_global;
        string str = @"server=DESKTOP-8ROVJ5G;Integrated Security=SSPI;database=" + database;
        //Integrated Security 综合安全，集成安全
        try
        {
            SqlConnection conn = new SqlConnection(str); //初始化连接
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery(); //返回受影响的行数，如果是select，返回-1
            conn.Close();
            return null;
        }
        catch
        {
            return "数据库连接失败";
        }
    }//

    public DataTable Sql_get_Datatable(string sql, string database = "Liberary")
    {
        string str = @"server=DESKTOP-8ROVJ5G;Integrated Security=SSPI;database=" + database;
        //Integrated Security 综合安全，集成安全
        try
        {
            string ConnectionString = @"server=DESKTOP-8ROVJ5G;Integrated Security=SSPI;database=" + database;
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            conn.Dispose();
            return dt;
        }
        catch
        {
            return null;
        }
    }//成功获取返回DataTable 失败返回null

    /// <summary>
    /// updata 封装
    /// </summary>
    public void Sql_updata(string beforeitem, string afteritem, string name, string table = "user", string database = "Liberary")
    {
        //初始化
        table = table_global;
        database = database_global;

        beforeitem = safe.Relace_special_characters(beforeitem);
        afteritem = safe.Relace_special_characters(afteritem);
        name = safe.Relace_special_characters(name);
        string sql = "update " + table + " set " + beforeitem + " = '" + afteritem + "' where userName = N'" + name + "'";
        Sql_deal_with(sql, database);
    }

    /// <summary>
    /// 从name的位置取item
    /// </summary>
    public DataTable Sql_get(string sql = null, string item1 = null, string item2 = null, string name = null,string table = "users", string database = "Liberary")
    {
        //初始化
        table = table_global;
        database = database_global;
        string namelist;
        if(table == "secret")
        {
             namelist = "secretName";
        }
        else
        {
             namelist = "userName";
        }
        name = safe.Relace_special_characters(name);
        if (sql == null && item2 == null)
        {
            sql = "select " + item1 + " from " + table + " where " + namelist + " = N'" + name + "'";
        }
        else if (sql == null)
        {
            sql = "select " + item1 + "," + item2 + " from " + table + " where " + namelist + " = N'" + name + "'";
        }
        else { }


        return Sql_get_Datatable(sql);
    } //根据sql语句获取表 返回表


   
}