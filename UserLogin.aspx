<%@ Page Title="USER LOGIN" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="UserLogin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

    <script src="JScript.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#reg").hide();
            $("#register").click(function () {
                $("#reg").show();
                $("#login").hide();
            });
            $("#log").click(function () {
                $("#login").show();
                $("#reg").hide();
            });
        });
    </script>

    <div id="login">
<center>
    <fieldset>
        <legend style="background-color:blue">Login</legend>
        <table>
          
            <tr>
                <td><asp:Label ID="lbl_username" runat="server" Text="User Name"></asp:Label>
                </td>
                <td> <asp:TextBox ID="txt_username" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txt_username" ValidationGroup="login"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td><asp:Label ID="lbl_password" runat="server" Text="Password"></asp:Label></td>
                <td><asp:TextBox ID="txt_password" runat="server" TextMode="Password"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txt_password"  ValidationGroup="login"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btn_login" runat="server" Text="Login"  ValidationGroup="login" OnClick="btn_login_Click"></asp:Button></td>
                <td><p>If you are new user <a id="register">Register</a> here</p></td>
            </tr>
           
        </table>
    </fieldset>
</center>
        </div>
    <div id="reg">
        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <center>

            <fieldset>
                <legend style="background-color:blue">Registration</legend>
           
        <table>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                   <tr>
                <td><asp:Label ID="lbl_UserID" runat="server" Text="User ID"></asp:Label></td>
                <td><asp:TextBox ID="txt_userId" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txt_userId"  ValidationGroup="reg" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_user" runat="server" Text="User Name"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txt_user" runat="server" ></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ValidationGroup="reg" ControlToValidate="txt_user"></asp:RequiredFieldValidator></td>
                <td><asp:Label ID="lbl_check" runat="server" Text=""></asp:Label></td>
            </tr>
                    </ContentTemplate>
                </asp:UpdatePanel>
            <tr>
                <td>
                    <asp:Label ID="lbl_gender" runat="server" Text="Gender"></asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" ValidationGroup="reg" RepeatDirection="Horizontal">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="reg" ErrorMessage="*" ControlToValidate="RadioButtonList1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_emailid" runat="server" Text="EmailId"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txt_emailid" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ValidationGroup="reg" ControlToValidate="txt_emailid"></asp:RequiredFieldValidator></td>
                <td><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Emailid" ControlToValidate="txt_emailid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="reg"></asp:RegularExpressionValidator></td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="lbl_userpass" runat="server" Text="Password"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txt_userpass" runat="server" TextMode="Password"></asp:TextBox></td>
                 <td><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ValidationGroup="reg" ControlToValidate="txt_userpass"></asp:RequiredFieldValidator></td>
            </tr>
            
             <tr>
                <td>
                    <asp:Label ID="lbl_conform" runat="server" Text="Retype Password"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txt_conform" runat="server" TextMode="Password"></asp:TextBox></td>
                 <td><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ValidationGroup="reg" ControlToValidate="txt_conform"></asp:RequiredFieldValidator></td>
                 <td><asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password mismatch" ControlToValidate="txt_conform" ControlToCompare="txt_userpass" ValidationGroup="reg"></asp:CompareValidator></td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="lbl_phone" runat="server" Text="Phone Number"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txt_phone" runat="server"></asp:TextBox></td>
                 <td><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ValidationGroup="reg" ControlToValidate="txt_phone"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td><asp:Label ID="lbl_city" runat="server" Text="City"></asp:Label></td>
                <td><asp:TextBox ID="txt_city" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ValidationGroup="reg" ControlToValidate="txt_city"></asp:RequiredFieldValidator></td>
            </tr>
             <tr>
                <td></td>
                   
                <td>
                    <asp:Button ID="btn_register" runat="server" Text="Register" ValidationGroup="reg" OnClick="btn_register_Click" /> </td>
                 <td><p><a id="log">Login Here</a></p></td>
                 
            </tr>
        </table>
            
         </fieldset>
            </center>
    </div>
</asp:Content>

