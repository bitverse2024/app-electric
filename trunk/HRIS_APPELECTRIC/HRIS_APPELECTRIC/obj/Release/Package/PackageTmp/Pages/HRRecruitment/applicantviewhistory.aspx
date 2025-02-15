﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="applicantviewhistory.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.HRRecruitment.applicantviewhistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <aside class="right-side">
        <!-- Small boxes (Stat box) -->



        <section class="content-header">
            <h1><a href="applicantprofileview.aspx?id=<%=applicantInfo["id"] %>"><%=applicantInfo["FullName"] %></a>
                <small>Application History</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Applicant</a></li>
                <li class="active">Application History</li>
            </ol>
        </section>
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
                    <h3 class="m-0 text-dark">Application History<small> applicantprofileview.aspx?id=<%=applicantInfo["id"] %>"><%=applicantInfo["FullName"] %></small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="applicantprofileview.aspx?id=<%=applicantInfo["id"] %>" class="btn btn-default">
                                <i class="fa fa-arrow-left"></i><span class="h5">Back to Applicant View</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">

                                        <div class="printableArea">
                                            <div id="list">
                                                <!-- Main Content -->
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
                                                            <asp:TemplateField Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="lnkDateReceived" Text='Date Received' runat="server" CommandName="Sort" CommandArgument="DateReceived"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtSearchDateReceived" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDateReceived" Text='<%# Eval("DateReceived") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="lnkaction" Text='Action' runat="server" CommandName="Sort" CommandArgument="action"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtSearchaction" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblaction" Text='<%# Eval("action") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="lnkreason" Text='Remarks' runat="server" CommandName="Sort" CommandArgument="reason"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtSearchRemarks" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
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
                                                                    <%--<asp:Button ID="btnView" CssClass="btn-success btn-xs" runat="server" Text="View"  CommandName="view" CommandArgument='<%# Eval("id") %>'  />--%>
                                                                    <asp:Button ID="btnUpdate" CssClass="btn-success btn-xs" runat="server" Text="Update" CommandName="upd" CommandArgument='<%# Eval("id") %>' />
                                                                    <asp:Button ID="btnDelete" CssClass="btn-danger btn-xs" runat="server" Text="Delete" CommandName="del" CommandArgument='<%# Eval("id") %>' />
                                                                </ItemTemplate>

                                                            </asp:TemplateField>


                                                        </Columns>
                                                    </asp:GridView>

                                                </div>
                                            </div>


                                            <div class="form container">
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <form id="applicanthistory-form" action="http://dataland.bit-verse.com/index.php?r=applicant/viewhistory&amp;id=1" method="post">
                                                            <!-- <p class="note">Fields with <span class="required text-red">**</span> are required.</p> -->


                                                            <!-- <div class="row">
				<label for="Applicanthistory_userid" class="required">Userid <span class="required text-red">**</span></label>				<input name="Applicanthistory[userid]" id="Applicanthistory_userid" type="text" />							</div>

			<div class="row">
				<label for="Applicanthistory_mrid" class="required">Mrid <span class="required text-red">**</span></label>				<input name="Applicanthistory[mrid]" id="Applicanthistory_mrid" type="text" />							</div>

			<div class="row">
				<label for="Applicanthistory_hrmrid" class="required">Hrmrid <span class="required text-red">**</span></label>				<input name="Applicanthistory[hrmrid]" id="Applicanthistory_hrmrid" type="text" />							</div>

			<div class="row">
				<label for="Applicanthistory_division">Division</label>				<input size="50" maxlength="50" name="Applicanthistory[division]" id="Applicanthistory_division" type="text" />							</div> -->

                                                            <div class="row">
                                                                <label for="Applicanthistory_PositionDesired">Position Desired</label>
                                                                <select class="form-control" name="Applicanthistory[PositionDesired]" id="Applicanthistory_PositionDesired" runat="server">
                                                                    <option value="">---Select Position---</option>

                                                                </select>
                                                            </div>

                                                            <!-- <div class="row">
				<label for="Applicanthistory_DateReceived">Date Received</label>				<input name="Applicanthistory[DateReceived]" id="Applicanthistory_DateReceived" type="text" />							</div>

			<div class="row">
				<label for="Applicanthistory_FullName">Full Name</label>				<input size="60" maxlength="255" name="Applicanthistory[FullName]" id="Applicanthistory_FullName" type="text" />							</div>

			<div class="row">
				<label for="Applicanthistory_action">Action</label>				<input size="60" maxlength="500" name="Applicanthistory[action]" id="Applicanthistory_action" type="text" />							</div>

			<div class="row">
				<label for="Applicanthistory_I1">I1</label>				<input size="50" maxlength="50" name="Applicanthistory[I1]" id="Applicanthistory_I1" type="text" />							</div>

			<div class="row">
				<label for="Applicanthistory_I2">I2</label>				<input size="50" maxlength="50" name="Applicanthistory[I2]" id="Applicanthistory_I2" type="text" />							</div>

			<div class="row">
				<label for="Applicanthistory_I3">I3</label>				<input size="50" maxlength="50" name="Applicanthistory[I3]" id="Applicanthistory_I3" type="text" />							</div>

			<div class="row">
				<label for="Applicanthistory_Interviewer1">Interviewer1</label>				<input size="60" maxlength="150" name="Applicanthistory[Interviewer1]" id="Applicanthistory_Interviewer1" type="text" />							</div>

			<div class="row">
				<label for="Applicanthistory_Interviewer2">Interviewer2</label>				<input size="60" maxlength="150" name="Applicanthistory[Interviewer2]" id="Applicanthistory_Interviewer2" type="text" />							</div>

			<div class="row">
				<label for="Applicanthistory_Interviewer3">Interviewer3</label>				<input size="60" maxlength="150" name="Applicanthistory[Interviewer3]" id="Applicanthistory_Interviewer3" type="text" />							</div>

			<div class="row">
				<label for="Applicanthistory_I1Remarks">I1 Remarks</label>				<input size="60" maxlength="150" name="Applicanthistory[I1Remarks]" id="Applicanthistory_I1Remarks" type="text" />							</div>

			<div class="row">
				<label for="Applicanthistory_I2Remarks">I2 Remarks</label>				<input size="60" maxlength="150" name="Applicanthistory[I2Remarks]" id="Applicanthistory_I2Remarks" type="text" />							</div>

			<div class="row">
				<label for="Applicanthistory_I3Remarks">I3 Remarks</label>				<input size="60" maxlength="150" name="Applicanthistory[I3Remarks]" id="Applicanthistory_I3Remarks" type="text" />							</div> -->

                                                            <div class="row">
                                                                <label for="Applicanthistory_reason">Reason</label>
                                                                <textarea size="60" maxlength="150" class="form-control" name="Applicanthistory[reason]" id="Applicanthistory_reason" runat="server"></textarea>
                                                            </div>

                                                            <div class="form-actions">
                                                                <asp:Button ID="btnCreate" class="btn btn-primary" runat="server" Text="Create"
                                                                    OnClick="btnCreate_Click" ValidationGroup="CreateCompanyGroup"></asp:Button>
                                                                <asp:Button ID="btnReset" class="btn" runat="server" Text="Reset"
                                                                    OnClick="btnReset_Click"></asp:Button>
                                                            </div>

                                                        </form>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- form -->
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
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
                            <asp:LinkButton ID="lnkbtnXlist" CssClass="close" runat="server"
                                OnClick="lnkbtnXlist_Click">
                            <span>&times;</span>
                            </asp:LinkButton>
                            <h4 class="modal-title">
                                <asp:Label ID="Label3" runat="server" Text="Edit Information"></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="HiddenID" runat="server" />
                            <div class="row">
                                <!-- Input Text to update -->



                                <div class="col-lg-6">
                                    <label>
                                        <label for="upd_ApplicationPositionDesired" class="required">Position Desired<span class="required"></span></label></label>
                                    <select class="form-control" name="selectPositionDesired" id="upd_ApplicationPositionDesired" runat="server">
                                        <option value="">---Select Position---</option>
                                    </select>

                                </div>

                                <div class="col-lg-6">
                                    <label>
                                        <label for="upd_Reason" class="required">Reason<span class="required"></span></label></label>
                                    <div class="input-group date">

                                        <input style="height: 20px;" class="form-control" id="upd_Reason" name="txtReason" type="text" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Apply Action"
                                OnClick="btnsaveUpdate_Click" ValidationGroup="UpdateRankGroup"></asp:Button>


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
