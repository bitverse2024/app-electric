﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="viewovertime.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.TK.viewovertime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">

        
        function MutExChkList(chk)
    {
        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");
        for(var i=0;i<chks.length;i++)
        {
            if(chks[i] != chk && chk.checked)
            {
                chks[i].checked=false;
            }
        }
    }
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
    <SCRIPT type="text/javascript">
       <!--
       function isNumberKey(evt)
       {
          var charCode = (evt.which) ? evt.which : evt.keyCode;
          if (charCode != 46 && charCode > 31 
            && (charCode < 48 || charCode > 57))
             return false;

          return true;
       }
       //-->
    </SCRIPT>
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
                <h3 class="m-0 text-dark">Employee <small>View Overtime</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="<%= ResolveUrl("~/Pages/Admin/TK/overtime.aspx")%>" class="btn btn-default"><i class="fa fa-home"></i><span class="h6">Back to List</span></a>
                        <a href="viewovertime.aspx?id=<%=empno %>" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                        <a id="A3" runat="server" onserverclick="btnExport_Click" class="btn btn-default"><i class="fa fa-arrow-circle-o-up"></i><span class="h6">Export to Excel</span></a>
                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class='box-body'>
                                    <h4 class="box-title">View Overtime  -  <%=empInfo["emp_FullName"] %> </h4>
                                    <div id="list">
                                        <div style="overflow-x: auto;" id="display-grid" class="grid-view">
                                            <div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>
                                            <asp:GridView ID="GridViewList" runat="server" AutoGenerateColumns="False"
                                                ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                ForeColor="Black" OnRowCommand="GridViewList_RowCommand" ShowHeaderWhenEmpty="true"
                                                OnPageIndexChanging="GridViewList_PageIndexChanging"
                                                ViewStateMode="Enabled">
                                                <EmptyDataTemplate>
                                                    <center><h1>NO OVERTIME AVAILABLE</h1></center>
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton1" CssClass="h8" Text='Status' runat="server" CommandName="Sort" CommandArgument="ot_status"></asp:LinkButton><br />
                                                              
                                                                      <asp:DropDownList ID="ddlStat" runat="server" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="true">
                                                                        <asp:ListItem Value="0" Text="-Select Status-"></asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="Approved"></asp:ListItem>
                                                                        <asp:ListItem Value="3" Text="Denied"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="Pending"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                            <asp:TextBox ID="txtSearchOT_Status" runat="server" Visible="false" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblOTStatus" CssClass="" Text=' <%# Eval("ot_status")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton2" Width="100px" CssClass="h8" Text='Date Filed' runat="server" CommandName="Sort" CommandArgument="DateFiled"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchDateFiled" runat="server" OnTextChanged="txtItem_TextChanged" TextMode="Date" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDateFiled" CssClass="" Text='<%# Eval("DateFiled") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton3" CssClass="h8" Text='OT Date' runat="server" CommandName="Sort" CommandArgument="OTDate"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchOTDate" runat="server" OnTextChanged="txtItem_TextChanged" TextMode="Date" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblOTDate" CssClass="" Text='<%# Eval("OTDate")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton4" Width="100px" CssClass="h8" Text='OT Time In' runat="server" CommandName="Sort" CommandArgument="ot_Time"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchTimeIn" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTimein" CssClass="" Text='<%# Eval("ot_Time")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton5" Width="100px" CssClass="h8" Text='OT Time Out' runat="server" CommandName="Sort" CommandArgument="ot_TimeOut"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchTimeOut" runat="server" OnTextChanged="txtItem_TextChanged" TextMode="Date" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTimeout" CssClass="" Text='<%# Eval("ot_TimeOut")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton6" Width="100px" CssClass="h8" Text='Total Hours' runat="server" CommandName="Sort" CommandArgument="ot_hours"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchTotalHours" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHours" CssClass="" Text='<%# Eval("ot_hours")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton7" Width="200px" CssClass="h8" Text='Reason' runat="server" CommandName="Sort" CommandArgument="Reason"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchReason" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblReason" CssClass="" Text='<%# Eval("Reason")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton8" CssClass="h8" Width="200px" Text='Approver 1' runat="server" CommandName="Sort" CommandArgument="Approver1"></asp:LinkButton><br /> 
                                                            <asp:TextBox ID="txtSearchApprover1" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApprover1" CssClass="" Text='<%# Eval("Approver1")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton9" Width="200px" CssClass="h8" Text='Date Approved 1' runat="server" CommandName="Sort" CommandArgument="DateApproved1"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchDapproved1" runat="server" OnTextChanged="txtItem_TextChanged" TextMode="Date" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDApproved1" CssClass="" Text='<%# Eval("DateApproved1")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton10" Width="200px" CssClass="h8" Text='Approver 2' runat="server" CommandName="Sort" CommandArgument="Approver2"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchApprover2" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApprover2" CssClass="" Text='<%# Eval("Approver2") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton11" Width="200px" CssClass="h8" Text='Date Approved 2' runat="server" CommandName="Sort" CommandArgument="DateApproved2"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchDapproved2" runat="server" OnTextChanged="txtItem_TextChanged" TextMode="Date" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDApproved2" CssClass="" Text='<%# Eval("DateApproved2")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--   <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="LinkButton12" Text='Remarks' runat="server" CommandName="Sort" CommandArgument="DateApproved2"></asp:LinkButton><br />
                                                                            <asp:TextBox ID="txtSearchDapproved2"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Eval("DateApproved2")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>




                                                    <asp:TemplateField HeaderStyle-Width="5%">
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton12" Width="50px" CssClass="h8" Text='' runat="server" CommandName="Sort" CommandArgument=""></asp:LinkButton>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            
                                                            <center>
                                                                <asp:LinkButton ID="btnUpdate" runat="server" ForeColor="Black" Font-Size="Medium" CommandName="upd" CommandArgument='<%# Eval("id") %>'><i class="fa fa-edit"></i></asp:LinkButton>&ensp;
                                                                <asp:LinkButton ID="btnDelete" runat="server" ForeColor="Black" Font-Size="Medium" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;"  CommandName="del" CommandArgument='<%# Eval("id") %>' ><i class="fa fa-trash"></i></asp:LinkButton>
                                                            </center>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>


                                                </Columns>
                                            </asp:GridView>

                                        </div>
                                    </div>
                                    <div class="form">

                                        <h4>Fields with <span class="required text-red">*</span> are required.</h4>


                                        <div class="showgrid">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <label for="Overtime_OTDate" class="required">
                                                        Overtime Date <span class="required text-red"**</span><asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required"
                                                            ControlToValidate="Overtime_Date" ValidationGroup="otgroup" ForeColor="Red"></asp:RequiredFieldValidator></label>
                                                    <input class="form-control" id="Overtime_Date" name="OTDate" type="date" min="1900-01-01" max="2099-12-31" runat="server" />
                                                    
                                                    <label for="Obt_In" class="required">
                                                                OT Time In<span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator8" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="addTimeIn" ValidationGroup="obt"></asp:RequiredFieldValidator></label>
                                                            <input type="time" id="addTimeIn" class="form-control" name="intTimeIn" min="05:00" max="23:00" value ="17:00" style="width:150px;" runat="server">

                                                            <label for="Obt_Out" class="required">
                                                                OT Time Out<span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator9" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="addTimeOut" ValidationGroup="obt"></asp:RequiredFieldValidator></label>
                                                            <input type="time" id="addTimeOut" name="intTimeOut" class="form-control" min="05:00" max="23:00" value="18:00" style="width:150px;" runat="server">
                                                    <%--<label for="Leavesapp_DateTo" class="required">
                                                Overtime Hours <span class="required text-red">**</span><asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator5" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="otHrs"
                                                    ValidationGroup="otgroup"></asp:RequiredFieldValidator></label>
                                        <div class="input-group">
                                            <input class="form-control" maxlength="1" name="emp_NickName" id="otHrs" type="number" min="1" max="9" onkeypress="return isNumberKey(event)" runat="server" />--%>
                                           
                                        </div>
                                                <div class="col-lg-6">
                                                    <label for="Overtime_Reason" class="required">
                                                        Reason <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator6" runat="server" ErrorMessage="Field Required"
                                                            ControlToValidate="Overtime_Reason" ValidationGroup="otgroup" ForeColor="Red"></asp:RequiredFieldValidator></label>
                                                    <textarea class="form-control" maxlength="200" name="Reason" id="Overtime_Reason" runat="server"></textarea>

                                                    Select IN/OUT<br />
                                                    <asp:CheckBoxList ID="cblOTInOut" runat="server">
                                                                    <asp:ListItem Text="IN" Value="1"  onclick="MutExChkList(this);" />
                                                                    <asp:ListItem Text="OUT" Value="2" Selected="True" onclick="MutExChkList(this);" />
                                                                    
                                                                </asp:CheckBoxList>
                                                </div>
                                                            
                                                        
                                                  
                                                </div>
                                                
                                            </div>
                                        </div>
                                        <br />
                                        <div class="form-actions">
                                            <asp:Button ID="btnCreate" class="btn btn-primary" Width="80" runat="server" Text="Create" UseSubmitBehavior="true"
                                                OnClick="btnCreate_Click" ValidationGroup="otgroup" OnClientClick="Confirm();"></asp:Button>
                                            <asp:Button ID="btnReset" class="btn btn-danger" Width="80" runat="server" Text="Reset" UseSubmitBehavior="true"
                                                OnClick="btnReset_Click"></asp:Button>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    <%--</div>--%>
                </section>
            </div>
        </div>
    </div>



    <%--Modal update--%>

    <div class="modal fade" id="listmodal">
        <div class="modal-dialog">
            <div class="modal-content">

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
                                    <label for="Overtime_OTDate" class="required">
                                        Overtime Date <span class="required text-red">*</span><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="upd_OTDate" ValidationGroup="otgroup1" ForeColor="Red"></asp:RequiredFieldValidator></label>
                                    <input class="form-control" id="upd_OTDate" name="OTDate" type="date" min="1900-01-01" max="2099-12-31" runat="server" />
                                    <%--<label for="Leavesapp_DateTo" class="required">
                                                Overtime Hours <span class="required text-red">**</span><asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" ForeColor="Red" ControlToValidate="upd_hours"
                                                    ValidationGroup="otgroup1"></asp:RequiredFieldValidator></label>
                                        <div class="input-group">
                                            <input class="form-control" maxlength="1" name="emp_NickName" id="upd_hours" type="number" min="1" max="9" onkeypress="return isNumberKey(event)" runat="server" />
                                           
                                        </div>--%>
                                    <label for="Overtime_Time" class="required">
                                        OT Time In <span class="required text-red">*</span><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="upd_in" ValidationGroup="otgroup1" ForeColor="Red"></asp:RequiredFieldValidator></label>
                                    <%--<input size="11" class="form-control" id="upd_in" name="ot_Time" type="text" maxlength="200" runat="server" />--%>
                                    <input type="time" id="upd_in" name="intTimeOut" class="form-control" min="09:00" max="18:00" value="17:00" style="width:150px;" runat="server">
                                    <label for="Overtime_TimeOut">OT Time Out</label>
                                   <%-- <input size="11" class="form-control" id="upd_out" name="ot_TimeOut" type="text" maxlength="200" runat="server" />--%>
                                    <input type="time" id="upd_out" name="intTimeOut" class="form-control" min="05:00" max="23:00" value="18:00" style="width:150px;" runat="server">
                                </div>
                                <div class="col-lg-6">
                                    <label for="Overtime_Reason" class="required">
                                        Reason <span class="required text-red">*</span><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator4" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="upd_Reason" ValidationGroup="otgroup1" ForeColor="Red"></asp:RequiredFieldValidator></label>
                                    <textarea class="form-control" maxlength="200" name="Reason" id="upd_Reason" runat="server"></textarea>

                                </div>
                            </div>


                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Apply Action" CssClass="btn btn-primary" UseSubmitBehavior="true"
                                OnClick="btnsaveUpdate_Click" OnClientClick="Confirm1()" ValidationGroup="otgroup1"></asp:Button>


                        </div>


                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnsaveUpdate" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>
    <%--End of Modal update--%>
</asp:Content>
