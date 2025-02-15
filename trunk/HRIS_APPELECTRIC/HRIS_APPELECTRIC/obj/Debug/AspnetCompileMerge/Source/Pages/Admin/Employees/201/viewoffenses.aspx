﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="viewoffenses.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees._201.viewoffenses" %>

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
                <h3 class="m-0 text-dark"><%=getname() %><small> Offenses</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/EmployeeView.aspx?empid="+empno+"")%>" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Employee View</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/CreateEmployee.aspx")%>" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                        <a href="viewoffenses.aspx?id=<%=empno %>" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>                        
                        <a id="A3" runat="server" onserverclick="btnExport_Click" class="btn btn-default"><i class="fa fa-arrow-circle-o-up"></i><span class="h6">Export to Excel</span></a>
                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="box-body">
                                    <div class='printableArea'>
                                        <div id="list">
                                            <div id="display-grid" class="grid-view">
                                                <div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>
                                                <asp:gridview id="GridViewList" runat="server" autogeneratecolumns="False"
                                                    showfooter="True" cssclass="items table table-striped table-bordered table-condensed"
                                                    gridlines="None" allowpaging="True" font-names="Segoe UI" PageSize="10"
                                                    forecolor="Black" onrowcommand="GridViewList_RowCommand"
                                                    onpageindexchanging="GridViewList_PageIndexChanging"
                                                    viewstatemode="Enabled" showheaderwhenempty="true">
                                                    <EmptyDataTemplate>
                                                        <center><h1>NO OFFENSE AVAILABLE</h1></center>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkRecDate" CssClass="h8" Text='Incusive Dates' runat="server" CommandName="Sort" CommandArgument="RecDate"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchRecDate" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRecDate" CssClass="" Text='<%# Eval("RecDate") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--<asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkOffCode" CssClass="h8" Text='Offense' runat="server" CommandName="Sort" CommandArgument="OffCode"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchOffCode" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblOffCode" CssClass="" Text='<%# Eval("OffCode") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkOffNo" Text='Offense Level' runat="server" CommandName="Sort" CommandArgument="OffNo"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchOffNo" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblInspector" CssClass="" Text='<%# Eval("OffNo") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--<asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkDA" CssClass="h8" Text='Disciplinary Action' runat="server" CommandName="Sort" CommandArgument="DA"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchDA" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDA" CssClass="" Text='<%# Eval("DA") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkRemSuspDays" CssClass="h8" Text='Suspension Days' runat="server" CommandName="Sort" CommandArgument="RemSuspDays"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchRemSuspDays" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRemSuspDays" CssClass="" Text='<%# Eval("RemSuspDays") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>



                                                        <asp:TemplateField HeaderStyle-Width="15%">
                                                            <ItemTemplate>
                                                                <%-- <asp:Button ID="btnView" CssClass="btn-success btn-xs" runat="server" Text="View"  CommandName="view" CommandArgument='<%# Eval("id") %>'  />
                                                                            <asp:Button ID="btnUpdate" CssClass="btn-success btn-xs" runat="server" Text="Update" CommandName="upd" CommandArgument='<%# Eval("id") %>'  />
                                                                            <asp:Button ID="btnDelete" CssClass="btn-danger btn-xs" runat="server" Text="Delete" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;" CommandName="del" CommandArgument='<%# Eval("id") %>'  />--%>
                                                                <center>
                                                                    <asp:Button ID="btnSuspension" CssClass="btn-success btn-xs" runat="server" Text="Set Suspension" Width="100px"  CommandName="cmd_suspension" CommandArgument='<%# Eval("id") %>' OnClientClick="Confirm2()" Visible='<%# Eval("RemSuspDays").ToString() != "0" %>'  />&nbsp;
                                                                    <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Black" Font-Size="Large" CommandName="printPDF" CommandArgument='<%# Eval("id") %>'><i class="fa fa-arrow-down"></i></asp:LinkButton> &nbsp;
                                                                    <asp:LinkButton ID="btnView" runat="server" ForeColor="Black" Font-Size="Large" CommandName="view" CommandArgument='<%# Eval("id") %>'><i class="fa fa-eye"></i></asp:LinkButton> &nbsp;
                                                                    <asp:LinkButton ID="btnUpdate" runat="server" ForeColor="Black" Font-Size="Medium" CommandName="upd" CommandArgument='<%# Eval("id") %>'><i class="fa fa-edit"></i></asp:LinkButton>&ensp;
                                                                    <asp:LinkButton ID="btnDelete" runat="server" ForeColor="Black" Font-Size="Medium" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;"  CommandName="del" CommandArgument='<%# Eval("id") %>'><i class="fa fa-trash"></i></asp:LinkButton>
                                                                </center>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>


                                                    </Columns>
                                                </asp:gridview>

                                            </div>
                                            <div id="display-grid" class="grid-view">
                                                <div class="summary">Displaying <%=gridrangecount1%> of <%=gridtotalcount1%> results.</div>
                                                <asp:gridview id="GridViewListSuspension" runat="server" autogeneratecolumns="False"
                                                    showfooter="True" cssclass="items table table-striped table-bordered table-condensed"
                                                    gridlines="None" allowpaging="True" font-names="Segoe UI"
                                                    forecolor="Black" onrowcommand="GridViewListSuspension_RowCommand"
                                                    onpageindexchanging="GridViewListSuspension_PageIndexChanging"
                                                    viewstatemode="Enabled" showheaderwhenempty="true">
                                                    <EmptyDataTemplate>
                                                        <center><h1>NO SUSPENSION AVAILABLE</h1></center>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkrenderedDtFrom" CssClass="h8" Text='Date From' runat="server" CommandName="Sort" CommandArgument="renderedDtFrom"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchrenderedDtFrom" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblrenderedDtFrom" CssClass="" Text='<%# Eval("renderedDtFrom") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkrenderedDtTo" CssClass="h8" Text='Date To' runat="server" CommandName="Sort" CommandArgument="renderedDtTo"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchrenderedDtTo" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblrenderedDtTo" CssClass="" Text='<%# Eval("renderedDtTo") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkspdDays" CssClass="h8" Text='Suspension Days' runat="server" CommandName="Sort" CommandArgument="spdDays"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchspdDays" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblspdDays" CssClass="" Text='<%# Eval("spdDays") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        



                                                        <asp:TemplateField HeaderStyle-Width="15%">
                                                            <ItemTemplate>
                                                                
                                                                <center>
                                                                    
                                                                    <asp:LinkButton ID="btnDelete" runat="server" ForeColor="Black" Font-Size="Medium" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;"  CommandName="del" CommandArgument='<%# Eval("id")+","+Eval("offenseid") %>'><i class="fa fa-trash"></i></asp:LinkButton>
                                                                </center>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>


                                                    </Columns>
                                                </asp:gridview>

                                            </div>



                                            <div class="form">

                                                <legend>
                                                    <p class="note">Fields with <span class="required text-red">*</span> are required.</p>
                                                </legend>



                                                <div class="showgrid">
                                                    <div class="row">
                                                        <div class="col-lg-6">


                                                            <label for="RecDate" class="required">
                                                                Date Issued <span class="required text-red">*
                                                                        <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" errormessage="Field Required" forecolor="Red" controltovalidate="txtRecDate" validationgroup="offensesgroup"></asp:requiredfieldvalidator>
                                                                </span>
                                                            </label>
                                                            <input class="form-control" id="txtRecDate" name="Eoffenses[RecDate]" type="date" runat="server" />
                                                            <label for="OffCode" class="required">
                                                                Offense <span class="required text-red">*
                                                                        <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" errormessage="Field Required" forecolor="Red" controltovalidate="OffCode" validationgroup="offensesgroup"></asp:requiredfieldvalidator>
                                                                </span>
                                                            </label>
                                                            <asp:dropdownlist id="OffCode" cssclass="form-control" runat="server" autopostback="true" onselectedindexchanged="OffenseDesc_SelectedIndexChanged">
                                                                    <asp:ListItem Enabled="true" Text="----Please Select----" Value=""></asp:ListItem>
                                                                </asp:dropdownlist>
                                                            <label for="OffNo" class="required">
                                                                Level of Offense <span class="required text-red">*
                                                                        <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" errormessage="Field Required" forecolor="Red" controltovalidate="OffNo" validationgroup="offensesgroup"></asp:requiredfieldvalidator>
                                                                </span>
                                                            </label>
                                                            <asp:dropdownlist id="OffNo" cssclass="form-control" runat="server">
                                                                    <asp:ListItem Enabled="true" Text="----Please Select----" Value=""></asp:ListItem>
                                                                    
                                                                </asp:dropdownlist>
                                                            <%--<label for="Eoffenses_Dates" class="required">Date(s) Occured</label>
                                                                <input class="form-control" maxlength="250" name="Eoffenses[Dates]" id="Eoffenses_Dates" type="text" runat="server" />--%>
                                                            <%--<label for="EffectiveDate" class="required">
                                                                    Effectivity Date</label>
                                                                <input class="form-control" id="txtEffectiveDate" name="Eoffenses[EffectiveDate]" type="date" runat="server" />--%>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            
                                                            <label for="Remarks" class="required">Remarks</label>
                                                            <textarea class="form-control" maxlength="500" name="Eoffenses[Remarks]" id="Remarks" runat="server"></textarea>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="form-actions" style="padding-top: 10px;">
                                                    <asp:button id="btnCreate" UseSubmitBehavior="true" width="80" class="btn btn-primary" runat="server" text="Create"
                                                        onclick="btnCreate_Click" onclientclick="Confirm()" validationgroup="offensesgroup"></asp:button>
                                                     <%--<asp:Button ID="Button1" UseSubmitBehavior="true" Width="80" class="btn btn-primary" runat="server" Text="PDFGen"
                                                        OnClick="ExportToPDFComp"></asp:Button>--%>
                                                    <asp:button id="btnReset" UseSubmitBehavior="true" class="btn btn-danger" width="80" runat="server" text="Reset"
                                                        onclick="btnReset_Click"></asp:button>
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
            <div class="modal-content1">

                <asp:updatepanel id="upListDetails" runat="server" childrenastriggers="False" updatemode="Conditional">
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
                                    <label for="upd_RecDate" class="required">
                                        Date Issued <span class="required text-red">*
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="upd_RecDate" ValidationGroup="offensesgroup1"></asp:RequiredFieldValidator></span></label>
                                    <input class="form-control datetimepicker" id="upd_RecDate" name="Eoffenses[RecDate]" type="text" runat="server" />
                                    <label for="upd_OffCode" class="required">
                                        Offense <span class="required text-red">*
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="upd_OffCode" ValidationGroup="offensesgroup1"></asp:RequiredFieldValidator></span></label>
                                    <asp:DropDownList ID="upd_OffCode" CssClass="form-control" runat="server">
                                        <asp:ListItem Enabled="true" Text="----Please Select----" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                    <label for="OffNo" class="required">
                                                                    Level of Offense <span class="required text-red">*
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="upd_OffNo" ValidationGroup="offensesgroup1"></asp:RequiredFieldValidator></span></label>
                                                                <asp:DropDownList ID="upd_OffNo" runat="server" CssClass="form-control" Label="" server="">
                                                                    
                                                                </asp:DropDownList>
                                   <%-- <label for="upd_Eoffenses_Dates" class="required">Date(s) Occured</label>
                                    <input class="form-control" maxlength="250" name="Eoffenses[Dates]" id="upd_Eoffenses_Dates" type="text" runat="server" />--%>
                                    <%--<label for="upd_EffectiveDate" class="required">
                                        Effectivity Date<span class="required">*
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="upd_EffectiveDate" ValidationGroup="offensesgroup1"></asp:RequiredFieldValidator></span></label>
                                    <input class="form-control datetimepicker" id="upd_EffectiveDate" name="Eoffenses[EffectiveDate]" type="text" runat="server" />--%>
                                </div>
                                <div class="col-lg-6">
                                    <%--<label for="upd_Eoffenses_DA" class="required">
                                        Disciplinary Action<span class="required">*
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="upd_Eoffenses_DA" ValidationGroup="offensesgroup1"></asp:RequiredFieldValidator></span></label>
                                    <asp:DropDownList ID="upd_Eoffenses_DA" CssClass="form-control" runat="server">
                                        <asp:ListItem Enabled="true" Text="---Select DA---" Value=""></asp:ListItem>
                                        <asp:ListItem Enabled="true" Text="Warning" Value="Warning"></asp:ListItem>
                                        <asp:ListItem Enabled="true" Text="Verbal Warning" Value="Verbal Warning"></asp:ListItem>
                                        <asp:ListItem Enabled="true" Text="Written Warning" Value="Written Warning"></asp:ListItem>
                                        <asp:ListItem Enabled="true" Text="Warning for Suspension" Value="Warning for Suspension"></asp:ListItem>
                                        <asp:ListItem Enabled="true" Text="Last and Final Warning" Value="Last and Final Warning"></asp:ListItem>
                                        <asp:ListItem Enabled="true" Text="Suspension" Value="Suspension"></asp:ListItem>
                                        <asp:ListItem Enabled="true" Text="Termination" Value="Termination"></asp:ListItem>
                                    </asp:DropDownList>--%>
                                    <label for="upd_suspensionDays" id="lblupd_suspensionDays" runat ="server" class="required">Suspension Days <span class="required text-red">*</span><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator7" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                        ControlToValidate="upd_suspensionDays" ValidationGroup="offensesgroup1"></asp:RequiredFieldValidator></label>
                                    <div class="input-group">
                                        <input class="form-control" id="upd_suspensionDays" name="Offenseapp_upd_suspensionDays" type="number" min="0" max="100" onkeypress="return isNumberKey(event)"  runat="server" />
                                    </div>
                                    <%--<label for="upd_Eoffenses_Inspector" class="required">Reported By</label>
                                    <asp:DropDownList ID="upd_Eoffenses_Inspector" CssClass="form-control" runat="server">
                                        <asp:ListItem Enabled="true" Text="----Please Select----" Value=""></asp:ListItem>
                                        
                                    </asp:DropDownList>--%>
                                    <label for="upd_Remarks" class="required">Remarks</label>
                                    <textarea class="form-control" maxlength="500" name="Eoffenses[Remarks]" id="upd_Remarks" runat="server"></textarea>
                                </div>

                            </div>


                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" UseSubmitBehavior="true" runat="server" Text="Update" CssClass="btn btn-primary"
                                OnClick="btnsaveUpdate_Click" OnClientClick="Confirm1()" ValidationGroup="offensesgroup1"></asp:Button>


                        </div>


                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnsaveUpdate" />
                    </Triggers>
                </asp:updatepanel>

            </div>
        </div>
    </div>

    <div class="modal fade" id="ViewModal">
        <div class="modal-dialog">
            <div class="modal-content">

                <asp:updatepanel id="upListDetails2" runat="server" childrenastriggers="False" updatemode="Conditional">
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
                                <div class="col-lg-12">
                                    <table>
                                        <tr>
                                            <td>
                                            <label for="vw_RecDate" class="required">Date Issued: </label>
                                    <asp:Label ID="vw_RecDate" runat="server" Text="Label"></asp:Label>
                                   <%-- <input class="form-control" id="vw_RecDate" name="Eoffenses[RecDate]" type="text" runat="server" disabled="disabled" />--%>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            <label for="vw_OffCode" class="required">Offense: </label>
                                    <asp:Label ID="vw_OffCode" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        
                                    <tr>
                                        <td>
                                        <label for="vw_OffNo" class="required">Offense Level: </label>
                                    <asp:Label ID="vw_OffNo" runat="server" Text="Label"></asp:Label>
                                   <%-- <input class="form-control" id="vw_OffCode" name="Eoffenses[RecDate]" type="text" runat="server" disabled="disabled" />--%>
                                            </td>
                                    </tr>
                                    
                                    <%--<label for="vw_Eoffenses_Dates">Date(s) Occured</label>
                                    <input class="form-control" maxlength="250" name="Eoffenses[Dates]" id="vw_Eoffenses_Dates" type="text" runat="server" disabled="disabled" />--%>
                                    <%--<label for="vw_EffectiveDate" class="required">Effectivity Date</label>
                                    <input class="form-control" id="vw_EffectiveDate" name="Eoffenses[EffectiveDate]" type="text" runat="server" disabled="disabled" />--%>
                                         <tr>
                                        <td>
                                        <label for="vw_Eoffenses_DA" class="required">Disciplinary Action: </label>
                                    <asp:Label ID="vw_Eoffenses_DA" runat="server" Text="Label"></asp:Label>
                                            </td>
                                             </tr>
                                         <tr>
                                        <td>
                                            <label for="vw_SuspensionDays" class="required">Suspension Days: </label>
                                            <asp:Label ID="vw_SuspensionDays" runat="server" Text="Label"></asp:Label>
                                        </td>
                                            </tr>
                                    <%--<input class="form-control" id="vw_Eoffenses_DA" name="Eoffenses[EffectiveDate]" type="text" runat="server" disabled="disabled" />--%>
                                    <%--<label for="vw_Eoffenses_Inspector" class="required">Reported By</label>
                                    <input class="form-control" id="vw_Eoffenses_Inspector" name="Eoffenses[EffectiveDate]" type="text" runat="server" disabled="disabled" />--%>
                                         <tr>
                                        <td>
                                    <label for="vw_Remarks" class="required">Remarks:</label>
                                    <asp:Label ID="vw_Remarks" runat="server" Text="Label"></asp:Label>
                                            </td>
                                             </tr>
                                    <%--<textarea class="form-control" maxlength="500" name="Eoffenses[Remarks]" id="vw_Remarks" runat="server" disabled="disabled"></textarea>--%>
                                    </table>
                                    
                                </div>
                                <div class="col-lg-6">
                                    
                                </div>

                            </div>


                        </div>
                        <div class="modal-footer">
                        </div>
                    </ContentTemplate>
                </asp:updatepanel>

            </div>
        </div>
    </div>

    <div class="modal fade" id="listmodalSetSuspension">
        <div class="modal-dialog">
            <div class="modal-content1">

                <asp:updatepanel id="UpdateSetSuspension" runat="server" childrenastriggers="False" updatemode="Conditional">
                    <ContentTemplate>

                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Label ID="Label2" runat="server" Text="Set Suspension"></asp:Label></h4>
                            <asp:LinkButton ID="lnkbtnXSetSuspension" CssClass="close" runat="server"
                                OnClick="lnkbtnXSetSuspension_Click">
                            <span>&times;</span>
                            </asp:LinkButton>
                        </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="HiddenFieldSuspension" runat="server" />
                            <div class="row">
                                <div class="col-lg-6">
                                    <label for="upd_RecDate" class="required">
                                        Date From <span class="required text-red">*
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="SuspensionDtFrom" ValidationGroup="setsuspensiongroup"></asp:RequiredFieldValidator></span></label>
                                    <input class="form-control datetimepicker" id="SuspensionDtFrom" name="Eoffenses[RecDate]" type="text" runat="server" />
                                    <label for="upd_RecDate" class="required">
                                        Date To <span class="required text-red">*s
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="SuspensionDtTo" ValidationGroup="setsuspensiongroup"></asp:RequiredFieldValidator></span></label>
                                    <input class="form-control datetimepicker" id="SuspensionDtTo" name="Eoffenses[RecDate]" type="text" runat="server" />
                                    

                            </div>


                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnSetSuspension" UseSubmitBehavior="false" runat="server" Text="Set" CssClass="btn btn-primary"
                                OnClick="btnSetSuspension_Click" OnClientClick="Confirm1()" ValidationGroup="setsuspensiongroup"></asp:Button>


                        </div>
                            </div>

                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnSetSuspension" />
                    </Triggers>
                </asp:updatepanel>

            </div>
        </div>
    </div>
</asp:Content>
