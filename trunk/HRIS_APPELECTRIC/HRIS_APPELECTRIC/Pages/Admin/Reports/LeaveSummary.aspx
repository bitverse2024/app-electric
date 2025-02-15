﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveSummary.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Reports.LeaveSummary" %>

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
                    <h3 class="m-0 text-dark">Reports<small> Leaves Summary</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="ReportsPage.aspx" class="btn btn-default"><i class="fa fa-cog"></i>Back to Reports</a>
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
                                                    <label>Start Date:</label>
                                                    <div class="input-group">
                                                        <input style="height: 30px;" class="form-control" id="txt_txtStartDate" name="DTS[BussDate]" type="date" min="1990-01-01" max="2099-12-31" runat="server">
                                                    </div>
                                                    <!-- /.input group -->
                                                </div>
                                                <div class="form-group">
                                                    <label>End Date:</label>
                                                    <div class="input-group">
                                                        <input style="height: 30px;" class="form-control" id="txt_txtEndDate" name="DTS[EndDate]" type="date" min="1990-01-01" max="2099-12-31" runat="server">
                                                    </div>
                                                    <!-- /.input group -->
                                                </div>
                                                <div class="form-group">
                                                    <label>Department:</label>
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
                                                    <label>Company:</label>
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
                                                            OnClick="btnSearch_Click"></asp:Button>
                                                        <asp:Button ID="btnExport" runat="server" class="btn btn-info"
                                                            Text="Export to Excel" OnClick="btnExport_Click"></asp:Button>
                                                        <asp:Button ID="btnExportPDF" runat="server" class="btn btn-info"
                                                            Text="Export to PDF" OnClick="btnExportPDF_Click"></asp:Button>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="list" class="box-primary">
                                        <div id="display-grid" class="grid-view" style="font-size: 10px; overflow-x:auto;">
                                            <%--<div class="right-side">Summary of Active Employees as of <%=year%>.</div>--%>
                                            <asp:GridView ID="GridOT" runat="server" AutoGenerateColumns="False"
                                                ShowFooter="True" CssClass="item table table-striped table-bordered table-condensed"
                                                GridLines="None" AllowPaging="True" Font-Names="Segoe UI" ShowHeaderWhenEmpty="true"
                                                ForeColor="Black" ViewStateMode="Enabled" PageSize="100" Width="100%">
                                                <EmptyDataTemplate>
                                                    <center><h1>NO LEAVES AVAILABLE</h1></center>
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkName" Text='Name' runat="server" CommandName="Sort" CommandArgument="Name"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>

                                                            <asp:Label ID="lblName" Text='<%# Eval("Name") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkDateFrom" Text='Date From' runat="server" CommandName="Sort" CommandArgument="DateFrom"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDateFrom" Text='<%# Eval("DateFrom") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkDateTo" Text='Leave Hours' runat="server" CommandName="Sort" CommandArgument="LeaveHours"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDateTo" Text='<%# Eval("LeaveHours") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkEarned" Text='Earned' runat="server" CommandName="Sort" CommandArgument="Earned"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEarned" Text='<%# Eval("Earned") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkUsed" Text='Used' runat="server" CommandName="Sort" CommandArgument="Used"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUsed" Text='<%# Eval("Used") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkBalance" Text='Balance' runat="server" CommandName="Sort" CommandArgument="Balance"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBalance" Text='<%# Eval("Balance") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkLeaveType" Text='Leave Type' runat="server" CommandName="Sort" CommandArgument="LeaveType"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLeaveType" Text='<%# Eval("LeaveType") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkReason" Text='Reason' runat="server" CommandName="Sort" CommandArgument="Reason"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblReason" Text='<%# Eval("Reason") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkStatus" Text='Status' runat="server" CommandName="Sort" CommandArgument="Status"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatus" Text='<%# Eval("Status") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkDateFiled" Text='Date Filed' runat="server" CommandName="Sort" CommandArgument="DateFiled"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDateFiled" Text='<%# Eval("DateFiled") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkDateApproved1" Text='Date Approved 1' runat="server" CommandName="Sort" CommandArgument="DateApproved1"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDateApproved1" Text='<%# Eval("DateApproved1") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkApprover1" Text='Approver1' runat="server" CommandName="Sort" CommandArgument="Approver1"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApprover1" Text='<%# Eval("Approver1") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkDateApproved2" Text='Date Approved 2' runat="server" CommandName="Sort" CommandArgument="DateApproved2"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDateApproved2" Text='<%# Eval("DateApproved2") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkApprover2" Text='Approver 2' runat="server" CommandName="Sort" CommandArgument="Approver2"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApprover2" Text='<%# Eval("Approver2") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkDays" Text='Days' runat="server" CommandName="Sort" CommandArgument="Days"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDays" Text='<%# Eval("Days") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkPosition" Text='Position' runat="server" CommandName="Sort" CommandArgument="Position"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPosition" Text='<%# Eval("Position") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkDepartment" Text='Department' runat="server" CommandName="Sort" CommandArgument="Department"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDepartment" Text='<%# Eval("Department") %>' runat="server"></asp:Label>
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
