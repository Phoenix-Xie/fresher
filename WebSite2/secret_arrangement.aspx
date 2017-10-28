<%@ Page Language="C#" AutoEventWireup="true" CodeFile="secret_arrangement.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style   id="background1" runat="server">
        #background{
            background-color:white;
            height:1079px;
            width:1557px;
            background-image:url('image//yll2.jpg');
        }
    </style>
</head>
<body style="height: 664px; width: 1794px">
    <div id="background">
     <div style="width:1000px; margin:0 auto;">
    <form id="form1" runat="server">
        <!--管理员登入界面-->
        
        <div id="Secret_login" runat="server" visible ="true" >            
            请先确认一下身份<br />
            请登入：<br />
            <asp:TextBox ID="Secret_login_pwd" runat="server" Textmode="Password"></asp:TextBox>
            <asp:Button ID="Secret_login_button" runat="server" Text ="登入" OnClick="Secret_login_button_Click" />
        </div>       
        <div id="Secret_Arrangement" runat="server" visible ="false">
            欢迎回来，管理员先生 <br />
            请问您想进行什么样的操作呢 <br />
            <asp:Button ID="Secret_Arrangement_Choose_userArrangement" runat="server" Text="用户管理" OnClick="Secret_Arrangement_Choose_userArrangement_Click" /><br />
            <asp:Button ID="Secret_Arrangement_Choose_pwd" runat="server" Text="密码修改" OnClick="Secret_Arrangement_Choose_pwd_Click" /><br />
            <asp:Button ID="Secret_Arrangement_Choose_key" runat="server" Text="密匙修改" OnClick="Secret_Arrangement_Choose_key_Click" /><br />
            <asp:Button ID="Secret_Arrangement_Choose_getkey" runat="server" Text="获取密匙" OnClick="Secret_Arrangement_Choose_getkey_Click" /><br />
        </div>
        <div id="Secret_user_Arrangement" runat="server" visible="false">
            请输入用户名：
            <asp:TextBox ID="Secret_usr_Arrangement_usrName" runat="server" ></asp:TextBox><br />
            <asp:Button ID="Secret_usr_Arrangement_usrName_delete" runat="server" Text="删除该用户" OnClick="Secret_usr_Arrangement_usrName_delete_Click" /><br />
            <asp:Button ID ="Secret_usr_Arrangement_usrpwd" runat="server" Text="获得用户密码" OnClick="Secret_usr_Arrangement_usrpwd_Click" /> <br />
            <asp:Button ID="Secret_usr_Arrangement_Exit" runat="server" Text="退出" OnClick="Secret_usr_Arrangement_Exit_Click" />
        </div>
        <div id="Secret_change_pwd" runat="server" visible="false">
            请输入旧密码<br />
            <asp:TextBox ID="Secret_change_pwd_oldpwd" runat="server" TextMode="Password" ></asp:TextBox><br />
            新密码<br />
            <asp:TextBox ID="Secret_change_pwd_newpwd" runat="server" TextMode="Password" ></asp:TextBox><br />
            <asp:Button ID ="Secret_change_pwd_submit" runat="server" Text="确定" OnClick="Secret_change_pwd_submit_Click" />
            <asp:Button ID="Secret_change_pwd_Exit" runat="server" Text="退出" OnClick="Secret_change_pwd_Exit_Click" />
        </div>
        <div id="Secret_change_key" runat="server" visible="false">
            密匙修改： <br />
            新密匙：<br />
            <asp:TextBox ID="New_Key" runat="server"></asp:TextBox>            
            <asp:Button ID="Secret_change_Key_button" runat="server" Text="提交" OnClick="Secret_change_Key_button_Click" />
            <asp:Button ID="Secret_change_Key_Exit" runat="server" Text="退出" OnClick="Secret_change_Key_Exit_Click" />
        </div>
        <div id="Secret_make_sure" runat="server" visible="false">
            请再次输入管理员密码：<br />
            <asp:TextBox ID="Secret_makesure_pwd" runat="server"  TextMode="Password"  ></asp:TextBox><br />
            <asp:Button ID="Secret_makesure_pwd_submit" runat="server" Text="确认身份" OnClick="Secret_makesure_pwd_submit_Click" />
        </div>

        <div id="Secret_make_sure_delete" runat="server" visible="false">
            该用户删除后将无法复原<br />
            <asp:Button ID="Secret_make_sure_delete_button" runat="server"  Text="确认删除" OnClick="Secret_make_sure_delete_button_Click" />
            <asp:Button ID="Secret_make_sure_delete_Exit" runat="server" Text="退出" OnClick="Secret_make_sure_delete_Exit_Click" />
        </div>
        <div id="Secret_make_sure_change_key" runat="server" visible="false">
            确定修改密匙吗？修改后可能导致之前数据解密错误 <br />
            <asp:Button ID="Secret_make_sure_change_key_button" runat="server" Text="修改" OnClick="Secret_make_sure_change_key_button_Click" />
            <asp:Button ID="Secret_make_sure_change_key_Exit" runat="server" Text="退出" OnClick="Secret_make_sure_change_key_Exit_Click" />
        </div>
    </form>
        </div>
        </div>
</body>
</html>
