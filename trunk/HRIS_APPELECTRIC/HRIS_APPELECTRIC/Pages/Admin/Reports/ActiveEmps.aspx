﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ActiveEmps.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Reports.ActiveEmps" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <aside class="right-side">
        <!-- Small boxes (Stat box) -->
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6"></div>
                    <div class="col-sm-6"></div>
                </div>
            </div>
        </div>
        <div class="" id="yw0">
            <div class="portlet-content" style="padding-left: 10px;">
                <ul class="nav nav-pills">
                    <li class=""></li>
                    <li class=""></li>
                    <li class=""></li>
                </ul>
            </div>
        </div>
        <div class="col-md-12">
            <div class="content">
                <div class="container-fluid">
                    <div class="container"></div>
                    <h3 class="m-0 text-dark">Reports<small> Summary of Active Office Staff</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="ReportsPage.aspx" class="btn btn-default"><i class="fa fa-cog"></i><span class="h6">Back to Reports</span></a>
                            <a href="#" runat="server" onserverclick="ExportToPDF" class="btn btn-default"><i class="fa fa-book"></i><span class="h6">Print to PDF</span></a>
                            <a href="#" runat="server" onserverclick="btnExport_Click" class="btn btn-default"><i class="fa fa-pencil"></i><span class="h6">Export to EXCEL</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div id="list" class="box-body">
                                     <div style="overflow-x: auto;" id="display-grid" class="grid-view">
                                            <div class="right-side h6">Summary of Active Employees as of <%=year%>.</div>
                                            <asp:GridView ID="GridActive" runat="server" AutoGenerateColumns="False"
                                                ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                GridLines="None" AllowPaging="True" Font-Names="Segoe UI" OnRowCommand="GridActive_RowCommand"
                                                ForeColor="Black"
                                                ViewStateMode="Enabled" PageSize="1000">
                                                <EmptyDataTemplate>
                                                    <center><h1>NO EMPLOYEE AVAILABLE</h1></center>
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-Width="120px">
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkLastName" CssClass="h8" Text='Last Name' runat="server" CommandName="Sort" CommandArgument="LastName"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLastName" CssClass="h5" Text='<%# Eval("LastName") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkSuffix" CssClass="h8" Text='Suffix' runat="server" CommandName="Sort" CommandArgument="Suffix"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSuffix" CssClass="h5" Text='<%# Eval("Suffix") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkFirstName" CssClass="h8" Text='First Name' runat="server" CommandName="Sort" CommandArgument="FirstName"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFirstName" CssClass="h5" Text='<%# Eval("FirstName") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkMiddleName" CssClass="h8" Text='Middle Name' runat="server" CommandName="Sort" CommandArgument="MiddleName"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMiddleName" CssClass="h5" Text='<%# Eval("MiddleName") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkStatus" CssClass="h8" Text='Status' runat="server" CommandName="Sort" CommandArgument="Status"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatus" CssClass="h5" Text='<%# Eval("Status") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkYear" CssClass="h8" Text='Tenure' runat="server" CommandName="Sort" CommandArgument="StartDate"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblYear" CssClass="h5" Text='<%# Eval("StartDate") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </div>

    </aside>
</asp:Content>
