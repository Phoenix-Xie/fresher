using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class secret_deletesecret : System.Web.UI.Page
{
    Secret secret = new Secret();
    //验证登入
    string secretname;
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

    protected void secret_delete_Click(object sender, EventArgs e)
    {
        if (secret.Test_Existence(secret_name.Text.ToString(),"") == 0)
        {
            int status = secret.Delete_secret(secret_name.Text.ToString(), secret_keypwd.Text.ToString());
            if(status == 1 )
            {
                Response.Write("<script>alert('删除成功');location = 'secret_arrangement.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('密匙错误')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('信息错误')</script>");
        }
    }

}