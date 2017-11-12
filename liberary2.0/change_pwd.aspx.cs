using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    Safe safe = new Safe();
    User usr = new User();
    string username = "123";
    protected void Page_Load(object sender, EventArgs e)
    {
        Test_username();
    }
    protected void Test_username()
    {
        try
        {
            username = Session["username"].ToString();
            if (username == null)
            {
                Response.Write("<script>alert('请先登入');location = 'login.aspx'</script>");
            }
        }
        catch
        {
            Response.Write("<script>alert('请先登入');location = 'login.aspx'</script>");
        }
    }
    
    //注销
    protected void Login_Exit_Click(object sender, EventArgs e)
    {
        Session["username"] = null;
        Response.Write("<script>alert('注销成功');location = 'sign.aspx'</script>");
    }
    //更改密码
    protected void Change_pwd_submit_Click(object sender, EventArgs e)
    {
        int i;
        i = usr.Test_Imformation(username, "userPwd",safe.Encrypt(Change_pwd_now.Text.ToString()));
        if (i == 0)
        {
            Response.Write("<script>alert('密码错误')</script>");
        }
        else
        {
            string pwd_safe = safe.Test_pwd_safe(Change_pwd_next.Text.ToString(), Change_pwd_next_second.ToString());
            if (pwd_safe == null )
            {
                Response.Write("<script>alert('" + pwd_safe + "')</script>");
            }
            else
            {
                usr.Change_Imformation(username, safe.Encrypt(Change_pwd_next.Text.ToString()));
                Response.Write("<script>alert('成功！');location = 'login_choose.aspx'</script>");
            }
        }
    }//完成
}
