﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="viewdtrlist.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees.viewdtrlist" %>

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
                <h3 class="m-0 text-dark">Employees<small> Daily Time Records</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="viewdtrlist.aspx" class="btn btn-default"><i class="fa fa-list"></i>List</a>
                        <a id="A3" runat="server" onserverclick="btnExport_Click" class="btn btn-default"><i class="fa fa-arrow-circle-o-up"></i><span class="h6">Export to Excel</span></a>
                    </div>
                    <%--<br />--%>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="box-body">
                                    <div class="row">

                                                <div>
                                                    <asp:GridView ID="GridUserList" runat="server" AutoGenerateColumns="False"
                                                        ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                        GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                        ForeColor="Black"
                                                        OnPageIndexChanging="GridUserList_PageIndexChanging"
                                                        ViewStateMode="Enabled" PageSize="1000" ShowHeaderWhenEmpty="true">
                                                        <EmptyDataTemplate>
                                                            <center><h1>NO DTR AVAILABLE</h1></center>
                                                        </EmptyDataTemplate>
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-Width="120px">
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="lblEmp_Name" Text='Full Name' runat="server" CommandName="Sort" CommandArgument="Emp_Name"></asp:LinkButton><br />

                                                                    <asp:TextBox ID="txtSearchEmp_Name" runat="server" OnTextChanged="txtItem_TextChanged" Width="100px"></asp:TextBox>

                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEmp_Name" Text='<%# Eval("Emp_Name") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="lblEmpID" Text='Employee No.' runat="server" CommandName="Sort" CommandArgument="EmpID"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtSearchEmpID" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEmpID" Width="150px" Text='<%# Eval("EmpID") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="lblBussDate" Text='Buss Date' runat="server" CommandName="Sort" CommandArgument="BussDate"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtSearchBussDate" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBussDate" Width="150px" Text='<%# Eval("BussDate") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="lblDateIn" Text='Date In' runat="server" CommandName="Sort" CommandArgument="DateIn"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtSearchDateIn" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDateIn" Width="150px" Text='<%# Eval("DateIn") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="lblDTimeIn" Text='Time In' runat="server" CommandName="Sort" CommandArgument="DTimeIn"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtSearchDTimeIn" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDTimeIn" Text='<%# Eval("DTimeIn") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="lblDateOut" Text='Date Out' runat="server" CommandName="Sort" CommandArgument="DateOut"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtSearchDateOut" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDateOut" Text='<%# Eval("DateOut") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="lblDTimeOut" Text='Time Out' runat="server" CommandName="Sort" CommandArgument="DTimeOut"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtSearchDTimeOut" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDTimeOut" Text='<%# Eval("DTimeOut") %>' runat="server"></asp:Label>
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
</asp:Content>
