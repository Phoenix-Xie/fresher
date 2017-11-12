<%@ Page Language="C#" AutoEventWireup="true" CodeFile="secret_book_arrangement.aspx.cs" Inherits="secret_book_arrangement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style   id="background1" runat="server">
        #background{
            background-color:white;
            height:637px;
            width:85%;
            background-image:url('image/街道.jpg');
            background-repeat:no-repeat;
            float:left;
            color:snow;
            
        }
         a{
            color:snow;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="background">
              <!--导航栏-->
                <a href="sign.aspx">注册</a>
                <a href="login.aspx">登入</a>
                <a href="findpwd.aspx">找回密码</a>
                <a href="secret_login.aspx">我是管理员</a> 
                <a href="secret_arrangement.aspx">管理主页</a><br />
            <!--功能区-->
            请问您需要对图书进行什么操作呢？<br />
            书籍信息:<br />
            <asp:TextBox  ID="imformation" runat="server"></asp:TextBox><br />
            信息类型:<br />
                <asp:DropDownList runat="server"  ID="item">
                    <asp:ListItem Text="书名" Value="book_name"></asp:ListItem>
                    <asp:ListItem Text="作者" Value="book_author_name"></asp:ListItem>
                    <asp:ListItem Text="类别" Value="book_class"></asp:ListItem>
                </asp:DropDownList>
            <asp:Button ID="book_search" runat="server" Text="搜索" OnClick="book_search_Click" BorderStyle="Groove" /><br />
            <asp:Button ID="book_borrowed_search" runat="server" Text ="显示全部已借出书籍" OnClick="book_borrowed_search_Click" BorderStyle="Groove" />
        </div>
        <div id="search_result"  runat="server" visible="false">

        </div>
    </form>
</body>
</html>
