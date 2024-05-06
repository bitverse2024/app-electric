<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeScheduler.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.TK.EmployeeScheduler" %>
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
        function changevalue(checkbox) {
            var updtxtTimeIn = document.getElementById("<%= updtxtTimeIn.ClientID %>");
            updtxtTimeIn.disabled = checkbox.checked ? true : false;
            var updtxtTimeOut = document.getElementById("<%= updtxtTimeOut.ClientID %>");
            updtxtTimeOut.disabled = checkbox.checked ? true : false;
            
            ValidatorEnable(document.getElementById('<%= rfvupdtimein.ClientID %>'), checkbox.checked ? false : true);
            ValidatorEnable(document.getElementById('<%= rfvupdtimeout.ClientID %>'), checkbox.checked ? false : true);
        }

        
    </script>
    <script type="text/javascript">
        function Confirm3() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure to delete these data?")) {
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
            if (confirm("This will be subject for approval by HRD. Are you sure you want to permanently remove this item?")) {
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
        function Confirm2() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to delete this schedule?")) {
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
                <h1 class="m-0 text-dark">Scheduler<small> Employee's Scheduler</small></h1>
                <section class="card">
                    <div class="card-header">
                        <a href="EmployeeListForScheduler.aspx" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                        <%--<a href="<%= ResolveUrl("~/Pages/Admin/TK/scheduler.aspx")%>" class="btn btn-default"><i class="fa fa-upload"></i><span class="h6">Upload Schedule</span></a>--%>
                        

                    </div>
                         <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    
                                    <div class="box box-primary">
                                        <div class="box-header">
                                            <h3 class="box-title">ADD SCHEDULE <small> <%=getname() %></small></h3>
                                        </div>
                                        <div class="box-body">
                                            <div>
                                                    
                                                    <div class="col-lg-12 col-md-6">
                                                        <h4>Fields with <span class="required text-red">*</span> are required.</h4>

                                                    </div>
                                                    <div class="row">
                                                        <!-- Date -->
                                                        <div class="col-lg-6">
                                                                <label for="txtDate" class="required">Date <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator8" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                ControlToValidate="txtDate" ValidationGroup="FlexiSched"></asp:RequiredFieldValidator></label>
                                                            <div class="input-group date">
                                                                <input class="form-control" id="txtDate" name="Leavesapp[DateFrom]" type="date" min="1900-01-01" max="2099-12-31" runat="server" />
                                                            </div>
                                                            <br />
                                                            
                                                            <div class="form-group">
                                                                <asp:CheckBox id="cbRestday" AutoPostBack="true" Text="Restday" Checked="False" OnCheckedChanged="OnCheckedChangedMethod" runat="server"/><br />
                                                                    <label for="txtTimeIn" class="required">
                                                                Time In <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="rfvTimeIn" runat="server" ErrorMessage="Field Reqired" ForeColor="Red"
                                                                    ControlToValidate="txtTimeIn" ValidationGroup="FlexiSched"></asp:RequiredFieldValidator></label>
                                                            <input type="time" id="txtTimeIn" class="form-control" name="txtTimeIn" min="05:00" max="23:00" value ="10:00" style="width:150px;" runat="server">
                                                                <label for="txtTimeOut" class="required">
                                                                Time Out <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="rfvTimeOut" runat="server" ErrorMessage="Field Reqired" ForeColor="Red"
                                                                    ControlToValidate="txtTimeOut" ValidationGroup="FlexiSched"></asp:RequiredFieldValidator></label>
                                                            <input type="time" id="txtTimeOut" class="form-control" name="txtTimeOut" min="05:00" max="23:00" value ="19:00" style="width:150px;" runat="server">
                                                            </div>
                                                        </div>
                                                        
                                                    </div>
                                                    <div class="form-actions">
                                                        <asp:Button ID="btnCreate" class="btn btn-primary" Width="80" runat="server" Text="Create"
                                                            OnClick="btnCreate_Click" OnClientClick="Confirm()" ValidationGroup="FlexiSched"></asp:Button>
                                                        <asp:Button ID="btnReset" class="btn btn-danger" Width="80" runat="server" Text="Reset"
                                                            OnClick="btnReset_Click"></asp:Button>
                                                    </div>
                                                </div>
                                            
                                        </div>
                                    </div>
                                    
                                  <div class="box box-primary">
                                            <div class="box-header">
                                                <h3 class="box-title">Schedule Applied</h3>
                                            </div>
                                            <div class="box-body">
                                                <div class='printableArea'>
                                                    <div id="list">
                                                        <div style="overflow-x: auto;" id="filedleave-grid" class="grid-view">
                                                            <%--<div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>--%>
                                                            <asp:GridView ID="GridScheduleFiled" runat="server" AutoGenerateColumns="False"
                                                                ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                                GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                                ForeColor="Black" OnRowCommand="GridScheduleFiled_RowCommand"
                                                                OnPageIndexChanging="GridScheduleFiled_PageIndexChanging"
                                                                ViewStateMode="Enabled" ShowHeaderWhenEmpty="true">
                                                                <EmptyDataTemplate><center><h1>NO DATA AVAILABLE</h1></center></EmptyDataTemplate> 
                                                                <Columns>
                                                                    <asp:TemplateField Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblEmployeeID" Text='<%# Eval("EmpID") %>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="LinkButton1" Width="100px" CssClass="h8" Text='Date' runat="server" CommandName="Sort" CommandArgument="BussDate"></asp:LinkButton><br />
                                                                            <asp:DropDownList ID="ddlMonth" runat="server" OnSelectedIndexChanged="MonthddlChange" AutoPostBack="true" EnableViewState="true" Width="100%">
                                                                                        <asp:ListItem Text="Select Month" Value=""></asp:ListItem>
                                                                                        <asp:ListItem Value="1" Text="January"></asp:ListItem>
                                                                                        <asp:ListItem Value="2" Text="February"></asp:ListItem>
                                                                                        <asp:ListItem Value="3" Text="March"></asp:ListItem>
                                                                                        <asp:ListItem Value="4" Text="April"></asp:ListItem>
                                                                                        <asp:ListItem Value="5" Text="May"></asp:ListItem>
                                                                                        <asp:ListItem Value="6" Text="June"></asp:ListItem>
                                                                                        <asp:ListItem Value="7" Text="July"></asp:ListItem>
                                                                                        <asp:ListItem Value="8" Text="August"></asp:ListItem>
                                                                                        <asp:ListItem Value="9" Text="September"></asp:ListItem>
                                                                                        <asp:ListItem Value="10" Text="October"></asp:ListItem>
                                                                                        <asp:ListItem Value="11" Text="November"></asp:ListItem>
                                                                                        <asp:ListItem Value="12" Text="December"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                            
                                                                            <%--<asp:TextBox ID="txtSearchDTFrom"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <span class=""><%# Eval("BussDate")%></span>
                                                                            <%--<span class=""><%# Eval("BussDate")%></span>--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="LinkButton2" CssClass="h8" Text='Schedule Time In' runat="server" CommandName="Sort" CommandArgument="Sched_TimeIn"></asp:LinkButton><br />
                                                                            <%--<asp:TextBox ID="txtSearchDTto"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <span class=""><%# Eval("Sched_TimeIn")%></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="LinkButton3" CssClass="h8" Text='Schedule Time Out' runat="server" CommandName="Sort" CommandArgument="Sched_TimeOut"></asp:LinkButton><br />
                                                                            <%--<asp:TextBox ID="txtSearchDTto"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <span class=""><%# Eval("Sched_TimeOut")%></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Width="10%">
                                                                         <HeaderTemplate >

                                                                         </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                        
                                                                            <center>
                                                                                
                                                                                <asp:LinkButton ID="btnUpdate" runat="server" ForeColor="Black" Font-Size="Medium" CommandName="upd" CommandArgument='<%# Eval("id") %>' ><i class="fa fa-edit"></i></asp:LinkButton>&nbsp;
                                                                                <asp:LinkButton ID="btnDelete" runat="server" ForeColor="Black" Font-Size="Medium" OnClientClick="if (!confirm('Are you sure you want to permanently remove this Schedule?')) return false;" CommandName="del" CommandArgument='<%# Eval("id") %>' ><i class="fa fa-trash"></i></asp:LinkButton>
                                                                                    
                                                                                </center>
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>


                                                                </Columns>
                                                            </asp:GridView>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>

                </section>
            </div>
        </div>
    </div>
    

    <div class="modal fade" id="listmodal">
        <div class="modal-dialog">
            <div class="modal-content">

                <asp:UpdatePanel ID="upListDetails" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
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
                                <!-- Date -->

                                <div class="col-lg-6">
                                                                <label for="updlbldate" class="required">Date: </label>
                                                            <div class="input-group date">
                                                                <asp:Label ID="updlbldate" runat="server" Text="Label" CssClass="h3"></asp:Label>
                                                            </div>
                                                            <br />
                                                            
                                                            <div class="form-group">
                                                                <asp:CheckBox ID="CheckBox1" runat="server" Text="Restday" onclick="changevalue(this)" /><br />
                                                                
                                                                    <label for="updtxtTimeIn" class="required">
                                                                Time In <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="rfvupdtimein" runat="server" ErrorMessage="Field Reqired" ForeColor="Red"
                                                                    ControlToValidate="updtxtTimeIn" ValidationGroup="updScheduleGroup"></asp:RequiredFieldValidator></label>
                                                            <input type="time" id="updtxtTimeIn" class="form-control" name="txtTimeIn"   style="width:150px;" runat="server">
                                                                <label for="updtxtTimeOut" class="required">
                                                                Time Out <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="rfvupdtimeout" runat="server" ErrorMessage="Field Reqired" ForeColor="Red"
                                                                    ControlToValidate="updtxtTimeOut" ValidationGroup="updScheduleGroup"></asp:RequiredFieldValidator></label>
                                                            <input type="time" id="updtxtTimeOut" class="form-control" name="txtTimeOut"   style="width:150px;" runat="server">
                                                            </div>
                                                        </div>



                            </div>


                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Update"
                                OnClick="btnsaveUpdate_Click" CssClass="btn btn-primary" UseSubmitBehavior="true"
                                OnClientClick="Confirm()" ValidationGroup="updScheduleGroup"></asp:Button>


                        </div>


                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnsaveUpdate" />
                        <asp:PostBackTrigger ControlID="CheckBox1" />
                        
                    </Triggers>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>
</asp:Content>
