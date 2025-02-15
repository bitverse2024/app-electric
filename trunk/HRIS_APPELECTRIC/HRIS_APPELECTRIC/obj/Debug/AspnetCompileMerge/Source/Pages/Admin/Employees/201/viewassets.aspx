﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="viewassets.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees._201.viewassets" %>

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
                <h3 class="m-0 text-dark"><%=getname() %><small> Assets</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="#" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                        <a href="viewassets.aspx" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
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
                                                        <center><h1>NO ASSET AVAILABLE</h1></center>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkItem" CssClass="" Text='Item' runat="server" CommandName="Sort" CommandArgument="item"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchItem" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblItem" CssClass="" Text='<%# Eval("item") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkSerialNo" CssClass="" Text='Serial No' runat="server" CommandName="Sort" CommandArgument="serial_no"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchSerialNo" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSerialNo" CssClass="" Text='<%# Eval("serial_no") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkModel" CssClass="" Text='Model' runat="server" CommandName="Sort" CommandArgument="model"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchModel" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblModel" CssClass="" Text='<%# Eval("model") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkbrand" CssClass="" Text='Brand' runat="server" CommandName="Sort" CommandArgument="brand"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchbrand" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblbrand" CssClass="" Text='<%# Eval("brand") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkqty" CssClass="" Text='Quantity' runat="server" CommandName="Sort" CommandArgument="quantity"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchqty" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblqty" CssClass="" Text='<%# Eval("quantity") %>' runat="server"></asp:Label>
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

                                        <div class="form">

                                            <legend>
                                                <p class="note">Fields with <span class="required text-red">**</span> are required.</p>
                                            </legend>


                                            <div class="row">
                                                <div class="col-lg-6">

                                                    <div class="control-group ">
                                                        <label class="control-label required" for="Assets_item">Item <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="item" ValidationGroup="assetsgroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label><div class="controls">
                                                            <input class="form-control" maxlength="50" name="Assets[item]" id="item" type="text" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="control-group ">
                                                        <label class="control-label required" for="Assets_serial_no">Serial No <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="serial_no" ValidationGroup="assetsgroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <div class="controls">
                                                            <input class="form-control" maxlength="50" name="Assets[serial_no]" id="serial_no" type="text" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="control-group ">
                                                        <label class="control-label required" for="Assets_model">Model <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="model" ValidationGroup="assetsgroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <div class="controls">
                                                            <input class="form-control" maxlength="50" name="Assets[model]" id="model" type="text" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="control-group ">
                                                        <label class="control-label required" for="Assets_brand">Brand <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="brand" ValidationGroup="assetsgroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <div class="controls">
                                                            <input class="form-control" maxlength="50" name="Assets[brand]" id="brand" type="text" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="control-group ">
                                                        <label class="control-label required" for="Assets_quantity">Quantity <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="quantity" ValidationGroup="assetsgroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <div class="controls">
                                                            <input class="form-control" name="Assets[quantity]" id="quantity" type="text" runat="server" />
                                                        </div>
                                                    </div>



                                                </div>


                                            </div>
                                            <div class="form-actions" style="padding-top: 10px;">
                                                <asp:Button ID="btnCreate" Width="80" class="btn btn-primary" runat="server" Text="Create"
                                                    OnClick="btnCreate_Click" OnClientClick="Confirm()" ValidationGroup="assetsgroup"></asp:Button>
                                                <asp:Button ID="btnReset" class="btn btn-danger" Width="80" runat="server" Text="Reset"
                                                    OnClick="btnReset_Click"></asp:Button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
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
                                                <div class="col-lg-6">
                                                    <div class="control-group ">
                                                        <label class="control-label required" for="upd_item">Item <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="upd_item" ValidationGroup="assetsgroup1" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label><div class="controls">
                                                            <input class="form-control" maxlength="50" name="Assets[item]" id="upd_item" type="text" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="control-group ">
                                                        <label class="control-label required" for="upd_serial_no">Serial No <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="upd_serial_no" ValidationGroup="assetsgroup1" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <div class="controls">
                                                            <input class="form-control" maxlength="50" name="Assets[serial_no]" id="upd_serial_no" type="text" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="control-group ">
                                                        <label class="control-label required" for="upd_model">Model <span class="required text-red">**</span></label><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="upd_model" ValidationGroup="assetsgroup1" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                            <div class="controls">
                                <input class="form-control" maxlength="50" name="Assets[model]" id="upd_model" type="text" runat="server" />
                            </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="control-group ">
                                                        <label class="control-label required" for="upd_brand">Brand <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="upd_brand" ValidationGroup="assetsgroup1" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <div class="controls">
                                                            <input class="form-control" maxlength="50" name="Assets[brand]" id="upd_brand" type="text" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="control-group ">
                                                        <label class="control-label required" for="upd_quantity">Quantity <span class="required text-red">**<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="upd_quantity" ValidationGroup="assetsgroup1" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <div class="controls">
                                                            <input class="form-control" name="Assets[quantity]" id="upd_quantity" type="text" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>


                                        </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnsaveUpdate" runat="server" Text="Update" CssClass="btn btn-primary"
                            OnClick="btnsaveUpdate_Click" OnClientClick="Confirm1()" ValidationGroup="assetsgroup1"></asp:Button>


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
                                            <div class="control-group ">
                                                <label class="control-label required" for="vw_item">Item</label><div class="controls">
                                                    <input class="form-control" maxlength="50" name="Assets[item]" id="vw_item" type="text" runat="server" disabled="disabled" />
                                                </div>
                                            </div>
                                            <div class="control-group ">
                                                <label class="control-label required" for="vw_serial_no">Serial No</label>
                                                <div class="controls">
                                                    <input class="form-control" maxlength="50" name="Assets[serial_no]" id="vw_serial_no" type="text" runat="server" disabled="disabled" />
                                                </div>
                                            </div>
                                            <div class="control-group ">
                                                <label class="control-label required" for="vw_model">Model</label>
                                                <div class="controls">
                                                    <input class="form-control" maxlength="50" name="Assets[model]" id="vw_model" type="text" runat="server" disabled="disabled" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-5">
                                            <div class="control-group ">
                                                <label class="control-label required" for="vw_brand">Brand</label>
                                                <div class="controls">
                                                    <input class="form-control" maxlength="50" name="Assets[brand]" id="vw_brand" type="text" runat="server" disabled="disabled" />
                                                </div>
                                            </div>
                                            <div class="control-group ">
                                                <label class="control-label required" for="vw_quantity">Quantity</label>
                                                <div class="controls">
                                                    <input class="form-control" name="Assets[quantity]" id="vw_quantity" type="text" runat="server" disabled="disabled" />
                                                </div>
                                            </div>
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
            </section>
        </div>
    </div>
    </div>
</asp:Content>
