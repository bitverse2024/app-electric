<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ImportEmployeeList.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees.ImportEmployeeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
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
                    <h3 class="m-0 text-dark">Employees<small> Import</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="<%= ResolveUrl("~/Pages/Admin/Employees/CreateEmployee.aspx")%>" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                            <a href="#" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                            <a href="<%= ResolveUrl("~/Pages/Admin/Employees/COE.aspx")%>" class="btn btn-default"><i class="fa fa-file"></i><span class="h6">COE</span></a>
                            <a href="<%= ResolveUrl("~/Pages/Admin/Employees/EmployeeMaster.aspx")%>" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Back</span></a>

                        </div>
                        <%--<br />--%>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">
                                        <div class="form">
                                            <div class="row">
                                                <%--<div id="Div1" runat="server" class="form-group form-group-sm col-md-10 col-md-offset-1">--%>
                                                <div class="col-lg-6">
                                                    <div class="input-group">
                                                        <span class="input-group-lg">Select File: </span>
                                                        <asp:RequiredFieldValidator ID="validatorUploader" runat="server" ControlToValidate="fuUploader" ValidationGroup="uploadGroup" ForeColor="Red" ErrorMessage="Select csv file to upload."></asp:RequiredFieldValidator>

                                                        <div class="row" style="padding-left: 10px">
                                                            <div class="col-lg-8">
                                                                <asp:FileUpload ID="fuUploader" Height="45px" runat="server" CssClass="form-control btn-default" />
                                                                <asp:RegularExpressionValidator ID="validatorFileUpload"
                                                                    ControlToValidate="fuUploader" ValidationGroup="uploadGroup" runat="server"
                                                                    ErrorMessage="Only image with .jpg, .jpeg or .png is allowed."
                                                                    ValidationExpression="^.*\.(csv|CSV|xls|XLS|tsv)$"></asp:RegularExpressionValidator>
                                                            </div>
                                                            <div class="col-lg-3">
                                                                <%--<input type="submit" name="yt0" value="upload" />--%>
                                                                <asp:LinkButton ID="btnUploadFile" runat="server"
                                                                    CssClass="btn btn-primary btn-block" ValidationGroup="uploadGroup"
                                                                    OnClick="btnUploadFile_Click">Upload</asp:LinkButton>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
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
</asp:Content>
