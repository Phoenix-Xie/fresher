using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class book_add_comment : System.Web.UI.Page
{
    string username, bookname, sqlstr;
    int status = 0;
    Sql sql = new Sql();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        Test_username();
        try
        {
            sqlstr = "select book_name from books where id =" + Session["bookid"];
            dt = sql.Sql_get_Datatable(sqlstr);
            bookname = dt.Rows[0][0].ToString();
                sqlstr = "select * from comments where book_name = N'" + bookname + "' and people_name = N'" + username + "'";
                dt = sql.Sql_get_Datatable(sqlstr);
                if (dt.Rows.Count != 0)
                {
                    comment.Text = dt.Rows[0][3].ToString();
                    status = 1;
                }

        }
        catch
        {
            Response.Write("<script>alert('数据库连接失败');location = 'login.aspx'</script>");
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

    protected void submit_Click(object sender, EventArgs e)
    {
        if (status == 0)
        {
            sqlstr = "insert into comments values (N'" + bookname + "',N'" + username + "',N'" + comment.Text.ToString() + "')";
            string error = sql.Sql_deal_with(sqlstr);
            if (error == null)
            {
                Response.Write("<script>alert('填写成功');location = 'book_comment.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('" + error + "');location = 'book_comment.aspx'</script>");
            }
        }
        else
        {
            sqlstr = "update comments set comment = N'" + comment.Text.ToString() + "' where people_name=N'" + username + "'";
            sql.Sql_deal_with(sqlstr);
            Response.Write("<script>alert('修改成功');location = 'bookcomment.aspx'</script>");
        }
    }

}