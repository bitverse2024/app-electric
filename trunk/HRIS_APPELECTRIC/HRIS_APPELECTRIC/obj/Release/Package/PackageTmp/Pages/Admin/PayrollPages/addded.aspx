﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="addded.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.PayrollPages.addded" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
    <style>
        /*gridview*/
        /*.table table > tbody > tr > td {
            display: inline-block;

        }*/
        .table {
            /*display: inline-block;*/
            padding-left: 0;
            margin: 20px 0;
            border-radius: 4px;
        }
        .table table > tbody > tr > td > a ,
        .table table > tbody > tr > td > span {
        position: relative;
        float: left;
        padding: 6px 12px;
        margin-left: -1px;
        line-height: 1.42857143;
        color: #337ab7;
        text-decoration: none;
        background-color: #fff;
        border: 1px solid #ddd;


        }

        .table table > tbody > tr > td > span {
        z-index: 3;
        color: #fff;
        cursor: default;
        background-color: #337ab7;
        border-color: #337ab7;


        }

        .table table > tbody > tr > td:first-child > a,
        .table table > tbody > tr > td:first-child > span {
        margin-left: 0;
        border-top-left-radius: 4px;
        border-bottom-left-radius: 4px;
        }

        .table table > tbody > tr > td:last-child > a,
        .table table > tbody > tr > td:last-child > span {
        border-top-right-radius: 4px;
        border-bottom-right-radius: 4px;
        }

        .table table > tbody > tr > td > a:hover,
        .table   table > tbody > tr > td > span:hover,
        .table table > tbody > tr > td > a:focus,
        .table table > tbody > tr > td > span:focus {
        z-index: 2;
        color: #23527c;
        background-color: #eee;
        border-color: #ddd;

        }
        /*end gridview */

    </style>
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
                <h3 class="m-0 text-dark">Payroll<small> Government Deduction</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="addded.aspx" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                        <a id="A3" runat="server" onserverclick="btnExport_Click" class="btn btn-default"><i class="fa fa-arrow-circle-o-up"></i><span class="h6">Export to Excel</span></a>
                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div id="display-grid" class="grid-view">
                                    <%--<div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>--%>
                                    <asp:GridView ID="GridViewList" runat="server" AutoGenerateColumns="False"
                                        ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                        GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                        ForeColor="Black" OnRowCommand="GridViewList_RowCommand"
                                        OnPageIndexChanging="GridViewList_PageIndexChanging" ShowHeaderWhenEmpty="true"
                                        ViewStateMode="Enabled">
                                        <EmptyDataTemplate>
                                            <center><h1>NO USERS AVAILABLE</h1></center>
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkempid" CssClass="h8" Text='Employee No' runat="server" CommandName="Sort" CommandArgument="empid"></asp:LinkButton><br />
                                                    <asp:TextBox ID="txtSearchempid" runat="server" OnTextChanged="txtItem_TextChanged" AutoPostBack="True" Width="100%"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblid" CssClass="h6" Text='<%# Eval("empid") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkFullName" CssClass="h8" Text='FullName' runat="server" CommandName="Sort" CommandArgument="FullName"></asp:LinkButton><br />
                                                    <asp:TextBox ID="txtSearchFullName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="True" ></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFullName" CssClass="h6" Text='<%# Eval("FullName") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <%--<asp:Button ID="btnView" CssClass="btn-success btn-xs" runat="server" Text="View"  CommandName="view" CommandArgument='<%# Eval("id") %>'  />
                                                                            <asp:Button ID="btnUpdate" CssClass="btn-success btn-xs" runat="server" Text="Update"   CommandName="upd" CommandArgument='<%# Eval("id") %>'  />--%>
                                                    <asp:LinkButton ID="btnView" CssClass="fa fa-eye" runat="server" ForeColor="Black" CommandName="view" CommandArgument='<%# Eval("empid") %>' />
                                                </ItemTemplate>

                                            </asp:TemplateField>


                                        </Columns>
                                    </asp:GridView>

                                </div>

                            </div>
                        </div>
                    </div>

                </section>
            </div>
        </div>
    </div>   
</asp:Content>
