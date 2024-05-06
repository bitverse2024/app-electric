<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateEmployeeAdjustment.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.PayrollPages.CreateEmployeeAdjustment" %>
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
                <h3 class="m-0 text-dark">Payroll<small> Adjustment</small></h3>
                <section class="card">
                    <div class="card-header">
                        
                        <a href="<%= ResolveUrl("~/Pages/Admin/PayrollPages/EmployeeAdjustmentList.aspx?empid="+empno+"")%>" class="btn btn-default"><i class="fa fa-th-list"></i><span class="h6">List</span></a>

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
                                                <label for="ddlCutoff" class="required">Cut Off <span class="required text-red">*
                                                        <asp:RequiredFieldValidator ID="validatorUploader" runat="server" ControlToValidate="ddlCutoff" 
                                                            ValidationGroup="CreateAdjOthersGroup" ForeColor="Red" ErrorMessage="Field Required">
                                                        </asp:RequiredFieldValidator>
                                                    </span></label>
                                                <asp:DropDownList ID="ddlCutoff" CssClass="form-control" runat="server">
                                                    <asp:ListItem Value="" Text="---Select Cut-Off---"></asp:ListItem>

                                                </asp:DropDownList>
                                                <label for="AdjustmentAdd" class="required">Adjustment Additional<span class="required text-red">*
                                                        <asp:RequiredFieldValidator ID="rfvAdjustmentAdd" runat="server" ControlToValidate="AdjustmentAdd" 
                                                            ValidationGroup="CreateAdjOthersGroup" ForeColor="Red" ErrorMessage="Field Required">
                                                        </asp:RequiredFieldValidator>
                                                    </span>
                                                </label>
                                                <asp:TextBox TextMode="Number" ID="AdjustmentAdd" class="form-control" runat="server"  max="999999" value="0" step="0.01"/>
                                                

                                                <label for="AdjRemarks" class="required">
                                           Adjustment Remarks</label>
                                        <textarea class="form-control" maxlength="250" rows="2" name="AdjRemarks" id="AdjRemarks" runat="server"></textarea>

                                                <label for="AdjustmentOthersAdd" class="required">Adjustment Others Additional<span class="required text-red">*
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="AdjustmentOthersAdd" 
                                                            ValidationGroup="CreateAdjOthersGroup" ForeColor="Red" ErrorMessage="Field Required">
                                                        </asp:RequiredFieldValidator>
                                                    </span>
                                                </label>
                                                <asp:TextBox TextMode="Number" ID="AdjustmentOthersAdd" class="form-control" runat="server"  max="999999" value="0" step="0.01"/>
                                                

                                                <label for="AdjOthrsRemarks" class="required">
                                            Adjustment Others Remarks</label>
                                        <textarea class="form-control" maxlength="250" rows="2" name="AdjOthrsRemarks" id="AdjOthrsRemarks" runat="server"></textarea>
                                                
                                                
                                                 
                                            </div>
                                        </div>
                                        <br />
                                        <div class="form-actions">
                                            <asp:Button ID="btnCreate" class="btn btn-primary" Width="80" runat="server" Text="Create"
                                                OnClick="btnCreate_Click" OnClientClick="Confirm()" ValidationGroup="CreateAdjOthersGroup"></asp:Button>
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
