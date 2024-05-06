<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="createcashadvance.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.AdminKiosk.createcashadvance" %>
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
         Request
         <small>Request Form</small>
     </h1>
     <ol class="breadcrumb">
        <li><a href="../../Default_kioskAdmin.aspx"><i class="fa fa-dashboard"></i> Dashboard</a></li>
        <li class="active">Request Form</li>
    </ol>
</section>
<section class="content">
    <div class="box box-primary">
        <div class="box-header">


<div class="" id="yw0">
<div class="portlet-content">
<ul class="nav nav-pills"><li class=""><a href="adminhtli.aspx"><i class="icon-th-list"></i> List</a></li></ul></div>
</div>        </div>
        <div class="box-body">


<div class="form">


		<legend>
			<p class="note">Fields with <span class="required text-red">**</span> are required.</p>
		</legend>

		
	<div class="container showgrid">
		<div class="col-lg-6">
		<div class="form-group">
			
			<div class="control-group ">
            <label class="control-label" for="Cash_ref_no">Reference Number</label>
            <div class="controls">
            <input class="form-control" maxlength="30" name="Cash[ref_no]" id="Cash_ref_no" type="text" runat= "server">
            </div>
            </div>			
            <div class="control-group ">
            <label class="control-label" for="Cash_particular">Particulars</label>
            <div class="controls">
            <input class="form-control" maxlength="30" name="Cash[particular]" id="Cash_particular" type="text" runat= "server">
            </div>
            </div>			
            <div class="control-group ">
            <label class="control-label" for="Cash_coa_acct_no">COA Account Number</label>
            <div class="controls">
            <input class="form-control" maxlength="30" name="Cash[coa_acct_no]" id="Cash_coa_acct_no" type="text" runat= "server">
            </div>
            </div>			
            <div class="control-group ">
            <label class="control-label required" for="Cash_amount">Amount <span class="required text-red">**</span></label>
            <div class="controls">
            <input class="form-control" maxlength="30" name="Cash[amount]" id="Cash_amount" type="text" runat= "server">
            </div>
            </div>    			
            <div class="control-group ">
            <label class="control-label required" for="Cash_reason">Reason <span class="required text-red">**</span></label>
            <div class="controls">
            <textarea class="form-control" maxlength="250" rows="3" name="Cash[reason]" id="Cash_reason" runat= "server" >
            </textarea>
            </div>
            </div>            
            </div>
		</div>

		<div class="col-lg-6">

	
			
		<label for="Cash_type" class="required">Type <span class="required text-red">**</span></label>		
        <select name="Cash[type]" id="Cash_type" runat= "server">
            <option value="empty">--- Select Type of form ---</option>
            <option value="Cash Advance">Cash Advance</option>
            <option value="Reimbursement">Reimbursement</option>
        </select>		
		</div>
	</div>


	<div class="form-actions">
		<%--<button class="btn btn-primary" type="submit" name="yt0"><i class="icon-ok icon-white"></i> Request</button>              
        <button class="btn" type="reset" name="yt1"><i class="icon-remove"></i> Cancel</button>--%>
        <asp:Button ID="btnRequest" class="btn btn-primary" runat="server" Text="Request" onclick="btnRequest_Click" ></asp:Button>
        <asp:Button ID="btnReset" class="btn btn-primary" runat="server" Text="Reset" onclick="btnReset_Click" ></asp:Button>
        </div>
        

</div><!-- form -->            
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
