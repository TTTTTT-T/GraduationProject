<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="UI.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/register.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div id="con">
        <div id="title">
            用户注册
        </div>  
        <hr class="bor"  />  
        <div id="reg">
            <ul>
                <li>

                    <asp:Label ID="Label1" runat="server" Text="用户姓名："></asp:Label>
                    <asp:TextBox ID="UserName" runat="server" class="textbox"></asp:TextBox>

                </li>
                <li>

                    <asp:Label ID="Label2" runat="server" Text="用户密码："></asp:Label>
                    <asp:TextBox ID="Pwd" runat="server" class="textbox"></asp:TextBox>

                </li>
                <li>

                    <asp:Button ID="Button1" runat="server" Text="注册" class="buttom" OnClick="Button1_Click"/>
                    <input id="Reset1" type="reset" value="重置" class="buttom"/></li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
