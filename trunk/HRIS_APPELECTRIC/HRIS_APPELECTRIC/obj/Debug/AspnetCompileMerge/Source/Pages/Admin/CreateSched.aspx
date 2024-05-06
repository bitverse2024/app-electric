<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateSched.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.CreateSched" %>

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
                    <h3 class="m-0 text-dark">Admin<small> Create Employee Schedules</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="#" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                            <a href="EmployeeSchedList.aspx" class="btn btn-default"><i class="fa fa-th-list"></i><span class="h6">List</span></a>
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
                                                    <label for="Empsched_Sched_TimeIn" class="required">Sched Time In <span class="required text-red">*</span></label>
                                                    <input size="11" class="form-control" id="Empsched_Sched_TimeIn" name="Empsched[Sched_TimeIn]" type="text" maxlength="5" runat="server" />
                                                    <label for="Empsched_Sched_TimeOut" class="required">Sched Time Out <span class="required text-red">*</span></label>
                                                    <input size="11" class="form-control" id="Empsched_Sched_TimeOut" name="Empsched[Sched_TimeOut]" type="text" maxlength="5" runat="server" />
                                                    <label for="Empsched_ShiftName" class="required">Shift Name</label>
                                                    <input class="form-control" maxlength="50" name="Empsched[ShiftName]" id="Empsched_ShiftName" type="text" runat="server" />
                                                </div>
                                            </div>
                                            <br />
                                            <div class="form-actions">

                                                <asp:Button ID="btnCreate" class="btn btn-primary" Width="80px" runat="server" Text="Create"
                                                    OnClick="btnCreate_Click" OnClientClick="Confirm()"></asp:Button>
                                                <asp:Button ID="btnReset" class="btn btn-danger" Width="80px" runat="server" Text="Reset"
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
        <!-- /.row (main row) -->
    </aside>
</asp:Content>
