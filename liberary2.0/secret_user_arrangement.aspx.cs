using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class secret_user_arrangement : System.Web.UI.Page
{
    Secret secret = new Secret();
    User usr = new User();
    Sql sql = new Sql();
    DataTable dt;
    string username;
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

    protected void Secret_usr_Arrangement_usrName_delete_Click(object sender, EventArgs e)
    {
        string name = imformation.Text.ToString();
        if (usr.Test_Existence(name)== 1)
        {
            
            string sqlstr = "select * from user_book_relation where user_name = N'" + name + "'";
            dt = sql.Sql_get_Datatable(sqlstr);
            if (dt.Rows.Count == 0)
            {
                usr.Delete_user(name);
                Response.Write("<script>alert('用户删除成功')</script>");
            }
            else
            {

                Response.Write("<script>alert('该用户还有以下书籍未归还')</script>");
                username = name;
                DataBlindToRepeater(1, dt);
                index_now.Text = "1";
                borrowlist.Visible = true;
                index_all.Visible = true;
                index_now.Visible = true;
            }
        }
        else
        {
            Response.Write("<script>alert('该用户不存在')</script>");
        }
    }

    string DataBlindToRepeater(int page, DataTable dt)
    {
        try
        {
            //DataTable dt = new DataTable();
            //items = Session["item"].ToString();
            //imformations = Session["imformation"].ToString();
            //dt = Book.Get_books(imformations, items);


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
                sqlstr = "select book_name from books where id =" + e.CommandArgument + "";
                string bookname = sql.Sql_get_Datatable(sqlstr).Rows[0][0].ToString();
                sqlstr = "delete from books where id = " + e.CommandArgument + "";
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
                Response.Redirect("secret_book_list.aspx");
            }
            else
            {
                Response.Write("<script>alert('该书未被借出')</script>");
            }
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
            DataBlindToRepeater(Convert.ToInt32(index_now.Text.ToString()) - 1, dt);
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
            DataBlindToRepeater(Convert.ToInt32(index_now.Text.ToString()) + 1, dt);
            index_now.Text = Convert.ToString(Convert.ToInt32(index_now.Text.ToString()) + 1);
        }
    }

    protected void search_Click(object sender, EventArgs e)
    {
        Session["secret_userimformation"] = imformation.Text;
        Session["secret_imformationtype"] = imformation_type.Text;
        Response.Redirect("secret_user_list.aspx");
    }
}