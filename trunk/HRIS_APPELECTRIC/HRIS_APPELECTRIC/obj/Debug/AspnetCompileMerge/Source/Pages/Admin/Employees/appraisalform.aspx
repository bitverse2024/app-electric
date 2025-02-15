﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="appraisalform.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees.appraisalform" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to add this item?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <script type="text/javascript">
        function Confirm1() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to update this item?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
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
                <h3 class="m-0 text-dark"><%=getname() %><small> Employee Appraisal</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/appraisal.aspx")%>" class="btn btn-default"><i
                            class="fa fa-arrow-left"></i><span class="h6">Employee View</span></a>
                        <a href="#" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">Print Form</span></a>
                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="box-body">
                                    <div class='printableArea'>
                                        <div id="list">
                                            <div id="display-grid" class="grid-view">
                                                <div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>
                                                <asp:GridView ID="GridViewList" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                                                    CssClass="items table table-striped table-bordered table-condensed" GridLines="None"
                                                    AllowPaging="True" Font-Names="Segoe UI" ForeColor="Black" OnRowCommand="GridViewList_RowCommand"
                                                    OnPageIndexChanging="GridViewList_PageIndexChanging" ViewStateMode="Enabled"
                                                    ShowHeaderWhenEmpty="true" PageSize="10">
                                                    <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
                                                    <EmptyDataTemplate>
                                                        <center><h1>NO ASSET AVAILABLE</h1></center>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblid" Text='<%# Eval("") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkEmpName" CssClass="h8" Text='Name' runat="server" CommandName="Sort"
                                                                    CommandArgument="item"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtEmpName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmpName" CssClass="h5" Text='<%# Eval("") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkDept" CssClass="h8" Text='Department' runat="server" CommandName="Sort"
                                                                    CommandArgument="serial_no"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtDept" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDept" CssClass="h5" Text='<%# Eval("") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkRevDate" CssClass="h8" Text='Review Date' runat="server" CommandName="Sort"
                                                                    CommandArgument="model"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtRevDate" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRevDate" CssClass="h5" Text='<%# Eval("") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkAppraiser" CssClass="h8" Text='Appraiser' runat="server" CommandName="Sort"
                                                                    CommandArgument="brand"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtAppraiser" runat="server" OnTextChanged="txtItem_TextChanged"
                                                                    Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAppraiser" CssClass="h5" Text='<%# Eval("") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="10%">
                                                            <ItemTemplate>
                                                                <center>
                                                <asp:LinkButton ID="btnView" runat="server" ForeColor="Black" Font-Size="Large" CommandName="view" CommandArgument='<%# Eval("id") %>'><i class="fa fa-eye"></i></asp:LinkButton> &nbsp;
                                                <asp:LinkButton ID="btnUpdate" runat="server" ForeColor="Black" Font-Size="Medium" CommandName="upd" CommandArgument='<%# Eval("id") %>'><i class="fa fa-edit"></i></asp:LinkButton>&ensp;
                                                <asp:LinkButton ID="btnDelete" runat="server" ForeColor="Black" Font-Size="Medium" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;"  CommandName="del" CommandArgument='<%# Eval("id") %>'><i class="fa fa-trash"></i></asp:LinkButton>
                                            </center>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="form">
                                            <legend>
                                                <p class="note">
                                                    Fields with <span class="required text-red">*</span> are required.
                                                </p>
                                            </legend>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="control-group ">
                                                        <label class="control-label required" for="txtRevDate">
                                                            Review Date <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                                                runat="server" ControlToValidate="txtRevDate" ValidationGroup="appraisal" ForeColor="Red"
                                                                ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <input class="form-control" maxlength="50" id="txtRevDate" type="text"
                                                            runat="server" />
                                                    </div>

                                                    <div class="control-group ">
                                                        <label class="control-label required" for="txtRevPeriod">
                                                            Review Period <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                                                runat="server" ControlToValidate="txtRevPeriod" ValidationGroup="appraisal" ForeColor="Red"
                                                                ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <div class="controls">
                                                            <input class="form-control" maxlength="50" id="txtRevPeriod"
                                                                type="text" runat="server" />
                                                        </div>
                                                    </div>

                                                    <div class="control-group ">
                                                        <label class="control-label required" for="txtUniv">
                                                            University Institution <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                                                runat="server" ControlToValidate="txtUniv" ValidationGroup="appraisal" ForeColor="Red"
                                                                ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <div class="controls">
                                                            <input class="form-control" maxlength="50" id="txtUniv" type="text"
                                                                runat="server" />
                                                        </div>
                                                    </div>

                                                    <div class="control-group ">
                                                        <label class="control-label required" for="txtCourse">
                                                            Course <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                                                                runat="server" ControlToValidate="txtCourse" ValidationGroup="appraisal" ForeColor="Red"
                                                                ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <div class="controls">
                                                            <input class="form-control" maxlength="50" id="txtCourse" type="text"
                                                                runat="server" />
                                                        </div>
                                                    </div>

                                                    <div class="control-group ">
                                                        <label class="control-label required" for="txtCompDate">
                                                            Completion Date <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                                                                runat="server" ControlToValidate="txtCompDate" ValidationGroup="appraisal" ForeColor="Red"
                                                                ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <div class="controls">
                                                            <input class="form-control" maxlength="50" id="txtCompDate" type="text"
                                                                runat="server" />
                                                        </div>
                                                    </div>

                                                    <div class="control-group ">
                                                        <label class="control-label required" for="txtObj">
                                                            Performance Objective <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                                                                runat="server" ControlToValidate="txtObj" ValidationGroup="appraisal" ForeColor="Red"
                                                                ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <div class="controls">
                                                            <input class="form-control" maxlength="50" id="txtObj" type="text"
                                                                runat="server" />
                                                        </div>
                                                    </div>

                                                    <div class="control-group ">
                                                        <label class="control-label required" for="txtOutput">
                                                            Performance Output <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator9"
                                                                runat="server" ControlToValidate="txtOutput" ValidationGroup="appraisal" ForeColor="Red"
                                                                ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <div class="controls">
                                                            <input class="form-control" maxlength="50" id="txtOutput" type="text"
                                                                runat="server" />
                                                        </div>
                                                    </div>

                                                    <div class="control-group ">
                                                        <label class="control-label required" for="txtRate">
                                                            Performance Rating <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator10"
                                                                runat="server" ControlToValidate="txtRate" ValidationGroup="appraisal" ForeColor="Red"
                                                                ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <div class="controls">
                                                            <input class="form-control" maxlength="50" id="txtRate" type="text"
                                                                runat="server" />
                                                        </div>
                                                    </div>

                                                    <div class="control-group ">
                                                        <label class="control-label required" for="txtPerf">
                                                            Performace Factor <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                                                runat="server" ControlToValidate="txtPerf" ValidationGroup="appraisal" ForeColor="Red"
                                                                ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <div class="controls">
                                                            <input class="form-control" maxlength="50" id="txtPerf" type="text"
                                                                runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="control-group ">
                                                        <label class="control-label required" for="txtFactor">
                                                            Factor Comment <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                                                runat="server" ControlToValidate="txtFactor" ValidationGroup="appraisal" ForeColor="Red"
                                                                ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <div class="controls">
                                                            <input class="form-control" id="txtFactor" type="text" runat="server" />
                                                        </div>
                                                    </div>

                                                    <div class="control-group ">
                                                        <label class="control-label required" for="txtRating">
                                                            Factor Rating <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator11"
                                                                runat="server" ControlToValidate="txtRating" ValidationGroup="appraisal" ForeColor="Red"
                                                                ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <div class="controls">
                                                            <input class="form-control" id="txtRating" type="text" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="control-group ">
                                                        <label class="control-label required" for="txtArea">
                                                            Area To Develop <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator12"
                                                                runat="server" ControlToValidate="txtArea" ValidationGroup="appraisal" ForeColor="Red"
                                                                ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <div class="controls">
                                                            <input class="form-control" id="txtArea" type="text" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="control-group ">
                                                        <label class="control-label required" for="txtAppraiserComm">
                                                            Appraisers Comment <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator13"
                                                                runat="server" ControlToValidate="txtAppraiserComm" ValidationGroup="appraisal" ForeColor="Red"
                                                                ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <div class="controls">
                                                            <input class="form-control" id="txtAppraiserComm" type="text" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="control-group ">
                                                        <label class="control-label required" for="txtHRObj">
                                                            HR Performance Objective <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator14"
                                                                runat="server" ControlToValidate="txtHRObj" ValidationGroup="appraisal" ForeColor="Red"
                                                                ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <div class="controls">
                                                            <input class="form-control" id="txtHRObj" type="text" runat="server" />
                                                        </div>
                                                    </div>

                                                    <div class="control-group ">
                                                        <label class="control-label required" for="txtHRFact">
                                                            HR Performance Factors <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator15"
                                                                runat="server" ControlToValidate="txtHRFact" ValidationGroup="appraisal" ForeColor="Red"
                                                                ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <div class="controls">
                                                            <input class="form-control" maxlength="50" id="txtHRFact" type="text"
                                                                runat="server" />
                                                        </div>
                                                    </div>

                                                    <div class="control-group ">
                                                        <label class="control-label required" for="txtComment">
                                                            Appraisees Comment <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator16"
                                                                runat="server" ControlToValidate="txtComment" ValidationGroup="appraisal" ForeColor="Red"
                                                                ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <div class="controls">
                                                            <input class="form-control" maxlength="50" id="txtComment" type="text"
                                                                runat="server" />
                                                        </div>
                                                    </div>

                                                    <div class="control-group ">
                                                        <label class="control-label required" for="txtDHComm">
                                                            Department Head Comment <span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator17"
                                                                runat="server" ControlToValidate="txtDHComm" ValidationGroup="appraisal" ForeColor="Red"
                                                                ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <div class="controls">
                                                            <input class="form-control" maxlength="50" id="txtDHComm" type="text"
                                                                runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-actions" style="padding-top: 10px;">
                                                <asp:Button ID="btnCreate" class="btn btn-primary" runat="server" Text="Create" OnClick="btnCreate_Click"
                                                    OnClientClick="Confirm()" ValidationGroup="assetsgroup"></asp:Button>
                                                <asp:Button ID="btnReset" class="btn btn-danger" runat="server" Text="Reset" OnClick="btnReset_Click"></asp:Button>
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
