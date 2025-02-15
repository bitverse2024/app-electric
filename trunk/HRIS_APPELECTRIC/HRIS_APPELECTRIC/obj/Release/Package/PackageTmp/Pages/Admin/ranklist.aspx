﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ranklist.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.ranklist" %>

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
                    <h3 class="m-0 text-dark">Admin<small> Ranks</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="AdminPage.aspx" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Back</span></a>
                            <a href="createrank.aspx" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                            <a href="ranklist.aspx" class="btn btn-default"><i class="fa fa-th-list"></i><span class="h6">List</span></a>
                            <a runat="server" class="btn btn-default" onserverclick="ExportToPDF"><i class="fa fa-arrow-circle-o-up"></i><span class="h6">Export to PDF</span></a>
                            <a runat="server" class="btn btn-default" onserverclick="btnExport_Click"><i class="fa fa-arrow-circle-o-up"></i><span class="h6">Export to Excel</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">
                                        <%--<a href="#" class="btn btn-app search-button">
                <i class="fa fa-search"></i>
                Search
            </a>--%>
                                        <div class="search-form" style="display: none">

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

                                            <script>
                                                $(".btnreset").click(function () {
                                                    $(":input", "#search-rank-form").each(function () {
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
                                                OnPageIndexChanging="GridViewList_PageIndexChanging"
                                                ViewStateMode="Enabled">
                                                <EmptyDataTemplate>
                                                    <center><h1>NO RANK AVAILABLE</h1></center>
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>

                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkRankName" CssClass="h8" Text='Rank Name' runat="server" CommandName="Sort" CommandArgument="RankName"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchRankName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRankName" CssClass="" Text='<%# Eval("RankName") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkGracePeriod" CssClass="h8" Text='Grace Period' runat="server" CommandName="Sort" CommandArgument="GracePeriod"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchGracePeriod" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGracePeriod" CssClass="" Text='<%# Eval("GracePeriod") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkallowance1" CssClass="h8" Text='Meal Allowance Reg' runat="server" CommandName="Sort" CommandArgument="allowance1"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtallowance1" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblallowance1" CssClass="" Text='<%# Eval("allowance1") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lblallowance2" CssClass="h8" Text='Meal Allowance RES/Hol' runat="server" CommandName="Sort" CommandArgument="allowance2"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtallowance2" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblallowance2" CssClass="" Text='<%# Eval("allowance2") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderStyle-Width="15%">
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
                                <!-- Input Text to update -->

                                <div class="col-lg-6">
                                    <label for="upd_RankName" class="required">
                                        Rank Name<span class="required">*<asp:RequiredFieldValidator ID="validatorUploader" runat="server" ControlToValidate="upd_RankName" ValidationGroup="UpdateRankGroup" ForeColor="Red" ErrorMessage="Field Required">
                                        </asp:RequiredFieldValidator></span></label>
                                    <div class="input-group date">
                                        <input class="form-control" id="upd_RankName" name="txtRankName" type="text" runat="server" />
                                    </div>

                                    <label for="upd_GracePeriod" class="required">Grace Period</label>
                                    <div class="input-group date">
                                        <input class="form-control" id="upd_GracePeriod" name="txtGracePeriod" type="text" runat="server" />
                                    </div>
                                    <label for="upd_allowance1" class="required">Meal Allowance Reg</label>
                                    <div class="input-group date">
                                        <input class="form-control" id="upd_allowance1" name="txtallowance1" type="text" runat="server" />
                                    </div>

                                </div>
                                <div class="col-lg-6">
                                    <label for="upd_RankDesc" class="required">Rank Desc</label>
                                    <div class="input-group date">

                                        <input class="form-control" id="upd_RankDesc" name="txtRankDesc" type="text" runat="server" />
                                    </div>
                                    <label for="upd_allowance2" class="required">Meal Allowance Res/Hol</label>
                                    <div class="input-group date">

                                        <input class="form-control" id="upd_allowance2" name="txtallowance2" type="text" runat="server" />
                                    </div>
                                    <div >
                                        <span class="">
                                            <label class="checkbox" for="Rank_Ot">
                                                <input id="ytRank_Ot" type="hidden" value="0" name="Rank[Ot]"><input size="1" maxlength="1" value="1" name="Rank[Ot]" id="Rank_Ot" type="checkbox" runat="server"></input></input>
                                                With Overtime</label></span>
                                    </div>
                                </div>


                            </div>


                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Update" CssClass="btn btn-primary" UseSubmitBehavior="true"
                                OnClick="btnsaveUpdate_Click" OnClientClick="Confirm()" ValidationGroup="UpdateRankGroup"></asp:Button>


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
                                    <input class="form-control" id="vw_ID" name="vw_ID" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_RankName" class="required">Rank Name</label>
                                    <input class="form-control" id="vw_RankName" name="vw_RankName" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_RankDesc" class="required">Rank Description</label>
                                    <input class="form-control" id="vw_RankDesc" name="vw_RankDesc" type="text" runat="server" disabled="disabled" />
                                    <div>
                                        <span class="">
                                            <label class="checkbox" for="Rank_Ot">
                                                <input id="Hidden1" type="hidden" value="0" name="Rank[Ot]"><input size="1" maxlength="1" value="1" name="Rank[Ot]" id="vw_OT" type="checkbox" runat="server"></input></input>
                                                With Overtime</label></span>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <label for="vw_GracePeriod" class="required">Grace Period</label>
                                    <input class="form-control" id="vw_GracePeriod" name="vw_GracePeriod" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_allowance1" class="required">Meal Allowance Reg</label>
                                    <input class="form-control" id="vw_allowance1" name="vw_allowance1" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_allowance2" class="required">Meal Allowance RES/Hol</label>
                                    <input class="form-control" id="vw_allowance2" name="vw_allowance2" type="text" runat="server" disabled="disabled" />
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
