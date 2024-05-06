<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="adminofficesupplies.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.AdminKiosk.adminofficesupplies" %>
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
        Office Supplies Requisition
        <small></small>
    </h1>
    
    <ol class="breadcrumb">
        <li><a href="../../Default_kioskAdmin.aspx"><i class="fa fa-dashboard"></i> Admin</a></li>
        <li class="active">  Office Supplies Requisition</li>
    </ol>
</section>


<section class="content">
    <div class="box box-primary">
        <div class="box-header">

            <div class="" id="yw0">
<div class="portlet-content">
<ul class="nav nav-pills"><li class=""><a href="createofficesupplies.aspx"><i class="fa fa-plus"></i><span class="h6">Create</span></a></li>
<li class="active"><a href="#"><i class="fa fa-th-list"></i><span class="h6">List</span></a></li>
<li> <a id="A1" runat="server" onserverclick="btnExport_Click"><i class="fa fa-arrow-circle-o-down"></i><span class="h6">Export to Excel</span></a></li>
</ul></div>
</div>

		</div>
		
		<div class="box-body">
        

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


<input type="hidden" value="officesupplies/index" name="r">
	<div class="row">
		<label for="Officesupplies_id">ID</label>		<input name="Officesupplies[id]" id="Officesupplies_id" type="text">	</div>

	<div class="row">
		<label for="Officesupplies_item_Name">Item Name</label>		<input size="60" maxlength="100" name="Officesupplies[item_Name]" id="Officesupplies_item_Name" type="text">	</div>

	<div class="row">
		<label for="Officesupplies_quantity">Quantity</label>		<input size="11" maxlength="11" name="Officesupplies[quantity]" id="Officesupplies_quantity" type="text">	</div>

	<div class="row buttons">
		<input type="submit" name="yt0" value="Search">	</div>


</div><!-- search-form -->                        </div><!-- search-form -->
                        
                   
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
                                                                        <ItemTemplate>
                                                                            <%--<asp:Button ID="btnView" CssClass="btn-success btn-xs" runat="server" Text="View"  CommandName="view" CommandArgument='<%# Eval("id") %>'  />--%>
                                                                           <%-- <asp:Button ID="btnUpdate" CssClass="btn-success btn-xs" runat="server" Text="Update"   CommandName="upd" CommandArgument='<%# Eval("id") %>'  />
                                                                            <asp:Button ID="btnDelete" CssClass="btn-danger btn-xs" runat="server" Text="Delete"  CommandName="del" CommandArgument='<%# Eval("id") %>'  />--%>
                                                                            <center>			                                                                    
			                                                                    <asp:LinkButton ID="btnUpdate" runat="server" ForeColor="Black" Font-Size="Medium" CommandName="upd" CommandArgument='<%# Eval("id") %>'><i class="fa fa-edit"></i></asp:LinkButton>&ensp;
			                                                                    <asp:LinkButton ID="btnDelete" runat="server" ForeColor="Black" Font-Size="Medium" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;"  CommandName="del" CommandArgument='<%# Eval("id") %>'><i class="fa fa-trash"></i></asp:LinkButton>
		                                                                    </center>
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
        
<div class="modal fade" id="listmodal">
    <div class="modal-dialog">
        <div class="modal-content">

            <asp:UpdatePanel ID="upListDetails" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                <ContentTemplate>
                    
                    <div class="modal-header">
                        <asp:LinkButton ID="lnkbtnXlist" CssClass ="close" runat="server" 
                            onclick="lnkbtnXlist_Click" >
                            <span>&times;</span>
                        </asp:LinkButton>
                        <h4 class="modal-title"><asp:Label ID="Label3" runat="server" Text="Edit Information"></asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <asp:HiddenField ID="HiddenEmpID" runat="server" />
                     <div class="row">
	                    <!-- Input Text to update -->

  	                    <div class="col-lg-6">
                            <label><label for="upd_item_Name" class="required">Item Name<span class="required"></span></label></label>
    	                        
    		
			                        <input style="height:20px;" class="form-control" id="upd_item_Name" name="txtitem_Name" type="text" runat="server"/>
                	            
    	
                        </div>

                        <div class="col-lg-6">
                            <label><label for="upd_quantity" class="required">quantity<span class="required">*
                            <asp:RequiredFieldValidator ID="validatorUploader" runat="server" ControlToValidate="upd_quantity"  ValidationGroup="UpdateOfficeSupplyGroup" ForeColor="Red" ErrorMessage="Field Required" ></asp:RequiredFieldValidator></span></label></label>
    	                        <div class="input-group date">
                                    <input style="height:20px;" class="form-control" id="upd_quantity" name="txtquantity" type="text" runat="server"/>
                	            </div>
                                </div>
                        </div>
	
                        
                    </div>
                    <div class="modal-footer">
                       <asp:Button ID="btnsaveUpdate" runat="server" Text="Update" 
                            onclick="btnsaveUpdate_Click" validationgroup = "UpdateOfficeSupplyGroup"></asp:Button>
                           
                       
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
