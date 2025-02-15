﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="createpayregadjded.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.PayrollPages.createpayregadjded" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to process this payslip?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <aside class="right-side">
        <!-- Small boxes (Stat box) -->
        <div class="row">
            <div class="col-lg-12">
                <div id="content">

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
                                <h3 class="m-0 text-dark">Create Payroll Adjusment<small> Compensation</small></h3>
                                <section class="card">
                                    <div class="card-header">
                                        <a href="#" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                                        <a href="payregadjded.aspx" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>

                                    </div>
                                    <div class="card-body">
                                        <div class="content">
                                            <div class="container-fluid">
                                                <div class="box-body">
                                                    <div class="form">

                                                        <fieldset>
                                                            <legend>
                                                                <p class="note">Fields with <span class="required text-red">**</span> are required.</p>
                                                            </legend>


                                                            <div class="row">
                                                                <div class="form col-lg-4">
                                                                    <label for="lblCoDate" class="required">
                                                                        Cut Off Date <span class="required text-red">**</span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server"
                                                                            ErrorMessage="Field Required" ValidationGroup="AdjGroup"
                                                                            ControlToValidate="ddlCoDate"></asp:RequiredFieldValidator></label>
                                                                    <asp:DropDownList ID="ddlCoDate" CssClass="form-control" runat="server" Width="300px"></asp:DropDownList>

                                                                    <label for="lblEmp" class="required">Employee Name<span class="required">*</span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server"
                                                                            ErrorMessage="Field Required" ValidationGroup="AdjGroup"
                                                                            ControlToValidate="ddlEmp"></asp:RequiredFieldValidator></label>
                                                                    <asp:DropDownList ID="ddlEmp" CssClass="form-control" runat="server" Width="300px"></asp:DropDownList>
                                                                </div>
                                                                <div class="form col-lg-4">
                                                                    <label for="lblDed" class="required">Deduction<span class="required">*</span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server"
                                                                            ErrorMessage="Field Required" ValidationGroup="AdjGroup"
                                                                            ControlToValidate="ddlDed"></asp:RequiredFieldValidator></label>
                                                                    <asp:DropDownList ID="ddlDed" CssClass="form-control" runat="server" Width="300px"></asp:DropDownList>

                                                                    <label for="lblAmt" class="required">Amount</label><br />
                                                                    <input class="form-control" id="txtAmt" type="text" runat="server" />
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="form-actions">
                                                                <asp:Button ID="btnProcess" Width="80" class="btn btn-primary" runat="server" Text="Create"
                                                                    ValidationGroup="AdjGroup" OnClientClick="Confirm()" OnClick="btnProcess_Click"></asp:Button>
                                                                &ensp;                                                          
                                                                <asp:Button ID="btnReset" Width="80" class="btn btn-danger" runat="server" Text="Reset"
                                                                    OnClick="btnReset_Click"></asp:Button>
                                                            </div>
                                                        </fieldset>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </section>

                            </div>
                            <!-- content -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.row (main row) -->
    </aside>
</asp:Content>
