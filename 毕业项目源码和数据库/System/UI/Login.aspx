<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Login" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/register.css" />
    <script src="Scripts/jquery-1.7.1.min.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript">
        $(function () {
            $("#btnOk").click(function () {
                if (checkUser() && checkPwd()) {
                    return true;
                } else {
                    return false;
                }
            });
        })

        function checkUser() {
            var user = $("#UserName").val();
            if (user.trim() == "" || user.trim() == null) {
                alert("用户名是必填项！");
                return false;
            } else {
                return true;
            }
        }
         function checkPwd() {
           
             var pwd = $("#Pwd").val();
             var fleg = /^[0-9A-Za-z]{6,12}$/;

            if (pwd.trim() == "" || pwd.trim() == null) {
                alert("密码是必填项！");
                return false;
            } else {
                if (!fleg.test(pwd)) {
                     alert("密码由6-12位字母数字组成！");
                    return false;
                    
                } else {
                   return true;
                }
               
            }
        }
    </script>
</head>
<body>
    <form  method="post" runat="server" >
        <div id="con">
            <div id="title">
                用户登录
            </div>
            <hr class="bor" />
            <div id="reg">
                <ul>
                     <li>
                       <img src="Images/no.jpg"  id="headPic" runat="server"/>
                    </li>
                    <li>
                        <label>用户姓名：</label>
                        <input type="text" name="UserName" id="UserName" value="" class="textbox" runat="server"/>
                    </li>
                    <li>
                        <label>用户密码：</label>
                        <input type="password" name="Pwd" id="Pwd" value="" class="textbox" runat="server" />
                    </li>
                    <li>
                       
                        <input type="submit" id="btnOk" value="登录" class="buttom" runat="server" onserverclick="LoginCheck"/>
                        <input id="Reset1" type="reset" value="重置" class="buttom" /></li>
                </ul>
            </div>
        </div>
    </form>
</body>
</html>
