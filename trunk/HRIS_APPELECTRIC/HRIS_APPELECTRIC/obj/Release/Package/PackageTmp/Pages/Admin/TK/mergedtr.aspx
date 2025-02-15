﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="mergedtr.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.TK.mergedtr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <aside class="right-side">
        <!-- Small boxes (Stat box) -->

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
                    <h3 class="m-0 text-dark">DTR<small> Merge DTR</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="<%= ResolveUrl("~/Pages/Admin/TK/dts.aspx")%>" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                            <a href="<%= ResolveUrl("~/Pages/Admin/TK/uploaddtr.aspx")%>" class="btn btn-default"><i class="fa fa-arrow-circle-o-down"></i><span class="h6">Upload DTR</span></a>
                            <a href="#" class="btn btn-default"><i class="fa fa-print"></i><span class="h6">Merge DTR</span></a>
                            <%--<a href="<%= ResolveUrl("~/Pages/Admin/TK/computedtr.aspx")%>" class="btn btn-default"><i class="fa fa-list-ol"></i><span class="h5">Compute DTR</span></a>--%>
                            <a href="<%= ResolveUrl("~/Pages/Admin/TK/createsummary.aspx")%>" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">Create Summary</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class='printableArea'>
                                        <div id="list">

                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <label class="required">Select Pay Period:<span style="color:red" class="required"> *</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator9" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="DTS_BussDate" ValidationGroup="mergeGroup"></asp:RequiredFieldValidator></label>
                                                    <asp:DropDownList class="form-control" ID="DTS_BussDate" runat="server" OnSelectedIndexChanged="DTS_BussDate_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem Value="" Text="---Select Pay Period---"></asp:ListItem>
                                                    </asp:DropDownList>

                                                </div>
                                                <div style="padding-top: 30px;">
                                                    <asp:UpdatePanel ID="mergePanel" runat="server">
                                                        <ContentTemplate>
                                                            <div class="row">
                                                                <div class="col-lg-1" style="display: none;">
                                                                    <asp:Button ID="btnMerge" class="btn btn-primary" runat="server" Text="Merge"
                                                                        OnClick="btnMerge_Click" ValidationGroup="mergeGroup"></asp:Button>

                                                                </div>

                                                                <div class="col-lg-1">
                                                                    <asp:Button ID="btmCompleteMerge" class="btn btn-primary" runat="server" Text="Merge Complete"
                                                                        OnClick="btmCompleteMerge_Click" data-toggle="modal" data-target="#listmodal" ValidationGroup="mergeGroup"></asp:Button>

                                                                </div>
                                                            </div>


                                                        </ContentTemplate>
                                                        <Triggers>

                                                            <asp:PostBackTrigger ControlID="btnMerge" />
                                                        </Triggers>

                                                    </asp:UpdatePanel>
                                                </div>
                                                <div class="col-lg-6">
                                                    <label class="required">Employee:</label>
                                                    <asp:DropDownList class="form-control" ID="ddlEmployee" runat="server" >
                                                        <asp:ListItem Value="" Text="---Select Employee---"></asp:ListItem>
                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                            
                                        </div>
                                    </div>
                                    <div id="here" class="summaryexcel">
                                        <div id="list1" class="excel">
                                        </div>
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
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>

                            <div class="modal-body" style="">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:UpdateProgress ID="mergeProgress" AssociatedUpdatePanelID="mergePanel" DisplayAfter="200" runat="server">
                                            <ProgressTemplate>
                                                <strong>Please wait while system is merging and computing data...</strong>

                                                <div class="progress">
                                                    <div class="progress-bar bg-primary progress-bar-striped progress-bar-animated" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 100%">
                                                    </div>
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </ContentTemplate>
                        <Triggers>

                            <asp:PostBackTrigger ControlID="btmCompleteMerge" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            window.onsubmit = function () {
                //        if (Page_IsValid) {
                var updateProgress = $find("<%= mergeProgress.ClientID %>");
                window.setTimeout(function () {
                    updateProgress.set_visible(true);
                }, 100);
                //        }
            }
        </script>

        <!-- /.row (main row) -->
    </aside>
</asp:Content>