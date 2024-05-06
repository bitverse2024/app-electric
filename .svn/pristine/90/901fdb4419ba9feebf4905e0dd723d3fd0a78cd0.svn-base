<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="viewlicenses.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees._201.viewlicenses" %>

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
                <h3 class="m-0 text-dark"><%=getname() %><small> License</small></h3>
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
                                                        <center><h1>NO LICENSE AVAILABLE</h1></center>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkLicenseType" Text='License Type' runat="server" CommandName="Sort" CommandArgument="LicenseType"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchLicenseType" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLicenseType" Text='<%# Eval("LicenseType") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkLicNo" Text='License No' runat="server" CommandName="Sort" CommandArgument="LicenseNo"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchLicNo" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLicNo" Text='<%# Eval("LicenseNo") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkExpiryDate" Text='Expiry Date' runat="server" CommandName="Sort" CommandArgument="ExpiryDate"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchExpiryDate" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblExpiryDate" Text='<%# Eval("ExpiryDate") %>' runat="server"></asp:Label>
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


                                            <div class="row">
                                                <div class="col-lg-6">


                                                    <label for="Licenses_license_type" class="required">
                                                        License Type <span class="required text-red">**
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="license_type" ValidationGroup="licensegroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                    <input runat="server" class="form-control" maxlength="30" name="Licenses[license_type]" id="license_type" type="text" />
                                                    <label for="Licenses_license_no" class="required">
                                                        License No <span class="required text-red">**
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="license_no" ValidationGroup="licensegroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                    <input runat="server" class="form-control" maxlength="30" name="Licenses[license_no]" id="license_no" type="text" />
                                                    <label for="Licenses_expiry_date" class="required">Expiry Date</label>
                                                    <input runat="server" class="form-control" id="txtlic_expirydate" name="Licenses[expiry_date]" type="date" />
                                                </div>
                                            </div>
                                            <br />
                                            <div class="form-actions">
                                                <asp:Button ID="btnCreate" class="btn btn-primary" runat="server" Text="Create" Width="80"
                                                    OnClick="btnCreate_Click" OnClientClick="Confirm()" ValidationGroup="licensegroup"></asp:Button>
                                                <asp:Button ID="btnReset" Width="80" class="btn btn-danger" runat="server" Text="Reset"
                                                    OnClick="btnReset_Click"></asp:Button>
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
                                                                    <div class="col-lg-7">
                                                                        <label for="upd_license_type" class="required">
                                                                            License Type <span class="required text-red">**
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="upd_license_type" ValidationGroup="licensegroup1" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                                        <input runat="server" class="form-control" maxlength="30" name="Licenses[license_type]" id="upd_license_type" type="text" />
                                                                        <label for="upd_license_no" class="required">
                                                                            License No <span class="required text-red">**
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="upd_license_no" ValidationGroup="licensegroup1" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                                        <input runat="server" class="form-control" maxlength="30" name="Licenses[license_no]" id="upd_license_no" type="text" />
                                                                        <label for="upd_lic_expirydate" class="required">Expiry Date</label>
                                                                        <input runat="server" class="form-control datetimepicker" id="upd_lic_expirydate" name="Licenses[expiry_date]" type="text" />
                                                                    </div>
                                                                </div>

                                                            </div>


                                                            </div>
                                                            <div class="modal-footer">
                                                                <asp:Button ID="btnsaveUpdate" runat="server" Text="Update" CssClass="btn btn-primary"
                                                                    OnClick="btnsaveUpdate_Click" OnClientClick="Confirm1()" ValidationGroup="licensegroup1"></asp:Button>


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
                                                                        <label for="vw_license_type" class="required">License Type</label>
                                                                        <input runat="server" class="form-control" maxlength="30" name="Licenses[license_type]" id="vw_license_type" type="text" disabled="disabled" />
                                                                        <label for="vw_license_no" class="required">License No</label>
                                                                        <input runat="server" class="form-control" maxlength="30" name="Licenses[license_no]" id="vw_license_no" type="text" disabled="disabled" />
                                                                        <label for="vw_lic_expirydate" class="required">Expiry Date</label>
                                                                        <input runat="server" class="form-control datetimepicker" id="vw_lic_expirydate" name="Licenses[expiry_date]" type="text" disabled="disabled" />
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
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</asp:Content>
