<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login"  ValidateRequest="false"%>

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
                <a href="secret_login.aspx">我是管理员</a> <br />
            <!--功能区-->
            欢迎回到 茵蒂克丝 图书馆
            登入：<br />
            用户名：
            <asp:TextBox ID ="Login_UsrName" runat ="server"></asp:TextBox><br />
            密码：
            <asp:TextBox ID ="Login_UsrPwd" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Button ID ="Login_button" runat="server" Text="登入" OnClick="Login_button_Click" />  <br /> 
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
