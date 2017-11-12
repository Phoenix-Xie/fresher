<%@ Page Language="C#" AutoEventWireup="true" CodeFile="secret_arrangement.aspx.cs" Inherits="secret_arrangement" %>

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
            <br /><!--功能区-->
            <asp:Button ID="secret_Exit" runat="server" Text="注销" OnClick="secret_Exit_Click" />
            <asp:Button ID="secret_Choose_user_arrangement" runat="server" Text="用户管理" OnClick="secret_Choose_user_arrangement_Click" />
            <asp:Button ID="secret_Chooose_book_arrangement" runat="server" Text="图书管理" OnClick="secret_Chooose_book_arrangement_Click" /><br />
            <asp:Button ID="secret_Choose_addsecret" runat="server" Text="增加管理员" OnClick="secret_Choose_addsecret_Click" />
            <asp:Button ID="secret_Choose_deletesecret" runat="server" Text="删除管理员" OnClick="secret_Choose_deletesecret_Click" />
        </div>
    </form>
</body>
</html>
