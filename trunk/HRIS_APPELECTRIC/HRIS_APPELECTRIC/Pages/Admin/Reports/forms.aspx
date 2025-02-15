﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="forms.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Reports.forms" %>

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
                <h3 class="m-0 text-dark">Claimed Leaves,Absent and Cash Advance<small> </small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="forms.aspx" class="btn btn-default"><i class="fa fa-cog"></i><span class="h6">List</span></a>
                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="panel-body">
                                            <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto">
                                                <div>

                                                    <asp:GridView ID="GridUserList" runat="server" AutoGenerateColumns="False"
                                                        ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                        GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                        ForeColor="Black" OnRowCommand="GridUserList_RowCommand"
                                                        OnPageIndexChanging="GridUserList_PageIndexChanging"
                                                        ViewStateMode="Enabled" PageSize="25">

                                                        <EmptyDataTemplate>
                                                            <center><h1>NO USERS AVAILABLE</h1></center>
                                                        </EmptyDataTemplate>
                                                        <Columns>
                                                            <asp:TemplateField Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblID" CssClass="h5" Text='<%# Eval("id") %>' runat="server" Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="lblFullname" CssClass="h8" Text='Full Name' runat="server" CommandName="Sort"
                                                                        CommandArgument="FullName"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtSearchFullName" runat="server" OnTextChanged="txtItem_TextChanged"
                                                                        Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblFullName" CssClass="" Text='<%# Eval("FullName") %>'
                                                                        runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="lblCompany" CssClass="h8" Text='Company' runat="server" CommandName="Sort"
                                                                        CommandArgument="Company"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtSearchCompany" runat="server" OnTextChanged="txtItem_TextChanged"
                                                                        Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCompany" CssClass="" Text='<%# Eval("Company") %>'
                                                                        runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <span class="h8">Claimed Leaves Approval Form</span>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnClaimedLeave" runat="server" ForeColor="Black" Font-Size="Large"
                                                                        CommandName="ClaimedLeave" CommandArgument='<%# Eval("id") %>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                                                    &nbsp;
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <span class="h8">Absent Form</span>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnAbsent" runat="server" ForeColor="Black" Font-Size="Large"
                                                                        CommandName="AbsentFrm" CommandArgument='<%# Eval("id") %>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                                                    &nbsp;
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <span class="h8">Cash Advance Form</span>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnCashAd" runat="server" ForeColor="Black" Font-Size="Large"
                                                                        CommandName="CashAd" CommandArgument='<%# Eval("id") %>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                                                    &nbsp;
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                 <%--   <div class="col-md-6">
                                        <asp:Button ID="Button1" runat="server" Text="Claimed Leaves" CssClass="form-control" OnClick="Button1_Click" />
                                        <asp:Button ID="Button2" runat="server" Text="Cash Advance Form" CssClass="form-control" OnClick="Button2_Click" />
                                        <asp:Button ID="Button3" runat="server" Text="Absent Form" CssClass="form-control" OnClick="Button3_Click" />
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</asp:Content>
