﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="contractualprob.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Reports.contractualprob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                <h3 class="m-0 text-dark">Reports<small> Summary of Contractual and Probationary Employees</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="ReportsPage.aspx" class="btn btn-default"><i class="fa fa-cog"></i><span class="h6">Back to Reports</span></a>
                        <%--<a href="#" runat="server" onserverclick="ExportToPDF" class="btn btn-default"><i class="fa fa-book"></i><span class="h6">Print to PDF</span></a>--%>
                        <%--<a href="#" runat="server" onserverclick="btnExport_Click" class="btn btn-default"><i class="fa fa-pencil"></i><span class="h6">Export to EXCEL</span></a>--%>
                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="row">
                                    <div class="col-md-6">
                                        <!-- general form elements -->
                                        <div class="box box-primary">
                                            <div class="form-group">
                                                <span class="h5">
                                                    <label>Status:</label></span>
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        <i class="fa fa-building"></i>
                                                    </div>
                                                    <asp:DropDownList ID="ddlStat" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="PROBATIONARY" Text="PROBATIONARY"></asp:ListItem>
                                                        <asp:ListItem Value="CONTRACTUAL" Text="CONTRACTUAL"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <!-- /.input group -->
                                            </div>
                                            <div class="form-group">
                                                <span class="h5">
                                                    <label>Department:</label></span>
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        <i class="fa fa-building"></i>
                                                    </div>
                                                    <asp:DropDownList ID="ddlDept" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="0" Text="ALL"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <!-- /.input group -->
                                            </div>

                                            <div class="form-group">
                                                <span class="h5">
                                                    <label>Company:</label></span>
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        <i class="fa fa-building"></i>
                                                    </div>
                                                    <asp:DropDownList ID="ddlComp" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="0" Text="ALL"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <!-- /.input group -->
                                                <br />
                                                <div class="footer">
                                                    <asp:Button ID="btnSearch" runat="server" class="btn btn-info" Text="Search"
                                                        OnClick="btnSearch_Click" ValidationGroup="OBT"></asp:Button>
                                                    <%--<asp:Button ID="btnExport" runat="server" class="btn btn-info"
                                                        Text="Export to Excel" ValidationGroup="OBT" OnClick="btnExport_Click"></asp:Button>--%>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="list" class="box-body">
                              <div style="overflow-x: auto;" id="display-grid" class="grid-view box-body">
                                        <asp:GridView ID="GridActive" runat="server" AutoGenerateColumns="False"
                                            ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                            GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                            ForeColor="Black" ShowHeaderWhenEmpty="true"
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
                                                        <asp:LinkButton ID="lnkYear" CssClass="h8" Text='Tenure' runat="server" CommandName="Sort" CommandArgument="Years"></asp:LinkButton><br />
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
</asp:Content>
