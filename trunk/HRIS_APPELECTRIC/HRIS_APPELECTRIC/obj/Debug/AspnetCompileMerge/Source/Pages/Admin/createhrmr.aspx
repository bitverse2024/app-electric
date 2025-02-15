﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="createhrmr.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.createhrmr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    <h3 class="m-0 text-dark">Add new HR Budget TO per Division<small></small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="hrmrlist.aspx" class="btn btn-default"><i class="fa fa-arrow-circle-o-left"></i><span class="h6">Back to List</span></a>
                            <a href="createhrmr.aspx" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create New</span> </a>

                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">

                                        <div class="container form">
                                            <div class="row">

                                                <legend>
                                                    <p class="note">Fields with <span class="required text-red">*</span> are required.</p>
                                                </legend>

                                                <div class="col-lg-5">
                                                    <div class="">
                                                        <label for="Hrmr_divisionCode" class="required">Division <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Hrmr_divisionCode" ValidationGroup="CreateHRMRGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <select class="form-control" name="Hrmr[divisionCode]" id="Hrmr_divisionCode" runat="server">
                                                            <option value="">---Select Division---</option>
                                                        </select>
                                                    </div>

                                                    <div class="">
                                                        <label for="Hrmr_departmentCode" class="required">Department <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Hrmr_departmentCode" ValidationGroup="CreateHRMRGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <select class="form-control" name="Hrmr[departmentCode]" id="Hrmr_departmentCode" runat="server">
                                                            <option value="">---Select Department---</option>
                                                        </select>
                                                    </div>
                                                </div>
                                                <div class="col-lg-5">
                                                    <div class="">
                                                        <label for="Hrmr_positionCode" class="required">Position <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Hrmr_positionCode" ValidationGroup="CreateHRMRGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <select class="form-control" name="Hrmr[positionCode]" id="Hrmr_positionCode" runat="server">
                                                            <option value="">---Select Position---</option>
                                                        </select>
                                                    </div>
                                                    <div class="">
                                                        <label for="startmonth" class="required">Boarding Date <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="startmonth" ValidationGroup="CreateHRMRGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <input class="form-control" autocomplete="off" id="startmonth" name="Hrmr[startmonth]" type="date" maxlength="225" runat="server" />
                                                    </div>
                                                    <br />
                                                </div>
                                                <div class="col-lg-9">
                                                    <asp:Button ID="btnCreate" class="btn btn-primary" Width="80" runat="server" Text="Create"
                                                        ValidationGroup="CreateHRMRGroup" OnClick="btnCreate_Click" OnClientClick="Confirm()"></asp:Button>
                                                    <asp:Button ID="btnReset" class="btn btn-danger" Width="80" runat="server" Text="Reset"
                                                        OnClick="btnReset_Click"></asp:Button>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- form -->
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                    <!-- /.row (main row) -->
                </div>
            </div>
        </div>
    </aside>
</asp:Content>
