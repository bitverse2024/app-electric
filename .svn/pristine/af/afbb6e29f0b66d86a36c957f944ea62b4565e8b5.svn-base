<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PayClass.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.PayClass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <aside class="right-side">
        <!-- Small boxes (Stat box) -->

        <script type="text/javascript">
            function Confirm() {
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
                    <h3 class="m-0 text-dark">Admin<small> Pay Class</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="AdminPage.aspx" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Back</span></a>
                            <a href="createPayClass.aspx" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                            <a href="PayClass.aspx" class="btn btn-default"><i class="fa fa-th-list"></i><span class="h5">List</span></a>
                            <a id="A1" class="btn btn-default" runat="server" onserverclick="ExportToPDF"><i class="fa fa-arrow-circle-o-up"></i><span class="h6">Export to PDF</span></a>
                            <a id="A2" class="btn btn-default" runat="server" onserverclick="btnExport_Click"><i class="fa fa-arrow-circle-o-up"></i><span class="h6">Export to Excel</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">
                                        <%--<a class="btn btn-app search-button">
                <i class="fa fa-search"></i>
                Advanced Search
            </a>--%>
                                        <div class="search-form" style="display: none">


                                            <script>
                                                $(".btnreset").click(function () {
                                                    $(":input", "#search-empsched-form").each(function () {
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


                                        <div id="display-grid" class="grid-view">
                                            <div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>
                                            <asp:GridView ID="GridViewList" runat="server" AutoGenerateColumns="False"
                                                ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                ForeColor="Black" OnRowCommand="GridViewList_RowCommand"
                                                OnPageIndexChanging="GridViewList_PageIndexChanging" ShowHeaderWhenEmpty="true"
                                                ViewStateMode="Enabled">
                                                <EmptyDataTemplate>
                                                    <center><h1>NO PAY CLASS AVAILABLE</h1></center>
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="linkbtn_1" CssClass="h8" Text='Pay Class Code' runat="server" CommandName="Sort" CommandArgument="PayClassCode"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchPayClassCode" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("PayClassCode")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="linkbtn_2" CssClass="h8" Text='Pay Class Desc' runat="server" CommandName="Sort" CommandArgument="PayClassName"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchPayClassDesc" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("PayClassName")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="linkbtn_3" CssClass="h8" Text='Level' runat="server" CommandName="Sort" CommandArgument="Level"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchLevel" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("Level")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderStyle-Width="10%">
                                                        <ItemTemplate>
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
                                    <label for="upd_Code" class="required">Pay Class Code</label>
                                    <input size="11" class="form-control" id="upd_Code" name="Empsched[Sched_TimeIn]" type="text" maxlength="5" runat="server" />
                                    <label for="upd_Desc" class="required">Pay Class Desc</label>
                                    <input size="11" class="form-control" id="upd_Desc" name="Empsched[Sched_TimeOut]" type="text" maxlength="5" runat="server" />
                                    <label for="upd_Level" class="required">Level</label>
                                    <input class="form-control" maxlength="50" name="Empsched[ShiftName]" id="upd_Level" type="text" runat="server" />
                                </div>

                            </div>


                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Update" CssClass="btn btn-primary" UseSubmitBehavior="true"
                                OnClick="btnsaveUpdate_Click" OnClientClick="Confirm()" ValidationGroup="SchedGroup"></asp:Button>


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
                                    <label for="vw_ID" class="required">ID</label>
                                    <input size="11" class="form-control" id="vw_ID" name="Empsched[Sched_TimeIn]" type="text" maxlength="5" runat="server" disabled="disabled" />
                                    <label for="vw_Code" class="required">Pay Class Code</label>
                                    <input size="11" class="form-control" id="vw_Code" name="Empsched[Sched_TimeIn]" type="text" maxlength="5" runat="server" disabled="disabled" />
                                    <label for="vw_Desc" class="required">Pay Class Desc</label>
                                    <input size="11" class="form-control" id="vw_Desc" name="Empsched[Sched_TimeOut]" type="text" maxlength="5" runat="server" disabled="disabled" />
                                    <label for="vw_Level" class="required">Level</label>
                                    <input class="form-control" maxlength="50" name="Empsched[ShiftName]" id="vw_Level" type="text" runat="server" disabled="disabled" />

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
