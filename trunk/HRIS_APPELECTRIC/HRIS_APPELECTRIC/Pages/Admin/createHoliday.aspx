<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="createHoliday.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.createHoliday" %>

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
                    <h3 class="m-0 text-dark">Admin<small> Create Holiday</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="createHoliday.aspx" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                            <a href="holidaylist.aspx" class="btn btn-default"><i class="fa fa-th-list"></i><span class="h6">List</span></a>

                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">
                                        <div class="form">

                                            <legend>
                                                <p class="note">Fields with <span class="required text-red">*</span> are required.</p>
                                            </legend>


                                            <div class="showgrid row">
                                                <div class="col-lg-6">
                                                    <label for="Holiday_Holiday" class="required">Holiday</label>
                                                    <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Holiday_Holiday" ValidationGroup="CreateHolidayGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span>
                                                    <input class="form-control" id="Holiday_Holiday" name="Holiday_Holiday[Holiday_Holiday]" type="date" min="1900-01-01" max="2099-12-31" runat="server" />

                                                    <label for="Holiday_HDescription" class="required">Description</label>
                                                    <span class="required text-red">*<asp:RequiredFieldValidator ID="validatorUploader" runat="server" ControlToValidate="Holiday_HDescription" ValidationGroup="CreateHolidayGroup" ForeColor="Red" ErrorMessage="Field Required"> </asp:RequiredFieldValidator></span>
                                                    <input class="form-control" maxlength="40" name="Holiday_HDescription[Holiday_HDescription]" id="Holiday_HDescription" type="text" runat="server" />

                                                    <label for="Holiday_Type" class="required">Holiday Type</label>
                                                    <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Holiday_Type" ValidationGroup="CreateHolidayGroup" ForeColor="Red" ErrorMessage="Field Required"> </asp:RequiredFieldValidator></span>
                                                    <br />
                                                    <select name="Holiday[Type]" id="Holiday_Type" class="form-control" runat="server">
                                                        <option value="LH">Legal Holiday</option>
                                                        <option value="SH">Special Non-working Holiday</option>
                                                        <option value="CH">Company Holiday</option>
                                                    </select>

                                                    <label for="Holiday_Location" runat="server" class="required">Location</label>
                                                    <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Holiday_Type" ValidationGroup="CreateHolidayGroup" ForeColor="Red" ErrorMessage="Field Required"> </asp:RequiredFieldValidator></span>
                                                    <br />
                                                    <select name="Holiday[Location]" id="Holiday_Location" class="form-control" runat="server">
                                                        <option value="ALL">ALL</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="form-actions">
                                                <asp:Button ID="btnCreate" class="btn btn-primary" Width="80" runat="server" Text="Create"
                                                    OnClick="btnCreate_Click" ValidationGroup="CreateHolidayGroup"></asp:Button>
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

        <!-- /.row (main row) -->
    </aside>
</asp:Content>
