<%@ Page Title="DEDUPLICATION" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="check.aspx.cs" Inherits="check" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <center>

     <fieldset>
         <legend>File Upload</legend>
         <table>
          <tr>         
             <td><asp:Label ID="Label1" runat="server" Text="Choose the file"></asp:Label> </td>
              <td><asp:FileUpload ID="FileUpload1" runat="server" ForeColor="#3399FF"></asp:FileUpload></td>

              <td>  
                  
              </td>

          </tr>
         <%-- <tr>
              <td>
                  <asp:Label ID="lbl_key" runat="server" Text="Enter the file token"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="txt_key" runat="server" ValidationGroup="upload"></asp:TextBox>
              </td>
              <td>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_key" runat="server" ErrorMessage="*" ValidationGroup="upload"></asp:RequiredFieldValidator>
              </td>
          </tr>--%>
          <tr>
              <td></td>
              <td><asp:Button ID="btn_upload" runat="server" Text="Upload" OnClick="btn_upload_Click" ValidationGroup="upload"></asp:Button></td>
              <td><asp:Button ID="btn_referesh" runat="server" Text="Refresh" OnClick="btn_referesh_Click"></asp:Button></td>
          </tr>

      </table>

     </fieldset>

      
      <table>
          <tr>
              <td></td>
              <td><asp:Label ID="Label2" runat="server" Text="Total No of Files:"></asp:Label><asp:Label ID="lblMsg" runat="server" Text=""></asp:Label></td>
          </tr>
         <tr>
              <td> <asp:GridView ID="GridView1" 
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
                            <asp:LinkButton ID="Lnk_delete" runat="server" OnClick="Lnk_delete_Click">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
</td>
              <td>     
              </td>
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

  </center>
</asp:Content>

