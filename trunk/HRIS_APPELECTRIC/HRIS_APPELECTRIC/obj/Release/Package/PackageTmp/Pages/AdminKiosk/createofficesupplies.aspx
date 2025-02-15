﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="createofficesupplies.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.AdminKiosk.createofficesupplies" %>
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
         <small>Add New Supply</small>
     </h1>
     <ol class="breadcrumb">
        <li><a href="adminofficesupplies.aspx"><i class="fa fa-dashboard"></i> Office Supply Requisition</a></li>
        <li class="active">Add New Supply</li>
    </ol>
</section>




<section class="content">
    <div class="box box-primary">
        <div class="box-header">
            <h4 class="box-title"></h4>
            <div class="" id="yw0">
<div class="portlet-content">
<ul class="nav nav-pills">
<li class="">
<a href="adminofficesupplies.aspx"><i class="icon-th-list"></i> Back to List</a>
</li>
<li class="">
<%--<a href="http://dataland.bit-verse.com/index.php?r=officesupplies/create">
<i class="icon-plus"></i> Add new</a>
</li>--%>
</ul></div>
</div>		</div>
		
			<div class="box-body">

				
<div class="form">


		<fieldset>
		<legend>
			<p class="note">Fields with <span class="required text-red">**</span> are required.</p>
		</legend>

		
	<div class="row">
		<div class="col-lg-6">

		<div class="control-group "><label class="control-label" for="Officesupplies_item_Name">Item Name</label>
            <div class="controls">
            <input class="form-control" maxlength="100" name="Officesupplies[item_Name]" id="Officesupplies_item_Name" type="text" runat="server">
            </div>
        </div>		
        <div class="control-group "><label class="control-label required" for="Officesupplies_quantity">Quantity <span class="required text-red">**</span></label>
            <div class="controls">
            <input class="form-control" maxlength="11" name="Officesupplies[quantity]" id="Officesupplies_quantity" type="text" runat="server">
            </div>
        </div>
		
		</div>
	</div>


	<div class="form-actions">
        <asp:Button ID="btnCreate" class="btn btn-primary" runat="server" Text="Save" onclick="btnCreate_Click" ></asp:Button>
        <asp:Button ID="btnReset" class="btn btn-primary" runat="server" Text="Reset" onclick="btnReset_Click" ></asp:Button>
		
    </div>
	</fieldset>


</div><!-- form -->			</div>
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
