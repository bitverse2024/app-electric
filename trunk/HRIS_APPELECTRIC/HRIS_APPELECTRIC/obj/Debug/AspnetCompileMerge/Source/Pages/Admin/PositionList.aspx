<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="PositionList.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.PositionList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type = "text/javascript">
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
    <script type = "text/javascript">
        function Confirm1() {
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
                    <h3 class="m-0 text-dark">Admin<small> Add New Position</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="DivisionList.aspx" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Back to List</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
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
                                                        ViewStateMode="Enabled">
                                                        <EmptyDataTemplate>
                                                            <center><h1>NO POSITION AVAILABLE</h1></center>
                                                        </EmptyDataTemplate>
                                                        <Columns>
                                                            <asp:TemplateField Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="linkbtn_1" Text='Position Name' runat="server" CommandName="Sort" CommandArgument="PositionName"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtSearchPosName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Eval("PositionName")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="lblReset" Text='Actions' runat="server" CommandName="Action" CommandArgument="Action"></asp:LinkButton><br />

                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnView" CssClass="btn-success btn-xs" runat="server" Text="View" CommandName="view" CommandArgument='<%# Eval("id") %>' />
                                                                    <asp:Button ID="btnUpdate" CssClass="btn-success btn-xs" runat="server" Text="Update" CommandName="upd" CommandArgument='<%# Eval("id") %>' />
                                                                    <asp:Button ID="btnDelete" CssClass="btn-danger btn-xs" runat="server" Text="Delete" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;" CommandName="del" CommandArgument='<%# Eval("id") %>' />
                                                                </ItemTemplate>

                                                            </asp:TemplateField>


                                                        </Columns>
                                                    </asp:GridView>

                                                </div>
                                            </div>
                                            <div class="form">
                                                <form enctype="multipart/form-data" class="form-horizontal" id="position-form" action="/index.php?r=department/viewposition&amp;id=37" method="post">
                                                    <legend>
                                                        <p class="note">Fields with <span class="required text-red">*</span> are required.</p>
                                                    </legend>


                                                    <div class="row">
                                                        <div class="col-lg-6">
                                                            <div class="control-group ">
                                                                <label class="control-label" for="Position_PositionName">Position Name <span class="required text-red">*</span></label><div class="controls">
                                                                    <input class="form-control" maxlength="40" name="Position[PositionName]" id="Position_PositionName" type="text" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="form-actions">
                                                        <asp:Button ID="btnCreate" class="btn btn-primary" Width="80px" runat="server" Text="Create" UseSubmitBehavior="true"
                                                            OnClick="btnCreate_Click" OnClientClick="Confirm1()"></asp:Button>
                                                        <asp:Button ID="btnReset" class="btn btn-danger" runat="server" Width="80px" Text="Reset" UseSubmitBehavior="true"
                                                            OnClick="btnReset_Click"></asp:Button>
                                                    </div>


                                                </form>
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

                                <div class="col-lg-8">
                                    <label for="upd_Pos" class="required">
                                        Position Name<span class="required">*</span><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" ControlToValidate="upd_Pos"
                                            ForeColor="Red" ValidationGroup="updos"></asp:RequiredFieldValidator></label>
                                    <div class="input-group date">

                                        <input class="form-control" id="upd_Pos" type="text" runat="server" />
                                    </div>

                                </div>

                            </div>


                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Update"
                                OnClick="btnsaveUpdate_Click" CssClass="btn btn-primary" UseSubmitBehavior="true"
                                OnClientClick="Confirm()" ValidationGroup="updos"></asp:Button>


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
                                    <label for="vw_DivisionName" class="required">Position Name</label>
                                    <input class="form-control" id="vw_PosName" type="text" runat="server" disabled="disabled" />
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
