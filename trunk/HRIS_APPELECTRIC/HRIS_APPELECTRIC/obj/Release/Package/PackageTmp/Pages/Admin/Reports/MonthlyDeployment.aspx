﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MonthlyDeployment.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Reports.MonthlyDeployment" %>

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
                    <h3 class="m-0 text-dark">Reports<small> Monthly New Hire</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="ReportsPage.aspx" class="btn btn-default"><i class="fa fa-cog"></i><span class="h6">Back to Reports</span></a>
                            <a runat="server" onserverclick="ExportToPDF" class="btn btn-default"><i class="fa fa-book"></i><span class="h6">Print to PDF</span></a>
                            <a runat="server" onserverclick="btnExport_Click" class="btn btn-default"><i class="fa fa-pencil"></i><span class="h6">Export to EXCEL</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="printableArea">
                                        <div style="padding-left: 20px;">
                                                <table>
                                                    <tbody>
                                                        <tr>
                                                            <td><span class="h5">Select Month:</span><div style="padding-right: 10px;">
                                                                <select name="Employee[DateStart]" runat="server" id="ddlMonth" class="form-control">
                                                                    <option value="01">January</option>
                                                                    <option value="02">February</option>
                                                                    <option value="03">March</option>
                                                                    <option value="04">April</option>
                                                                    <option value="05">May</option>
                                                                    <option value="06">June</option>
                                                                    <option value="07">July</option>
                                                                    <option value="08">August</option>
                                                                    <option value="09">September</option>
                                                                    <option value="10">October</option>
                                                                    <option value="11">November</option>
                                                                    <option value="12">December</option>
                                                                </select>
                                                            </div>
                                                            </td>
                                                            <td><span class="h5">Year:</span><div style="padding-right: 10px;">
                                                                <input style="padding-right: 10px;" runat="server" maxlength="128" name="Employee[ContractEnd]" id="txtYear" class="form-control" type="text">
                                                            </div>
                                                            </td>
                                                            <td><span class="h5">Company:</span><div style="padding-right: 10px;">
                                                                <select class="form-control" runat="server" name="Employee[AssignmentCode]" id="ddlEmpCode">
                                                                </select>
                                                            </div>
                                                            </td>
                                                            <td style="padding-top: 25px">
                                                                <asp:Button ID="btnSearch" runat="server"
                                                                    Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-primary"></asp:Button><%--<input type="submit" class="form-control" name="yt0" value="Search" id="yt0">--%></td>
                                                        </tr>

                                                    </tbody>
                                                </table>
                                            <!-- form -->

                                        </div>
                                    </div>
                                    <br />
                                    <div id="loading"></div>
                                    <div id="here">
                                        <div id="list" class="box-body">
                                            <div style="overflow-x: auto;" id="display-grid" class="grid-view">
                                                <div class="summary h6">Monthly Deployment for the month of <%=year%>-<%=month%> results.</div>
                                                <asp:GridView ID="GridUserList" runat="server" AutoGenerateColumns="False"
                                                    ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                    GridLines="None" AllowPaging="True" Font-Names="Segoe UI" OnRowCommand="GridUserList_RowCommand"
                                                    ForeColor="Black"
                                                    ViewStateMode="Enabled" PageSize="1000">
                                                    <EmptyDataTemplate>
                                                        <center><h1>NO EMPLOYEE AVAILABLE</h1></center>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-Width="120px">
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkLastName" CssClass="h8" Text='Last Name' runat="server" CommandName="Sort" CommandArgument="LastName"></asp:LinkButton><br />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLastName" CssClass="h5" Text='<%# Eval("LastName") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkSuffix" CssClass="h8" Text='Suffix' runat="server" CommandName="Sort" CommandArgument="Suffix"></asp:LinkButton><br />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSuffix" CssClass="h5" Width="150px" Text='<%# Eval("Suffix") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkFirstName" CssClass="h8" Text='First Name' runat="server" CommandName="Sort" CommandArgument="FirstName"></asp:LinkButton><br />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFirstName" CssClass="h5" Text='<%# Eval("FirstName") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkMiddleName" CssClass="h8" Text='Middle Name' runat="server" CommandName="Sort" CommandArgument="MiddleName"></asp:LinkButton><br />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMiddleName" CssClass="h5" Text='<%# Eval("MiddleName") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkStartDate" CssClass="h8" Text='Start Date' runat="server" CommandName="Sort" CommandArgument="StartDate"></asp:LinkButton><br />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStartDate" CssClass="h5" Text='<%# Eval("StartDate") %>' runat="server"></asp:Label>
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

                                                    </Columns>
                                                </asp:GridView>

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
