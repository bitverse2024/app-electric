<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeListForScheduler.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.TK.EmployeeListForScheduler" %>
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
                <h1 class="m-0 text-dark">Scheduler<small> Employee's Scheduler</small></h1>
                <section class="card">
                    <div class="card-header">
                        <a href="EmployeeListForScheduler.aspx" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                        <%if (Session["EMP_ID"].ToString() == "00000")
                            { %>
                        <a href="<%= ResolveUrl("~/Pages/Admin/TK/scheduler.aspx")%>" class="btn btn-default"><i class="fa fa-upload"></i><span class="h6">Upload Bulk Schedule</span></a>
                        <%} %>
                        

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
                                            <center><h1>NO USERS AVAILABLE</h1></center>
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkempid" CssClass="h8" Text='Employee No' runat="server" CommandName="Sort" CommandArgument="empid"></asp:LinkButton><br />
                                                    <asp:TextBox ID="txtSearchempid" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblid" CssClass="h6" Text='<%# Eval("empid") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkFullName" CssClass="h8" Text='Full Name' runat="server" CommandName="Sort" CommandArgument="FullName"></asp:LinkButton><br />
                                                    <asp:TextBox ID="txtSearchFullName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFullName" CssClass="h6" Text='<%# Eval("FullName") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkCompany" CssClass="h8" Text='Company' runat="server" CommandName="Sort" CommandArgument="Company"></asp:LinkButton><br />
                                                    <asp:TextBox ID="txtSearchCompany" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompany" CssClass="h6" Text='<%# Eval("Company") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <%--<asp:Button ID="btnView" CssClass="btn-success btn-xs" runat="server" Text="View"  CommandName="view" CommandArgument='<%# Eval("id") %>'  />
                                                                            <asp:Button ID="btnUpdate" CssClass="btn-success btn-xs" runat="server" Text="Update"   CommandName="upd" CommandArgument='<%# Eval("id") %>'  />--%>
                                                    <asp:LinkButton ID="btnView" CssClass="fa fa-eye" runat="server" ForeColor="Black" CommandName="view" CommandArgument='<%# Eval("empid") %>' />
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
