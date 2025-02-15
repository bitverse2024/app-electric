﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeView.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees.EmployeeView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="\scripts\jquery-1.7.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        function Confirm() {
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
                <h3 class="m-0 text-dark">Employees<small> View Employee</small></h3>
                <section class="card">
                    <div class="card-header">
                        <%if (Session["ROLES"].ToString() == "employee")
                            { %>
                        
                        <a href="ChangePassword.aspx" class="btn btn-default"><i class="fa fa-edit"></i><span class="h6">Change Password</span></a>
                        <% }
                            if (Session["ROLES"].ToString() == "admin")
                            { %>
                        <a href="EmployeeMaster.aspx" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Back</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/CreateEmployee.aspx")%>" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                        <a href="EmployeeMaster.aspx" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/EmployeeUpdateView.aspx?empid="+empno+"")%>" class="btn btn-default"><i class="fa fa-file"></i><span class="h6">Update</span></a>
                        <a href="ChangePassword.aspx" class="btn btn-default"><i class="fa fa-edit"></i><span class="h6">Change Password</span></a>
                        <%} %>
                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="row">
                                <section class="col-lg-6">
                                    <div class="card card-widget widget-user-2">
                                        <!-- Add the bg color to the header using any of the bg-* classes -->
                                        <div class="widget-user-header bg-blue">
                                            <div class="widget-user-image">
                                                <asp:Image ID="userimg" runat="server" CssClass="img-circle" ImageUrl="/../../../images/1.jpg"></asp:Image>                                                
                                            </div>
                                            <!-- /.widget-user-image -->
                                            <h3 class="widget-user-username">
                                                <asp:Label ID="lblFullName" runat="server" Text="Label"></asp:Label></h3>
                                            <h5 class="widget-user-desc">
                                                <asp:Label ID="lblPosition" runat="server" Text="Label"></asp:Label></h5>
                                        </div>
                                        <div class="card-body p-0">
                                            <ul class="nav flex-column">
                                                <li class="nav-item"><a href="#Personal2" data-toggle="modal" data-target="#Personal2" class="nav-link"><span class="h6">Personal</span></a></li>
                                                <li class="nav-item even"><a href="#Personnel" data-toggle="modal" data-target="#Personnel" class="nav-link"><span class="h6">Personnel</span></a></li>
                                                <li class="nav-item odd"><a href="#Payroll" data-toggle="modal" data-target="#Payroll" class="nav-link"><span class="h6">Payroll</span></a></li>
                                                <%--<li class="nav-item"><a href="201/viewmovement.aspx?id=<%=empno%>" class="nav-link"><span class="h6">Movement</span></a></li>--%>
                                                <li class="nav-item"><a href="#Schedule" data-toggle="modal" data-target="#Schedule" class="nav-link"><span class="h6">Schedule</span></a></li>
                                                <%--<li class="nav-item"><a href="201/viewfiles.aspx?id=<%=empno%>" class="nav-link"><span class="h6">201 Files</span></a></li>--%>
                                                <li class="nav-item"><a href="201/viewloans.aspx?empid=<%=empno%>" class="nav-link"><span class="h6">Loans</span></a></li>
                                                <%--<li class="nav-item"><a href="201/viewhistory.aspx?id=<%=empno%>" class="nav-link"><span class="h6">Employment</span></a></li>--%>
                                                <%--<li class="nav-item"><a href="201/viewdependent.aspx?id=<%=empno%>" class="nav-link"><span class="h6">Dependent</span></a></li>
                                                <li class="nav-item"><a href="201/viewfbground.aspx?id=<%=empno%>" class="nav-link"><span class="h6">Family</span></a></li>
                                                <li class="nav-item"><a href="201/viewmedical.aspx?id=<%=empno%>" class="nav-link"><span class="h6">Medical</span></a></li>
                                                <li class="nav-item"><a href="201/vieweducation.aspx?id=<%=empno%>" class="nav-link"><span class="h6">Education</span></a></li>
                                                <li class="nav-item"><a href="201/viewexams.aspx?id=<%=empno%>" class="nav-link"><span class="h6">Exams/Seminars</span></a></li>--%>
                                                <li class="nav-item"><a href="201/viewoffenses.aspx?id=<%=empno%>" class="nav-link"><span class="h6">Offenses</span></a></li>
                                                <%--<li class="nav-item"><a href="#" class="nav-link"><span class="h6">Evaluation</span></a></li>
                                                <li class="nav-item"><a href="201/viewtraining.aspx?id=<%=empno%>" class="nav-link"><span class="h6">Training</span></a></li>
                                                <li class="nav-item"><a href="201/viewassets.aspx?id=<%=empno%>" class="nav-link"><span class="h6">Assets</span></a></li>
                                                <li class="nav-item"><a href="201/viewlicenses.aspx?id=<%=empno%>" class="nav-link"><span class="h6">Licenses</span></a></li>--%>
                                                <%if (Session["ROLES"].ToString() == "admin")
                                                    {%>
                                                <li class="nav-item"><a href="201/AllowanceSetting.aspx?id=<%=empno%>" class="nav-link"><span class="h6">Allowance Settings</span></a></li>
                                                <li class="nav-item"><a href="201/DTRSetting.aspx?id=<%=empno%>" class="nav-link"><span class="h6">DTR Settings</span></a></li>
                                                <%} %>
                                            </ul>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="card">
                                        <div style="padding-left: 10px; padding-top: 5px;">
                                            <h3 class="card-title"><i class="fa fa-camera"></i>
                                                Update Photo
                                            </h3>
                                        </div>
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-sm-5 text-center">
                                                    <asp:Image ID="imageEmp" runat="server" CssClass="thumbnail" Width="150" Height="150" ImageUrl="~/Pages/Admin/Employee/images/1.jpg"></asp:Image>

                                                </div>
                                                <div class="col-6 text-left">
                                                    <%--<label for="UploadForm_file">Choose File</label> 
                                                                <input id="ytUploadForm_file" type="hidden" value="" name="UploadForm[file]" /><input name="UploadForm[file]" id="UploadForm_file" type="file" />--%>
                                                    <div class="input-group">
                                                        <div class="row">
                                                            <span class="input-group-lg">Select File: </span>
                                                            <asp:RequiredFieldValidator ID="validatorUploader" CssClass="small" runat="server" ControlToValidate="fuUploader"
                                                                ValidationGroup="uploadGroup" ForeColor="Red" ErrorMessage="Select Image to upload."></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="row">
                                                            <asp:FileUpload ID="fuUploader" runat="server" CssClass="form-control btn-default" />
                                                            <asp:LinkButton ID="btnUploadImage" runat="server" CssClass="btn btn-primary btn-block" ValidationGroup="uploadGroup"
                                                                OnClick="btnUploadImage_Click">Upload</asp:LinkButton>
                                                            <asp:RegularExpressionValidator ID="validatorFileUpload"
                                                                ControlToValidate="fuUploader" ValidationGroup="uploadGroup" runat="server"
                                                                ErrorMessage="Only image with .jpg, .jpeg or .png is allowed."
                                                                ValidationExpression="^.*\.(jpg|JPG|JPEG|jpeg|png|PNG)$" CssClass="small"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </section>

                                <section class="col-lg-6" style="padding-top: 10px">
                                    <div class="card">
                                        <div class="card-body">
                                            <h3>
                                                <i class="fa fa-edit"></i>
                                                <span class="badge bg-success">Active</span>
                                            </h3>
                                        
                                            <%=GetEmployeeData()%>
                                        </div>
                            </div>
                </section>
            </div>
        </div>
    </div>
    </section>
            </div>
        </div>
    </div>

    <!-- Button HTML (to Trigger Modal) -->
    <!-- Modal Personal HTML -->
    <div id="Personal2" class="modal fade in">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Personal</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    <%=GetPersonal()%>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                    <a href="#UpdatePersonal2" data-toggle="modal" data-target="#UpdatePersonal2" class="btn btn-primary">Update</a>
                </div>
            </div>
        </div>
    </div>
    <div id="UpdatePersonal2" class="modal fade in">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Personal</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    <table class="detail-view table table-striped table-condensed" id="yw2">
                        <tr class="odd">
                            <th><span class="h8">Permanent Address</span></th>
                            <td>
                                <asp:TextBox ID="emp_PermanentAddress" CssClass="form-control" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="even">
                            <th><span class="h8">Zip Code</span></th>
                            <td>
                                <asp:TextBox ID="emp_PermanentZipCode" CssClass="form-control" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="odd">
                            <th><span class="h8">Present Address</span></th>
                            <td>
                                <asp:TextBox ID="emp_PresentAddress" CssClass="form-control" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="even">
                            <th><span class="h8">Zip Code</span></th>
                            <td>
                                <asp:TextBox ID="emp_PresentZipCode" CssClass="form-control" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="odd">
                            <th><span class="h8">Home Tel No</span></th>
                            <td>
                                <asp:TextBox ID="emp_HomeTelNo" CssClass="form-control" ClientIDMode="static" runat="server" MaxLength="11"></asp:TextBox></td>
                        </tr>

                        <tr class="even">
                            <th><span class="h8">Cellphone No</span></th>
                            <td>
                                <asp:TextBox ID="emp_CellPhoneNo" CssClass="form-control" class="cpno" runat="server" MaxLength="12" placeholder="0000-0000000"></asp:TextBox></td>
                        </tr>
                        <tr class="even">
                            <th><span class="h8">Email</span></th>
                            <td>
                                <asp:TextBox ID="emp_Email" CssClass="form-control" runat="server"></asp:TextBox></td>
                        </tr>
                        <%--<tr class="odd"><th>Birthdate</th><td><asp:TextBox ID="emp_Birthdate" runat="server"></asp:TextBox></td></tr>--%>
                        <tr class="odd">
                            <th><span class="h8">Birthdate</span></th>
                            <td>
                                <input class="form-control" id="emp_Birthdate" name="txtUpdEffectiveDate" type="date" maxlength="11" min="1900-01-01" max="2099-12-31" runat="server" /></td>
                        </tr>
                        <tr class="even">
                            <th><span class="h8">Birth Place</span></th>
                            <td>
                                <asp:TextBox ID="emp_Birthplace" CssClass="form-control" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="odd">
                            <th><span class="h8">Civil Status</span></th>
                            <td>
                                <select id="emp_CivilStatus" class="form-control" runat="server">
                                    <option value="">-Select Civil Status-</option>
                                    <option value="S">Single</option>
                                    <option value="M">Married</option>
                                </select></td>
                        </tr>
                        <%--<tr class="odd"><th><span class="h8">Civil Status</span></th><td><asp:TextBox ID="emp_CivilStatus" CssClass="form-control" runat="server"></asp:TextBox></td></tr>--%>
                        <%--<tr class="even"><th><span class="h8">Gender</span></th><td><asp:TextBox ID="emp_Gender" CssClass="form-control" runat="server"></asp:TextBox></td></tr>--%>
                        <tr class="odd">
                            <th><span class="h8">Gender</span></th>
                            <td>
                                <select id="emp_Gender" class="form-control" runat="server">
                                    <option value="">-Select Gender-</option>
                                    <option value="M">Male</option>
                                    <option value="F">Female</option>
                                </select></td>
                        </tr>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                    <asp:Button ID="btnUpdatePersonal" runat="server" Text="Submit" class="btn btn-primary"
                        OnClick="btnUpdatePersonal_Click" OnClientClick="Confirm()" />
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Personnel HTML -->
    <div id="Personnel" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Personnel</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    <%=GetPersonnel()%>
                    <%--<table class="detail-view" id="yw3"><tr class="odd"><th>SSS</th><td>33-2453668-4</td></tr>
<tr class="even"><th>TIN</th><td>178-709-371</td></tr>
<tr class="odd"><th>Pagibig MID No</th><td>1210-0078-5017</td></tr>
<tr class="even"><th>Phil Health No</th><td>19-026455453-9</td></tr>
<tr class="odd"><th>Date Start</th><td>02/29/2016</td></tr>
<tr class="even"><th>Date Separated</th><td><span class="null">Not set</span></td></tr>
<tr class="odd"><th>Biometrics ID</th><td>40034</td></tr>
</table>           --%>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                    <a href="#UpdatePersonnel" data-toggle="modal" data-target="#UpdatePersonnel" class="btn btn-primary">Update</a>
            <%--        <a href="201/viewmovement.aspx?id=<%=empno%>" class="btn btn-primary">Movement</a>
                    <a href="201/viewfiles.aspx?id=<%=empno%>" class="btn btn-primary">Files</a>--%>
                </div>
            </div>
        </div>
    </div>
    <div id="UpdatePersonnel" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Personnel</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    <table class="detail-view table table-striped table-condensed" id="yw3">
                        <tr class="odd">
                            <th><span class="h8">SSS</span></th>
                            <td>
                                <asp:TextBox ID="emp_SSSNo" CssClass="form-control ssno" maxlength="12" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="even">
                            <th><span class="h8">TIN</span></th>
                            <td>
                                <asp:TextBox ID="emp_TIN" CssClass="form-control tinno" maxlength="11" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="odd">
                            <th><span class="h8">Pagibig MID No</span></th>
                            <td>
                                <asp:TextBox ID="emp_PagibigNo" CssClass="form-control pagibigno" maxlength="14" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="even">
                            <th><span class="h8">Phil Health No</span></th>
                            <td>
                                <asp:TextBox ID="PhilHealth_No" CssClass="form-control philno" maxlength="14" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="odd">
                            <th><span class="h8">National ID</span></th>
                            <td>
                                <asp:TextBox ID="emp_NationalIDNo" CssClass="form-control philno" maxlength="12" runat="server"></asp:TextBox>
                                </td>
                        </tr>
                        <tr class="even">
                            <th><span class="h8">Date Start</span></th>
                            <td>
                                <input class="form-control" id="emp_DateStart" name="txtUpdDateStart" type="date" min="1900-01-01" max="2099-12-31" maxlength="11" runat="server" /></td>
                        </tr>
                        <tr class="odd">
                            <th><span class="h8">Date Separated</span></th>
                            <td>
                                <input class="form-control" id="emp_DateSeparated" name="txtUpdDateSeparated" type="date" min="1900-01-01" max="2099-12-31" maxlength="11" runat="server" /></td>
                        </tr>
                        <tr class="even">
                            <th><span class="h8">Biometrics ID</span></th>
                            <td>
                                <asp:TextBox ID="emp_BiometricsID" CssClass="form-control" runat="server"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                    <asp:Button ID="btnUpdatePersonnel" runat="server" Text="Submit" class="btn btn-primary"
                        OnClick="btnUpdatePersonnel_Click" OnClientClick="Confirm()" />

                </div>
            </div>
        </div>
    </div>


    <!-- Modal Schedule HTML -->
    <div id="Schedule" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Schedule</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    <%=GetSchedule() %>

                    <%--<table class="detail-view" id="yw4"><tr class="odd"><th>Monday</th><td>07:00 - 16:00</td></tr>
        <tr class="even"><th>Tuesday</th><td>08:30 - 17:30</td></tr>
        <tr class="odd"><th>Wednesday</th><td>08:30 - 17:30</td></tr>
        <tr class="even"><th>Thursday</th><td>08:30 - 17:30</td></tr>
        <tr class="odd"><th>Friday</th><td>08:30 - 17:30</td></tr>
        <tr class="even"><th>Saturday</th><td>0</td></tr>
        <tr class="odd"><th>Sunday</th><td>0</td></tr>
        </table>--%>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                    <%--<a href="/dataland/index.php?r=employee/updatesched&id=1" class="btn btn-primary">Update</a>--%>
                    <a href="#UpdateSchedule" data-toggle="modal" data-target="#UpdateSchedule" class="btn btn-primary">Update</a>

                </div>
            </div>
        </div>
    </div>
    <div id="UpdateSchedule" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Schedule</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">

                    <table class="detail-view table table-striped table-condensed" id="yw4">
                        <tr class="odd">
                            <th><span class="h8">Monday</span></th>
                            <td>
                                <select id="emp_Monday" class="form-control" runat="server">
                                    <option value="0">Restday</option>
                                </select>
                            </td>
                        </tr>
                        <tr class="even">
                            <th><span class="h8">Tuesday</span></th>
                            <td>
                                <select id="emp_Tuesday" class="form-control" runat="server">
                                    <option value="0">Restday</option>
                                </select></td>
                        </tr>
                        <tr class="odd">
                            <th><span class="h8">Wednesday</span></th>
                            <td>
                                <select id="emp_Wednesday" class="form-control" runat="server">
                                    <option value="0">Restday</option>
                                </select></td>
                        </tr>
                        <tr class="even">
                            <th><span class="h8">Thursday</span></th>
                            <td>
                                <select id="emp_Thursday" class="form-control" runat="server">
                                    <option value="0">Restday</option>
                                </select></td>
                        </tr>
                        <tr class="odd">
                            <th><span class="h8">Friday</span></th>
                            <td>
                                <select id="emp_Friday" class="form-control" runat="server">
                                    <option value="0">Restday</option>
                                </select></td>
                        </tr>
                        <tr class="even">
                            <th><span class="h8">Saturday</span></th>
                            <td>
                                <select id="emp_Saturday" class="form-control" runat="server">
                                    <option value="0">Restday</option>
                                </select></td>
                        </tr>
                        <tr class="odd">
                            <th><span class="h8">Sunday</span></th>
                            <td>
                                <select id="emp_Sunday" class="form-control" runat="server">
                                    <option value="0">Restday</option>
                                </select></td>
                        </tr>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                    <asp:Button ID="btnUpdateSched" runat="server" class="btn btn-primary"
                        Text="Submit" OnClick="btnUpdateSched_Click" OnClientClick="Confirm()" />

                </div>
            </div>
        </div>
    </div>

    <!-- Modal Payroll HTML -->
    <div id="Payroll" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Payroll</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">

                    <%=GetPayroll()%>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                    <a href="#UpdatePayroll" data-toggle="modal" data-target="#UpdatePayroll" class="btn btn-primary">Update</a>
                    <%--<a href="201/viewloans.aspx?empid=<%=empno%>" class="btn btn-primary">Loans</a>--%>
                </div>
            </div>
        </div>
    </div>

    <div id="UpdatePayroll" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Payroll</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">


                    <%--<%=GetUpdatePayroll()%>--%>

                    <table class="detail-view table table-striped table-condensed" id="Table1">
                        <%--<tr class="odd">
                            <th><span class="h8">Wage Type</span></th>
                            <td>
                                <asp:TextBox ID="emp_WageType" CssClass="form-control" runat="server"></asp:TextBox></td>
                        </tr>--%>
                        <tr class="even">
                            <th><span class="h8">Basic Pay</span></th>
                            <td>
                                <%--<asp:TextBox ID="emp_BasicPay" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                <asp:TextBox TextMode="Number" ID="emp_BasicPay" class="form-control" runat="server" min="0"  step="0.01"/>
                            </td>
                        </tr>
                        <%--<tr class="odd">
                            <th><span class="h8">Per Day</span></th>
                            <td>
                                <asp:TextBox TextMode="Number" ID="emp_PerDay" class="form-control" runat="server" min="0"  step="0.01"/>
                                </td>
                        </tr>
                        <tr class="even">
                            <th><span class="h8">Basic Allowance</span></th>
                            <td><asp:TextBox TextMode="Number" ID="emp_BasicAllowance" class="form-control" runat="server" min="0"  step="0.01"/>
                                </td>
                        </tr>
                        <tr class="odd">
                            <th><span class="h8">Taxable OT Allowance</span></th>
                            <td>
                                <asp:TextBox ID="emp_TaxableOTAllowance" CssClass="form-control" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="even">
                            <th><span class="h8">Non-Taxable OT Allowance</span></th>
                            <td>
                                <asp:TextBox ID="emp_NonTaxableOTAllowance" CssClass="form-control" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="odd">
                            <th><span class="h8">Out of Station Allowance</span></th>
                            <td>
                                <asp:TextBox ID="emp_OutOfStationAllowance" CssClass="form-control" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="even">
                            <th><span class="h8">Other Allowance</span></th>
                            <td>
                                <asp:TextBox ID="emp_OtherAllowance" CssClass="form-control" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="odd">
                            <th><span class="h8">ECOLA</span></th>
                            <td>
                                <asp:TextBox ID="emp_ECOLA" CssClass="form-control" runat="server"></asp:TextBox></td>
                        </tr>--%>
                        <tr class="even">
                            <th><span class="h8">SSS Deduction</span></th>
                            <td>
                                <%--<asp:TextBox ID="emp_SSSDed" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                <asp:TextBox TextMode="Number" ID="emp_SSSDed" class="form-control" runat="server"  step="0.01"/>
                            </td>
                        </tr>
                        <%--<tr class="odd">
                            <th><span class="h8">Loan Deduction</span></th>
                            <td>
                                <asp:TextBox ID="emp_LoanDed" CssClass="form-control" runat="server"></asp:TextBox></td>
                        </tr>--%>
                        <tr class="even">
                            <th><span class="h8">Philhealth Deduction</span></th>
                            <td>
                                <%--<asp:TextBox ID="emp_PhilHealthDed" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                <asp:TextBox TextMode="Number" ID="emp_PhilHealthDed" class="form-control" runat="server" min="0"  step="0.01"/>
                            </td>
                        </tr>
                        <tr class="odd">
                            <th><span class="h8">Pagibig Deduction</span></th>
                            <td>
                                <%--<asp:TextBox ID="emp_PagibigDed" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                <asp:TextBox TextMode="Number" ID="emp_PagibigDed" class="form-control" runat="server" min="0"   step="0.01"/>
                            </td>
                        </tr>
                        <%--<tr class="even">
                            <th><span class="h8">Acct Type</span></th>
                            <td>
                                <asp:TextBox ID="emp_AcctType" CssClass="form-control" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="odd">
                            <th><span class="h8">Bank Code</span></th>
                            <td>
                                <asp:TextBox ID="emp_BankCode" CssClass="form-control" runat="server"></asp:TextBox></td>
                        </tr>--%>
                        <tr class="even">
                            <th><span class="h8">Tax</span></th>
                            <td>
                                <%--<asp:TextBox ID="emp_YTD_WTax" CssClass="form-control" runat="server" ></asp:TextBox>--%>
                                <asp:TextBox TextMode="Number" ID="emp_YTD_WTax" class="form-control" runat="server" min="0"   step="0.01"/>
                            </td>
                        </tr>
                        <tr class="odd">
                            <th><span class="h8">Contribution</span></th>
                            <td>
                                <asp:CheckBox ID="emp_isEnableContriDed" runat="server" CssClass="checkbox-inline"></asp:CheckBox>
                            </td>
                        </tr>
                        <tr class="even">
                            <th><span class="h8">Loan</span></th>
                            <td>
                                <asp:CheckBox ID="emp_isEnableLoanDed" runat="server" CssClass="checkbox-inline"></asp:CheckBox>
                            </td>
                        </tr>
                    </table>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                    <asp:Button ID="btnUpdatePayroll" runat="server" Text="Submit" class="btn btn-primary"
                        OnClick="btnUpdatePayroll_Click" OnClientClick="Confirm()" />

                </div>
            </div>
        </div>
    </div>
    </i>
</asp:Content>
