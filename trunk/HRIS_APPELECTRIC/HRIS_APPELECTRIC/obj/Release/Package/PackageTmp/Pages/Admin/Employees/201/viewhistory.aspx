<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="viewhistory.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees._201.viewhistory" %>

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
                <h3 class="m-0 text-dark"><%=getname() %><small> Employment History</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/CreateEmployee.aspx")%>" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/EmployeeMaster.aspx")%>" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/EmployeeView.aspx?empid="+empno+"")%>" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Employee View</span></a>

                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="box-body">

                                    <div class='printableArea'>
                                        <div id="display-grid" class="grid-view">
                                            <div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>
                                            <asp:GridView ID="GridViewList" runat="server" AutoGenerateColumns="False"
                                                ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                ForeColor="Black" OnRowCommand="GridViewList_RowCommand"
                                                OnPageIndexChanging="GridViewList_PageIndexChanging"
                                                ViewStateMode="Enabled" ShowHeaderWhenEmpty="true">
                                                <EmptyDataTemplate>
                                                    <center><h1>NO EMPLOYMENT HISTORY AVAILABLE</h1></center>
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkFromDate" CssClass="" Text='From Date' runat="server" CommandName="Sort" CommandArgument="FromDate"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtFromDate" runat="server" OnTextChanged="txtFromDate_TextChanged" Width="100%"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFromDate" CssClass="" Text='<%# Eval("From_Date") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkToDate" CssClass="" Text='To Date' runat="server" CommandName="Sort" CommandArgument="ToDate"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtToDate" runat="server" OnTextChanged="txtFromDate_TextChanged" Width="100%"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblToDate" CssClass="" Text='<%# Eval("To_Date") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkCompany" CssClass="" Text='Company' runat="server" CommandName="Sort" CommandArgument="Company"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtCompany" runat="server" OnTextChanged="txtFromDate_TextChanged" Width="100%"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCompany" CssClass="" Text='<%# Eval("Company") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkPosition" CssClass="" Text='Position' runat="server" CommandName="Sort" CommandArgument="Position"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtPosition" runat="server" OnTextChanged="txtFromDate_TextChanged" Width="100%"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPosition" CssClass="" Text='<%# Eval("Position") %>' runat="server"></asp:Label>
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



                                        <fieldset>
                                            <legend>
                                                <p class="note">Fields with <span class="required text-red">**</span> are required.</p>
                                            </legend>

                                            <div class="alert alert-error span12" id="ehistory-form_es_" style="display: none">
                                                Opps!!!
                                <ul>
                                    <li>dummy</li>
                                </ul>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <label for="From_Date" class="required">From Date <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtFrom_Date" ForeColor="Red" runat="server" ErrorMessage="Field Required" ValidationGroup="historygroup"></asp:RequiredFieldValidator></span></label>
                                                    <input class="form-control" id="txtFrom_Date" name="Ehistory[From_Date]" type="date" runat="server" />
                                                    <label for="To_Date" class="required">To Date <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtTo_Date" ForeColor="Red" runat="server" ErrorMessage="Field Required" ValidationGroup="historygroup"></asp:RequiredFieldValidator></span></label>
                                                    <input class="form-control" id="txtTo_Date" name="Ehistory[To_Date]" type="date" runat="server" />

                                                    <label for="Company" class="required">Company <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Company" ForeColor="Red" runat="server" ErrorMessage="Field Required" ValidationGroup="historygroup"></asp:RequiredFieldValidator></span></label>
                                                    <input class="form-control" maxlength="50" name="Ehistory[Company]" id="Company" type="text" runat="server" /><span class="help-inline" id="Ehistory_Company_em_" style="display: none"></span>
                                                    <label for="Position" class="required">Position <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="Position" ForeColor="Red" runat="server" ErrorMessage="Field Required" ValidationGroup="historygroup"></asp:RequiredFieldValidator></span></label>
                                                    <input class="form-control" maxlength="50" name="Ehistory[Position]" id="Position" type="text" runat="server" /><span class="help-inline" id="Ehistory_Position_em_" style="display: none"></span>
                                                    <label for="DNR" class="required">Duties and Responsibilities</label>
                                                    <textarea class="form-control" maxlength="250" name="Ehistory[DNR]" id="DNR" runat="server"></textarea><span class="help-inline" id="Ehistory_DNR_em_" style="display: none"></span>
                                                    <label for="RFLeaving" class="required">Reason for Leaving</label>
                                                    <input class="form-control" maxlength="100" name="Ehistory[RFLeaving]" id="RFLeaving" type="text" runat="server" /><span class="help-inline" id="Ehistory_RFLeaving_em_" style="display: none"></span>

                                                    <span class="required text-red">*
                                                        <asp:CheckBox ID="Previous" runat="server" Text="Previous Employer?" CssClass="checkbox-inline" /></span>
                                                </div>
                                                <div class="col-lg-6">
                                                    <label for="HYear" class="required">Year</label>
                                                    <input class="form-control" maxlength="50" name="Ehistory[Year]" id="HYear" type="text" runat="server" value="0" />
                                                    <span class="help-inline" id="Ehistory_Year_em_" style="display: none"></span>
                                                    <label for="NThirteenth" class="required">NT 13th Month Pay</label>
                                                    <input class="form-control" maxlength="50" name="Ehistory[NThirteenth]" id="NThirteenth" type="text" runat="server" value="0" />
                                                    <span class="help-inline" id="Ehistory_NThirteenth_em_" style="display: none"></span>
                                                    <label for="Deminimis" class="required">Deminimis</label>
                                                    <input class="form-control" maxlength="50" name="Ehistory[Deminimis]" id="Deminimis" type="text" runat="server" value="0" /><span class="help-inline" id="Ehistory_Deminimis_em_" style="display: none"></span>
                                                    <label for="Contributions" class="required">Contributions</label>
                                                    <input class="form-control" maxlength="50" name="Ehistory[Contributions]" id="Contributions" type="text" runat="server" value="0" />
                                                    <span class="help-inline" id="Ehistory_Contributions_em_" style="display: none"></span>
                                                    <label for="NCompensations" class="required">NT Compensations</label>
                                                    <input class="form-control" maxlength="50" name="Ehistory[NCompensations]" id="NCompensations" type="text" runat="server" value="0" />
                                                    <span class="help-inline" id="Ehistory_NCompensations_em_" style="display: none"></span>
                                                    <label for="Basic" class="required">Basic Pay</label>
                                                    <input class="form-control" maxlength="50" name="Ehistory[Basic]" id="Basic" type="text" runat="server" value="0" />
                                                    <span class="help-inline" id="Ehistory_Basic_em_" style="display: none"></span>
                                                    <label for="TThirteenth" class="required">Taxable 13th Month Pay</label>
                                                    <input class="form-control" maxlength="50" name="Ehistory[TThirteenth]" id="TThirteenth" type="text" runat="server" value="0" />
                                                    <span class="help-inline" id="Ehistory_TThirteenth_em_" style="display: none"></span>
                                                    <label for="TCompensations" class="required">Taxable Compensations</label>
                                                    <input class="form-control" maxlength="50" name="Ehistory[TCompensations]" id="TCompensations" type="text" runat="server" value="0" />
                                                    <span class="help-inline" id="Ehistory_TCompensations_em_" style="display: none"></span>
                                                    <asp:HiddenField ID="hdnfieldID" runat="server"></asp:HiddenField>
                                                </div>
                                            </div>

                                            <div class="form-actions">
                                                <asp:Button ID="btnCreate" Width="80" class="btn btn-primary" runat="server" Text="Create"
                                                    OnClick="btnCreate_Click" OnClientClick="Confirm()" CausesValidation="true" ValidationGroup="historygroup"></asp:Button>
                                                <asp:Button ID="btnReset" Width="80" class="btn btn-danger" runat="server" Text="Reset"
                                                    OnClick="btnReset_Click"></asp:Button>
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
    <!-- Modal -->
    <div class="modal fade" id="listmodal">
        <div class="modal-dialog">
            <div class="modal-content">

                <asp:UpdatePanel ID="upEmpHistory" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
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
                                    <label for="upd_FromDate" class="required">From Date <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="upd_FromDate" ForeColor="Red" runat="server" ErrorMessage="Field Required" ValidationGroup="historygroup1"></asp:RequiredFieldValidator></span></label>
                                    <input class="form-control datetimepicker" id="upd_FromDate" name="Ehistory[From_Date]" type="text" runat="server" />
                                    <label for="upd_ToDate" class="required">To Date <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="upd_ToDate" ForeColor="Red" runat="server" ErrorMessage="Field Required" ValidationGroup="historygroup1"></asp:RequiredFieldValidator></span></label>
                                    <input class="form-control datetimepicker" id="upd_ToDate" name="Ehistory[To_Date]" type="text" runat="server" />
                                    <label for="upd_Company" class="required">Company <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="upd_Company" ForeColor="Red" runat="server" ErrorMessage="Field Required" ValidationGroup="historygroup1"></asp:RequiredFieldValidator></span></label>
                                    <input class="form-control" maxlength="50" name="Ehistory[Company]" id="upd_Company" type="text" runat="server" /><span class="help-inline" id="Span1" style="display: none"></span>
                                    <label for="upd_Position" class="required">Position <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="upd_Position" ForeColor="Red" runat="server" ErrorMessage="Field Required" ValidationGroup="historygroup1"></asp:RequiredFieldValidator></span></label>
                                    <input class="form-control" maxlength="50" name="Ehistory[Position]" id="upd_Position" type="text" runat="server" /><span class="help-inline" id="Span2" style="display: none"></span>
                                    <label for="upd_DNR" class="required">Duties and Responsibilities</label>
                                    <textarea class="form-control" maxlength="250" name="Ehistory[DNR]" id="upd_DNR" runat="server"></textarea><span class="help-inline" id="Span3" style="display: none"></span>
                                    <label for="upd_RFLeaving" class="required">Reason for Leaving</label>
                                    <input class="form-control" maxlength="100" name="Ehistory[RFLeaving]" id="upd_RFLeaving" type="text" runat="server" /><span class="help-inline" id="Span4" style="display: none"></span>
                                    <br />
                                    <span class="required text-red">*
                                        <asp:CheckBox ID="upd_Previous" runat="server" Text="Previous Employer?" CssClass="checkbox-inline" /></span>
                                </div>
                                <div class="col-lg-6">
                                    <label for="upd_HYear" class="required">Year</label>
                                    <input class="form-control" maxlength="50" name="Ehistory[Year]" id="upd_HYear" type="text" runat="server" />
                                    <span class="help-inline" id="Span6" style="display: none"></span>
                                    <label for="upd_NThirteenth" class="required">NT 13th Month Pay</label>
                                    <input class="form-control" maxlength="50" name="Ehistory[NThirteenth]" id="upd_NThirteenth" type="text" runat="server" />
                                    <span class="help-inline" id="Span7" style="display: none"></span>
                                    <label for="upd_Deminimis" class="required">Deminimis</label>
                                    <input class="form-control" maxlength="50" name="Ehistory[Deminimis]" id="upd_Deminimis" type="text" runat="server" /><span class="help-inline" id="Span8" style="display: none"></span>
                                    <label for="upd_Contributions" class="required">Contributions</label>
                                    <input class="form-control" maxlength="50" name="Ehistory[Contributions]" id="upd_Contributions" type="text" runat="server" />
                                    <span class="help-inline" id="Span9" style="display: none"></span>
                                    <label for="upd_NCompensations" class="required">NT Compensations</label>
                                    <input class="form-control" maxlength="50" name="Ehistory[NCompensations]" id="upd_NCompensations" type="text" runat="server" />
                                    <span class="help-inline" id="Span10" style="display: none"></span>
                                    <label for="upd_Basic" class="required">Basic Pay</label>
                                    <input class="form-control" maxlength="50" name="Ehistory[Basic]" id="upd_Basic" type="text" runat="server" />
                                    <span class="help-inline" id="Span11" style="display: none"></span>
                                    <label for="upd_TThirteenth" class="required">Taxable 13th Month Pay</label>
                                    <input class="form-control" maxlength="50" name="Ehistory[TThirteenth]" id="upd_TThirteenth" type="text" runat="server" />
                                    <span class="help-inline" id="Span12" style="display: none"></span>
                                    <label for="upd_TCompensations" class="required">Taxable Compensations</label>
                                    <input class="form-control" maxlength="50" name="Ehistory[TCompensations]" id="upd_TCompensations" type="text" runat="server" />
                                    <span class="help-inline" id="Span13" style="display: none"></span>
                                </div>
                            </div>


                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Update" CssClass="btn btn-primary"
                                OnClick="btnUpdate_Click" OnClientClick="Confirm1()" ValidationGroup="historygroup1"></asp:Button>


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
                                    <label for="vw_FromDate" class="required">From Date</label>
                                    <input class="form-control datetimepicker" id="vw_FromDate" name="Ehistory[From_Date]" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_ToDate" class="required">To Date</label>
                                    <input class="form-control datetimepicker" id="vw_ToDate" name="Ehistory[To_Date]" type="text" runat="server" disabled="disabled" />

                                    <label for="vw_Company" class="required">Company</label>
                                    <input class="form-control" maxlength="50" name="Ehistory[Company]" id="vw_Company" type="text" runat="server" disabled="disabled" /><span class="help-inline" id="Span14" style="display: none"></span>
                                    <label for="vw_Position" class="required">Position</label>
                                    <input class="form-control" maxlength="50" name="Ehistory[Position]" id="vw_Position" type="text" runat="server" disabled="disabled" /><span class="help-inline" id="Span15" style="display: none"></span>
                                    <label for="vw_DNR" class="required">Duties and Responsibilities</label>
                                    <textarea class="form-control" maxlength="250" name="Ehistory[DNR]" id="vw_DNR" runat="server" disabled="disabled"></textarea><span class="help-inline" id="Span16" style="display: none"></span>
                                    <label for="vw_RFLeaving" class="required">Reason for Leaving</label>
                                    <input class="form-control" maxlength="100" name="Ehistory[RFLeaving]" id="vw_RFLeaving" type="text" runat="server" disabled="disabled" /><span class="help-inline" id="Span17" style="display: none"></span>
                                    <br />
                                    <span class="required text-red">*
                                        <asp:CheckBox ID="vw_Previous" runat="server" Text="Previous Employer?" CssClass="checkbox-inline" Enabled="false" /></span>
                                </div>
                                <div class="col-lg-6">
                                    <label for="vw_HYear" class="required">Year</label>
                                    <input class="form-control" maxlength="50" name="Ehistory[Year]" id="vw_HYear" type="text" runat="server" disabled="disabled" />
                                    <span class="help-inline" id="Span19" style="display: none"></span>
                                    <label for="vw_NThirteenth" class="required">NT 13th Month Pay</label>
                                    <input class="form-control" maxlength="50" name="Ehistory[NThirteenth]" id="vw_NThirteenth" type="text" runat="server" disabled="disabled" />
                                    <span class="help-inline" id="Span20" style="display: none"></span>
                                    <label for="vw_Deminimis" class="required">Deminimis</label>
                                    <input class="form-control" maxlength="50" name="Ehistory[Deminimis]" id="vw_Deminimis" type="text" runat="server" disabled="disabled" /><span class="help-inline" id="Span21" style="display: none"></span>
                                    <label for="vw_Contributions" class="required">Contributions</label>
                                    <input class="form-control" maxlength="50" name="Ehistory[Contributions]" id="vw_Contributions" type="text" runat="server" disabled="disabled" />
                                    <span class="help-inline" id="Span22" style="display: none"></span>
                                    <label for="vw_NCompensations" class="required">NT Compensations</label>
                                    <input class="form-control" maxlength="50" name="Ehistory[NCompensations]" id="vw_NCompensations" type="text" runat="server" disabled="disabled" />
                                    <span class="help-inline" id="Span23" style="display: none"></span>
                                    <label for="vw_Basic" class="required">Basic Pay</label>
                                    <input class="form-control" maxlength="50" name="Ehistory[Basic]" id="vw_Basic" type="text" runat="server" disabled="disabled" />
                                    <span class="help-inline" id="Span24" style="display: none"></span>
                                    <label for="vw_TThirteenth" class="required">Taxable 13th Month Pay</label>
                                    <input class="form-control" maxlength="50" name="Ehistory[TThirteenth]" id="vw_TThirteenth" type="text" runat="server" disabled="disabled" />
                                    <span class="help-inline" id="Span25" style="display: none"></span>
                                    <label for="vw_TCompensations" class="required">Taxable Compensations</label>
                                    <input class="form-control" maxlength="50" name="Ehistory[TCompensations]" id="vw_TCompensations" type="text" runat="server" disabled="disabled" />
                                    <span class="help-inline" id="Span26" style="display: none"></span>
                                </div>

                            </div>


                        </div>
                        <div class="modal-footer">
                        </div>


                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnsaveUpdate" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>
</asp:Content>
