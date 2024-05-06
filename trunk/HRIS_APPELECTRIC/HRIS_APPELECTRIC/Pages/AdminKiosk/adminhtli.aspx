<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="adminhtli.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.AdminKiosk.adminhtli" %>
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
                <h3 class="m-0 text-dark">Admin<small> HTLI</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="/../../Default_kioskAdmin.aspx" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Back</span></a>
                        <a href="createhtli.aspx" class="btn btn-default"><i class="fa fa-plus-circle"></i><span class="h6">Add</span></a>
                        <a href="#" class="btn btn-default"><i class="fa fa-th-list"></i><span class="h6">List</span></a>
                        <a href="#" class="btn btn-default" onserverclick="btnExport_Click"><i class="fa fa-download"></i><span class="h6">Export to Excel</span></a>
                        <a href="#" class="btn btn-default" onserverclick="ExportToPDF"><i class="fa fa-download"></i><span class="h6">Export to PDF</span></a>
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
                                        OnPageIndexChanging="GridViewList_PageIndexChanging"
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
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkName" Text='Name' runat="server" CommandName="Sort" CommandArgument="Name"></asp:LinkButton><br />
                                                    <%--<asp:TextBox ID="txtSearchName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>--%>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" Text='<%# Eval("Name") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkPositione" Text='Position' runat="server" CommandName="Sort" CommandArgument="Position"></asp:LinkButton><br />
                                                    <%--<asp:TextBox ID="txtSearchPosition" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>--%>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPosition" Text='<%# Eval("Position") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkCp_Number" Text='CP Number' runat="server" CommandName="Sort" CommandArgument="Cp_Number"></asp:LinkButton><br />
                                                    <%--<asp:TextBox ID="txtSearchCp_Number" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>--%>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCp_Number" Text='<%# Eval("Cp_Number") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkPhone_Number" Text='Phone Number' runat="server" CommandName="Sort" CommandArgument="Phone_Number"></asp:LinkButton><br />
                                                    <%--<asp:TextBox ID="txtSearchPhone_Number" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>--%>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPhone_Number" Text='<%# Eval("Phone_Number") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkEmail" Text='Email' runat="server" CommandName="Sort" CommandArgument="Email"></asp:LinkButton><br />
                                                    <%--<asp:TextBox ID="txtSearchEmail" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>--%>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" Text='<%# Eval("Email") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>



                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lblReset" Text='' runat="server" CommandName="Reset" CommandArgument="Reset"></asp:LinkButton><br />

                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%--<asp:Button ID="btnView" CssClass="btn-success btn-xs" runat="server" Text="View"  CommandName="view" CommandArgument='<%# Eval("id") %>'  />
                                                                            <asp:Button ID="btnUpdate" CssClass="btn-success btn-xs" runat="server" Text="Update"   CommandName="upd" CommandArgument='<%# Eval("id") %>'  />--%>
                                                    <asp:Button ID="btnDelete" CssClass="btn-danger btn-xs" runat="server" Text="Delete" CommandName="del" CommandArgument='<%# Eval("id") %>' />
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
