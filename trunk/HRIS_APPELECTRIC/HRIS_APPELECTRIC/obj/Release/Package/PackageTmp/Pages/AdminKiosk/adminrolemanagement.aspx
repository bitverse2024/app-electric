<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="adminrolemanagement.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.AdminKiosk.adminrolemanagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script language="javascript" type="text/javascript">
        // <![CDATA[

        function select_role_onclick() {
            emprole = select_role.Value;
            GridViewList.DataSource = adl.populateGridOBTMasterSlct(emprole);
            GridViewList.DataBind();

        }

// ]]>
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                <h3 class="m-0 text-dark">Admin<small> Update Role</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="/../../Default_kioskAdmin.aspx" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Back</span></a>
                        <a href="#" class="btn btn-default"><i class="fa fa-th-list"></i><span class="h6">List</span></a>
                    </div>
                    <div class="card-body">
                        <div id="display-grid" class="grid-view">
                            <div class="summary">
                                <div class="form-actions">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <label for="select_role" class="required">Search By Role</label>
                                            <%--      <select class="form-control" name="select[Role]" id="select_role" runat="server" style="width: inherit" onselect="Status_SelectedIndexChanged" onclick="return select_role_onclick()">
                                                <option value="">---Select Role---</option>
                                                <option value="employee">Employee</option>
                                                <option value="admin">Admin</option>
                                                <option value="Timekeeper">Timekeeper</option>

                                            </select>--%>
                                            <asp:DropDownList ID="select_role" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="0" Selected="True">---SELECT USER ACCESS---</asp:ListItem>
                                                <asp:ListItem Value="admin">Admin</asp:ListItem>
                                                <asp:ListItem Value="employee">Employee</asp:ListItem>
                                                
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-6" style="padding-top: 32px">
                                            <asp:Button ID="btnSearch" class="btn btn-primary" runat="server" Text="Search"
                                                OnClick="btnSearch_Click" UseSubmitBehavior="true"></asp:Button>
                                        </div>
                                    </div>
                                </div>
                                Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.
                            </div>
                            <asp:GridView ID="GridViewList" runat="server" AutoGenerateColumns="False"
                                ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                ForeColor="Black" OnRowCommand="GridViewList_RowCommand"
                                OnPageIndexChanging="GridViewList_PageIndexChanging" ShowHeaderWhenEmpty="true"
                                ViewStateMode="Enabled" PageSize="20">
                                <EmptyDataTemplate>
                                    <center><h1>NO USERS AVAILABLE</h1></center>
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblid" Text='<%# Eval("empid") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="lnkFullName" Text='FullName' runat="server" CommandName="Sort" CommandArgument="fullname"></asp:LinkButton><br />
                                            <asp:TextBox ID="txtSearchFullName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblFullName" Text='<%# Eval("fullname") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="5%">
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="lblReset" Text='' runat="server" CommandName="Reset" CommandArgument="Reset"></asp:LinkButton><br />

                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Button ID="btnView" CssClass="btn-danger btn-xs" runat="server" Text="Update" CommandName="view" CommandArgument='<%# Eval("empid") %>' />
                                        </ItemTemplate>

                                    </asp:TemplateField>


                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
    <!-- UPDATE MODAL -->
    <div class="modal fade" id="listmodal">
        <div class="modal-dialog">
            <div class="modal-content">

                <asp:UpdatePanel ID="upListDetails" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                    <ContentTemplate>

                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Label ID="Label3" runat="server" Text="Update Roles"></asp:Label></h4>
                            <asp:LinkButton ID="lnkbtnXlist" CssClass="close" runat="server"
                                OnClick="lnkbtnXlist_Click">
                            <span>&times;</span>
                            </asp:LinkButton>
                        </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="HiddenEmpID" runat="server" />
                            <div class="row">
                                <!-- Modal Content -->

                                <div class="col-lg-9">


                                    <p>
                                        <asp:Label ID="lblDisplayempname" runat="server" Text="Alexander Pierce"></asp:Label>
                                    </p>
                                    <p>
                                        <asp:Label ID="lblDisplayempid" runat="server" Text=""></asp:Label>
                                    </p>

                                    <label>
                                        <label for="upd_roles" class="required">Role</label></label>
                                    <%--  <select class="form-control" name="upd[Role]" id="upd_roles" runat="server" style="width: inherit" onselect="Status_SelectedIndexChanged">
                                        <option value="">---Select Role---</option>
                                        <option value="employee">Employee</option>
                                        <option value="admin">Admin</option>
                                        <option value="Timekeeper">Timekeeper</option>

                                    </select>--%>
                                    <asp:DropDownList ID="upd_roles" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0" Selected="True">---SELECT USER ACCESS---</asp:ListItem>
                                    </asp:DropDownList>


                                </div>

                            </div>


                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Update" Width="80px" CssClass="btn btn-primary"
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
</asp:Content>
