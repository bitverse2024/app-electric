<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="viewfbground.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees._201.viewfbground" %>

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
                <h3 class="m-0 text-dark"><%=getname() %><small> Family</small></h3>
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
                                        <div id="list">

                                            <div id="fbground-grid" class="grid-view">
                                                <div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>
                                                <asp:GridView ID="GridViewList" runat="server" AutoGenerateColumns="False"
                                                    ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                    GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                    ForeColor="Black" OnRowCommand="GridViewList_RowCommand"
                                                    OnPageIndexChanging="GridViewList_PageIndexChanging"
                                                    ViewStateMode="Enabled" ShowHeaderWhenEmpty="true">
                                                    <EmptyDataTemplate>
                                                        <center><h1>NO FAMILY BACKGROUND AVAILABLE</h1></center>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkFName" CssClass="" Text='Name' runat="server" CommandName="Sort" CommandArgument="Fname"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtFName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFName" CssClass="" Text='<%# Eval("FName") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkBirthdate" CssClass="" Text='Birthdate' runat="server" CommandName="Sort" CommandArgument="Birthdate"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtBirthdate" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBirthdate" CssClass="" Text='<%# Eval("Birthdate") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkAge" CssClass="" Text='Age' runat="server" CommandName="Sort" CommandArgument="Age"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtAge" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAge" CssClass="" Text='<%# Eval("Age") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkRelationship" CssClass="" Text='Relationship' runat="server" CommandName="Sort" CommandArgument="Relationship"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtRelationship" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRelationship" CssClass="" Text='<%# Eval("Relationship") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkContactNo" CssClass="" Text='Contact Number' runat="server" CommandName="Sort" CommandArgument="ContactNo"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtContactNo" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblContactNo" CssClass="" Text='<%# Eval("ContactNo") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>



                                                        <asp:TemplateField HeaderStyle-Width="15%">
                                                            <ItemTemplate>
                                                                <%-- <asp:Button ID="btnView" CssClass="btn-success btn-xs" runat="server" Text="View"  CommandName="view" CommandArgument='<%# Eval("id") %>'  />
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
                                    </div>

                                    <div class="form">
                                        <legend>
                                            <p class="note">Fields with <span class="required text-red">**</span> are required.</p>
                                        </legend>


                                        <div class="row">
                                            <div class="col-lg-6">


                                                <label for="FName" class="required">First Name <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="FName" ForeColor="Red" runat="server" ErrorMessage="Field Required" ValidationGroup="fbroundgroup"></asp:RequiredFieldValidator></span></label>
                                                <input class="form-control" maxlength="100" name="Fbground[Name]" id="FName" type="text" runat="server" />
                                                <label for="MName" class="required">Middle Name</label>
                                                <input class="form-control" maxlength="100" name="Fbground[Name]" id="MName" type="text" runat="server" />
                                                <label for="LName" class="required">Last Name <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="LName" ForeColor="Red" runat="server" ErrorMessage="Field Required" ValidationGroup="fbroundgroup"></asp:RequiredFieldValidator></span></label>
                                                <input class="form-control" maxlength="100" name="Fbground[Name]" id="LName" type="text" runat="server" />
                                                <label for="Birthdate" class="required">Birthdate</label>
                                                <input class="form-control" id="txtBirthdate" name="Fbground[Birthdate]" type="date" runat="server" />
                                            </div>
                                            <div class="col-lg-6">
                                                <label for="Relationship" class="required">Relationship <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="Relationship" ForeColor="Red" runat="server" ErrorMessage="Field Required" ValidationGroup="fbroundgroup"></asp:RequiredFieldValidator></span></label>
                                                <input class="form-control" maxlength="8" name="Fbground[Relationship]" id="Relationship" type="text" runat="server" />
                                                <label for="Occupation" class="required">Occupation</label>
                                                <input class="form-control" maxlength="40" name="Fbground[Occupation]" id="Occupation" type="text" runat="server" />
                                                <label for="Company" class="required">Company</label>
                                                <input class="form-control" maxlength="50" name="Fbground[Company]" id="Company" type="text" runat="server" />
                                                <label for="ContactNo" class="required">Contact Number</label>
                                                <input class="form-control" maxlength="100" name="Fbground[ContactNo]" id="ContactNo" type="text" runat="server" />
                                            </div>


                                        </div>

                                    </div>
                                    <div class="form-actions" style="padding-top: 10px;">
                                        <asp:Button ID="btnSubmit" Width="80" class="btn btn-primary" runat="server" Text="Create"
                                            OnClick="btnSubmit_Click" OnClientClick="Confirm()" ValidationGroup="fbroundgroup"></asp:Button>
                                        <asp:Button ID="btnReset" Width="80" class="btn btn-danger" runat="server" Text="Reset"
                                            OnClick="btnReset_Click"></asp:Button>
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
                                    <label for="upd_FName" class="required">First Name <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="upd_FName" ForeColor="Red" runat="server" ErrorMessage="Field Required" ValidationGroup="fbroundgroup1"></asp:RequiredFieldValidator></span></label>
                                    <input class="form-control" maxlength="100" name="Fbground[Name]" id="upd_FName" type="text" runat="server" />
                                    <label for="upd_MName" class="required">Middle Name</label>
                                    <input class="form-control" maxlength="100" name="Fbground[Name]" id="upd_MName" type="text" runat="server" />
                                    <label for="upd_LName" class="required">Last Name <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="upd_LName" ForeColor="Red" runat="server" ErrorMessage="Field Required" ValidationGroup="fbroundgroup1"></asp:RequiredFieldValidator></span></label>
                                    <input class="form-control" maxlength="100" name="Fbground[Name]" id="upd_LName" type="text" runat="server" />
                                    <label for="upd_Birthdate" class="required">Birthdate</label>
                                    <input class="form-control datetimepicker" id="upd_Birthdate" name="Fbground[Birthdate]" type="text" runat="server" />
                                    <label for="upd_Relationship" class="required">Relationship <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="upd_Relationship" ForeColor="Red" runat="server" ErrorMessage="Field Required" ValidationGroup="fbroundgroup1"></asp:RequiredFieldValidator></span></label>
                                    <input class="form-control" maxlength="8" name="Fbground[Relationship]" id="upd_Relationship" type="text" runat="server" />
                                </div>
                                <div class="col-lg-6">
                                    <label for="upd_Occupation" class="required">Occupation</label>
                                    <input class="form-control" maxlength="40" name="Fbground[Occupation]" id="upd_Occupation" type="text" runat="server" />
                                    <label for="upd_Company" class="required">Company</label>
                                    <input class="form-control" maxlength="50" name="Fbground[Company]" id="upd_Company" type="text" runat="server" />
                                    <label for="upd_ContactNo" class="required">Contact Number</label>
                                    <input class="form-control" maxlength="100" name="Fbground[ContactNo]" id="upd_ContactNo" type="text" runat="server" />
                                </div>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Update" CssClass="btn btn-primary"
                                OnClick="btnsaveUpdate_Click" OnClientClick="Confirm1()" ValidationGroup="fbroundgroup1"></asp:Button>


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
                                    <label for="vw_FName" class="required">Name</label>
                                    <input class="form-control" maxlength="100" name="Fbground[Name]" id="vw_FName" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_MName" class="required">Middle Name</label>
                                    <input class="form-control" maxlength="100" name="vw_FName" id="vw_MName" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_LName" class="required">Last Name</label>
                                    <input class="form-control" maxlength="100" name="vw_FName" id="vw_LName" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_Birthdate" class="required">Birthdate</label>
                                    <input class="form-control datetimepicker" id="vw_Birthdate" name="Fbground[Birthdate]" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_Relationship" class="required">Relationship</label>
                                    <input class="form-control" maxlength="8" name="Fbground[Relationship]" id="vw_Relationship" type="text" runat="server" disabled="disabled" />
                                </div>
                                <div class="col-lg-6">
                                    <label for="vw_Occupation" class="required">Occupation</label>
                                    <input class="form-control" maxlength="40" name="Fbground[Occupation]" id="vw_Occupation" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_Company" class="required">Company</label>
                                    <input class="form-control" maxlength="50" name="Fbground[Company]" id="vw_Company" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_ContactNo" class="required">Contact Number</label>
                                    <input class="form-control" maxlength="100" name="Fbground[ContactNo]" id="vw_ContactNo" type="text" runat="server" disabled="disabled" />
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
