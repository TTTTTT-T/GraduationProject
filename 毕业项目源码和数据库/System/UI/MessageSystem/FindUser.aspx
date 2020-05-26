<%@ Page Title="" Language="C#" MasterPageFile="~/MessageSystem/Site1.Master" AutoEventWireup="true" CodeBehind="FindUser.aspx.cs" Inherits="UI.MessageSystem.FindUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="Repeater1" runat="server">
     <HeaderTemplate>
        <table border="1">
        
        <tr>
            <th>用户编号</th>
             <th>用户姓名</th>
             <th>密码</th>
             <th>账号状态</th>
             <th>操作</th>
        </tr>
    </HeaderTemplate>
        <ItemTemplate>
   
        <tr>
            <td><%# Eval("UserID") %></td>
             <td><%# Eval("UserName") %></td>
             <td><%# Eval("Pwd") %></td>
             <td><img src="../picture/<%# Eval("picture") %>" width="20" height="20"/></td>
             <td><%# Eval("IsDelete").ToString()=="0"?"有效":"无效" %></td>
             <td><a href="#">删除</a>&nbsp;<a href="#">修改</a></td>
        </tr>
        </ItemTemplate>
        <FooterTemplate>
        </table>
            </FooterTemplate>
    </asp:Repeater>
</asp:Content>
