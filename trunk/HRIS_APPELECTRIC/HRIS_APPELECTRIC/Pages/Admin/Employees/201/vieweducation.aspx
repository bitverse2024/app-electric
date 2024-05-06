<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="vieweducation.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees._201.vieweducation" %>

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
                <h3 class="m-0 text-dark"><%=getname() %><small> Education</small></h3>
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
                                                        <center><h1>NO EDUCATIONAL BACKGROUND AVAILABLE</h1></center>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkCourseName" CssClass="" Text='Course' runat="server" CommandName="Sort" CommandArgument="CourseName"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchCourseName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseName" CssClass="" Text='<%# Eval("CourseName") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkSchoolName" CssClass="h8" Text='School' runat="server" CommandName="Sort" CommandArgument="SchoolName"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchSchoolName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSchoolName" CssClass="" Text='<%# Eval("SchoolName") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkIdate" CssClass="" Text='Date' runat="server" CommandName="Sort" CommandArgument="Idate"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchIdate" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIdate" CssClass="" Text='<%# Eval("IDate") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkRemarks" CssClass="" Text='Remarks' runat="server" CommandName="Sort" CommandArgument="Remarks"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchRemarks" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRemarks" CssClass="" Text='<%# Eval("Remarks") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>



                                                        <asp:TemplateField HeaderStyle-Width="15%">
                                                            <ItemTemplate>
                                                                <%--  <asp:Button ID="btnView" CssClass="btn-success btn-xs" runat="server" Text="View"  CommandName="view" CommandArgument='<%# Eval("id") %>'  />
                                                                            <asp:Button ID="btnUpdate" CssClass="btn-success btn-xs" runat="server" Text="Update"   CommandName="upd" CommandArgument='<%# Eval("id") %>'  />
                                                                            <asp:Button ID="btnDelete" CssClass="btn-danger btn-xs" runat="server" Text="Delete" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;" CommandName="del" CommandArgument='<%# Eval("id") %>'  />--%>
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
                                                            <label for="SchoolName" class="required">
                                                                School <span class="required text-red">**
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="SchoolName" ValidationGroup="educgroup" InitialValue="0" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                            <asp:DropDownList ID="SchoolName" CssClass="form-control" runat="server">
                                                                <asp:ListItem Enabled="true" Text="----Please Select----" Value="0"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <label for="IDate" class="required">Inclusive Dates</label>
                                                            <input class="form-control" maxlength="30" name="Ebground[IDate]" id="IDate" type="text" runat="server" />
                                                            <label for="CourseName" class="required">
                                                                Course <span class="required text-red">**
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="CourseName" ValidationGroup="educgroup" InitialValue="0" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                            <asp:DropDownList ID="CourseName" CssClass="form-control" runat="server">
                                                                <asp:ListItem Enabled="true" Text="----Please Select----" Value="0"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <label for="HReceived" class="required">Honors Received</label><input class="form-control" maxlength="30" name="Ebground[HReceived]" id="HReceived" type="text" runat="server" />
                                                            <label for="Remarks" class="required">Remarks</label><input class="form-control" maxlength="50" name="Ebground[Remarks]" id="Remarks" type="text" runat="server" />
                                                            <label for="LicenseNo" class="required">License No.</label><input class="form-control" maxlength="50" name="Ebground[Remarks]" id="LicenseNo" type="text" runat="server" />

                                                        </div>
                                                    </div>
                                                </div>


                                                <div class="form-actions" style="padding-top: 10px;">
                                                    <asp:Button ID="btnCreate" CssClass="btn btn-primary" runat="server" Text="Create" Width="80"
                                                        OnClick="btnCreate_Click" OnClientClick="Confirm()" ValidationGroup="educgroup"></asp:Button>
                                                    <asp:Button ID="btnReset" class="btn btn-danger" runat="server" Text="Reset" Width="80"
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
                                    <label for="upd_SchoolName" class="required">
                                        School <span class="required text-red">**
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="upd_SchoolName" ValidationGroup="educgroup1" InitialValue="0" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                    <asp:DropDownList ID="upd_SchoolName" CssClass="form-control" runat="server">
                                        <asp:ListItem Enabled="true" Text="----Please Select----" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <label for="upd_IDate" class="required">Inclusive Dates</label>
                                    <input class="form-control" maxlength="30" name="Ebground[IDate]" id="upd_IDate" type="text" runat="server" />
                                    <label for="upd_CourseName" class="required">
                                        Course <span class="required text-red">**
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="upd_CourseName" ValidationGroup="educgroup1" InitialValue="0" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                    <asp:DropDownList ID="upd_CourseName" CssClass="form-control" runat="server">
                                        <asp:ListItem Enabled="true" Text="----Please Select----" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-6">
                                    <label for="upd_HReceived" class="required">Honors Received</label><input class="form-control" maxlength="30" name="Ebground[HReceived]" id="upd_HReceived" type="text" runat="server" />
                                    <label for="upd_Remarks" class="required">Remarks</label><input class="form-control" maxlength="50" name="Ebground[Remarks]" id="upd_Remarks" type="text" runat="server" />
                                    <label for="upd_LicenseNo" class="required">License No.</label><input class="form-control" maxlength="50" name="Ebground[Remarks]" id="upd_LicenseNo" type="text" runat="server" />
                                </div>

                            </div>

                        </div>


                        </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnsaveUpdate" runat="server" Text="Update" CssClass="btn btn-primary"
                            OnClick="btnsaveUpdate_Click" OnClientClick="Confirm1()" ValidationGroup="educgroup1"></asp:Button>


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
                                    <label for="vw_SchoolName" class="required">School</label>
                                    <input class="form-control" maxlength="30" id="vw_SchoolName" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_IDate" class="required">Inclusive Dates</label>
                                    <input class="form-control datetimepicker" maxlength="30" id="vw_IDate" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_CourseName" class="required">Course</label>
                                    <input class="form-control datetimepicker" maxlength="30" id="vw_CourseName" type="text" runat="server" disabled="disabled" />
                                </div>
                                <div class="col-lg-6">
                                    <label for="vw_HReceived" class="required">Honors Received</label><input class="form-control" maxlength="30" name="Ebground[HReceived]" id="vw_HReceived" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_Remarks" class="required">Remarks</label><input class="form-control" maxlength="50" name="Ebground[Remarks]" id="vw_Remarks" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_LicenseNo" class="required">License No.</label><input class="form-control" maxlength="50" name="Ebground[Remarks]" id="vw_LicenseNo" type="text" runat="server" disabled="disabled" />
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
