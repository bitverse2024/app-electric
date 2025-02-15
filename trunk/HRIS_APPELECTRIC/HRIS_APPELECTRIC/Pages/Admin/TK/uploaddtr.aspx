﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="uploaddtr.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.TK.uploaddtr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                <h3 class="m-0 text-dark">Upload DTR</h3>
                <section class="card">
                    <div class="card-header">
                        <a href="<%= ResolveUrl("~/Pages/Admin/TK/dts.aspx")%>" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                        <a href="#" class="btn btn-default"><i class="fa fa-arrow-circle-o-down"></i><span class="h6">Upload DTR</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/TK/mergedtr.aspx")%>" class="btn btn-default"><i class="fa fa-print"></i><span class="h6">Merge DTR</span></a>
                        <%--<a href="<%= ResolveUrl("~/Pages/Admin/TK/computedtr.aspx")%>" class="btn btn-default"><i class="fa fa-list-ol"></i><span class="h5">Compute DTR</span></a>--%>
                        <a href="<%= ResolveUrl("~/Pages/Admin/TK/createsummary.aspx")%>" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">Create Summary</span></a>

                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <span class="input-group-lg h5">Select File: </span>
                                            <asp:FileUpload ID="fuUploader" runat="server" CssClass="form-control btn-default" Height="45px" />

                                            <asp:RequiredFieldValidator ID="validatorUploader" runat="server" ControlToValidate="fuUploader" ValidationGroup="uploadGroup" ForeColor="Red" ErrorMessage="Select Image to upload."></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="validatorFileUpload"
                                                ControlToValidate="fuUploader" ValidationGroup="uploadGroup" runat="server"
                                                ErrorMessage="Only file with .xps is allowed."
                                                ValidationExpression="^.*\.(xps|XPS|oxps)$"></asp:RegularExpressionValidator>

                                        </div>
                                        <div class="col-lg-6" style="padding-top: 28px">
                                            <asp:Button ID="btnUpload" class="btn btn-primary" runat="server" Text="Upload"
                                                OnClick="btnUpload_Click" data-toggle="modal" data-target="#listmodal" ValidationGroup="uploadGroup"></asp:Button>
                                        </div>
                                    </div>

                                
                                <div>
                                    <div id="yw1"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
    <div class="modal fade" id="listmodal" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="modal-body" style="">
                            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="200" runat="server">
                                <ProgressTemplate>
                                    <strong>Please wait...</strong>

                                    <div class="progress">
                                        <div class="progress-bar bg-primary progress-bar-striped progress-bar-animated" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 100%">
                                        </div>
                                    </div>

                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </ContentTemplate>
                    <Triggers>

                        <asp:PostBackTrigger ControlID="btnUpload" />
                    </Triggers>

                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        window.onsubmit = function () {
            if (Page_IsValid) {
                var updateProgress = $find("<%= UpdateProgress1.ClientID %>");
                window.setTimeout(function () {
                    updateProgress.set_visible(true);
                }, 100);
            }
        }
    </script>
</asp:Content>
