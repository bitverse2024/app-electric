<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="applicantupdexperience.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.HRRecruitment.applicantupdexperience" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <aside class="right-side">
        <!-- Small boxes (Stat box) -->
        <section class="content-header">
            <h1>Recruitment
         <small>Update Applicant  <%=applicantInfo["FullName"] %></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Recruitment</a></li>
                <li class="active">Applicants</li>
            </ol>
        </section>
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
                    <h3 class="m-0 text-dark">Recruitment<small>Update Applicant <%=applicantInfo["FullName"] %></small></h3>
                    <section class="card">
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">
                                        <div class="form">
                                            <legend>
                                                <p class="note">Fields with <span class="required text-red">**</span> are required.</p>
                                            </legend>
                                            <ul class="nav nav-pills">
                                                <li class=""><a href="applicantprofileview.aspx?id=<%=applicantInfo["id"] %>"><i class="icon-arrow-left"></i>Back to Applicant View</a></li>
                                            </ul>
                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <h3>Experience 1</h3>
                                                    <label for="Applicant_Postion1">Position</label>
                                                    <input class="form-control" maxlength="100" name="Applicant[Postion1]" id="Applicant_Postion1" type="text" value="" runat="server">
                                                    <label for="Applicant_Year1">Year</label>
                                                    <input class="form-control" maxlength="100" name="Applicant[Year1]" id="Applicant_Year1" type="text" value="" runat="server">
                                                    <label for="Applicant_CompanyName1">Company Name</label>
                                                    <input class="form-control" maxlength="100" name="Applicant[CompanyName1]" id="Applicant_CompanyName1" type="text" value="" runat="server">
                                                </div>
                                                <div class="col-lg-4">
                                                    <h3>Experience 2</h3>
                                                    <label for="Applicant_Postion2">Position</label>
                                                    <input class="form-control" maxlength="100" name="Applicant[Postion2]" id="Applicant_Postion2" type="text" value="" runat="server">
                                                    <label for="Applicant_Year2">Year</label>
                                                    <input class="form-control" maxlength="100" name="Applicant[Year2]" id="Applicant_Year2" type="text" value="" runat="server">
                                                    <label for="Applicant_CompanyName2">Company Name</label>
                                                    <input class="form-control" maxlength="100" name="Applicant[CompanyName2]" id="Applicant_CompanyName2" type="text" value="" runat="server">
                                                </div>
                                                <div class="col-lg-4">
                                                    <h3>Experience 3</h3>
                                                    <label for="Applicant_Postion3">Position</label>
                                                    <input class="form-control" maxlength="100" name="Applicant[Postion3]" id="Applicant_Postion3" type="text" value="" runat="server">
                                                    <label for="Applicant_Year3">Year</label>
                                                    <input class="form-control" maxlength="100" name="Applicant[Year3]" id="Applicant_Year3" type="text" value="" runat="server">
                                                    <label for="Applicant_CompanyName3">Company Name</label>
                                                    <input class="form-control" maxlength="100" name="Applicant[CompanyName3]" id="Applicant_CompanyName3" type="text" value="" runat="server">
                                                </div>

                                            </div>

                                            <%--<button class="btn btn-primary" type="submit" name="yt0"><i class="icon-ok icon-white"></i> Save</button></form>	--%>
                                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Save" OnClick="btnsaveUpdate_Click"></asp:Button>

                                        </div>
                                    </div>

                                    <div class="box box-danger">
                                        <div class="box-header">
                                            <h3 class="box-title" style="margin-bottom: 2rem;">Work Experience</h3>
                                        </div>
                                        <table class="detail-view table table-striped table-condensed" id="yw1">
                                            <tbody>
                                                <tr class="odd">
                                                    <th>Position</th>
                                                    <td><%=applicantInfo["Postion1"]%></td>
                                                </tr>
                                                <tr class="even">
                                                    <th>Year</th>
                                                    <td><%=applicantInfo["Year1"]%></td>
                                                </tr>
                                                <tr class="odd">
                                                    <th>Company Name</th>
                                                    <td><%=applicantInfo["CompanyName1"]%></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <table class="detail-view table table-striped table-condensed" id="yw2">
                                            <tbody>
                                                <tr class="odd">
                                                    <th>Position</th>
                                                    <td><%=applicantInfo["Postion2"]%></td>
                                                </tr>
                                                <tr class="even">
                                                    <th>Year</th>
                                                    <td><%=applicantInfo["Year2"]%></td>
                                                </tr>
                                                <tr class="odd">
                                                    <th>Company Name</th>
                                                    <td><%=applicantInfo["CompanyName2"]%></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <table class="detail-view table table-striped table-condensed" id="yw3">
                                            <tbody>
                                                <tr class="odd">
                                                    <th>Position</th>
                                                    <td><%=applicantInfo["Postion3"]%></td>
                                                </tr>
                                                <tr class="even">
                                                    <th>Year</th>
                                                    <td><%=applicantInfo["Year3"]%></td>
                                                </tr>
                                                <tr class="odd">
                                                    <th>Company Name</th>
                                                    <td><%=applicantInfo["CompanyName3"]%></td>
                                                </tr>
                                            </tbody>
                                        </table>
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
