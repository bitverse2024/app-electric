<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="viewfts.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.TK.viewfts" %>

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
                <h3 class="m-0 text-dark">Employee<small> View Unaccounted Attendance</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="fts.aspx" class="btn btn-default"><i class="fa fa-home"></i><span class="h6">Back to List</span></a>
                        <a href="viewfts.aspx?id=<%=empno %>" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                        <a id="A3" runat="server" onserverclick="btnExport_Click" class="btn btn-default"><i class="fa fa-arrow-circle-o-up"></i><span class="h6">Export to Excel</span></a>
                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="box-body">
                                    <h4 class="box-title">View Unaccounted Attendance  -  <%=empInfo["emp_FullName"] %> </h4>
                                    
                                        <div id="display-grid" class="grid-view box-body" style="overflow-x: auto;">
                                            <div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>
                                            <asp:GridView ID="GridViewList" runat="server" AutoGenerateColumns="False"
                                                ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                ForeColor="Black" OnRowCommand="GridViewList_RowCommand"
                                                OnPageIndexChanging="GridViewList_PageIndexChanging" ShowHeaderWhenEmpty="true"
                                                ViewStateMode="Enabled">
                                                <EmptyDataTemplate>
                                                    <center><h1>NO UNACCOUNTED ATTENDANCE AVAILABLE</h1></center>
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton1" Text='Status' runat="server" CommandName="Sort" CommandArgument="fts_status"></asp:LinkButton><br />
                                                              <asp:LinkButton ID="LinkButton12" CssClass="" Text='Status' runat="server" CommandName="Sort" CommandArgument="LeaveStatus"></asp:LinkButton><br />
                                                                      <asp:DropDownList ID="ddlStat" runat="server" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="true">
                                                                        <asp:ListItem Value="0" Text="-Select Status-"></asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="Approved"></asp:ListItem>
                                                                        <asp:ListItem Value="3" Text="Denied"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="Pending"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                            <asp:TextBox ID="txtSearchfts_Status" runat="server" Visible="false" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("fts_status")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton2" Width="100px" CssClass="h8" Text='Date Filed' runat="server" CommandName="Sort" CommandArgument="DateFiled"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchDateFiled" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("DateFiled") %></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton3" CssClass="h8" Text='Date' runat="server" CommandName="Sort" CommandArgument="buss_date"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchbuss_date" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("buss_date")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton4" Width="70px" CssClass="h8" Text='Time' runat="server" CommandName="Sort" CommandArgument="ftime"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchftime" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("ftime")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton5" CssClass="h8" Text='Type' runat="server" CommandName="Sort" CommandArgument="fts_type"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchtype" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("fts_type")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton6" Width="200px" CssClass="h8" Text='Reason' runat="server" CommandName="Sort" CommandArgument="Reason"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchReason" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("Reason")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton7" Width="200px" CssClass="h8" Text='Approver 1' runat="server" CommandName="Sort" CommandArgument="Approver1"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchApprover1" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("Approver1")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton8" Width="200px" CssClass="h8" Text='Date Approved 1' runat="server" CommandName="Sort" CommandArgument="DateApproved1"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchDapproved1" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("DateApproved1")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton9" Width="200px" CssClass="h8" Text='Approver 2' runat="server" CommandName="Sort" CommandArgument="Approver2"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchApprover2" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("Approver2") %></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton10" Width="200px" CssClass="h8" Text='Date Approved 2' runat="server" CommandName="Sort" CommandArgument="DateApproved2"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchDapproved2" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("DateApproved2")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--   <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="LinkButton11" Text='Reason for Disapproval' runat="server" CommandName="Sort" CommandArgument="reasons2"></asp:LinkButton><br />
                                                                            <asp:TextBox ID="txtSearchRemarks"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Eval("reasons2")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>



                                                    <asp:TemplateField HeaderStyle-Width="">
                                                         <HeaderTemplate>
                                                            <asp:LinkButton ID="LinkButton11" Width="50px" CssClass="h8" Text='' runat="server" CommandName="Sort" CommandArgument=""></asp:LinkButton>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%--<asp:Button ID="btnAction" CssClass="btn-success btn-xs" runat="server" Text="Action"  CommandName="action" CommandArgument='<%# Eval("id") %>'  />--%>
                                                            <%--<asp:Button ID="btnUpdate" CssClass="btn-success btn-xs" runat="server" Text="Update"   CommandName="upd" CommandArgument='<%# Eval("id") %>'  />
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
                                    <div class="form">

                                        <h4>Fields with <span class="required text-red">*</span> are required.</h4>


                                        <div class="showgrid">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <label for="Fts_buss_date" class="required">
                                                        Date <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required"
                                                            ControlToValidate="buss_date" ValidationGroup="ftsgroup" ForeColor="Red"></asp:RequiredFieldValidator></label>
                                                    <input class="form-control" id="buss_date" name="Fts[buss_date]" type="date" min="1900-01-01" max="2099-12-31" runat="server" />
                                                    <label for="Fts_time" class="required">
                                                        Time <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required"
                                                            ControlToValidate="Fts_time" ValidationGroup="ftsgroup" ForeColor="Red"></asp:RequiredFieldValidator></label>
                                                    <%--<input size="11" class="form-control" id="Fts_time" name="Fts[time]" type="text" maxlength="10" runat="server" />--%>
                                                    <input type="time" id="Fts_time" class="form-control" name="intTimeIn" min="05:00" max="23:00" value ="08:00" style="width:150px;" runat="server">
                                                    <label for="Fts_type" class="required">
                                                        Type <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required"
                                                            ControlToValidate="Fts_type" ValidationGroup="ftsgroup" ForeColor="Red"></asp:RequiredFieldValidator></label>
                                                    <select class="form-control" name="Fts[type]" id="Fts_type" runat="server">
                                                        <option value="In">In</option>
                                                        <option value="Out">Out</option>
                                                    </select>
                                                </div>
                                                <div class="col-lg-6">
                                                    <label for="Fts_reasons" class="required">
                                                        Reasons <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator4" runat="server" ErrorMessage="Field Required"
                                                            ControlToValidate="Fts_reasons" ValidationGroup="ftsgroup" ForeColor="Red"></asp:RequiredFieldValidator></label>
                                                    <textarea class="form-control" maxlength="200" name="Fts[reasons]" id="Fts_reasons" runat="server"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="form-actions">
                                            <asp:Button ID="btnCreate" class="btn btn-primary" Width="80" runat="server" Text="Create" UseSubmitBehavior="true"
                                                OnClick="btnCreate_Click" ValidationGroup="ftsgroup" OnClientClick="Confirm()"></asp:Button>
                                            <asp:Button ID="btnReset" class="btn btn-danger" Width="80" runat="server" Text="Reset" UseSubmitBehavior="true"
                                                OnClick="btnReset_Click"></asp:Button>
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
                                    <label for="Fts_buss_date" class="required">
                                        Date <span class="required text-red">*</span><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator5" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="upd_bussdate" ValidationGroup="ftsgroup1" ForeColor="Red"></asp:RequiredFieldValidator></label>
                                    <input class="form-control" id="upd_bussdate" name="Fts[buss_date]" type="date" min="1900-01-01" max="2099-12-31" runat="server" />
                                    <label for="Fts_time" class="required">
                                        Time <span class="required text-red">*</span><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator6" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="upd_time" ValidationGroup="ftsgroup1" ForeColor="Red"></asp:RequiredFieldValidator></label>
                                    <input size="11" class="form-control" id="upd_time" name="Fts[time]" type="text" maxlength="10" runat="server" />
                                    <label for="Fts_type" class="required">
                                        Type <span class="required text-red">*</span><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator7" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="upd_type" ValidationGroup="ftsgroup1" ForeColor="Red"></asp:RequiredFieldValidator></label>
                                    <select class="form-control" name="Fts[type]" id="upd_type" runat="server">
                                        <option value="In">In</option>
                                        <option value="Out">Out</option>
                                    </select>
                                </div>
                                <div class="col-lg-6">
                                    <label for="Fts_reasons" class="required">
                                        Reasons <span class="required text-red">*</span><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator8" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="upd_reason" ValidationGroup="ftsgroup1" ForeColor="Red"></asp:RequiredFieldValidator></label>
                                    <textarea class="form-control" maxlength="200" name="Fts[reasons]" id="upd_reason" runat="server"></textarea>
                                </div>
                            </div>


                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Apply Action" CssClass="btn btn-primary" UseSubmitBehavior="true"
                                OnClick="btnsaveUpdate_Click" OnClientClick="Confirm1()" ValidationGroup="ftsgroup1"></asp:Button>


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
