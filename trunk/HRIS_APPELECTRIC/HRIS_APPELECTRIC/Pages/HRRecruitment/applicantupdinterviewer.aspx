<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="applicantupdinterviewer.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.HRRecruitment.applicantupdinterviewer" %>

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
                    <h3 class="m-0 text-dark">Recruitment<small> Applicant's Interviewer</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="" class="btn btn-default"><i class="fa fa-th-list"></i><span class="h5">List</span></a>
                            <a href="" class="btn btn-default"><i class="fa fa-edit"></i><span class="h5">Update</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">

                                        <div class="form">

                                            <legend>
                                                <!-- <p class="note" style="font-size: 16px;font-weight:500">Step 1 (Personal Information) <br /><span style="font-weight:bold;"> Fields with <span class="required text-red">**</span> are required.</span></p> -->
                                            </legend>


                                            <div class="">
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <label for="Applicant_Interviewer2">Interviewer</label>
                                                        <select class="form-control" name="ait1" id="Applicant_Interviewer1" runat="server">
                                                            <option value="">---Select Interviewer 1---</option>

                                                        </select>
                                                        <label for="Applicant_Interviewer2">Interviewer</label>
                                                        <select class="form-control" name="ait2" id="Applicant_Interviewer2" runat="server">
                                                            <option value="">---Select Interviewer 2---</option>

                                                        </select>
                                                        <label for="Applicant_Interviewer3">Interviewer</label>
                                                        <select class="form-control" name="ait3" runat="server" id="Applicant_Interviewer3">
                                                            <option value="">---Select Interviewer 3---</option>

                                                        </select>


                                                    </div>

                                                </div>
                                            </div>

                                            <div class="form-actions">
                                                <%--<button class="btn btn-primary" type="submit" name="yt0" id = "btnsaveUpdate" onclick ="btnsaveUpdate_Click"><i class="icon-ok icon-white"></i> Save</button>              
        <button class="btn btn-primary" type="reset" name="yt1"><i class="icon-remove icon-white"></i> Reset</button>	--%>
                                                <asp:Button ID="btnsaveUpdate" class="btn btn-primary" runat="server" Text="Create"
                                                    OnClick="btnsaveUpdate_Click" ValidationGroup="CreateCompanyGroup"></asp:Button>
                                                <asp:Button ID="btnReset" class="btn" runat="server" Text="Reset"
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
