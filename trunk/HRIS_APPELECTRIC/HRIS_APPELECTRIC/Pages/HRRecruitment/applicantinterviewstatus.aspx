<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="applicantinterviewstatus.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.HRRecruitment.applicantinterviewstatus" %>

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
                        <div class="card-header">
                            <a href="applicantprofileview.aspx?id=<%=applicantInfo["id"] %>" class="btn btn-default">
                                <i class="fa fa-arrow-left"></i><span class="h5">Back to Applicant View</span></a>

                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-header">
                                        <ul class="nav nav-tabs" role="tablist">
                                            <li role="presentation" class="active">
                                                <a href="#applicant" aria-controls="applicant" role="tab" data-toggle="tab">First Interview</a>
                                            </li>
                                            <li role="presentation">
                                                <a href="#status" aria-controls="status" role="tab" data-toggle="tab">Second Interview</a>
                                            </li>
                                            <li role="presentation">
                                                <a href="#requirements" aria-controls="requirements" role="tab" data-toggle="tab">Third and Last Interview</a>
                                            </li>
                                        </ul>
                                        <div class="tab-content" style="padding: 2rem;">
                                            <div role="tabpanel" class="tab-pane active" id="applicant">

                                                <div class="form">



                                                    <div class="row">
                                                        <div class="col-lg-6">
                                                            <label for="Applicant_I1">Interview 1</label>
                                                            <select class="form-control" name="Applicant[I1]" id="Applicant_I1" runat="server">
                                                                <option value="empty">-Select Status-</option>
                                                                <option value="P">Passed</option>
                                                                <option value="F">Failed</option>
                                                                <option value="C">Conditional</option>
                                                            </select>

                                                            <label for="Applicant_Interviewer1">Interviewer</label>
                                                            <input class="form-control" readonly maxlength="255" value="" name="Applicant[Interviewer1]" runat="server" id="Applicant_Interviewer1" type="text">
                                                        </div>

                                                        <div class="col-lg-6">
                                                            <label for="Applicant_I1Remarks">Remarks</label>
                                                            <textarea class="form-control" maxlength="255" name="Applicant[I1Remarks]" id="Applicant_I1Remarks" runat="server"></textarea>
                                                        </div>


                                                    </div>

                                                    <%--<button class="btn btn-primary" type="submit" name="yt0"><i class="icon-ok icon-white"></i> Save</button>--%>
                                                    <asp:Button ID="btnsaveUpdate1" runat="server" Text="Save" OnClick="btnsaveUpdate1_Click"></asp:Button>

                                                </div>

                                            </div>
                                            <div role="tabpanel" class="tab-pane disabled" id="status">
                                                <div class="form">



                                                    <div class="row">
                                                        <div class="col-lg-6">
                                                            <label for="Applicant_I2">Interview 2</label>
                                                            <select class="form-control" name="Applicant[I2]" id="Applicant_I2" runat="server">
                                                                <option value="empty">-Select Status-</option>
                                                                <option value="P">Passed</option>
                                                                <option value="F">Failed</option>
                                                                <option value="C">Conditional</option>
                                                            </select>
                                                            <label for="Applicant_Interviewer2">Interviewer</label>
                                                            <input class="form-control" readonly maxlength="255" value="" name="Applicant[Interviewer2]" runat="server" id="Applicant_Interviewer2" type="text">
                                                        </div>

                                                        <div class="col-lg-6">
                                                            <label for="Applicant_I2Remarks">Remarks</label>
                                                            <textarea class="form-control" maxlength="255" name="Applicant[I2Remarks]" id="Applicant_I2Remarks" runat="server"></textarea>
                                                        </div>

                                                    </div>
                                                    <%--<button class="btn btn-primary" type="submit" name="yt1"><i class="icon-ok icon-white"></i> Save</button>--%>
                                                    <asp:Button ID="btnsaveUpdate2" runat="server" Text="Save" OnClick="btnsaveUpdate2_Click"></asp:Button>


                                                </div>
                                            </div>
                                            <div role="tabpanel" class="tab-pane" id="requirements">
                                                <div class="form">



                                                    <div class="row">
                                                        <div class="col-lg-6">
                                                            <label for="Applicant_I3">Interview 3</label>
                                                            <select class="form-control" name="Applicant[I3]" id="Applicant_I3" runat="server">
                                                                <option value="empty">-Select Status-</option>
                                                                <option value="P">Passed</option>
                                                                <option value="F">Failed</option>
                                                                <option value="C">Conditional</option>
                                                            </select>
                                                            <label for="Applicant_Interviewer1">Interviewer</label>
                                                            <input class="form-control" readonly maxlength="255" value="" name="Applicant[Interviewer1]" id="Applicant_Interviewer3" runat="server" type="text">
                                                        </div>

                                                        <div class="col-lg-6">
                                                            <label for="Applicant_I3Remarks">Remarks</label>
                                                            <textarea class="form-control" maxlength="255" name="Applicant[I3Remarks]" id="Applicant_I3Remarks" runat="server"></textarea>
                                                        </div>

                                                    </div>
                                                    <asp:Button ID="btnsaveUpdate3" runat="server" Text="Save" OnClick="btnsaveUpdate3_Click" ValidationGroup="UpdateRankGroup"></asp:Button>
                                                </div>
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
    </aside>
</asp:Content>
