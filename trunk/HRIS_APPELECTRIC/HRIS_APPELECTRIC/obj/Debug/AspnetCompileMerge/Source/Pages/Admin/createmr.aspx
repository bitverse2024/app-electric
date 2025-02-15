﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="createmr.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.createmr" %>

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
                    <h3 class="m-0 text-dark">Request Manpower<small></small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="hrmrlist.aspx" class="btn btn-default"><i class="fa fa-arrow-circle-o-left"></i><span class="h6">Back to List</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">
                                        <div class='printableArea'>
                                            <div id="list">
                                            </div>

                                            <div class="container form">
                                                <p class="required">Fields with <span class="required text-red">*</span> are required.</p>
                                                <div class="row">

                                                    <div class="col-lg-5">
                                                        <div class="">
                                                            <label for="Manpowerrequest_workexperience" class="required">Work Experience <span class="required text-red">*</span></label> <br />
                                                            <textarea size="60" maxlength="200" class="form-control" autocomplete="off" name="Manpowerrequest[workexperience]" id="Manpowerrequest_workexperience" runat="server"></textarea>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-5">
                                                        <div class="">
                                                            <label for="Manpowerrequest_skills" class="required">Skills <span class="required text-red">*</span></label>
                                                            <textarea size="60" maxlength="200" class="form-control" autocomplete="off" name="Manpowerrequest[skills]" id="Manpowerrequest_skills" runat="server"></textarea>
                                                        </div>

            
                                                        <br />
                                                    </div>

                                                    <div class="col-lg-9">
                                                        <asp:Button ID="btnCreate" class="icon-ok icon-white" runat="server" Text="Request"
                                                            OnClick="btnCreate_Click" CssClass="btn btn-primary" Width="80"></asp:Button>
                                                        <asp:Button ID="btnReset" class="icon-remove icon-white" runat="server" Text="Clear"
                                                            OnClick="btnReset_Click" CssClass="btn btn-danger" Width="80"></asp:Button>
                                                    </div>

                                                </div>
                                                <!-- form -->
                                            </div>
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
