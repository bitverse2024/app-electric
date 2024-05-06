<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="closepayroll.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.PayrollPages.closepayroll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to close this payroll?")) {
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
                    <h3 class="m-0 text-dark">Payroll<small> Close Payroll</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="PayReg.aspx" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>

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
                                                        <label for="lblCreditDate" class="required">
                                                            Credit Date <span class="required text-red">**</span>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server"
                                                                ErrorMessage="Field Required" ValidationGroup="ProcessPayroll"
                                                                ControlToValidate="ddlCredDate"></asp:RequiredFieldValidator></label>
                                                        <asp:DropDownList ID="ddlCredDate" CssClass="form-control" runat="server" Width="300px"></asp:DropDownList>
                                                    </div>
                                                    <div class="form col-lg-6">
                                                        <label for="lblClient" class="required">Client</label><br />
                                                        <asp:DropDownList ID="ddlClient" CssClass="form-control" runat="server" Width="300px"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="form-actions">
                                                    <asp:Button ID="btnProcess" Width="80" class="btn btn-primary" runat="server" Text="Process"
                                                        ValidationGroup="ProcessPayroll" OnClientClick="Confirm()" OnClick="btnProcess_Click"></asp:Button>
                                                    &ensp;
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

        <!-- /.row (main row) -->
    </aside>
</asp:Content>
