using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

/// <summary>
/// secret 的摘要说明
/// </summary>
public class Secret
{
    public Secret()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    protected void Sql_deal_with(string sql, string database = "user")
    {
        string str = @"server=DESKTOP-8ROVJ5G;Integrated Security=SSPI;database=" + database;
        //Integrated Security 综合安全，集成安全
        SqlConnection conn = new SqlConnection(str); //初始化连接
        conn.Open();
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.ExecuteNonQuery(); //返回受影响的行数，如果是select，返回-1
        conn.Close();
    }// 输入相关的sql语句，对相应数据库进行操作

    protected string Sql_get(string sql, string database = "user")
    {
        string dateString = "";
        string ConnectionString = @"server=DESKTOP-8ROVJ5G;Integrated Security=SSPI;database=" + database;
        SqlConnection conn = new SqlConnection(ConnectionString);
        conn.Open();
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            dateString = reader[0].ToString();
        }
        reader.Close();
        cmd.Dispose();
        conn.Close();
        return dateString;
    }

    private static string key = "0";
    private static string secret_pwd = "12345";
    public bool Test_pwd(string pwd)
    {
        if (pwd == secret_pwd)
        {
            return true;
        }
        else return false;
    }
    public void Change_pwd(string new_pwd)
    {
        secret_pwd = new_pwd;
    }
    public void Change_key(string new_key)
    {
        key = new_key;
    }
    public string Encrypt(string pwd, string key = "0")
    {
        List<string> keys = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        int counter = 0;
        if (key != "0")
        {
            foreach (char i in key)
            {
                keys[counter] = i.ToString();
                counter++;
            }
        }
        List<string> secret = new List<string> { "吹", "灭", "读", "书", "灯", "一", "身", "都", "是", "月" };
        for (int j = 0; j < 10; j++)
        {
            pwd = Regex.Replace(pwd, keys[j], secret[j]);
        }
        return pwd;
    } //加密字符后返回
    public string Decrypt(string pwd, string key = "0")
    {
        List<string> keys = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        int counter = 0;
        if (key != "0")
        {
            foreach (char i in key)
            {
                keys[counter] = i.ToString();
                counter++;
            }
        }
        List<string> secret = new List<string> { "吹", "灭", "读", "书", "灯", "一", "身", "都", "是", "月" };
        for (int j = 0; j < 10; j++)
        {
            pwd = Regex.Replace(pwd, secret[j], keys[j]);
        }

        return pwd;
    } //解密字符后返回
    public string Getkey()
    {
        return key;
    }
}