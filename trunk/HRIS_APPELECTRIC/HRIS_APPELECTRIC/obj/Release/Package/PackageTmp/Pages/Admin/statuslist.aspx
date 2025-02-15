﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="statuslist.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.statuslist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <aside class="right-side">


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
                    <h3 class="m-0 text-dark">Admin<small> Status</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="AdminPage.aspx" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Back</span></a>
                            <a href="createstatus.aspx" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                            <a href="statuslist.aspx" class="btn btn-default"><i class="fa fa-th-list"></i><span class="h6">List</span></a>
                            <a runat="server" class="btn btn-default" onserverclick="ExportToPDF"><i class="fa fa-arrow-circle-o-up"></i><span class="h6">Export to PDF</span></a>
                            <a runat="server" class="btn btn-default" onserverclick="btnExport_Click"><i class="fa fa-arrow-circle-o-up"></i><span class="h6">Export to Excel</span></a>
                        </div>

                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">
                                        <div class="box-body">
                                            <div class="search-form" style="display: none">
                                                <input type="hidden" value="empStatus/index" name="r">

                                                <label for="EmpStatus_EmpStatus">Emp Status</label><input class="span5" maxlength="1" name="EmpStatus[EmpStatus]" id="EmpStatus_EmpStatus" type="text">
                                                <label for="EmpStatus_id">ID</label><input class="span5" name="EmpStatus[id]" id="EmpStatus_id" type="text">
                                                <label for="EmpStatus_Description">Description</label><input class="span5" maxlength="20" name="EmpStatus[Description]" id="EmpStatus_Description" type="text">
                                                <label for="EmpStatus_SSSRef">Sssref</label><input class="span5" maxlength="1" name="EmpStatus[SSSRef]" id="EmpStatus_SSSRef" type="text">
                                                <label for="EmpStatus_DaysPerMonth">Days Per Month</label><input class="span5" name="EmpStatus[DaysPerMonth]" id="EmpStatus_DaysPerMonth" type="text">
                                                <label for="EmpStatus_DaysPerYear">Days Per Year</label><input class="span5" name="EmpStatus[DaysPerYear]" id="EmpStatus_DaysPerYear" type="text">
                                                <label for="EmpStatus_MonthPerYear">Month Per Year</label><input class="span5" name="EmpStatus[MonthPerYear]" id="EmpStatus_MonthPerYear" type="text">
                                                <label for="EmpStatus_VarRef">Var Ref</label><input class="span5" maxlength="1" name="EmpStatus[VarRef]" id="EmpStatus_VarRef" type="text">
                                                <div class="form-actions">
                                                    <button class="btn btn-primary" type="submit" name="yt0"><i class="icon-search icon-white"></i>Search</button>
                                                    <button class="btnreset btn-small btn" name="yt1" type="button"><i class="icon-remove-sign white"></i>Reset</button>
                                                </div>
                                                <script type="text/javascript">
                                                    function Confirm() {
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

                                                <script>
                                                    $(".btnreset").click(function () {
                                                        $(":input", "#search-emp-status-form").each(function () {
                                                            var type = this.type;
                                                            var tag = this.tagName.toLowerCase(); // normalize case
                                                            if (type == "text" || type == "password" || tag == "textarea") this.value = "";
                                                            else if (type == "checkbox" || type == "radio") this.checked = false;
                                                            else if (tag == "select") this.selectedIndex = "";
                                                        });
                                                    });
                                                </script>

                                            </div>
                                            <!-- search-form -->


                                            <div id="display-grid" class="grid-view">
                                                <div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>
                                                <asp:GridView ID="GridViewList" runat="server" AutoGenerateColumns="False"
                                                    ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                    GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                    ForeColor="Black" OnRowCommand="GridViewList_RowCommand"
                                                    OnPageIndexChanging="GridViewList_PageIndexChanging"
                                                    ViewStateMode="Enabled">
                                                    <EmptyDataTemplate>
                                                        <center><h1>NO STATUS AVAILABLE</h1></center>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkStatusDesc" CssClass="h8" Text='Description' runat="server" CommandName="Sort" CommandArgument="StatusDesc"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchStatusDesc" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStatusDesc" CssClass="" Text='<%# Eval("StatusDesc") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkSSSRef" CssClass="h8" Text='SSS Ref' runat="server" CommandName="Sort" CommandArgument="SSSRef"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchSSSRef" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSSSRef" CssClass="" Text='<%# Eval("SSSRef") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkDaysPerMonth" CssClass="h8" Text='Days Per Month' runat="server" CommandName="Sort" CommandArgument="DaysPerMonth"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchDaysPerMonth" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDaysPerMonth" CssClass="" Text='<%# Eval("DaysPerMonth") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkDaysPerYear" CssClass="h8" Text='Days Per Year' runat="server" CommandName="Sort" CommandArgument="DaysPerYear"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchDaysPerYear" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDaysPerYear" CssClass="" Text='<%# Eval("DaysPerYear") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>



                                                        <asp:TemplateField HeaderStyle-Width="15%">
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

    <div class="modal fade" id="listmodal">
        <div class="modal-dialog">
            <div class="modal-content1">

                <asp:UpdatePanel ID="upListDetails" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                    <ContentTemplate>

                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Label ID="Label3" runat="server" Text="Edit Information"></asp:Label></h4>
                            <asp:LinkButton ID="lnkbtnXlist" CssClass="close" runat="server"
                                OnClick="lnkbtnXlist_Click">
                            <span>&times;</span>
                            </asp:LinkButton>
                        </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="HiddenEmpID" runat="server" />
                            <div class="row">
                                <!-- Input Text to update -->

                                <div class="col-lg-6">
                                    <label for="upd_EmpStatus" class="required">
                                        Status<span class="required">*</span><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" ControlToValidate="upd_EmpStatus"
                                            ForeColor="Red" ValidationGroup="updStat"></asp:RequiredFieldValidator></label>
                                    <div class="input-group date">

                                        <input class="form-control" id="upd_EmpStatus" name="txtEmpStatus" type="text" runat="server" />
                                    </div>

                                    <label for="upd_StatusDesc" class="required">
                                        Status Description<span class="required">*</span><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" ControlToValidate="upd_StatusDesc"
                                            ForeColor="Red" ValidationGroup="updStat"></asp:RequiredFieldValidator></label>
                                    <div class="input-group date">

                                        <input class="form-control" id="upd_StatusDesc" name="txtStatusDesc" type="text" runat="server" />
                                    </div>

                                    <label for="upd_SSSRef" class="required">
                                        SSS Ref<span class="required">*</span><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required" ControlToValidate="upd_SSSRef"
                                            ForeColor="Red" ValidationGroup="updStat"></asp:RequiredFieldValidator></label>
                                    <div class="input-group date">

                                        <input class="form-control" id="upd_SSSRef" name="txtSSSRef" type="text" runat="server" />
                                    </div>

                                    <label for="upd_DaysPerMonth" class="required">
                                        Days Per Month<span class="required">*</span><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator4" runat="server" ErrorMessage="Field Required" ControlToValidate="upd_DaysPerMonth"
                                            ForeColor="Red" ValidationGroup="updStat"></asp:RequiredFieldValidator></label>
                                    <div class="input-group date">
                                        <input class="form-control" id="upd_DaysPerMonth" name="txtDaysPerMonth" type="text" runat="server" />
                                    </div>

                                </div>
                                <div class="col-lg-6">
                                    <label for="upd_DaysPerYear" class="required">
                                        Days Per Year<span class="required">*</span><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator5" runat="server" ErrorMessage="Field Required" ControlToValidate="upd_DaysPerYear"
                                            ForeColor="Red" ValidationGroup="updStat"></asp:RequiredFieldValidator></label>
                                    <div class="input-group date">
                                        <input class="form-control" id="upd_DaysPerYear" name="txtDaysPerYear" type="text" runat="server" />
                                    </div>

                                    <label for="upd_MonthPerYear" class="required">
                                        Month Per Year<span class="required">*</span><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator6" runat="server" ErrorMessage="Field Required" ControlToValidate="upd_MonthPerYear"
                                            ForeColor="Red" ValidationGroup="updStat"></asp:RequiredFieldValidator></label>
                                    <div class="input-group date">
                                        <input class="form-control" id="upd_MonthPerYear" name="txtMonthPerYear" type="text" runat="server" />
                                    </div>

                                    <label for="upd_VarRef" class="required">
                                        Var Ref<span class="required">*</span><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator7" runat="server" ErrorMessage="Field Required" ControlToValidate="upd_VarRef"
                                            ForeColor="Red" ValidationGroup="updStat"></asp:RequiredFieldValidator></label>
                                    <div class="input-group date">
                                        <input class="form-control" id="upd_VarRef" name="txtVarRef" type="text" runat="server" />
                                    </div>
                                </div>
                            </div>


                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Update" CssClass="btn btn-primary" UseSubmitBehavior="true"
                                OnClick="btnsaveUpdate_Click" OnClientClick="Confirm()" ValidationGroup="updStat"></asp:Button>


                        </div>


                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnsaveUpdate" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>

    <div class="modal fade" id="ViewModal">
        <div class="modal-dialog">
            <div class="modal-content">

                <asp:UpdatePanel ID="upListDetails2" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                    <ContentTemplate>

                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Label ID="Label1" runat="server" Text="View Information"></asp:Label></h4>
                            <asp:LinkButton ID="LinkButton1" CssClass="close" runat="server"
                                OnClick="lnkbtnXlistView_Click">
                            <span>&times;</span>
                            </asp:LinkButton>
                        </div>
                        <div class="modal-body" style="">
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <div class="row">
                                <!-- View Modal Content -->
                                <div class="col-lg-6">
                                    <label for="vw_ID" class="required">ID</label>
                                    <input class="form-control" id="vw_ID" name="vw_ID" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_EmpStatus" class="required">Status</label>
                                    <input class="form-control" id="vw_EmpStatus" name="vw_EmpStatus" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_StatusDesc" class="required">Status Description</label>
                                    <input class="form-control" id="vw_StatusDesc" name="vw_StatusDesc" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_SSSRef" class="required">SSS Ref</label>
                                    <input class="form-control" id="vw_SSSRef" name="vw_SSSRef" type="text" runat="server" disabled="disabled" />
                                </div>
                                <div class="col-lg-6">
                                    <label for="vw_DaysPerMonth" class="required">Days Per Month</label>
                                    <input class="form-control" id="vw_DaysPerMonth" name="vw_DaysPerMonth" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_DaysPerYear" class="required">Days Per Year</label>
                                    <input class="form-control" id="vw_DaysPerYear" name="vw_DaysPerYear" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_MonthPerYear" class="required">Month Per Year</label>
                                    <input class="form-control" id="vw_MonthPerYear" name="vw_MonthPerYear" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_VarRef" class="required">Var Ref</label>
                                    <input class="form-control" id="vw_VarRef" name="vw_VarRef" type="text" runat="server" disabled="disabled" />
                                </div>

                            </div>


                        </div>
                        <div class="modal-footer">
                        </div>


                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>
</asp:Content>
