<%@ Page Title="UPLOAD DETAILS" Language="C#" MasterPageFile="~/Public_cloud.master" AutoEventWireup="true" CodeFile="Public_upload_details.aspx.cs" Inherits="Public_upload_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="UserId" HeaderText="UserID"/>
            <asp:BoundField DataField="filename" HeaderText="FileName" />
            <asp:BoundField DataField="filesize" HeaderText="FileSize"/>
            <asp:BoundField DataField="time" HeaderText="Uploading Time"/>
        </Columns>
    </asp:GridView>

</asp:Content>

