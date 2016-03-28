<%@ Page Title="UPDATE DETAILS" Language="C#" MasterPageFile="~/Public_cloud.master" AutoEventWireup="true" CodeFile="Update_details.aspx.cs" Inherits="Upload_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="UserId" HeaderText="UserID"/>
            <asp:BoundField DataField="filename" HeaderText="FileName" />
            <asp:BoundField DataField="filesize" HeaderText="FileSize"/>
            <asp:BoundField DataField="time" HeaderText="Updating Time"/>
        </Columns>
    </asp:GridView>
</center>
</asp:Content>

