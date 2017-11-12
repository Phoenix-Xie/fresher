using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// 用户操作类
/// </summary>
public class User
{
    public User()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    Secret secret = new Secret();
    Safe safe = new Safe();
    Sql sqlclass = new Sql();

    /*对外功能区*/
    public void Add_usr(string name, string pwd, string question, string answer, string college)
    {
        
        name = safe.Relace_special_characters(name);
        pwd = safe.Encrypt(safe.Relace_special_characters(pwd));
        question = safe.Relace_special_characters(question);
        answer = safe.Relace_special_characters(answer);
        college = safe.Relace_special_characters(college);
        //insert into users values(N'',N'',N'',N'',N'',N'')
        string sql = "insert into users values(N'" + name + "', N'" + pwd + "', N'" + question + "', N'" + answer + "', N'" + college + "')";
        sqlclass.Sql_deal_with(sql);
    }

    /// <summary>
    /// 返回1则用户名存在，-1不存在
    /// </summary>
    public int Test_Existence(string name)
    {
        DataTable dt = new DataTable();
        dt =sqlclass.Sql_get(item1:"userName", name: name);
        if (dt.Rows.Count == 0)
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
        return safe.Decrypt(sqlclass.Sql_get(item1: "userPwd", name: name).Rows[0][0].ToString());
    }

    /// <summary>
    ///不存在返回-1，失败返回0，成功返回1，
    /// </summary>
    public int Test_Imformation(string name, string item, string imformation)
    {
        DataTable dt = new DataTable();
        dt = sqlclass.Sql_get(item1: item, name: name);
        if (dt.Rows.Count == 0)
        {
            return -1;
        }
        else
        {
            if(dt.Rows[0][0].ToString() == imformation)
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
    ///Answer为null则执行更换密码，输入Answer 则更换密保,成功返回0，不存在返回-1
    /// </summary>
    public int Change_Imformation(string name, string QuestionOrNewpwd = null, string Answer = null)
    {
        if (Test_Existence(name) == -1)
            return -1;
        if (Answer != null)//更新问题
        {
            sqlclass.Sql_updata("userQuestion", QuestionOrNewpwd, name);
            sqlclass.Sql_updata("userAnswer", Answer, name);
        }
        else
        {
            sqlclass.Sql_updata("userPwd", QuestionOrNewpwd, name);
        }
        return 0;
    }

    public string Get_Question(string name)
    {
        return sqlclass.Sql_get(item1: "userQuestion", name: name).Rows[0][0].ToString();
    }

    public void Delete_user(string name)
    {
        //delete from users where name = N''
        string sql = "delete from users where userName = N'" + name + "'";
        sqlclass.Sql_deal_with(sql);
    }
}