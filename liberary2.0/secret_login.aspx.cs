using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class secret_login : System.Web.UI.Page
{
    Secret secret = new Secret();
    protected void Page_Load(object sender, EventArgs e)
    {
        ibtn_yzm.ImageUrl = "ImageCode.aspx";
    }
    //导航

    protected void Secret_login_button_Click(object sender, EventArgs e)
    {
        if (secret.Test_Existence(Secret_login_name.Text.ToString(),Secret_login_pwd.Text.ToString()) == 1)
        {
            Session["secretname"] = Secret_login_name.Text.ToString();
            Response.Write("<script> alert('登入成功');location = 'secret_arrangement.aspx'</script>");
        }
        else
        {
            Response.Write("<script> alert('非管理员身份不得进入')</script>");

        }
    }
}