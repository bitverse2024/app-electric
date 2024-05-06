<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="viewexams.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees._201.viewexams" %>

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
                <h3 class="m-0 text-dark"><%=getname() %><small> Exams and Seminars</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="#" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/EmployeeMaster.aspx")%>" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/EmployeeView.aspx?empid="+empno+"")%>" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Employee View</span></a>

                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="box-body">
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
                                                        <center><h1>NO EXAMS/SEMINAR AVAILABLE</h1></center>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkDateTaken" CssClass="" Text='Date Taken' runat="server" CommandName="Sort" CommandArgument="DateTaken"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchDateTaken" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDateTaken" CssClass="" Text='<%# Eval("DateTaken") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkExamType" CssClass="" Text='Description' runat="server" CommandName="Sort" CommandArgument="ExamType"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchDescription" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblExamType" CssClass="" Text='<%# Eval("ExamType") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkRemarks" CssClass="" Text='Remarks/Grade' runat="server" CommandName="Sort" CommandArgument="Remarks"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchRemarks" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRemarks" CssClass="" Text='<%# Eval("Remarks") %>' runat="server"></asp:Label>
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

                                        <div class="form">
                                            <legend>
                                                <p class="note">Fields with <span class="required text-red">**</span> are required.</p>
                                            </legend>


                                            <div class="showgrid">
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <label for="DateTaken" class="required">
                                                            Date Taken <span class="required text-red">**
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDateTaken" ForeColor="Red" ErrorMessage="Field Required" ValidationGroup="examsgroup"></asp:RequiredFieldValidator></span></label>
                                                        <input class="form-control" id="txtDateTaken" name="Exams[RefDate]" type="date" maxlength="30" runat="server" />
                                                        <label for="ExamType" class="required">
                                                            Description <span class="required text-red">**
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ExamType" ForeColor="Red" ErrorMessage="Field Required" ValidationGroup="examsgroup"></asp:RequiredFieldValidator></span></label>
                                                        <input class="form-control" maxlength="255" name="Exams[ExamType]" id="ExamType" type="text" runat="server" />
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label for="Remarks" class="required">Remarks/Grade</label><input class="form-control" maxlength="100" name="Exams[Remarks]" id="Remarks" type="text" runat="server" />
                                                        <label for="ExamStatus" class="required">Status</label><input class="form-control" maxlength="50" name="Exams[Status]" id="ExamStatus" type="text" runat="server" />
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-actions" style="padding-top: 10px;">
                                                <asp:Button ID="btnCreate" Width="80" CssClass="btn btn-primary" runat="server" Text="Create"
                                                    OnClick="btnCreate_Click" OnClientClick="Confirm()" ValidationGroup="examsgroup"></asp:Button>
                                                <asp:Button ID="btnReset" Width="80" CssClass="btn btn-danger" runat="server" Text="Reset"
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
            <div class="modal-content">

                <asp:UpdatePanel ID="upListDetails" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                    <ContentTemplate>

                        <div class="modal-header">
                            <h4 class="modal-title"><asp:Label ID="Label3" runat="server" Text="Edit Information"></asp:Label></h4>
                            <asp:LinkButton ID="lnkbtnXlist" CssClass="close" runat="server"
                                OnClick="lnkbtnXlist_Click">
                            <span>&times;</span>
                            </asp:LinkButton>
                        </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="HiddenEmpID" runat="server" />
                            <div class="row">
                                <div class="col-lg-6">
                                    <label for="upd_DateTaken" class="required">
                                        Date Taken <span class="required text-red">**
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="upd_DateTaken" ErrorMessage="Field Required" ValidationGroup="examsgroup1"></asp:RequiredFieldValidator></span></label>
                                    <input class="form-control datetimepicker" id="upd_DateTaken" name="Exams[RefDate]" type="text" maxlength="30" runat="server" />
                                    <label for="upd_ExamType" class="required">
                                        Description <span class="required text-red">**
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="upd_ExamType" ErrorMessage="Field Required" ValidationGroup="examsgroup1"></asp:RequiredFieldValidator></span></label>
                                    <input class="form-control" maxlength="255" name="Exams[ExamType]" id="upd_ExamType" type="text" runat="server" />
                                </div>
                                <div class="col-lg-6">
                                    <label for="upd_Remarks" class="required">Remarks/Grade</label>
                                    <input class="form-control" maxlength="100" name="Exams[Remarks]" id="upd_Remarks" type="text" runat="server" />
                                    <label for="upd_Status" class="required">Status</label>
                                    <input class="form-control" maxlength="50" name="Exams[Status]" id="upd_Status" type="text" runat="server" />
                                </div>
                            </div>
                        </div>
                        </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnsaveUpdate" runat="server" Text="Update" CssClass="btn btn-primary"
                            OnClick="btnsaveUpdate_Click" OnClientClick="Confirm1()" ValidationGroup="examsgroup1"></asp:Button>


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
                            <h4 class="modal-title"><asp:Label ID="Label1" runat="server" Text="View Information"></asp:Label></h4>
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
                                    <label for="vw_DateTaken" class="required">Date Taken</label>
                                    <input class="form-control datetimepicker" id="vw_DateTaken" name="Exams[RefDate]" type="text" maxlength="30" runat="server" disabled="disabled" />
                                    <label for="vw_ExamType" class="required">Description</label>
                                    <input class="form-control" maxlength="255" name="Exams[ExamType]" id="vw_ExamType" type="text" runat="server" disabled="disabled" />
                                </div>
                                <div class="col-lg-6">
                                    <label for="vw_Remarks" class="required">Remarks/Grade</label><input class="form-control" maxlength="100" name="Exams[Remarks]" id="vw_Remarks" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_ExamStatus" class="required">Status</label><input class="form-control" maxlength="50" name="Exams[Status]" id="vw_ExamStatus" type="text" runat="server" disabled="disabled" />
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
