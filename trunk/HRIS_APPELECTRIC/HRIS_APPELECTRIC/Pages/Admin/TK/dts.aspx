<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="dts.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.TK.dts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .pagination-ae table > tbody > tr > td > a,
        .pagination-ae table > tbody > tr > td > span {
            color: #000; 
            background-color: #808080; 
            border: 1px solid #dddddd;
            cursor: default;

        }

    </style>
    <style>
       .pagination-ys {
    /*display: inline-block;*/
    padding-left: 0;
    margin: 20px 0;
    border-radius: 4px;
}

.pagination-ys table > tbody > tr > td {
    display: inline;
}

.pagination-ys table > tbody > tr > td > a,
.pagination-ys table > tbody > tr > td > span {
    position: relative;
    float: left;
    padding: 8px 12px;
    line-height: 1.42857143;
    text-decoration: none;
    color: #dd4814;
    background-color: #ffffff;
    border: 1px solid #dddddd;
    margin-left: -1px;
}

.pagination-ys table > tbody > tr > td > span {
    position: relative;
    float: left;
    padding: 8px 12px;
    line-height: 1.42857143;
    text-decoration: none;    
    margin-left: -1px;
    z-index: 2;
    color: #aea79f;
    background-color: #f5f5f5;
    border-color: #dddddd;
    cursor: default;
}

.pagination-ys table > tbody > tr > td:first-child > a,
.pagination-ys table > tbody > tr > td:first-child > span {
    margin-left: 0;
    border-bottom-left-radius: 4px;
    border-top-left-radius: 4px;
}

.pagination-ys table > tbody > tr > td:last-child > a,
.pagination-ys table > tbody > tr > td:last-child > span {
    border-bottom-right-radius: 4px;
    border-top-right-radius: 4px;
}

.pagination-ys table > tbody > tr > td > a:hover,
.pagination-ys table > tbody > tr > td > span:hover,
.pagination-ys table > tbody > tr > td > a:focus,
.pagination-ys table > tbody > tr > td > span:focus {
    color: #97310e;
    background-color: #eeeeee;
    border-color: #dddddd;
}
    </style>
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
    <div class="col-md-12">
        <div class="content">
            <div class="container-fluid">
                <div class="container"></div>
                <h1 class="m-0 text-dark">DTR<small> Employee's DTR</small></h1>
                <section class="card">
                    <div class="card-header">
                        <a href="#" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/TK/uploaddtr.aspx")%>" class="btn btn-default"><i class="fa fa-download"></i><span class="h6">Upload DTR</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/TK/mergedtr.aspx")%>" class="btn btn-default"><i class="fa fa-print"></i><span class="h6">Merge DTR</span></a>
                       <%-- <a href="<%= ResolveUrl("~/Pages/Admin/TK/computedtr.aspx")%>" class="btn btn-default"><i class="fa fa-list-ol"></i><span class="h5">Compute DTR</span></a>--%>
                        <a href="<%= ResolveUrl("~/Pages/Admin/TK/createsummary.aspx")%>" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">Create Summary</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/TK/dtr_summary.aspx")%>" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">DTR Summary</span></a>
                        <a runat="server" onserverclick="btnExport_Click" class="btn btn-default"><i class="fa fa-arrow-circle-o-up"></i><span class="h6">Export to Excel</span></a>

                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div id="display-grid" class="grid-view">
                                    <div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>
                                    <asp:GridView ID="GridViewList" runat="server" AutoGenerateColumns="False"
                                        ShowFooter="True" CssClass="items table table-striped table-bordered table-hover"
                                        GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                        ForeColor="Black" OnRowCommand="GridViewList_RowCommand"
                                        OnPageIndexChanging="GridViewList_PageIndexChanging"
                                        ViewStateMode="Enabled" PageSize="10">
                                        <PagerStyle HorizontalAlign = "Center" />
                                        <%--<PagerStyle CssClass="pagination-ae" />--%>
                                        <%--<PagerStyle CssClass="pagination-ys" />--%>
                                        <%--<PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />--%>
                                        <%--<PagerStyle HorizontalAlign = "Center" CssClass="GridPager GridPager-Danger" />--%>
                                        <%--<PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />--%>
                                        
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
                                                    <asp:LinkButton ID="lnkFullName" CssClass="h8" Text='FullName' runat="server" CommandName="Sort" CommandArgument="FullName"></asp:LinkButton><br />
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
