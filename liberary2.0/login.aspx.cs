using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
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

    protected void Login_button_Click(object sender, EventArgs e)
    {
        try
        {

            if (Login_UsrName.Text == "")
            {
                Response.Write("<script>alert('用户名不能为空')</script>");
            }
            else if (Login_UsrPwd.Text == "")
            {
                Response.Write("<script>alert('密码不能为空')</script>");
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
                else
                {
                    int judgement = usr.Test_Imformation(Login_UsrName.Text, "userPwd", safe.Encrypt(Login_UsrPwd.Text));
                    if (judgement == -1)
                    {
                        Response.Write("<script>alert('账户不存在')</script>");
                    }
                    else if (judgement == 0)
                    {
                        Response.Write("<script>alert('账户或密码错误')</script>");
                    }
                    else
                    {
                        Session["username"] = Login_UsrName.Text.ToString();
                        Response.Write("<script>alert('成功登入，欢迎回来！');location = 'login_choose.aspx'</script>");
                    }
                }
            }
        }
        catch
        {
            Response.Write("<script>alert('请勿输入非法字符！')</script>");
        }
    }
}