<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.ViewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    ViewUser<asp:Button ID="Button1" runat="server" Text="Button" 
        onclick="btnOnclick" />

        <div class="modal fade" id="MODAL_SAMP">
    <div class="modal-dialog">
        <div class="modal-content">

            <asp:UpdatePanel ID="UpdatePanelModal" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                <ContentTemplate>
                    
                    <div class="modal-header">
                        <asp:LinkButton ID="lnkbtnXlist" CssClass ="close" runat="server" 
                            onclick="lnkbtnXlist_Click" >
                            <span>&times;</span>
                        </asp:LinkButton>
                        <h4 class="modal-title"><asp:Label ID="Label3" runat="server" Text="Edit Information"></asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblEmpNo" Text="" runat="server"></asp:Label>
                        <asp:DropDownList ID="deleteDropDownList" runat="server">
                        <asp:ListItem Enabled="true" Text="Select Action" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="ACTIVATE" Value="Y"></asp:ListItem>
                        <asp:ListItem Text="DEACTIVATE" Value="N"></asp:ListItem>
                        <asp:ListItem Text="ARCHIVE" Value="A"></asp:ListItem>
                        <asp:ListItem Text="PERMANENTLY DELETE" Value="D"></asp:ListItem>


                        </asp:DropDownList>
                        
                    </div>
                    <div class="modal-footer">
                       <asp:Button ID="btnsaveUpdate" runat="server" Text="Apply Action"></asp:Button>
                           
                       
                    </div>
                   

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
</div>
</asp:Content>
