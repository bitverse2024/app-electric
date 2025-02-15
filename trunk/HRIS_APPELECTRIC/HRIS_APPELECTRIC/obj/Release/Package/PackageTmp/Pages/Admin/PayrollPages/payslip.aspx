﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="payslip.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.PayrollPages.payslip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function Confirm2() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to process this payslip?")) {
                confirm_value.value = "";
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "";
                confirm_value.value = "No";
            }
            //document.forms[0].target = '_blank';
            document.forms[0].appendChild(confirm_value);
        }
        function Confirm() {
   return confirm("Are you sure you want to print this payslip?");         
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
                                <h3 class="m-0 text-dark">Payroll<small> View Payslip</small></h3>
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
                                                                <p class="note">Fields with <span class="required text-red">*</span> are required.</p>
                                                            </legend>


                                                            <div class="row">
                                                                <div class="form col-lg-4">
                                                                    

                                                                    <label for="lblCreditDate" class="required">
                                                                        Cutoff - Payroll Group <span class="required text-red">*</span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server"
                                                                            ErrorMessage="Field Required" ValidationGroup="ProcessPayroll"
                                                                            ControlToValidate="ddlCredDate"></asp:RequiredFieldValidator></label>
                                                                        
                                                                    
                                                                    <asp:DropDownList ID="ddlCredDate" CssClass="form-control" runat="server" Width="300px" OnSelectedIndexChanged="ddlCredDate_SelectedIndexChanged" AutoPostBack="true">
                                                                        <asp:ListItem Enabled="true" Text="----SELECT CUTOFF----" Value=""></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                        
                                                                    <label for="lblEmployee" class="required">
                                                                        Employee</label>
                                                                    <asp:DropDownList ID="ddlEmployee" CssClass="form-control" runat="server" Width="300px">
                                                                        <asp:ListItem Enabled="true" Text="----ALL EMPLOYEE----" Value="ALL"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                                
                                                            </div>
                                                            <br />
                                                            <div class="form-actions">
                                                                <%--<asp:Button ID="btnProcess" Width="140" class="btn btn-primary" runat="server" Text="Process Payslip"
                                                                    ValidationGroup="ProcessPayroll" OnClientClick="Confirm()" OnClick="btnProcess_Click"></asp:Button>--%>
                                                                <asp:Button ID="btnProcess" Width="140" class="btn btn-primary" runat="server" Text="View Payslip"
                                                                    ValidationGroup="ProcessPayroll" OnClientClick=" document.forms[0].target = '_blank';if (!Confirm()) return false;" OnClick="btnProcess_Click"></asp:Button>
                                                                &ensp;
                                                                <asp:Button ID="btnReset" Width="80" class="btn btn-danger" runat="server" Text="Reset"></asp:Button>
                                                                &ensp;
                                                                <%--<asp:Button ID="btnPrint" Width="190" class="btn btn-info" runat="server" Text="Print Individual Payslip" PostBackUrl="~/Pages/Admin/PayrollPages/printpayslip.aspx"></asp:Button>--%>
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