﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default_kioskAdmin.aspx.cs" Inherits="HRIS_APPELECTRIC.Default_kioskAdmin" %>

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
                                            <!-- small box -->
                                            <%--  <div class="small-box bg-blue" style="border-radius: 5px;">
                                                <div class="inner">
                                                    <h3>Conference
                                                    </h3>
                                                    <p>
                                                        Conference Room Booking
                                                    </p>
                                                </div>
                                                <div class="icon">
                                                    <i class="fa fa-building"></i>
                                                </div>
                                                <a href="#" class="small-box-footer">Click here <i class="fa fa-arrow-circle-right"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <!-- ./col -->
                                        <div class="col-lg-3 col-xs-12">
                                            <!-- small box -->
                                            <div class="small-box bg-aqua" style="border-radius: 5px;">
                                                <div class="inner">
                                                    <h3>Service
                                                    </h3>
                                                    <p>
                                                        Service Vehicle 
                                                    </p>
                                                </div>
                                                <div class="icon">
                                                    <i class="fa fa-bus"></i>
                                                </div>
                                                <a href="#" class="small-box-footer">Click here <i class="fa fa-arrow-circle-right"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <!-- ./col -->
                                        <div class="col-lg-3 col-xs-12">
                                            <!-- small box -->
                                            <div class="small-box bg-teal" style="border-radius: 5px;">
                                                <div class="inner">
                                                    <span class="text-xl text-bold">Maintenance
                                                    </span>
                                                    <span class="text">Service Vehicle Maintenance</span>
                                                </div>
                                                <div class="icon">
                                                    <i class="fa fa-tachometer"></i>
                                                </div>
                                                <a href="#" class="small-box-footer">Click here <i class="fa fa-arrow-circle-right"></i>
                                                </a>
                                            </div>
                                        </div>--%>
                                            <!-- ./col -->
                                            <%--<div class="col-lg-3 col-xs-12">
			                            <!-- small box -->
			                            <div class="small-box bg-light-blue" style="border-radius: 5px;">
				                            <div class="inner">
					                            <h3>
						                            Travel 
					                            </h3>
					                            <p>
						                             Travel Request
					                            </p>
				                            </div>
				                            <div class="icon">
                                            <i class="fa fa-plane"></i>		
            		                            </div>
				                            <a href="#" class="small-box-footer">
					                            Click here <i class="fa fa-arrow-circle-right"></i>
				                            </a>
			                            </div>
		                            </div><!-- ./col -->--%>
                                            <div class="col-lg-3 col-xs-6">
                                                <!-- small box -->
                                                <div class="small-box bg-maroon">
                                                    <div class="inner">
                                                        <h3>RM
                                                        </h3>
                                                        <p>
                                                            Role Management
                                                        </p>
                                                    </div>
                                                    <div class="icon">
                                                        <i class="fa fa-user-secret"></i>
                                                    </div>
                                                    <a href="Pages/AdminKiosk/adminrolemanagement.aspx" class="small-box-footer">Click here <i class="fa fa-arrow-circle-right"></i>
                                                    </a>
                                                </div>
                                            </div>
                                            <div class="col-lg-3 col-xs-12">
                                                <!-- small box -->
                                                <div class="small-box bg-lime" style="border-radius: 5px;">
                                                    <div class="inner">
                                                        <h3>UAM 
                                                        </h3>
                                                        <p>
                                                            User Account Management
                                                        </p>
                                                    </div>
                                                    <div class="icon">
                                                        <i class="fa fa-address-card"></i>
                                                    </div>
                                                    <a href="Pages/AdminKiosk/adminusermanagement.aspx" class="small-box-footer">Click here <i class="fa fa-arrow-circle-right"></i>
                                                    </a>
                                                </div>
                                            </div>
                                            <div class="col-lg-3 col-xs-12">
                                                <!-- small box -->
                                                <div class="small-box bg-blue" style="border-radius: 5px;">
                                                    <div class="inner">
                                                        <h3>HTLI
                                                        </h3>
                                                        <p>
                                                            Directory
                                                        </p>
                                                    </div>
                                                    <div class="icon">
                                                        <i class="fa fa-address-book"></i>
                                                    </div>
                                                    <a href="Pages/AdminKiosk/adminhtli.aspx" class="small-box-footer">Click here <i class="fa fa-arrow-circle-right"></i>
                                                    </a>
                                                </div>
                                            </div>
                                    </div>
                                    <!-- /.row -->

                                    <!-- Small boxes (Stat box) -->
                                    <%--<div class="row">
                                        <div class="col-lg-3 col-xs-12">
                                            <!-- small box -->
                                            <div class="small-box bg-light-blue" style="border-radius: 5px;">
                                                <div class="inner">
                                                    <h3>Asset
                                                    </h3>
                                                    <p>
                                                        Asset Requisition
                                                    </p>
                                                </div>
                                                <div class="icon">
                                                    <i class="fa fa-laptop"></i>
                                                </div>
                                                <a href="#" class="small-box-footer">Click here <i class="fa fa-arrow-circle-right"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <!-- ./col -->
                                        <div class="col-lg-3 col-xs-12">
                                            <!-- small box -->
                                            <div class="small-box bg-teal" style="border-radius: 5px;">
                                                <div class="inner">
                                                    <h3>Admin 
                                                    </h3>
                                                    <p>
                                                        Admin Asset Requisition
                                                    </p>
                                                </div>
                                                <div class="icon">
                                                    <i class="fa fa-desktop"></i>
                                                </div>
                                                <a href="#" class="small-box-footer">Click here <i class="fa fa-arrow-circle-right"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <!-- ./col -->
                                        <div class="col-lg-3 col-xs-12">
                                            <!-- small box -->
                                            <div class="small-box bg-aqua" style="border-radius: 5px;">
                                                <div class="inner">
                                                    <h3>Office
                                                    </h3>
                                                    <p>
                                                        Office Supplies Requisition
                                                    </p>
                                                </div>
                                                <div class="icon">
                                                    <i class="ion ion-printer"></i>
                                                </div>
                                                <a href="Pages/AdminKiosk/adminofficesupplies.aspx" class="small-box-footer">Click here <i class="fa fa-arrow-circle-right"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <!-- ./col -->
                                        <div class="col-lg-3 col-xs-12">
                                            <!-- small box -->
                                            <div class="small-box bg-blue" style="border-radius: 5px;">
                                                <div class="inner">
                                                    <h3>Supply Req
                                                    </h3>
                                                    <p>
                                                        List of Supply Request
                                                    </p>
                                                </div>
                                                <div class="icon">
                                                    <i class="fa fa-calendar"></i>
                                                </div>
                                                <a href="Pages/AdminKiosk/adminsuppliesrequest.aspx" class="small-box-footer">Click here <i class="fa fa-arrow-circle-right"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <!-- ./col -->
                                        <div class="col-lg-3 col-xs-12">
                                            <!-- small box -->
                                            <div class="small-box bg-blue" style="border-radius: 5px;">
                                                <div class="inner">
                                                    <h3>HTLI
                                                    </h3>
                                                    <p>
                                                        Directory
                                                    </p>
                                                </div>
                                                <div class="icon">
                                                    <i class="fa fa-address-book"></i>
                                                </div>
                                                <a href="Pages/AdminKiosk/adminhtli.aspx" class="small-box-footer">Click here <i class="fa fa-arrow-circle-right"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <!-- ./col -->

                                        <div class="col-lg-3 col-xs-12">
                                            <!-- small box -->
                                            <div class="small-box bg-aqua" style="border-radius: 5px;">
                                                <div class="inner">
                                                    <h3>Forms
                                                    </h3>
                                                    <p>
                                                        Downloadable Forms
                                                    </p>
                                                </div>
                                                <div class="icon">
                                                    <i class="fa fa-file"></i>
                                                </div>
                                                <a href="#" class="small-box-footer">Click here <i class="fa fa-arrow-circle-right"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <!-- ./col -->
                                        <div class="col-lg-3 col-xs-12">
                                            <!-- small box -->
                                            <div class="small-box bg-teal" style="border-radius: 5px;">
                                                <div class="inner">
                                                    <span class="text-lg text-bold">Cash Advance
                                                    </span>
                                                    <p>
                                                        Cash Advance & Reimbursement
                                                    </p>
                                                </div>
                                                <div class="icon">
                                                    <i class="fa fa-money"></i>
                                                </div>
                                                <a href="Pages/AdminKiosk/admincashadvance.aspx" class="small-box-footer">Click here <i class="fa fa-arrow-circle-right"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <!-- ./col -->
                                        <div class="col-lg-3 col-xs-6">
                                            <!-- small box -->
                                            <div class="small-box bg-blue">
                                                <div class="inner">
                                                    <h3>RM
                                                    </h3>
                                                    <p>
                                                        Role Management
                                                    </p>
                                                </div>
                                                <div class="icon">
                                                    <i class="fa fa-user-secret"></i>
                                                </div>
                                                <a href="Pages/AdminKiosk/adminrolemanagement.aspx" class="small-box-footer">Click here <i class="fa fa-arrow-circle-right"></i>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.row -->

                                    <div class="row">

                                        <div class="col-lg-3 col-xs-6">
                                            <!-- small box -->
                                            <div class="small-box bg-blue">
                                                <div class="inner">
                                                    <h3>PS
                                                    </h3>
                                                    <p>
                                                        Password Settings
                                                    </p>
                                                </div>
                                                <div class="icon">
                                                    <i class="fa fa-shield"></i>
                                                </div>
                                                <a href="Pages/AdminKiosk/adminpassword.aspx" class="small-box-footer">Click here <i class="fa fa-arrow-circle-right"></i>
                                                </a>
                                            </div>
                                        </div>
                                    </div>--%>

                                    <!-- Small boxes (Stat box) -->
                                    <div class="row">
                                        <!-- Widgets as boxes -->
                                        <section class="col-lg-6">
                                            <div class="box box-primary">
                                                <div class="box-header">
                                                    <i class="fa fa-folder"></i>
                                                    <h3 class="box-title">Office Supplies
                                                    </h3>
                                                </div>

                                                <div class="box-body">
                                                    <p style="color: red"><b>WARNING </b></p>
                                                    <table class="items table table-striped table-bordered table-condensed">
                                                        <thead>
                                                            <tr>
                                                                <th style="color: #3c8dbc;">Item Name</th>
                                                                <th style="color: #3c8dbc;">Quantity</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </section>
                                        <!-- /.Left col -->


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
