﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="viewleavesforapproval.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees.viewleavesforapproval" %>

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
    <script type="text/javascript">
       <!--
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }
       //-->
    </script>
    <script type="text/javascript">
        function Confirm2() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to approve this Leave?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
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
                    <h3 class="m-0 text-dark">Leaves<small> <%=getname() %></small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="../../../Default_kiosk.aspx" class="btn btn-default"><i class="fa fa-home"></i><span class="h6">Back to Home</span></a>
                            <a href="viewleavesforapproval.aspx?id=<%=empno %>" class="btn btn-default"><i class="fa fa-list"></i>List</a>
                            <a id="A3" runat="server" onserverclick="btnExport_Click" class="btn btn-default"><i class="fa fa-arrow-circle-o-up"></i><span class="h6">Export to Excel</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">
                                        <h3 class="box-title">LEAVES FOR APPROVAL</h3>
                                        <div class="" id="yw1">
                                            <div class="portlet-content">
                                                <ul class="nav nav-pills"></ul>
                                            </div>
                                        </div>
                                        <asp:HiddenField ID="hfAprrove" runat="server" />
                                        <div style="overflow-x: auto;" id="leavesforapproval-grid" class="grid-view">
                                            <div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>
                                            <asp:GridView ID="GridForApproval" runat="server" AutoGenerateColumns="False"
                                                ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                ForeColor="Black" OnRowCommand="GridForApproval_RowCommand"
                                                OnPageIndexChanging="GridForApproval_PageIndexChanging" ShowHeaderWhenEmpty="true"
                                                ViewStateMode="Enabled" OnRowDataBound="GridForApproval_OnRowDataBound">
                                                <EmptyDataTemplate>
                                                    <center><h1>NO DATA AVAILABLE</h1></center>
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblid" CssClass="h8" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton1" CssClass="h8" Text='Status' runat="server" CommandName="Sort" CommandArgument="LeaveStatus"></asp:LinkButton><br />

                                                            <%--<asp:TextBox ID="txtSearchStatus"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("LeaveStatus")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton9" Width="200px" CssClass="h8" Text='Name' runat="server" CommandName="Sort" CommandArgument="FullName"></asp:LinkButton><br />
                                                            <%--<asp:TextBox ID="txtSearchApprover2"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("FullName")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton2" Width="200px" CssClass="h8" Text='Leave Type' runat="server" CommandName="Sort" CommandArgument="LeaveTypeDesc"></asp:LinkButton><br />
                                                            <%--<asp:TextBox ID="txtSearchLeaveType"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("LeaveTypeDesc")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton3" Width="100px" CssClass="h8" Text='Date From' runat="server" CommandName="Sort" CommandArgument="DateFrom"></asp:LinkButton><br />
                                                            <%--<asp:TextBox ID="txtSearchDTFrom"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("DateFrom")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton4" CssClass="h8" Text='Date To' runat="server" CommandName="Sort" CommandArgument="DateTo"></asp:LinkButton><br />
                                                            <%--<asp:TextBox ID="txtSearchDTto"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("DateTo")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <%--<asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton4" CssClass="h8" Text='Hours' runat="server" CommandName="Sort" CommandArgument="LeaveHours"></asp:LinkButton><br />--%>
                                                    <%--<asp:TextBox ID="txtSearchDTto"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                    <%--  </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("LeaveHours")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton5" Width="100px" CssClass="h8" Text='Hours' runat="server" CommandName="Sort" CommandArgument="LeaveHours"></asp:LinkButton><br />
                                                            <%--<asp:TextBox ID="txtSearchDays"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("txtSearchLeaveHours")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton6" Width="100px" CssClass="h8" Text='Date Filed' runat="server" CommandName="Sort" CommandArgument="DateFiled"></asp:LinkButton><br />
                                                            <%--<asp:TextBox ID="txtSearchDateFiled"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("DateFiled")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton8" Width="200px" CssClass="h8" Text='Date Approved 1' runat="server" CommandName="Sort" CommandArgument="DateApproved1"></asp:LinkButton><br />
                                                            <%--<asp:TextBox ID="txtSearchDapproved1"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDate1" runat="server" Text='<%# Eval("DateApproved1")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton10" Width="200px" CssClass="h8" Text='Date Approved 2' runat="server" CommandName="Sort" CommandArgument="DateApproved2"></asp:LinkButton><br />
                                                            <%--<asp:TextBox ID="txtSearchDApproved2"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDate2" runat="server" Text='<%# Eval("DateApproved2")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton12" Width="200px" CssClass="h8" Text='Reason for Disapproval' runat="server" CommandName="Sort" CommandArgument="reasons2"></asp:LinkButton><br />
                                                            <%--<asp:TextBox ID="txtSearchDisapproval"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("reasons2")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApp1" runat="server" Text='<%# Eval("App1")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApp2" runat="server" Text='<%# Eval("App2")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton9" CssClass="h8" Width="90px" Text='' runat="server" CommandName="Sort" CommandArgument="FullName"></asp:LinkButton><br />
                                                            <%--<asp:TextBox ID="txtSearchApprover2"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <center>
                                                                <asp:Button ID="btnApprove" CssClass="btn-success btn-xs" runat="server" Text="Approve" Width="70px"  CommandName="cmd_approve" CommandArgument='<%# Eval("id")+","+Eval("EmpID") %>' OnClientClick="Confirm2()" Visible='<%# Eval("LeaveStatus").ToString() == "PENDING" %>'  />                                                                
                                                                <asp:Button ID="btnDisapprove" CssClass="btn-danger btn-xs" runat="server" Text="Disapprove" Width="70px"  CommandName="cmd_disapprove" CommandArgument='<%# Eval("id") %>' Visible='<%# Eval("LeaveStatus").ToString() == "PENDING" %>' />
                                                                <%--<asp:LinkButton ID="btnUpdate" runat="server" ForeColor="Black" Font-Size="Medium" CommandName="upd" CommandArgument='<%# Eval("id") %>' Visible='<%# Eval("LeaveStatus").ToString() == "PENDING" %>'><i class="fa fa-edit"></i></asp:LinkButton>&ensp;
                                                                <asp:LinkButton ID="btnDelete" runat="server" ForeColor="Black" Font-Size="Medium" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;"  CommandName="del" CommandArgument='<%# Eval("id") %>' Visible='<%# Eval("LeaveStatus").ToString() == "PENDING" %>'><i class="fa fa-trash"></i></asp:LinkButton>--%>
                                                            </center>
                                                            <%--<asp:Button ID="btnAction" CssClass="btn-success btn-xs" runat="server" Text="Action"  CommandName="action" CommandArgument='<%# Eval("id") %>'  />--%>
                                                        </ItemTemplate>


                                                    </asp:TemplateField>


                                                </Columns>
                                            </asp:GridView>

                                        </div>
                                    </div>
                                    <div class="box box-primary">
                                        <div class="box-header">
                                            <h3 class="box-title">LEAVE LEDGER</h3>
                                        </div>
                                        <div class="box-body">
                                            <div class='printableArea'>
                                                <div id="list">
                                                    <div id="leaveledger-grid" class="grid-view">
                                                        <%--<div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>--%>
                                                        <asp:GridView ID="GridLeaveLedger" runat="server" AutoGenerateColumns="False"
                                                            ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                            GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                            ForeColor="Black" OnRowCommand="GridLeaveLedger_RowCommand"
                                                            OnPageIndexChanging="GridLeaveLedger_PageIndexChanging"
                                                            ViewStateMode="Enabled" ShowHeaderWhenEmpty="true">
                                                            <EmptyDataTemplate>
                                                                <center><h1>NO USERS AVAILABLE</h1></center>
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
                                                                        <%--<asp:TextBox ID="txtSearchLeavetype"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <span class=""><%# Eval("LeaveType")%></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="linkbtn_2" CssClass="h8" Text='Earned' runat="server" CommandName="Sort" CommandArgument="Allowed"></asp:LinkButton><br />
                                                                        <%--<asp:TextBox ID="txtSearchEarned"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <span class=""><%# Eval("Allowed")%></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="linkbtn_3" CssClass="h8" Text='Used' runat="server" CommandName="Sort" CommandArgument="Used"></asp:LinkButton><br />
                                                                        <%--<asp:TextBox ID="txtSearchUsed"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <span class=""><%# Eval("Used")%></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="linkbtn_4" CssClass="h8" Text='Balance' runat="server" CommandName="Sort" CommandArgument="Remaining"></asp:LinkButton><br />
                                                                        <%--<asp:TextBox ID="txtSearchRemaining"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <span class=""><%# Eval("Remaining")%></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="linkbtn_5" CssClass="h8" Text='Expiry Date' runat="server" CommandName="Sort" CommandArgument="Expiry"></asp:LinkButton><br />
                                                                        <%--<asp:TextBox ID="txtSearchExpiry"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <span class=""><%# Eval("Expiry")%></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>


                                                            </Columns>
                                                        </asp:GridView>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="box box-primary">
                                        <div class="box-header">
                                            <h3 class="box-title">FILED LEAVES</h3>
                                        </div>
                                        <div class="box-body">
                                            <div class='printableArea'>
                                                <div id="list">
                                                    <div style="overflow-x: auto;" id="filedleave-grid" class="grid-view">
                                                        <%--<div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>--%>
                                                        <asp:GridView ID="GridFiledLeave" runat="server" AutoGenerateColumns="False"
                                                            ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                            GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                            ForeColor="Black" OnRowCommand="GridFiledLeave_RowCommand"
                                                            OnPageIndexChanging="GridFiledLeave_PageIndexChanging"
                                                            ViewStateMode="Enabled" ShowHeaderWhenEmpty="true">
                                                            <EmptyDataTemplate>
                                                                <center><h1>NO DATA AVAILABLE</h1></center>
                                                            </EmptyDataTemplate>
                                                            <Columns>
                                                                <asp:TemplateField Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="LinkButton1" CssClass="h8" Text='Status' runat="server" CommandName="Sort" CommandArgument="LeaveStatus"></asp:LinkButton><br />

                                                                        <%--<asp:TextBox ID="txtSearchStatus"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%# Eval("LeaveStatus")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="LinkButton2" Width="200px" CssClass="h8" Text='Leave Type' runat="server" CommandName="Sort" CommandArgument="LeaveTypeDesc"></asp:LinkButton><br />
                                                                        <%--<asp:TextBox ID="txtSearchLeaveType"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <span class=""><%# Eval("LeaveTypeDesc")%></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="LinkButton3" Width="100px" CssClass="h8" Text='Date From' runat="server" CommandName="Sort" CommandArgument="DateFrom"></asp:LinkButton><br />
                                                                        <%--<asp:TextBox ID="txtSearchDTFrom"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <span class=""><%# Eval("DateFrom")%></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="LinkButton4" CssClass="h8" Text='Date To' runat="server" CommandName="Sort" CommandArgument="DateTo"></asp:LinkButton><br />
                                                                        <%--<asp:TextBox ID="txtSearchDTto"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <span class=""><%# Eval("DateTo")%></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="LinkButton5" CssClass="h8" Text='Days' runat="server" CommandName="Sort" CommandArgument="LeaveHours"></asp:LinkButton><br />
                                                                        <%--<asp:TextBox ID="txtSearchDays"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <span class=""><%# Eval("txtSearchLeaveHours")%></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="LinkButton6" Width="100px" CssClass="h8" Text='Date Filed' runat="server" CommandName="Sort" CommandArgument="DateFiled"></asp:LinkButton><br />
                                                                        <%--<asp:TextBox ID="txtSearchDateFiled"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <span class=""><%# Eval("DateFiled")%></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="LinkButton7" Width="200px" CssClass="h8" Text='Approver 1' runat="server" CommandName="Sort" CommandArgument="Approver1"></asp:LinkButton><br />
                                                                        <%--<asp:TextBox ID="txtSearchApprover1"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <span class=""><%# Eval("Approver1")%></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="LinkButton8" Width="200px" CssClass="h8" Text='Date Approved 1' runat="server" CommandName="Sort" CommandArgument="DateApproved1"></asp:LinkButton><br />
                                                                        <%--<asp:TextBox ID="txtSearchDapproved1"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <span class=""><%# Eval("DateApproved1")%></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="LinkButton9" Width="200px" CssClass="h8" Text='Approver 2' runat="server" CommandName="Sort" CommandArgument="Approver2"></asp:LinkButton><br />
                                                                        <%--<asp:TextBox ID="txtSearchApprover2"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <span class=""><%# Eval("Approver2") %></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton CssClass="h8" Width="200px" ID="LinkButton10" Text='Date Approved 2' runat="server" CommandName="Sort" CommandArgument="DateApproved2"></asp:LinkButton><br />
                                                                        <%--<asp:TextBox ID="txtSearchDApproved2"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <span class=""><%# Eval("DateApproved2")%></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="LinkButton11" Width="200px" CssClass="h8" Text='Remarks' runat="server" CommandName="Sort" CommandArgument="Reason"></asp:LinkButton><br />
                                                                        <%--<asp:TextBox ID="txtSearchReason"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <span class=""><%# Eval("Reason")%></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="LinkButton12" Width="200px" CssClass="h8" Text='Reason for Disapproval' runat="server" CommandName="Sort" CommandArgument="reasons2"></asp:LinkButton><br />
                                                                        <%--<asp:TextBox ID="txtSearchDisapproval"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <span class=""><%# Eval("reasons2")%></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>





                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="LinkButton9" CssClass="h8" Width="50px" Text='' runat="server" CommandName="Sort" CommandArgument="FullName"></asp:LinkButton><br />
                                                                        <%--<asp:TextBox ID="txtSearchApprover2"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%--<asp:Button ID="btnAction" CssClass="btn-success btn-xs" runat="server" Text="Action"  CommandName="action" CommandArgument='<%# Eval("id") %>'  />--%>
                                                                        <center>
                                                                                <asp:LinkButton ID="btnUpdate" runat="server" ForeColor="Black" Font-Size="Medium" CommandName="upd" CommandArgument='<%# Eval("id") %>' Visible='<%# Eval("LeaveStatus").ToString() == "PENDING" %>'><i class="fa fa-edit"></i></asp:LinkButton>&ensp;
                                                                                <asp:LinkButton ID="btnDelete" runat="server" ForeColor="Black" Font-Size="Medium" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;"  CommandName="del" CommandArgument='<%# Eval("id") %>' Visible='<%# Eval("LeaveStatus").ToString() == "PENDING" %>'><i class="fa fa-trash"></i></asp:LinkButton>
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
                                    <div class="box box-primary" runat="server" visible="false">
                                        <div class="box-header">
                                            <h3 class="box-title">ADD LEAVE</h3>
                                        </div>
                                        <div class="box-body">
                                            <div class='printableArea'>
                                                <div id="list">
                                                    <div id="leaves"></div>
                                                    <div class="col-lg-12 col-md-6">
                                                        <h4>Fields with <span class="required text-red">*</span> are required.</h4>

                                                    </div>
                                                    <div class="row">
                                                        <!-- Date From-->
                                                        <div class="col-lg-6">
                                                            <label for="Leavesapp_DateFrom" class="required">
                                                                Date From <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator8" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="txtDateFrom" ValidationGroup="LeaveApp"></asp:RequiredFieldValidator></label>
                                                            <div class="input-group date">
                                                                <input class="form-control" id="txtDateFrom" name="Leavesapp[DateFrom]" type="date" min="1900-01-01" max="2099-12-31" runat="server" />
                                                            </div>
                                                            <!-- Date To-->
                                                            <label for="Leavesapp_DateFrom" class="required">
                                                                Date To <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator10" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="txtDateTo" ValidationGroup="LeaveApp"></asp:RequiredFieldValidator></label>
                                                            <div class="input-group date">
                                                                <input class="form-control" id="txtDateTo" name="Leavesapp[DateTo]" type="date" min="1900-01-01" max="2099-12-31" runat="server" />
                                                            </div>
                                                            <div class="form-group">
                                                                <%--<label for="txtLeaveHours" class="required">Leave Hours <span class="required text-red">**</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator10" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="txtLeaveHours" ValidationGroup="LeaveApp"></asp:RequiredFieldValidator></label>
                                                                <div class="input-group">
                                                                    <input class="form-control" id="txtLeaveHours" name="Leavesapp[LeaveHrs]" type="number" min="1" max="8" onkeypress="return isNumberKey(event)"  runat="server" />
                                                                </div>--%>
                                                                <!-- /.input group -->
                                                                <div class="form-group">
                                                                    <label for="Leavesapp_ampm" class="required">Whole/Half Day<span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="Leavesapp_ampm" ValidationGroup="LeaveApp" ForeColor="Red" ErrorMessage="Field Required">
                                                    </asp:RequiredFieldValidator></span></label>
                                                                    <select class="form-control" name="Leavesapp[ampm]" id="Leavesapp_ampm" runat="server">
                                                                        <option value="DAY" selected="selected">Whole Day</option>
                                                                        <option value="AM">AM Only</option>
                                                                        <option value="PM">PM Only</option>
                                                                    </select>

                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="Leavesapp_LeaveType" class="required">
                                                                        Leave Type <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                            ID="RequiredFieldValidator11" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                            ControlToValidate="Leavesapp_LeaveType" ValidationGroup="LeaveApp"></asp:RequiredFieldValidator></label>
                                                                    <asp:DropDownList class="form-control" name="Leave[LeaveType]" ID="Leavesapp_LeaveType" runat="server">
                                                                        <asp:ListItem Value="" Text="---Select Leave Type---"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="slct_LeaveKey" class="required">
                                                                        Leave Type <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                            ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                            ControlToValidate="slct_LeaveKey" ValidationGroup="LeaveApp"></asp:RequiredFieldValidator></label>
                                                                    <asp:DropDownList class="form-control" name="slct_LeaveKey" ID="slct_LeaveKey" runat="server">
                                                                        <asp:ListItem Value="" Text="---SELECT LEAVE---"></asp:ListItem>
                                                                        <asp:ListItem Value="VL" Text="SIL - VACATION LEAVE"></asp:ListItem>
                                                                        <asp:ListItem Value="SL" Text="SIL - SICK LEAVE"></asp:ListItem>
                                                                        <%--<asp:ListItem Value="SLWOP" Text="SICK LEAVE W/O PAY"></asp:ListItem>
                                                                <asp:ListItem Value="LWOP" Text="LEAVE W/O PAY"></asp:ListItem>
                                                                <asp:ListItem Value="MT" Text="MATERNITY W/PAY"></asp:ListItem>
                                                                <asp:ListItem Value="MTWOP" Text="MATERNITY W/O PAY"></asp:ListItem>
                                                                <asp:ListItem Value="PT" Text="PATERNITY W/PAY"></asp:ListItem>
                                                                <asp:ListItem Value="PTWOP" Text="PATERNITY W/O PAY"></asp:ListItem>
                                                                <asp:ListItem Value="UT" Text="UNDERTIME"></asp:ListItem>
                                                                <asp:ListItem Value="OTH" Text="OTHERS"></asp:ListItem>--%>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                            <label for="leave_hours" class="required">
                                                                Leave Hours <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator15" runat="server" ErrorMessage="Field Required" ControlToValidate="leave_hours" ForeColor="Red" ValidationGroup="leaves"></asp:RequiredFieldValidator></label>
                                                            <asp:TextBox TextMode="Number" ID="leave_hours" class="form-control" runat="server" min="2" max="8" value="2" step="0.25"/>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <label for="Leavesapp_Reason" class="required">
                                                                    Remarks <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator12" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                        ControlToValidate="Leavesapp_Reason" ValidationGroup="LeaveApp"></asp:RequiredFieldValidator></label>
                                                                <textarea class="form-control" maxlength="250" rows="3" name="Leavesapp[Reason]" id="Leavesapp_Reason" runat="server"></textarea>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-actions">
                                                        <asp:Button ID="btnCreate" class="btn btn-primary" Width="80" runat="server" Text="Create"
                                                            OnClick="btnCreate_Click" OnClientClick="Confirm()" ValidationGroup="LeaveApp"></asp:Button>
                                                        <asp:Button ID="btnReset" class="btn btn-danger" Width="80" runat="server" Text="Reset"
                                                            OnClick="btnReset_Click"></asp:Button>
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

        <!-- /.row (main row) -->
    </aside>


    <%--Modal update--%>

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
                                <div class="col-lg-6">
                                    <!--<div class="form-group">
			<label><label for="Leavesapp_CODate">Cutoff Date</label></label>
			<div class="input-group date">
      	<div class="input-group-addon">
        	<i class="fa fa-calendar"></i>
        </div>
			<input style="height:20px;" class="form-control" id="CODate" name="Leavesapp[CODate]" type="text" />			</div>
		</div>-->
                                    <!--Date From-->
                                    <label for="Leavesapp_DateFrom" class="required">
                                        Date From<span class="required text-red">*</span><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="upd_dateFrom"
                                            ValidationGroup="updapproval"></asp:RequiredFieldValidator></label>
                                    <div class="input-group date">
                                        <input class="form-control" id="upd_dateFrom" name="Leavesapp[DateFrom]" type="date" min="1900-01-01" max="2099-12-31" runat="server" />
                                    </div>
                                    <!--Date To-->
                                    <label for="Leavesapp_DateFrom" class="required">
                                        Date To <span class="required text-red">*</span><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator13" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="upd_dateTo"
                                            ValidationGroup="updapproval"></asp:RequiredFieldValidator></label>
                                    <div class="input-group date">
                                        <input class="form-control" id="upd_dateTo" name="Leavesapp[DateTo]" type="date" min="1900-01-01" max="2099-12-31" runat="server" />
                                    </div>
                                    <div class="form-group">
                                        <%--<label for="Leavesapp_DateTo" class="required">
                                                Leave Hours <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="upd_LeaveHours"
                                                    ValidationGroup="updapproval"></asp:RequiredFieldValidator></label>
                                        <div class="input-group">
                                            <input class="form-control" maxlength="1" name="emp_NickName" id="upd_LeaveHours" type="number" min="1" max="8" onkeypress="return isNumberKey(event)" runat="server" />
                                           
                                        </div>--%>
                                        <!-- /.input group -->
                                        <label for="Leavesapp_ampm" class="required">Whole Day AM/PM<span class="required text-red">*</span><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator17" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="upd_SelectAmPm"
                                            ValidationGroup="updapproval"></asp:RequiredFieldValidator></label>
                                            <select class="form-control" name="Leavesapp[ampm]" id="upd_SelectAmPm" runat="server">
                                                <option value="DAY" selected="selected">Whole Day</option>
                                                <option value="AM">AM Only</option>
                                                <option value="PM">PM Only</option>
                                            </select>
                                        <label for="Leavesapp_LeaveType" class="required">
                                            Leave Type <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="upd_leavetype"
                                                ValidationGroup="updapproval"></asp:RequiredFieldValidator></label>
                                        <asp:DropDownList class="form-control" name="Leave[LeaveType]" ID="upd_leavetype" runat="server">
                                            <asp:ListItem Value="" Text="---Select Leave Type---"></asp:ListItem>
                                        </asp:DropDownList>
                                        <label for="upd_leavekey" class="required">
                                            Leave Type <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator14" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="upd_leavekey"
                                                ValidationGroup="updapproval"></asp:RequiredFieldValidator></label>
                                        <asp:DropDownList class="form-control" name="upd_leavekey" ID="upd_leavekey" runat="server">
                                            <asp:ListItem Value="" Text="---SELECT LEAVE---"></asp:ListItem>
                                            <asp:ListItem Value="VL" Text="SIL - VACATION LEAVE"></asp:ListItem>
                                            <asp:ListItem Value="SL" Text="SIL - SICK LEAVE"></asp:ListItem>

                                        </asp:DropDownList>
                                        <label for="upd_leave_hours" class="required">
                                            Leave Hours <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator16" runat="server" ErrorMessage="Field Required" ControlToValidate="upd_leave_hours" ForeColor="Red" ValidationGroup="updapproval"></asp:RequiredFieldValidator></label>
                                        <asp:TextBox TextMode="Number" ID="upd_leave_hours" class="form-control" runat="server" min="2" max="8"  step="0.25"/>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="Leavesapp_Reason" class="required">
                                            Remarks <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator4" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="upd_reason"
                                                ValidationGroup="updapproval"></asp:RequiredFieldValidator></label>
                                        <textarea class="form-control" maxlength="250" rows="3" name="Leavesapp[Reason]" id="upd_reason" runat="server"></textarea>
                                    </div>
                                </div>
                            </div>


                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Apply Action" CssClass="btn btn-primary"
                                OnClick="btnsaveUpdate_Click" OnClientClick="Confirm1()" ValidationGroup="updapproval"></asp:Button>


                        </div>


                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnsaveUpdate" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>

    <div class="modal fade" id="listmodal1">
        <div class="modal-dialog">
            <div class="modal-content1">

                <asp:UpdatePanel ID="updLedger" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                    <ContentTemplate>

                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Label ID="Label1" runat="server" Text="Edit Information"></asp:Label></h4>
                            <asp:LinkButton ID="LinkButton13" CssClass="close" runat="server"
                                OnClick="lnkbtnXlist1_Click">
                            <span>&times;</span>
                            </asp:LinkButton>
                        </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <div class="row">
                                <div class="col-lg-6">
                                    <label for="Leave_LeaveType">
                                        Leave Type <span class="required text-red">**</span><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Leave_LeaveType" ValidationGroup="updleaves"
                                            ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></label>
                                    <asp:DropDownList class="form-control" name="Leave[LeaveType]" ID="Leave_LeaveType" runat="server">
                                        <asp:ListItem Value="" Text="---Select Leave Type---"></asp:ListItem>
                                    </asp:DropDownList>
                                    </select>
					            <label for="Leave_Allowed" class="required">
                                    Earned <span class="required text-red">**</span><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Leave_Allowed" ValidationGroup="updleaves"
                                        ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator>
                                </label>
                                    <input class="form-control" name="Leave[Allowed]" id="Leave_Allowed" type="text" runat="server" />
                                    <label for="Leave_Remaining" class="required">
                                        Balance <span class="required text-red">**</span><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Leave_Remaining" ValidationGroup="updleaves"
                                            ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></label>
                                    <input class="form-control" name="Leave[Remaining]" id="Leave_Remaining" type="text" runat="server" />
                                </div>
                                <div class="col-lg-6">
                                    <label for="Leave_Expiry">Expiry Date</label>
                                    <input class="form-control datetimepicker" id="Expiry" name="Leave[Expiry]" type="text" runat="server" />
                                    <label>Activate Leave?</label>
                                    <select class="form-control" name="Leave[Activated]" id="Leave_Activated" runat="server">
                                        <option value="empty">---Select Status---</option>
                                        <option value="1">Yes</option>
                                        <option value="0">No</option>
                                    </select>
                                </div>
                            </div>


                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnUpdateLeave" CssClass="btn btn-primary" Width="70px" runat="server" Text="Apply Action" OnClientClick="Confirm1()" ValidationGroup="updleaves" OnClick="btnUpdateLeave_Click"></asp:Button>


                        </div>


                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnUpdateLeave" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>

    <div class="modal fade" id="listdisapprove">
        <div class="modal-dialog">
            <div class="modal-content1">

                <asp:UpdatePanel ID="updDisapprove" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                    <ContentTemplate>

                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Label ID="Label2" runat="server" Text="Edit Information"></asp:Label></h4>
                            <asp:LinkButton ID="LinkButton14" CssClass="close" runat="server"
                                OnClick="lnkbtnXlist2_Click">
                            <span>&times;</span>
                            </asp:LinkButton>
                        </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="HiddenField2" runat="server" />

                            <div class="row">
                                <div class="col-lg-5">
                                    <label for="Leavesapp_DateFrom" class="required">Date From</label>
                                    <div class="input-group date">
                                        <input class="form-control datetimepicker" id="dis_datefrom" name="Leavesapp[DateFrom]" type="text" runat="server" disabled="disabled" />
                                    </div>
                                    <label for="Leavesapp_DateFrom" class="required">Date To</label>
                                    <div class="input-group date">
                                        <input class="form-control datetimepicker" id="dis_dateto" name="Leavesapp[DateFrom]" type="text" runat="server" disabled="disabled" />
                                    </div>
                                    <div class="form-group">
                                        <%--<label for="Leavesapp_DateTo" class="required">Leave Hours</label>
                                        <div class="input-group">
                                            <input class="form-control" maxlength="1" name="disHours" id="disHours" type="text" runat="server" disabled="disabled"/>
                                            
                                        </div>--%>
                                        <!-- /.input group -->
                                        <div class="form-group">
                                            <%--<label for="Leavesapp_ampm" class="required">Half-day AM/PM</label>
                                            <input class="form-control" id="dis_ampm" name="Leavesapp[DateTo]" type="text" runat="server" disabled="disabled" />--%>

                                            <label for="Leavesapp_LeaveType" class="required">Leave Type</label>
                                            <input class="form-control" id="dis_leavetype" name="Leavesapp[DateTo]" type="text" runat="server" disabled="disabled" />

                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-7">
                                    <div class="form-group">
                                        <label for="Leavesapp_Reason" class="required">Remarks</label>
                                        <textarea class="form-control" maxlength="250" rows="3" name="Leavesapp[Reason]" id="dis_reason" runat="server" disabled="disabled"></textarea>
                                        <label for="dis_Reason2" class="required">
                                            Reason for Disapproval <span class="required text-red">**</span><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator9" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                ControlToValidate="dis_Reason2" ValidationGroup="disapprove"></asp:RequiredFieldValidator></label>
                                        <textarea class="form-control" maxlength="200" name="Obt[Reason]" id="dis_Reason2" runat="server"></textarea>
                                    </div>
                                </div>
                            </div>


                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnDisapprove" Width="70px" runat="server" Text="Save" CssClass="btn-primary"
                                OnClick="btnDisapprove_Click" OnClientClick="Confirm1()" ValidationGroup="disapprove"></asp:Button>


                        </div>


                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnDisapprove" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>
</asp:Content>
