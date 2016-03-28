<%@ Page Title="FILE TOKEN DETAILS" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="user_file_token.aspx.cs" Inherits="user_file_token" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <center>
<asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="false">
    <Columns>
          <asp:BoundField HeaderText="Requested Time" DataField="time"/>
          <asp:BoundField HeaderText="File Token" DataField="file_token"/>
    </Columns>
</asp:GridView>
   </center>
</asp:Content>

