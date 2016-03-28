<%@ Page Title="USER DETAILS" Language="C#" MasterPageFile="~/PrivateMaster.master" AutoEventWireup="true" CodeFile="UserDetails.aspx.cs" Inherits="UserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <asp:GridView ID="gv_userdetails" runat="server" AutoGenerateColumns="false" OnRowDataBound="gv_userdetails_RowDataBound">
          <Columns>
              <asp:BoundField DataField="userId" HeaderText="UserId" />
              <asp:BoundField DataField="username" HeaderText="Username" />
              <asp:BoundField DataField="gender" HeaderText="Gender" />
              <asp:BoundField DataField="emailid" HeaderText="Emailid" />
              <asp:BoundField DataField="phone" HeaderText="Phone" />
              <asp:BoundField DataField="city" HeaderText="ciyt" />
              <asp:TemplateField>
                  <ItemTemplate>
                      <asp:LinkButton ID="active_link" runat="server" CommandArgument='<%#Eval("activated")%>' OnClick="active_link_Click" Text="Active"/>
                  </ItemTemplate>
              </asp:TemplateField>
          </Columns>
        </asp:GridView>
    </center>
</asp:Content>

