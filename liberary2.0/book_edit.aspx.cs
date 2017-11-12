using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class book_edit : System.Web.UI.Page
{
    string id, secretname;
    DataTable dt = new DataTable(); 
    Sql sql = new Sql();
    protected void Page_Load(object sender, EventArgs e)
    {
        Test_secretname();
        try
        {
            id = Request.QueryString["id"];
            string sqlstr = "select * from books where id =" + id;
            dt = sql.Sql_get_Datatable(sqlstr);
            if (!IsPostBack)
            {
                book_name.Text = dt.Rows[0][1].ToString();
                book_author_name.Text = dt.Rows[0][2].ToString();
                book_class.Text = dt.Rows[0][3].ToString();
            }
        }
        catch
        {
            Response.Write("<script>alert('数据库连接失败');location = 'login.aspx'</script>");
        }
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


    protected void edit_Click(object sender, EventArgs e)
    {
        string sqlstr = "update books set book_name = N'"+ book_name.Text + "'where id = "+id;
        sql.Sql_deal_with(sqlstr);
        sqlstr = "update books set book_author_name = N'" + book_author_name.Text + "' where id = "+id;
        sql.Sql_deal_with(sqlstr);
        sqlstr = "update books set book_class = N'" + book_class.Text + "'where id = " + id;
        sql.Sql_deal_with(sqlstr);
    }
}