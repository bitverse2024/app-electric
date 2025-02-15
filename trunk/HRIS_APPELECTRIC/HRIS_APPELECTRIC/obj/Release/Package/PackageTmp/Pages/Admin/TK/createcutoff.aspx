﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="createcutoff.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.TK.createcutoff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <aside class="right-side">
        <!-- Small boxes (Stat box) -->

        <script type="text/javascript">
            function Confirm() {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden";
                confirm_value.name = "confirm_value";
                if (confirm("Are you sure you want to add this item?")) {
                    confirm_value.value = "Yes";
                } else {
                    confirm_value.value = "No";
                }
                document.forms[0].appendChild(confirm_value);
            }
        </script>

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
                                <h3 class="m-0 text-dark">Admin<small> Create Cut off</small></h3>
                                <section class="card">
                                    <div class="box box-primary">
                                        <div class="box-header">
                                        </div>
                                        <div class="card-header">
                                            <a href="#" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                                            <a href="cutoff.aspx" class="btn btn-default"><i class="fa fa-th-list"></i><span class="h6">List</span></a>
                                        </div>
                                        <div class="card-body">
                                            <div class="content">
                                                <div class="container-fluid">
                                                    <div class="form">

                                                        <legend>
                                                            <p class="note">Fields with <span class="required text-red">*</span> are required.</p>
                                                        </legend>

                                                        <div class="row">
                                                            <div class="col-lg-6">
                                                                <label for="Cutoff_CODate" class="required">Credit Date<span class="required text-red">*
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="CODate" ValidationGroup="CreateCutOffGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                                <input class="form-control" id="CODate" name="Cutoff[CODate]" type="date" runat="server" />

                                                                <label for="Cutoff_COFrom" class="required">Date From<span class="required text-red">*
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="COFrom" ValidationGroup="CreateCutOffGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                                <input class="form-control" id="COFrom" name="Cutoff[COFrom]" type="date" runat="server" />

                                                                <label for="Cutoff_COTo" class="required">Date To<span class="required text-red">*
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="COTo" ValidationGroup="CreateCutOffGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                                <input class="form-control" id="COTo" name="Cutoff[COFrom]" type="date" runat="server" />

                                                                <label for="Cutoff_Description" class="required">Cutoff Name<span class="required v">*
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CODesc" ValidationGroup="CreateCutOffGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                                <input class="form-control" autocomplete="off" name="Cutoff[Description]" id="CODesc" type="text" runat="server" />

                                                               <label for="Employee_DeptCode" class="required">Payroll Group<span class="required text-red">*
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="Employee_PayrollGrpCode" ValidationGroup="CreateCutOffGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                            <select class="form-control" name="Employee_PayrollGrpCode" id="Employee_PayrollGrpCode" runat="server">
                                                                <option value="">---Select Payroll Group---</option>
                                                                </select>
                                                            </div>
                                                            <div class="col-lg-6">
                                                                <label for="CutOff_Company" class="required">Company<span class="required text-red">*
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="CutOff_Company" ValidationGroup="CreateCutOffGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                            <select class="form-control" name="CutOff_Company" id="CutOff_Company" runat="server">
                                                                <option value="">---Select Company---</option>
                                                                <option value="AEC">APP ELECTRIC CORP.</option>
                                                                <option value="MSC">M2B SALES CORPORATION</option>
                                                                <option value="WAISC">WATTS APP INDUSTRIAL SALES CORP.</option>
                                                                </select>
                                                                <label for="monthlydt" class="required">Credit Month<span class="required text-red">*
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="monthlydt" ValidationGroup="CreateCutOffGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                                <input class="form-control" style="width:225px" id="monthlydt" type="month" runat="server">

                                                                <label for="creditWeek" class="required">Credit Week<span class="required text-red">*
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="creditWeek" ValidationGroup="CreateCutOffGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                            <select class="form-control" name="Cutoff_creditWeek" id="creditWeek" runat="server">
                                                                <option value="">---Select Credit Week---</option>
                                                                <option value="1">Week 1</option>
                                                                <option value="2">Week 2</option>
                                                                <option value="3">Week 3</option>
                                                                <option value="4">Week 4</option>
                                                                <option value="5">Week 5</option>
                                                                <option value="6">Extra</option>
                                                                </select>
                                                                </div>
                                                        </div>
                                                        <br />
                                                        <div class="form-actions">
                                                            <asp:Button ID="btnCreate" class="btn btn-primary" Width="80" runat="server" Text="Create"
                                                                OnClick="btnCreate_Click"  validationgroup="CreateCutOffGroup"></asp:Button>
                                                            <asp:Button ID="btnReset" class="btn btn-danger" Width="80" runat="server" Text="Reset"
                                                                OnClick="btnReset_Click"></asp:Button>
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
                </div>

            </div>
            <!-- content -->
        </div>
        <div class="col-lg-6">
            <div id="sidebar">
            </div>
            <!-- sidebar -->
        </div>

        <!-- /.row (main row) -->
    </aside>
</asp:Content>
