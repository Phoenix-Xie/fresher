using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class secret_arrangement : System.Web.UI.Page
{
    string secretname;
    //验证登入
    protected void Page_Load(object sender, EventArgs e)
    {
        Test_secretname();
    }
    protected void Test_secretname()
    {
        try
        {
            secretname = Session["secretname"].ToString();
            if (secretname == null)
            {
                Response.Write("<script>alert('非管理员不得入内');location = 'login.aspx'</script>");
            }
        }
        catch
        {
            Response.Write("<script>alert('非管理员不得入内');location = 'login.aspx'</script>");
        }
    }
    //注销
    protected void secret_Exit_Click(object sender, EventArgs e)
    {
        Session["secretname"] = null;
        Response.Write("<script>alert('注销成功');location = 'login.aspx'</script>");
    }
    //功能 各个位置跳转
    protected void secret_Choose_user_arrangement_Click(object sender, EventArgs e)
    {
        Response.Redirect("secret_user_arrangement.aspx");
    }

    protected void secret_Chooose_book_arrangement_Click(object sender, EventArgs e)
    {
        Response.Redirect("secret_book_arrangement.aspx");
    }

    protected void secret_Choose_addsecret_Click(object sender, EventArgs e)
    {
        Response.Redirect("secret_addsecret.aspx");
    }

    protected void secret_Choose_deletesecret_Click(object sender, EventArgs e)
    {
        Response.Redirect("secret_deletesecret.aspx");
    }



    protected void secret_Choose_change_secret_keypwd_Click(object sender, EventArgs e)
    {
        Response.Redirect("secret_change_keypwd.aspx");
    }
}