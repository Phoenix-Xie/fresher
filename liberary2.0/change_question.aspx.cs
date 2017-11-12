using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class change_question : System.Web.UI.Page
{
    string username;
    User usr = new User();

    protected void Page_Load(object sender, EventArgs e)
    {
        Test_username();
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
    //注销
    protected void Login_Exit_Click(object sender, EventArgs e)
    {
        Session["username"] = null;
        Response.Write("<script>alert('注销成功');location = 'login.aspx'</script>");
    }

    //功能
    protected void Change_question_sumbit_Click(object sender, EventArgs e)
    {
        if (Change_question_question_self.Text == "")
        {
            Change_questions(username, Change_question_question.Text.ToString(), Change_question_answer.Text.ToString());
        }
        else
        {
            Change_questions(username, Change_question_question_self.Text.ToString(), Change_question_answer.Text.ToString());
        }

    }

    protected void Change_questions(string name, string question, string answer)
    {
        usr.Change_Imformation(name, question, answer);
        Response.Write("<script>alert('修改成功');location = 'login_choose.aspx'</script>");
    }


}