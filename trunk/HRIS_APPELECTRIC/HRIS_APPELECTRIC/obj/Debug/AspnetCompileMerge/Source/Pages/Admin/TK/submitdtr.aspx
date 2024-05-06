<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="submitdtr.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.TK.submitdtr" %>

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
                    <h3 class="m-0 text-dark">DTR<small> Submit DTR</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="dts.aspx" class="btn btn-default"><i class="fa fa-home"></i><span class="h6">Home</span></a>
                            <%-- <li class=""><a target="" href=""><i class="fa fa-download"></i> Export to Excel</a></li>--%>
                            <a href="#" class="btn btn-default"><i class="fa fa-edit"></i><span class="h6">Submit DTR</span></a>

                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class='printableArea'>
                                        <div id="list1">
                                            <asp:UpdatePanel ID="mergePanel" runat="server">
                                                <ContentTemplate>
                                                    <div class="row">
                                                        <div class="col-lg-6">
                                                            <label>Select Pay Period:</label>
                                                            <select class="form-control" name="DTS[BussDate]" id="DTS_BussDate" runat="server">
                                                                <option value="">---Select Pay Period---</option>
                                                            </select>
                                                        </div>
                                                        <div class="col-lg-6" style="padding-top: 30px;">
                                                            <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" Text="Submit"
                                                                OnClick="btnSubmit_Click" ValidationGroup="computeGroup" data-toggle="modal" data-target="#listmodal"></asp:Button>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                            <%--<input class="btn btn-primary" type="submit" name="yt0" value="Compute" id="yt0" />                       
                        <div id="loading" class="box box-alert hidden">
                            <div class="box-header">
                                <h3 class="box-title">Processing</h3>
                                <div class="box-tools pull-right"></div>
                            </div>
                            <div class="box-body">
                                Merging DTR <i class="fa fa-refresh fa-spin"></i> 
                                <p>
                                    Please wait while merging all DTR's.
                                </p>                                    
                            </div><!-- /.box-body -->
                            <!-- Loading (remove the following to stop the loading)-->
                            <div class="overlay"></div>
                            <div class="loading-img"></div>
                            <!-- end loading -->
                        </div>--%>
                                        </div>
                                    </div>
                                    <div id="here" class="summaryexcel">
                                        <div id="list" class="excel">
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
                                        <asp:UpdateProgress ID="submitProgress" AssociatedUpdatePanelID="mergePanel" DisplayAfter="200" runat="server">
                                            <ProgressTemplate>
                                                <strong>Please wait...</strong>

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

                            <asp:PostBackTrigger ControlID="btnSubmit" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            window.onsubmit = function () {
                //        if (Page_IsValid) {
                var updateProgress = $find("<%= submitProgress.ClientID %>");
                window.setTimeout(function () {
                    updateProgress.set_visible(true);
                }, 100);
                //        }
            }
        </script>

        <!-- /.row (main row) -->
    </aside>
</asp:Content>
