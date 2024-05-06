<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default_kioskTK.aspx.cs" Inherits="HRIS_APPELECTRIC.Default_kioskTK" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <aside class="right-side">
        <!-- Small boxes (Stat box) -->

        <section class="content-header">
        </section>
        <!-- Main content -->
        <div class="col-md-12">
            <div class="content">
                <div class="container-fluid">
                    <div class="container"></div>
                    <h1 class="m-0 text-dark">Dashboard<small> Control Panel</small></h1>

                    <section class="card">
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="row">
                                        <%--<div class="col-lg-3 col-xs-6">
			<!-- small box -->
			<div class="small-box bg-blue" >
				<div class="inner">
					<h3>
						MR
					</h3>
					<p>
						Manpower Requisition
					</p>
				</div>
				<div class="icon">
					<i class="fa fa-user-plus"></i>
				</div>
				<a href=/dataland-new/index.php class="small-box-footer">
					Click here <i class="fa fa-arrow-circle-right"></i>
				</a>
			</div>
		</div>--%><!-- ./col -->



                                        <%--<div class="col-lg-3 col-xs-6">
			<!-- small box -->
			<div class="small-box bg-green" >
				<div class="inner">
					<h3>
						Payslip
					</h3>
					<p>
						View Payslip
					</p>
				</div>
				<div class="icon">
					<i class="fa fa-file-text"></i>
				</div>
				<a href="" class="small-box-footer">
					Click here <i class="fa fa-arrow-circle-right"></i>
				</a>
			</div>
		</div><!-- ./col -->

		<div class="col-lg-3 col-xs-6">
			<!-- small box -->
			<div class="small-box bg-red" >
				<div class="inner">
					<h3>
						Appraisal
					</h3>
					<p>
						Performance Evaluation
					</p>
				</div>
				<div class="icon">
					<i class="ion ion-arrow-graph-up-right"></i>
				</div>
				<a href="" class="small-box-footer">
					Click here <i class="fa fa-arrow-circle-right"></i>
				</a>
			</div>
		</div><!-- ./col -->--%>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-3 col-xs-6">
                                            <!-- small box -->
                                            <div class="small-box bg-aqua">
                                                <div class="inner">
                                                    <h3>EMPLOYEES</h3>

                                                    <p>201 Data</p>
                                                </div>
                                                <div class="icon">
                                                    <i class="fa fa-users"></i>
                                                </div>
                                                <a href="<%= ResolveUrl("~/Pages/Admin/Employees/EmployeeMaster.aspx")%>" class="small-box-footer">Click here <i class="fa fa-arrow-circle-right"></i></a>
                                            </div>
                                        </div>
                                        <!-- ./col -->

                                        <div class="col-lg-3 col-xs-6">
                                            <!-- small box -->
                                            <div class="small-box bg-teal">
                                                <div class="inner">
                                                    <h3>DTR
                                                    </h3>
                                                    <p>
                                                        Time Record
                                                    </p>
                                                </div>
                                                <div class="icon">
                                                    <i class="fa fa-calendar"></i>
                                                </div>
                                                <a href="Pages/Admin/TK/dts.aspx" class="small-box-footer">Click here <i class="fa fa-arrow-circle-right"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <!-- ./col -->

                                        <div class="col-lg-3 col-xs-6">
                                            <!-- small box -->
                                            <div class="small-box bg-green">
                                                <div class="inner">
                                                    <h3>Payroll
                                                    </h3>
                                                    <p>
                                                        Payroll Register
                                                    </p>
                                                </div>
                                                <div class="icon">
                                                    <i class="fa fa-calendar"></i>
                                                </div>
                                                <a href="Pages/Admin/TK/dts.aspx" class="small-box-footer">Click here <i class="fa fa-arrow-circle-right"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <!-- ./col -->

                                        <div class="col-lg-3 col-xs-6">
                                            <!-- small box -->
                                            <div class="small-box bg-purple">
                                                <div class="inner">
                                                    <h3>REPORTS<sup style="font-size: 20px"></sup></h3>

                                                    <p>Reports</p>
                                                </div>
                                                <div class="icon">
                                                    <i class="ion ion-printer"></i>
                                                </div>
                                                <a href="<%= ResolveUrl("~/Pages/Admin/Reports/ReportsPage.aspx")%>" class="small-box-footer">Click here <i class="fa fa-arrow-circle-right"></i></a>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-3 col-xs-6">
                                            <!-- small box -->
                                            <div class="small-box bg-maroon">
                                                <div class="inner">
                                                    <h3>SETTINGS</h3>

                                                    <p>Table Maintenance</p>
                                                </div>
                                                <div class="icon">
                                                    <i class="fa fa-cog"></i>
                                                </div>
                                                <a href="<%= ResolveUrl("~/Pages/Admin/AdminPage.aspx")%>" class="small-box-footer">Click here <i class="fa fa-arrow-circle-right"></i></a>
                                            </div>
                                        </div>
                                        <div>
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
