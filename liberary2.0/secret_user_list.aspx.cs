using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class secret_user_list : System.Web.UI.Page
{
    Secret secret = new Secret();
    User usr = new User();
    Sql sql = new Sql();
    DataTable dt;
    string imformation, imformation_type, sqlstr;
    //验证登入
    string secretname, username;
    protected void Page_Load(object sender, EventArgs e)
    {
        Test_secretname();
        try
        {
            imformation = Session["secret_userimformation"].ToString();
            imformation_type = Session["secret_imformationtype"].ToString();
        }
        catch
        {
            Response.Write("<script>alert('未输入相关信息');location='secret_user_arrangement.aspx'</script>");
        }
        sqlstr = "select userName,userCollege from users where " + imformation_type + " like N'%" + imformation + "%'";
        dt = sql.Sql_get_Datatable(sqlstr);
        string error = DataBlindToUserlist(1, dt);
        if (error != null)
        {
            Response.Write("<script>alert('" + error + "');location='secret_arrangement.aspx'</script>");
        }
        user_index_now.Text = "1";
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

    string DataBlindToUserlist(int page, DataTable dt)
    {
        try
        {
            PagedDataSource pds = new PagedDataSource();

            pds.AllowPaging = true;
            pds.PageSize = 3;
            pds.DataSource = dt.DefaultView;

            user_index_all.Text = pds.PageCount.ToString();

            pds.CurrentPageIndex = page - 1;
            userlist.DataSource = pds;
            userlist.DataBind();
            return null;
        }
        catch
        {
            return "数据库连接失败";
        }
    }

    protected void user_former_page_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(user_index_now.Text.ToString()) - 1 <= 0)
        {
            Response.Write("<script>alert('已经到了首页')</script>");
        }
        else
        {
            DataBlindToBorrowlist(Convert.ToInt32(user_index_now.Text.ToString()) - 1, dt);
            index_now.Text = Convert.ToString(Convert.ToInt32(user_index_now.Text.ToString()) - 1);
        }
    }
    protected void user_next_page_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(user_index_now.Text.ToString()) + 1 > Convert.ToInt32(user_index_all.Text))
        {
            Response.Write("<script>alert('已经到了末页')</script>");
        }
        else
        {
            DataBlindToBorrowlist(Convert.ToInt32(user_index_now.Text.ToString()) + 1, dt);
            index_now.Text = Convert.ToString(Convert.ToInt32(user_index_now.Text.ToString()) + 1);
        }
    }

    string DataBlindToBorrowlist(int page, DataTable dt)
    {
        try
        {
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
        string sqlstr = "select status from books where book_name = N'" + e.CommandArgument + "'";
        string status = sql.Sql_get_Datatable(sqlstr).Rows[0][0].ToString();
        if (e.CommandName == "delete")
        {
            if (status == "已借出")
            {
                Response.Write("<script>alert('该书已被借出')</script>");
            }
            else
            {
                sqlstr = "delete from books where book_name = N'" + e.CommandArgument + "'";
                sql.Sql_deal_with(sqlstr);
                Response.Write("<script>alert('成功删除" + e.CommandArgument + "')</script>");
            }
        }
        else
        {
            if (status == "已借出")
            {
                sqlstr = "update books set status = N'未借出' where book_name = N'" + e.CommandArgument + "'";
                sql.Sql_deal_with(sqlstr);
                sqlstr = "delete from user_book_relation where book_name_borrow = N'" + e.CommandArgument + "'";
                sql.Sql_deal_with(sqlstr);
                //Response.Redirect("secret_user_list.aspx");
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
            DataBlindToBorrowlist(Convert.ToInt32(index_now.Text.ToString()) - 1, dt);
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
            DataBlindToBorrowlist(Convert.ToInt32(index_now.Text.ToString()) + 1, dt);
            index_now.Text = Convert.ToString(Convert.ToInt32(index_now.Text.ToString()) + 1);
        }
    }

    protected void userlist_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            string name = e.CommandArgument.ToString();
            if (usr.Test_Existence(name) == 1)
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
                    DataBlindToBorrowlist(1, dt);
                    index_now.Text = "1";
                    borrowlist.Visible = true;
                    index_all.Visible = true;
                    index_now.Visible = true;
                }
            }
        }
    }
}