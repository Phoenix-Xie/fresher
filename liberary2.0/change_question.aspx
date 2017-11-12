<%@ Page Language="C#" AutoEventWireup="true" CodeFile="change_question.aspx.cs" Inherits="change_question" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="Change_question" runat="server" >
           <!--导航栏-->
                <a href="sign.aspx">注册</a>
                <a href="login.aspx">登入</a>
                <a href="findpwd.aspx">找回密码</a>
                <a href="secret_login.aspx">我是管理员</a> 
                <a href="login_choose.aspx">我的主页</a>
            <br /><!--功能区-->
            <asp:Button ID="Login_Exit" runat="server" Text="注销" OnClick="Login_Exit_Click" />        <br />
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
    </form>
</body>
</html>
