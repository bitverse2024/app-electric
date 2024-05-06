<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeAdjustmentList.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.PayrollPages.EmployeeAdjustmentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                <h3 class="m-0 text-dark">Payroll<small> Deductions</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="EmployeeListForAdjustment.aspx" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/PayrollPages/CreateEmployeeAdjustment.aspx?empid="+empno+"")%>" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div id="display-grid" class="grid-view">
                                    <div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>
                                    <asp:GridView ID="GridViewList" runat="server" AutoGenerateColumns="False"
                                        ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                        GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                        ForeColor="Black" OnRowCommand="GridViewList_RowCommand"
                                        OnPageIndexChanging="GridViewList_PageIndexChanging" ShowHeaderWhenEmpty="true"
                                        ViewStateMode="Enabled">
                                        <EmptyDataTemplate>
                                            <center><h1>NO DATA AVAILABLE</h1></center>
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkEmpID" CssClass="h8" Text='Employee Number' runat="server" CommandName="Sort" CommandArgument="EmpID"></asp:LinkButton><br />
                                                    <asp:TextBox ID="txtSearchEmpID" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblidEmpID" CssClass="h6" Text='<%# Eval("EmpID") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkCutOffID" CssClass="h8" Text='Pay Period' runat="server" CommandName="Sort" CommandArgument="CutOffID"></asp:LinkButton><br />
                                                    <asp:TextBox ID="txtCutOffID" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDeduction" CssClass="h6" Text='<%# Eval("CutOffID") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkAdjustmentAdd" CssClass="h8" Text='ADJUSTMENT' runat="server" CommandName="Sort" CommandArgument="AdjustmentAdd"></asp:LinkButton><br />
                                                    <asp:TextBox ID="txtAdjustmentAdd" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAdjustmentAdd" CssClass="h6" Text='<%# Eval("AdjustmentAdd") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkAdjRemarks" CssClass="h8" Text='ADJUSTMENT REMARKS' runat="server" CommandName="Sort" CommandArgument="AdjRemarks"></asp:LinkButton><br />
                                                    <asp:TextBox ID="txtAdjRemarks" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAdjRemarks" CssClass="h6" Text='<%# Eval("AdjRemarks") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkAdjustmentOthersAdd" CssClass="h8" Text='ADJ - OTHERS' runat="server" CommandName="Sort" CommandArgument="AdjustmentOthersAdd"></asp:LinkButton><br />
                                                    <asp:TextBox ID="txtAdjustmentOthersAdd" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAdjustmentOthersAdd" CssClass="h6" Text='<%# Eval("AdjustmentOthersAdd") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkAdjOthrsRemarks" CssClass="h8" Text='ADJ - OTHERS REMARKS' runat="server" CommandName="Sort" CommandArgument="AdjOthrsRemarks"></asp:LinkButton><br />
                                                    <asp:TextBox ID="txtAdjOthrsRemarks" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAdjOthrsRemarks" CssClass="h6" Text='<%# Eval("AdjOthrsRemarks") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            

                                            <asp:TemplateField HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <center>
                                                   
                                                    <asp:LinkButton ID="btnDelete" runat="server" ForeColor="Black" Font-Size="Medium" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;"  CommandName="del" CommandArgument='<%# Eval("id") %>'><i class="fa fa-trash"></i></asp:LinkButton>
                                                </center>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


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
     
</asp:Content>

