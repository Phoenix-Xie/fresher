<%@ Page Language="C#" AutoEventWireup="true" CodeFile="findpwd.aspx.cs" Inherits="findpwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id ="Find_pwd" runat="server" >
             <!--导航栏-->
                <a href="sign.aspx">注册</a>
                <a href="login.aspx">登入</a>
                <a href="findpwd.aspx">找回密码</a>
                <a href="secret_login.aspx">我是管理员</a> <br />
            <!--功能区--> 
            <pre />
            找回密码<br />
            用户名：
            <asp:TextBox ID="Find_pwd_UsrName" runat="server"></asp:TextBox><br />
            请回答以下问题：<br />
            <asp:Button ID="Find_pwd_question_visiable_button" runat="server" Text="显示相应问题" OnClick="Find_pwd_question_visiable_button_Click" />
            
            <asp:TextBox ID="Find_pwd_question" runat="server" Text=""  ReadOnly="true"></asp:TextBox> <br />
            你的答案：
            <asp:TextBox ID="Find_pwd_answer" runat="server" ></asp:TextBox> <br />
            <asp:Button ID ="Find_pwd_Submit" runat="server" Text="找回" OnClick="Find_pwd_Submit_Click" />                     
        </div>
    </form>
</body>
</html>
