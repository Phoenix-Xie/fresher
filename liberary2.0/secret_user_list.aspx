<%@ Page Language="C#" AutoEventWireup="true" CodeFile="secret_user_list.aspx.cs" Inherits="secret_user_list" %>

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
            <asp:Repeater ID="userlist" runat="server" OnItemCommand="userlist_ItemCommand">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>人名</th>
                            <th>学院</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("userName") %></td>
                        <td><%#Eval("userCollege") %></td>
                        <td><asp:LinkButton runat="server" ID="userdelete" CommandName="delete" Text="删除" CommandArgument='<%#Eval("userName") %>'></asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Button ID="user_former_page" runat="server" Text="上一页" OnClick="user_former_page_Click" Visible/>
            <asp:Button ID="user_next_page" runat="server" Text ="下一页" OnClick="user_next_page_Click" Visible/> <br />
            <asp:Label ID="user_index_now" runat="server" ></asp:Label>/
            <asp:Label ID="user_index_all" runat="server"></asp:Label>
        <asp:Repeater ID="borrowlist" runat="server" OnItemCommand="borrowlist_ItemCommand" Visible="false" >
        <HeaderTemplate>
            <table>
                <tr>
                    <th>书名</th>
                    <th>借出时间</th>
                    <th>删除</th>
                    <th>归还</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
                <tr>
                    <td><%# Eval("book_name_borrow") %></td>
                    <td><%# Eval("book_borrow_start_days") %></td>
                    <td><asp:LinkButton runat="server" ID="btndelete" CommandName="delete" Text="删除" CommandArgument='<%# Eval("book_name_borrow") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton runat="server" ID="btnreturn" CommandName ="return" Text="归还" CommandArgument='<%#Eval("book_name_borrow") %>'></asp:LinkButton></td>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
            <asp:Button ID="former_page" runat="server" Text="上一页" OnClick="former_page_Click" Visible="false"/>
            <asp:Button ID="next_page" runat="server" Text ="下一页" OnClick="next_page_Click" Visible="false"/> <br />
            <asp:Label ID="index_now" runat="server" Visible="false"></asp:Label>/
            <asp:Label ID="index_all" runat="server" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
