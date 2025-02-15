﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="viewleaves.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.TK.viewleaves" %>

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
    <SCRIPT type="text/javascript">
       <!--
       function isNumberKey(evt)
       {
          var charCode = (evt.which) ? evt.which : evt.keyCode;
          if (charCode != 46 && charCode > 31 
            && (charCode < 48 || charCode > 57))
             return false;

          return true;
       }
       //-->
    </SCRIPT>
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
                    <h3 class="m-0 text-dark">Employee<small> View Leaves</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="leaves.aspx" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Employee View</span></a>
                            <%--<a href="<%= ResolveUrl("~/Pages/Admin/Employees/viewleaves.aspx?empid="+empno+"")%>" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">View Leaves</span></a>--%>
                            <a href="viewleaves.aspx?id=<%=empno %>" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                            <a href="viewleavesapp.aspx?id=<%=empno %>" class="btn btn-default"><i class="fa fa-edit"></i><span class="h6">Apply for Leave</span></a>
                            <a id="A3" runat="server" onserverclick="btnExport_Click" class="btn btn-default"><i class="fa fa-arrow-circle-o-up"></i><span class="h6">Export to Excel</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">
                                        <h4 class="box-title">View Leaves  -  <%=getname()%> </h4>
                                        <div class='printableArea'>
                                            <div id="list">
                                                <div id="display-grid" class="grid-view">
                                                    <div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>
                                                    <asp:GridView ID="GridViewList" runat="server" AutoGenerateColumns="False"
                                                        ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                        GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                        ForeColor="Black" OnRowCommand="GridViewList_RowCommand"
                                                        OnPageIndexChanging="GridViewList_PageIndexChanging"
                                                        ViewStateMode="Enabled" ShowHeaderWhenEmpty="true">
                                                        <EmptyDataTemplate>
                                                            <center><h1>NO LEAVES AVAILABLE</h1></center>
                                                        </EmptyDataTemplate>
                                                        <Columns>
                                                            <asp:TemplateField Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="linkbtn_1" CssClass="h8" Text='Leave Type' runat="server" CommandName="Sort" CommandArgument="LeaveType"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtSearchLeavetype" runat="server" AutoPostBack="true" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <span class=""><%# Eval("LeaveType")%></span>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="linkbtn_2" CssClass="h8" Text='Earned' runat="server" CommandName="Sort" CommandArgument="Allowed"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtSearchEarned" runat="server" AutoPostBack="true" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <span class=""><%# Eval("Allowed")%></span>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="linkbtn_3" CssClass="h8" Text='Used' runat="server" CommandName="Sort" CommandArgument="Used"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtSearchUsed" runat="server" AutoPostBack="true" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <span class=""><%# Eval("Used")%></span>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="linkbtn_4" CssClass="h8" Text='Balance' runat="server" CommandName="Sort" CommandArgument="Remaining"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtSearchRemaining" runat="server" AutoPostBack="true" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <span class=""><%# Eval("Remaining")%></span>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="linkbtn_5" CssClass="h8" Text='Expiry Date' runat="server" CommandName="Sort" CommandArgument="Expiry"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtSearchExpiry" TextMode="Date" runat="server" AutoPostBack="true" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <span class=""><%# Eval("Expiry")%></span>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderStyle-Width="10%">
                                                                <ItemTemplate>
                                                                    <center>
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
                                                    <p class="note">Fields with <span class="required text-red">*</span> are required.</p>
                                                </legend>

                                                <div class="showgrid">
                                                    <div class="row">
                                                        <div class="col-lg-6">
                                                            <label for="Leave_LeaveType" class="required">
                                                                Leave Type <span class="required text-red">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Leave_LeaveType" ValidationGroup="leaves"
                                                                    ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></label>

                                                            <asp:DropDownList class="form-control" name="Leave[LeaveType]" ID="Leave_LeaveType" runat="server">
                                                                <asp:ListItem Value="" Text="---Select Leave Type---"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            

                                                            <label for="Leavesapp_DateTo" class="required">
                                                                Earned <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator7" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="Leave_Allowed"
                                                                    ValidationGroup="leaves"></asp:RequiredFieldValidator></label>
                                                        <div class="input-group">
                                                            <input class="form-control" maxlength="2" name="emp_NickName" id="Leave_Allowed" type="number" min="1" max="18" step=".01" onkeypress="return isNumberKey(event)" runat="server" />
                                           
                                                        </div>
                                                            <label for="Leavesapp_DateTo" class="required">
                                                                Balance <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="Leave_Remaining"
                                                                    ValidationGroup="leaves"></asp:RequiredFieldValidator></label>
                                                        <div class="input-group">
                                                            <input class="form-control" maxlength="2" name="emp_NickName" id="Leave_Remaining" type="number" min="1" max="18" step=".01" onkeypress="return isNumberKey(event)" runat="server" />
                                           
                                                        </div>

                                                        </div>
                                                        <div class="col-lg-6">
                                                            <%--<label for="Leave_Expiry" class="required">Expiry Date <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="Expiry"
                                                                    ValidationGroup="leaves"></asp:RequiredFieldValidator></label>
                                                            <input class="form-control" id="Expiry" name="Leave[Expiry]" type="date" min="1900-01-01" max="2099-12-31" runat="server" />--%>
                                                            <label class="required">Activate Leave? <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator8" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="Leave_Activated"
                                                                    ValidationGroup="leaves"></asp:RequiredFieldValidator></label>
                                                            <select class="form-control" name="Leave[Activated]" id="Leave_Activated" runat="server">
                                                                <option value="empty">---Select Status---</option>
                                                                <option value="1">Yes</option>
                                                                <option value="0">No</option>
                                                            </select>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="form-actions">
                                                    <asp:Button ID="btnCreate" UseSubmitBehavior="true" Width="80" class="btn btn-primary" runat="server" Text="Create"
                                                        OnClick="btnCreate_Click" ValidationGroup="leaves" OnClientClick="Confirm()"></asp:Button>
                                                    <asp:Button ID="btnReset" UseSubmitBehavior="true" Width="80" class="btn btn-danger" runat="server" Text="Reset"
                                                        OnClick="btnReset_Click"></asp:Button>
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
                                    <!-- Date -->
                                    <div class="col-lg-7">
                                        <label for="Leave_LeaveType" class="required">
                                            Leave Type <span class="required text-red">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                                runat="server" ControlToValidate="upd_leavetype" ValidationGroup="leaves1" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator>
                                        </label>
                                        <asp:DropDownList class="form-control" name="Leave[LeaveType]" ID="upd_leavetype" runat="server">
                                            <asp:ListItem Value="" Text="---Select Leave Type---"></asp:ListItem>
                                        </asp:DropDownList>
                                        <label for="Leavesapp_DateTo" class="required">
                                                                Earned <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator4" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="upd_allowed"
                                                                    ValidationGroup="leaves1"></asp:RequiredFieldValidator></label>
                                                        <div class="input-group">
                                                            <input class="form-control" maxlength="2" name="emp_NickName" id="upd_allowed" type="number" min="1" max="18" step=".01" onkeypress="return isNumberKey(event)" runat="server" />
                                           
                                                        </div>
                                        <label for="Leavesapp_DateTo" class="required">
                                                                Balance <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator6" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="upd_remaining"
                                                                    ValidationGroup="leaves1"></asp:RequiredFieldValidator></label>
                                                        <div class="input-group">
                                                            <input class="form-control" maxlength="2" name="emp_NickName" id="upd_remaining" type="number" min="1" max="18" step=".01" onkeypress="return isNumberKey(event)" runat="server" />
                                           
                                                        </div>
                                        <%--<label for="Leave_Allowed" class="required">
                                            Earned <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                                runat="server" ControlToValidate="upd_allowed" ValidationGroup="leaves1" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck" Type="Double"
                                            ControlToValidate="upd_allowed" ErrorMessage="Input numbers only" ValidationGroup="leaves1" ForeColor="Red" />
                                        <input class="form-control" name="Leave[Allowed]" id="upd_allowed" type="text" runat="server" />
                                        <label for="Leave_Remaining" class="required">
                                            Balance <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                                                runat="server" ControlToValidate="upd_remaining" ValidationGroup="leaves1" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" Operator="DataTypeCheck" Type="Double"
                                            ControlToValidate="upd_remaining" ErrorMessage="Input numbers only" ValidationGroup="leaves1" ForeColor="Red" />
                                        <input class="form-control" name="Leave[Remaining]" id="upd_remaining" type="text" runat="server" />--%>
                                    </div>
                                    <div class="col-lg-5">
                                        <%--<label for="Leave_Expiry" class="required">Expiry Date</label>
                                        <input class="form-control datetimepicker" id="upd_expirydt" name="Leave[Expiry]" type="text" runat="server" />--%>
                                        <label class="required">Activate Leave?</label>
                                        <select class="form-control" name="Leave[Activated]" id="upd_activated" runat="server">
                                            <option value="empty">---Select Status---</option>
                                            <option value="1">Yes</option>
                                            <option value="0">No</option>
                                        </select>
                                    </div>


                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnsaveUpdate" runat="server" Text="Apply Action" CssClass="btn btn-primary"
                                        OnClick="btnsaveUpdate_Click" UseSubmitBehavior="true" OnClientClick="Confirm1()" ValidationGroup="leaves1"></asp:Button>


                                </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnsaveUpdate" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>
    </aside>
</asp:Content>
