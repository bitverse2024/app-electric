<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="viewtraining.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees._201.viewtraining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to add this item?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <script type="text/javascript">
        function Confirm1() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to update this item?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
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
                <h3 class="m-0 text-dark"><%=getname() %><small> Trainings</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="#" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/EmployeeMaster.aspx")%>" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/EmployeeView.aspx?empid="+empno+"")%>" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Employee View</span></a>

                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="box-body">
                                    <div class='printableArea'>
                                        <div id="list">
                                            <div id="display-grid" class="grid-view">
                                                <div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>
                                                <asp:GridView ID="GridViewList" runat="server" AutoGenerateColumns="False"
                                                    ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                    GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                    ForeColor="Black" OnRowCommand="GridViewList_RowCommand"
                                                    OnPageIndexChanging="GridViewList_PageIndexChanging"
                                                    ViewStateMode="Enabled" ShowHeaderWhenEmpty="true">
                                                    <EmptyDataTemplate>
                                                        <center><h1>NO TRAINING AVAILABLE</h1></center>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkTrainingCode" CssClass="h8" Text='Training Code' runat="server" CommandName="Sort" CommandArgument="TrainingCode"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchTrainingCode" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTrainingCode" CssClass="" Text='<%# Eval("TrainingCode") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkTopic" CssClass="h8" Text='Topic' runat="server" CommandName="Sort" CommandArgument="Topic"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchTopic" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTopic" CssClass="" Text='<%# Eval("Topic") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkDateTaken" CssClass="h8" Text='Date' runat="server" CommandName="Sort" CommandArgument="DateTaken"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchDateTaken" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl" CssClass="" Text='<%# Eval("DateTaken") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkSpeaker" CssClass="h8" Text='Speaker' runat="server" CommandName="Sort" CommandArgument="Speaker"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchSpeaker" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSpeaker" CssClass="" Text='<%# Eval("Speaker") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkRemarks" CssClass="h8" Text='Remarks' runat="server" CommandName="Sort" CommandArgument="Remarks"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchRemarks" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRemarks" CssClass="" Text='<%# Eval("Remarks") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderStyle-Width="15%">
                                                            <ItemTemplate>
                                                                <%--  <asp:Button ID="btnView" CssClass="btn-success btn-xs" runat="server" Text="View"  CommandName="view" CommandArgument='<%# Eval("id") %>'  />
                                                                            <asp:Button ID="btnUpdate" CssClass="btn-success btn-xs" runat="server" Text="Update"   CommandName="upd" CommandArgument='<%# Eval("id") %>'  />
                                                                            <asp:Button ID="btnDelete" CssClass="btn-danger btn-xs" runat="server" Text="Delete" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;" CommandName="del" CommandArgument='<%# Eval("id") %>'  />--%>
                                                                <center>
                                                                    <asp:LinkButton ID="btnView" runat="server" ForeColor="Black" Font-Size="Large" CommandName="view" CommandArgument='<%# Eval("id") %>'><i class="fa fa-eye"></i></asp:LinkButton> &nbsp;
                                                                    <asp:LinkButton ID="btnUpdate" runat="server" ForeColor="Black" Font-Size="Medium" CommandName="upd" CommandArgument='<%# Eval("id") %>'><i class="fa fa-edit"></i></asp:LinkButton>&ensp;
                                                                    <asp:LinkButton ID="btnDelete" runat="server" ForeColor="Black" Font-Size="Medium" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;"  CommandName="del" CommandArgument='<%# Eval("id") %>'><i class="fa fa-trash"></i></asp:LinkButton>
                                                                </center>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>


                                                    </Columns>
                                                </asp:GridView>

                                            </div>

                                        </div>

                                        <div class="form">
                                            <legend>
                                                <p class="note">Fields with <span class="required text-red">**</span> are required.</p>
                                            </legend>



                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <label for="TrainingCode" class="required">
                                                        Training Code <span class="required text-red">**
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="TrainingCode" ValidationGroup="traininggroup"></asp:RequiredFieldValidator></span></label>
                                                    <input class="form-control" maxlength="50" name="Training[TrainingCode]" id="TrainingCode" type="text" runat="server" />
                                                    <label for="DateTaken" class="required">
                                                        Date <span class="required text-red">**
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="txtDateTaken" ValidationGroup="traininggroup"></asp:RequiredFieldValidator></span></label>
                                                    <input class="form-control" id="txtDateTaken" name="Training[Date]" type="date" runat="server" />
                                                    <label for="Topic" class="required">
                                                        Topic <span class="required text-red">**
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="Topic" ValidationGroup="traininggroup"></asp:RequiredFieldValidator></span></label>
                                                    <input class="form-control" maxlength="100" name="Training[Topic]" id="Topic" type="text" runat="server" />
                                                    <label for="Venue" class="required">Venue</label><input class="form-control" maxlength="50" value=" " name="Training[Venue]" id="Venue" type="text" runat="server" />
                                                    <label for="Cost" class="required">Cost</label><input class="form-control" maxlength="10" value="0" name="Training[Cost]" id="Cost" type="text" runat="server" />

                                                </div>
                                                <div class="col-lg-6">
                                                    <label for="TrainingHours" class="required">Hours</label><input class="form-control" value="0" maxlength="10" name="Training[Hours]" id="TrainingHours" type="text" runat="server" />
                                                    <label for="Speaker" class="required">Speaker</label><input class="form-control" maxlength="50" name="Training[Speaker]" id="Speaker" type="text" runat="server" />
                                                    <label for="TSource" class="required">Source</label><input class="form-control" maxlength="50" name="Training[Source]" id="TSource" type="text" runat="server" />
                                                    <label for="Remarks" class="required">Remarks</label><textarea class="form-control" maxlength="200" name="Training[Remarks]" id="Remarks" runat="server"></textarea>

                                                </div>
                                            </div>

                                            <div class="form-actions" style="padding-top: 10px;">
                                                <asp:Button ID="btnCreate" Width="80" class="btn btn-primary" runat="server" Text="Create"
                                                    OnClick="btnCreate_Click" OnClientClick="Confirm()" ValidationGroup="traininggroup"></asp:Button>
                                                <asp:Button ID="btnReset" Width="80" class="btn btn-danger" runat="server" Text="Reset"
                                                    OnClick="btnReset_Click"></asp:Button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal fade" id="listmodal">
                        <div class="modal-dialog">
                            <div class="modal-content1">

                                <asp:UpdatePanel ID="upListDetails" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                    <ContentTemplate>

                                        <div class="modal-header">
                                            <h4 class="modal-title">
                                                <asp:Label ID="Label3" runat="server" Text="Edit Information"></asp:Label></h4>
                                            <asp:LinkButton ID="lnkbtnXlist" CssClass="close" runat="server"
                                                OnClick="lnkbtnXlist_Click">
                                                <span>&times;</span>
                                            </asp:LinkButton>
                                        </div>
                                        <div class="modal-body">
                                            <asp:HiddenField ID="HiddenEmpID" runat="server" />
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <label for="upd_TrainingCode" class="required">
                                                        Training Code <span class="required text-red">**
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="upd_TrainingCode" ValidationGroup="traininggroup1"></asp:RequiredFieldValidator></span></label>
                                                    <input class="form-control" maxlength="50" name="Training[TrainingCode]" id="upd_TrainingCode" type="text" runat="server" />
                                                    <label for="upd_DateTaken" class="required">
                                                        Date <span class="required text-red">**
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="upd_DateTaken" ValidationGroup="traininggroup1"></asp:RequiredFieldValidator></span></label>
                                                    <input class="form-control datetimepicker" id="upd_DateTaken" name="Training[Date]" type="text" runat="server" />
                                                    <label for="upd_Topic" class="required">
                                                        Topic <span class="required text-red">**
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="upd_Topic" ValidationGroup="traininggroup1"></asp:RequiredFieldValidator></span></label>
                                                    <input class="form-control" maxlength="100" name="Training[Topic]" id="upd_Topic" type="text" runat="server" />
                                                    <label for="upd_Venue" class="required">Venue</label>
                                                    <input class="form-control" maxlength="50" name="Training[Venue]" id="upd_Venue" type="text" runat="server" value=" " />
                                                    <label for="upd_Cost" class="required">Cost</label>
                                                    <input class="form-control" maxlength="10" name="Training[Cost]" id="upd_Cost" type="text" runat="server" value=" 0" />
                                                </div>

                                                <div class="col-lg-6">
                                                    <label for="upd_TrainingHours" class="required">Hours</label>
                                                    <input class="form-control" maxlength="10" name="Training[Hours]" id="upd_TrainingHours" type="text" runat="server" value="0" />
                                                    <label for="upd_Speaker" class="required">Speaker</label>
                                                    <input class="form-control" maxlength="50" name="Training[Speaker]" id="upd_Speaker" type="text" runat="server" />
                                                    <label for="upd_TSource" class="required">Source</label>
                                                    <input class="form-control" maxlength="50" name="Training[Source]" id="upd_TSource" type="text" runat="server" />
                                                    <label for="upd_Remarks" class="required">Remarks</label>
                                                    <textarea class="form-control" maxlength="200" name="Training[Remarks]" id="upd_Remarks" runat="server"></textarea>
                                                </div>
                                            </div>

                                        </div>


                                        </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnsaveUpdate" runat="server" Text="Update" CssClass="btn btn-primary"
                            OnClick="btnsaveUpdate_Click" OnClientClick="Confirm1()" ValidationGroup="traininggroup1"></asp:Button>
                    </div>


                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnsaveUpdate" />
                                    </Triggers>
                                </asp:UpdatePanel>

                            </div>
                        </div>
                    </div>

                    <div class="modal fade" id="ViewModal">
                        <div class="modal-dialog">
                            <div class="modal-content">

                                <asp:UpdatePanel ID="upListDetails2" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                    <ContentTemplate>

                                        <div class="modal-header">
                                            <h4 class="modal-title">
                                                <asp:Label ID="Label1" runat="server" Text="View Information"></asp:Label></h4>
                                            <asp:LinkButton ID="LinkButton1" CssClass="close" runat="server"
                                                OnClick="lnkbtnXlistView_Click">
                                            <span>&times;</span>
                                            </asp:LinkButton>
                                        </div>
                                        <div class="modal-body" style="">
                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                            <div class="row">
                                                <!-- View Modal Content -->
                                                <div class="col-lg-6">
                                                    <label for="vw_TrainingCode" class="required">Training Code</label>
                                                    <input class="form-control" maxlength="50" name="Training[TrainingCode]" id="vw_TrainingCode" type="text" runat="server" disabled="disabled" />
                                                    <label for="vw_DateTaken" class="required">Date</label>
                                                    <input class="form-control" id="vw_DateTaken" name="Training[Date]" type="text" runat="server" disabled="disabled" />
                                                    <label for="vw_Topic" class="required">Topic</label>
                                                    <input class="form-control" maxlength="100" name="Training[Topic]" id="vw_Topic" type="text" runat="server" disabled="disabled" />
                                                    <label for="vw_Venue" class="required">Venue</label><input class="form-control" maxlength="50" name="Training[Venue]" id="vw_Venue" type="text" runat="server" disabled="disabled" />
                                                    <label for="vw_Cost" class="required">Cost</label><input class="form-control" maxlength="10" name="Training[Cost]" id="vw_Cost" type="text" runat="server" disabled="disabled" />

                                                </div>
                                                <div class="col-lg-6">
                                                    <label for="vw_TrainingHours" class="required">Hours</label><input class="form-control" maxlength="10" name="Training[Hours]" id="vw_TrainingHours" type="text" runat="server" disabled="disabled" />
                                                    <label for="vw_Speaker" class="required">Speaker</label><input class="form-control" maxlength="50" name="Training[Speaker]" id="vw_Speaker" type="text" runat="server" disabled="disabled" />
                                                    <label for="vw_TSource" class="required">Source</label><input class="form-control" maxlength="50" name="Training[Source]" id="vw_TSource" type="text" runat="server" disabled="disabled" />
                                                    <label for="vw_Remarks" class="required">Remarks</label><textarea class="form-control" maxlength="200" name="Training[Remarks]" id="vw_Remarks" runat="server" disabled="disabled"></textarea>

                                                </div>
                                            </div>


                                        </div>
                                        <div class="modal-footer">
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</asp:Content>
