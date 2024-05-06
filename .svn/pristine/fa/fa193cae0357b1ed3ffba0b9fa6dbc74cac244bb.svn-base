<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AbsentSummary.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Reports.AbsentSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        /*gridview*/
        /*.table table > tbody > tr > td {
            display: inline-block;

        }*/
        .table {
            /*display: inline-block;*/
            padding-left: 0;
            margin: 20px 0;
            border-radius: 4px;
        }
.table table > tbody > tr > td > a ,
.table table > tbody > tr > td > span {
position: relative;
float: left;
padding: 6px 12px;
margin-left: -1px;
line-height: 1.42857143;
color: #337ab7;
text-decoration: none;
background-color: #fff;
border: 1px solid #ddd;


}

.table table > tbody > tr > td > span {
z-index: 3;
color: #fff;
cursor: default;
background-color: #337ab7;
border-color: #337ab7;


}

.table table > tbody > tr > td:first-child > a,
.table table > tbody > tr > td:first-child > span {
margin-left: 0;
border-top-left-radius: 4px;
border-bottom-left-radius: 4px;
}

.table table > tbody > tr > td:last-child > a,
.table table > tbody > tr > td:last-child > span {
border-top-right-radius: 4px;
border-bottom-right-radius: 4px;
}

.table table > tbody > tr > td > a:hover,
.table   table > tbody > tr > td > span:hover,
.table table > tbody > tr > td > a:focus,
.table table > tbody > tr > td > span:focus {
z-index: 2;
color: #23527c;
background-color: #eee;
border-color: #ddd;
}
/*end gridview */
    </style>
    <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6"></div>
                <div class="col-sm-6"></div>
            </div>
        </div>
    </div>

    <div class="" id="yw0">
        <div class="printableArea">
            <ul class="nav nav-pills" style="padding-left: 10px;">
                <li class=""></li>
            </ul>
        </div>
    </div>
    <div class="col-md-12">
        <div class="content">
            <div class="container-fluid">
                <div class="container"></div>
                <h3 class="m-0 text-dark">Reports<small> Absent Summary</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="ReportsPage.aspx" class="btn btn-default"><i class="fa fa-cog"></i><span class="h6">Back to Reports</span></a>
                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="row">
                                    <div class="col-md-6">
                                        <!-- general form elements -->
                                        <div class="box box-primary">
                                            <div class="box-header">
                                                <h5 class="box-title">Select Date</h5>
                                            </div>
                                            <!-- /.box-header -->
                                            <div class="form-group">
                                                <span class="h5">
                                                    <label>Start Date:</label></span>
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        <i class="fa fa-calendar"></i>
                                                    </div>
                                                    <input style="height: 30px;" class="form-control" id="txt_txtStartDate" type="date" min="1990-01-01" max="2099-12-31" runat="server">
                                                </div>
                                                <!-- /.input group -->
                                            </div>
                                            <div class="form-group">
                                                <span class="h5">
                                                    <label>End Date:</label></span>
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        <i class="fa fa-calendar"></i>
                                                    </div>
                                                    <input style="height: 30px;" class="form-control" id="txt_txtEndDate" type="date" min="1990-01-01" max="2099-12-31" runat="server">
                                                </div>
                                                <!-- /.input group -->
                                            </div>
                                            <div class="form-group">
                                                <span class="h5">
                                                    <label>Department:</label></span>
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        <i class="fa fa-building"></i>
                                                    </div>
                                                    <asp:DropDownList ID="ddlDept" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="" Text="ALL"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <%--<select class="form-control" name="DTS[DeptCode]" id="ddlDept" runat="server">
                    <option value="0">ALL</option>
                    </select>--%>
                                                </div>
                                                <!-- /.input group -->
                                            </div>
                                            <div class="form-group">
                                                <span class="h5">
                                                    <label>Company:</label></span>
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        <i class="fa fa-building"></i>
                                                    </div>
                                                    <asp:DropDownList ID="ddlComp" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="" Text="ALL"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <%--<select class="form-control" name="DTS[AssignmentCode]" id="ddlComp" runat="server">
                    <option value="0">ALL</option>
                    </select>--%>
                                                </div>
                                                <!-- /.input group -->
                                                <br />
                                                <div class="footer">
                                                    <asp:Button ID="btnSearch" runat="server" class="btn btn-info" Text="Search"
                                                        OnClick="btnSearch_Click"></asp:Button>
                                                    <asp:Button ID="btnExport" runat="server" class="btn btn-info"
                                                        Text="Export to Excel" OnClick="btnExport_Click"></asp:Button>
                                                     <asp:Button ID="btnPDFExport" runat="server" class="btn btn-info"
                                                        Text="Export to PDF" OnClick="btnPDFExport_Click"></asp:Button>
                                                </div>

                                            </div>

                                        </div>
                                    </div>
                                </div>
                                  <div id="list" class="box-body">
                                   <div style="overflow-x: auto;" id="display-grid" class="grid-view">
                                        <div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>
                                        <%--<div class="right-side">Summary of Active Employees as of <%=year%>.</div>--%>
                                        <asp:GridView ID="GridSummaryList" runat="server" AutoGenerateColumns="False"
                                            ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                            GridLines="None" AllowPaging="True" Font-Names="Segoe UI" OnPageIndexChanging="GridSummaryList_PageIndexChanging"
                                            OnRowCommand="GridViewList_RowCommand"
                                            ForeColor="Black"
                                            ViewStateMode="Enabled" PageSize="10">
                                            <EmptyDataTemplate>
                                                <center><h1>NO ABSENT AVAILABLE</h1></center>
                                            </EmptyDataTemplate>
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-Width="120px">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkName" Width="200px" CssClass="h8" Text='Name' runat="server" CommandName="Sort" CommandArgument="Name"></asp:LinkButton><br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" CssClass="h5" Text='<%# Eval("Name") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkPosition" CssClass="h8" Text='Position' runat="server" CommandName="Sort" CommandArgument="Position"></asp:LinkButton><br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPosition" CssClass="h5" Text='<%# Eval("Position") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkDepartment" CssClass="h8" Text='Department' runat="server" CommandName="Sort" CommandArgument="Department"></asp:LinkButton><br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDepartment" CssClass="h5" Text='<%# Eval("Department") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkAbsent" CssClass="h8" Text='Absent Days' runat="server" CommandName="Sort" CommandArgument="Absent"></asp:LinkButton><br />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAbsent" CssClass="h5" Text='<%# Eval("Absent") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>

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
