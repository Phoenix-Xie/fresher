using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class secret_book_arrangement : System.Web.UI.Page
{
    string  secretname;
    protected void Page_Load(object sender, EventArgs e)
    {
        Test_secretname();
    }
    //验证登入
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

    protected void book_search_Click(object sender, EventArgs e)
    {
        Session["secretitem"] = item.Text.ToString();
        Session["secretimformation"] = imformation.Text.ToString();
        Response.Redirect("secret_book_list.aspx");          
    }

    protected void book_borrowed_search_Click(object sender, EventArgs e)
    {
        Response.Redirect("secret_book_borrowed_list.aspx");
    }
}