<%@ Page Language="C#" AutoEventWireup="true" CodeFile="book_list.aspx.cs" Inherits="borrow_books" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <div runat="server" visible ="true">
            <!--导航栏-->
                <a href="sign.aspx">注册</a>
                <a href="login.aspx">登入</a>
                <a href="findpwd.aspx">找回密码</a>
                <a href="secret_login.aspx">我是管理员</a> 
                <a href="login_choose.aspx">我的主页</a>
            <br /><!--功能区-->
            <asp:Button ID="Login_Exit" runat="server" Text="注销" OnClick="Login_Exit_Click" />        <br />
        <asp:Repeater ID="borrowlist" runat="server" OnItemCommand="borrowlist_ItemCommand"  >
        <HeaderTemplate>
            <table border="1">
                <tr>
                    <th>书名</th>
                    <th>作者名</th>
                    <th>类别</th>
                    <th>借阅情况</th>
                    <th>借阅</th>
                    <th>查看评论</th>
                    <th>填写评论</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
                <tr>
                    <td><%# Eval("book_name") %></td>
                    <td><%# Eval("book_author_name") %></td>
                    <td><%# Eval("book_class") %></td>
                    <td><%# Eval("status") %></td>
                    <td><asp:LinkButton runat="server" ID="btnLend" CommandName="lend" Text="借阅" CommandArgument='<%# Eval("id") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton runat="server" ID="btncommnet" CommandName="comment" Text="查看评论" CommandArgument='<%# Eval("id") %>'></asp:LinkButton></td>     
                    <td><asp:LinkButton runat="server" ID="btnaddcommnet" CommandName="addcomment" Text="新增评论" CommandArgument='<%# Eval("id") %>'></asp:LinkButton></td>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
            <br />
            <asp:Button ID="former_page" runat="server" Text="上一页" OnClick="former_page_Click" />
            <asp:Button ID="next_page" runat="server" Text ="下一页" OnClick="next_page_Click" /> <br />
            <asp:Label ID="index_now" runat="server"></asp:Label>/
            <asp:Label ID="index_all" runat="server"></asp:Label>
           
        </div>
    </form>
</body>
</html>
