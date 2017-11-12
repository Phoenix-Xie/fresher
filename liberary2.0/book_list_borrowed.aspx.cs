using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class book_list_borrowed : System.Web.UI.Page
{
    book Book = new book();
    Sql sql = new Sql();
    string username, sqlstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        Test_username();
        if (!IsPostBack)
        {
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

    protected void borrowlist_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        
        if (e.CommandName == "comment")
        {
            Session["bookid"] = e.CommandArgument;
            Response.Redirect("book_comment.aspx");
        }
        else
        {
            Session["bookid"] = e.CommandArgument;
            Response.Redirect("book_add_comment.aspx");
        }
    }

    protected void Login_Exit_Click(object sender, EventArgs e)
    {
        Session["username"] = null;
        Response.Write("<script>alert('注销成功');location = 'login.aspx'</script>");
    }

    //数据连接与绑定
    string DataBlindToRepeater(int page)
    {
        try
        {
            DataTable dt = new DataTable();
            sqlstr = "select book_name_borrow from user_book_relation where user_name = N'" + username + "'";
            dt = sql.Sql_get_Datatable(sqlstr);
            sqlstr = "select books.book_name from books,user_book_relation where user_book_relation.user_name = N'" + username + "' and user_book_relation.book_name_borrow = books.book_name";
            //选取所有名字为username所借的书
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
}