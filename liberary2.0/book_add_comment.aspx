<%@ Page Language="C#" AutoEventWireup="true" CodeFile="book_add_comment.aspx.cs" Inherits="book_add_comment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <!--导航栏-->
                <a href="sign.aspx">注册</a>
                <a href="login.aspx">登入</a>
                <a href="findpwd.aspx">找回密码</a>
                <a href="secret_login.aspx">我是管理员</a> 
                <a href="login_choose.aspx">我的主页</a>
                <a href="book_comment.aspx">查看评论</a>
            <br /><!--功能区-->
        <div>
            我的评论：
            <asp:TextBox runat="server" ID="comment" TextMode="MultiLine"></asp:TextBox>
            <asp:Button runat="server" ID="submit" Text="提交" OnClick="submit_Click" />
        </div>
    </form>
</body>
</html>
