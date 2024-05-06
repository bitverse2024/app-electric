<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="adminsuppliesrequest.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.AdminKiosk.adminsuppliesrequest" %>
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
        Office Supplies Requests
        <small></small>
    </h1>
    
    <ol class="breadcrumb">
        <li><a href="../../Default_kioskAdmin.aspx"><i class="fa fa-dashboard"></i> Admin</a></li>
        <li class="active">Office Supplies Requests</li>
    </ol>
</section>

<section class="content">
    <div class="box box-primary">
        <div class="box-header">

            <div class="" id="yw0">
<div class="portlet-content">
<ul class="nav nav-pills"><li class="active"><a href="#"><i class="fa fa-th-list"></i><span class="h6">List</span></a></li>
<li><a id="A1" runat="server" onserverclick="btnExport_Click"><i class="fa fa-arrow-circle-o-down"></i><span class="h6">Export to Excel</span></a></li>
</ul></div>
</div>

		</div>
		
		<div class="box-body">
        
            <hr />

                        <div class="search-form" style="display:none">
                        
<div class="wide form">


<input type="hidden" value="supplyrequest/index" name="r">
	<div class="row">
		<label for="Supplyrequest_id">ID</label>		<input name="Supplyrequest[id]" id="Supplyrequest_id" type="text">	</div>

	<div class="row">
		<label for="Supplyrequest_item_id">Item</label>		<input size="20" maxlength="20" name="Supplyrequest[item_id]" id="Supplyrequest_item_id" type="text">	</div>

	<div class="row">
		<label for="Supplyrequest_item_Name">Item Name</label>		<input size="60" maxlength="100" name="Supplyrequest[item_Name]" id="Supplyrequest_item_Name" type="text">	</div>

	<div class="row">
		<label for="Supplyrequest_quantity">Quantity</label>		<input size="20" maxlength="20" name="Supplyrequest[quantity]" id="Supplyrequest_quantity" type="text">	</div>

	<div class="row">
		<label for="Supplyrequest_requested_By">Requested By</label>		<input size="60" maxlength="100" name="Supplyrequest[requested_By]" id="Supplyrequest_requested_By" type="text">	</div>

	<div class="row">
		<label for="Supplyrequest_date_Requested">Date Requested</label>		<input size="50" maxlength="50" name="Supplyrequest[date_Requested]" id="Supplyrequest_date_Requested" type="text">	</div>

	<div class="row">
		<label for="Supplyrequest_status">Status</label>		<input size="20" maxlength="20" name="Supplyrequest[status]" id="Supplyrequest_status" type="text">	</div>

	<div class="row">
		<label for="Supplyrequest_date_Served">Date Served</label>		<input size="50" maxlength="50" name="Supplyrequest[date_Served]" id="Supplyrequest_date_Served" type="text">	</div>

	<div class="row buttons">
		<input type="submit" name="yt0" value="Search">	</div>


</div><!-- search-form -->                        
</div><!-- search-form -->

                    
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
                                                                            <asp:LinkButton ID="lnkdepartment" CssClass="h8" Text='Department' runat="server" CommandName="Sort" CommandArgument="department"></asp:LinkButton><br />
                                                                            <asp:TextBox ID="txtSearchdepartment"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbldepartment" CssClass="h5" Text='<%# Eval("department") %>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="lnkitem_Name" CssClass="h8" Text='Item Name' runat="server" CommandName="Sort" CommandArgument="item_Name"></asp:LinkButton><br />
                                                                            <asp:TextBox ID="txtSearchitem_Name"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblitem_Name" CssClass="h5" Text='<%# Eval("item_Name") %>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="lnkquantity" CssClass="h8" Text='Quantity' runat="server" CommandName="Sort" CommandArgument="quantity"></asp:LinkButton><br />
                                                                            <asp:TextBox ID="txtSearchquantity"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblquantity" CssClass="h5" Text='<%# Eval("quantity") %>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="lnkrequested_By" CssClass="h8" Text='Requested By' runat="server" CommandName="Sort" CommandArgument="requested_By"></asp:LinkButton><br />
                                                                            <asp:TextBox ID="txtSearchrequested_By"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblrequested_By" CssClass="h5" Text='<%# Eval("requested_By") %>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="lnkdate_Requested" CssClass="h8" Text='Date Requested' runat="server" CommandName="Sort" CommandArgument="date_Requested"></asp:LinkButton><br />
                                                                            <asp:TextBox ID="txtSearchdate_Requested"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbldate_Requested" CssClass="h5" Text='<%# Eval("date_Requested") %>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="lnkstatus" CssClass="h8" Text='Status' runat="server" CommandName="Sort" CommandArgument="status"></asp:LinkButton><br />
                                                                            <asp:TextBox ID="txtSearchstatus"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblstatus" CssClass="h5" Text='<%# Eval("status") %>' runat="server"></asp:Label>
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
</section>		</div><!-- content -->
	</div>
	<div class="col-lg-6">
		<div id="sidebar">
				
		
		</div><!-- sidebar -->
	</div>
</div>
 
          <!-- /.row (main row) -->
        </aside>

</asp:Content>
