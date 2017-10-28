using System; //系统时间等引用
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions; //正则表达式
using System.Drawing; //像素图片生成
using System.IO;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    //引用函数库

    static int login_time = 0;
    User usr = new User();
    Secret secret = new Secret();


    //choose 语段
    protected void Page_Load(object sender, EventArgs e)
    {
        login_time++;
        if(login_time % 20 == 0 )
        {

        }       
        //Secret_Arangement.Visible = false;
        //Context.Response.ClearContent();
    }// 清除缓存
    protected void Choose_Sign_Click(object sender, EventArgs e)
    {
        div_close_all();
        Sign.Visible = true;
    }//完成

    protected void Choose_Login_Click(object sender, EventArgs e)
    {
        div_close_all();
        Login.Visible = true;
    } //完成

    protected void Choose_Find_Click(object sender, EventArgs e)
    {
        div_close_all();
        Find_pwd.Visible = true;
    } //完成

    protected void Choose_secret_Click(object sender, EventArgs e)
    {
        Response.Write("<script>alert('欢迎回来，管理员先生');location='secret_arrangement.aspx'</script>");
    }

    protected void Choose_secret_change_picture_Click(object sender, EventArgs e)
    {
        Response.Write("<script>alert('这可是圣人惠，不能换')</script>");
    }

    //用户操作

    //注册
    protected void Sign_submit_Click(object sender, EventArgs e)
    {

        Regex number = new Regex("[0-9]");
        Regex Uppercharacter = new Regex("[A-Z]");
        Regex Lowercharacter = new Regex("[a-z]");
        Regex others = new Regex("[^0-9a-zA-Z]");
        Regex Chinese_character = new Regex("[\u4E00 - \uFA29]");//匹配汉字
        Regex space = new Regex("/s");
        if (Sign_Usrname.Text.Length > 15)
        {
            Response.Write("<Script>alert('用户名不得超过15位')</script>");
        }
        //else if(Sign_)
        else if (Sign_pwd.Text.Length > 15)
        {
            Response.Write("<Script>alert('密码不得超过15位')</script>");
        }
        else if (usr.TestName(Sign_Usrname.Text) == 1)
        {
            Response.Write("<Script>alert('已经有人抢先一步注册了这个名字')</script>");
        }
        else if (Sign_pwd.Text != Sign_pwd2.Text)
        {
            Response.Write("<script>alert('两次密码不相符！！！');</script>");
        }
        else if (Sign_pwd.Text == "")
        {
            Response.Write("<script>alert('密码不能为空');</script>");
        }
        else if (Sign_pwd.Text.Length < 5)
        {
            Response.Write("密码必须五位以上，但不超过15位");
        }
        else if (!(number.IsMatch(Sign_pwd.Text) && Uppercharacter.IsMatch(Sign_pwd.Text) && Lowercharacter.IsMatch(Sign_pwd.Text) && others.IsMatch(Sign_pwd.Text)))//如果没有出现大小写字母，数字，特殊字符需要更改
        {
            Response.Write("密码里必须有数字，大小写字母和特殊字符混合");
        }
        else if (space.IsMatch(Sign_pwd.Text))
        {
            Response.Write("密码中不允许有空格");
        }
        else if (Chinese_character.IsMatch(Sign_pwd.Text))
        {
            Response.Write("密码中不允许包含有汉字");
        }
        else if (Sign_security_answer.Text == "")
        {
            Response.Write("密保问题不能为空");
        }
        else
        {
            //Response.Write(Sign_security_answer.Text);
            if (Sign_security_question_self.Text == "")
            {
                usr.Addusr(Sign_Usrname.Text, Sign_pwd.Text, Sign_security_question.Text, Sign_security_answer.Text);
            }
            else
            {
                usr.Addusr(Sign_Usrname.Text, Sign_pwd.Text, Sign_security_question_self.Text, Sign_security_answer.Text);
            }
            Response.Write("<script>alert('注册成功');</script>");
            //进入登入界面
            div_close_all();
            Login.Visible = true;

        }
    } //完成
    //登录
    static string usrName;
    protected void Login_button_Click(object sender, EventArgs e)
    {
        if(Login_UsrName.Text == "")
        {
            Response.Write("<script>alert('用户名不能为空')</script>");
        }
        else if(Login_UsrPwd.Text == "")
        {
            Response.Write("<script>alert('密码不能为空')</script>");
        }
        else
        {
            int judgement = usr.VerifyPwd(Login_UsrName.Text, Login_UsrPwd.Text);
            if (judgement == -1)
            {
                Response.Write("<script>alert('账户或密码出错')</script>");
            }
            else if (judgement == 0)
            {
                Response.Write("<script>alert('账户或密码出错')</script>");
            }
            else
            {
                Response.Write("<script>alert('成功登入，欢迎回来！')</script>");
                usrName = Login_UsrName.Text;
                div_close_all();
                Login_Choose.Visible = true;
            }
        }
    } //完成
      //登入后的操作
    protected void Choose_Change_Click(object sender, EventArgs e)
    {
        div_close_all();
        Login_Choose.Visible = true;
        Change_pwd.Visible = true;
    } //完成

    protected void Find_pwd_question_visiable_button_Click(object sender, EventArgs e)
    {
        int index = usr.TestName(Find_pwd_UsrName.Text);
        if (index == -1)
        {
            Response.Write("<script>alert('用户名错误')</script>");
        }
        else
        {
            Find_pwd_question.Text = usr.Getquestion(Find_pwd_UsrName.Text);
        }
        
    }

    protected void Find_pwd_Submit_Click(object sender, EventArgs e) //完成，未调试
    {
        string pwd;
        int index = usr.TestName(Find_pwd_UsrName.Text);
        if(index == -1)
        {
            Response.Write("<script>alert('用户名错误')</script>");
        }
        else
        {
            if(usr.Verigfyanswer(Find_pwd_UsrName.Text,Find_pwd_answer.Text))
            {
                pwd = usr.FindPwd(Find_pwd_UsrName.Text);
                Response.Write("<script>alert('密码：" + pwd + "')</script>");
                div_close_all();
                Login.Visible = true;
            }
            else
            {
                Response.Write("<script>alert('答案错误')</script>");
                
            }

        }                  
    }

    protected void Change_pwd_submit_Click(object sender, EventArgs e)
    {
        int i;
        i = usr.ChangePwd(Login_UsrName.Text, Change_pwd_now.Text, Change_pwd_next.Text);
        if (i == 0)
        {
            Response.Write("<script>alert('原密码错误')</script>");
        }
        else
        {
            Response.Write("<script>alert('成功！')</script>");
            div_close_all();
            Login_Choose.Visible = true;

        }
    }//完成

    protected void Login_Exit_Click(object sender, EventArgs e)
    {
        div_close_all();
    }

    protected void Choose_Change_question_Click(object sender, EventArgs e)
    {
        div_close_all();
        Login_Choose.Visible = true;
        Change_question.Visible = true;
    }       

    protected void Change_question_sumbit_Click(object sender, EventArgs e)
    {
        if(Change_question_question_self.Text == "")
        {
            usr.Addanswer(usrName, Change_question_question.Text, Change_question_answer.Text);
            Response.Write("<script>alert('修改成功')</script>");
            div_close_all();
            Login_Choose.Visible = true;
        }
        else
        {
            usr.Addanswer(usrName, Change_question_question_self.Text, Change_question_answer.Text);
            Response.Write("<script>alert('修改成功')</script>");
            div_close_all();
            Login_Choose.Visible = true;
        }
       
    }/*未完成*/

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void test_Click(object sender, EventArgs e)
    {

        //Verification_Code();
        Response.Write(secret.Decrypt(secret.Encrypt("1112345", "321"), "321"));
        string code = make_verification_code();
        Bitmap img = CreateCodeImg(code);
        //Context.Response.ClearContent();
        //Context.Response.ContentType = "image/Gif";
        //MemoryStream ms = CreateCodeImg(code);
        img.Save(@"D:\\web it\\website2");
        //if (null != ms)
        //{
        //Verify_Code_imge.ImageUrl=""
        //Context.Response.BinaryWrite(ms.ToArray);
        //}

    }
   //验证码尝试
    public static Bitmap CreateCodeImg(string checkCode)
    {
        if (string.IsNullOrEmpty(checkCode))
        {
            return null;
        }
        Bitmap image = new Bitmap((int)Math.Ceiling((checkCode.Length * 12.5)), 22);//bitmap第一项参数为的是将长度变为与数字数量相吻合
        Graphics graphic = Graphics.FromImage(image); //创建一个graphics类（绘图图面）而bitmap是位图
        try
        {
            Random random = new Random();
            graphic.Clear(Color.White);//清除背景并填充颜色
            int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
            for (int index = 0; index < 25; index++)
            {
                x1 = random.Next(image.Width);
                x2 = random.Next(image.Width);
                y1 = random.Next(image.Height);
                y2 = random.Next(image.Height);

                graphic.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                //绘制多条杂线干扰
            }
            Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));//宋体12号加粗斜体
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Red, Color.DarkRed, 1.2f, true);
            graphic.DrawString(checkCode, font, brush, 2, 2);
            //噪点绘制
            int x = 0;
            int y = 0;

            for (int i = 0; i < 100; i++)
            {
                x = random.Next(image.Width);
                y = random.Next(image.Height);

                image.SetPixel(x, y, Color.FromArgb(random.Next())); //任意取颜色插入噪点
            }
            //图片边线
            graphic.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
            //System.IO.MemoryStream ms = new System.IO.MemoryStream();
            return image;
        }
        finally
        {
            graphic.Dispose();
            image.Dispose();
        }

    }
    protected string make_verification_code()
    {
        int RandomNumber;
        DateTime now = DateTime.Now;
        Random ran = new Random((int)now.Second);
        RandomNumber = ran.Next(1000, 9999);
        return RandomNumber.ToString();

    }    
    protected void div_close_all()
    {
        //用户操作
        Sign.Visible = false;
        Login.Visible = false;
        Login_Choose.Visible = false;
        Find_pwd.Visible = false;
        Change_pwd.Visible = false;
        Change_question.Visible = false;
    }    

}


