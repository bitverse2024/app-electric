﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="viewloans.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees.viewloans" %>

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
                <h3 class="m-0 text-dark">Loans<small> <%=getname() %></small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/EmployeeView.aspx?empid="+empno+"")%>" class="btn btn-default"><i class="fa fa-arrow-left"></i>Employee View</a>
                        <a href="viewloans.aspx" class="btn btn-default"><i class="fa fa-list"></i>List</a>
                        <a id="A3" runat="server" onserverclick="btnExport_Click" class="btn btn-default"><i class="fa fa-arrow-circle-o-up"></i><span class="h6">Export to Excel</span></a>
                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="box-body">
                                    <div class='printableArea'>
                                        <div id="list">
                                            <div id="display-grid" class="grid-view">
                                                <div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>
                                                <div style="overflow-x: auto;" id="obtforapproval-grid" class="grid-view">
                                                    <asp:GridView ID="GridViewList" runat="server" AutoGenerateColumns="False"
                                                        ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                        GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                        ForeColor="Black"
                                                        OnPageIndexChanging="GridViewList_PageIndexChanging"
                                                        ViewStateMode="Enabled" ShowHeaderWhenEmpty="true">
                                                        <EmptyDataTemplate>
                                                            <center><h1>NO LOANS ENTRIES</h1></center>
                                                        </EmptyDataTemplate>
                                                        <Columns>
                                                            <asp:TemplateField Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>



                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="lnkLoanCode" CssClass="h8" Text='Loan Code' runat="server" CommandName="Sort" CommandArgument="LoanDesc"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtLoanCode" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <span class=""><%# Eval("LoanDesc")%></span>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="lnkDedStart" CssClass="h8" Text='Start of Deduction' runat="server" CommandName="Sort" CommandArgument="DedStart"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtDedStart" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <span class=""><%# Eval("DedStart")%></span>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="lnkLoanAmount" CssClass="h8" Text='Loan Amount' runat="server" CommandName="Sort" CommandArgument="LoanAmount"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtLoanAmount" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <span class=""><%# Eval("LoanAmount")%></span>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="lnkAmountPaid" CssClass="h8" Text='Amount Paid' runat="server" CommandName="Sort" CommandArgument="AmountPaid"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtAmountPaid" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <span class=""><%# Eval("AmountPaid")%></span>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="lnkBalance" CssClass="h8" Text='Balance' runat="server" CommandName="Sort" CommandArgument="Balance"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtBalance" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <span class=""><%# Eval("Balance")%></span>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="lnkDedAmount" CssClass="h8" Text='Deduction Amount' runat="server" CommandName="Sort" CommandArgument="DedAmount"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtDedAmount" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <span class=""><%# Eval("DedAmount")%></span>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <%--<asp:TemplateField HeaderStyle-Width="10%">
                                                            <ItemTemplate>
                                                                <center>--%>
                                                            <%-- <asp:Button ID="btnView" CssClass="btn-success btn-xs" runat="server" Text="View"  CommandName="view" CommandArgument='<%# Eval("id") %>'  />
                                                                            <asp:Button ID="btnUpdate" CssClass="btn-success btn-xs" runat="server" Text="Update"   CommandName="upd" CommandArgument='<%# Eval("id") %>'  />
                                                                            <asp:Button ID="btnDelete" CssClass="btn-danger btn-xs" runat="server" Text="Delete"  CommandName="del" CommandArgument='<%# Eval("id") %>'  />--%>
                                                            <%-- <asp:LinkButton ID="btnView" runat="server" ForeColor="Black" Font-Size="Large" CommandName="view" CommandArgument='<%# Eval("id") %>'><i class="fa fa-eye"></i></asp:LinkButton> &nbsp;
                                                                            <asp:LinkButton ID="btnUpdate" runat="server" ForeColor="Black" Font-Size="Medium" CommandName="upd" CommandArgument='<%# Eval("id") %>'><i class="fa fa-edit"></i></asp:LinkButton>&ensp;
                                                                            <asp:LinkButton ID="btnDelete" runat="server" ForeColor="Black" Font-Size="Medium" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;"  CommandName="del" CommandArgument='<%# Eval("id") %>'><i class="fa fa-trash"></i></asp:LinkButton>--%>
                                                            <%--      </center>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>--%>
                                                        </Columns>
                                                    </asp:GridView>
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
