<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="contributions.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.PayrollPages.contributions" %>

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
                <h3 class="m-0 text-dark">Payroll<small> Contributions</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="contributions.aspx" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>

                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="box-body">
                                    <div class="form">

                                        <fieldset>
                                            <%--<legend>
                                                <p class="note">Fields with <span class="required text-red">**</span> are required.</p>
                                            </legend>--%>


                                            <div class="row">
                                                <div class="form col-lg-4">
                                                    <label for="lblMonth" class="required">
                                                        Month
                                                    </label>
                                                    <asp:DropDownList ID="ddlMonth" CssClass="form-control" runat="server" Width="300px">
                                                        <asp:ListItem Value="" Text="--- All ---"></asp:ListItem>
                                                        <asp:ListItem Value="01" Text="January"></asp:ListItem>
                                                        <asp:ListItem Value="02" Text="February"></asp:ListItem>
                                                        <asp:ListItem Value="03" Text="March"></asp:ListItem>
                                                        <asp:ListItem Value="04" Text="April"></asp:ListItem>
                                                        <asp:ListItem Value="05" Text="May"></asp:ListItem>
                                                        <asp:ListItem Value="06" Text="June"></asp:ListItem>
                                                        <asp:ListItem Value="07" Text="July"></asp:ListItem>
                                                        <asp:ListItem Value="08" Text="August"></asp:ListItem>
                                                        <asp:ListItem Value="09" Text="September"></asp:ListItem>
                                                        <asp:ListItem Value="10" Text="October"></asp:ListItem>
                                                        <asp:ListItem Value="11" Text="November"></asp:ListItem>
                                                        <asp:ListItem Value="12" Text="Decemver"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form col-lg-6">
                                                    <label for="lblYear" class="required">Year</label><br />
                                                    <asp:DropDownList ID="ddlYear" CssClass="form-control" runat="server" Width="300px">
                                                        <asp:ListItem Value="" Text="--- All ---"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="form col-lg-4">
                                                    <label for="lblPayGrp" class="required">
                                                        Payroll Group
                                                    </label>
                                                    <asp:DropDownList ID="ddlPayrollGroup" CssClass="form-control" runat="server" Width="300px">
                                                        <asp:ListItem Value="" Text="--- All ---"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form col-lg-6">
                                                    <label for="lblEmp" class="required">Employee </label>
                                                    <br />
                                                    <asp:DropDownList ID="ddlEmp" CssClass="form-control" runat="server" Width="300px">
                                                        <asp:ListItem Value="" Text="--- All ---"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <br />
                                                    <div class="footer">
                                                        <asp:Button ID="btnSearch" runat="server" class="btn btn-info" Text="Search"
                                                            OnClick="btnSearch_Click"></asp:Button>
                                                        <asp:Button ID="btnExport" runat="server" class="btn btn-info"
                                                            Text="Export to Excel" OnClick="btnExport_Click"></asp:Button>
                                                    </div>
                                            <br />
                                            <div id="display-grid" class="grid-view box-body">
                                                <asp:GridView ID="GridContributionList" runat="server" AutoGenerateColumns="False"
                                                    ShowFooter="True" CssClass="table table-bordered table-striped table-responsive p-0 dataTable"
                                                    GridLines="None" AllowPaging="True" Font-Names="Segoe UI" OnRowCommand="GridContributionList_RowCommand"
                                                    ForeColor="Black" OnPageIndexChanging="GridContributionList_PageIndexChanging"
                                                    ViewStateMode="Enabled" PageSize="25" ShowHeader="true" ShowHeaderWhenEmpty="true">
                                                    <EmptyDataTemplate>
                                                        <center><h1>NO DATA AVAILABLE</h1></center>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <%--<asp:Label ID="lblid" Text='<%# Eval("") %>' runat="server"></asp:Label>--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkEmpNo" Text="Employee Number" runat="server" CommandName="Sort" CommandArgument="empID"></asp:LinkButton><br />
                                                                <%--<asp:TextBox ID="txtEmpno" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>--%>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmpno" Width="90px" Text='<%# Eval("empID") %>' runat="server"></asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkEmpName" Text="Employee Name" runat="server" CommandName="Sort" CommandArgument="emp_FullName"></asp:LinkButton><br />
                                                                <%-- <asp:TextBox ID="txtSearchEmpName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>--%>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmpName" Width="90px" Text='<%# Eval("emp_FullName") %>' runat="server"></asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkCODate" Text="Cut Off Date" runat="server" CommandName="Sort" CommandArgument="CODate"></asp:LinkButton><br />
                                                                <%-- <asp:TextBox ID="txtSearchEmpName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>--%>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCoDate" Width="90px" Text='<%# Eval("CODate") %>' runat="server"></asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkSSS" Text="SSS EE" runat="server" CommandName="Sort" CommandArgument="sssEE"></asp:LinkButton><br />
                                                                <%-- <asp:TextBox ID="txtSearchEmpName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>--%>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSSS" Width="90px" Text='<%# Eval("sssEE") %>' runat="server"></asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkPhil" Text="PhilHealth EE" runat="server" CommandName="Sort" CommandArgument="philhealthEE"></asp:LinkButton><br />
                                                                <%-- <asp:TextBox ID="txtSearchEmpName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>--%>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPhil" Width="90px" Text='<%# Eval("philhealthEE") %>' runat="server"></asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkPagibig" Text="Pag-Ibig EE" runat="server" CommandName="Sort" CommandArgument="pagibigEE"></asp:LinkButton><br />
                                                                <%-- <asp:TextBox ID="txtSearchEmpName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>--%>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lnlPagibbig" Width="90px" Text='<%# Eval("pagibigEE") %>' runat="server"></asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>

            </div>
            <!-- content -->
        </div>
    </div>
</asp:Content>
