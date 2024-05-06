<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="createsummary.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.TK.createsummary" %>

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
                    <h3 class="m-0 text-dark">DTR<small> Create Summary</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="<%= ResolveUrl("~/Pages/Admin/TK/dts.aspx")%>" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                            <a href="<%= ResolveUrl("~/Pages/Admin/TK/uploaddtr.aspx")%>" class="btn btn-default"><i class="fa fa-arrow-circle-o-down"></i><span class="h6">Upload DTR</span></a>
                            <a href="<%= ResolveUrl("~/Pages/Admin/TK/mergedtr.aspx")%>" class="btn btn-default"><i class="fa fa-print"></i><span class="h6">Merge DTR</span></a>
                            <%--<a href="<%= ResolveUrl("~/Pages/Admin/TK/computedtr.aspx")%>" class="btn btn-default"><i class="fa fa-list-ol"></i><span class="h5">Compute DTR</span></a>--%>
                            <a href="<%= ResolveUrl("~/Pages/Admin/TK/createsummary")%>" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">Create Summary</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">
                                        <div class='printableArea'>
                                            <div id="list">

                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        
                                                        <label class="required">Select Pay Period:<span style="color:red" class="required"> *</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="DTS_BussDate" ValidationGroup="mergeGroup"></asp:RequiredFieldValidator></label>
                                                    <asp:DropDownList class="form-control" ID="DTS_BussDate" runat="server" OnSelectedIndexChanged="DTS_BussDate_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem Value="" Text="---Select Pay Period---"></asp:ListItem>
                                                    </asp:DropDownList>

                                                    </div>
                                                    <div class="col-lg-6" style="padding-top: 6px;">
                                                        <asp:UpdatePanel ID="createSummaryPanel" runat="server">
                                                            <ContentTemplate>
                                                                <div class="row">
                                                                    <div class="input-group">
                                                                    </div>

                                                                    <br />
                                                                    <div class="col-lg-6">
                                                                        <asp:Button ID="btncreateSummary" class="btn btn-primary" runat="server" Text="Create Summary"
                                                                            OnClick="btncreateSummary_Click" ValidationGroup="createSummaryGroup"></asp:Button>

                                                                    </div>

                                                                </div>


                                                            </ContentTemplate>
                                                            <%--<Triggers>

                                                                <asp:PostBackTrigger ControlID="btncreateSummary" />
                                                            </Triggers>--%>

                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <label class="required">Employee:</label>
                                                    <asp:DropDownList class="form-control" ID="ddlEmployee" runat="server" >
                                                        <asp:ListItem Value="" Text="---Select Employee---"></asp:ListItem>
                                                    </asp:DropDownList>

                                                </div>


                                            </div>
                                        </div>
                                        <div id="here" class="summaryexcel">
                                            <div id="list" class="excel">
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
        <div class="modal fade" id="listmodal" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog">
                <div class="modal-content">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>

                            <div class="modal-body" style="">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:UpdateProgress ID="createSummaryProgress" AssociatedUpdatePanelID="createSummaryPanel" DisplayAfter="200" runat="server">
                                            <ProgressTemplate>
                                                <strong>Please wait while system processing...</strong>

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

                            <asp:PostBackTrigger ControlID="btncreateSummary" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            window.onsubmit = function () {
                //        if (Page_IsValid) {
                var updateProgress = $find("<%= createSummaryProgress.ClientID %>");
                window.setTimeout(function () {
                    updateProgress.set_visible(true);
                }, 100);
                //        }
            }
        </script>

        <!-- /.row (main row) -->
    </aside>
</asp:Content>
