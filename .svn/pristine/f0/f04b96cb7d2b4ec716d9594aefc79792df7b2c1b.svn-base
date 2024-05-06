<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="COEOthers.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees.COEOthers" %>

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
                    <h3 class="m-0 text-dark">Employees<small> View Certificates</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="COE.aspx" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Back</span></a>
                            <a href="#" class="btn btn-default"><i class="fa fa-print"></i><span class="h6">Print COE w/o Compensation</span></a>
                            <a href="#" class="btn btn-default"><i class="fa fa-print"></i><span class="h6">Print COE w/ Compensation</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">
                                        <div class="row">
                                            <div class="panel-body">
                                                <div class="col-md-12">
                                                    <div>
                                                        <asp:Label ID="Label1" runat="server" CssClass="h4" Text="View Certificate for:"></asp:Label>
                                                        <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto">
                                                            <asp:GridView ID="GridUserList" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                                                                CssClass="items table table-striped table-bordered table-condensed" GridLines="None"
                                                                AllowPaging="True" Font-Names="Segoe UI" ForeColor="Black" ViewStateMode="Enabled"
                                                                PageSize="10">
                                                                <EmptyDataTemplate>
                                                                    <center><h1>NO CERTIFICATE AVAILABLE</h1></center>
                                                                </EmptyDataTemplate>
                                                                <Columns>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </asp:Panel>
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
        <!-- /.row (main row) -->
    </aside>
</asp:Content>
