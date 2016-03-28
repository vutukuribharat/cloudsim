<%@ Page Title="DOWNLOAD" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="down.aspx.cs" Inherits="down" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <style type="text/css">
.modalBackground
{
background-color: Gray;
filter: alpha(opacity=80);
opacity: 0.8;
z-index: 10000;
}
</style>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Total Number of Files:"></asp:Label></td>
            <td> <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label></td>
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
                            <asp:LinkButton ID="lnk_download" runat="server" OnClick="lnk_download_Click" >Download</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Button ID="btnShowPopup" runat="server" style="display:none" />
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup" CancelControlID="btnCancel" BackgroundCssClass="modalBackground" ></cc1:ModalPopupExtender>
<asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="269px" Width="400px" style="display:none">
<table width="100%" style="border:Solid 3px #82CAFA; width:100%; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:#82CAFA">
<td colspan="2" style=" height:10%; color:White; font-weight:bold; font-size:larger" align="center">Download Details</td>
</tr>
<tr>
<td align="right">
FileName:
</td>
<td>
    <asp:TextBox ID="txt_Filename" runat="server" ReadOnly="true"></asp:TextBox>
</td>
</tr>
<tr>
<td align="right">
FileSize:
</td>
<td>
<asp:TextBox ID="txt_filesize" ReadOnly="true" runat="server"/>
</td>
</tr>
<tr>
<td align="right">
 File Token:
</td>
<td>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<asp:TextBox ID="txt_convergentKey" ReadOnly="true" runat="server" />
    <asp:Label ID="lbl_status" runat="server" Text=" "></asp:Label>
    <asp:Label ID="lbl_filepath" runat="server" Text="Label" Visible="false"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
</td>
</tr>
<tr>
<td>
</td>
<td>
    <asp:Button ID="Button1" runat="server" Text="Download" OnClick="Button1_Click"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
</td>
</tr>
</table>
</asp:Panel>        
         

         <asp:ListBox ID="drop1" Rows="3" runat="server" Visible="false">
                    <asp:ListItem Selected="true">All</asp:ListItem>
                    <asp:ListItem>pdf</asp:ListItem>
                    <asp:ListItem>jpg</asp:ListItem>
                    <asp:ListItem>png</asp:ListItem>
                    <asp:ListItem>txt</asp:ListItem>
                    <asp:ListItem>doclt</asp:ListItem> 
                </asp:ListBox>
</asp:Content>

