﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="viewmovement.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees._201.viewmovement" %>

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
                <h3 class="m-0 text-dark"><%=getname() %><small> Movement</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/CreateEmployee.aspx")%>" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/EmployeeMaster.aspx")%>" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/EmployeeView.aspx?empid="+empno+"")%>" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Employee View</span></a>
                    </div>
                    <div class="card-body"> 
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
                                            <center><h1>NO MOVEMENT ENTRIES</h1></center>
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>



                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkMovementTypeCode" CssClass="h8" Text='Movement Type Code' runat="server" CommandName="Sort" CommandArgument="MovementTypeName"></asp:LinkButton><br />
                                                    <asp:TextBox ID="txtMovementTypeCode" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMType" CssClass="" Text='<%# Eval("MovementTypeName") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkBranchCode" CssClass="h8" Text='Assignment' runat="server" CommandName="Sort" CommandArgument="CoName"></asp:LinkButton><br />
                                                    <asp:TextBox ID="txtBranchCode" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCoName" CssClass="" Text='<%# Eval("CoName") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkPositionCode" CssClass="h8" Text='Position' runat="server" CommandName="Sort" CommandArgument="PositionName"></asp:LinkButton><br />
                                                    <asp:TextBox ID="txtPositionCode" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPos" CssClass="" Text='<%# Eval("PositionName") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkEffectiveDate" CssClass="h8" Text='Effective Date' runat="server" CommandName="Sort" CommandArgument="EffectiveDate"></asp:LinkButton><br />
                                                    <asp:TextBox ID="txtEffectiveDate" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEffectDate" CssClass="" Text='<%# Eval("EffectiveDate") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkRemarks" CssClass="h8" Text='Remarks' runat="server" CommandName="Sort" CommandArgument="Remarks"></asp:LinkButton><br />
                                                    <asp:TextBox ID="txtRemarks" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemarks" CssClass="" Text='<%# Eval("Remarks") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-Width="10%">

                                                <ItemTemplate>
                                                    <center>
                                                        <%--<asp:Button ID="btnView" CssClass="btn-success btn-xs" runat="server" Text="View"  CommandName="view" CommandArgument='<%# Eval("id") %>' />
                                                        <asp:Button ID="btnUpdate" CssClass="btn-success btn-xs" runat="server" Text="Update"   CommandName="upd" CommandArgument='<%# Eval("id") %>'  />
                                                        <asp:Button ID="btnDelete" CssClass="btn-danger btn-xs" runat="server" Text="Delete" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;"  CommandName="del" CommandArgument='<%# Eval("id") %>'  />--%>
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

                            <legend>
                                <p class="note">Fields with <span class="required text-red">**</span> are required.</p>
                            </legend>
                            <%--   <div class="container showgrid">--%>
                            
                                <div class="row">
                                    <div class="col-lg-6">


                                        <label for="Movement_MovementTypeCode" class="required">Movement Type Code <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Movement_MovementTypeCode" ValidationGroup="MovementGroup" ForeColor="Red" ErrorMessage="Field Required" InitialValue="0"></asp:RequiredFieldValidator></span></label>
                                        <asp:DropDownList class="form-control" ID="Movement_MovementTypeCode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="MovementType_SelectedIndexChanged">
                                            <asp:ListItem Text="---Select Movement---" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                        <%-- <select class="form-control" name="Movement[MovementTypeCode]" id="Movement_MovementTypeCode" runat = "server">
    
        <option value="">---Select Movement---</option>
        <%--<option value="1">PROMOTION</option>
        <option value="2">RESIGNED</option>--%>
                                        <%-- </select>--%>

                                        <label for="Movement_BranchCode" class="required">Assignment <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="Movement_BranchCode" ValidationGroup="MovementGroup" ForeColor="Red" ErrorMessage="Field Required" InitialValue="0"></asp:RequiredFieldValidator></span></label>
                                        <select class="form-control" name="Movement[BranchCode]" id="Movement_BranchCode" runat="server">
                                            <option value="">---Select Client---</option>
                                            <%--<option value="1">Dataland Inc.</option>--%>
                                        </select>

                                        <label for="Movement_DivisionCode" class="required">Division Code <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="Movement_DivisionCode" ValidationGroup="MovementGroup" ForeColor="Red" ErrorMessage="Field Required" InitialValue="0"></asp:RequiredFieldValidator></span></label>
                                        <select class="form-control" name="Movement[DivisionCode]" id="Movement_DivisionCode" runat="server">
                                            <option value="">---Select Division---</option>
                                        </select>

                                        <label for="Movement_DeptCode" class="required">Department Code <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="Movement_DeptCode" ValidationGroup="MovementGroup" ForeColor="Red" ErrorMessage="Field Required" InitialValue="0"></asp:RequiredFieldValidator></span></label>
                                        <select class="form-control" name="Movement[DeptCode]" id="Movement_DeptCode" runat="server">
                                            <option value="0">---Select Department---</option>
                                        </select>

                                        <label for="Movement_PositionCode" class="required">Position <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Movement_PositionCode" ValidationGroup="MovementGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                        <select class="form-control" name="Movement[PositionCode]" id="Movement_PositionCode" runat="server">
                                            <option value="">---Select Position---</option>
                                        </select>


                                        <label for="Movement_GroupCode" class="required">Location <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="Movement_GroupCode" ValidationGroup="MovementGroup" ForeColor="Red" ErrorMessage="Field Required" InitialValue="0"></asp:RequiredFieldValidator></span></label>
                                        <select class="form-control" name="Movement[GroupCode]" id="Movement_GroupCode" runat="server">
                                            <option value="">---Select Location---</option>
                                            <%--<option value="1">CEBU</option>
        <option value="2">MANDAUE</option>--%>
                                        </select>





                                    </div>
                                    <div class="col-lg-6">
                                        <%--<label for="Movement_EffectiveDate" class="required">Effective Date <span class="required text-red">**</span></label>		
    <input style="height:20px;" class="form-control" id="EffectiveDate" runat = "server" name="Movement[EffectiveDate]" type="text" />--%>
                                        <label for="EffectiveDate" class="required">
                                            Effective Date <span class="required text-red">**
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEffectiveDate" ValidationGroup="MovementGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                        <input class="form-control" id="txtEffectiveDate" name="Movement_EffectiveDate" type="date" maxlength="11" runat="server" />



                                        <label for="Movement_Remarks" class="required">
                                            Reason<span class="required">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="Movement_Remarks" ValidationGroup="MovementGroup" ForeColor="Red" ErrorMessage="Field Required" Enabled="false"></asp:RequiredFieldValidator></span></label><input class="form-control" maxlength="100" name="Movement[Remarks]" id="Movement_Remarks" runat="server" type="text" />

                                        <label for="Movement_PayClassCode" class="required">Pay Class Code <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="Movement_PayClassCode" ValidationGroup="MovementGroup" ForeColor="Red" ErrorMessage="Field Required" InitialValue="0"></asp:RequiredFieldValidator></span></label>
                                        <select class="form-control" name="Movement[PayClassCode]" id="Movement_PayClassCode" runat="server">
                                            <option value="">---Select Pay Class---</option>
                                            <%--<option value="1">1</option>
        <option value="2">2</option>--%>
                                        </select>

                                        <label for="Movement_WageType" class="required">Wage Type</label>
                                        <select class="form-control" name="Movement[WageType]" id="Movement_WageType" runat="server">
                                            <option value="">---Select Wage Type---</option>
                                            <option value="M">Monthly</option>
                                            <option value="D">Daily</option>

                                        </select>

                                    </div>
                                </div>
                                <%--</div>--%>

                                <div class="form-actions" style="padding-top: 10px;">
                                    <asp:Button ID="btnCreate" class="btn btn-primary" runat="server" Text="Create" Width="80"
                                        OnClick="btnCreate_Click" OnClientClick="Confirm()" ValidationGroup="MovementGroup"></asp:Button>
                                    <asp:Button ID="btnReset" class="btn btn-danger" Width="80" runat="server" Text="Reset"
                                        OnClick="btnReset_Click"></asp:Button>
                                </div>
                        </div>
                        </div>
                </section>
            </div>
        </div>
    </div>

    <!-- UPDATE MODAL -->
    <div class="modal fade" id="listmodal" role="dialog">
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
                                <!-- Modal Content -->

                                <div class="col-lg-6">
                                    <label for="upd_MovementTypeCode" class="required">MovementTypeCode<span class="required">*<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="upd_MovementTypeCode" ValidationGroup="UpdMovementGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                    <select class="form-control" name="textUpdMovementTypeCode" id="upd_MovementTypeCode" runat="server">
                                        <option value="">---Select Movement---</option>
                                    </select>

                                    <label for="upd_EffectiveDate" class="required">
                                        Effective Date<span class="required">*
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="upd_EffectiveDate" ValidationGroup="UpdMovementGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                    <input class="form-control datetimepicker" id="upd_EffectiveDate" name="txtUpdEffectiveDate" type="text" maxlength="11" runat="server" />

                                    <label for="upd_BranchCode" class="required">Assignment<span class="required">*<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="upd_EffectiveDate" ValidationGroup="UpdMovementGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                    <select class="form-control" name="textUpdBranchCode" id="upd_BranchCode" runat="server">
                                        <option value="">---Select Assignment---</option>
                                        <%--<option value="1">PROMOTION</option>
                                <option value="2">RESIGNED</option>--%>
                                    </select>

                                    <label for="upd_Remarks" class="required">Reason<span class="required"></span></label>
                                    <input class="form-control" id="upd_Remarks" name="txtRemarks" type="text" runat="server" />

                                    <label for="upd_DeptCode" class="required">Dept Code<span class="required"></span></label>
                                    <select class="form-control" name="textUpdDeptCode" id="upd_DeptCode" runat="server">
                                        <option value="">---Select Department---</option>
                                        <%--<option value="1">PROMOTION</option>
                                <option value="2">RESIGNED</option>--%>
                                    </select>
                                </div>
                                <div class="col-lg-6">
                                    <label for="upd_PositionCode" class="required">Position<span class="required">*<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="upd_PositionCode" ValidationGroup="UpdMovementGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                    <select class="form-control" name="textUpdPositionCode" id="upd_PositionCode" runat="server">
                                        <option value="">---Select Position---</option>
                                        <%--<option value="1">PROMOTION</option>
                                <option value="2">RESIGNED</option>--%>
                                    </select>

                                    <label for="upd_PayClassCode" class="required">PayClassCode</label>
                                    <select class="form-control" name="textUpdBranchCode" id="upd_PayClassCode" runat="server">
                                        <option value="">---Select Pay Class---</option>
                                        <%--<option value="1">PROMOTION</option>
                                <option value="2">RESIGNED</option>--%>
                                    </select>

                                    <label for="upd_WageType" class="required">Wage Type<span class="required"></span></label>
                                    <select class="form-control" name="textUpdWageType" id="upd_WageType" runat="server">
                                        <option value="">---Select Wage Type---</option>
                                        <option value="M">Monthly</option>
                                        <option value="D">Daily</option>
                                    </select>

                                    <label for="upd_GroupCode" class="required">Location<span class="required"></span></label>
                                    <select class="form-control" name="textUpdGroupCode" id="upd_GroupCode" runat="server">
                                        <option value="">---Select Location---</option>
                                        <%--<option value="1">PROMOTION</option>
                                <option value="2">RESIGNED</option>--%>
                                    </select>

                                    <label for="upd_DivisionCode" class="required">Division Code<span class="required">*</span></label>
                                    <select class="form-control" name="textUpdDivisionCode" id="upd_DivisionCode" runat="server">
                                        <option value="0">---Select Division---</option>
                                        <%--<option value="1">PROMOTION</option>
                                <option value="2">RESIGNED</option>--%>
                                    </select>

                                </div>

                            </div>


                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Update" CssClass="btn btn-primary"
                                OnClick="btnsaveUpdate_Click" OnClientClick="Confirm1()" ValidationGroup="UpdMovementGroup"></asp:Button>


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
    </div>
    <!--VIEW MODAL-->
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
                                    <label for="view_MovementTypeCode" class="required">Movement Type Code</label>
                                    <input class="form-control" id="lblMovementTypeCode" name="txtMovementTypeCode" type="text" runat="server" disabled="true" />
                                    <label for="view_EffectiveDate" class="required">Effective Date</label>
                                    <input class="form-control datetimepicker" id="view_EffectiveDate" name="txtUpdEffectiveDate" type="text" maxlength="11" runat="server" disabled="true" />
                                    <label for="lblBranchCode" class="required">Assignment</label>
                                    <input class="form-control" id="lblBranchCode" name="txtBranchCode" type="text" runat="server" disabled="true" />
                                    <label for="lblRemarks" class="required">Reason</label>
                                    <input class="form-control" id="lblRemarks" name="txtRemarks" type="text" runat="server" disabled="true" />
                                    <label for="view_DeptCode" class="required">Department Code</label>
                                    <input class="form-control" id="lblDeptCode" name="txtDeptCode" type="text" runat="server" disabled="true" />

                                </div>
                                <div class="col-lg-6">
                                    <label for="lblPositionCode" class="required">Position</label>
                                    <input class="form-control" id="lblPositionCode" name="txtPositionCode" type="text" runat="server" disabled="true" />
                                    <label for="lblPayClass" class="required">Pay Class Code</label>
                                    <input class="form-control" id="lblPayClass" name="txtPayClass" type="text" runat="server" disabled="true" />
                                    <label for="lblWageType" class="required">Wage Type</label>
                                    <input class="form-control" id="lblWageType" name="txtWageType" type="text" runat="server" disabled="true" />
                                    <label for="lblGroupCode" class="required">Location</label>
                                    <input class="form-control" id="lblGroupCode" name="txtGroupCode" type="text" runat="server" disabled="true" />
                                    <label for="lblDivisionCode" class="required">Division Code</label>
                                    <input class="form-control" id="lblDivisionCode" name="txtDivisionCode" type="text" runat="server" disabled="true" />

                                </div>

                            </div>


                        </div>
                        <div class="modal-footer">
                            <%--<asp:Button ID="Button1" runat="server" Text="Update" 
                            onclick="btnsaveUpdate_Click" OnClientClick="Confirm()" validationgroup = "UpdMovementGroup"></asp:Button>--%>
                        </div>


                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnsaveUpdate" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>
    <style>
        * {
            box-sizing: border-box;
        }

        .row {
            display: flex;
        }

        /* Create two equal columns that sits next to each other */
        .column {
            flex: 50%;
            padding: 10px;
        }
    </style>
</asp:Content>
