﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="OTSummary.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Reports.OTSummary" %>

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

        <div class="" id="yw0">
            <div class="printableArea">
                <ul class="nav nav-pills" style="padding-left: 10px;">
                    <li class=""></li>
                </ul>
            </div>
        </div>
        <div class="col-md-12">
            <div class="content">
                <div class="container-fluid">
                    <div class="container"></div>
                    <h3 class="m-0 text-dark">Reports<small> OT Summary</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="ReportsPage.aspx" class="btn btn-default"><i class="fa fa-cog"></i><span class="h6">Back to Reports</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <!-- general form elements -->
                                            <div class="box box-primary">
                                                <div class="box-header">
                                                    <h5 class="box-title">Select Date</h5>
                                                </div>
                                                <!-- /.box-header -->
                                                <div class="form-group">
                                                    <span class="h5">
                                                        <label>Start Date:</label></span>
                                                    <div class="input-group">
                                                        <input style="height: 30px;" class="form-control" id="txt_txtStartDate" name="DTS[BussDate]" type="date" min="1990-01-01" max="2099-12-31" runat="server">
                                                    </div>
                                                    <!-- /.input group -->
                                                </div>
                                                <div class="form-group">
                                                    <span class="h5">
                                                        <label>End Date:</label></span>
                                                    <div class="input-group">
                                                        <input style="height: 30px;" class="form-control" id="txt_txtEndDate" name="DTS[EndDate]" type="date" min="1990-01-01" max="2099-12-31" runat="server">
                                                    </div>
                                                    <!-- /.input group -->
                                                </div>
                                                <div class="form-group">
                                                    <span class="h5">
                                                        <label>Department:</label></span>
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            <i class="fa fa-building"></i>
                                                        </div>
                                                        <asp:DropDownList ID="ddlDept" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0" Text="ALL"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <!-- /.input group -->
                                                </div>
                                                <div class="form-group">
                                                    <span class="h5">
                                                        <label>Company:</label></span>
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            <i class="fa fa-building"></i>
                                                        </div>
                                                        <asp:DropDownList ID="ddlComp" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0" Text="ALL"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <!-- /.input group -->
                                                    <br />
                                                    <div class="footer">
                                                        <asp:Button ID="btnSearch" runat="server" class="btn btn-info" Text="Search"
                                                            OnClick="btnSearch_Click"></asp:Button>
                                                        <asp:Button ID="btnExport" runat="server" class="btn btn-info"
                                                            Text="Export to Excel" OnClick="btnExport_Click"></asp:Button>
                                                        <asp:Button ID="btnEXportPDF" runat="server" class="btn btn-info"
                                                            Text="Export to PDF" OnClick="btnEXportPDF_Click"></asp:Button>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div id="list" class="box-body">
                                        <div id="display-grid" class="grid-view" style="padding-left: 10px; overflow-x:auto">
                                            <%--<div class="right-side">Summary of Active Employees as of <%=year%>.</div>--%>
                                             <asp:GridView ID="GridOT" runat="server" AutoGenerateColumns="False"
                                                ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                ForeColor="Black" ShowHeaderWhenEmpty="true"
                                                ViewStateMode="Enabled" PageSize="1000">
                                                <EmptyDataTemplate>
                                                    <center><h1>NO OT AVAILABLE</h1></center>
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-Width="120px">
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkName" CssClass="h8" Text='Name' runat="server" CommandName="Sort" CommandArgument="Name"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblName" CssClass="h5" Text='<%# Eval("Name") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkPosition" CssClass="h8" Text='Position' runat="server" CommandName="Sort" CommandArgument="Position"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPosition" CssClass="h5" Text='<%# Eval("Position") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkDepartment" CssClass="h8" Text='Department' runat="server" CommandName="Sort" CommandArgument="Department"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDepartment" CssClass="h5" Text='<%# Eval("Department") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkOTDate" CssClass="h8" Text='OT Date' runat="server" CommandName="Sort" CommandArgument="OTDate"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblOTDate" CssClass="h5" Text='<%# Eval("OTDate") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkReason" CssClass="h8" Text='Reason' runat="server" CommandName="Sort" CommandArgument="Reason"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblReason" CssClass="h5" Text='<%# Eval("Reason") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton12" CssClass="h8" Text='OT' runat="server" CommandName="Sort"
                                                                CommandArgument="RegOT"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRegOT" CssClass="h5" Text='<%# Eval("RegOT")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton12" CssClass="h8" Text='NDO' runat="server" CommandName="Sort"
                                                                CommandArgument="RegNDO"></asp:LinkButton><br />

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRegNDO" CssClass="h5" Text='<%# Eval("RegOTND")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton13" CssClass="h8" Text='8HRS' runat="server" CommandName="Sort"
                                                                CommandArgument="LHOT8"></asp:LinkButton><br />

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLHOT8" CssClass="h5" Text='<%# Eval("LHOT8Hrs")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton14" CssClass="h8" Text='OT' runat="server" CommandName="Sort"
                                                                CommandArgument="LHOT"></asp:LinkButton><br />

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLHOT" CssClass="h5" Text='<%# Eval("LHOT")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton15" CssClass="h8" Text='NDO' runat="server" CommandName="Sort"
                                                                CommandArgument="LHOTNDO"></asp:LinkButton><br />

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLHOTNDO" CssClass="h5" Text='<%# Eval("LHOTND")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton16" CssClass="h8" Text='8HRS' runat="server" CommandName="Sort"
                                                                CommandArgument="SHOT8"></asp:LinkButton><br />

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSHOT8" CssClass="h5" Text='<%# Eval("SHOT8Hrs")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton17" CssClass="h8" Text='OT' runat="server" CommandName="Sort"
                                                                CommandArgument="SHOT"></asp:LinkButton><br />

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSHOT" CssClass="h5" Text='<%# Eval("SHOT")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton18" CssClass="h8" Text='NDO' runat="server" CommandName="Sort"
                                                                CommandArgument="SHOTNDO"></asp:LinkButton><br />

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSHOTNDO" CssClass="h5" Text='<%# Eval("SHOTND")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton19" CssClass="h8" Text='8HRS' runat="server" CommandName="Sort"
                                                                CommandArgument="RDOT8"></asp:LinkButton><br />

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRDOT8" CssClass="h5" Text='<%# Eval("RDOT8Hrs")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton20" CssClass="h8" Text='OT' runat="server" CommandName="Sort"
                                                                CommandArgument="RDOT"></asp:LinkButton><br />

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRDOT" CssClass="h5" Text='<%# Eval("RDOT")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton21" CssClass="h8" Text='NDO' runat="server" CommandName="Sort"
                                                                CommandArgument="RDOTNDO"></asp:LinkButton><br />

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRDOTNDO" CssClass="h5" Text='<%# Eval("RDOTND")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton22" CssClass="h8" Text='8HRS' runat="server" CommandName="Sort"
                                                                CommandArgument="LRDOT8"></asp:LinkButton><br />

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLRDOT8" CssClass="h5" Text='<%# Eval("RDLHOT8Hrs")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton23" CssClass="h8" Text='OT' runat="server" CommandName="Sort"
                                                                CommandArgument="LRDOT"></asp:LinkButton><br />

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLRDOT" CssClass="h5" Text='<%# Eval("RDLHOT")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton24" CssClass="h8" Text='NDO' runat="server" CommandName="Sort"
                                                                CommandArgument="LRDOTNDO"></asp:LinkButton><br />

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLRDOTNDO" CssClass="h5" Text='<%# Eval("RDLHOTND")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton25" CssClass="h8" Text='8HRS' runat="server" CommandName="Sort"
                                                                CommandArgument="SRDOT8"></asp:LinkButton><br />

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSRDOT8" CssClass="h5" Text='<%# Eval("RDSHOT8Hrs")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton26" CssClass="h8" Text='OT' runat="server" CommandName="Sort"
                                                                CommandArgument="SRDOT"></asp:LinkButton><br />

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSRDOT" CssClass="h5" Text='<%# Eval("RDSHOT")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton27" CssClass="h8" Text='NDO' runat="server" CommandName="Sort"
                                                                CommandArgument="SRDOTNDO"></asp:LinkButton><br />

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSRDOTNDO" CssClass="h5" Text='<%# Eval("RDSHOTND")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkHours" CssClass="h8" Text='OT Hours' runat="server" CommandName="Sort" CommandArgument="Hours"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHours" CssClass="h5" Text='<%# Eval("Hours") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkDateApproved" CssClass="h8" Text='Date Approved' runat="server" CommandName="Sort" CommandArgument="DateApproved"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDateApproved" CssClass="h5" Text='<%# Eval("DateApproved1") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkStatus" CssClass="h8" Text='Status' runat="server" CommandName="Sort" CommandArgument="Status"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatus" CssClass="h5" Text='<%# Eval("Status") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>

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
