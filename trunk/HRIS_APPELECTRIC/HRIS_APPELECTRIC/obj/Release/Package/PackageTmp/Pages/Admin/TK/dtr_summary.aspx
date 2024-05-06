<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="dtr_summary.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.TK.dtr_summary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                <h3 class="m-0 text-dark">DTR<small> DTR Summary</small></h3>
                <section class="card">
                    <div class="card-header">
                        <%if (Session["ROLES"].ToString() == "admin")
                            { %>
                        <a href="<%= ResolveUrl("~/Default.aspx")%>" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Back to Home</span></a>
                        <%}%>
                        <%if (Session["ROLES"].ToString() == "hrtimekeeper")
                            { %>
                        <a href="<%= ResolveUrl("~/Default_kioskTK.aspx")%>" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Back to Home</span></a>
                        <%}%>
                        <a href="dtr_summary.aspx" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                        <%--<a target="" href="ExportDTRSummaryPDF.aspx" class="btn btn-default"><i class="fa fa-download"></i><span class="h5">Export to PDF</span></a>--%>
                        <a href="ExportDTRSummaryExcel.aspx" class="btn btn-default"><i class="fa fa-download"></i><span class="h6">Export to Excel</span></a>
                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="box-body">
                                    <div class="search-form" style="display: none">

                                        <div style="display: none">
                                            <input type="hidden" value="payrollsum/index" name="r" />
                                        </div>
                                        <div class="container">
                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <label for="Payrollsum_CODate">Pay Period</label><input class="form-control" name="Payrollsum[CODate]" id="Payrollsum_CODate" type="text" />
                                                    <label for="Payrollsum_name">Name</label><input class="form-control" maxlength="50" name="Payrollsum[name]" id="Payrollsum_name" type="text" />
                                                    <label for="Payrollsum_Days">Days</label><input class="form-control" name="Payrollsum[Days]" id="Payrollsum_Days" type="text" />
                                                    <label for="Payrollsum_OTReg">Reg OT</label><input class="form-control" name="Payrollsum[OTReg]" id="Payrollsum_OTReg" type="text" />
                                                </div>
                                                <div class="col-lg-4">
                                                    <label for="Payrollsum_UTmin">Undertime</label><input class="form-control" name="Payrollsum[UTmin]" id="Payrollsum_UTmin" type="text" />
                                                    <label for="Payrollsum_Latesmin">Lates</label><input class="form-control" name="Payrollsum[Latesmin]" id="Payrollsum_Latesmin" type="text" />
                                                    <label for="Payrollsum_absent">Absent</label><input class="form-control" maxlength="50" name="Payrollsum[absent]" id="Payrollsum_absent" type="text" />
                                                </div>
                                            </div>
                                        </div>



                                        <div class="form-actions">
                                            <button class="btn btn-primary" type="submit" name="yt0"><i class="icon-search icon-white"></i>Search</button>
                                            <button class="btnreset btn-small btn" name="yt1" type="button"><i class="icon-remove-sign white"></i>Reset</button>
                                        </div>


                                        <script>
                                            $(".btnreset").click(function () {
                                                $(":input", "#search-payrollsum-form").each(function () {
                                                    var type = this.type;
                                                    var tag = this.tagName.toLowerCase(); // normalize case
                                                    if (type == "text" || type == "password" || tag == "textarea") this.value = "";
                                                    else if (type == "checkbox" || type == "radio") this.checked = false;
                                                    else if (tag == "select") this.selectedIndex = "";
                                                });
                                            });
                                        </script>

                                    </div>
                                    <!-- search-form -->

                                   <div style="overflow-x: auto;" id="display-grid" class="grid-view">
                                        <div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>
                                        <asp:GridView ID="GridViewList" runat="server" AutoGenerateColumns="False"
                                            ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                            GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                            ForeColor="Black" OnRowCommand="GridViewList_RowCommand"
                                            OnPageIndexChanging="GridViewList_PageIndexChanging"
                                            ViewStateMode="Enabled">
                                            <EmptyDataTemplate>
                                                <center><h1>NO SUMMARY AVAILABLE</h1></center>
                                            </EmptyDataTemplate>
                                            <Columns>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkbtn_1" CssClass="h8" Text='Pay Period' runat="server" CommandName="Sort" CommandArgument="CODate"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtSearchCODate" TextMode="Date" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <span class=""><%# Eval("CODate") %></span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkbtn_2" CssClass="h8" Text='Name' runat="server" CommandName="Sort" CommandArgument="PSname"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtSearchName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <span class=""><%# Eval("PSname") %></span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkbtn_3" CssClass="h8" Text='Days' runat="server" CommandName="Sort" CommandArgument="PSDays"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtSearchPSDays" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <span class=""><%# Eval("PSDays") %></span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkbtn_4" CssClass="h8" Text='Absent' runat="server" CommandName="Sort" CommandArgument="PSabsent"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtSearchPSAbsent" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <span class=""><%# Eval("PSabsent") %></span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkbtn_5" CssClass="h8" Text='Lates' runat="server" CommandName="Sort" CommandArgument="Latesmin"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtSearchLates" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <span class=""><%# Eval("Latesmin") %></span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkbtn_6" CssClass="h8" Text='Undertime' runat="server" CommandName="Sort" CommandArgument="UTmin"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtSearchUT" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <span class=""><%# Eval("UTmin") %></span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkbtn_7" CssClass="h8" Text='Reg OT' runat="server" CommandName="Sort" CommandArgument="OTReg"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtSearchOT" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <span class=""><%# Eval("OTReg") %></span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <%--<asp:Button ID="btnAction" CssClass="btn-success btn-xs" runat="server" Text="Action"  CommandName="action" CommandArgument='<%# Eval("id") %>'  />--%>
                                                        <%--<asp:Button ID="btnUpdate" CssClass="btn-success btn-xs" runat="server" Text="Update"   CommandName="upd" CommandArgument='<%# Eval("id") %>'  />--%>
                                                        <%--<asp:Button ID="btnDelete" CssClass="btn-danger btn-xs" runat="server" Text="Delete"  CommandName="del" CommandArgument='<%# Eval("id") %>'  />--%>
                                                        <center>
                                                            <asp:LinkButton ID="btnView" runat="server" ForeColor="Black" Font-Size="Medium" CommandName="view" CommandArgument='<%# Eval("id") %>'><i class="fa fa-eye"></i></asp:LinkButton>&ensp;
                                                            <asp:LinkButton ID="btnUpdate" runat="server" ForeColor="Black" Font-Size="Medium" CommandName="upd" CommandArgument='<%# Eval("id") %>'><i class="fa fa-edit"></i></asp:LinkButton>&ensp;
                                                            <asp:LinkButton ID="btnDelete" runat="server" ForeColor="Black" Font-Size="Medium" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;"  CommandName="del" CommandArgument='<%# Eval("id") %>'><i class="fa fa-trash"></i></asp:LinkButton>
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

                </section>
            </div>
        </div>
    </div>

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
                                    <label for="updCODate">Pay Period</label>
                                    <input class="form-control" id="updCODate" type="text" runat="server" />
                                    <%--   <select class="form-control" id="updCODate" runat="server">
                                        <option value="">---Select Pay Period---</option>
                                    </select>--%>
                                    <label for="updDays">Days</label>
                                    <input class="form-control" id="updDays" type="text" runat="server" />
                                    <label for="updRegHrsWnd">Reg Hrs Wnd</label>
                                    <input class="form-control" id="updRegHrsWnd" type="text" runat="server" />
                                    <label for="updRegOT">Reg OT</label>
                                    <input class="form-control" id="updRegOT" type="text" runat="server" />
                                    <label for="updOTWND">OT WND</label>
                                    <input class="form-control" id="updOTWND" type="text" runat="server" />
                                    <label for="updRegSun">Reg Sun</label>
                                    <input class="form-control" id="updRegSun" type="text" runat="server" />
                                    <label for="updSunOT">Sun OT</label>
                                    <input class="form-control" id="updSunOT" type="text" runat="server" />
                                </div>
                                <div class="col-lg-6">
                                    <label for="updOtlh">Otlh</label>
                                    <input class="form-control" id="updOtlh" type="text" runat="server" />
                                    <label for="updOtlhexc8Hrs">Otlhexc8 Hrs</label>
                                    <input class="form-control" id="updOtlhexc8Hrs" type="text" runat="server" />
                                    <label for="updEcola">Ecola</label>
                                    <input class="form-control" id="updEcola" type="text" runat="server" />
                                    <label for="updAbsent">Absent</label>
                                    <input class="form-control" id="updAbsent" type="text" runat="server" />
                                    <label for="updUndertime">Undertime</label>
                                    <input class="form-control" id="updUndertime" type="text" runat="server" />
                                    <label for="updLates">Lates</label>
                                    <input class="form-control" id="updLates" type="text" runat="server" />
                                </div>
                            </div>


                        </div>
                        <div class="modal-footer">
                            <label for=""></label>
                            <asp:Button ID="btnsaveUpdate" runat="server" CssClass="btn-primary" Text="Apply Action"
                                OnClick="btnsaveUpdate_Click" OnClientClick="Confirm1()"></asp:Button>


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
                                    <label for="vwCODate">Pay Period</label>
                                    <input class="form-control" disabled="disabled" id="vwCODate" type="text" runat="server" />
                                    <%--   <select class="form-control" id="updCODate" runat="server">
                                        <option value="">---Select Pay Period---</option>
                                    </select>--%>
                                    <label for="vwDays">Days</label>
                                    <input class="form-control" disabled="disabled" id="vwDays" type="text" runat="server" />
                                    <label for="vwRegHrsWnd">Reg Hrs Wnd</label>
                                    <input class="form-control" disabled="disabled" id="vwRegHrsWnd" type="text" runat="server" />
                                    <label for="vwRegOT">Reg OT</label>
                                    <input class="form-control" disabled="disabled" id="vwRegOT" type="text" runat="server" />
                                    <label for="vwOTWND">OT WND</label>
                                    <input class="form-control" disabled="disabled" id="vwOTWND" type="text" runat="server" />
                                    <label for="vwRegSun">Reg Sun</label>
                                    <input class="form-control" disabled="disabled" id="vwRegSun" type="text" runat="server" />
                                    <label for="vwSunOT">Sun OT</label>
                                    <input class="form-control" disabled="disabled" id="vwSunOT" type="text" runat="server" />
                                </div>
                                <div class="col-lg-6">
                                    <label for="vwOtlh">Otlh</label>
                                    <input class="form-control" disabled="disabled" id="vwOtlh" type="text" runat="server" />
                                    <label for="vwOtlhexc8Hrs">Otlhexc8 Hrs</label>
                                    <input class="form-control" disabled="disabled" id="vwOtlhexc8Hrs" type="text" runat="server" />
                                    <label for="vwEcola">Ecola</label>
                                    <input class="form-control" disabled="disabled" id="vwEcola" type="text" runat="server" />
                                    <label for="vwAbsent">Absent</label>
                                    <input class="form-control" disabled="disabled" id="vwAbsent" type="text" runat="server" />
                                    <label for="vwUndertime">Undertime</label>
                                    <input class="form-control" disabled="disabled" id="vwUndertime" type="text" runat="server" />
                                    <label for="vwLates">Lates</label>
                                    <input class="form-control" disabled="disabled" id="vwLates" type="text" runat="server" />
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
</asp:Content>
