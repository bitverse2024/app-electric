<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="viewloans.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees._201.viewloans" %>

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
    function isNumberKey1(txt, evt) {
      var charCode = (evt.which) ? evt.which : evt.keyCode;
      if (charCode == 46) {
        //Check if the text already contains the . character
        if (txt.value.indexOf('.') === -1) {
          return true;
        } else {
          return false;
        }
      } else {
        if (charCode > 31 &&
          (charCode < 48 || charCode > 57))
          return false;
      }
      return true;
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
                <h3 class="m-0 text-dark"><%=getname() %><small> Loans</small></h3>
                <section class="card">
                    <div class="card-header">
                        <%if (Session["ROLES"].ToString() == "admin")
                            { %><a href="<%= ResolveUrl("~/Pages/Admin/Employees/CreateEmployee.aspx")%>" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/EmployeeMaster.aspx")%>" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a><%} %>
                        <a href="<%=ResolveUrl("~/Pages/Admin/Employees/EmployeeView.aspx?empid="+empno+"")%>" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Employee View</span></a>
                    </div>
                    <div class="card-body">
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
                                                <center><h1>NO LOANS ENTRIES</h1></center>
                                            </EmptyDataTemplate>
                                            <Columns>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>



                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkLoanCode" Style="color: #0026ff; font-size: 12px; font-weight: bold;" Text='Loan Code' runat="server" CommandName="Sort" CommandArgument="LoanDesc"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtLoanCode" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" Style=" font-size: 12px;"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <span class="" Style=" font-size: 12px; font-weight: bold;"><%# Eval("LoanDesc")%></span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkDedStart" Style="color: #0026ff; font-size: 12px; font-weight: bold;" Text='Start of Deduction' Width="150px" runat="server" CommandName="Sort" CommandArgument="DedStart"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtDedStart" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" Style=" font-size: 12px;"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <span class="" Style=" font-size: 12px; font-weight: bold;"><%# Eval("DedStart")%></span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkLoanAmount" Style="color: #0026ff; font-size: 12px; font-weight: bold;" Text='Loan Amount' runat="server" CommandName="Sort" CommandArgument="LoanAmount"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtLoanAmount" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" Style=" font-size: 12px;"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <span class="" Style=" font-size: 12px; font-weight: bold;"><%# Eval("LoanAmount")%></span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkAmountPaid" Style="color: #0026ff; font-size: 12px; font-weight: bold;" Text='Amount Paid' runat="server" CommandName="Sort" CommandArgument="AmountPaid"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtAmountPaid" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" Style=" font-size: 12px;"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <span class="" Style=" font-size: 12px; font-weight: bold;"><%# Eval("AmountPaid")%></span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkBalance" Style="color: #0026ff; font-size: 12px; font-weight: bold;" Text='Balance' runat="server" CommandName="Sort" CommandArgument="Balance"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtBalance" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" Style=" font-size: 12px;"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <span class="" Style=" font-size: 12px; font-weight: bold;"><%# Eval("Balance")%></span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkDedAmount" Style="color: #0026ff; font-size: 12px; font-weight: bold;" Width="150px" Text='Deduction Amount' runat="server" CommandName="Sort" CommandArgument="DedAmount"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtDedAmount" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" Style=" font-size: 12px;"></asp:TextBox>
                                                    </HeaderTemplate>
                                                   <ItemTemplate>
                                                        <span class="" Style=" font-size: 12px; font-weight: bold;"><%# Eval("DedAmount")%></span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <center>
                                                            <asp:LinkButton ID="btnView" runat="server" ForeColor="Black" Font-Size="Large" CommandName="view" CommandArgument='<%# Eval("id") %>'><i class="fa fa-eye"></i></asp:LinkButton> &nbsp;
                                                            <asp:LinkButton ID="btnUpdate" runat="server" ForeColor="Black" Font-Size="Medium" CommandName="upd" CommandArgument='<%# Eval("id") %>' Visible='<%# Session["ROLES"].ToString() == "admin" %>'><i class="fa fa-edit"></i></asp:LinkButton>&ensp;
                                                            <asp:LinkButton ID="btnDelete" runat="server" ForeColor="Black" Font-Size="Medium" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;"  CommandName="del" CommandArgument='<%# Eval("id") %>' Visible='<%# Session["ROLES"].ToString() == "admin" %>'><i class="fa fa-trash"></i></asp:LinkButton>
                                                        </center>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                

                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                
                                 <div class="box box-primary">
                                        <div class="box-header">
                                            <h3 class="box-title">LOAN PAYMENT</h3>
                                        </div>
                                        <div class="box-body">
                                            <div class='printableArea'>
                                                <div id="list">
                                                    <div id="leaveledger-grid" class="grid-view">
                                                        <div class="summary">Displaying <%=gridrangecountPaymentHistory%> of <%=gridtotalcountPaymentHistory%> results.</div>
                                                        <asp:GridView ID="GridPaymentHistory" runat="server" AutoGenerateColumns="False"
                                                            ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                            GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                            ForeColor="Black" OnRowCommand="GridPaymentHistory_RowCommand"
                                                            OnPageIndexChanging="GridPaymentHistory_PageIndexChanging"
                                                            ViewStateMode="Enabled" ShowHeaderWhenEmpty="true">
                                                            <EmptyDataTemplate><center><h1>NO PAYMENT HISTORY</h1></center></EmptyDataTemplate> 
                                                            <Columns>
                                                                <asp:TemplateField Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lnkName" runat="server" Text="Loan" Style="color: #0026ff; font-size: 12px; font-weight: bold;"></asp:Label>
                                                                        <%--<asp:LinkButton ID="linkbtn_1" CssClass="h8" Text='Loan' runat="server" CommandName="Sort" CommandArgument="Name"></asp:LinkButton>--%><br />
                                                                        <%--<asp:TextBox ID="txtSearchLeavetype"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                    <asp:DropDownList ID="ddlSearch" runat="server" OnSelectedIndexChanged="ddlChange" AutoPostBack="true" EnableViewState="true" Width="100%" Style=" font-size: 12px; font-weight: bold;">
                                                                        <asp:ListItem Text="Select Type" Value="ALL"></asp:ListItem>
                                                                        <asp:ListItem Value="CA" Text="Cash Advance"></asp:ListItem>
                                                                        <asp:ListItem Value="PIL" Text="HDMF SAL"></asp:ListItem>
                                                                        <asp:ListItem Value="PICL" Text="HDMF-CAL"></asp:ListItem>
                                                                        <asp:ListItem Value="SSS" Text="SSS SAL"></asp:ListItem>
                                                                        <asp:ListItem Value="SSSCL" Text="SSS-CAL"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <span class="" Style=" font-size: 12px; font-weight: bold;"><%# Eval("Name")%></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <%--<asp:LinkButton ID="linkbtn_2" CssClass="h8" Text='PAID' runat="server" CommandName="Sort" CommandArgument="amountPaid"></asp:LinkButton>--%>
                                                                        <asp:Label ID="lnkamountPaid" runat="server" Text="Paid" Style="color: #0026ff; font-size: 12px; font-weight: bold;"></asp:Label><br />
                                                                        <%--<asp:TextBox ID="txtSearchEarned"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <span class="" Style=" font-size: 12px; font-weight: bold;"><%# Eval("amountPaid")%></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <%--<asp:LinkButton ID="linkbtn_3" CssClass="h8" Text='Previous Balance' runat="server" CommandName="Sort" CommandArgument="beforepaymentbal"></asp:LinkButton>--%>
                                                                        <asp:Label ID="lnkbeforepaymentbal" runat="server" Text="Previous Bal" Style="color: #0026ff; font-size: 12px; font-weight: bold;"></asp:Label><br />
                                                                        <%--<asp:TextBox ID="txtSearchUsed"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <span class="" Style=" font-size: 12px; font-weight: bold;"><%# Eval("beforepaymentbal")%></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <%--<asp:LinkButton ID="linkbtn_4" CssClass="h8" Text='Balance' runat="server" CommandName="Sort" CommandArgument="afterpaymentbal"></asp:LinkButton>--%>
                                                                        <asp:Label ID="lnkafterpaymentbal" runat="server" Text="Balance" Style="color: #0026ff; font-size: 12px; font-weight: bold;"></asp:Label><br />
                                                                        <%--<asp:TextBox ID="txtSearchRemaining"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <span class="" Style=" font-size: 12px; font-weight: bold;"><%# Eval("afterpaymentbal")%></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <%--<asp:LinkButton ID="linkbtn_5" CssClass="h8" Text='Date' runat="server" CommandName="Sort" CommandArgument="DateTrans"></asp:LinkButton>--%>
                                                                        <asp:Label ID="lblfts_status" runat="server" Text="Date" Style="color: #0026ff; font-size: 12px; font-weight: bold;"></asp:Label><br />
                                                                        <%--<asp:TextBox ID="txtSearchExpiry"  runat="server" OnTextChanged="txtItem_TextChanged"  Width= "100%"></asp:TextBox>--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <span class="" Style=" font-size: 12px; font-weight: bold;"><%# Eval("DateTrans")%></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="10%">
                                                                    <ItemTemplate>
                                                                        <center>
                                                                            <asp:LinkButton ID="btnDeletePaymentHistory" runat="server" ForeColor="Black" Font-Size="Medium" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;"  CommandName="del" CommandArgument='<%# Eval("id") %>' Visible='<%# Session["ROLES"].ToString() == "admin" %>'><i class="fa fa-trash"></i></asp:LinkButton>
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
                                <%if (Session["ROLES"].ToString() == "admin")
                                    { %>
                                <div class="form">
                                    <legend>
                                        <p class="note">Fields with <span class="required text-red">*</span> are required.</p>
                                    </legend>


                                    <div class="row showgrid">
                                        <div class="col-lg-6">


                                            <%--<label for="Loanentries_DateFiled">Date Filed</label>	
    <input style="height:20px;" class="form-control" id="Loanentries_DateFiled" runat = "server" name="Loanentries[DateFiled]" type="text" />--%>
                                            <label for="Loanentries_DateFiled" class="required" Style=" font-size: 14px;">Loan Date <span class="required text-red">*
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLoanentries_DateFiled"
                                                    ValidationGroup="LoansGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                            <input class="form-control " id="txtLoanentries_DateFiled" name="Loanentries[DateFiled]" type="date" min="1900-01-01" max="2099-12-31" maxlength="11" runat="server" />

                                            <label for="Loanentries_DedStart" class="required" Style=" font-size: 14px;">Start of Deduction <span class="required text-red">*
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLoanentries_DedStart"
                                                    ValidationGroup="LoansGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                            <input class="form-control" id="txtLoanentries_DedStart" name="Loanentries[DedStart]" type="date" min="1900-01-01" max="2099-12-31" maxlength="11" runat="server" />
                                            
                                            <%--<label for="Loanentries_DedStart">Start of Deduction</label>	
    <input style="height:20px;" class="form-control" id="Loanentries_DedStart" runat = "server" name="Loanentries[DedStart]" type="text" />		--%>
                                            <label for="Loanentries_LoanCode" class="required" Style=" font-size: 14px;">
                                                Loan Code <span class="required text-red">*
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Loanentries_LoanCode" ValidationGroup="LoansGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                            <select class="form-control" name="Loanentries[LoanCode]" id="Loanentries_LoanCode" runat="server">
                                                <option value="">---Select Loan Type---</option>
                                            </select>
                                            <%--<label for="Loanentries_AmountOfLoan" class="required">Loan Granted</label><input class="form-control" name="Loanentries[AmountOfLoan]" id="Loanentries_AmountOfLoan" runat="server" type="text" value="0" />--%>
                                            <%--<label for="Loanentries_LoanAmount" class="required">Loan Amount</label><input class="form-control" name="Loanentries[LoanAmount]" id="Loanentries_LoanAmount" runat="server" type="text" value="0" />--%>
                                            <label for="Loanentries_LoanAmount" class="required">Loan Amount <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator11" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="Loanentries_LoanAmount" ValidationGroup="CreateEmployeeGroup"></asp:RequiredFieldValidator></label>
                                                                <div class="input-group">
                                                                    <input class="form-control" id="Loanentries_LoanAmount" name="Loanentries_LoanAmount" type="number" min="0" max="100000" onkeypress="return isNumberKey(event)"  runat="server" />
                                                                </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <label for="Loanentries_DedAmount" class="required" Style=" font-size: 14px;">Deduction Amount<span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="Loanentries_DedAmount" ValidationGroup="CreateEmployeeGroup"></asp:RequiredFieldValidator></label>
                                                                <div class="input-group">
                                                                    <input class="form-control" id="Loanentries_DedAmount" name="Loanentries_DedAmount" type="number" min="0" max="100000" onkeypress="return isNumberKey(event)"  runat="server" />
                                                                </div>
                                            <label for="Loanentries_AmountPaid" class="required" Style=" font-size: 14px;">Amount Paid<span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator4" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="Loanentries_AmountPaid" ValidationGroup="CreateEmployeeGroup"></asp:RequiredFieldValidator></label>
                                                                <div class="input-group">
                                                                    <input class="form-control" id="Loanentries_AmountPaid" name="Loanentries_AmountPaid" type="number" min="0" max="100000" onkeypress="return isNumberKey(event)"  runat="server" />
                                                                </div>
                                            <label for="Loanentries_Balance" class="required" Style=" font-size: 14px;">Balance <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator6" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="Loanentries_Balance" ValidationGroup="CreateEmployeeGroup"></asp:RequiredFieldValidator></label>
                                                                <div class="input-group">
                                                                    <input class="form-control" id="Loanentries_Balance" name="Loanentries_Balance" type="number" min="0" max="100000" onkeypress="return isNumberKey(event)"  runat="server" />
                                                                </div>
                                            <%--<label for="Loanentries_DedAmount" class="required">Deduction Amount</label><input class="form-control" name="Loanentries[DedAmount]" id="Loanentries_DedAmount" runat="server" type="text" value="0" />
                                            <label for="Loanentries_AmountPaid" class="required">Amount Paid</label><input class="form-control" name="Loanentries[AmountPaid]" id="Loanentries_AmountPaid" runat="server" type="text" value="0" />
                                            <label for="Loanentries_Balance" class="required">Balance</label><input class="form-control" name="Loanentries[Balance]" id="Loanentries_Balance" runat="server" type="text" value="0" />--%>
                                            <%--<br />--%>
                                            <%--<span class="h5">--%>
                                                <%--<asp:CheckBox ID="Loanentries_Schedule" runat="server" CssClass="checkbox-inline" Text="For Deduction"></asp:CheckBox></span>&ensp;--%>
    <span Style=" font-size: 14px;">
        <asp:CheckBox ID="Loanentries_Status" runat="server" CssClass="checkbox-inline" Text="Active Deduction"></asp:CheckBox></span>
                                            <%--<label class="checkbox" for="Loanentries_Schedule">
    <input id="ytLoanentries_Schedule" runat = "server" type="hidden" value="I" name="Loanentries[Schedule]" />
    <input size="1" maxlength="1" value="A" name="Loanentries[Schedule]" id="Loanentries_Schedule"runat = "server" type="checkbox" />
    For Deduction</label>--%>

                                            <%--<label class="checkbox" for="Loanentries_Status">
    <input id="ytLoanentries_Status" runat = "server" type="hidden" value="I" name="Loanentries[Status]" />
    <input size="1" maxlength="1" value="A" name="Loanentries[Status]" id="Loanentries_Status"runat = "server" type="checkbox" />
    Active</label>--%>
                                        </div>
                                    </div>

                                    <div class="form-actions" style="padding-top: 10px;">
                                        <asp:Button ID="btnCreate" UseSubmitBehavior="false" class="btn btn-primary" Width="80" runat="server" Text="Create" OnClick="btnCreate_Click" OnClientClick="Confirm()" ValidationGroup="LoansGroup"></asp:Button>
                                        <asp:Button ID="btnReset" class="btn btn-danger" Width="80" runat="server" Text="Reset" OnClick="btnReset_Click"></asp:Button>
                                    </div>



                                </div>
                                <%} %>
                            </div>
                        </div>
                    </div>


                    <!-- UPDATE MODAL -->
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
                                                <!-- Modal Content -->

                                                <div class="col-lg-6">
                                                    <label for="upd_DateFiled" class="required">Date Filed<span class="required text-red"></span></label>
                                                    <input class="form-control" id="upd_DateFiled" name="txtUpdEffectiveDate" type="date" min="1900-01-01" max="2099-12-31" maxlength="11" runat="server" />

                                                    <label for="upd_StartDeduction" class="required">Start of Deduction<span class="required text-red"></span></label>
                                                    <input class="form-control" id="upd_StartDeduction" name="txtUpdEffectiveDate" type="date" min="1900-01-01" max="2099-12-31" maxlength="11" runat="server" />

                                                    <label for="upd_LoanCode" class="required">Loan Type<span class="required text-red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="upd_LoanCode" ValidationGroup="UpdLoansGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                    <select class="form-control" name="textUpdBranchCode" id="upd_LoanCode" runat="server">
                                                        <option value="">---Select Loan Type---</option>
                                                        <%--<option value="1">PROMOTION</option>
                            <option value="2">RESIGNED</option>--%>
                                                    </select>

                                                    <%--<label for="upd_LoanGranted" class="required">Loan Granted<span class="required text-red"></span></label>
                                                    <input class="form-control" id="upd_LoanGranted" name="txtRemarks" type="text" runat="server" />--%>

                                                    <%--<label for="upd_LoanAmount" class="required">Loan Amount<span class="required text-red"></span></label>
                                                    <input class="form-control" id="upd_LoanAmount" name="txtRemarks" type="text" runat="server" />--%>

                                                    <label for="Loanentries_LoanAmount" class="required">Loan Amount <span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator8" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="upd_LoanAmount" ValidationGroup="UpdLoansGroup"></asp:RequiredFieldValidator></label>
                                                                
                                                                    <%--<input class="form-control" id="upd_LoanAmount" name="upd_LoanAmount" type="number" min="0" max="100000" onkeypress="return isNumberKey(event)"  runat="server" />--%>
                                                <input class="form-control" id="upd_LoanAmount" name="upd_LoanAmount" type="text" onkeypress="return isNumberKey(this, event);"  runat="server" ondrop="return false;" onpaste="return false;" oncontextmenu="return false;"/>
                                                    </div>
                                                <div class="col-lg-6">
                                                    <%--<label for="upd_DeductionAmount" class="required">Deduction Amount<span class="required text-red"></span></label>
                                                    <input class="form-control" id="upd_DeductionAmount" name="txtRemarks" type="text" runat="server" />--%>

                                                    <label for="Loanentries_LoanAmount" class="required">Deduction Amount<span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator9" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="upd_DeductionAmount" ValidationGroup="UpdLoansGroup"></asp:RequiredFieldValidator></label>
                                                                
                                                                    <%--<input class="form-control" id="upd_DeductionAmount" name="upd_DeductionAmount" type="number" min="0" max="100000" onkeypress="return isNumberKey(event)"  runat="server" />--%>
                                                    <input class="form-control" id="upd_DeductionAmount" name="upd_DeductionAmount" type="text" onkeypress="return isNumberKey1(this, event);"  runat="server" ondrop="return false;" onpaste="return false;" oncontextmenu="return false;"/>
                                                

                                                    <%--<label for="upd_AmountPaid" class="required">Amount Paid<span class="required text-red"></span></label>
                                                    <input class="form-control" id="upd_AmountPaid" name="txtRemarks" type="text" runat="server" />--%>

                                                    <label for="Loanentries_LoanAmount" class="required">Amount Paid<span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator10" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="upd_AmountPaid" ValidationGroup="UpdLoansGroup"></asp:RequiredFieldValidator></label>
                                                                
                                                                    <%--<input class="form-control" id="upd_AmountPaid" name="upd_AmountPaid" type="number" min="0" max="100000" onkeypress="return isNumberKey(event)"  runat="server" />--%>
                                                <input class="form-control" id="upd_AmountPaid" name="upd_AmountPaid" type="text" onkeypress="return isNumberKey1(this, event);"  runat="server" ondrop="return false;" onpaste="return false;" oncontextmenu="return false;"/>

                                                    <%--<label for="upd_Balance" class="required">Balance<span class="required text-red"></span></label>
                                                    <div class="input-group date">
                                                        <input class="form-control" id="upd_Balance" name="txtRemarks" type="text" runat="server" />


                                                    </div>--%>
                                                    <label for="Loanentries_LoanAmount" class="required">Balance<span class="required text-red">*</span><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator12" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="upd_Balance" ValidationGroup="UpdLoansGroup"></asp:RequiredFieldValidator></label>
                                                                
                                                                    <%--<input class="form-control" id="upd_Balance" name="upd_Balance" type="number" min="0" max="100000" onkeypress="return isNumberKey(event)"  runat="server" />--%>
                                                <input class="form-control" id="upd_Balance" name="upd_Balance" type="text" onkeypress="return isNumberKey1(this, event);"  runat="server" ondrop="return false;" onpaste="return false;" oncontextmenu="return false;"/>

                                                    <%--<asp:CheckBox ID="upd_GroupCode" runat="server" CssClass="checkbox-inline" Text="For Deduction"></asp:CheckBox>&ensp;--%>
                                    <asp:CheckBox ID="upd_Active" runat="server" CssClass="checkbox-inline" Text="Active Deduction"></asp:CheckBox>
                                                </div>


                                            <%--</div>--%>
                                            <div class="modal-footer">
                                                <asp:Button ID="btnsaveUpdate" runat="server" Text="Update" CssClass="btn btn-primary"
                                                    OnClick="btnsaveUpdate_Click" OnClientClick="Confirm1()" ValidationGroup="UpdLoansGroup"></asp:Button>


                                            </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnsaveUpdate" />
                                    </Triggers>
                                </asp:UpdatePanel>

                            </div>
                        </div>
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
                    </div>
                    <!--VIEW MODAL-->
                    
                </section>
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
                                        <div class="modal-body">
                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                            <div class="row">
                                                <!-- View Modal Content -->

                                                <div class="col-lg-6">
                                                    <label for="view_DateFiled" class="required">Date Filed</label>
                                                    <input class="form-control" id="view_DateFiled" name="txtUpdEffectiveDate" type="date" min="01-01-1990" max="12-31-2099" maxlength="11" runat="server" disabled="disabled" />
                                                    <label for="view_StartDeduction" class="required">Start of Deduction</label>
                                                    <input class="form-control" id="view_StartDeduction" name="txtUpdEffectiveDate" type="date" min="01-01-1990" max="12-31-2099" maxlength="11" runat="server" disabled="disabled" />
                                                    <label for="view_LoanType" class="required">Loan Type</label>
                                                    <input class="form-control" id="view_LoanType" name="txtBranchCode" type="text" runat="server" disabled="disabled" />
                                                    <%--<label for="view_LoanGranted" class="required">Loan Granted</span></label>
                                                    <input class="form-control" id="view_LoanGranted" name="txtRemarks" type="text" runat="server" disabled="disabled" />--%>
                                                    <label for="view_LoanAmount" class="required">Loan Amount</label>
                                                    <input class="form-control" id="view_LoanAmount" name="txtDeptCode" type="text" runat="server" disabled="disabled" />
                                                </div>
                                                <div class="col-lg-6">
                                                    <label for="view_DeductionAmount" class="required">Deduction Amount</label>
                                                    <input class="form-control" id="view_DeductionAmount" name="view_DeductionAmount" type="text" runat="server" disabled="disabled" />
                                                    <label for="view_AmountPaid" class="required">Amount Paid</label>
                                                    <input class="form-control" id="view_AmountPaid" name="view_AmountPaid" type="text" runat="server" disabled="disabled" />
                                                    <label for="view_Balance" class="required">Balance</label>
                                                    <input class="form-control" id="view_Balance" name="view_Balance" type="text" runat="server" disabled="disabled" />
                                                    <%--<label for="view_ForDeduction" class="required">For Deduction</label>
                                                    <input class="form-control" id="view_ForDeduction" name="txtGroupCode" type="text" runat="server" disabled="disabled" />--%>
                                                    <label for="view_Active" class="required">Active Deduction</label>
                                                    <input class="form-control" id="view_Active" name="view_Active" type="text" runat="server" disabled="disabled" />
                                                </div>

                                            </div>


                                        </div>



                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                        </div>
                    </div>
            </div>
        </div>
    </div>
</asp:Content>
