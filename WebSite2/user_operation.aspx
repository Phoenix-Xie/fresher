<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_operation.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style   id="background1" runat="server">
        #background{
            background-color:white;
            height:1079px;
            width:1557px;
            background-image:url('image//jth.png');
        }
    </style>
</head>
<body>
    <div id="background">
    <form id="form1" runat="server">
        <div id="Choose" runat="server" visible="true">
            <pre />
            欢迎登入该网站 <br />
            <asp:Button ID="Choose_Sign" runat="server" Text="注册" OnClick="Choose_Sign_Click" />    <br />
            <asp:Button ID="Choose_Login" runat="server" Text="登入" OnClick="Choose_Login_Click" />    <br />
            <asp:Button ID="Choose_Find" runat="server" Text="找回密码" OnClick="Choose_Find_Click" />    <br />
            <asp:Button ID ="Choose_secret" runat="server" Text="我是管理员" OnClick="Choose_secret_Click" />  <br />
            <asp:Button ID="Choose_secret_change_picture"  runat="server"  Text="壁纸太丑换一张"  OnClick="Choose_secret_change_picture_Click"  /><br />
            <!--<asp:Button ID ="test" runat="server" Text="test" Onclick="test_Click"/> <br /> -->

        </div>
        <div id ="Sign" runat ="server" visible="false">
        <pre />
            用户注册：<br />
            用户名：
            <asp:TextBox ID ="Sign_Usrname" runat ="server"></asp:TextBox><br />
            设置密码：
            <asp:TextBox ID ="Sign_pwd" runat ="server" TextMode ="Password"></asp:TextBox><br />
            密码应该五位以上，并且数字字母混合，带有特殊字符 <br />
            再次输入密码：
            <asp:TextBox ID ="Sign_pwd2" runat="server" TextMode ="Password"></asp:TextBox><br />            
            <asp:DropDownList ID="Sign_security_question" runat="server">
                <asp:ListItem>小时候最喜欢的人的名字</asp:ListItem><asp:ListItem>现在或最近时期班主任名字</asp:ListItem><asp:ListItem>最喜欢的食物</asp:ListItem><asp:ListItem>最喜欢的运动</asp:ListItem><asp:ListItem>父亲的生日</asp:ListItem><asp:ListItem>母亲的生日</asp:ListItem></asp:DropDownList>
            自主选择密保问题请在以下方框输入：
            <asp:TextBox ID="Sign_security_question_self" runat="server" Text="" ></asp:TextBox>
            设置问题答案<br />
            <asp:TextBox ID="Sign_security_answer" runat="server" ></asp:TextBox>
            <asp:Button ID ="Sign_submit" runat="server" Text ="提交" OnClick ="Sign_submit_Click" />

        

        </div>
        <div id="verify_Code" runat="server" visible="true">
            <asp:Image ID="Verify_Code_imge" runat="server" Width="203px" Height="115px" ImageUrl="" />
        </div>
        <!-- 登入及登入后界面-->
        <div id="Login" runat="server" visible ="false">
            <pre />            
            登入：<br />
            用户名：
            <asp:TextBox ID ="Login_UsrName" runat ="server"></asp:TextBox><br />
            密码：
            <asp:TextBox ID ="Login_UsrPwd" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Button ID ="Login_button" runat="server" Text="登入" OnClick="Login_button_Click" />  <br />                                   
        </div>
        <div id ="Login_Choose" runat="server" visible="false">
            <pre />
            欢迎登入属于你的主页<br />
            <asp:Button ID="Choose_Change" runat="server" Text="修改密码" OnClick="Choose_Change_Click" />        <br />
            <asp:Button ID="Choose_Change_question" runat="server" Text="更改密保问题" OnClick="Choose_Change_question_Click" />  <br />
            <asp:Button ID="Login_Exit" runat="server" Text="退出主页" OnClick="Login_Exit_Click" />        <br />
        </div>
        <div id ="Find_pwd" runat="server" visible="false">
            <pre />
            找回密码<br />
            用户名：
            <asp:TextBox ID="Find_pwd_UsrName" runat="server"></asp:TextBox><br />
            请回答以下问题：<br />
            <asp:Button ID="Find_pwd_question_visiable_button" runat="server" Text="显示相应问题" OnClick="Find_pwd_question_visiable_button_Click" />
            
            <asp:TextBox ID="Find_pwd_question" runat="server" Text=""  ReadOnly="true"></asp:TextBox> <br />
            <asp:TextBox ID="Find_pwd_answer" runat="server" ></asp:TextBox> <br />
            <asp:Button ID ="Find_pwd_Submit" runat="server" Text="找回" OnClick="Find_pwd_Submit_Click" />
        
        
        
        </div>
        <div id ="Change_pwd" runat ="server" visible="false">
            <pre />            
            修改密码<br />
            原始密码:
            <asp:TextBox ID="Change_pwd_now" runat="server" Textmode="Password"></asp:TextBox><br /> <br />
            新的密码：
            <asp:TextBox ID="Change_pwd_next" runat="server" Textmode="Password"></asp:TextBox> <br />                 
            <asp:Button ID="Change_pwd_submit" runat="server" Text="修改！" OnClick="Change_pwd_submit_Click" />
        
        
        
        </div>  
        <div id="Change_question" runat="server" visible="false">
            <asp:DropDownList ID="Change_question_question" runat="server" >
                <asp:ListItem>小时候最喜欢的人的名字</asp:ListItem>
                <asp:ListItem>现在或最近时期班主任名字</asp:ListItem>
                <asp:ListItem>最喜欢的食物</asp:ListItem>
                <asp:ListItem>最喜欢的运动</asp:ListItem>
                <asp:ListItem>父亲的生日</asp:ListItem>
                <asp:ListItem>母亲的生日</asp:ListItem>
            </asp:DropDownList>
            自主选择密保问题请在以下方框输入：
            <asp:TextBox ID="Change_question_question_self" runat="server"></asp:TextBox> <br />
            <asp:TextBox ID="Change_question_answer" runat="server"></asp:TextBox>
            <asp:Button ID="Change_question_sumbit" runat="server" Text="提交"  OnClick="Change_question_sumbit_Click"/>
        </div>
        <div id="Verification" runat="server" visible="false">

        </div>
        <p>
            <asp:ImageButton ID="ImageButton1" runat="server" Height="46px" Width="90px" OnClick="ImageButton1_Click"  ImageUrl="" />
        </p>  
        
    </form>
        </div>
</body>
</html>
