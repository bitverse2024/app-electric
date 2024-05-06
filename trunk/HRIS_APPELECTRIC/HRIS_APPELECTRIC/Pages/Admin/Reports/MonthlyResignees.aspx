<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MonthlyResignees.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Reports.MonthlyResignees" %>

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
                    <h3 class="m-0 text-dark">Reports<small> Monthly Resignees</small></h3>
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
                                                        <td>
                                                            <div style="padding-right: 10px;">
                                                                <span class="h5">Select Month:</span><select class="form-control" name="Movement[EffectiveDate]" id="ddlMonth" runat="server">
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
                                                            <input maxlength="128" value="" class="form-control" name="Movement[Date_End]" id="txtYear" runat="server" type="text">
                                                        </div>
                                                        </td>
                                                        <td style="padding-top: 25px">
                                                            <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary"
                                                                Text="Search" OnClick="btnSearch_Click"></asp:Button></td>
                                                    </tr>

                                                </tbody>
                                            </table>

                                        </div>
                                    </div>
                                    <div id="here">
                                        <div id="list" class="box-body">
                                         <div style="overflow-x: auto;" id="display-grid" class="grid-view">
                                                <%-- <div class="summary">Monthly Deployment for the month of <%=year%>-<%=month%> results.</div>--%>
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
                                                                <asp:LinkButton ID="lnkSSS" Text='SSS No' runat="server" CommandName="Sort" CommandArgument="SSS"></asp:LinkButton><br />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSSS" Text='<%# Eval("SSS") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkEffectiveDate" Text='Effective Date' runat="server" CommandName="Sort" CommandArgument="EffectiveDate"></asp:LinkButton><br />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEffectiveDate" Width="150px" Text='<%# Eval("EffectiveDate") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkName" Text='Name' runat="server" CommandName="Sort" CommandArgument="Name"></asp:LinkButton><br />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" Width="150px" Text='<%# Eval("Name") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkBirthdate" Text='Birthdate' runat="server" CommandName="Sort" CommandArgument="Birthdate"></asp:LinkButton><br />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBirthdate" Text='<%# Eval("Birthdate") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkPosition" Text='Position' runat="server" CommandName="Sort" CommandArgument="Position"></asp:LinkButton><br />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPosition" Width="150px" Text='<%# Eval("Position") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkAssignment" Text='Assignment' runat="server" CommandName="Sort" CommandArgument="Assignment"></asp:LinkButton><br />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAssignment" Text='<%# Eval("Assignment") %>' runat="server"></asp:Label>
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
