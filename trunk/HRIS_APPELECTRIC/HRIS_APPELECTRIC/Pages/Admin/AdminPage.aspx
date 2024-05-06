<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.AdminPage" %>

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
                <h3 class="m-0 text-dark">Admin<small></small></h3>
                <section class="card">
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="box-header">
                                    <h4 class="box-title">Admin Page</h4>
                                </div>
                                <%if (Session["ROLES"].ToString() == "admin")
                                    { %>
                                <div class="box-body">
                                    <ul class="nav nav-pills nav-sidebar flex-column">
                                        <li class="nav-item">
                                            <h5>DATA MAINTENANCE</h5>
                                        </li>
                                        <li class="nav-item"><a href="CompanyList.aspx" class="nav-link" style="color:black"><i class="fa fa-cog"></i><span class="h5"> Companies</span></a></li>
                                        <li class="nav-item"><a href="TK/cutoff.aspx" class="nav-link" style="color:black"><i class="fa fa-cog"></i><span class="h5"> Cut-off</span></a></li>
                                        <li class="nav-item"><a href="DivisionList.aspx" class="nav-link" style="color:black"><i class="fa fa-cog"></i><span class="h5"> Divisions</span></a></li>
                                        <li class="nav-item"><a href="holidaylist.aspx" class="nav-link" style="color:black"><i class="fa fa-cog"></i><span class="h5"> Holidays</span></a></li>
                                        <li class="nav-item"><a href="LeaveType.aspx" class="nav-link" style="color:black"><i class="fa fa-cog"></i><span class="h5"> Leave Type</span></a></li>
                                        <li class="nav-item"><a href="Loans.aspx" class="nav-link" style="color:black"><i class="fa fa-cog"></i><span class="h5"> Loans</span></a></li>
                                        <li class="nav-item"><a href="locationlist.aspx" class="nav-link" style="color:black"><i class="fa fa-cog"></i><span class="h5"> Locations</span></a></li>
                                        <li class="nav-item"><a href="movementtypelist.aspx" class="nav-link" style="color:black"><i class="fa fa-cog"></i><span class="h5"> Movement Type</span></a></li>
                                        <li class="nav-item"><a href="offenseType.aspx" class="nav-link" style="color:black"><i class="fa fa-cog"></i><span class="h5"> Offense Type</span></a></li>
                                        <li class="nav-item"><a href="PayClass.aspx" class="nav-link" style="color:black"><i class="fa fa-cog"></i><span class="h5"> Pay Class</span></a></li>
                                        <li class="nav-item"><a href="PayrollGroup.aspx" class="nav-link" style="color:black"><i class="fa fa-cog"></i><span class="h5"> Payroll Group</span></a></li>
                                        <li class="nav-item"><a href="philHealth.aspx" class="nav-link" style="color:black"><i class="fa fa-cog"></i><span class="h5"> Phil Health Percentage Deduction</span></a></li>
                                        <li class="nav-item"><a href="provinceList.aspx" class="nav-link" style="color:black"><i class="fa fa-cog"></i><span class="h5"> Provinces</span></a></li>
                                        <li class="nav-item"><a href="ranklist.aspx" class="nav-link" style="color:black"><i class="fa fa-cog"></i><span class="h5"> Ranks</span></a></li>
                                        <li class="nav-item"><a href="EmployeeSchedList.aspx" class="nav-link" style="color:black"><i class="fa fa-cog"></i><span class="h5"> Schedule</span></a></li>
                                        <li class="nav-item"><a href="courseList.aspx" class="nav-link" style="color:black"><i class="fa fa-cog"></i><span class="h5"> School Courses</span></a></li>
                                        <li class="nav-item"><a href="statuslist.aspx" class="nav-link" style="color:black"><i class="fa fa-cog"></i><span class="h5"> Status</span></a></li>
                                        
                                        
                                        <%if (Session["EMP_ID"].ToString() == "00000")
                                            { %>
                                        <li class="nav-item"><a href="UpdateBulkData.aspx" class="nav-link" style="color:black"><i class="fa fa-cog"></i><span class="h5"> Manage Bulk Data</span></a></li>
                                        <%} %>
                                        
                                        <li class="">
                                            <h5>USER MAINTENANCE</h5>
                                        </li>
                                        <li class="nav-item"><a href="Userlist.aspx" class="nav-link" style="color:black"><i class="fa fa-user"></i><span class="h5"> Users</span></a></li>
                                        <li class="">
                                            <h5>Audit Logs</h5>
                                        </li>
                                        <li class="nav-item"><a href="auditLogs.aspx" class="nav-link" style="color:black"><i class="fa fa-cog"></i><span class="h5"> Audit Logs</span></a></li>
                                    </ul>
                                </div>
                                <%} %>
                                <%if (Session["ROLES"].ToString() == "hrtimekeeper")
                                    { %>
                                <div class="box-body">
                                    <ul class="nav nav-pills nav-sidebar flex-column">
                                        <li class="nav-item">
                                            <h5>DATA MAINTENANCE</h5>
                                        </li>
                                        <li class="nav-item"><a href="CompanyList.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5">Companies</span></a></li>
                                        <li class="nav-item"><a href="DivisionList.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5">Divisions</span></a></li>
                                        <li class="nav-item"><a href="locationlist.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5">Locations</span></a></li>
                                        <li class="nav-item"><a href="ranklist.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5">Ranks</span></a></li>
                                        <li class="nav-item"><a href="statuslist.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5">Status</span></a></li>
                                        <li class="nav-item"><a href="provinceList.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5">Provinces</span></a></li>
                                        <li class="nav-item"><a href="movementtypelist.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5">Movement Type</span></a></li>
                                        <li class="nav-item"><a href="PayClass.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5">Pay Class</span></a></li>
                                        <li class="nav-item"><a href="courseList.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5">School Courses</span></a></li>
                                        <li class="nav-item"><a href="offenseType.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5">Offense Type</span></a></li>
                                        <li class="nav-item"><a href="LeaveType.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5">Leave Type</span></a></li>
                                        <li class="nav-item"><a href="Loans.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5">Loans</span></a></li>
                                        <li class="nav-item"><a href="TK/cutoff.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5">Cut-off</span></a></li>
                                        <li class="nav-item"><a href="holidaylist.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5">Holidays</span></a></li>
                                        <li class="nav-item"><a href="EmployeeSchedList.aspx" class="nav-link"><i class="fa fa-cog"></i><span class="h5">Schedule</span></a></li>
                                    </ul>
                                </div>
                                <%} %>
                                <%if (Session["EMP_ID"].ToString() == "00000")
                                            { %>
                                <div class="box-body">
                                    <ul class="nav nav-pills nav-sidebar flex-column">
                                        <li class="nav-item">
                                            <h5>SUPER ADMIN</h5>
                                        </li>
                                        <li class="nav-item"><a href="BulkUploadPages/LoanEntriesBulkUpload.aspx" class="nav-link" style="color:black"><i class="fa fa-cog"></i><span class="h5"> Loan Entries Bulk Upload</span></a></li>
                                        </ul>

                                        </div>
                                <%} %>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</asp:Content>
