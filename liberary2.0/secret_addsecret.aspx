<%@ Page Language="C#" AutoEventWireup="true" CodeFile="secret_addsecret.aspx.cs" Inherits="secret_addsecret" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!--导航栏-->
                <a href="sign.aspx">注册</a>
                <a href="login.aspx">登入</a>
                <a href="findpwd.aspx">找回密码</a>
                <a href="secret_login.aspx">我是管理员</a> 
                <a href="secret_arrangement.aspx">回到管理页面</a>
            <br /><!--功能区-->
            <asp:Button ID="secret_Exit" runat="server" Text="注销" OnClick="secret_Exit_Click" /><br />
            新管理员账户：<br />
            <asp:TextBox ID="secret_name"  runat="server" ></asp:TextBox><br />
            新管理员密码：<br />
            <asp:TextBox ID="secret_pwd"  runat="server" TextMode="Password"></asp:TextBox><br />
            再次输入：<br />
            <asp:TextBox ID="secret_pwd_twice" runat="server" TextMode="Password"></asp:TextBox><br />
            输入关键密码：<br />
            <asp:TextBox ID="secret_key_pwd" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Button ID="secret_add" runat="server" Text="提交"  OnClick="secret_add_Click"/>
        </div>
    </form>
</body>
</html>
