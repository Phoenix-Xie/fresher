<%@ Page Language="C#" AutoEventWireup="true" CodeFile="secret_login.aspx.cs" Inherits="secret_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style   id="background1" runat="server">
        #Secret_login{
            background-color:white;
            height:1079px;
            width:100%;
            background-image:url('image//桐人2.jpg');
            background-repeat:no-repeat;
            float:left;   
            color:white;
        }
        a{
            color:white;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="Secret_login" runat="server" > 
            <!--导航栏-->
                <a  href="sign.aspx">注册</a>
                <a href="login.aspx">登入</a>
                <a href="findpwd.aspx">找回密码</a>
                <a href="secret_login.aspx">我是管理员</a> 
            <br /><!--功能区-->
            请先确认一下身份<br />
            请登入：<br />
            管理员名<br />
            <asp:TextBox ID="Secret_login_name" runat="server"></asp:TextBox><br />
            密码<br />
            <asp:TextBox ID="Secret_login_pwd" runat="server" Textmode="Password"></asp:TextBox><br />
            <asp:Button ID="Secret_login_button" runat="server" Text ="登入" OnClick="Secret_login_button_Click" /><br />
            验证码：
            <asp:TextBox ID="tbx_yzm" runat="server" Width="70px"></asp:TextBox>
            <asp:ImageButton ID="ibtn_yzm" runat="server" />
            <a href="javascript:changeCode()"style="text-decoration: underline; font-size:10px;">换一张</a>
            <script type="text/javascript">
            function changeCode() 
            {
                document.getElementById('ibtn_yzm').src = document.getElementById('ibtn_yzm').src + '?';
            }
            </script>
        </div>  
    </form>
</body>
</html>
