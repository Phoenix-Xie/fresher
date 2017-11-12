<%@ Page Language="C#" AutoEventWireup="true" CodeFile="book_edit.aspx.cs" Inherits="book_edit" %>

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
                <a href="secret_arrangement.aspx">管理主页</a><br />
            <!--功能区-->
            书名：
            <asp:TextBox runat="server" ID="book_name"></asp:TextBox> <br />
            作者：
            <asp:TextBox runat="server" ID="book_author_name"></asp:TextBox> <br />
            类型：
            <asp:TextBox runat="server" ID="book_class"></asp:TextBox> <br />
            <asp:Button runat="server" ID="edit"  Text="修改" OnClick="edit_Click" />
        </div>
    </form>
</body>
</html>
