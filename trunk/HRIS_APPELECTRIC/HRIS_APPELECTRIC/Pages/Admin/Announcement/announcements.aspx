﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="announcements.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Announcement.announcements" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function Confirm1() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to update this announcement?")) {
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
                <h3 class="m-0 text-dark">Post Announcement<small> Announcements</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="announcements.aspx" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                        <%if (Session["ROLES"].ToString() == "admin")
                            { %>
                        <a href="addannouncement.aspx" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Add Announcement</span></a>
                        <a id="A3" runat="server" onserverclick="btnExport_Click" class="btn btn-default"><i class="fa fa-arrow-circle-o-up"></i><span class="h6">Export to Excel</span></a>
                        <%} %>
                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="box-body">
                                    <div class="search-form" style="display: none">

                                        <div style="display: none">
                                            <input type="hidden" value="dtr/index" name="r" />
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <label for="Dtr_id">ID</label>
                                                <input class="form-control" name="Dtr[id]" id="Dtr_id" type="text" />
                                                <label for="Dtr_EmpID">Emp</label>
                                                <input class="form-control" maxlength="6" name="Dtr[EmpID]" id="Dtr_EmpID" type="text" />
                                                <label for="Dtr_BussDate">Buss Date</label>
                                                <input class="form-control" name="Dtr[BussDate]" id="Dtr_BussDate" type="text" />
                                                <label for="Dtr_DateIn">Date In</label><input class="form-control" name="Dtr[DateIn]" id="Dtr_DateIn" type="text" />
                                            </div>
                                            <div class="col-lg-6">
                                                <label for="Dtr_TimeIn">Time In</label>
                                                <input class="form-control" maxlength="5" name="Dtr[TimeIn]" id="Dtr_TimeIn" type="text" />
                                                <label for="Dtr_DateOut">Date Out</label>
                                                <input class="form-control" name="Dtr[DateOut]" id="Dtr_DateOut" type="text" />
                                                <label for="Dtr_TimeOut">Time Out</label>
                                                <input class="form-control" maxlength="5" name="Dtr[TimeOut]" id="Dtr_TimeOut" type="text" />

                                            </div>
                                        </div>
                                        <div class="form-actions">
                                            <button class="btn btn-primary" type="submit" name="yt0"><i class="icon-search icon-white"></i>Search</button>
                                            <button class="btnreset btn-small btn" name="yt1" type="button"><i class="icon-remove-sign white"></i>Reset</button>
                                        </div>




                                        <%-- <script>
       $(".btnreset").click(function () {
           $(":input", "#search-dtr-form").each(function () {
               var type = this.type;
               var tag = this.tagName.toLowerCase(); // normalize case
               if (type == "text" || type == "password" || tag == "textarea") this.value = "";
               else if (type == "checkbox" || type == "radio") this.checked = false;
               else if (tag == "select") this.selectedIndex = "";
           });
       });
   </script>--%>
                                    </div>
                                    <!-- search-form -->


                                    <div id="dtr-grid" class="grid-view">
                                        <asp:GridView ID="GridViewList" runat="server" AutoGenerateColumns="False"
                                            ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                            GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                            ForeColor="Black" OnRowCommand="GridViewList_RowCommand"
                                            OnPageIndexChanging="GridViewList_PageIndexChanging"
                                            ViewStateMode="Enabled" ShowHeaderWhenEmpty="true">
                                            <EmptyDataTemplate>
                                                <center><h1>NO ANNOUNCEMENT AVAILABLE</h1></center>
                                            </EmptyDataTemplate>
                                            <Columns>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkannDesc" CssClass="h8" Text='Description' runat="server" CommandName="Sort" CommandArgument="description"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtSearchannDesc" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <span class="h5"><%# Eval("description")%></span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lblReset" Text='Actions' runat="server" CommandName="Reset" CommandArgument="Reset"></asp:LinkButton><br />

                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnView" runat="server" ForeColor="Black" Text="Actions" Font-Size="Large" CommandName="view" CommandArgument='<%# Eval("id") %>'><i class="fa fa-eye"></i></asp:LinkButton>
                                                        &nbsp;
                                                        <%if (Session["ROLES"].ToString() == "admin")
                                                        { %>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Black" Font-Size="Medium" CommandName="upd" CommandArgument='<%# Eval("id") %>'><i class="fa fa-edit"></i></asp:LinkButton>&ensp;
                                                            <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Black" Font-Size="Medium" CommandName="del" CommandArgument='<%# Eval("id") %>' OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;"><i class="fa fa-trash"></i></asp:LinkButton>
                                                        <%} %>
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

    <!-- UPDATE MODAL -->
    <div class="modal fade" id="listmodal">
        <div class="modal-dialog">
            <div class="modal-content">

                <asp:UpdatePanel ID="upListDetails" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                    <ContentTemplate>

                        <div class="modal-header">
                            <h4 class="modal-title"><asp:Label ID="Label3" runat="server" Text="Edit Information"></asp:Label></h4>
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
                                    <label for="TaDesc" class="required">Description</label>
                                    <textarea class="form-control" maxlength="500" name="Announcements[description]" id="TaDesc" runat="server"></textarea>
                                </div>

                            </div>


                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Update" CssClass="btn btn-primary" UseSubmitBehavior="true"
                                OnClick="btnsaveUpdate_Click" OnClientClick="Confirm1()"></asp:Button>


                        </div>


                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnsaveUpdate" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>
        </div>
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
    </div>
    <!--VIEW MODAL-->
    <div class="modal fade" id="ViewModal">
        <div class="modal-dialog">
            <div class="modal-content">

                <asp:UpdatePanel ID="upListDetails2" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                    <ContentTemplate>

                        <div class="modal-header">
                            <h4 class="modal-title"><asp:Label ID="Label1" runat="server" Text="View Information"></asp:Label></h4>
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
                                    <label for="view_MovementTypeCode" class="required">Announcement Description</label>
                                    <textarea class="form-control" maxlength="500" name="Announcements[description]" id="txtDescription" runat="server" disabled="true"></textarea>



                                </div>


                            </div>


                        </div>
                        <div class="modal-footer">
                            <%--<asp:Button ID="Button1" runat="server" Text="Update" 
                            onclick="btnsaveUpdate_Click" OnClientClick="Confirm()" validationgroup = "UpdMovementGroup"></asp:Button>--%>
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
