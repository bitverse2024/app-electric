<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ExportDTRSummaryExcel.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.TK.ExportDTRSummaryExcel" %>

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
                <h3 class="m-0 text-dark">DTR<small> Export DTR Summary</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="dtr_summary.aspx" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>

                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="box-body">
                                    <div class='printableArea'>
                                        <div id="list">

                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <label class="required">Select Pay Period:</label>
                                                    <asp:DropDownList ID="DTS_BussDate" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="" Text="---Select Pay Period---"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <%-- <select class="form-control" name="DTS[BussDate]" id="DTS_BussDate" runat="server">
                                    <option value="">---Select Pay Period---</option>
                                </select>--%>
                                                </div>
                                                <br />
                                                <div class="col-lg-6" style="padding-top: 30px;">
                                                    <asp:Button ID="btnExport" class="btn btn-primary" Width="80" runat="server" Text="Export"
                                                        OnClick="btnExport_Click"></asp:Button>
                                                </div>



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
</asp:Content>
