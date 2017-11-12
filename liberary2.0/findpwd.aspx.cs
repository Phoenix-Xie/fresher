using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class findpwd : System.Web.UI.Page
{
    string username;
    User usr = new User();
    //加载函数为空
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    //按钮
    //显示问题
    protected void Find_pwd_question_visiable_button_Click(object sender, EventArgs e)
    {
        int index = usr.Test_Existence(Find_pwd_UsrName.Text);
        if (index == -1)
        {
            Response.Write("<script>alert('用户名错误')</script>");
        }
        else
        {
            Find_pwd_question.Text = usr.Get_Question(Find_pwd_UsrName.Text);
        }

    }
    //验证正确 及 找回密码
    protected void Find_pwd_Submit_Click(object sender, EventArgs e) //完成，未调试
    {
        string pwd;
        int index = usr.Test_Existence(Find_pwd_UsrName.Text);
        if (index == -1)
        {
            Response.Write("<script>alert('用户名错误')</script>");
        }
        else
        {
            if (usr.Test_Imformation(Find_pwd_UsrName.Text,"userAnswer", Find_pwd_answer.Text) == 1)
            {
                pwd = usr.FindPwd(Find_pwd_UsrName.Text);
                Response.Write("<script>alert('密码：" + pwd + "');location = 'login.aspx'</script>");

            }
            else
            {
                Response.Write("<script>alert('答案错误')</script>");
            }

        }
    }
}