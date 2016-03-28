<%@ Page Title="RIGHTS" Language="C#" MasterPageFile="~/PrivateMaster.master" AutoEventWireup="true" CodeFile="Rights.aspx.cs" Inherits="Rights" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%" OnRowDataBound="GridView1_RowDataBound" >
        <Columns>
            <asp:BoundField HeaderText="UserId" DataField="UserId" />
            <asp:BoundField HeaderText="Upload" DataField="Upload" />
            <asp:BoundField HeaderText="Download" DataField="download" />
            <asp:BoundField HeaderText="Update" DataField="updat" />
            <asp:TemplateField> 
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CommandName='<%#Eval("UserId")%>' Text="Accpt Request" OnClick="Button1_Click"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
       
    </asp:GridView>
</asp:Content>

