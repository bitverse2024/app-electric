<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AlphaListReportByCutOffs.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.PayrollPages.AlphaListReportByCutOffs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</style>
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
                <h3 class="m-0 text-dark">Payroll<small> Alpha List Report</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="AlphaListReportByCutOffs.aspx" class="btn btn-default"><i class="fa fa-refresh"></i><span class="h6"></span></a>

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
                                                <div class="form col-lg-6">
                                                    <label for="lbCutOffSelected" class="required">
                                                                        Select an Item:</label>
                                                    <br />
                                                    <asp:ListBox ID="lbCutOff" runat="server">
                                                        
                                                    </asp:ListBox>

                                                    
                                                </div>
                                                
                                                <div class="form col-lg-6">
                                                    <label for="lbCutOffSelected" class="required">
                                                                        Selected Items:</label>
                                                    <br />
                                                    <asp:ListBox ID="lbCutOffSelected" runat="server">
                                                        
                                                    </asp:ListBox>
                                                    
                                                </div>
                                                
                                                
                                                
                                            </div>
                                            <%--<div class="row">
                                                <div class="form col-lg-1">
                                                    
                                                    
                                                    <asp:LinkButton ID="SelectButton" runat="server" CssClass="btn btn-info"><i class=""></i>&nbsp;Select</asp:LinkButton>
                                                    
                                                </div>
                                                </div>--%>
                                            <div class="row">
                                                <div class="form col-lg-4" style="padding-top:30px">
                                                    <asp:Button ID="Button2" runat="server" class="btn btn-primary" Text="Clear"
                                                            OnClick="btnclear_Click"></asp:Button>
                                                     <asp:Button ID="btnSearch" runat="server" class="btn btn-success" Text="Process"
                                                            OnClick="btnSearch_Click" ValidationGroup="NetPayBankSummaryGroup"></asp:Button>
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


