﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="createapplicant.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.HRRecruitment.createapplicant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to Apply for this Position?")) {
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
                    <h3 class="m-0 text-dark">Recruitment<small> Create Applicants</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="../../Default_kioskapplicant.aspx" class="btn btn-default"><i class="fa fa-th-list"></i><span class="h5">List</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">
                                        <div class="form">
                                            <form enctype="multipart/form-data" class="form-vertical" id="applicant-form" action="/index.php?r=applicant/create&amp;pd=Billing%20&amp;%20Collection%20Associate%20(Post)&amp;hrmr=2&amp;mr=2&amp;division=2&amp;fname=CLYDE&amp;mname=SILVANO&amp;lname=CIPRIANO&amp;id=45&amp;email=cipriano.clyde@dataland.ph" method="post">
                                                <legend>
                                                    <p class="note" style="font-size: 16px; font-weight: 500">
                                                        Step 1 (Personal Information)
                                    <br />
                                                        <span style="font-weight: bold;">Fields with <span class="required text-red">**</span> are required.</span>
                                                    </p>
                                                </legend>


                                                <div class="">
                                                    <div class="row">
                                                        <div class="col-lg-6">

                                                            <label for="Applicant_SSS" class="required">SSS</label>
                                                            <input size="11" onblur="jQuery.ajax({&#039;type&#039;:&#039;POST&#039;,&#039;url&#039;:&#039;\x2Findex.php\x3Fr\x3Dapplicant\x2Fchecksss&#039;,&#039;cache&#039;:false,&#039;data&#039;:jQuery(this).parents(&quot;form&quot;).serialize(),&#039;success&#039;:function(html){jQuery(&quot;#hours&quot;).html(html)}});" class="form-control" id="Applicant_SSS" name="Applicant[SSS]" type="text" maxlength="50" runat="server" />
                                                            <div id="yw1"></div>
                                                            <select class="form-control" name="Applicant[Blacklist]" id="Applicant_Blacklist">
                                                                <option value="">---Blacklist Applicant---</option>
                                                                <option value="Y">Yes</option>
                                                                <option value="N">No</option>
                                                            </select>
                                                            <label for="Applicant_BranchCode" class="required">Company</label>
                                                            <select class="form-control" name="Applicant[BranchCode]" id="Applicant_BranchCode" runat="server">
                                                                <option value="empty">---Select Company---</option>
                                                                <option value="2">Dataland Sales Corp.</option>
                                                                <option value="1">Dataland, Inc.</option>
                                                                <option value="3">IWH Bohol Resort Corp.</option>
                                                            </select>

                                                            <label for="Applicant_EmploymentType" class="required">Employment Type</label>
                                                            <select class="form-control" name="Applicant[EmploymentType]" id="Applicant_EmploymentType" runat="server">
                                                                <option value="">---Select Type of Employment---</option>
                                                                <option value="Seconded">Seconded</option>
                                                                <option value="Organic">Organic</option>
                                                                <option value="Project Base">Project Base</option>
                                                                <option value="Agency">Agency</option>
                                                            </select>

                                                            <label for="Applicant_PositionDesired" class="required">Position Desired <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Applicant_PositionDesired" ValidationGroup="CreateApplicantGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label><input class="form-control" maxlength="50" name="Applicant[PositionDesired]" id="Applicant_PositionDesired" type="text" runat="server" />
                                                            <label for="Applicant_DateReceived" class="required">Date Applied <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DateReceived" ValidationGroup="CreateApplicantGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                            <input class="form-control datetimepicker" id="DateReceived" name="Applicant[DateReceived]" type="text" runat="server" />
                                                            <label for="Applicant_Surname" class="required">Surname <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Applicant_Surname" ValidationGroup="CreateApplicantGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label><input class="form-control" maxlength="100" name="Applicant[Surname]" id="Applicant_Surname" type="text" runat="server" />
                                                            <label for="Applicant_FirstName" class="required">First Name <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Applicant_FirstName" ValidationGroup="CreateApplicantGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label><input class="form-control" maxlength="100" name="Applicant[FirstName]" id="Applicant_FirstName" type="text" runat="server" />
                                                            <label for="Applicant_Midname" class="required">Midname <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Applicant_Midname" ValidationGroup="CreateApplicantGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label><input class="form-control" maxlength="100" name="Applicant[Midname]" id="Applicant_Midname" type="text" runat="server" />
                                                            <label for="Applicant_BirthDate" class="required">Birth Date</label>
                                                            <input class="form-control datetimepicker" id="BirthDate" name="Applicant[BirthDate]" type="text" maxlength="50" runat="server" />
                                                            <label for="Applicant_EmailAddress" class="required">Email Address</label><input class="form-control" maxlength="50" name="Applicant[EmailAddress]" id="Applicant_EmailAddress" type="text" runat="server" />




                                                        </div>

                                                        <div class="col-lg-6">
                                                            <label for="Applicant_PhilhealthNo" class="required">Philhealth No:</label><input class="form-control" maxlength="14" name="Applicant[PhilhealthNo]" id="Applicant_PhilhealthNo" type="text" runat="server" />
                                                            <label for="Applicant_PagibigNo" class="required">Pagibig No:</label><input class="form-control" maxlength="14" name="Applicant[PagibigNo]" id="Applicant_PagibigNo" type="text" runat="server" />
                                                            <label for="Applicant_TinNo" class="required">TIN No:</label><input class="form-control" maxlength="11" name="Applicant[TinNo]" id="Applicant_TinNo" type="text" runat="server" />
                                                            <label for="Applicant_NationalIDNo" class="required">National ID No:</label><input class="form-control" maxlength="14" name="Applicant[NationalIDNo]" id="Applicant_NationalIDNo" type="text" runat="server" />
                                                            <label for="Applicant_Gender" class="required">Gender</label>
                                                            <select class="form-control" style="margin-bottom: 10px;" name="Applicant[Gender]" id="Applicant_Gender" runat="server">
                                                                <option value="">---Select Gender---</option>
                                                                <option value="M">Male</option>
                                                                <option value="F">Female</option>
                                                            </select>
                                                            <label for="Applicant_Status" class="required">Civil Status</label>
                                                            <select class="form-control" style="margin-bottom: 10px;" name="Applicant[Status]" id="Applicant_Status" runat="server">
                                                                <option value="">---Select Civil Status---</option>
                                                                <option value="S">Single</option>
                                                                <option value="M">Married</option>
                                                                <option value="SE">Separated</option>
                                                                <option value="W">Widowed</option>
                                                            </select>


                                                            <label for="Applicant_Celphone" class="required">Contact No:</label>
                                                            <input size="11" class="form-control" onblur="jQuery.ajax({&#039;type&#039;:&#039;POST&#039;,&#039;url&#039;:&#039;\x2Findex.php\x3Fr\x3Dapplicant\x2Fcheckmobile&#039;,&#039;cache&#039;:false,&#039;data&#039;:jQuery(this).parents(&quot;form&quot;).serialize(),&#039;success&#039;:function(html){jQuery(&quot;#mobile&quot;).html(html)}});" id="Applicant_Celphone" name="Applicant[Celphone]" type="text" maxlength="50" runat="server" />


                                                            <div id="yw2"></div>


                                                            <label for="Applicant_Address" class="required">Address</label><input class="form-control" maxlength="255" placeholder="Ex: San Fernando City, Pampanga, Lubao" name="Applicant[Address]" id="Applicant_Address" type="text" runat="server" />
                                                            <label for="Applicant_Address2" class="required">Address 2</label><input class="form-control" maxlength="255" placeholder="Ex: St. Joseph, B20, L3, No.9" name="Applicant[Address2]" id="Applicant_Address2" type="text" runat="server" />


                                                            <label for="Applicant_Source" class="required">Source</label>
                                                            <select class="form-control" name="Applicant[Source]" id="Applicant_Source" runat="server">
                                                                <option value="0">---Select Source---</option>
                                                                <option value="Referral">Referral</option>
                                                                <option value="Walk-in">Walk-in</option>
                                                                <option value="Headhunter">Headhunter</option>
                                                            </select>
                                                            <br />

                                                            <input class="form-control hidden" maxlength="50" value="2" name="Applicant[division]" id="Applicant_division" type="hidden" runat="server" />
                                                            <input class="form-control hidden" maxlength="50" value="2" name="Applicant[mrid]" id="Applicant_mrid" type="hidden" />
                                                            <input class="form-control hidden" maxlength="50" value="2" name="Applicant[hrmrid]" id="Applicant_hrmrid" type="hidden" />
                                                            <input class="form-control hidden" maxlength="50" value="45" name="Applicant[userid]" id="Applicant_userid" type="hidden" />

                                                            <!-- <label for="Applicant_MedicalDate">MedicalDate</label>				<input style="height:20px;" class="form-control" id="MedicalDate" name="Applicant[MedicalDate]" type="text" /> -->



                                                            <!--<input style="height:20px;" class="form-control" id="StartDate" name="Applicant[StartDate]" type="text" maxlength="50" /> -->


                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="form-actions">
                                                    <button class="btn btn-primary" id="btnSubmit" type="submit" name="yt0" runat="server" onclientclick="Confirm()" onserverclick="btnSubmit_Click" validationgroup="CreateApplicantGroup"><i class="icon-ok icon-white"></i>Save</button>

                                                    <button class="btn btn-primary" type="reset" name="yt1"><i class="icon-remove icon-white"></i>Reset</button>
                                                </div>

                                            </form>
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
