using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// secret 的摘要说明
/// </summary>
public class Secret
{
    Safe safe = new Safe();
    Sql sqlclass = new Sql(table_get: "secret");
    string secretkey = "12345";
    public Secret()
    {
        
    }

    /// <summary>
    /// 返回1则用户名存在且密码正确，返回0用户存在密码错误，-1不存在
    /// </summary>
    public int Test_Existence(string name, string pwd)
    {
        DataTable dt = new DataTable();
        dt = sqlclass.Sql_get(item1: "secretName", item2:"secretPwd", name: name);
        if (dt.Rows.Count == 0)
        {
            return -1;
        }
        else
        {
            if(safe.Decrypt(dt.Rows[0][1].ToString()) == pwd)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }  

    /// <summary>
    /// 正确增加返回1，否则返回-1
    /// </summary>
    public int Add_secret(string name, string pwd, string keypwd)
    {
        if (keypwd == secretkey)
        {
            name = safe.Relace_special_characters(name);
            pwd = safe.Relace_special_characters(pwd);
            string sqlstring = "insert into secret values(N'" + name + "',N'" + safe.Encrypt(pwd) + "')";
            sqlclass.Sql_deal_with(sqlstring);
            return 1;
        }
        else
            return -1;
    }

    public int Delete_secret(string name, string keypwd)
    {
        if (keypwd == secretkey)
        {
            string sqlstring = "delete from secret where secretName = N'" + name + "'";
            sqlclass.Sql_deal_with(sqlstring);
            return 1;
        }
        else
        {
            return -1;
        }
    }

    public string Find_Pwd(string name)
    {
        name = safe.Relace_special_characters(name);
        return sqlclass.Sql_get(item1: "secretPwd", name: name).Rows[0][0].ToString();
    }


}