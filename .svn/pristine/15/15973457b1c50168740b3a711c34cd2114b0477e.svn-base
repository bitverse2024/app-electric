<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="createstatus.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.createstatus" %>

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
                    <h3 class="m-0 text-dark">Admin<small> Create Employee Status</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="createstatus.aspx" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                            <a href="statuslist.aspx" class="btn btn-default"><i class="fa fa-th-list"></i><span class="h6">List</span></a>
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
                                                <script language="Javascript">
                                                    function isNumberKey(evt) {
                                                        var charCode = (evt.which) ? evt.which : evt.keyCode;
                                                        if (charCode > 31 && (charCode < 48 || charCode > 57))
                                                            return false;
                                                        return true;
                                                    }
                                                </script>


                                                <div class="row">
                                                    <div class="col-lg-6">

                                                        <div class="control-group ">
                                                            <label class="required" for="EmpStatus_EmpStatus">Emp Status</label>
                                                            <div class="controls">
                                                                <input class="form-control" maxlength="1" name="EmpStatus[EmpStatus]" id="EmpStatus_EmpStatus" type="text" runat="server">
                                                            </div>
                                                        </div>
                                                        <div class="control-group ">
                                                            <label class="required" for="EmpStatus_Description">Description</label>
                                                            <div class="controls">
                                                                <input class="form-control" maxlength="20" name="EmpStatus[Description]" id="EmpStatus_Description" type="text" runat="server">
                                                            </div>
                                                        </div>
                                                        <div class="control-group ">
                                                            <label class="required" for="EmpStatus_SSSRef">Sssref</label>
                                                            <div class="controls">
                                                                <input class="form-control" maxlength="1" name="EmpStatus[SSSRef]" id="EmpStatus_SSSRef" type="text" runat="server">
                                                            </div>
                                                        </div>
                                                        <div class="control-group ">
                                                            <label class="required" for="EmpStatus_DaysPerMonth">Days Per Month</label>
                                                            <div class="controls">
                                                                <input class="form-control" name="EmpStatus[DaysPerMonth]" id="EmpStatus_DaysPerMonth" type="text" runat="server" onkeypress="return isNumberKey(event)">
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="control-group ">
                                                            <label class="required" for="EmpStatus_DaysPerYear">Days Per Year</label>
                                                            <div class="controls">
                                                                <input class="form-control" name="EmpStatus[DaysPerYear]" id="EmpStatus_DaysPerYear" type="text" runat="server" onkeypress="return isNumberKey(event)">
                                                            </div>
                                                        </div>
                                                        <div class="control-group ">
                                                            <label class="required" for="EmpStatus_MonthPerYear">Month Per Year</label>
                                                            <div class="controls">
                                                                <input class="form-control" name="EmpStatus[MonthPerYear]" id="EmpStatus_MonthPerYear" type="text" runat="server" onkeypress="return isNumberKey(event)">
                                                            </div>
                                                        </div>
                                                        <div class="control-group ">
                                                            <label class="required" for="EmpStatus_VarRef">Var Ref</label>
                                                            <div class="controls">
                                                                <input class="form-control" maxlength="1" name="EmpStatus[VarRef]" id="EmpStatus_VarRef" type="text" runat="server">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="form-actions">
                                                    <asp:Button ID="btnCreate" class="btn btn-primary" Width="80px" runat="server" Text="Create"
                                                        OnClick="btnCreate_Click" OnClientClick="Confirm()"></asp:Button>
                                                    <asp:Button ID="btnReset" class="btn btn-danger" Width="80px" runat="server" Text="Reset"
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
            </div>
        </div>
        <!-- /.row (main row) -->
    </aside>
</asp:Content>
