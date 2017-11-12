using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login_choose : System.Web.UI.Page
{
    //页面加载验证登录情况
    string username;
    protected void Page_Load(object sender, EventArgs e)
    {   
        Test_username();
        //try
        //{
        //    
        //    username = Session["username"].ToString();
        //    Response.Write("<script>alert('" + username +"')");
        //    if (username == null)
        //    {
        //        Response.Write("<script>alert('请先登入');location = 'login.aspx'</script>");
        //    }
        //    else
        //    {
        //        Response.Write("<script>alert('成功登入，欢迎回来！')");
        //    }            
        //}
        //catch (Exception)
        //{
        //    Response.Write("<script>alert('有问题')");
        //}
    }
    protected void Test_username() //将该操作封装
    {
        try
        {
            username = Session["username"].ToString();
            if (username == null)   //检测是否为null
            {
                Response.Write("<script>alert('请先登入');location = 'login.aspx'</script>");
            }
        }
        catch    //弹窗并跳转至登入页面
        {
            Response.Write("<script>alert('请先登入');location = 'login.aspx'</script>");
        }
    }

    //按钮
    protected void Login_Exit_Click(object sender, EventArgs e)
    {
        Session["username"] = null;
        Response.Write("<script>alert('注销成功');location = 'login.aspx'</script>");
    }
    protected void Choose_Change_Click(object sender, EventArgs e)
    {
        Response.Redirect("change_pwd.aspx");
    }
    protected void Choose_Change_question_Click(object sender, EventArgs e)
    {
        Response.Redirect("change_question.aspx");
    }
    protected void search_Click(object sender, EventArgs e)
    { 
        Session["item"] = item.Text.ToString();
        Session["imformation"] = imformation.Text.ToString();
        Response.Redirect("book_list.aspx");        
    }

    protected void borrowed_book_Click(object sender, EventArgs e)
    {
        Response.Redirect("book_list_borrowed.aspx");
    }
}