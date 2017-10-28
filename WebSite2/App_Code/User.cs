using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Class3 的摘要说明
/// </summary>
public class User
{



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
    protected string Sql_get(string sql, string database = "user", int line = 0, int column = 0)
    {
        string dateString = "";
        string ConnectionString = @"server=DESKTOP-8ROVJ5G;Integrated Security=SSPI;database=" + database;
        SqlConnection conn = new SqlConnection(ConnectionString);
        conn.Open();
        SqlCommand cmd = new SqlCommand(sql, conn);
        /*SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
             dateString = reader[0].ToString();
        }
        reader.Close();
        cmd.Dispose();
        conn.Close();
        return dateString;*/
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();
        conn.Dispose();
        return dt.Rows[line][column].ToString();
        dt.Dispose();

    }
    //根据sql语句获取表 返回表中相应行数和列数的内容，如不存在，返回null


    public User()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    Secret secret = new Secret();

    public int TestName(string name)
    {
        //select * from users where name = N'name'
        string sql = "select * from users where name = N'" + name + "'";

        if(Sql_get(sql) != "")
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }  //返回1则用户名存在，-1否则不存在

    public void Addusr(string name, string pwd, string question, string answer)
    {
        //insert into users values (N'',N'',N'',N'')
        string sql = "insert into users values (N'" + name + "',N'" + secret.Encrypt(pwd) + "',N'" + question + "',N'" + answer + "')";
        Sql_deal_with(sql);
    }

    public int VerifyPwd(string name, string pwd)  //返回值-1为用户名出错或密码出错，1为成功
    {
        //select * from users where name = N'' and password = ''
        string sql = "select * from users where name = N'" + name + "'and  password = '" + secret.Encrypt(pwd) + "'";

        if(Sql_get(sql) == "")
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

    public string FindPwd(string name)
    {
        string sql = "select * from users where name = N'" + name + "'";
        int i;
        i = TestName(name);
        if (i == -1)
        {
            return null;
        }
        else
        {
            return secret.Decrypt(Sql_get(sql));
        }

    }   //若存在用户，返回未解密密码，否则，返回null

    public int ChangePwd(string name, string pwd, string new_pwd) //用户名错误返回-1，密码错误返回0，成功返回1
    {   //由于修改密码必须在登录后，因而不存在找不到用户名的情况
        int i, index;
        i = VerifyPwd(name, pwd);
        //update users set password = '' where name = N''
        string sql = "update users set password = '" + new_pwd + "' where name = N'" + name + "'";

        if (i == 0)
        { return 0; }
        else
        {
            Sql_deal_with(sql);
            return 1;
        }
    }

    public void Change_key(string new_key)
    {
        secret.Change_key(new_key);
    }

    public void Delete_user(string name)
    {
        //delete from users where name = N''
        string sql = "delete from users where name = N'" + name + "'";
        Sql_deal_with(sql);
    }

    public void Addanswer(string name, string question, string answer)
    {
        //update users set question = '', answer = '' where name = N''
        string sql = "update users set question = '" + question + "',answer = '" + answer + "' where name = N'" + name + "'";
        Sql_deal_with(sql);
    }

    public string Getquestion(string name)
    {
        //select question from users where name = N''
        string sql = "select question from users where name = N'" + name + "'";
        
        return Sql_get(sql);
    }

    public string Getanswer(string name)
    {
        string sql = "select answer from users where name = N'" + name + "'";

        return Sql_get(sql);       
    }

    public bool Verigfyanswer(string name, string answer)
    {
        if (Getanswer(name) == answer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}