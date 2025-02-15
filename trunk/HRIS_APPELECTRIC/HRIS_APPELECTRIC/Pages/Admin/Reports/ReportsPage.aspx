﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReportsPage.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Reports.ReportsPage" %>

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
                    <h3 class="m-0 text-dark">Reports<small></small></h3>
                    <section class="card">
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box box-primary">
                                        <div class="box-header">
                                            <h4 class="box-title">Reports Page</h4>
                                        </div>
                                        <div class="box-body">
                                            <nav class="mt-2">
                                                <ul id="yw0" class="nav flex-column" data-widget="treeview" role="menu" data-accordion="false">
                                                    <li class="nav-item">
                                                        <h5 class="">MEMBERS</h5>
                                                    </li>
                                                    <li class="nav-item"><a href="MonthlyDeployment.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5"> Monthly New Hire</span></a></li>
                                                    <li class="nav-item"><a href="ActiveEmps.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5"> Summary of Active Employees</span></a></li>
                                                    <li class="nav-item"><a href="MonthlyResignees.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5"> Monthly Resignees</span></a></li>
                                                    <li class="nav-item"><a href="contractualprob.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5"> Probationary and Contractual</span></a></li>
                                                    <li class="nav-item"><a runat="server" onserverclick="btnExport_Click" class="nav-link"><i class="fa fa-cog"></i><span class="h5"> Employee Registry</span></a></li>
                                                    <li class="nav-item">
                                                        <h5 class="">TIMEKEEPING</h5>
                                                    </li>
                                                    <li class="nav-item"><a href="noInOut.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5"> UA Summary</span></a></li>
                                                    <li class="nav-item"><a href="LatesSummary.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5"> Lates Summary</span></a></li>
                                                    <li class="nav-item"><a href="AbsentSummary.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5"> Absent Summary</span></a></li>
                                                    <li class="nav-item"><a href="OBTSummary.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5"> OBT Summary</span></a></li>
                                                    <li class="nav-item"><a href="OTSummary.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5"> Overtime Summary</span></a></li>
                                                    <li class="nav-item"><a href="LeaveSummary.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5"> Leave Summary</span></a></li>
                                                    <%--<li class="nav-item"><a href="../PayrollPages/contributions.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5"> Contributions</span></a></li>--%>
                                                    <li class="nav-item"><a href="LatesReport.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5"> Lates Report</span></a></li>
                                                <li class="nav-item">
                                                        <h5 class="">PAYROLL</h5>
                                                    </li>
                                                    <li class="nav-item"><a href="../PayrollPages/AlphaListReportByCutOffs.aspx" class="nav-link"><i class=" fa fa-cog"></i><span class="h5"> Alpha List</span></a></li>
                                                    <li class="nav-item"><a href="../PayrollPages/contributions.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5"> Contributions</span></a></li>
                                                    <li class="nav-item"><a href="LoanSummary.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5"> Loan</span></a></li>
                                                    <li class="nav-item"><a href="../PayrollPages/PayrollRegisterReport.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5"> Payroll Register</span></a></li>
                                                </ul>
                                            </nav>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </div>
        <!-- /.row (main row) -->
    </aside>
</asp:Content>
