<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="adminusermanagement.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.AdminKiosk.adminusermanagement" %>

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
                <h3 class="m-0 text-dark">Admin<small> User Management</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="/../../Default_kioskAdmin.aspx" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Back</span></a>
                        <a href="#" class="btn btn-default"><i class="fa fa-th-list"></i><span class="h6">List</span></a>
                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div id="display-grid" class="grid-view">
                                    <asp:GridView ID="GridUserList" runat="server" AutoGenerateColumns="False"
                                        ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                        GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                        ForeColor="Black" OnRowCommand="GridUserList_RowCommand"
                                        OnPageIndexChanging="GridUserList_PageIndexChanging" ShowHeaderWhenEmpty="true"
                                        ViewStateMode="Enabled" PageSize="20" ShowHeader="true">
                                        <EmptyDataTemplate>
                                            <center><h1>NO USERS AVAILABLE</h1></center>
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="120px">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lblemp_EmpID" Text='Employee No.' runat="server" CommandName="Sort" CommandArgument="emp_EmpID"></asp:LinkButton><br />

                                                    <asp:TextBox ID="txtSearchemp_EmpID" runat="server" OnTextChanged="txtItem_TextChanged" Width="100px"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmpNo" Text='<%# Eval("emp_EmpID") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lblemp_FullName" CssClass="h8" Text='Full Name' runat="server" CommandName="Sort" CommandArgument="emp_FullName"></asp:LinkButton><br />
                                                    <asp:TextBox ID="txtSearchemp_FullName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblemp_FullName" CssClass="h5" Text='<%# Eval("emp_FullName") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lbldatecreatep" CssClass="h8" Text='Date Create' runat="server" CommandName="Sort" CommandArgument="datecreatep"></asp:LinkButton><br />
                                                    <asp:TextBox ID="txtSearchdatecreatep" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldatecreatep" CssClass="h5" Text='<%# Eval("datecreatep") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lblvaliddays" CssClass="h8" Text='Valid Days' runat="server" CommandName="Sort" CommandArgument="validdays"></asp:LinkButton><br />
                                                    <asp:TextBox ID="txtSearchvaliddays" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblvaliddays" CssClass="h5" Text='<%# Eval("validdays") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>



                                            <asp:TemplateField HeaderStyle-Width="90px">
                                                <ItemTemplate>
                                                    <center>
                                                        <%--<asp:Button ID="btnAdd" CssClass="btn-instagram btn-xs" runat="server"  Text="View" CommandName="view" CommandArgument='<%# Eval("EmployeeNo") %>'  />
                                                        <asp:Button ID="btnUpdate" CssClass="btn-success btn-xs" runat="server" Text="Update"   CommandName="update" CommandArgument='<%# Eval("EmployeeNo") %>'  />
                                                        <asp:Button ID="btnDelete" CssClass="btn-danger btn-xs" runat="server" Text="Delete"  CommandName="del" CommandArgument='<%# Eval("EmployeeNo") %>'  />--%>

                                                        <asp:LinkButton ID="btnupd" runat="server" ForeColor="Black" Font-Size="Large" CommandName="upd" CommandArgument='<%# Eval("emp_EmpID") %>'><i class="fa fa-edit"></i></asp:LinkButton> &nbsp;
                                                                            
                                                                            
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
                </section>
            </div>
        </div>
    </div>
    <div>

        <!-- UPDATE MODAL -->
        <div class="modal fade" id="listmodal">
            <div class="modal-dialog">
                <div class="modal-content">

                    <asp:UpdatePanel ID="upListDetails" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                        <ContentTemplate>

                            <div class="modal-header">
                                <h4 class="modal-title">
                                    <asp:Label ID="Label3" runat="server" Text="Edit Valid Days"></asp:Label></h4>

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


                                        <label>
                                            <label for="upd_validdate" class="required">Valid Days<span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="upd_validdate" ValidationGroup="Updvaliddate" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label></label>
                                        <input class="form-control" id="upd_validdate" name="txtvaliddate" type="text" runat="server" />
                                        <label>
                                            <label for="view_validtil" class="required">Valid Until</label></label>
                                        <input class="form-control" id="view_validtil" name="txtvalidtil" type="text" runat="server" readonly />



                                    </div>

                                </div>


                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnsaveUpdate" runat="server" Text="Update" CssClass="btn btn-primary" Width="80px"
                                    OnClick="btnsaveUpdate_Click" OnClientClick="Confirm()" ValidationGroup="Updvaliddate"></asp:Button>


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
    </div>
</asp:Content>
