<%@ Page Language="C#" AutoEventWireup="true" CodeFile="change_pwd.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id ="Change_pwd" runat ="server">
             <!--导航栏-->
                <a href="sign.aspx">注册</a>
                <a href="login.aspx">登入</a>
                <a href="findpwd.aspx">找回密码</a>
                <a href="secret_login.aspx">我是管理员</a> 
                <a href="login_choose.aspx">我的主页</a>
            <br /><!--功能区-->
            <asp:Button ID="Login_Exit" runat="server" Text="注销" OnClick="Login_Exit_Click" />   <br />
            <pre />            
            修改密码<br />
            原始密码:
            <asp:TextBox ID="Change_pwd_now" runat="server" Textmode="Password"></asp:TextBox><br /> <br />
            新的密码：
            <asp:TextBox ID="Change_pwd_next" runat="server" Textmode="Password"></asp:TextBox> <br />    
            <asp:TextBox ID="Change_pwd_next_second" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Button ID="Change_pwd_submit" runat="server" Text="修改！" OnClick="Change_pwd_submit_Click" />       
        </div>
    </form>
</body>
</html>
