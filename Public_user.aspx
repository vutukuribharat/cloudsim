<%@ Page Title="USER DETAILS" Language="C#" MasterPageFile="~/Public_cloud.master" AutoEventWireup="true" CodeFile="Public_user.aspx.cs" Inherits="Public_user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>               
                <asp:BoundField DataField="userId" HeaderText="UserId" />
                <asp:BoundField DataField="username" HeaderText="UserName" />
                <asp:BoundField DataField="emailid" HeaderText="EmailID" />
                <asp:BoundField DataField="gender" HeaderText="Gender" />
                <asp:BoundField DataField="phone" HeaderText="Phone" />
                <asp:BoundField DataField="city" HeaderText="City" />
                <asp:BoundField DataField="time" HeaderText="Account Created Date" />
            </Columns>
        </asp:GridView>
    </center
</asp:Content>

