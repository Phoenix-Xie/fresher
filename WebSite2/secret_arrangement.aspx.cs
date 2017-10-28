using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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

    //管理员登入

    User usr = new User();
    Secret secret = new Secret();

    protected void Secret_login_button_Click(object sender, EventArgs e)
    {
        if (secret.Test_pwd(Secret_login_pwd.Text))
        {
            div_close_all();
            Secret_Arrangement.Visible = true;
        }
        else
        {
            Response.Write("<script> alert('非管理员身份不得进入')</script>");

        }
    }

    //管理员选择

    protected void Secret_Arrangement_Choose_userArrangement_Click(object sender, EventArgs e)
    {
        div_close_all();
        Secret_user_Arrangement.Visible = true;
    }

    protected void Secret_Arrangement_Choose_pwd_Click(object sender, EventArgs e)
    {
        div_close_all();
        Secret_change_pwd.Visible = true;
    }

    protected void Secret_Arrangement_Choose_key_Click(object sender, EventArgs e)
    {
        div_close_all();
        Secret_change_key.Visible = true;
    }

    static string secret_flag = "delete";
    static string secret_data = "", secret_data2 = ""; //变量，注意，若未设置静态会在函数切换时刷新
                                                       // 获取密匙
    protected void Secret_Arrangement_Choose_getkey_Click(object sender, EventArgs e)
    {
        secret_flag = "getkey";
        secret_data = Secret_change_pwd_oldpwd.Text;
        secret_data2 = Secret_change_pwd_newpwd.Text;
        div_close_all();
        Secret_Arrangement.Visible = true;
        Secret_makesure_pwd.Visible = true;
    }
    //更改密匙 跳转再次验证

    protected void Secret_change_Key_button_Click(object sender, EventArgs e)
    {
        secret_flag = "key";
        secret_data = New_Key.Text;
        div_close_all();
        Secret_Arrangement.Visible = true;
        Secret_makesure_pwd.Visible = true;

    } //完成

    protected void Secret_change_Key_Exit_Click(object sender, EventArgs e)
    {
        div_close_all();
        Secret_Arrangement.Visible = true;
    }

    //更改管理员密码

    protected void Secret_change_pwd_submit_Click(object sender, EventArgs e)
    {
        secret_flag = "pwd";
        secret_data = Secret_change_pwd_oldpwd.Text;
        secret_data2 = Secret_change_pwd_newpwd.Text;
        div_close_all();
        Secret_makesure_pwd.Visible = true;
        Secret_change_pwd.Visible = true;
    }

    protected void Secret_change_pwd_Exit_Click(object sender, EventArgs e)
    {
        div_close_all();
        Secret_Arrangement.Visible = true;
    }

    //用户组管理 两个按钮都会跳转到再次验证，并在那里实现功能

    protected void Secret_usr_Arrangement_usrName_delete_Click(object sender, EventArgs e)
    {
        secret_flag = "delete";
        secret_data = Secret_usr_Arrangement_usrName.Text;
        div_close_all();
        Secret_user_Arrangement.Visible = true;
        Secret_make_sure.Visible = true;
    }

    protected void Secret_usr_Arrangement_usrpwd_Click(object sender, EventArgs e)
    {
        secret_data = Secret_usr_Arrangement_usrName.Text;
        secret_flag = "usrpwd";
        div_close_all();
        Secret_user_Arrangement.Visible = true;
        Secret_make_sure.Visible = true;
    }

    protected void Secret_usr_Arrangement_Exit_Click(object sender, EventArgs e)
    {
        div_close_all();
        Secret_Arrangement.Visible = true;
    }

    //管理员再次验证
    protected void Secret_makesure_pwd_submit_Click(object sender, EventArgs e)
    {
        if (secret.Test_pwd(Secret_makesure_pwd.Text))
        {

            if (secret_flag == "delete")   //删除用户
            {
                if (usr.TestName(secret_data) == -1)
                {
                    Response.Write("<script>alert('用户名不存在')</script>");
                }
                else
                {
                    Secret_make_sure_delete.Visible = true;
                    Secret_make_sure_delete_button.Text = "确定删除" + secret_data + "吗？";
                    div_close_all();
                    Secret_Arrangement.Visible = true;
                    Secret_make_sure_delete.Visible = true;
                }
            }
            else if (secret_flag == "usrpwd")   //获得用户密码
            {
                if (usr.TestName(secret_data) == -1)
                {
                    Response.Write("<script>alert('用户名不存在')</script>");
                }
                else
                {
                    Response.Write("<script>alert('用户" + secret_data + "密码为" + secret.Decrypt(usr.FindPwd(secret_data)) + "')</script>");
                    div_close_all();
                    Secret_Arrangement.Visible = true;

                }
            }
            else if (secret_flag == "key")  //更改密匙
            {
                div_close_all();
                Secret_Arrangement.Visible = true;
                Secret_make_sure_change_key.Visible = true;
            }
            else if (secret_flag == "pwd")
            {
                if (secret.Test_pwd(secret_data))
                {
                    secret.Change_pwd(secret_data2);
                    Response.Write("<script>alert('密码修改成功')</script>");
                    div_close_all();
                    Secret_Arrangement.Visible = true;

                }
                else
                {
                    Response.Write("<script>alert('密码错误')</script>");
                    div_close_all();
                    Secret_Arrangement.Visible = true;
                }
            }
            else if (secret_flag == "getkey")
            {
                Response.Write("<script>alert('密匙为" + secret.Getkey() + "')</script>");
            }
        }
        else
        {
            Response.Write("<script> alert('非管理员身份不得操作！！')</script>");
            div_close_all();
            Secret_Arrangement.Visible = true;

        }
    }

    protected void Secret_make_sure_delete_button_Click(object sender, EventArgs e)
    {
        usr.Delete_user(secret_data);

        div_close_all();
        Secret_Arrangement.Visible = true;

        Response.Write("<script>alert('" + secret_data + "已被删除')</script>");

        Secret_make_sure_delete.Visible = false;
    }

    protected void Secret_make_sure_delete_Exit_Click(object sender, EventArgs e)
    {
        div_close_all();
        Secret_Arrangement.Visible = true;
    }

    protected void Secret_make_sure_change_key_button_Click(object sender, EventArgs e)
    {
        div_close_all();

        Secret_user_Arrangement.Visible = false;
        Response.Write("<script>alert('密匙修改成功')</script>");
        Secret_make_sure_change_key.Visible = false;

    }

    protected void Secret_make_sure_change_key_Exit_Click(object sender, EventArgs e)
    {
        div_close_all();
        Secret_Arrangement.Visible = true;
    }

    protected void div_close_all()
    {
        //管理员用户
        Secret_login.Visible = false;
        Secret_Arrangement.Visible = false;
        Secret_user_Arrangement.Visible = false;
        Secret_change_key.Visible = false;
        Secret_change_pwd.Visible = false;
        Secret_make_sure.Visible = false;
        //管理员确定
        Secret_make_sure_delete.Visible = false;
        Secret_make_sure_change_key.Visible = false;
    }
}