<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="payregupdate.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.PayrollPages.payregupdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function Confirm1() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to update this item?")) {
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
                <h3 class="m-0 text-dark">Payroll<small> Update</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="PayReg.aspx" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Back</span></a>
                    </div>

                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="box-header">

                                    <legend>
                                        <p class="note">Fields with <span class="required text-red">**</span> are required.</p>
                                    </legend>
                                </div>

                                <div class="showgrid">
                                    <div class="form row">
                                        <div class="col-lg-6">
                                            <label for="txtBasicPay" class="required">
                                                Basic Pay <span class="required text-red">** 
                                        <asp:RequiredFieldValidator ID="validatorUploader" runat="server" ControlToValidate="txtBasicPay"
                                            ValidationGroup="updatepayreg" autocomplete="off" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator>
                                                </span>
                                            </label>
                                            <input class="form-control" maxlength="50" id="txtBasicPay" type="text" runat="server" clientidmode="Static" />

                                            <label for="txtAbsences" class="required">
                                                Absences <span class="required text-red">** 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAbsences"
                                            ValidationGroup="updatepayreg" autocomplete="off" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator>
                                                </span>
                                            </label>
                                            <input class="form-control" maxlength="50" id="txtAbsences" type="text" runat="server" clientidmode="Static" />

                                            <label for="txtLates" class="required">
                                                Lates <span class="required text-red">** 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLates"
                                            ValidationGroup="updatepayreg" autocomplete="off" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator>
                                                </span>
                                            </label>
                                            <input class="form-control" maxlength="50" id="txtLates" type="text" runat="server" clientidmode="Static" />

                                            <label for="txtUT" class="required">
                                                Undertime <span class="required text-red">** 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUT"
                                            ValidationGroup="updatepayreg" autocomplete="off" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator>
                                                </span>
                                            </label>
                                            <input class="form-control" maxlength="50" id="txtUT" type="text" runat="server" clientidmode="Static" />

                                            <label for="txtOT" class="required">
                                                Overtime <span class="required text-red">** 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtOT"
                                            ValidationGroup="updatepayreg" autocomplete="off" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator>
                                                </span>
                                            </label>
                                            <input class="form-control" maxlength="50" id="txtOT" type="text" runat="server" clientidmode="Static" />

                                            <label for="txtLCreds" class="required">
                                                Remaining Leave Credits <span class="required text-red">** 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLCreds"
                                            ValidationGroup="updatepayreg" autocomplete="off" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator>
                                                </span>
                                            </label>
                                            <input class="form-control" maxlength="50" id="txtLCreds" type="text" runat="server" clientidmode="Static" />

                                        </div>
                                        <div class="col-lg-6">
                                            <label for="txtSSS" class="required">
                                                SSS <span class="required text-red">** 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtSSS"
                                            ValidationGroup="updatepayreg" autocomplete="off" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator>
                                                </span>
                                            </label>
                                            <input class="form-control" maxlength="50" id="txtSSS" type="text" runat="server" clientidmode="Static" />

                                            <label for="txtPhilhealth" class="required">
                                                PhilHealth <span class="required text-red">** 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPhilhealth"
                                            ValidationGroup="updatepayreg" autocomplete="off" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator>
                                                </span>
                                            </label>
                                            <input class="form-control" maxlength="50" id="txtPhilhealth" type="text" runat="server" clientidmode="Static" />

                                            <label for="txtPagibig" class="required">
                                                Pag-Ibig <span class="required text-red">** 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPagibig"
                                            ValidationGroup="updatepayreg" autocomplete="off" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator>
                                                </span>
                                            </label>
                                            <input class="form-control" maxlength="50" id="txtPagibig" type="text" runat="server" clientidmode="Static" />

                                            <label for="txtLPay" class="required">
                                                Leave Pay <span class="required text-red">** 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtLPay"
                                            ValidationGroup="updatepayreg" autocomplete="off" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator>
                                                </span>
                                            </label>
                                            <input class="form-control" maxlength="50" id="txtLPay" type="text" runat="server" clientidmode="Static" />

                                            <label for="txtCashAd" class="required">
                                                Cash Ad <span class="required text-red">** 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtCashAd"
                                            ValidationGroup="updatepayreg" autocomplete="off" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator>
                                                </span>
                                            </label>
                                            <input class="form-control" maxlength="50" id="txtCashAd" type="text" runat="server" clientidmode="Static" />

                                            <label for="txtHPay" class="required">
                                                Holiday Pay <span class="required text-red">** 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtHPay"
                                            ValidationGroup="updatepayreg" autocomplete="off" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator>
                                                </span>
                                            </label>
                                            <input class="form-control" maxlength="50" id="txtHPay" type="text" runat="server" clientidmode="Static" />
                                        </div>

                                        <div class="col-lg-6">
                                            <br />
                                            <button class="btn btn-primary" style="width: 80px;" id="yw1" type="submit" name="yt0" runat="server" OnClientClick="Confirm1()" onserverclick="btnSubmit_Click" validationgroup="updatepayreg"><i class="icon-ok icon-white"></i>Save</button>
                                            <button class="btn btn-danger" style="width: 80px;" id="yw2" type="submit" name="yt1" runat="server" onserverclick="btnCancel_Click"><i class="icon-remove"></i>Cancel</button>
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
