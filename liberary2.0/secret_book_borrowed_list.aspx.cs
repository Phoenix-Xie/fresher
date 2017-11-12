using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class secret_book_borrowed_list : System.Web.UI.Page
{
    book Book = new book();
    Sql sql = new Sql();
    string secretname;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Test_secretname();
            if (!IsPostBack)
            {
                DataBlindToRepeater(1);
                string status = DataBlindToRepeater(1);
                if (status != null)
                {
                    Response.Write("<script>alert('" + status + "');location = login_choose.apsx</script>");
                }
                index_now.Text = "1";
            }
        }
        catch
        {
            Response.Write("<script>alert('请在相应页面输入正确信息，即将跳转')；location = 'login_choose'</script>");
        }
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

    string DataBlindToRepeater(int page)
    {
        try
        {
            DataTable dt = new DataTable();
            string sqlstr = "select * from books where status = N'已借出'";
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

    protected void borrowlist_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string sqlstr = "select status from books where id =" + e.CommandArgument + "";
        string status = sql.Sql_get_Datatable(sqlstr).Rows[0][0].ToString();
        if (e.CommandName == "delete")
        {
            if (status == "已借出")
            {
                Response.Write("<script>alert('该书已被借出')</script>");
            }
            else
            {
                sqlstr = "select book_name from books where id =" + e.CommandArgument;
                string bookname = sql.Sql_get_Datatable(sqlstr).Rows[0][0].ToString();
                sqlstr = "delete from books where id = " + e.CommandArgument;
                sql.Sql_deal_with(sqlstr);
                Response.Write("<script>alert('成功删除" + bookname + "')</script>");
            }
        }
        else
        {
            if (status == "已借出")
            {
                sqlstr = "update books set status = N'未借出' where id = " + e.CommandArgument + "";
                sql.Sql_deal_with(sqlstr);
                sqlstr = "select book_name from books where id = " + e.CommandArgument + "";
                DataTable dt = sql.Sql_get_Datatable(sqlstr);
                sqlstr = "delete from user_book_relation where book_name_borrow = N'" + dt.Rows[0][0].ToString() + "'";
                sql.Sql_deal_with(sqlstr);
                Response.Redirect("secret_book_borrowed_list.aspx");
            }
            else
            {
                Response.Write("<script>alert('该书未被借出')</script>");
            }
        }

    }

    //上一页与下一页
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