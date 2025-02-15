﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="createded.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.PayrollPages.createded" %>

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
                <h3 class="m-0 text-dark">Payroll<small> Deductions</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="#" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/PayrollPages/employeeded.aspx?empid="+empno+"")%>" class="btn btn-default"><i class="fa fa-th-list"></i><span class="h6">List</span></a>

                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="box-body">
                                    <div class="form">
                                        <legend>
                                            <p class="note">Fields with <span class="required text-red">*</span> are required.</p>
                                        </legend>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <label for="ddlCutoff" class="required">Cut Off <span class="required text-red">
                                                        <asp:RequiredFieldValidator ID="validatorUploader" runat="server" ControlToValidate="ddlCutoff" 
                                                            ValidationGroup="CreateGovtDedAdjGroup" ForeColor="Red" ErrorMessage="Field Required">
                                                        </asp:RequiredFieldValidator>
                                                    </span></label>
                                                <asp:DropDownList ID="ddlCutoff" CssClass="form-control" runat="server">
                                                    <asp:ListItem Value="" Text="---Select Pay Period---"></asp:ListItem>

                                                </asp:DropDownList>
                                                <label for="txtSSS" class="required">SSS<span class="required text-red">
                                                        <%--<asp:RequiredFieldValidator ID="validatorUploader" runat="server" ControlToValidate="txtSSS" 
                                                            ValidationGroup="createded" ForeColor="Red" ErrorMessage="Field Required">
                                                        </asp:RequiredFieldValidator>--%>
                                                    <%--</span>--%>
                                                </label>
                                                <%--<input class="form-control" maxlength="50" id="txtSSS" type="text" runat="server" />--%>
                                                <%--<input class="form-control" type="number" id="txtSSS" name="txtSSS" runat="server">--%>
                                                <asp:TextBox TextMode="Number" ID="txtSSS" class="form-control" runat="server"  step="0.01"/>
                                                <label for="txtsssER" class="required">SSS ER<span class="required text-red">
                                                        
                                                </label>
                                                <%--<input class="form-control" maxlength="50" id="txtsssER" type="text" runat="server" />--%>
                                                <%--<input class="form-control" type="number" id="txtsssER" name="txtsssER" runat="server">--%>
                                                <asp:TextBox TextMode="Number" ID="txtsssER" class="form-control" runat="server"  step="0.01"/>
                                                <label for="txtPhilhealth" class="required">PhilHealth<span class="required text-red">
                                                </label>
                                                <%--<input class="form-control" maxlength="50" id="txtPhilhealth" type="text" runat="server" />--%>
                                                <%--<input class="form-control" type="number" id="txtPhilhealth" name="txtPhilhealth" runat="server">--%>
                                                <asp:TextBox TextMode="Number" ID="txtPhilhealth" class="form-control" runat="server"  step="0.01"/>
                                                <label for="txtPhilDedER" class="required">PhilHealth ER<span class="required text-red">
                                                </label>
                                                <%--<input class="form-control" maxlength="50" id="txtPhilDedER" type="text" runat="server" />--%>
                                                <%--<input class="form-control" type="number" id="txtPhilDedER" name="txtPhilDedER" runat="server">--%>
                                                <asp:TextBox TextMode="Number" ID="txtPhilDedER" class="form-control" runat="server"  step="0.01"/>
                                                <label for="txtPagibig" class="required">Pag-ibig<span class="required text-red">
                                                    </span>
                                                </label>
                                                <%--<input class="form-control" maxlength="50" id="txtPagibig" type="text" runat="server" />--%>
                                                <%--<input class="form-control" type="number" id="txtPagibig" name="txtPagibig" runat="server">--%>
                                                <asp:TextBox TextMode="Number" ID="txtPagibig" class="form-control" runat="server"  step="0.01"/>
                                                <label for="txtPagibigDedER" class="required">Pag-ibig ER<span class="required text-red">
                                                    </span>
                                                </label>
                                                <%--<input class="form-control" maxlength="50" id="txtPagibigDedER" type="text" runat="server" />--%>
                                                <%--<input class="form-control" type="number" id="txtPagibigDedER" name="txtPagibigDedER" runat="server">--%>
                                                <asp:TextBox TextMode="Number" ID="txtPagibigDedER" class="form-control" runat="server"  step="0.01"/>
                                                <label for="txtempTax" class="required">Tax<span class="required text-red">
                                                    </span>
                                                </label>
                                                <%--<input class="form-control" maxlength="50" id="txtempTax" type="text" runat="server" />--%>
                                                <%--<input class="form-control" type="number" id="txtempTax" name="txtempTax" runat="server">--%>
                                                <asp:TextBox TextMode="Number" ID="txtempTax" class="form-control" runat="server"  step="0.01"/>
                                                
                                                 
                                            </div>
                                        </div>
                                        <br />
                                        <div class="form-actions">
                                            <asp:Button ID="btnCreate" class="btn btn-primary" Width="80" runat="server" Text="Create"
                                                OnClick="btnCreate_Click" OnClientClick="Confirm()" ValidationGroup="CreateGovtDedAdjGroup"></asp:Button>
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
</asp:Content>
