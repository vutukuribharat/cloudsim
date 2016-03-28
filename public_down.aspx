<%@ Page Title="DOWNLOAD DETAILS" Language="C#" MasterPageFile="~/Public_cloud.master" AutoEventWireup="true" CodeFile="public_down.aspx.cs" Inherits="public_down" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="true" Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="UserId" HeaderText="UserID"/>
            <asp:BoundField DataField="filename" HeaderText="FileName" />
            <asp:BoundField DataField="filesize" HeaderText="FileSize"/>
            <asp:BoundField DataField="time" HeaderText="Downloading Time"/>
        </Columns>
    </asp:GridView>
</center>
</asp:Content>

