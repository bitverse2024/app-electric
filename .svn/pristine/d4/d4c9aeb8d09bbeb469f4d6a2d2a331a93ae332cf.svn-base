<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="applicantprofileview.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.HRRecruitment.applicantprofileview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <aside class="right-side">
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
                    <h3 class="m-0 text-dark">Recruitment<small>View Applicant <%=applicantInfo["FullName"] %></small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="../../Default_kioskapplicant.aspx"><i class="fa fa-th-list"></i>List</a>
                            <a href=""><i class="fa fa-edit"></i>Update</a>
                            <a href=""><i class="fa fa-edit"></i>Endorse Applicant</a>
                            <a href=""><i class="fa fa-edit"></i>Hire Applicant</a>
                            <a href="" onserverclick="btn_MarkShortListed_Click" runat="server"><i class="fa fa-check"></i>Mark as Shorlisted</a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="container">
                                        <div class="row">
                                            <section class="col-lg-6">
                                                <div class="box box-widget widget-user-2">
                                                    <!-- Add the bg color to the header using any of the bg-* classes -->
                                                    <div class="widget-user-header bg-blue">
                                                        <div class="widget-user-image">
                                                            <img class="img-circle" src="./recruitmentviewapplicant_files/1.jpg" alt="User Avatar">
                                                        </div>
                                                        <!-- /.widget-user-image -->
                                                        <h3 class="widget-user-username"><%=applicantInfo["FullName"] %></h3>
                                                        <h5 class="widget-user-desc">Position Desired: <%=applicantInfo["PositionDesired"]%>
                                                        </h5>
                                                    </div>
                                                    <div class="box-footer no-padding">
                                                        <ul class="nav nav-stacked">
                                                            <li class="tablinks" onclick="openCity(event, &#39;Personal&#39;)" id="defaultOpen">
                                                                <a data-toggle="modal" data-target="">Personal Information</a>
                                                            </li>
                                                            <li class="tablinks" onclick="openCity(event, &#39;Educ&#39;)">
                                                                <a href="applicanteducation.aspx?id=<%:applicantid %>">Educational Attainment</a>
                                                                <!--<a data-toggle="modal" data-target="#Personnel">Educational Attainment</a>-->
                                                            </li>
                                                            <li class="tablinks" onclick="openCity(event, &#39;Work&#39;)">
                                                                <a href="applicantupdexperience.aspx?id=<%:applicantid %>">Work Experience</a>
                                                                <!--<a data-toggle="modal" data-target="#Payroll">Work experience</a>-->
                                                            </li>
                                                            <li class="tablinks" onclick="openCity(event, &#39;Req&#39;)">
                                                                <!-- <a data-toggle="modal" data-target="#Payroll">Requirments</a> -->
                                                                <a href="applicantselrequirements.aspx?id=<%:applicantid %>">Requirements</a>
                                                            </li>
                                                            <li class="tablinks" onclick="openCity(event, &#39;Req&#39;)">
                                                                <!-- <a data-toggle="modal" data-target="#Payroll">Requirments</a> -->
                                                                <a href="applicantuploadfiles.aspx?id=<%:applicantid %>">Upload Requirements</a>
                                                            </li>
                                                            <li class="tablinks" onclick="openCity(event, &#39;Req&#39;)">
                                                                <a href="applicantviewhistory.aspx?id=<%:applicantid %>">Application History</a>
                                                            </li>
                                                            <li class="tablinks" onclick="openCity(event, &#39;Int&#39;)">
                                                                <a href="applicantupdinterviewer.aspx?id=<%:applicantid %>">Set Applicant's Interviewer</a>
                                                            </li>

                                                            <li class="tablinks" onclick="openCity(event, &#39;Status&#39;)">
                                                                <!-- <a data-toggle="modal" data-target="#Payroll">Interview Status</a> -->
                                                                <a href="applicantinterviewstatus.aspx?id=<%:applicantid %>">Interview Status</a>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>

                                                <div class="box box-success">
                                                    <div class="box-header">
                                                        <h3 class="box-title" style="margin-bottom: 2rem;">Interview Status</h3>
                                                    </div>
                                                    <div style="background-color: white; width: 100%; height: 220px; overflow-x: hidden; overflow-y: scroll;">
                                                        <!--Code for Single data entry-->

                                                        <!--Code for Single data entry end-->
                                                        <!--Loop Data-->
                                                        <div class="row" style="padding: 2px 27px;">
                                                            <h5 style="margin-bottom: 1px;"><b>1st Interview:<%=getRemarks(applicantInfo["I1"])%> </b>

                                                            </h5>

                                                            <h5><b>Remarks: <%=applicantInfo["I1Remarks"]%></b></h5>
                                                            <p style="text-align: justify;"></p>
                                                            <h5><b>Interviewed By: <%=cm.GetSpecificDataFromDB("emp_FullName","TBL_EMPLOYEE_MASTER","WHERE emp_EmpID = '"+applicantInfo["Interviewer1"]+"'")%></b></h5>
                                                            <p style="text-align: justify;"></p>
                                                            <hr>
                                                        </div>
                                                        <div class="row" style="padding: 2px 27px;">
                                                            <h5 style="margin-bottom: 1px;"><b>2nd Interview: <%=getRemarks(applicantInfo["I2"])%></b>
                                                            </h5>

                                                            <h5><b>Remarks: <%=applicantInfo["I2Remarks"]%></b></h5>
                                                            <p style="text-align: justify;"></p>
                                                            <h5><b>Interviewed By: <%=cm.GetSpecificDataFromDB("emp_FullName","TBL_EMPLOYEE_MASTER","WHERE emp_EmpID = '"+applicantInfo["Interviewer2"]+"'")%></b></h5>

                                                            <p style="text-align: justify;"></p>
                                                            <hr>
                                                        </div>
                                                        <div class="row" style="padding: 2px 27px;">
                                                            <h5 style="margin-bottom: 1px;"><b>3rd Interview: <%=getRemarks(applicantInfo["I3"])%></b>
                                                            </h5>

                                                            <h5><b>Remarks: <%=applicantInfo["I3Remarks"]%></b></h5>
                                                            <p style="text-align: justify;"></p>
                                                            <h5><b>Interviewed By: <%=cm.GetSpecificDataFromDB("emp_FullName","TBL_EMPLOYEE_MASTER","WHERE emp_EmpID = '"+applicantInfo["Interviewer3"]+"'")%></b></h5>
                                                            <p style="text-align: justify;"></p>
                                                            <hr>
                                                        </div>
                                                        <!--Loop Data End-->
                                                    </div>
                                                </div>
                                            </section>

                                            <section class="col-lg-6 connectedSortable">
                                                <div class="box box-danger">
                                                    <div class="box-header">
                                                        <h3 class="box-title">
                                                            <span class="label label-danger"><%=(applicantInfo["shortlisted"]=="1"? "Shortlisted":"Not ShortListed")%></span>           </h3>
                                                    </div>
                                                    <table class="detail-view table table-striped table-condensed" id="yw1">
                                                        <tbody>
                                                            <tr class="odd">
                                                                <th>Date Applied</th>
                                                                <td><%=cm.FormatDate(applicantInfo["DateReceived"])%></td>
                                                            </tr>
                                                            <tr class="even">
                                                                <th>Surname</th>
                                                                <td><%=applicantInfo["Surname"] %></td>
                                                            </tr>
                                                            <tr class="odd">
                                                                <th>First Name</th>
                                                                <td><%=applicantInfo["FirstName"] %></td>
                                                            </tr>
                                                            <tr class="even">
                                                                <th>Midname</th>
                                                                <td><%=applicantInfo["Midname"] %></td>
                                                            </tr>
                                                            <tr class="odd">
                                                                <th>Birth Date</th>
                                                                <td><%=cm.FormatDate(applicantInfo["BirthDate"])%></td>
                                                            </tr>
                                                            <tr class="even">
                                                                <th>Gender</th>
                                                                <td><%=applicantInfo["Gender"]%></td>
                                                            </tr>
                                                            <tr class="odd">
                                                                <th>Civil Status</th>
                                                                <td><%=applicantInfo["AStatus"] %></td>
                                                            </tr>
                                                            <tr class="even">
                                                                <th>SSS</th>
                                                                <td><%=applicantInfo["SSS"] %></td>
                                                            </tr>
                                                            <tr class="odd">
                                                                <th>Philhealth No:</th>
                                                                <td><%=applicantInfo["PhilhealthNo"]%></td>
                                                            </tr>
                                                            <tr class="even">
                                                                <th>TIN No:</th>
                                                                <td><%=applicantInfo["TinNo"]%></td>
                                                            </tr>
                                                            <tr class="odd">
                                                                <th>Pagibig No:</th>
                                                                <td><%=applicantInfo["PagibigNo"]%></td>
                                                            </tr>
                                                            <tr class="even">
                                                                <th>National ID No:</th>
                                                                <td><%=applicantInfo["NationalIDNo"]%></td>
                                                            </tr>
                                                            <tr class="odd">
                                                                <th>Contact No:</th>
                                                                <td><%=applicantInfo["Celphone"]%></td>
                                                            </tr>
                                                            <tr class="even">
                                                                <th>Address</th>
                                                                <td><%=applicantInfo["Address1"]%></td>
                                                            </tr>
                                                            <tr class="odd">
                                                                <th>Address 2</th>
                                                                <td><%=applicantInfo["Address2"]%></td>
                                                            </tr>
                                                            <tr class="even">
                                                                <th>Email Address</th>
                                                                <td><%=applicantInfo["EmailAddress"]%></td>
                                                            </tr>
                                                            <tr class="odd">
                                                                <th>Elementary</th>
                                                                <td><%=applicantInfo["Elementary"]%></td>
                                                            </tr>
                                                            <tr class="even">
                                                                <th>Year Graduated</th>
                                                                <td><%=applicantInfo["ElementaryYear"]%></td>
                                                            </tr>
                                                            <tr class="odd">
                                                                <th>Secondary</th>
                                                                <td><%=applicantInfo["HighSchool"]%></td>
                                                            </tr>
                                                            <tr class="even">
                                                                <th>Year Graduated</th>
                                                                <td><%=applicantInfo["HighSchoolYear"]%></td>
                                                            </tr>
                                                            <tr class="odd">
                                                                <th>Tertiary</th>
                                                                <td><%=applicantInfo["College"]%></td>
                                                            </tr>
                                                            <tr class="even">
                                                                <th>Year Graduated</th>
                                                                <td><%=applicantInfo["CollegeYear"]%></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </section>

                                            <section class="col-lg-6">
                                                <!-- <div id="Personal" class="tabcontent">
          <div class="box box-danger">
	<div class="box-header">
		<ul class="nav nav-pills"><li class=""><a href="/index.php?r=applicant/updateinfo&amp;id=1"><i class="icon-edit"></i> </a></li></ul>	<center><h3 class="box-title" style="margin-bottom: 2rem;">Personal Information</h3></center>
	</div>
		<table class="detail-view table table-striped table-condensed" id="yw2"><tr class="odd"><th>Date Applied</th><td>02/20/2020</td></tr>
<tr class="even"><th>Surname</th><td>CIPRIANO</td></tr>
<tr class="odd"><th>First Name</th><td>CLYDE</td></tr>
<tr class="even"><th>Midname</th><td>SILVANO</td></tr>
<tr class="odd"><th>Birth Date</th><td></td></tr>
<tr class="even"><th>Gender</th><td>empty</td></tr>
<tr class="odd"><th>Civil Status</th><td>empty</td></tr>
<tr class="even"><th>SSS</th><td></td></tr>
<tr class="odd"><th>Philhealth No:</th><td></td></tr>
<tr class="even"><th>TIN No:</th><td></td></tr>
<tr class="odd"><th>Pagibig No:</th><td></td></tr>
<tr class="even"><th>National ID No:</th><td></td></tr>
<tr class="odd"><th>Contact No:</th><td></td></tr>
<tr class="even"><th>Address</th><td></td></tr>
<tr class="odd"><th>Address 2</th><td></td></tr>
<tr class="even"><th>Email Address</th><td>cipriano.clyde@dataland.ph</td></tr>
</table></div> 
        </div>

        <div id="Educ" class="tabcontent">
          <div class="box box-danger">
  <div class="box-header">
    <ul class="nav nav-pills"><li class=""><a href="/index.php?r=applicant/UpdateEducation&amp;id=1"><i class="icon-edit"></i> </a></li></ul>    <center><h3 class="box-title" style="margin-bottom: 2rem;">Educational Attainment</h3></center>
  </div>
  <div class="container">
    <div class="col-lg-5">
      <table class="detail-view table table-striped table-condensed" id="yw3"><tr class="odd"><th>Elementary</th><td></td></tr>
<tr class="even"><th>Secondary</th><td></td></tr>
<tr class="odd"><th>Tertiary</th><td></td></tr>
</table>    </div>
    <div class="col-lg-3">
      <table class="detail-view table table-striped table-condensed" id="yw4"><tr class="odd"><th>Year Graduated</th><td><span class="null">Not set</span></td></tr>
<tr class="even"><th>Year Graduated</th><td><span class="null">Not set</span></td></tr>
<tr class="odd"><th>Year Graduated</th><td><span class="null">Not set</span></td></tr>
</table>    </div>
  </div>
</div>         </div>

        <div id="Work" class="tabcontent">
            <div class="box box-danger">
  <div class="box-header">
  <ul class="nav nav-pills"><li class=""><a href="/index.php?r=applicant/view&amp;id=1"><i class="icon-arrow-left"></i> Back to Applicant View</a></li></ul>    <center><h3 class="box-title" style="margin-bottom: 2rem;">Work Experience</h3></center>
  </div>
  <table class="detail-view table table-striped table-condensed" id="yw5"><tr class="odd"><th>Position</th><td></td></tr>
<tr class="even"><th>Year</th><td></td></tr>
<tr class="odd"><th>Company Name</th><td></td></tr>
</table>  <table class="detail-view table table-striped table-condensed" id="yw6"><tr class="odd"><th>Position</th><td></td></tr>
<tr class="even"><th>Year</th><td></td></tr>
<tr class="odd"><th>Company Name</th><td></td></tr>
</table>  <table class="detail-view table table-striped table-condensed" id="yw7"><tr class="odd"><th>Position</th><td></td></tr>
<tr class="even"><th>Year</th><td></td></tr>
<tr class="odd"><th>Company Name</th><td></td></tr>
</table></div>        </div>

        <div id="Req" class="tabcontent">
                  <div class="box box-danger">
          <div class="box-header">
          <ul class="nav nav-pills"><li class=""><a href="/index.php?r=applicant/viewrequirements&amp;id=1"><i class="icon-edit"></i> </a></li></ul>          <center><h3 class="box-title" style="margin-bottom: 2rem;">Requirments</h3></center>
          </div>
            <table class="detail-view table table-striped table-condensed" id="yw8"><tr class="odd"><th>SSS</th><td></td></tr>
<tr class="even"><th>Diploma</th><td><span class="null">Not set</span></td></tr>
<tr class="odd"><th>NBI</th><td><span class="null">Not set</span></td></tr>
<tr class="even"><th>Medical</th><td><span class="null">Not set</span></td></tr>
<tr class="odd"><th>Clearance</th><td><span class="null">Not set</span></td></tr>
<tr class="even"><th>TOR</th><td><span class="null">Not set</span></td></tr>
<tr class="odd"><th>Birth Certificate</th><td><span class="null">Not set</span></td></tr>
<tr class="even"><th>SSS Static Info</th><td><span class="null">Not set</span></td></tr>
<tr class="odd"><th>Employment Certificate</th><td><span class="null">Not set</span></td></tr>
<tr class="even"><th>Police Clearance</th><td><span class="null">Not set</span></td></tr>
<tr class="odd"><th>Resume</th><td><span class="null">Not set</span></td></tr>
<tr class="even"><th>Resident Certificate</th><td></td></tr>
<tr class="odd"><th>Philhealth</th><td></td></tr>
<tr class="even"><th>Driver's License</th><td></td></tr>
</table>        </div>

 
        </div>
      
        <div id="Status" class="tabcontent">
          <section class="content-header">
    <h1>
        Recruitment
        <small>Update Applicant CIPRIANO, CLYDE SILVANO</small>
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Recruitment</a></li>
        <li class="active">Applicants</li>
    </ol>
</section>
<section class="content">
    <div class="box box-primary">
        <div class="box-header">
            <ul class="nav nav-pills"><li class=""><a href="/index.php?r=applicant/view&amp;id=1"><i class="icon-arrow-left"></i> Back to Applicant View</a></li></ul>          <h4>Interview Status</h4>
        </div>
                    <div class="box-header">
                <ul class="nav nav-tabs" role="tablist">
                    <li role="presentation" class="active">
                        <a href="#applicant" aria-controls="applicant" role="tab" data-toggle="tab">First Interview</a>
                    </li>
                    <li role="presentation">
                        <a href="#status" aria-controls="status" role="tab" data-toggle="tab">Second Interview</a>
                    </li>
                    <li role="presentation">
                        <a href="#requirements" aria-controls="requirements" role="tab" data-toggle="tab">Third and Last Interview</a>
                    </li>
                </ul>
                <div class="tab-content" style="padding: 2rem;">
                    <div role="tabpanel" class="tab-pane active" id="applicant">
                        
<div class="form">
	<form enctype="multipart/form-data" class="form-vertical" id="applicant-form" action="/index.php?r=applicant/view&amp;id=1" method="post">     	
	

	   		<div class="row">	
			<div class="col-lg-6">
			<label for="Applicant_I1">Interview 1</label>			<select class="form-control" name="Applicant[I1]" id="Applicant_I1">
<option value="empty">-Select Status-</option>
<option value="P">Passed</option>
<option value="F">Failed</option>
<option value="C">Conditional</option>
</select>	

						<label for="Applicant_Interviewer1">Interviewer</label>			<input class="form-control" maxlength="255" value="CIPRIANO, CLYDE SILVANO" name="Applicant[Interviewer1]" id="Applicant_Interviewer1" type="text" />			</div>

			<div class="col-lg-6">
				<label for="Applicant_I1Remarks">Remarks</label>				<textarea class="form-control" maxlength="255" name="Applicant[I1Remarks]" id="Applicant_I1Remarks"></textarea>
			</div>
			
	
		</div>
	
			<button class="btn btn-primary" type="submit" name="yt0"><i class="icon-ok icon-white"></i> Save</button></form>			
</div>

                    </div>
                    <div role="tabpanel" class="tab-pane disabled" id="status"> 
                        <div class="form">
	<form enctype="multipart/form-data" class="form-vertical" id="applicant-form" action="/index.php?r=applicant/view&amp;id=1" method="post">     	
	

	   		<div class="row">	
			<div class="col-lg-6">
			<label for="Applicant_I2">Interview 2</label>			<select class="form-control" name="Applicant[I2]" id="Applicant_I2">
<option value="empty">-Select Status-</option>
<option value="P">Passed</option>
<option value="F">Failed</option>
<option value="C">Conditional</option>
</select>	
						<label for="Applicant_Interviewer1">Interviewer</label>			<input class="form-control" maxlength="255" value="CIPRIANO, CLYDE SILVANO" name="Applicant[Interviewer1]" id="Applicant_Interviewer1" type="text" />			</div>

			<div class="col-lg-6">
				<label for="Applicant_I2Remarks">Remarks</label>				<textarea class="form-control" maxlength="255" name="Applicant[I2Remarks]" id="Applicant_I2Remarks"></textarea>
			</div>
	
		</div>
			<button class="btn btn-primary" type="submit" name="yt1"><i class="icon-ok icon-white"></i> Save</button></form>			
</div>
                    </div>
                    <div role="tabpanel" class="tab-pane" id="requirements">  
                        <div class="form">
	<form enctype="multipart/form-data" class="form-vertical" id="applicant-form" action="/index.php?r=applicant/view&amp;id=1" method="post">     	
	

	   		<div class="row">	
			<div class="col-lg-6">
			<label for="Applicant_I3">Interview 3</label>			<select class="form-control" name="Applicant[I3]" id="Applicant_I3">
<option value="empty">-Select Status-</option>
<option value="P">Passed</option>
<option value="F">Failed</option>
<option value="C">Conditional</option>
</select>	
						<label for="Applicant_Interviewer1">Interviewer</label>			<input class="form-control" maxlength="255" value="CIPRIANO, CLYDE SILVANO" name="Applicant[Interviewer1]" id="Applicant_Interviewer1" type="text" />			</div>

			<div class="col-lg-6">
				<label for="Applicant_I3Remarks">Remarks</label>				<textarea class="form-control" maxlength="255" name="Applicant[I3Remarks]" id="Applicant_I3Remarks"></textarea>
			</div>
	
		</div>
			<button class="btn btn-primary" type="submit" name="yt2"><i class="icon-ok icon-white"></i> Save</button></form>			
</div>
                    </div> 
                </div>
            </div>          </div>
    </div>
</section>
 
        </div> -->
                                            </section>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </div>
        <script>
            function openCity(evt, cityName) {
                var i, tabcontent, tablinks;
                tabcontent = document.getElementsByClassName("tabcontent");
                for (i = 0; i < tabcontent.length; i++) {
                    tabcontent[i].style.display = "none";
                }
                tablinks = document.getElementsByClassName("tablinks");
                for (i = 0; i < tablinks.length; i++) {
                    tablinks[i].className = tablinks[i].className.replace("active", "");
                }
                document.getElementById(cityName).style.display = "block";
                evt.currentTarget.className += "active";
            }

            // Get the element with id="defaultOpen" and click on it
            document.getElementById("defaultOpen").click();
        </script>

        <!-- /.row (main row) -->
    </aside>
</asp:Content>
