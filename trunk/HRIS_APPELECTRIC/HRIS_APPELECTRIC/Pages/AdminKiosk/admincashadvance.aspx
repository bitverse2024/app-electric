<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="admincashadvance.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.AdminKiosk.admincashadvance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <aside class="right-side">
          <!-- Small boxes (Stat box) -->
          <div class="row">
	<div class="col-lg-12">
		<div id="content">
			
<section class="content-header">
     <h1>
         Admin
         <small>Positions</small>
     </h1>
     <ol class="breadcrumb">
        <li><a href="../../Default_kioskAdmin.aspx"><i class="fa fa-dashboard"></i> Admin</a></li>
        <li class="active">Positions</li>
    </ol>
</section>

<section class="content">
    <div class="box box-primary">
        <div class="box-header">

<div class="" id="yw0">
<div class="portlet-content">
<ul class="nav nav-pills"><li class=""><a href="createcashadvance.aspx"><i class="icon-plus"></i> Request</a></li><li class="active"><a href="admincashadvance.aspx"><i class="icon-th-list"></i> List</a></li></ul></div>
</div>

</div>

<div class="box-body">
    <a id="A1" class="btn btn-app" runat="server" onserverclick="btnExport_Click">
                <i class="fa fa-file-excel-o"></i>
                Export to Excel
            </a>

            <%--<a href="<%= ResolveUrl("~/Pages/Admin/Employee/ImportEmployeeList.aspx")%>" class="btn btn-app">
                <i class="fa fa-file-excel-o"></i>
                Import
            </a>
            
            <a id="A2" class="btn btn-app search-button" runat="server" onserverclick="btnSearch_Click">
                <i class="fa fa-search"></i>
                Advanced Search
            </a>--%>
        <hr />

		<div class="search-form" style="display:none">
		
<div class="wide form">


<input type="hidden" value="cash/index" name="r">
	<div class="row">
		<label for="Cash_id">ID</label>		<input name="Cash[id]" id="Cash_id" type="text">	</div>

	<div class="row">
		<label for="Cash_requested_by">Requested By</label>		<input size="60" maxlength="60" name="Cash[requested_by]" id="Cash_requested_by" type="text">	</div>

	<div class="row">
		<label for="Cash_date_requested">Date Requested</label>		<input size="30" maxlength="30" name="Cash[date_requested]" id="Cash_date_requested" type="text">	</div>

	<div class="row">
		<label for="Cash_type">Type</label>		<input size="60" maxlength="60" name="Cash[type]" id="Cash_type" type="text">	</div>

	<div class="row">
		<label for="Cash_amount">Amount</label>		<input size="30" maxlength="30" name="Cash[amount]" id="Cash_amount" type="text">	</div>

	<div class="row">
		<label for="Cash_reason">Reason</label>		<input size="60" maxlength="200" name="Cash[reason]" id="Cash_reason" type="text">	</div>

	<div class="row buttons">
		<input type="submit" name="yt0" value="Search">	</div>


</div><!-- search-form -->		</div><!-- search-form -->


		<div id="display-grid" class="grid-view">
    <div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>
    <asp:GridView ID="GridViewList" runat="server" AutoGenerateColumns="False" 
                                                ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                ForeColor="Black" onrowcommand="GridViewList_RowCommand"
                                                onpageindexchanging="GridViewList_PageIndexChanging"
                                                ViewStateMode="Enabled">
                                                        <EmptyDataTemplate><center><h1>NO DATA AVAILABLE</h1></center></EmptyDataTemplate> 
                                                            <Columns>
                                                                    <asp:TemplateField Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="lnkdate_requested" Text='Date Requested' runat="server" CommandName="Sort" CommandArgument="date_requested"></asp:LinkButton><br />
                                                                            <asp:TextBox ID="txtSearchdate_requested"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbldate_requested" Text='<%# Eval("date_requested") %>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="lnktype" Text='Type' runat="server" CommandName="Sort" CommandArgument="type"></asp:LinkButton><br />
                                                                            <asp:TextBox ID="txtSearchtype"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbltype" Text='<%# Eval("type") %>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="lnkamount" Text='Amount' runat="server" CommandName="Sort" CommandArgument="amount"></asp:LinkButton><br />
                                                                            <asp:TextBox ID="txtSearchamount"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblamount" Text='<%# Eval("amount") %>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="lnkreason" Text='Reason' runat="server" CommandName="Sort" CommandArgument="reason"></asp:LinkButton><br />
                                                                            <asp:TextBox ID="txtSearchreason"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblreason" Text='<%# Eval("reason") %>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                 
                                                          

                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="lblReset" Text='Reset' runat="server" CommandName="Reset" CommandArgument="Reset"></asp:LinkButton><br />
                                                                            
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%--<asp:Button ID="btnView" CssClass="btn-success btn-xs" runat="server" Text="View"  CommandName="view" CommandArgument='<%# Eval("id") %>'  />
                                                                            <asp:Button ID="btnUpdate" CssClass="btn-success btn-xs" runat="server" Text="Update"   CommandName="upd" CommandArgument='<%# Eval("id") %>'  />--%>
                                                                            <asp:Button ID="btnDelete" CssClass="btn-danger btn-xs" runat="server" Text="Delete"  CommandName="del" CommandArgument='<%# Eval("id") %>'  />
                                                                        </ItemTemplate>
                                                                       
                                                                    </asp:TemplateField>    
                                                
                                                                                                                    
                                                </Columns>
                                            </asp:GridView>

</div>
</div>

</div>
</section>
</div>		</div><!-- content -->
	</div>
	<div class="col-lg-6">
		<div id="sidebar">
				
		
		</div><!-- sidebar -->
	</div>
</aside>
</asp:Content>
