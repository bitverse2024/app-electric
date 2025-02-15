﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="viewdts.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.TK.viewdts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <aside class="right-side">
        <!-- Small boxes (Stat box) -->

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
                    <h3 class="m-0 text-dark">Employee<small> <%=getname() %></small></h3>
                    <section class="card">
                        <div class="card-header">
                            <%if (Session["ROLES"].ToString() == "admin")
                                { %>
                            <a href="dts.aspx" class="btn btn-default"><i class="fa fa-home"></i><span class="h6">Home</span></a>
                            <%} %>
                            <%if (Session["ROLES"].ToString() == "employee")
                                { %>
                            <a href="viewdts.aspx" class="btn btn-default"><i class="fa fa-home"></i><span class="h6">Home</span></a>
                            <%} %>
                            <a target="" href="" runat="server" onserverclick="btnExport_Click" ValidationGroup="viewdts" class="btn btn-default"><i class="fa fa-download"></i><span class="h6">Export to Excel</span></a>
                            <%--<a href="submitdtr.aspx" class="btn btn-default"><i class="fa fa-edit"></i><span class="h6">Submit DTR</span></a>--%>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <!--<h4 class="note">Select Cut-off date to view.</h4>-->
                                    <div class="printableArea">
                                        <div id="list">
                                            <table>
                                                <!--<td><input type="text" id="asset" name="keyword" size="60" class="form-control" autocomplete="off" style="height:32px;width:100%;"/></td>-->
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            
                                                            <select name="DTS[BussDate]" id="DTS_BussDate" runat="server" class="form-control" autocomplete="off" style="height: 40px; width: 300px;">
                                                                <%--<option name="">--- Select Cut-off Date --- </option>--%>
                                                                <option value="">--- Select Cut-off Date ---</option>

                                                            </select>
                                                            

                                                        </td>
                                                        <asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator9" runat="server" ErrorMessage="Field Required" ForeColor="Red"
                                                                    ControlToValidate="DTS_BussDate" ValidationGroup="viewdts"></asp:RequiredFieldValidator>
                                                        <td style="padding-left: 30px">
                                                            <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-primary"
                                                                Style="padding: 10px; margin-left: -21px; margin-top: -2px; font-weight: bold;"
                                                                OnClick="btnSearch_Click"  ValidationGroup="viewdts"></asp:Button></td>
                                                    </tr>
                                                </tbody>
                                            </table>

                                            <h5>
                                                <asp:Label ID="lbl1HideShow" runat="server" Text="Employee Daily Time Record from  " Visible="false"></asp:Label>
                                                <span style="font-weight: bold;">
                                                    <asp:Label ID="lblHideShow2" runat="server" Text="" Visible="false"></asp:Label>
                                                </span>
                                            </h5>
                                               <div id="display-grid" class="grid-view" style="overflow-x: auto;">
                                                <asp:GridView ID="GridViewList" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                                                    CssClass="items table table-striped table-bordered table-condensed" GridLines="None"
                                                    AllowPaging="True" Font-Names="Segoe UI" ForeColor="Black" OnDataBound="OnDataBound"
                                                    OnPageIndexChanging="GridViewList_PageIndexChanging" ViewStateMode="Enabled"
                                                    PageSize="16">
                                                    <EmptyDataTemplate>
                                                        <center><h1>NO DTR AVAILABLE</h1></center>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text="LAST, FIRST MI" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmpName" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("Emp_Name")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text="SHIFT" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblShift" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("ShiftName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text="Day, MM/DD/YY" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBussDate" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("BussDate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="Label4" runat="server" Text="IN" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDTIn" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("DTimeIn")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="Label5" runat="server" Text="OUT" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDTOut" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("DTimeOut")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblRemarks" runat="server" Text="" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                 <span class="<%# Eval("Remarks").ToString()=="ABS" ? "text-red" : ""%>">
                                                                    <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("Remarks") %>' CssClass=" text-sm text-bold"></asp:Label></span>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="Label6" runat="server" Text="(DAYS)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotDays" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("TotDays")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="Label6" runat="server" Text="(HRS)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblHrs" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("TotHrs")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="Label6" runat="server" Text="(DAYS)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAbs" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("AbsentDays")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="Label6" runat="server" Text="(HRS)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAbsHrs" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("AbsHrs")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblDays" runat="server" Text="(DAYS)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLWP" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("LWPDays")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblHrs" runat="server" Text="(HRS)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLWPHrs" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("LWPHrs")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblDays1" runat="server" Text="(DAYS)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLWOP" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("LWOPDays")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblDays2" runat="server" Text="(HRS)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLWOPHrs" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("LWOPHrs")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblLate" runat="server" Text="(HRS)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLates" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("Lates")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblITs" runat="server" Text="(HRS)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUT" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("UT")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblRegs" runat="server" Text="(8HRS)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblReg" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("RegOT")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblOTND1" runat="server" Text="(ND)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRegND" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("RegOTND")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblOT1" runat="server" Text="(8HRS)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLHOT" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("LHOT")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblOT8a" runat="server" Text="(>8HRS)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLJOT8Hrs" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("LHOT8Hrs")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblOTND2" runat="server" Text="(ND)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLHOTND" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("LHOTND")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblOT3" runat="server" Text="(8HRS)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label7" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("RDLHOT")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblOT8b" runat="server" Text="(>8HRS)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRDLHOT8Hrs" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("RDLHOT8Hrs")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblOTND3" runat="server" Text="(ND)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRDLHOTND" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("RDLHOTND")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblOT4" runat="server" Text="(8HRS)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRDOT" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("RDOT")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblOT8c" runat="server" Text="(>8HRS)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRDOT8Hrs" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("RDOT8Hrs")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblOTND5" runat="server" Text="(ND)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRDOTND" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("RDOTND")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblOT6" runat="server" Text="(8HRS)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSHOT" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("SHOT")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblOT8d" runat="server" Text="(>8HRS)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSHOT8Hrs" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("SHOT8Hrs")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblOTND7" runat="server" Text="(ND)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSHOTND" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("SHOTND")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                      <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblOT8" runat="server" Text="(8HRS)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRDSHOT" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("RDSHOT")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblOT8e" runat="server" Text="(>8HRS)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRDSHOT8Hrs" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("RDSHOT8Hrs")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblOTND8" runat="server" Text="(ND)" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label7" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("RDSHOTND")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblSub" runat="server" Text="YES/NO" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSubmit" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("Submit")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblDateDub" runat="server" Text="DATE SUBMITTED" Style="color: #3c8dbc; font-size: 9px;"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDatedubmitted" Style="font-size: 10px; font-weight: bold;" runat="server"
                                                                    Text='<%# Eval("DateSubmit")%>'></asp:Label>
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
                    </section>
                </div>
            </div>
        </div>
        <!-- /.row (main row) -->
    </aside>
</asp:Content>
