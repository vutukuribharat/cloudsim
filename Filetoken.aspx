<%@ Page Title="TOKEN REQUEST" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="Filetoken.aspx.cs" Inherits="Filetoken" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <div style="margin-top:20px">
        <asp:Panel ID="Panel1" runat="server">
            <fieldset>
                <legend>File Token</legend>
        <div>   
        <table>
            <tr>
                <td>
                   
                <asp:Button ID="btn_token" runat="server" Text="Send Request to Get The file Token" BackColor="White" BorderColor="#3399FF" OnClick="btn_token_Click" ></asp:Button></td>
                <td>
                      <asp:Label ID="Generate" runat="server" ForeColor="#ff0066" Text=""></asp:Label>
                </td>
            </tr>
            </table>
              </div>
                </fieldset>
            </asp:Panel>
            </div>
    </center>
</asp:Content>

