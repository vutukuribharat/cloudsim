<%@ Page Title="FILE TOKEN" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="File_upload.aspx.cs" Inherits="File_upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <center>
        <div style="margin-top:20px">
        <asp:Panel ID="Panel1" runat="server" Visible="true">
            <fieldset>
                <legend>File Token</legend>
        <div>   
        <table>
            <tr>
                <td> <asp:Label ID="Label1" runat="server" Text="Enter the File Token"></asp:Label></td>
                <td> <asp:TextBox ID="txt_token" runat="server"></asp:TextBox></td>
                <td> <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click"></asp:Button></td>
                              <td>
                     <asp:Button ID="btn_back" runat="server" OnClick="btn_back_Click"  Text="Back"></asp:Button>
                </td>
            </tr>
            </table>
              </div>
                </fieldset>
            </asp:Panel>
            </div>
    </center>
</asp:Content>

