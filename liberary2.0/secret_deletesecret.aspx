<%@ Page Language="C#" AutoEventWireup="true" CodeFile="secret_deletesecret.aspx.cs" Inherits="secret_deletesecret" %>

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
            <asp:Button ID="secret_Exit" runat="server"  Text="注销" OnClick="secret_Exit_Click" /><br />
            请输入所删除的管理员的名字
            <asp:TextBox ID="secret_name" runat="server" ></asp:TextBox><br />
            请输入关键密码
            <asp:TextBox ID="secret_keypwd" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Button ID="secret_delete" runat="server" Text="删除"  OnClick="secret_delete_Click" />
        </div>
    </form>
</body>
</html>
