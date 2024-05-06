<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="uploadpayreg.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.PayrollPages.uploadpayreg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to process this payroll?")) {
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
                                <h3 class="m-0 text-dark">Payroll<small> Upload Payroll Register</small></h3>
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
                                                                    <label class="required">Select File: </label>
                                                                    <asp:FileUpload ID="fuUploader" runat="server" CssClass="form-control btn-default" Height="45px" />
                                                                    <asp:RequiredFieldValidator ID="validatorUploader" runat="server" ControlToValidate="fuUploader" 
                                                                        ValidationGroup="uploadGroup" ForeColor="Red" ErrorMessage="Select csv file to upload."></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>

                                                            <div class="form-actions">
                                                                <asp:Button ID="btnUpload" Width="80" class="btn btn-primary" runat="server" Text="Upload"
                                                                    ValidationGroup="uploadGroup" OnClientClick="Confirm()"></asp:Button>
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
                </div>
            </div>
        </div>
        <!-- /.row (main row) -->
    </aside>
</asp:Content>
