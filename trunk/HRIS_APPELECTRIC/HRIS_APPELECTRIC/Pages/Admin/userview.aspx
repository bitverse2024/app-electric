﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="userview.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.userview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function Confirm1() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to reset password?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <aside>
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
                    <h3 class="m-0 text-dark"><%=getname() %><small> User</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="UserList.aspx" class="btn btn-default"><i class="fa fa-th-list"></i><span class="h6">Back to List</span></a>
                            <a href="UpdatePassword.aspx" class="btn btn-default"><i class="fa fa-edit"></i><span class="h6">Update Password</span></a>
                            <a href="UpdateEmail.aspx" class="btn btn-default"><i class="fa fa-edit"></i><span class="h6">Update Email</span></a>
                            <%--<a href="ifApprover.aspx" class="btn btn-default"><i class="fa fa-edit"></i><span class="h6">Set if Approver</span></a>--%>
                            <a href="useraccess.aspx" class="btn btn-default"><i class="fa fa-edit"></i><span class="h6">Set User Access</span></a>
                            <a href="#" class="btn btn-default" runat="server" onserverclick="btnReset_Click" onclick="Confirm1()"><i class="fa fa-edit"></i><span class="h6">Reset Password</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">
                                        <asp:GridView ID="GridViewList" runat="server" AutoGenerateColumns="False"
                                            ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                            GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                            ForeColor="Black"
                                            ViewStateMode="Enabled" ShowHeaderWhenEmpty="true">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkName" CssClass="h8" Text='Profile' runat="server" CommandName="Sort" CommandArgument="item"></asp:LinkButton><br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" CssClass="" Text='<%# Eval("Emp_Name") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkUser" CssClass="h8" Text='Username' runat="server" CommandName="Sort" CommandArgument="serial_no"></asp:LinkButton><br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUser" CssClass="" Text='<%# Eval("Username") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkEmail" CssClass="h8" Text='Email' runat="server" CommandName="Sort" CommandArgument="model"></asp:LinkButton><br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmail" CssClass="" Text='<%# Eval("Email") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkRole" CssClass="h8" Text='Role' runat="server" CommandName="Sort" CommandArgument="model"></asp:LinkButton><br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRole" CssClass="" Text='<%# Eval("Role") %>' runat="server"></asp:Label>
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
    </aside>
</asp:Content>
