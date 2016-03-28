<%@ Page Title="UPDATE" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="Update.aspx.cs" Inherits="Update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Total No of files:"></asp:Label></td>
            <td> <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label></td>
            
        </tr>
    </table>
   
 <asp:GridView ID="GridView1" 
                AllowPaging="true"  AutoGenerateColumns="false"
                OnPageIndexChanging="GridView1_PageIndexChanging" runat="server">

                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="File Length">
                        <ItemTemplate>
                            <asp:Label ID="lblLen" runat="server" Text='<%#Eval("Length")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="File Extention">
                        <ItemTemplate>
                            <asp:Label ID="lblFileType" runat="server" Text='<%#Eval("Extension")%>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Creation Date & Time">
                        <ItemTemplate>
                            <asp:Label ID="lblDateTime" runat="server" Text='<%#Eval("CreationTime")%>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Lnk_delete" runat="server" OnClick="Lnk_delete_Click">Update</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
    
    <table>
        <tr>
            <td><textarea runat="server" id="textBoxContents" visible="false" style="height:100%;width:100%"></textarea></td>
        </tr>
    </table>
    <table>
        <tr>
        <td> <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" Visible="false" /></td>
        <td>
            <asp:Button ID="Button2" runat="server" Text="Cancel" Visible="false" OnClick="Button2_Click" /></td>
            </tr>
    </table>
   

         <asp:ListBox ID="drop1" Rows="3" runat="server" Visible="false">
                    <asp:ListItem Selected="true">All</asp:ListItem>
                    <asp:ListItem>pdf</asp:ListItem>
                    <asp:ListItem>jpg</asp:ListItem>
                    <asp:ListItem>png</asp:ListItem>
                    <asp:ListItem>txt</asp:ListItem>
                    <asp:ListItem>doclt</asp:ListItem> 
                </asp:ListBox>
</asp:Content>

