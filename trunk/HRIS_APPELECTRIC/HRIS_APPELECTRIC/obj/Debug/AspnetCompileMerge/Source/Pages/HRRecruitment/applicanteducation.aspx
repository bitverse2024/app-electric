﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="applicanteducation.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.HRRecruitment.applicanteducation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    <h3 class="m-0 text-dark">Recruitment<small> Update Applicant <%=applicantInfo["FullName"] %></small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="applicantprofileview.aspx?id=<%=applicantInfo["id"] %>" class="btn btn-default">
                                <i class="fa fa-arrow-left"></i><span class="h5">Back to Applicant View</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">
                                        <div class="form">

                                            <legend>
                                                <p class="note">Fields with <span class="required text-red">**</span> are required.</p>
                                            </legend>

                                            <div class="row">
                                                <div class="col-lg-2">
                                                    <input id="ytchkPassport" type="hidden" value="0" name="Applicant[Elementary]"><input id="chkElementary" size="1" maxlength="1" onclick="myFunctionElementary()" name="Applicant[Elementary]" value="1" type="checkbox">
                                                    <label for="Applicant_Elementary">Elementary</label><br>
                                                    <script type="text/javascript">
                                                        function myFunctionElementary() {
                                                            var checkBox = document.getElementById("chkElementary");
                                                            var dv = document.getElementById("divElementary");
                                                            if (checkBox.checked == true) {
                                                                dv.style.display = "block";
                                                            } else {
                                                                dv.style.display = "none";
                                                            }
                                                        }

                                                    </script>

                                                    <input id="ytchkPassport1" type="hidden" value="0" name="Applicant[HighSchool]"><input id="chkSecondary" size="1" maxlength="1" name="Applicant[HighSchool]" onclick="myFunctionSecondary()" value="1" type="checkbox">
                                                    <label for="Applicant_HighSchool">Secondary</label><br>
                                                    <script type="text/javascript">
                                                        function myFunctionSecondary() {
                                                            var checkBox = document.getElementById("chkSecondary");
                                                            var dv = document.getElementById("divSecondary");
                                                            if (checkBox.checked == true) {
                                                                dv.style.display = "block";
                                                            } else {
                                                                dv.style.display = "none";
                                                            }
                                                        }

                                                    </script>

                                                    <input id="ytchkPassport2" type="hidden" value="0" name="Applicant[College]"><input id="chkTertiary" size="1" maxlength="1" onclick="myFunctionTertiary()" name="Applicant[College]" value="1" type="checkbox">
                                                    <label for="Applicant_College">Tertiary</label><br>

                                                    <script type="text/javascript">
                                                        function myFunctionTertiary() {
                                                            var checkBox = document.getElementById("chkTertiary");
                                                            var dv = document.getElementById("divTertiary");
                                                            if (checkBox.checked == true) {
                                                                dv.style.display = "block";
                                                            } else {
                                                                dv.style.display = "none";
                                                            }
                                                        }

                                                    </script>

                                                    <input id="ytchkPassport3" type="hidden" value="0" name="Applicant[masterdegree]"><input id="chkMaster" size="1" maxlength="1" name="Applicant[masterdegree]" onclick="myFunctionMaster()" value="1" type="checkbox">
                                                    <label for="Applicant_masterdegree">Master's Degree</label><br>
                                                    <script type="text/javascript">
                                                        function myFunctionMaster() {
                                                            var checkBox = document.getElementById("chkMaster");
                                                            var dv = document.getElementById("divMaster");
                                                            if (checkBox.checked == true) {
                                                                dv.style.display = "block";
                                                            } else {
                                                                dv.style.display = "none";
                                                            }
                                                        }

                                                    </script>

                                                    <input id="ytchkPassport4" type="hidden" value="0" name="Applicant[doctoraldegree]"><input id="chkDoctoral" size="1" maxlength="1" name="Applicant[doctoraldegree]" onclick="myFunctionDoctoral()" value="1" type="checkbox">
                                                    <label for="Applicant_doctoraldegree">Doctoral Degree</label><br>
                                                    <script type="text/javascript">
                                                        function myFunctionDoctoral() {
                                                            var checkBox = document.getElementById("chkDoctoral");
                                                            var dv = document.getElementById("dvDoctoral");
                                                            if (checkBox.checked == true) {
                                                                dv.style.display = "block";
                                                            } else {
                                                                dv.style.display = "none";
                                                            }
                                                        }

                                                    </script>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div id="divElementary" style="display: none; margin-bottom: 1rem;">
                                                        <label for="Applicant_ElementaryYear">Year Graduated</label>
                                                        <input class="form-control" maxlength="50" name="Applicant[ElementaryYear]" id="Applicant_ElementaryYear" type="text" runat="server">
                                                        <label for="Applicant_Elementary">Elementary</label>
                                                        <textarea class="form-control" maxlength="50" name="Applicant[Elementary]" id="Applicant_Elementary" runat="server"></textarea>
                                                    </div>

                                                    <div id="divSecondary" style="display: none; margin-bottom: 1rem;">
                                                        <label for="Applicant_HighSchoolYear">Year Graduated</label>
                                                        <input class="form-control" maxlength="50" name="Applicant[HighSchoolYear]" id="Applicant_HighSchoolYear" type="text" runat="server">
                                                        <label for="Applicant_HighSchool">Secondary</label>
                                                        <textarea class="form-control" maxlength="50" name="Applicant[HighSchool]" id="Applicant_HighSchool" runat="server"></textarea>
                                                    </div>

                                                    <div id="divTertiary" style="display: none; margin-bottom: 1rem;">
                                                        <label for="Applicant_CollegeYear">Year Graduated</label>
                                                        <input class="form-control" maxlength="50" name="Applicant[CollegeYear]" id="Applicant_CollegeYear" type="text" runat="server">
                                                        <label for="Applicant_College">Tertiary</label>
                                                        <textarea class="form-control" maxlength="50" name="Applicant[College]" id="Applicant_College" runat="server"></textarea>
                                                    </div>

                                                    <div id="divMaster" style="display: none; margin-bottom: 1rem;">
                                                        <label for="Applicant_masteryear">Year Graduated</label>
                                                        <input class="form-control" maxlength="50" name="Applicant[masteryear]" id="Applicant_masteryear" type="text" value="" runat="server">
                                                        <label for="Applicant_masterdegree">Master's Degree</label>
                                                        <textarea class="form-control" maxlength="50" name="Applicant[masterdegree]" id="Applicant_masterdegree" runat="server"></textarea>
                                                    </div>

                                                    <div id="dvDoctoral" style="display: none; margin-bottom: 1rem;">
                                                        <label for="Applicant_doctoralyear">Year Graduated</label>
                                                        <input class="form-control" maxlength="50" name="Applicant[doctoralyear]" id="Applicant_doctoralyear" type="text" value="" runat="server">
                                                        <label for="Applicant_doctoraldegree">Doctoral Degree</label>
                                                        <textarea class="form-control" maxlength="50" name="Applicant[doctoraldegree]" id="Applicant_doctoraldegree" runat="server"></textarea>
                                                    </div>

                                                </div>
                                            </div>
                                            <br>
                                            <%--<button class="btn btn-primary" type="submit" runat="server" name="yt0" onclick="btnsaveUpdate_Click"><i class="icon-ok icon-white"></i> Save</button>--%>
                                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Update"
                                                OnClick="btnsaveUpdate_Click"></asp:Button>
                                        </div>
                                    </div>

                                    <div class="box box-danger">
                                        <div class="box-header">
                                            <h3 class="box-title" style="margin-bottom: 2rem;">Educational Attainment</h3>
                                        </div>
                                        <div class="container">
                                            <div class="col-lg-5">
                                                <table class="detail-view table table-striped table-condensed" id="yw0">
                                                    <tbody>
                                                        <tr class="even">
                                                            <th>Elementary</th>
                                                            <td><%=applicantInfo["Elementary"] %></td>
                                                        </tr>
                                                        <tr class="odd">
                                                            <th>Secondary</th>
                                                            <td><%=applicantInfo["HighSchool"] %></td>
                                                        </tr>
                                                        <tr class="even">
                                                            <th>Tertiary</th>
                                                            <td><%=applicantInfo["College"] %></td>
                                                        </tr>
                                                        <tr class="odd">
                                                            <th>Master's Degree</th>
                                                            <td><%=applicantInfo["masterdegree"] %></td>
                                                        </tr>
                                                        <tr class="even">
                                                            <th>Doctoral Degree</th>
                                                            <td><%=applicantInfo["doctoraldegree"] %></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                            <div class="col-lg-3">
                                                <table class="detail-view table table-striped table-condensed" id="yw1">
                                                    <tbody>
                                                        <tr class="even">
                                                            <th>Year Graduated</th>
                                                            <td><%=applicantInfo["ElementaryYear"]%></td>
                                                        </tr>
                                                        <tr class="odd">
                                                            <th>Year Graduated</th>
                                                            <td><%=applicantInfo["HighSchoolYear"]%></td>
                                                        </tr>
                                                        <tr class="even">
                                                            <th>Year Graduated</th>
                                                            <td><%=applicantInfo["CollegeYear"]%></td>
                                                        </tr>
                                                        <tr class="odd">
                                                            <th>Year Graduated</th>
                                                            <td><%=applicantInfo["masteryear"]%></td>
                                                        </tr>
                                                        <tr class="even">
                                                            <th>Year Graduated</th>
                                                            <td><%=applicantInfo["doctoralyear"]%></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
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
        </div>
        <!-- /.row (main row) -->
    </aside>
</asp:Content>
