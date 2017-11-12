<%@ Page Language="C#" AutoEventWireup="true" CodeFile="secret_user_arrangement.aspx.cs" Inherits="secret_user_arrangement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="Secret_user_Arrangement" runat="server">
            <!--导航栏-->
                <a href="sign.aspx">注册</a>
                <a href="login.aspx">登入</a>
                <a href="findpwd.aspx">找回密码</a>
                <a href="secret_login.aspx">我是管理员</a> 
                <a href="secret_arrangement.aspx">回到管理页面</a>
            <br /><!--功能区-->
            <asp:Button ID="secret_Exit" runat="server" Text="注销"  OnClick="secret_Exit_Click" />
            请输入用户名相关信息：
            <asp:TextBox ID="imformation" runat="server" ></asp:TextBox><br />
            信息类型
            <asp:DropDownList ID="imformation_type" runat="server">
                <asp:ListItem Value="userName">姓名</asp:ListItem>
                <asp:ListItem Value="userCollege">学院</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="search" runat="server" Text="搜索" OnClick="search_Click" />
            <asp:Button ID="Secret_usr_Arrangement_usrName_delete" runat="server" Text="删除该用户" OnClick="Secret_usr_Arrangement_usrName_delete_Click" /><br />
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
                    <td><asp:LinkButton runat="server" ID="btndelete" CommandName="delete" Text="删除" CommandArgument='<%# Eval("id") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton runat="server" ID="btnreturn" CommandName ="return" Text="归还" CommandArgument='<%#Eval("id") %>'></asp:LinkButton></td>
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
