﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeMaster.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees.EmployeeMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        /*gridview*/
        /*.table table > tbody > tr > td {
            display: inline-block;

        }*/
        .table {
            /*display: inline-block;*/
            padding-left: 0;
            margin: 20px 0;
            border-radius: 4px;
        }
        .table table > tbody > tr > td > a ,
        .table table > tbody > tr > td > span {
        position: relative;
        float: left;
        padding: 6px 12px;
        margin-left: -1px;
        line-height: 1.42857143;
        color: #337ab7;
        text-decoration: none;
        background-color: #fff;
        border: 1px solid #ddd;


        }

        .table table > tbody > tr > td > span {
        z-index: 3;
        color: #fff;
        cursor: default;
        background-color: #337ab7;
        border-color: #337ab7;


        }

        .table table > tbody > tr > td:first-child > a,
        .table table > tbody > tr > td:first-child > span {
        margin-left: 0;
        border-top-left-radius: 4px;
        border-bottom-left-radius: 4px;
        }

        .table table > tbody > tr > td:last-child > a,
        .table table > tbody > tr > td:last-child > span {
        border-top-right-radius: 4px;
        border-bottom-right-radius: 4px;
        }

        .table table > tbody > tr > td > a:hover,
        .table   table > tbody > tr > td > span:hover,
        .table table > tbody > tr > td > a:focus,
        .table table > tbody > tr > td > span:focus {
        z-index: 2;
        color: #23527c;
        background-color: #eee;
        border-color: #ddd;

        }
        /*end gridview */

    </style>
    <div>
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
                    <h3 class="m-0 text-dark">Employees<small> 201</small></h3>
                    <section class="card">
                            <div class="card-header">
                                <a href="<%= ResolveUrl("~/Pages/Admin/Employees/CreateEmployee.aspx")%>" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Add new Employee</span></a>
                                <a href="EmployeeMaster.aspx" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                                <a href="<%= ResolveUrl("~/Pages/Admin/Employees/COE.aspx")%>" class="btn btn-default"><i class="fa fa-file"></i><span class="h6">COE</span></a>
                                <a id="A3" runat="server" onserverclick="btnExport_Click" class="btn btn-default"><i class="fa fa-arrow-circle-o-up"></i><span class="h6">Export to Excel</span></a>
                                   <%if (Session["EMP_ID"].ToString() == "00000")
                                    { %><a id="A2" href="<%=ResolveUrl("~/Pages/Admin/Employees/ImportEmployeeList.aspx")%>" class="btn btn-default"><i class="fa fa-arrow-circle-o-down"></i><span class="h6">Import</span></a><%} %>
                            </div>
                            <div class="card-body">
                                <div class="content">
                                    <div class="container-fluid">
                                            <div class="box-body">
                                                    <%--<div class="list">--%>
                                                        <div id="display-grid" class="grid-view box-body">
                                                            <asp:GridView ID="GridUserList" runat="server" AutoGenerateColumns="False"
                                                                        ShowFooter="True" CssClass="table table-bordered table-striped table-responsive p-0 dataTable"
                                                                        GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                                        ForeColor="Black" OnRowCommand="GridUserList_RowCommand"
                                                                        OnPageIndexChanging="GridUserList_PageIndexChanging"
                                                                        ViewStateMode="Enabled" PageSize="10" ShowHeader="true" ShowHeaderWhenEmpty="true">
                                                                <PagerStyle HorizontalAlign = "Center" />
                                                                        <EmptyDataTemplate>
                                                                            <center><h1>NO USERS AVAILABLE</h1></center>
                                                                        </EmptyDataTemplate>
                                                                        <Columns>

                                                                            <asp:TemplateField>
                                                                                <HeaderTemplate>
                                                                                    <asp:LinkButton ID="lblEmpNo" Text="Employee No." Width="100%" runat="server" CommandName="Sort" CommandArgument="EmployeeNo"></asp:LinkButton><br />
                                                                                    <asp:TextBox ID="txtSearchEmpNo" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>

                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>

                                                                                    <asp:Label ID="lblEmpNo" Width="100%" Text='<%# Eval("EmployeeNo") %>' runat="server"></asp:Label>

                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField>
                                                                                <HeaderTemplate>
                                                                                    <asp:LinkButton ID="lblFullname" Text="Full Name" Width="100%" runat="server" CommandName="Sort" CommandArgument="FullName"></asp:LinkButton><br />
                                                                                    <asp:TextBox ID="txtSearchFUllName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>

                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblFullName" Width="100%" Text='<%# Eval("FullName") %>' runat="server"></asp:Label>

                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField>
                                                                                <HeaderTemplate>
                                                                                    <asp:LinkButton ID="lblPosition" Text='Position' Width="100%" runat="server" CommandName="Sort" CommandArgument="Position"></asp:LinkButton><br />
                                                                                    <asp:TextBox ID="txtSearchPosition" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblPosition" Width="100%" Text='<%# Eval("Position") %>' runat="server"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField>
                                                                                <HeaderTemplate>

                                                                                    <asp:LinkButton ID="lblDepartment" Text='Department' Width="100%" runat="server" CommandName="Sort" CommandArgument="Department"></asp:LinkButton><br />
                                                                                    <asp:TextBox ID="txtSearchDepartment" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>

                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>

                                                                                    <asp:Label ID="lblDepartment" Width="100%" Text='<%# Eval("Department") %>' runat="server"></asp:Label>

                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField>
                                                                                <HeaderTemplate>
                                                                                    <asp:LinkButton ID="lblRank" Text='Rank' Width="100%" runat="server" CommandName="Sort" CommandArgument="Rank"></asp:LinkButton><br />
                                                                                    <asp:TextBox ID="txtSearchRank" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>

                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblRank" Width="100%" Text='<%# Eval("Rank") %>' runat="server"></asp:Label>

                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField>
                                                                                <HeaderTemplate>
                                                                                    <asp:LinkButton ID="lblStatus" Text='Status' Width="100%" runat="server" CommandName="Sort" CommandArgument="Status"></asp:LinkButton><br />
                                                                                    <asp:TextBox ID="txtSearchStatus" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>

                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblStatus" Width="100%" Text='<%# Eval("Status") %>' runat="server"></asp:Label>

                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">

                                                                                <HeaderTemplate>
                                                                                    <asp:LinkButton ID="lblActive" Text='Active' runat="server" CommandName="Sort" CommandArgument="Active" Width="115px"></asp:LinkButton><br />                                                                                   
                                                                                    <%--<asp:TextBox ID="txtSearchActive" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>--%>
                                                                                    <asp:DropDownList ID="ddlSearch" runat="server" OnSelectedIndexChanged="ddlChange" AutoPostBack="true" EnableViewState="true" Width="100%">
                                                                                        <asp:ListItem Text="Select Status" Value=""></asp:ListItem>
                                                                                        <asp:ListItem Value="Y" Text="Active"></asp:ListItem>
                                                                                        <asp:ListItem Value="N" Text="Inactive"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </HeaderTemplate>

                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblActive" Width="70px" class='<%# Eval("Active")=="ACTIVE" ? "badge bg-success float-md-none" : Eval("Active")=="INACTIVE" ? "badge bg-danger float-md-none" : "badge bg-success float-md-none" %>' Text='<%# Eval("Active") %>' runat="server"></asp:Label>

                                                                                </ItemTemplate>

                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField>
                                                                                <HeaderTemplate>
                                                                                    <asp:LinkButton ID="lblControls" Width="75px" Text='' runat="server" CommandName="Sort" CommandArgument="Active"></asp:LinkButton><br />
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <center>
                                                                            <%--<asp:Button ID="btnAdd" CssClass="btn-instagram btn-xs" runat="server"  Text="View" CommandName="view" CommandArgument='<%# Eval("EmployeeNo") %>'  />
                                                                            <asp:Button ID="btnUpdate" CssClass="btn-success btn-xs" runat="server" Text="Update"   CommandName="update" CommandArgument='<%# Eval("EmployeeNo") %>'  />
                                                                            <asp:Button ID="btnDelete" CssClass="btn-danger btn-xs" runat="server" Text="Delete"  CommandName="del" CommandArgument='<%# Eval("EmployeeNo") %>'  />--%>

                                                                                        <asp:LinkButton ID="btnView" runat="server" ForeColor="Black" Font-Size="" CommandName="view" CommandArgument='<%# Eval("EmployeeNo") %>'><i class="fa fa-eye"></i></asp:LinkButton> &nbsp;
                                                                                        <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Black" Font-Size="" CommandName="update" CommandArgument='<%# Eval("EmployeeNo") %>'><i class="fa fa-edit"></i></asp:LinkButton>&ensp;
                                                                                        <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Black" Font-Size=""  CommandName="del" CommandArgument='<%# Eval("EmployeeNo") %>'><i class="fa fa-trash"></i></asp:LinkButton>
                                                                                    </center>
                                                                                </ItemTemplate>

                                                                            </asp:TemplateField>
                                                                            <%--<asp:CommandField HeaderText="Cancel Item" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-xs btn-danger"  /> --%>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                        </div>
                                                    <%--</div>--%>
                                                </div>
                                    </div>
                                </div>
                            </div>
                            <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
                            <!-- search-form -->
                    </section>
                </div>
        </div>
    </div>
    </div>



    <div class="modal fade" id="listmodal">
        <div class="modal-dialog">
            <div class="modal-content">

                <asp:UpdatePanel ID="upListDetails" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                    <ContentTemplate>

                        <div class="modal-header">
                              <h4 class="modal-title">
                                <asp:Label ID="Label3" runat="server" Text="Edit Information"></asp:Label></h4>
                            
                            <asp:LinkButton ID="lnkbtnXlist" CssClass="close" runat="server"
                                OnClick="lnkbtnXlist_Click">
                            <span>&times;</span>
                            </asp:LinkButton>
                          
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblEmpNo" Text="" runat="server"></asp:Label><br>
                            <asp:DropDownList ID="deleteDropDownList" runat="server">
                                <asp:ListItem Enabled="true" Text="Select Action" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="ACTIVATE" Value="Y"></asp:ListItem>
                                <asp:ListItem Text="DEACTIVATE" Value="N"></asp:ListItem>
                                <%--<asp:ListItem Text="ARCHIVE" Value="A"></asp:ListItem>--%>
                                <asp:ListItem Text="PERMANENTLY DELETE" Value="D"></asp:ListItem>


                            </asp:DropDownList>

                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Apply Action"
                                OnClick="btnDoDelete_Click"></asp:Button>


                        </div>


                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnsaveUpdate" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>

    <div class="modal fade" id="mbox_modal" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">

                <asp:UpdatePanel ID="updateMbox" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="HiddenDeleteNo" runat="server" />
                        <div class="modal-header">
                              <h4 class="modal-title">
                                <asp:Label ID="Label1" runat="server" Text="Confirmation"></asp:Label></h4>
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <%--<asp:LinkButton ID="lnk_closembox" CssClass ="close" runat="server" 
                            onclick="closeMbox_click" >
                            <span>&times;</span>
                        </asp:LinkButton>--%>
                          
                        </div>
                        <div class="modal-body">
                            Permanent deletion of this record is irreparable.
                        Do you still want to proceed?
                        
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnYes" runat="server" Text="Yes" CommandArgument="YES"
                                OnClick="btnConfirmClick"></asp:Button>
                            <asp:Button ID="btnNo" runat="server" Text="No" CommandArgument="NO"
                                OnClick="btnConfirmClick"></asp:Button>


                        </div>


                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnYes" />
                        <asp:PostBackTrigger ControlID="btnNo" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>
</asp:Content>
