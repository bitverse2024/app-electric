﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="viewOffensesType.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.viewOffensesType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <SCRIPT type="text/javascript">
       <!--
       function isNumberKey(evt)
       {
          var charCode = (evt.which) ? evt.which : evt.keyCode;
          if (charCode != 46 && charCode > 31 
            && (charCode < 48 || charCode > 57))
             return false;

          return true;
       }
       //-->
    </SCRIPT>
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
                <h3 class="m-0 text-dark"><small> Offense Type</small></h3>
                <section class="card">
                    <div class="card-header">
                        
                        <a href="<%= ResolveUrl("~/Pages/Admin/offenseType.aspx")%>" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Back</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/viewOffensesType.aspx?id="+offenseno+"")%>" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                        
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
                                            <center><h1>NO OFFENSE TYPE ENTRIES</h1></center>
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbloffenseKey" Text='<%# Eval("offenseKey") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkoffenseDesc" CssClass="h8" Text='Offense Description' runat="server" CommandName="Sort" CommandArgument="offenseDesc"></asp:LinkButton><br />
                                                    <%--<asp:TextBox ID="txtoffenseDesc" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>--%>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbloffenseDesc" CssClass="" Text='<%# Eval("offenseDesc") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnksuspensionDay" CssClass="h8" Text='Suspension Day' runat="server" CommandName="Sort" CommandArgument="suspensionDay"></asp:LinkButton><br />
                                                    <%--<asp:TextBox ID="txtsuspensionDay" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>--%>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsuspensionDay" CssClass="" Text='<%# Eval("suspensionDay") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="10%">

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

                            <legend>
                                <p class="note">Fields with <span class="required text-red">**</span> are required.</p>
                            </legend>
                            <%--   <div class="container showgrid">--%>
                            
                                <div class="row">
                                    
                                    <div class="col-lg-6">
                                        <label for="offenseDesc" class="required">
                                        Offense Description<span class="required">*</span><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" ControlToValidate="offenseDesc"
                                            ForeColor="Red" ValidationGroup="OffenseTypeGroup"></asp:RequiredFieldValidator></label>
                                    <div class="input-group date">

                                        <input class="form-control" id="offenseDesc" name="Offense[Type]" type="text" runat="server" />
                                    </div>
                                        

                                        <label for="txtsuspensionDay" class="required">Suspension Days</label>
                                                                <div class="input-group">
                                                                    <input class="form-control" id="txtsuspensionDay" name="Offense[suspensionDay]" type="number" min="0" max="100" onkeypress="return isNumberKey(event)"  runat="server" />
                                                                </div>
                                    </div>
                                </div>
                                <%--</div>--%>

                                <div class="form-actions" style="padding-top: 10px;">
                                    <asp:Button ID="btnCreate" class="btn btn-primary" runat="server" Text="Create" Width="80"
                                        OnClick="btnCreate_Click" OnClientClick="Confirm()" ValidationGroup="OffenseTypeGroup"></asp:Button>
                                    <%--<asp:Button ID="btnReset" class="btn btn-danger" Width="80" runat="server" Text="Reset"
                                        OnClick="btnReset_Click"></asp:Button>--%>
                                </div>
                        </div>
                        </div>
                </section>
            </div>
        </div>
    </div>

    <%--VIEW MODAL--%>
    <div class="modal fade" id="ViewModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <asp:HiddenField ID="HiddenEmpIDView" runat="server" />
                <asp:updatepanel id="vwListDetails" runat="server" childrenastriggers="False" updatemode="Conditional">
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
                            <asp:HiddenField ID="HiddenFieldView" runat="server" />
                            <div class="row">
                                <!-- View Modal Content -->
                                <div class="col-lg-12">
                                    <table>
                                        <tr>
                                            <td>
                                                <label for="VW_OffenseDesc" class="required">Offense Description: </label>
                                                <asp:Label ID="VW_OffenseDesc" runat="server" Text="Label"></asp:Label>

                                            </td>

                                        </tr>
                                        <tr>
                                            <td>
                                                <label for="VW_SuspensionDays" class="required">Suspension Days: </label>
                                                <asp:Label ID="VW_SuspensionDays" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>

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

    <!-- Update Modal -->
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
                                <!-- Date -->

                                <div class="col-lg-8">
                                    
                                        <label for="offenseDesc" class="required">
                                        Offense Description<span class="required">*</span><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" ControlToValidate="offenseDesc"
                                            ForeColor="Red" ValidationGroup="OffenseTypeGroup"></asp:RequiredFieldValidator></label>
                                    <div class="input-group date">

                                        <input class="form-control" id="UPD_OffenseDesc" name="Offense[Type]" type="text" runat="server" />
                                    </div>
                                        

                                        <label for="UPD_SuspensionDays" class="required">Suspension Days</label>
                                        <div class="input-group">
                                            <input class="form-control" id="UPD_SuspensionDays" name="Offense[suspensionDay]" type="number" min="0" max="100" onkeypress="return isNumberKey(event)"  runat="server" />
                                        </div>

                                </div>

                            </div>

                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Update" CssClass="btn btn-primary"
                                OnClick="btnsaveUpdate_Click" OnClientClick="Confirm()" ValidationGroup="updComp"></asp:Button>


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
