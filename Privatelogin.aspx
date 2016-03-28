<%@ Page Title="PRIVATE LOGIN" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Privatelogin.aspx.cs" Inherits="Privatelogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <center>
 <fieldset>
     <legend>Private Cloud Login</legend>
        <table>
            <tr>
                <td><asp:Label ID="lbl_name" runat="server" Text="Private Cloud Name"></asp:Label></td>
                <td><asp:TextBox ID="txt_username" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txt_username"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td><asp:Label ID="lbl_password" runat="server" Text="Password"></asp:Label></td>
                <td><asp:TextBox ID="txt_password" runat="server" TextMode="Password"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txt_password"></asp:RequiredFieldValidator></td>
            </tr>
             <tr>
                <td></td>
                <td><asp:Button ID="btn_login" runat="server" Text="Login" OnClick="btn_login_Click"></asp:Button></td>
            </tr>
        </table>
     </fieldset>
  </center>
</asp:Content>

