﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeSchedList.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.EmployeeSchedList" %>

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
                    <h3 class="m-0 text-dark">Admin<small> Employee Schedules</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="AdminPage.aspx" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Back</span></a>
                            <a href="CreateSched.aspx" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                            <a href="EmployeeSchedList.aspx" class="btn btn-default"><i class="fa fa-th-list"></i><span class="h6">List</span></a>
                            <a id="A1" class="btn btn-default" runat="server" onserverclick="ExportToPDF"><i class="fa fa-arrow-circle-o-up"></i><span class="h6">Export to PDF</span></a>
                            <a id="A2" class="btn btn-default" runat="server" onserverclick="btnExport_Click"><i class="fa fa-arrow-circle-o-up"></i><span class="h6">Export to Excel</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">
                                        <div class="search-form" style="display: none">
                                            <div style="display: none">
                                                <input type="hidden" value="empsched/index" name="r" />
                                            </div>
                                            <div class="row">

                                                <div class="col-lg-6">
                                                    <label for="Empsched_id">ID</label><input class="form-control" name="Empsched[id]" id="Empsched_id" type="text" />
                                                    <label for="Empsched_Sched_TimeIn" class="required">Sched Time In <span class="required text-red">**</span></label><input class="form-control" maxlength="5" name="Empsched[Sched_TimeIn]" id="Empsched_Sched_TimeIn" type="text" />
                                                </div>
                                                <div class="col-lg-6">
                                                    <label for="Empsched_Sched_TimeOut" class="required">Sched Time Out <span class="required text-red">**</span></label><input class="form-control" maxlength="5" name="Empsched[Sched_TimeOut]" id="Empsched_Sched_TimeOut" type="text" />
                                                    <label for="Empsched_Sched_RestDay">Sched Rest Day</label><input class="form-control" maxlength="3" name="Empsched[Sched_RestDay]" id="Empsched_Sched_RestDay" type="text" />
                                                </div>
                                            </div>
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
                                                    $(":input", "#search-empsched-form").each(function () {
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
                                                    <center><h1>NO SCHEDULE AVAILABLE</h1></center>
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="linkbtn_1" CssClass="h8" Text='Sched Time In' runat="server" CommandName="Sort" CommandArgument="Sched_TimeIn"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchTimein" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("Sched_TimeIn")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="linkbtn_2" CssClass="h8" Text='Sched Time Out' runat="server" CommandName="Sort" CommandArgument="Sched_TimeOut"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchTimeout" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("Sched_TimeOut")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="linkbtn_3" CssClass="h8" Text='ShiftName' runat="server" CommandName="Sort" CommandArgument="ShiftName"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchSname" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("ShiftName")%></span>
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
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </aside>

    <div class="modal fade" id="listmodal">
        <div class="modal-dialog">
            <div class="modal-content">

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
                                <!-- Date -->

                                <div class="col-lg-8">
                                    <label for="upd_TimeIn" class="required">Sched Time In <span class="required text-red">**</span></label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ControlToValidate="upd_TimeIn" ValidationGroup="SchedGroup"></asp:RequiredFieldValidator>
                                    <input size="11" class="form-control" id="upd_TimeIn" name="Empsched[Sched_TimeIn]" type="text" maxlength="5" runat="server" />
                                    <label for="upd_TimeOut" class="required">Sched Time Out <span class="required text-red">**</span></label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ControlToValidate="upd_TimeOut" ValidationGroup="SchedGroup"></asp:RequiredFieldValidator>
                                    <input size="11" class="form-control" id="upd_TimeOut" name="Empsched[Sched_TimeOut]" type="text" maxlength="5" runat="server" />
                                    <label for="upd_ShiftName" class="required">Shift Name</label>
                                    <input class="form-control" maxlength="50" name="Empsched[ShiftName]" id="upd_ShiftName" type="text" runat="server" />
                                </div>

                            </div>


                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Update" CssClass="btn btn-primary"
                                OnClick="btnsaveUpdate_Click" OnClientClick="Confirm()" ValidationGroup="SchedGroup"></asp:Button>


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
                                    <input size="11" class="form-control" id="vw_ID" name="Empsched[Sched_TimeIn]" type="text" maxlength="5" runat="server" disabled="disabled" />
                                    <label for="vw_TimeIn" class="required">Sched Time In</label>
                                    <input size="11" class="form-control" id="vw_TimeIn" name="Empsched[Sched_TimeIn]" type="text" maxlength="5" runat="server" disabled="disabled" />
                                    <label for="vw_TimeOut" class="required">Sched Time Out</label>
                                    <input size="11" class="form-control" id="vw_TimeOut" name="Empsched[Sched_TimeOut]" type="text" maxlength="5" runat="server" disabled="disabled" />
                                    <label for="vw_ShiftName" class="required">Shift Name</label>
                                    <input class="form-control" maxlength="50" name="Empsched[ShiftName]" id="vw_ShiftName" type="text" runat="server" disabled="disabled" />

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
