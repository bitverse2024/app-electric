﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="OBTSummary.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Reports.OBTSummary" %>

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
        <div class="col-md-12">
            <div class="content">
                <div class="container-fluid">
                    <div class="container"></div>
                    <h3 class="m-0 text-dark">Reports<small> OBT Summary</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="ReportsPage.aspx" class="btn btn-default"><i class="fa fa-cog"></i><span class="h6">Back to Reports</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <!-- general form elements -->
                                            <div class="box box-primary">
                                                <div class="box-header">
                                                    <h5 class="box-title">Select Date</h5>
                                                </div>
                                                <!-- /.box-header -->
                                                <div class="form-group">
                                                    <span class="h5">
                                                        <label>Start Date:</label></span>
                                                    <div class="input-group">
                                                        <input style="height: 30px;" class="form-control" id="txt_txtBussDate" type="date" min="1990-01-01" max="2099-12-31" runat="server">
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <span class="h5">
                                                        <label>End Date:</label></span>
                                                    <div class="input-group">
                                                        <input style="height: 30px;" class="form-control" id="txt_txtEndDate" type="date" min="1990-01-01" max="2099-12-31" runat="server">
                                                    </div>
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
                                                        <asp:Button ID="btnExport" runat="server" class="btn btn-info"
                                                            Text="Export to Excel" ValidationGroup="OBT" OnClick="btnExport_Click"></asp:Button>
                                                        <asp:Button ID="btnExportPDF" runat="server" class="btn btn-info"
                                                            Text="Export to PDF" ValidationGroup="OBT" OnClick="btnExportPDF_Click"></asp:Button>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="list" class="box-body">
                                          <div style="overflow-x: auto;" id="display-grid" class="grid-view">
                                            <%--<div class="right-side">Summary of Active Employees as of <%=year%>.</div>--%>
                                            <asp:GridView ID="GridOBT" runat="server" AutoGenerateColumns="False"
                                                ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                ForeColor="Black"
                                                ViewStateMode="Enabled" PageSize="1000">
                                                <EmptyDataTemplate>
                                                    <center><h1>NO OBT AVAILABLE</h1></center>
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-Width="120px">
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkName" CssClass="h8" Text='Name' runat="server" CommandName="Sort" CommandArgument="Name"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblName" CssClass="h5" Text='<%# Eval("Name") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkPosition" CssClass="h8" Text='Position' runat="server" CommandName="Sort" CommandArgument="Position"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPosition" CssClass="h5" Text='<%# Eval("Position") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkDepartment" CssClass="h8" Text='Department' runat="server" CommandName="Sort" CommandArgument="Department"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDepartment" CssClass="h5" Text='<%# Eval("Department") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkTripDate" CssClass="h8" Text='Trip Date' runat="server" CommandName="Sort" CommandArgument="TripDate"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTripDate" CssClass="h5" Text='<%# Eval("TripDate") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkApproveDate" CssClass="h8" Text='Date Approved/Cancelled' runat="server" CommandName="Sort" CommandArgument="ApproveDate"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApproveDate" CssClass="h5" Text='<%# Eval("ApproveDate") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkApproving" CssClass="h8" Text='Approving' runat="server" CommandName="Sort" CommandArgument="Approving"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApproving" CssClass="h5" Text='<%# Eval("Status") %>' runat="server"></asp:Label>
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
