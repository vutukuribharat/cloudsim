<%@ Page Title="UPDATE RIGHTS" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="Update_rights.aspx.cs" Inherits="Update_rights" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="Upload" DataField="Upload" />
             <asp:BoundField HeaderText="Download" DataField="download" />

            <asp:TemplateField HeaderText="Update">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("updat")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btn_request" runat="server" Text="Send request" OnClick="btn_request_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>

</asp:Content>

