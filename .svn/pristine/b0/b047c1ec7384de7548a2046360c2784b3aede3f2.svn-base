<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="payregadjcom.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.PayrollPages.payregadjcom" %>

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
                <h3 class="m-0 text-dark">Payroll Adjustment<small> Compensations</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="createpayregadjcom.aspx" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                        <a href="#" class="btn btn-default"><i class="fa fa-th-list"></i><span class="h6">List</span></a>
                        <a runat="server" class="btn btn-default" onserverclick="ExportToPDF"><i class="fa fa-arrow-circle-o-up"></i><span class="h6">Export to PDF</span></a>
                        <a runat="server" class="btn btn-default" onserverclick="btnExport_Click"><i class="fa fa-arrow-circle-o-up"></i><span class="h6">Export to Excel</span></a>
                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="box-body">
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
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkID" Text="Cut Off Date" runat="server" CommandName="Sort" CommandArgument="CODate"></asp:LinkButton><br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" Width="200px" Text='<%# Eval("") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkCODate" Text="Cut Off Date" runat="server" CommandName="Sort" CommandArgument="CODate"></asp:LinkButton><br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCODate" Width="200px" Text='<%# Eval("") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lblEmpName" Text="Employee Name" runat="server" CommandName="Sort" CommandArgument="EmpName"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtSearchEmpName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>

                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmpName" Width="90px" Text='<%# Eval("") %>' runat="server"></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkComp" Text='Gross Pay' runat="server" CommandName="Sort" CommandArgument="Comp"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtComp" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblComp" Text='<%# Eval("") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkAmt" Text='Amount' runat="server" CommandName="Sort" CommandArgument="Amt"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtAmt" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAmt" Width="100px" Text='<%# Eval("") %>' runat="server"></asp:Label>
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
                                                            <asp:LinkButton ID="btnDelete" runat="server" ForeColor="Black" Font-Size=""  CommandName="del" CommandArgument='<%# Eval("id") %>'><i class="fa fa-trash"></i></asp:LinkButton>
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
                                    <label for="upd_CoDate" class="required">
                                        Cut Off Date<span class="required">*
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="upd_CoDate"
                                            ValidationGroup="updAdj" ForeColor="Red" ErrorMessage="Field Required">
                                        </asp:RequiredFieldValidator></span></label>
                                    <select class="form-control" id="upd_CoDate" runat="server">
                                        <option value="">---Select Cut Off---</option>
                                    </select>
                                    <label for="upd_EmpName" class="required">
                                        Employee Name<span class="required">*
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="upd_EmpName"
                                            ValidationGroup="updAdj" ForeColor="Red" ErrorMessage="Field Required">
                                        </asp:RequiredFieldValidator></span></label>
                                    <select class="form-control" id="upd_EmpName" runat="server">
                                        <option value="">---Select Employee---</option>
                                    </select>


                                </div>

                                <div class="col-lg-6">
                                    <label for="upd_EmpName" class="required">Compensation</label>
                                    <select class="form-control" id="upd_CompCode" runat="server">
                                        <option value="">---Select Compensation Code---</option>
                                    </select>

                                    <label class="control-label required">Amount</label>
                                    <input class="form-control" id="upd_Amount" type="text" runat="server" />
                                </div>

                            </div>


                        </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Update" CssClass="btn btn-primary"
                                OnClick="btnsaveUpdate_Click" OnClientClick="Confirm()" ValidationGroup="updAdj"></asp:Button>


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
                                    <label class="control-label required">ID</label>
                                    <input class="form-control" id="vw_ID" type="text" runat="server" disabled="disabled" />

                                    <label class="control-label required">Cut Off Date</label>
                                    <input class="form-control" id="vw_CoDate" type="text" runat="server" disabled="disabled" />

                                    <label class="control-label required">Payroll Group</label>
                                    <input class="form-control" id="vw_PayGrp" type="text" runat="server" disabled="disabled" />
                                </div>
                                <div class="col-lg-6">
                                    <label class="control-label required">Employee Name</label>
                                    <input class="form-control" id="vw_EmpName" type="text" runat="server" disabled="disabled" />

                                    <label class="control-label required">Compensation</label>
                                    <input class="form-control" id="vw_Comp" type="text" runat="server" disabled="disabled" />

                                    <label class="control-label required">Amount</label>
                                    <input class="form-control" id="vw_Amt" type="text" runat="server" disabled="disabled" />
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
