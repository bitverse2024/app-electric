<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div>--%>
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6"></div>
                    <div class="col-sm-6"></div>
                </div>
            </div>
        </div>
        <div class="col-md-12">
            <div class="content">
                <div class="container-fluid">
                    <div class="container"></div>
                    <h3 class="m-0 text-dark">Admin<small> Users</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="AdminPage.aspx" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Back</span></a>
                            <a href="UserList.aspx" class="btn btn-default"><i class="fa fa-th-list"></i><span class="h6">List</span></a>
                            <%--<a href="AdminPage.aspx" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Admin Page</span></a>--%>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">
                                        <div class="search-form">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <div class="row">
                                                        <div class="panel-body">
                                                            <div class="col-md-12">
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <div class="panel-body">
                                                                            <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto">

                                                                                <div>
                                                                                    <asp:GridView ID="GridUserList" runat="server" AutoGenerateColumns="False"
                                                                                        ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                                                        GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                                                        ForeColor="Black" OnRowCommand="GridUserList_RowCommand"
                                                                                        OnPageIndexChanging="GridUserList_PageIndexChanging"
                                                                                        ViewStateMode="Enabled">
                                                                                        <EmptyDataTemplate>
                                                                                            <center><h1>NO USERS AVAILABLE</h1></center>
                                                                                        </EmptyDataTemplate>
                                                                                        <Columns>
                                                                                            <asp:TemplateField>
                                                                                                <HeaderTemplate>
                                                                                                    <asp:LinkButton ID="lnkFullName" Text='Profile' runat="server" CommandName="Sort" CommandArgument="Profile"></asp:LinkButton><br />
                                                                                                    <asp:TextBox ID="txtSearchFullName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblFullName" CssClass="" Text='<%# Eval("Profile") %>' runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <HeaderTemplate>
                                                                                                    <asp:LinkButton ID="lnkEmpNo" CssClass="h8" Text='EmployeeNo' runat="server" CommandName="Sort" CommandArgument="EmployeeNo"></asp:LinkButton><br />
                                                                                                    <asp:TextBox ID="txtSearchEmpNo" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblEmpNo" CssClass="" Text='<%# Eval("EmployeeNo") %>' runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <HeaderTemplate>
                                                                                                    <asp:LinkButton ID="lnkUsername" CssClass="h8" Text='Username' runat="server" CommandName="Sort" CommandArgument="Username"></asp:LinkButton><br />
                                                                                                    <asp:TextBox ID="txtSearchUsername" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblUsername" CssClass="" Text='<%# Eval("Username") %>' runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <HeaderTemplate>
                                                                                                    <asp:LinkButton ID="lnkEmail" CssClass="h8" Text='Email' runat="server" CommandName="Sort" CommandArgument="Email"></asp:LinkButton><br />
                                                                                                    <asp:TextBox ID="txtSearchEmail" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblEmail" CssClass="" Text='<%# Eval("Email") %>' runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <HeaderTemplate>
                                                                                                    <asp:LinkButton ID="lnkAcctStatus" CssClass="h8" Text='Account Status' runat="server" CommandName="Sort" CommandArgument="Account Status"></asp:LinkButton><br />
                                                                                                    <asp:TextBox ID="txtSearchStatus" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblAcctStatus" CssClass="" Text='<%# Eval("Account Status") %>' runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderStyle-Width="10%">
                                                                                                <ItemTemplate>
                                                                                                    <center>
			                                                                    <asp:LinkButton ID="btnView" runat="server" ForeColor="Black" Font-Size="Large" CommandName="view" CommandArgument='<%# Eval("EmployeeNo") %>'><i class="fa fa-eye"></i></asp:LinkButton> &nbsp;
			                                                                    <%--<asp:LinkButton ID="btnUpdate" runat="server" ForeColor="Black" Font-Size="Medium" CommandName="upd" CommandArgument='<%# Eval("EmployeeNo") %>'><i class="fa fa-edit"></i></asp:LinkButton>&ensp;--%>			
		                                                                    </center>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <%--<asp:CommandField HeaderText="Cancel Item" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-xs btn-danger"  /> --%>
                                                                                        </Columns>
                                                                                    </asp:GridView>

                                                                                </div>

                                                                            </asp:Panel>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>



                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <!-- search-form -->

                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    <%--Modal update--%>

    <div class="modal fade" id="listmodal">
        <div class="modal-dialog">
            <div class="modal-content">

                <asp:UpdatePanel ID="upListDetails" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                    <ContentTemplate>

                        <div class="modal-header">
                            <asp:LinkButton ID="lnkbtnXlist" CssClass="close" runat="server"
                                OnClick="lnkbtnXlist_Click">
                            <span>&times;</span>
                            </asp:LinkButton>
                            <h4 class="modal-title">
                                <asp:Label ID="Label3" runat="server" Text="Edit Information"></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="HiddenEmpID" runat="server" />
                            <asp:Label ID="lblfname" Text="" runat="server"></asp:Label>
                            Username:
                            <asp:TextBox ID="txtbox_username" runat="server"></asp:TextBox>
                            Password:
                            <asp:TextBox ID="txtbox_password" runat="server"></asp:TextBox>
                            <asp:DropDownList ID="drpdwn_acctstatus" runat="server">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Unlocked</asp:ListItem>
                                <asp:ListItem Value="2">Locked</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Apply Action" UseSubmitBehavior="true"
                                OnClick="btnsaveUpdate_Click"></asp:Button>


                        </div>


                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>
    <%--End of Modal update--%>

    <%--Modal view--%>

    <div class="modal fade" id="ViewUserModal">
        <div class="modal-dialog">
            <div class="modal-content">

                <asp:UpdatePanel ID="UPViewUser" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                    <ContentTemplate>

                        <div class="modal-header">
                            <asp:LinkButton ID="lnkbtnXlist2" CssClass="close" runat="server"
                                OnClick="lnkbtnXlist2_Click">
                            <span>&times;</span>
                            </asp:LinkButton>
                            <h4 class="modal-title">
                                <asp:Label ID="Label1" runat="server" Text="View Information"></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:Label ID="Label2" Text="" runat="server"></asp:Label>
                            EmployeeNo:
                            <asp:Label ID="mlblempno" runat="server" Text="Label"></asp:Label>
                            Username:
                            <asp:Label ID="mlblusrname" runat="server" Text="Label"></asp:Label>
                            Email:
                            <asp:Label ID="mlblemail" runat="server" Text="Label"></asp:Label>
                            Roles: 
                            <asp:Label ID="mlblroles" runat="server" Text="Label"></asp:Label>


                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnexitviewmodal" runat="server" Text="Back" UseSubmitBehavior="true"
                                OnClick="btnexitviewmodal_Click"></asp:Button>


                        </div>


                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>
</asp:Content>
