<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="loanentries.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.PayrollPages.loanentries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
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
                    <h3 class="m-0 text-dark">Payroll<small> Payroll Register</small></h3>
                    <section class="card">
                        <div class="card-header">

                            <a href="#" class="btn btn-default"><i class="fa fa-arrow-circle-o-down"></i><span class="h6">Loans Office</span></a>
                            <a href="#" class="btn btn-default"><i class="fa fa-arrow-circle-o-down"></i><span class="h6">SSS Deduction</span></a>
                            <a href="#" class="btn btn-default"><i class="fa fa-arrow-circle-o-down"></i><span class="h6">HDMF Salary Deduction</span></a>
                            <a href="#" class="btn btn-default"><i class="fa fa-arrow-circle-o-down"></i><span class="h6">HDMF Calamity Deduction</span></a>

                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">
                                        <%--<div class="list">--%>
                                        <div id="display-grid" class="grid-view box-body">
                                            <asp:GridView ID="GridUserList" runat="server" AutoGenerateColumns="False"
                                                ShowFooter="True" CssClass="table table-bordered table-striped table-responsive p-0 dataTable"
                                                GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                ForeColor="Black" OnRowCommand="GridUserList_RowCommand"
                                                OnPageIndexChanging="GridUserList_PageIndexChanging"
                                                ViewStateMode="Enabled" PageSize="25" ShowHeader="true" ShowHeaderWhenEmpty="true">
                                                <EmptyDataTemplate>
                                                    <center><h1>NO DATA AVAILABLE</h1></center>
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblid" Text='<%# Eval("") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkEmpName" Text="Employee Name" runat="server" CommandName="Sort" CommandArgument="EmpName"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchEmpName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEmpName" Width="90px" Text='<%# Eval("") %>' runat="server"></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkLoan" Text='Loan Code' runat="server" CommandName="Sort" CommandArgument="LoanCode"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtLoan" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLoan" Text='<%# Eval("") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>

                                                            <asp:LinkButton ID="lnkLoanAmt" Text='Loan Amount' runat="server" CommandName="Sort" CommandArgument="LoanAmt"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtLoanAmt" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>

                                                        </HeaderTemplate>
                                                        <ItemTemplate>

                                                            <asp:Label ID="lblLoanAmt" Width="100px" Text='<%# Eval("") %>' runat="server"></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>



                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkAmtPd" Text='Amount Paid' runat="server" CommandName="Sort" CommandArgument="AmtPd"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtAmtPd" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAmtPd" Text='<%# Eval("") %>' runat="server"></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkBal" Text='Balance' runat="server" CommandName="Sort" CommandArgument="Bal"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtBal" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBal" Text='<%# Eval("") %>' runat="server"></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkDedAmt" Text='Deduction Amount' runat="server" CommandName="Sort" CommandArgument="DedAmt"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtDedAmt" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDedAmt" Text='<%# Eval("") %>' runat="server"></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lblControls" Width="75px" Text='' runat="server" CommandName="Sort" CommandArgument="Active"></asp:LinkButton><br />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <center>
                                                                <asp:LinkButton ID="btnView" runat="server" ForeColor="Black" Font-Size="" CommandName="view" CommandArgument='<%# Eval("id") %>'><i class="fa fa-eye"></i></asp:LinkButton> &nbsp;
                                                                <asp:LinkButton ID="btnUpdate" runat="server" ForeColor="Black" Font-Size="" CommandName="update" CommandArgument='<%# Eval("id") %>'><i class="fa fa-edit"></i></asp:LinkButton>&ensp;
                                                                <asp:LinkButton ID="btnDel" runat="server" ForeColor="Black" Font-Size=""  CommandName="del" CommandArgument='<%# Eval("id") %>'><i class="fa fa-trash"></i></asp:LinkButton>
                                                            </center>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>
                                                    <%--<asp:CommandField HeaderText="Cancel Item" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-xs btn-danger"  /> --%>
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
                                <!-- Modal Content -->

                                <div class="col-lg-6">
                                    <label for="upd_DateFiled" class="required">Date Filed<span class="required"></span></label>
                                    <input class="form-control datetimepicker" id="upd_DateFiled" name="txtUpdEffectiveDate" type="text" maxlength="11" runat="server" />

                                    <label for="upd_StartDeduction" class="required">Start of Deduction<span class="required"></span></label>
                                    <input class="form-control datetimepicker" id="upd_StartDeduction" name="txtUpdEffectiveDate" type="text" maxlength="11" runat="server" />

                                    <label for="upd_LoanCode" class="required">Loan Type<span class="required">*<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="upd_LoanCode" ValidationGroup="UpdLoansGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                    <select class="form-control" name="textUpdBranchCode" id="upd_LoanCode" runat="server">
                                        <option value="">---Select Loan Type---</option>
                                    </select>

                                    <label for="upd_LoanGranted" class="required">Loan Granted<span class="required"></span></label>
                                    <input class="form-control" id="upd_LoanGranted" name="txtRemarks" type="text" runat="server" />

                                    <label for="upd_LoanAmount" class="required">Loan Amount<span class="required"></span></label>
                                    <input class="form-control" id="upd_LoanAmount" name="txtRemarks" type="text" runat="server" />

                                </div>

                                <div class="col-lg-6">
                                    <label for="upd_DeductionAmount" class="required">Deduction Amount<span class="required"></span></label>
                                    <input class="form-control" id="upd_DeductionAmount" name="txtRemarks" type="text" runat="server" />

                                    <label for="upd_AmountPaid" class="required">Amount Paid<span class="required"></span></label>
                                    <input class="form-control" id="upd_AmountPaid" name="txtRemarks" type="text" runat="server" />

                                    <label for="upd_Balance" class="required">Balance<span class="required"></span></label>
                                    <div class="input-group date">
                                        <input class="form-control" id="upd_Balance" name="txtRemarks" type="text" runat="server" />
                                        <br />
                                        <asp:CheckBox ID="upd_GroupCode" runat="server" CssClass="checkbox-inline" Text="For Deduction"></asp:CheckBox>&ensp;
                            <asp:CheckBox ID="upd_Active" runat="server" CssClass="checkbox-inline" Text="Active"></asp:CheckBox>

                                    </div>

                                </div>


                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Update" CssClass="btn btn-primary"
                                OnClick="btnsaveUpdate_Click" OnClientClick="Confirm()" ValidationGroup="UpdLoansGroup"></asp:Button>


                        </div>


                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnsaveUpdate" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>
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
                                    <label class="control-label required">Date Filed</label>
                                    <input class="form-control" id="vw_DateFiled" type="text" runat="server" disabled="disabled" />

                                    <label class="control-label required">Loan Code</label>
                                    <input class="form-control" id="vw_LoanCode" type="text" runat="server" disabled="disabled" />

                                    <label class="control-label required">Loan Granted</label>
                                    <input class="form-control" id="vw_LoanGrant" type="text" runat="server" disabled="disabled" />

                                    <label class="control-label required">Loan Amount</label>
                                    <input class="form-control" id="vw_LoanAmt" type="text" runat="server" disabled="disabled" />

                                    <label class="control-label required">Deduction Amt</label>
                                    <input class="form-control" id="vw_DedAmt" type="text" runat="server" disabled="disabled" />
                                </div>
                                <div class="col-lg-6">
                                    <label class="control-label required">Start of Deduction</label>
                                    <input class="form-control" id="vw_StartDed" type="text" runat="server" disabled="disabled" />

                                    <label class="control-label required">Amount Paid</label>
                                    <input class="form-control" id="vw_AmtPd" type="text" runat="server" disabled="disabled" />

                                    <label class="control-label required">Balance</label>
                                    <input class="form-control" id="vw_Bal" type="text" runat="server" disabled="disabled" />

                                    <label class="control-label required">For Deduction</label>
                                    <input class="form-control" id="vw_ForDed" type="text" runat="server" disabled="disabled" />

                                    <label class="control-label required">Active</label>
                                    <input class="form-control" id="vw_Active" type="text" runat="server" disabled="disabled" />
                                </div>
                            </div>
                            <div class="row">
                                <div id="vw-grid" class="grid-view box-body">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                        ShowFooter="True" CssClass="table table-bordered table-striped table-responsive p-0 dataTable"
                                        GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                        ForeColor="Black" OnRowCommand="GridUserList_RowCommand"
                                        OnPageIndexChanging="GridUserList_PageIndexChanging"
                                        ViewStateMode="Enabled" PageSize="25" ShowHeader="true" ShowHeaderWhenEmpty="true">
                                        <EmptyDataTemplate>
                                            <center><h1>NO DATA AVAILABLE</h1></center>
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblid" Text='<%# Eval("") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkvwCoDate" Text="Codate" runat="server" CommandName="Sort" CommandArgument="Codate"></asp:LinkButton><br />
                                                    <asp:TextBox ID="txtvwCoDate" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>

                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblvwCoDate" Width="90px" Text='<%# Eval("") %>' runat="server"></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkvwAmt" Text='Loan Code' runat="server" CommandName="Sort" CommandArgument="LoanCode"></asp:LinkButton><br />
                                                    <asp:TextBox ID="txtvwAmt" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblvwAmt" Text='<%# Eval("") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                    </asp:GridView>
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
