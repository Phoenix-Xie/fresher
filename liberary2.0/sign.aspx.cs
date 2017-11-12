using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    User usr = new User();
    Safe safe = new Safe();

    protected void Page_Load(object sender, EventArgs e)
    {
        ibtn_yzm.ImageUrl = "ImageCode.aspx";
    }
    protected void Page_Error(object sender, EventArgs e)
    {
        Exception ex = Server.GetLastError();
        if (ex is HttpRequestValidationException)
        {
            Response.Write("<script>请您输入合法字符串。</script>");
            Server.ClearError(); // 如果不ClearError()这个异常会继续传到Application_Error()。
        }
        else
        {
            Response.Write("<script>请勿乱来</script>");
            Server.ClearError();
        }
    }
    //功能区
    protected void Sign_submit_Click(object sender, EventArgs e)
    {
        string name_safe = safe.Test_name_safe(Sign_Usrname.Text.ToString());
        string pwd_safe = safe.Test_pwd_safe(Sign_pwd.Text.ToString(), Sign_pwd2.Text.ToString());
        if (name_safe != null)
        {
            Response.Write("<script>alert('"+ name_safe + "')</script>");
        }
        else if (usr.Test_Existence(Sign_Usrname.Text.ToString()) == 1)
        {
            Response.Write("<script>alert('已经有人抢先一步注册了这个名字')</script>");
        }
        else if(pwd_safe != null)
        {
            Response.Write("<script>alert('" + pwd_safe + "')</script>");
        }
        else if (Sign_security_answer.Text == "")
        {
            Response.Write("密保问题答案不能为空");
        }
        else if (Sign_college.Text.ToString() == "")
        {
            Response.Write("学院名称不能为空");
        }
        else
        {                    
            string code = tbx_yzm.Text;
            HttpCookie htco = Request.Cookies["ImageV"];
            string scode = htco.Value.ToString();
            if (code.ToLower() != scode.ToLower())
            {
                Response.Write("<script>alert('验证码输入不正确！')</script>");
            }
            //Response.Write(Sign_security_answer.Text);
            else
            {
                if (Sign_security_question_self.Text == "")//未设置自主密保问题
                {
                    usr.Add_usr(Sign_Usrname.Text, Sign_pwd.Text, Sign_security_question.Text, Sign_security_answer.Text, Sign_college.Text);
                }
                else
                {
                    usr.Add_usr(Sign_Usrname.Text, Sign_pwd.Text, Sign_security_question_self.Text, Sign_security_answer.Text, Sign_college.Text);
                }
                Response.Write("<script>alert('注册成功');location='login.aspx'</script>");
            }
        }
    }
}