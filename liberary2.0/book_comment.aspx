<%@ Page Language="C#" AutoEventWireup="true" CodeFile="book_comment.aspx.cs" Inherits="book_comment" %>

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
                <a href="login_choose.aspx">我的主页</a>
                <a href="book_add_comment.aspx">新增评论</a>
            <br /><!--功能区-->
            书名：
            <asp:Label runat="server" ID="book_name"></asp:Label>
            作者：
            <asp:Label runat="server" ID="book_author_name"></asp:Label>
            类别：
            <asp:Label runat="server" ID="book_class"></asp:Label><br />
        <asp:Repeater ID="borrowlist" runat="server" OnItemCommand="borrowlist_ItemCommand" >
        <HeaderTemplate>
            <table>
                <tr>
                    <th>评论用户</th>
                    <th>评论</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
                <tr>
                    <td><%# Eval("people_name") %></td>
                    <td><%# Eval("comment") %></td>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
            <br />
            <asp:Button ID="former_page" runat="server" Text="上一页" OnClick="former_page_Click" />
            <asp:Button ID="next_page" runat="server" Text ="下一页" OnClick="next_page_Click" /> <br />
            <asp:Label ID="index_now" runat="server" ></asp:Label>/
            <asp:Label ID="index_all" runat="server"></asp:Label><br />
            <asp:Button ID="return_list" runat="server" OnClick ="return_list_Click" />
        </div>
    </form>
</body>
</html>
