<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PayrollRegisterReport.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.PayrollPages.PayrollRegisterReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.2.1.min.js">
      </script>
    <script type="text/javascript">
         $(function() {
            $( "#date" ).datepicker({dateFormat: 'yy'});
         });
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
                <h4 class="m-0 text-dark">Payroll Register Report<small></small></h4>
                <section class="card">
                    <div class="card-header">
                        <a href="PayrollRegisterReport.aspx" class="btn btn-default"><i class="fa fa-refresh"></i><span class="h6"></span></a>

                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="box-body">
                                    <div class="form">

                                        <fieldset>
                                            <%--<legend>
                                                <p class="note">Fields with <span class="required">*</span> are required.</p>
                                            </legend>--%>


                                            <div class="row">
                                                <div class="form col-lg-4">
                                                    <%--<asp:ListBox ID="lbCutOff" runat="server">
                                                        
                                                    </asp:ListBox>--%>

                                                    <label for="lblCreditDate" class="required">
                                                                        Cutoff<span class="required text-red">*</span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server"
                                                                            ErrorMessage="Field Required" ValidationGroup="GenerateGroup"
                                                                            ControlToValidate="ddlCredDate"></asp:RequiredFieldValidator></label>
                                                                    <asp:DropDownList ID="ddlCredDate" CssClass="form-control" runat="server">
                                                                        <asp:ListItem Enabled="true" Text="----SELECT CUTOFF----" Value=""></asp:ListItem>
                                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form col-lg-4">
                                                    <%--<asp:ListBox ID="lbCutOffSelected" runat="server">
                                                        
                                                    </asp:ListBox>--%>
                                                    
                                                </div>
                                                
                                                
                                                
                                            </div>
                                            <div class="row">
                                                <div class="form col-lg-4" style="padding-top:30px">
                                                    <%--<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Click Here " />--%>
                                                     <asp:Button ID="btnSearch" runat="server" class="btn btn-primary" Text="Process"
                                                            OnClick="btnSearch_Click" ValidationGroup="GenerateGroup"></asp:Button>
                                                </div>
                                            </div>
                                            <br />
                                                    <div class="footer">
                                                       
                                                        
                                                    </div>
                                            <br />
                                            
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>

            </div>
            <!-- content -->
        </div>
    </div>
</asp:Content>



