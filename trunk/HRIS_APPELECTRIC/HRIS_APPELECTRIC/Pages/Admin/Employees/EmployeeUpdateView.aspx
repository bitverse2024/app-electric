﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeUpdateView.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees.EmployeeUpdateView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="http://code.jquery.com/jquery-latest.js"></script>
    <!-- Example jQuery Masking Script -->
    <script src="http://digitalbush.com/wp-content/uploads/2013/01/jquery.maskedinput-1.3.1.min_.js"></script>
    <script src="\scripts\jquery-1.7.2.js" type="text/javascript"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

    <script src="https://igorescobar.github.io/jQuery-Mask-Plugin/js/jquery.mask.min.js" type="text/javascript"></script>
    <!--mask script-->
    <SCRIPT type="text/javascript">
       <!--
       function isNumberKey(evt)
       {
          var charCode = (evt.which) ? evt.which : evt.keyCode;
          if (charCode != 46 && charCode > 31 
            && (charCode < 48 || charCode > 57))
             return false;

          return true;
       }
       //-->
    </SCRIPT>
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
        $(document).ready(function () {

            $(".ssno").keyup(function (e) {
                var value = $(".ssno").val();
                if (e.key.match(/[0-9]/) == null) {
                    value = value.replace(e.key, "");
                    $(".ssno").val(value);
                    return;
                }

                if (value.length == 2) {
                    $(".ssno").val(value + "-")
                }
                if (value.length == 10) {
                    $(".ssno").val(value + "-")
                }
            });
        });

        $(document).ready(function () {

            $(".tinno").keyup(function (e) {
                var value = $(".tinno").val();
                if (e.key.match(/[0-9]/) == null) {
                    value = value.replace(e.key, "");
                    $(".tinno").val(value);
                    return;
                }

                if (value.length == 3) {
                    $(".tinno").val(value + "-")
                }
                if (value.length == 7) {
                    $(".tinno").val(value + "-")
                }
            });
        });

        $(document).ready(function () {

            $(".pagibigno").keyup(function (e) {
                var value = $(".pagibigno").val();
                if (e.key.match(/[0-9]/) == null) {
                    value = value.replace(e.key, "");
                    $(".pagibigno").val(value);
                    return;
                }

                if (value.length == 4) {
                    $(".pagibigno").val(value + "-")
                }
                if (value.length == 11) {
                    $(".pagibigno").val(value + "-")
                }
            });
        });

        $(document).ready(function () {

            $(".philno").keyup(function (e) {
                var value = $(".philno").val();
                if (e.key.match(/[0-9]/) == null) {
                    value = value.replace(e.key, "");
                    $(".philno").val(value);
                    return;
                }

                if (value.length == 2) {
                    $(".philno").val(value + "-")
                }
                if (value.length == 12) {
                    $(".philno").val(value + "-")
                }
            });
        });
    </script>

    <script type="text/javascript">
        $('.phone_us').mask('000-000-0000');
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
                <h3 class="m-0 text-dark">Employee<small> <%=getname() %></small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/EmployeeMaster.aspx")%>" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Back</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/CreateEmployee.aspx")%>" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/EmployeeView.aspx?empid="+empno+"")%>" class="btn btn-default"><i class="fa fa-user"></i><span class="h6">View</span></a>
                        <a href="#" class="btn btn-default"><i class="fa fa-edit"></i><span class="h6">Update</span></a>
                    </div>

                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="box-header">

                                    <legend>
                                        <p class="note">Fields with <span class="required text-red">*</span> are required.</p>
                                    </legend>
                                </div>

                                <div class="showgrid">
                                    <div class="form row">
                                        <div class="col-lg-6">

                                            <label for="Employee_Surname" class="required">Last Name <span class="required text-red">*</span></label><input class="form-control" maxlength="255" name="emp_Surname" id="emp_Surname" type="text" runat="server" clientidmode="Static" />

                                            <label for="Employee_FirstName" class="required">First Name <span class="required text-red">*</span></label><input class="form-control" maxlength="255" name="emp_FirstName" id="emp_FirstName" type="text" runat="server" />

                                            <label for="Employee_MidName" class="required">Middle Name</label><input class="form-control" maxlength="255" name="emp_MidName" id="emp_MidName" type="text" runat="server" />

                                            <label for="Employee_Suffix" class="required">Suffix</label><input class="form-control" maxlength="50" name="emp_Suffix" id="emp_Suffix" type="text" runat="server" />
                                            <label for="Employee_NickName" class="required">Nick Name</label><input class="form-control" maxlength="10" name="emp_NickName" id="emp_NickName" type="text" runat="server" />
                                            <%--<label for="Employee_EmpID" class="required">Employee No. <span class="required text-red">*</span></label><asp:TextBox ID="emp_EmpID" class="form-control" runat="server" 
                                                    OnTextChanged="Employee_EmpID_TextChanged" AutoPostBack="true"></asp:TextBox>--%>
                                              <label for="Employee_EmpID" class="required">Employee No. <span class="required text-red">*
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="emp_EmpID" ValidationGroup="UpdateEmployeeGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label> <asp:TextBox ID="emp_EmpID" class="form-control" runat="server" 
                                               AutoPostBack="true" OnTextChanged="Employee_EmpID_TextChanged"></asp:TextBox>
                                            <%--<label for="Employee_BACode" class="required">Biometrics ID</label><asp:TextBox ID="emp_BiometricsID" class="form-control" runat="server" OnTextChanged="Employee_BACode_TextChanged" AutoPostBack="true"></asp:TextBox>--%>
                                            <label for="Employee_AssignmentCode" class="required">Company <span class="required text-red">*</span></label>
                                            <select class="form-control" name="emp_Assignment" id="emp_Assignment" runat="server">
                                                <option value="">---Select Assignment---</option>
                                            </select>
                                            <label for="Employee_Gender" class="required">Gender</label>
                                            <select class="form-control" name="emp_Gender" id="emp_Gender" runat="server">
                                                <option value="">---Select Gender---</option>
                                                <option value="M">Male</option>
                                                <option value="F">Female</option>
                                            </select>
                                            <label for="Employee_PayType" class="required">Pay Type<span class="required text-red">*
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="emp_PayType" ValidationGroup="UpdateEmployeeGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                            <select class="form-control" name="emp_PayType" id="emp_PayType" runat="server">
                                                <option value="">---Select Pay Type---</option>
                                                <option value="H">Hourly</option>
                                                <option value="D">Daily</option>
                                                <option value="M">Monthly</option>
                                            </select>
                                            <label for="Employee_PositionCode" class="required">Position <span class="required text-red">*
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="emp_Position" ValidationGroup="UpdateEmployeeGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                            <select class="form-control" name="emp_Position" id="emp_Position" runat="server">
                                                <option value="">---Select Position---</option>

                                            </select>
                                            <label for="Employee_DeptCode" class="required">Department <span class="required text-red">*
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="emp_Department" ValidationGroup="UpdateEmployeeGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                            <select class="form-control" name="emp_Department" id="emp_Department" runat="server">
                                                <option value="">---Select Department---</option>

                                            </select>
                                            <label for="Employee_DeptCode" class="required">
                                                Payroll Group <span class="required text-red">*
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="emp_PayrollGroup" ValidationGroup="UpdateEmployeeGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                            <select class="form-control" name="Employee_PayrollGrpCode" id="emp_PayrollGroup" runat="server">
                                                <option value="">---Select Payroll Group---</option>


                                            </select>
                                            <label for="emp_Location" class="required">
                                                Location <span class="required text-red">*
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="emp_Location" ValidationGroup="UpdateEmployeeGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                            <select class="form-control" name="emp_Location" id="emp_Location" runat="server">
                                                <option value="">---Select Location---</option>


                                            </select>


                                            <%--<label for="Employee_DateStart" class="required">Date Start <span class="required text-red">**</span></label>		
    <input style="height:20px;" class="form-control" id="emp_DateStart" name="emp_DateStart" type="text" maxlength="11" runat="server" />--%>
                                            <%--<label for="emp_DateStart" class="required">
                                                Date Start <span class="required text-red">**
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="emp_DateStart" ValidationGroup="UpdateEmployeeGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                            <input class="form-control datetimepicker" id="emp_DateStart" name="emp_DateStart" type="text" maxlength="11" runat="server" />--%>
                                            <label for="Leavesapp_DateFrom" class="required">
                                                        Date Start <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator12" runat="server" ErrorMessage="Field Required" ControlToValidate="emp_DateStart" ForeColor="Red" ValidationGroup="UpdateEmployeeGroup"></asp:RequiredFieldValidator></label>
                                                    <div class="input-group">
                                                        <input class="form-control" id="emp_DateStart" type="date" min="1900-01-01" max="2099-12-31" runat="server">
                                                    </div>
                                              <label for="" class="required">
                                                        Date Separated <span class="required text-red"></span></label>
                                                    <div class="input-group">
                                                        <input class="form-control" id="emp_DateSeparated" type="date" min="1900-01-01" max="2099-12-31" runat="server">
                                                    </div>
                                            <label for="ContractStart" class="required">
                                                Contract Start <span class="required text-red"></span>
                                            </label>
                                            <div class="input-group">
                                                <input class="form-control" id="emp_ContractStart" type="date" min="1900-01-01" max="2099-12-31" runat="server">
                                            </div>
                                            <label for="ContractEnd" class="required">
                                                Contract End <span class="required text-red"></span>
                                            </label>
                                            <div class="input-group">
                                                <input class="form-control" id="emp_ContractEnd" type="date" min="1900-01-01" max="2099-12-31" runat="server">
                                            </div>

                                        </div>
                                        <div class="col-lg-6 col-xs-6">
                                            <label for="Employee_SSSNo" class="required">SSS</label>
                                            <input size="11" class="form-control ssno" id="emp_SSSNo" name="emp_SSSNo" type="text" maxlength="12" runat="server" placeholder="00-0000000-0" />
                                            <label for="Employee_TIN" class="required">TIN</label>
                                            <input size="11" class="form-control tinno" id="emp_TIN" name="Employee[TIN]" type="text" maxlength="11" runat="server" placeholder="000-000-000" />
                                            <label for="Employee_PagibigNo" class="required">Pagibig MID No</label>
                                            <input size="14" class="form-control pagibigno" id="emp_PagibigNo" name="emp_PagibigNo" type="text" maxlength="14" runat="server" placeholder="0000-000000-00" />
                                            <label for="Employee_PhilHealth_No" class="required">Phil Health No</label>
                                            <input size="14" class="form-control philno" id="PhilHealth_No" name="PhilHealth_No" type="text" maxlength="14" runat="server" placeholder="00-000000000-0" />
                                            <label for="Employee_NationalIDNo" class="required">National ID No</label><input class="form-control" maxlength="12" autocomplete="off" name="emp_NationalIDNo" id="emp_NationalIDNo" type="text" runat="server" />

                                            <label for="Employee_LicNo" class="required">License No.</label><input class="form-control" maxlength="15" name="emp_LicNo" id="emp_LicNo" type="text" runat="server" />
                                            <label for="Employee_LicExpDate" class="required">License Expiry Date</label>
                                            <input class="form-control" id="emp_LicExpDate" name="emp_LicExpDate" type="date" runat="server" />

                                            <label for="Employee_Status" class="required">Status</label>
                                            <select class="form-control" name="emp_Status" id="emp_Status" runat="server">
                                                <option value="">---Select Status---</option>

                                            </select>
                                            <label for="Employee_RankCode" class="required">Rank</label>
                                            <select class="form-control" name="emp_Rank" id="emp_Rank" runat="server">
                                                <option value="">---Select Rank---</option>

                                            </select>

                                            <label for="Employee_Approver1" class="required">
                                                First Approver</label>
                                            <select class="form-control" name="emp_Approver1" id="emp_Approver1" runat="server">
                                                <option value="">---Select Approver---</option>

                                            </select>
                                            <label for="Employee_Approver2" class="required">Second Approver<span class="required"></span></label>
                                            <select class="form-control" name="emp_Approver2" id="emp_Approver2" runat="server">
                                                <option value="">---Select Approver 2---</option>

                                            </select>

                                            <label for="Employee_Email" class="required">
                                                Email
       
                                    <span class="required text-red">*
       
                                      <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="emp_Email" ValidationGroup="UpdateEmployeeGroup"
                                            ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                            Display="Dynamic" ErrorMessage="Invalid email address" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator30" Display="dynamic" runat="server" ControlToValidate="emp_Email" ValidationGroup="UpdateEmployeeGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator>--%>
                                    </span>
                                            </label>
                                            <input class="form-control" maxlength="255" name="emp_Email" id="emp_Email" type="text" runat="server" />
                                            
                                            <%--<label for="Employee_BasicPay" class="required">
                                                Basic Pay<span class="required">*
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="emp_BasicPay" ValidationGroup="UpdateEmployeeGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                            
                                            <input size="14" class="form-control philno" id="emp_BasicPay" name="PhilHealth_No" type="text" maxlength="14" runat="server" />--%>

                                            <label for="emp_BasicPay" class="required">Basic Pay <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator11" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="emp_BasicPay" ValidationGroup="UpdateEmployeeGroup"></asp:RequiredFieldValidator></label>
                                                                <div class="input-group">
                                                                    <input class="form-control" id="emp_BasicPay" name="Leavesapp[LeaveHrs]" type="number" min="1" max="100000" step=".01" onkeypress="return isNumberKey(event)"  runat="server" />
                                                                </div>
                                              
                                            <label for="emp_WorkDays" class="required">Work Days(per month)<span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="emp_WorkDays" ValidationGroup="UpdateEmployeeGroup"></asp:RequiredFieldValidator></label>
                                                                <div class="input-group">
                                                                    <input class="form-control" id="emp_WorkDays" name="emp_WorkDays" type="number" min="1" max="100000" step=".01" onkeypress="return isNumberKey(event)"  runat="server" />
                                                                </div>
                                            <label for="emp_RegularizationDate" class="required">
                                                Regularization Date <span class="required text-red"></span>
                                            </label>
                                            <div class="input-group">
                                                <input class="form-control" id="emp_RegularizationDate" type="date" min="1900-01-01" max="2099-12-31" runat="server">
                                            </div>
                                            <label for="LeaveCreditPerYear" class="required">
                                                                Leave Credit Per Year<span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator15" runat="server" ErrorMessage="Field Required" ControlToValidate="LeaveCreditPerYear" ForeColor="Red" ValidationGroup="UpdateEmployeeGroup"></asp:RequiredFieldValidator></label>
                                                            <asp:TextBox TextMode="Number" ID="LeaveCreditPerYear" class="form-control" runat="server" min="0" max="365"  step="1"/>
                                        <span Style=" font-size: 14px;">
                                            <asp:CheckBox ID="emp_IsPioneer" runat="server" CssClass="checkbox-inline" Text="Pioneer"></asp:CheckBox>

                                        </span>
                                        </div>
                                    </div>
                                </div>
                                <br />

                                <div class="form-actions">
                                    <asp:Button ID="yw1" class="btn btn-primary" Width="80px" runat="server" Text="Save"
                                        OnClick="btnSubmit_Click"  ValidationGroup="UpdateEmployeeGroup"></asp:Button>
                                    <button class="btn btn-danger" Width="80px" id="yw2" type="submit" name="yt1" runat="server" onserverclick="btnCancel_Click"><i class="icon-remove"></i>Cancel</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</asp:Content>
