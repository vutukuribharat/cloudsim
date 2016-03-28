<%@ Page Title="FILE TOKEN REQUEST" Language="C#" MasterPageFile="~/PrivateMaster.master" AutoEventWireup="true" CodeFile="File_token_requests.aspx.cs" Inherits="File_token_requests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <center>
       <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound">
           <Columns>
               <asp:BoundField DataField="Id" HeaderText="UserID" />
                <asp:BoundField DataField="time" HeaderText="Time"/>
               <asp:TemplateField HeaderText="Status">
                   <ItemTemplate>
                       <asp:Label ID="Label1" runat="server" Text='<%#Eval("status")%>' ></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField>
                   <ItemTemplate>
                       <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("Id")+","+Eval("file_token")%>' CommandName='<%#Eval("time")%>' runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>
                   </ItemTemplate>
               </asp:TemplateField>
           </Columns>
       </asp:GridView>
   </center>
</asp:Content>

