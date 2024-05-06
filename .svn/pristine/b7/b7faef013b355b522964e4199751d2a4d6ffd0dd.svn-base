<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="applicantselrequirements.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.HRRecruitment.applicantselrequirements" %>

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
                    <h3 class="m-0 text-dark">Recruitment<small>Update Applicant <%=applicantInfo["FullName"] %></small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="applicantprofileview.aspx?id=<%=applicantInfo["id"] %>" class="btn btn-default">
                                <i class="fa fa-arrow-left"></i><span class="h5">Back to Applicant View</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">
                                        <div id="comments">

                                            <div class="col-lg-6">
                                                <div>
                                                    <asp:CheckBox ID="Diploma" runat="server" Text="Diploma"></asp:CheckBox><br />
                                                    <asp:CheckBox ID="NBI" runat="server" Text="NBI"></asp:CheckBox><br />
                                                    <asp:CheckBox ID="Medical" runat="server" Text="Medical"></asp:CheckBox><br />
                                                    <asp:CheckBox ID="Clearance" runat="server" Text="Clearance"></asp:CheckBox><br />
                                                    <asp:CheckBox ID="TOR" runat="server" Text="TOR"></asp:CheckBox><br />
                                                    <asp:CheckBox ID="BC" runat="server" Text="Birth Certificate"></asp:CheckBox><br />
                                                    <asp:CheckBox ID="SSI" runat="server" Text="SSS Static Info"></asp:CheckBox><br />
                                                    <asp:CheckBox ID="ECC" runat="server" Text="Employment Certificate"></asp:CheckBox><br />
                                                    <asp:CheckBox ID="PC" runat="server" Text="Police Clearance"></asp:CheckBox><br />
                                                    <asp:CheckBox ID="Resume_CV" runat="server" Text="Resume"></asp:CheckBox><br />
                                                    <asp:CheckBox ID="Cedula" runat="server" Text="Resident Certificate"></asp:CheckBox><br />
                                                    <asp:CheckBox ID="HDMF" runat="server" Text="PhilHealth"></asp:CheckBox><br />
                                                    <asp:CheckBox ID="DL" runat="server" Text="Driver's License"></asp:CheckBox><br />
                                                </div>
                                                <div class="form-actions">
                                                    <asp:Button ID="btnCreate" class="btn btn-primary" runat="server" Text="Create"
                                                        OnClick="btnCreate_Click" ValidationGroup="uploadGroup"></asp:Button>
                                                    <%--<asp:Button ID="btnReset" class="btn" runat="server" Text="Reset" 
            onclick="btnReset_Click"></asp:Button>--%>
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
        <!-- /.row (main row) -->
    </aside>
</asp:Content>
