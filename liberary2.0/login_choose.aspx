<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login_choose.aspx.cs" Inherits="login_choose" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="Login_choose" runat="server">
             <!--导航栏-->
                <a href="sign.aspx">注册</a>
                <a href="login.aspx">登入</a>
                <a href="findpwd.aspx">找回密码</a>
                <a href="secret_login.aspx">我是管理员</a> <br />
            <!--功能区-->
            <asp:Button ID="Login_Exit" runat="server" Text="注销" OnClick="Login_Exit_Click" />        <br />
            欢迎登入属于你的主页<br />
            <asp:Button ID="Choose_Change" runat="server" Text="修改密码" OnClick="Choose_Change_Click" />        <br />
            <asp:Button ID="Choose_Change_question" runat="server" Text="更改密保问题" OnClick="Choose_Change_question_Click"/>  <br />  
            <div>
            若打算查询书籍请输入：<br />
            所要查询的关键信息：
            <asp:TextBox ID="imformation" runat="server" ></asp:TextBox><br />
            搜索方向：
                <asp:DropDownList runat="server"  ID="item">
                    <asp:ListItem Text="书名" Value="book_name"></asp:ListItem>
                    <asp:ListItem Text="作者" Value="book_author_name"></asp:ListItem>
                    <asp:ListItem Text="类别" Value="book_class"></asp:ListItem>
                </asp:DropDownList>
            <asp:Button ID="search" runat="server"  Text="搜索" OnClick="search_Click" />
            <asp:Button ID="borrowed_book" runat="server" Text="显示已借阅的图书" OnClick="borrowed_book_Click" />
        </div>
        </div>
    </form>
</body>
</html>
