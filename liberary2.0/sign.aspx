  <%@ Page Language="C#" AutoEventWireup="true" CodeFile="sign.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style   id="background1" runat="server">
        #background{
            background-color:white;
            height:1079px;
            width:100%;
            background-image:url('image//图书馆穹顶.jpg');
            background-repeat:no-repeat;
            float:left;            
        }        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
         <div id="img" runat="server"  > </div>
            <div id="contain">
                <!--导航栏-->
                <a href="sign.aspx">注册</a>
                <a href="login.aspx">登入</a>
                <a href="findpwd.aspx">找回密码</a>
                <a href="secret_login.aspx">我是管理员</a> <br />
            欢迎注册茵蒂克丝图书馆
            用户注册：<br />
            用户名：
            <asp:TextBox ID ="Sign_Usrname" runat ="server"></asp:TextBox><br />
            设置密码：
            <asp:TextBox ID ="Sign_pwd" runat ="server" TextMode ="Password"></asp:TextBox><br />
            密码应该五位以上，并且数字大小写字母混合，带有特殊字符 <br />
            再次输入密码：
            <asp:TextBox ID ="Sign_pwd2" runat="server" TextMode ="Password"></asp:TextBox><br />  
            学院：
            <asp:DropDownList ID ="Sign_college" runat="server">
                <asp:ListItem>信息科学与工程学院</asp:ListItem>
                <asp:ListItem>工程学院</asp:ListItem>
                <asp:ListItem>国家保密学院</asp:ListItem>
                <asp:ListItem>其他学院</asp:ListItem>
            </asp:DropDownList><br />
            密保问题：
            <asp:DropDownList ID="Sign_security_question" runat="server">
                <asp:ListItem>小时候最喜欢的人的名字</asp:ListItem>
                <asp:ListItem>现在或最近时期班主任名字</asp:ListItem>
                <asp:ListItem>最喜欢的食物</asp:ListItem>
                <asp:ListItem>最喜欢的运动</asp:ListItem>
                <asp:ListItem>父亲的生日</asp:ListItem>
                <asp:ListItem>母亲的生日</asp:ListItem>
            </asp:DropDownList><br />
            自主选择密保问题请在以下方框输入：
            <asp:TextBox ID="Sign_security_question_self" runat="server" Text="" ></asp:TextBox><br />
            设置问题答案<br />
            <asp:TextBox ID="Sign_security_answer" runat="server" ></asp:TextBox><br />
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
            <asp:Button ID ="Sign_submit" runat="server" Text ="提交" OnClick="Sign_submit_Click" />
               </div>
        <div id="background" runat="server"></div>
        
    </form>
</body>
</html>
