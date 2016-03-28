<%@ Page Title="Authentication KEY" Language="C#" MasterPageFile="~/convergent.master" AutoEventWireup="true" CodeFile="Convergent Key.aspx.cs" Inherits="Convergent_Kye" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <div style="margin-top:20px">
        <asp:Panel ID="Panel1" runat="server" Visible="true">
            <fieldset>
                <legend>Convergent key</legend>
        <div>   
        <table>
            <tr>
                <td> <asp:Label ID="Label1" runat="server" Text="Enter the Authentication key"></asp:Label></td>
                <td> <asp:TextBox ID="txt_key" runat="server"></asp:TextBox></td>
                <td> <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click"></asp:Button></td>
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

