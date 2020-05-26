<%@ Page Title="" Language="C#" MasterPageFile="~/BackType/Main.Master" AutoEventWireup="true" CodeBehind="addUser.aspx.cs" Inherits="UI.BackType.addUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
     <table border="1px solid black">
                    <tr>
                        <td>用户名：</td>
                        <td><input type="text" id="username" name="username" runat="server"/></td>
                        
                    </tr>
                     <tr>
                        <td>密码：</td>
                        <td><input type="password" id="userpwd" name="password" runat="server"/></td>
                    </tr>
                     <tr>
                        <td>图片：</td>
                        <td><asp:FileUpload ID="FileUpload1" runat="server" Height="18px" Width="222px" /></td>
                    </tr>
                     <tr>
                         <td>账号状态</td>
                         <td>
                             <select id="isDelete" runat="server">
                                 <option value="0">可用</option>
                                  <option value="1">冻结</option>
                             </select>
                         </td>
                     </tr>
                     <tr>
                         <td colspan="2">
                             <input  type="submit" name="name" id="btnOk" runat="server" onserverclick="addUserMassae" value="提交"/>
                         </td>
                    </tr>
      </table>
        </form>
</asp:Content>
