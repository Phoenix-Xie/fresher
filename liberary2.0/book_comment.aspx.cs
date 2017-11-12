using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class book_comment : System.Web.UI.Page
{
    string username;
    Sql sql = new Sql();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Test_username();
            //在标签页上附加信息
            DataTable dt = new DataTable();
            string sqlstr = "select * from books where id =" + Session["bookid"];
            dt = sql.Sql_get_Datatable(sqlstr);
            book_name.Text = dt.Rows[0][1].ToString();
            book_author_name.Text = dt.Rows[0][2].ToString();
            book_class.Text = dt.Rows[0][3].ToString();
            
            //绑定信息
            string status = DataBlindToRepeater(1);
            if (status != null)
            {
                Response.Write("<script>alert('" + status + "');location = secret_arrangement.apsx</script>");
            }
            index_now.Text = "1";
        }
        
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
    string DataBlindToRepeater(int page)
    {
        try
        {
            DataTable dt = new DataTable();
            string sqlstr = "select book_name from books where id = " + Session["bookid"];
            dt = sql.Sql_get_Datatable(sqlstr);
            sqlstr = "select * from comments where book_name = N'" + dt.Rows[0][0] + "'";
            dt = sql.Sql_get_Datatable(sqlstr);


            PagedDataSource pds = new PagedDataSource();

            pds.AllowPaging = true;
            pds.PageSize = 3;
            pds.DataSource = dt.DefaultView;

            index_all.Text = pds.PageCount.ToString();


            pds.CurrentPageIndex = page - 1;
            borrowlist.DataSource = pds;
            borrowlist.DataBind();
            return null;
        }
        catch
        {
            return "数据库连接失败";
        }

    }

    //翻页操作
    protected void former_page_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(index_now.Text.ToString()) - 1 <= 0)
        {
            Response.Write("<script>alert('已经到了首页')</script>");
        }
        else
        {
            DataBlindToRepeater(Convert.ToInt32(index_now.Text.ToString()) - 1);
            index_now.Text = Convert.ToString(Convert.ToInt32(index_now.Text.ToString()) - 1);
        }
    }
    protected void next_page_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(index_now.Text.ToString()) + 1 > Convert.ToInt32(index_all.Text))
        {
            Response.Write("<script>alert('已经到了末页')</script>");
        }
        else
        {
            DataBlindToRepeater(Convert.ToInt32(index_now.Text.ToString()) + 1);
            index_now.Text = Convert.ToString(Convert.ToInt32(index_now.Text.ToString()) + 1);
        }
    }

    protected void borrowlist_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void return_list_Click(object sender, EventArgs e)
    {
        Response.Redirect("book_list_borrowed.aspx");
    }
}