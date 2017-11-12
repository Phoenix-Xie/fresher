using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// index 的摘要说明
/// </summary>
public class Index:System.Web.UI.Page
{
    public Index()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public void Home_page()
    {
        Response.Redirect("login_choose.aspx");
    }
    public void sign()
    {
        Response.Redirect("sign.aspx");
    }
    public void login()
    {
        Response.Redirect("login.aspx");
    }
    public void find_pwd()
    {
        Response.Redirect("find_pwd.aspx");
    }
    public void secret_login()
    {
        Response.Redirect("secret_login.aspx");
    }
    public void secret_user_arrangement()
    {
        Response.Redirect("secret_user_arrangement.aspx");
    }
    public void secret_book_arrangement()
    {
        Response.Redirect("secret_book_arrangement.aspx");
    }
}