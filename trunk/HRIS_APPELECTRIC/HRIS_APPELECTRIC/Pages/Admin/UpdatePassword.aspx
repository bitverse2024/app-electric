﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdatePassword.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.UpdatePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function Confirm1() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to update password?")) {
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
                    <h3 class="m-0 text-dark">User<small> Change Password</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="<%= ResolveUrl("~/Pages/Admin/userview.aspx?empid="+empno+"")%>" class="btn btn-default"><i class="fa fa-arrow-circle-o-left"></i><span class="h6">Back</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">
                                        <div class="form">
                                            <legend>
                                                <p class="note">
                                                    Fields with <span class="required text-red">*</span> are required.
                                                </p>
                                            </legend>
                                            <div class="showgrid row">
                                                <div class="col-lg-6">
                                                    <h4 class="box-title">
                                                        <%=getname() %></h4>
                                                    <label for="username" class="required">
                                                        Username<span class="required">*<asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                                            runat="server" ControlToValidate="Username" ValidationGroup="UpdPasswordGroup"
                                                            ForeColor="Red" ErrorMessage="Field Required">
                </asp:RequiredFieldValidator></span></label><input
                                                                class="form-control" id="Username" runat="server" />
                                                    <label for="passwrd" class="required">
                                                        Enter Password <span class="required text-red">*<asp:RequiredFieldValidator ID="validatorUploader"
                                                            runat="server" ControlToValidate="passwrd" ValidationGroup="UpdPasswordGroup"
                                                            ForeColor="Red" ErrorMessage="Field Required">
                </asp:RequiredFieldValidator></span></label><input
                                                                class="form-control" maxlength="40" name="Employee[passwrd]" id="passwrd" type="password"
                                                                runat="server" clientidmode="Static" />
                                                    <label for="newpasswrd" class="required">
                                                        New Password <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                                            runat="server" ControlToValidate="newpasswrd" ValidationGroup="UpdPasswordGroup"
                                                            ForeColor="Red" ErrorMessage="Field Required">
                </asp:RequiredFieldValidator></span></label><input
                                                                class="form-control" maxlength="40" name="Employee[newpasswrd]" id="newpasswrd"
                                                                type="password" runat="server" clientidmode="Static" />
                                                    <label>
                                                        <input type="checkbox" onclick="myFunction()">
                                                        Show Password
                                                    </label>
                                                    <script type="text/javascript">
                                                        function myFunction() {
                                                            var x = document.getElementById("passwrd");
                                                            var y = document.getElementById("newpasswrd");
                                                            if (x.type === "password") {
                                                                x.type = "text";
                                                                y.type = "text";
                                                            } else {
                                                                x.type = "password";
                                                                y.type = "password";
                                                            }
                                                        }
                                                    </script>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="form-actions">
                                                <asp:Button ID="btnUpdate" class="btn btn-primary" Width="80px" runat="server" Text="Save" OnClick="btnUpdate_Click"
                                                    ValidationGroup="UpdPasswordGroup" OnClientClick="Confirm1()"></asp:Button>
                                                <asp:Button ID="btnReset" class="btn btn-danger" Width="80px" runat="server" Text="Reset" OnClick="btnReset_Click"></asp:Button>
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
