<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="viewobtforapproval.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees.viewobtforapproval" %>

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
        function Confirm2() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to approve this OBT?")) {
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
                <h3 class="m-0 text-dark">OBT<small> <%=getname() %></small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="../../../Default_kiosk.aspx" class="btn btn-default"><i class="fa fa-home"></i>Back to Home</a>
                        <a href="viewobtforapproval.aspx?id=<%=empno %> class="btn btn-default"><i class="fa fa-list"></i>List</a>
                        <a id="A3" runat="server" onserverclick="btnExport_Click" class="btn btn-default"><i class="fa fa-arrow-circle-o-up"></i><span class="h6">Export to Excel</span></a>
                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="box-body">
                                    <div class='printableArea'>
                                        <div id="list">
                                            <h3 class="box-title">OBT FOR APPROVAL</h3>
                                            <asp:HiddenField ID="hfAprrove" runat="server" />
                                            <div style="overflow-x: auto;" id="obtforapproval-grid" class="grid-view">
                                                <div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>
                                                <asp:GridView ID="GridForApproval" runat="server" AutoGenerateColumns="False"
                                                    ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                    GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                    ForeColor="Black" OnRowCommand="GridForApproval_RowCommand"
                                                    OnPageIndexChanging="GridForApproval_PageIndexChanging" ShowHeaderWhenEmpty="true"
                                                    ViewStateMode="Enabled" OnRowDataBound="GridForApproval_OnRowDataBound" PageSize="10">
                                                    <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
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
                                                                <asp:LinkButton ID="LinkButton1" CssClass="h8" Text='Status' runat="server" CommandName="Sort" CommandArgument="OBT_Status"></asp:LinkButton><br />

                                                                <%--<asp:TextBox ID="txtSearchStatus"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <span class=""><%# Eval("OBT_Status")%></span>
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
                                                                <asp:LinkButton ID="LinkButton3" CssClass="h8" Text='Date From' runat="server" CommandName="Sort" CommandArgument="DateFrom"></asp:LinkButton><br />
                                                                <%--<asp:TextBox ID="txtSearchDTFrom"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <span class=""><%# Eval("DateFrom")%></span>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="LinkButton3" CssClass="h8" Text='Date To' runat="server" CommandName="Sort" CommandArgument="DateTo"></asp:LinkButton><br />
                                                                <%--<asp:TextBox ID="txtSearchDTFrom"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <span class=""><%# Eval("DateTo")%></span>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="LinkButton4" CssClass="h8" Text='TimeIn' runat="server" CommandName="Sort" CommandArgument="TimeIn"></asp:LinkButton><br />
                                                                <%--<asp:TextBox ID="txtSearchDTto"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <span class=""><%# Eval("TimeIn")%></span>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="LinkButton5" CssClass="h8" Text='TimeOut' runat="server" CommandName="Sort" CommandArgument="TimeOut"></asp:LinkButton><br />
                                                                <%--<asp:TextBox ID="txtSearchDays"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <span class=""><%# Eval("TimeOut")%></span>
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
                                                                <asp:LinkButton ID="LinkButton8" Width="200px" CssClass="h8" Text='Date Approved1' runat="server" CommandName="Sort" CommandArgument="DateApproved1"></asp:LinkButton><br />
                                                                <%--<asp:TextBox ID="txtSearchDapproved1"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDate1" runat="server" Text='<%# Eval("DateApproved1")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="LinkButton10" Width="200px" CssClass="h8" Text='Date Approved2' runat="server" CommandName="Sort" CommandArgument="DateApproved2"></asp:LinkButton><br />
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

                                                        <asp:TemplateField HeaderStyle-Width="10%">
                                                            <ItemTemplate>
                                                                <center>
                                                                    <asp:Button ID="btnApprove" CssClass="btn-success btn-xs" runat="server" Text="Approve" Width="70px"  CommandName="cmd_approve" CommandArgument='<%# Eval("id") %>' OnClientClick="Confirm2()" Visible='<%# Eval("OBT_Status").ToString() == "PENDING" %>'  />
                                                                    <asp:Button ID="btnDisapprove" CssClass="btn-danger btn-xs" runat="server" Text="Disapprove" Width="70px" CommandName="cmd_disapprove" CommandArgument='<%# Eval("id") %>' Visible='<%# Eval("OBT_Status").ToString() == "PENDING" %>'  />
                                                                    <%--<asp:LinkButton ID="btnUpdate" runat="server" ForeColor="Black" Font-Size="Medium" CommandName="upd" CommandArgument='<%# Eval("id") %>' Visible='<%# Eval("OBT_Status").ToString() == "PENDING" %>'><i class="fa fa-edit"></i></asp:LinkButton>&ensp;
                                                                    <asp:LinkButton ID="btnDelete" runat="server" ForeColor="Black" Font-Size="Medium" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;"  CommandName="del" CommandArgument='<%# Eval("id") %>' Visible='<%# Eval("OBT_Status").ToString() == "PENDING" %>'><i class="fa fa-trash"></i></asp:LinkButton>--%>
                                                                </center>
                                                                <%--<asp:Button ID="btnAction" CssClass="btn-success btn-xs" runat="server" Text="Action"  CommandName="action" CommandArgument='<%# Eval("id") %>'  />--%>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>


                                                    </Columns>
                                                </asp:GridView>

                                            </div>
                                        </div>
                                    </div>

                                    <div class="box box-primary">
                                        <div class="box-header">
                                            <h3 class="box-title">FILED OBT</h3>
                                        </div>
                                        <div class="box-body">
                                            <div class='printableArea'>
                                                <div id="list">
                                                    <div id="filedobt-grid" style="overflow-x: auto;" class="grid-view">
                                                        <div style="overflow-x: auto;" id="obtforapproval-grid" class="grid-view">
                                                            <%--<div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>--%>
                                                            <asp:GridView ID="GridFiledObt" runat="server" AutoGenerateColumns="False"
                                                                ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                                GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                                ForeColor="Black" OnRowCommand="GridFiledObt_RowCommand"
                                                                OnPageIndexChanging="GridFiledObt_PageIndexChanging" ShowHeaderWhenEmpty="true"
                                                                ViewStateMode="Enabled">
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
                                                                            <asp:LinkButton ID="LinkButton1" CssClass="h8" Text='Status' runat="server" CommandName="Sort" CommandArgument="OBT_Status"></asp:LinkButton><br />
                                                                            <%--<asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="txtItem_TextChanged">
                                                                                <asp:ListItem Value = "1" Text="Approved"></asp:ListItem>
                                                                                <asp:ListItem Value = "2" Text="Denied"></asp:ListItem>
                                                                                <asp:ListItem Value = "3" Text="Pending"></asp:ListItem>
                                                                            </asp:DropDownList>--%>
                                                                            <%--<asp:TextBox ID="txtSearchOBT_Status"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <span class=""><%# Eval("OBT_Status") %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="LinkButton2" CssClass="h8" Text='Date Filed' runat="server" CommandName="Sort" CommandArgument="DateFiled"></asp:LinkButton><br />
                                                                            <%--<asp:TextBox ID="txtSearchDateFiled"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <span class=""><%# Eval("DateFiled") %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="LinkButton3" CssClass="h8" Text='Date From' runat="server" CommandName="Sort" CommandArgument="DateFrom"></asp:LinkButton><br />
                                                                            <%--<asp:TextBox ID="txtSearchTripDate"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <span class=""><%# Eval("DateFrom")%></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="LinkButton3" CssClass="h8" Text='Date To' runat="server" CommandName="Sort" CommandArgument="DateTo"></asp:LinkButton><br />
                                                                            <%--<asp:TextBox ID="txtSearchTripDate"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <span class=""><%# Eval("DateTo")%></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="LinkButton4" Width="80px" CssClass="h8" Text='In' runat="server" CommandName="Sort" CommandArgument="TimeIn"></asp:LinkButton><br />
                                                                            <%--<asp:TextBox ID="txtSearchTimeIn"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <span class=""><%# Eval("TimeIn")%></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="LinkButton5" Width="80px" CssClass="h8" Text='Out' runat="server" CommandName="Sort" CommandArgument="TimeOut"></asp:LinkButton><br />
                                                                            <%--<asp:TextBox ID="txtSearchTimeOut"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <span class=""><%# Eval("TimeOut") %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="LinkButton6" Width="200px" CssClass="h8" Text='Reason' runat="server" CommandName="Sort" CommandArgument="Reason"></asp:LinkButton><br />
                                                                            <%--<asp:TextBox ID="txtSearchReason"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <span class=""><%# Eval("Reason")%></span>
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
                                                                            <asp:LinkButton ID="LinkButton10" Width="200px" CssClass="h8" Text='Date Approved 2' runat="server" CommandName="Sort" CommandArgument="DateApproved2"></asp:LinkButton><br />
                                                                            <%--<asp:TextBox ID="txtSearchDapproved2"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <span class=""><%# Eval("DateApproved2")%></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="LinkButton11" Width="200px" CssClass="h8" Text='Reason for Disapproval' runat="server" CommandName="Sort" CommandArgument="reasons2"></asp:LinkButton><br />
                                                                            <%--<asp:TextBox ID="txtSearchreasons2"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <span class=""><%# Eval("reasons2")%></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>



                                                                    <asp:TemplateField HeaderStyle-Width="">
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="LinkButton10" CssClass="h8" Width="50px" Text='Actions' runat="server" CommandName="Sort" CommandArgument="DateApproved2"></asp:LinkButton><br />
                                                                            <%--<asp:TextBox ID="txtSearchDapproved2"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <center>
                                                                                <asp:LinkButton ID="btnUpdate" runat="server" ForeColor="Black" Font-Size="Medium" CommandName="upd" CommandArgument='<%# Eval("id") %>' Visible='<%# Eval("OBT_Status").ToString() == "PENDING" %>'><i class="fa fa-edit"></i></asp:LinkButton>&ensp;
                                                                                <asp:LinkButton ID="btnDelete" runat="server" ForeColor="Black" Font-Size="Medium" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;"  CommandName="del" CommandArgument='<%# Eval("id") %>' Visible='<%# Eval("OBT_Status").ToString() == "PENDING" %>'><i class="fa fa-trash"></i></asp:LinkButton>
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
                                    <div class="box box-primary" runat="server" visible="false">
                                        <div class="box-header">
                                            <h3 class="box-title">ADD OBT</h3>
                                        </div>
                                        <div class="box-body">
                                            <div class='printableArea'>
                                                <div id="list">
                                                    <div id="leaves"></div>
                                                    <div class="col-lg-12 col-md-6">
                                                        <h4>Fields with <span class="required text-red">*</span> are required.</h4>

                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-6">
                                                            <label for="txtDateFrom" class="required">
                                                                 Date From<span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="txtDateFrom" ValidationGroup="obt"></asp:RequiredFieldValidator></label>
                                                            <input class="form-control" autocomplete="off" id="txtDateFrom" name="Obt[DateFrom]" type="date" min="1900-01-01" max="2099-12-31" runat="server" />
                                                            <label for="txtDateTo" class="required">
                                                                 Date To <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator10" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="txtDateTo" ValidationGroup="obt"></asp:RequiredFieldValidator></label>
                                                            <input class="form-control" autocomplete="off" id="txtDateTo" name="Obt[DateTo]" type="date" min="1900-01-01" max="2099-12-31" runat="server" />
                                                            <%--<label for="Obt_EndDate" class="required">
                                                                Date To <span class="required text-red">**</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="txtEndDate" ValidationGroup="obt"></asp:RequiredFieldValidator></label>
                                                            <input class="form-control" autocomplete="off" id="txtEndDate" name="Obt[EndDate]" type="date" runat="server" />--%>

                                                            <label for="Obt_Reason" class="required">
                                                                Reason <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="Reason" ValidationGroup="obt"></asp:RequiredFieldValidator></label>
                                                            <textarea class="form-control" maxlength="200" name="Obt[Reason]" id="Reason" runat="server"></textarea>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <label for="Obt_In" class="required">
                                                                In<span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="addTimeIn" ValidationGroup="obt"></asp:RequiredFieldValidator></label>
                                                            <input type="time" id="addTimeIn" class="form-control" name="intTimeIn" min="08:00" max="17:00" value ="08:00" style="width:150px;" runat="server">

                                                            <label for="Obt_Out" class="required">
                                                                Out<span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator8" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="addTimeOut" ValidationGroup="obt"></asp:RequiredFieldValidator></label>
                                                            <input type="time" id="addTimeOut" name="intTimeOut" class="form-control" min="08:00" max="17:00" value="17:00" style="width:150px;" runat="server">
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="form-actions">
                                                        <asp:Button ID="btnCreate" class="btn btn-primary" Width="80" runat="server" Text="Create"
                                                            OnClick="btnCreate_Click" ValidationGroup="obt" OnClientClick="Confirm()"></asp:Button>
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
                    </div>
                </section>
            </div>
        </div>
    </div>
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
                                <div class="col-lg-6">
                                    <label for="upd_DateFrom" class="required">
                                        Date From <span class="required text-red">*</span><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator4" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                            ControlToValidate="upd_DateFrom" ValidationGroup="updobt"></asp:RequiredFieldValidator></label>
                                    <input class="form-control" autocomplete="off" id="upd_DateFrom" name="Obt[TripDate]" type="date" min="1900-01-01" max="2099-12-31" runat="server" />

                                    <label for="upd_DateTo" class="required">
                                        Date To <span class="required text-red">*</span><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator11" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                            ControlToValidate="upd_DateTo" ValidationGroup="updobt"></asp:RequiredFieldValidator></label>
                                    <input class="form-control" autocomplete="off" id="upd_DateTo" name="Obt[TripDate]" type="date" min="1900-01-01" max="2099-12-31" runat="server" />
                                    <%--<label for="upd_EndDate" class="required">Date To <span class="required text-red">**</span><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator5" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                     ControlToValidate="upd_EndDate" ValidationGroup="updobt"></asp:RequiredFieldValidator></label>
                                <input class="form-control datetimepicker" autocomplete="off" id="upd_EndDate" name="Obt[EndDate]" type="text" runat="server" />	--%>

                                    <label for="upd_Reason" class="required">
                                        Reason <span class="required text-red">*</span><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator6" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                            ControlToValidate="upd_Reason" ValidationGroup="updobt"></asp:RequiredFieldValidator></label>
                                    <textarea class="form-control" maxlength="200" name="Obt[Reason]" id="upd_Reason" runat="server"></textarea>
                                </div>
                                <div class="col-lg-6">
                                    <label for="upd_TimeIn" class="required">
                                                                In<span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator5" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="upd_TimeIn" ValidationGroup="updobt"></asp:RequiredFieldValidator></label>
                                    <input type="time" class="form-control" id="upd_TimeIn" name="intTimeIn" min="08:00" max="17:00" style="width:200px;" runat="server">

                                    <label for="upd_TimeOut" class="required">
                                                                Out<span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator9" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="upd_TimeOut" ValidationGroup="updobt"></asp:RequiredFieldValidator></label>
                                    <input type="time" class="form-control" id="upd_TimeOut" name="intTimeIn" min="08:00" max="17:00" style="width:200px;" runat="server">
                                </div>
                            </div>


                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Apply Action" CssClass="btn btn-primary"
                                OnClick="btnsaveUpdate_Click" OnClientClick="Confirm1()" ValidationGroup="updobt"></asp:Button>


                        </div>


                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnsaveUpdate" />
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
                                <asp:Label ID="Label1" runat="server" Text="Edit Information"></asp:Label></h4>
                            <asp:LinkButton ID="LinkButton13" CssClass="close" runat="server"
                                OnClick="lnkbtnXlist1_Click">
                            <span>&times;</span>
                            </asp:LinkButton>
                        </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="HiddenField1" runat="server" />

                            <div class="row">
                                <div class="col-lg-5">
                                    <div class="form-group">
                                        <label for="dis_DateFrom" class="required">Date From</label>
                                        <input class="form-control datetimepicker" autocomplete="off" id="dis_DateFrom"
                                            name="Obt[TripDate]" type="text" runat="server" disabled="disabled" />
                                        <label for="dis_DateTo" class="required">Date To</label>
                                        <input class="form-control datetimepicker" autocomplete="off" id="dis_DateTo"
                                            name="Obt[TripDate]" type="text" runat="server" disabled="disabled" />

                                        <label for="dis_Reason" class="required">Reason</label>
                                        <textarea class="form-control" maxlength="200" name="Obt[Reason]" id="dis_Reason" runat="server" disabled="disabled"></textarea>
                                    </div>
                                </div>
                                <div class="col-lg-7">
                                    <div class="form-group">
                                        <label for="dis_TimeIn" class="required">In</label>
                                        <input class="form-control timepickerUI" id="dis_TimeIn" name="Obt[In]" type="text" disabled="disabled" runat="server" />

                                        <label for="dis_TimeOut" class="required">Out</label>
                                        <input class="form-control timepicker" id="dis_TimeOut" name="Obt[Out]" type="text" disabled="disabled" runat="server" />

                                        <label for="dis_Reason2" class="required">
                                            Reason for Disapproval <span class="required text-red">**</span><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator7" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                ControlToValidate="dis_Reason2" ValidationGroup="disapprove"></asp:RequiredFieldValidator></label>
                                        <textarea class="form-control" maxlength="200" name="Obt[Reason]" id="dis_Reason2" runat="server"></textarea>
                                    </div>
                                </div>
                            </div>


                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnDisapprove" runat="server" Text="Save" CssClass="btn btn-primary" Width="70px"
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
