<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="hrmrlist.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.hrmrlist" %>

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
                    <h3 class="m-0 text-dark">HR Budget TO per Division<small></small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="../../Default.aspx" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Back</span></a>
                            <a href="createhrmr.aspx" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create New</span></a>
                            <a href="hrmrlist.aspx" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                            <%--<li class=""><a class="search-button" href="#"><i class="icon-search"></i> Search</a></li>--%>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">
                                        <div class="search-form" style="display: none">

                                            <div class="wide form">

                                                    <input type="hidden" value="hrmr/index" name="r" />
                                                    <div class="row">
                                                        <label for="Hrmr_id">ID</label>
                                                        <input name="Hrmr[id]" id="Hrmr_id" type="text" />
                                                    </div>

                                                    <div class="row">
                                                        <label for="Hrmr_division">Division</label>
                                                        <input size="60" maxlength="225" name="Hrmr[division]" id="Hrmr_division" type="text" />
                                                    </div>

                                                    <div class="row">
                                                        <label for="Hrmr_position">Position</label>
                                                        <input size="60" maxlength="225" name="Hrmr[position]" id="Hrmr_position" type="text" />
                                                    </div>

                                                    <div class="row">
                                                        <label for="Hrmr_positionneeded">Position Needed</label>
                                                        <input size="60" maxlength="225" name="Hrmr[positionneeded]" id="Hrmr_positionneeded" type="text" />
                                                    </div>

                                                    <div class="row">
                                                        <label for="Hrmr_startmonth">Boarding Date</label>
                                                        <input size="60" maxlength="225" name="Hrmr[startmonth]" id="Hrmr_startmonth" type="text" />
                                                    </div>

                                                    <div class="row">
                                                        <label for="Hrmr_status">Status</label>
                                                        <input size="60" maxlength="225" name="Hrmr[status]" id="Hrmr_status" type="text" />
                                                    </div>

                                                    <div class="row buttons">
                                                        <input type="submit" name="yt0" value="Search" />
                                                    </div>

                                            </div>
                                            <!-- search-form -->
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
                                                    <center><h1>NO REQUEST AVAILABLE</h1></center>
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="linkbtn_1" CssClass="h8" Text='Division' runat="server" CommandName="Sort" CommandArgument="DivName"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchDiv" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("DivName")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="linkbtn_2" CssClass="h8" Text='Department' runat="server" CommandName="Sort" CommandArgument="DeptName"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchDept" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("DeptName")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="linkbtn_3" CssClass="h8" Text='Position' runat="server" CommandName="Sort" CommandArgument="PositionName"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchPos" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("PositionName")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="linkbtn_4" CssClass="h8" Text='Boarding Date' runat="server" CommandName="Sort" CommandArgument="startmonth"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchBdate" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("startmonth")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblstatus" Text='<%# Eval("hrmr_status") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lblReset" Text='Action' runat="server" CommandName="Reset" CommandArgument="Reset"></asp:LinkButton><br />

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%--<asp:Button ID="btnAction" CssClass="btn-success btn-xs" runat="server" Text="Action"  CommandName="action" CommandArgument='<%# Eval("id") %>'  />--%>
                                                            <asp:Button ID="btnHiring" CssClass="btn-success btn-xs" runat="server" Text="Hiring" CommandName="hir" CommandArgument='<%# Eval("id") %>' Visible='<%# ishiringenabled(Eval("hrmr_status"))%>' />
                                                            <asp:Button ID="btnRequest" CssClass="btn-success btn-xs" runat="server" Text="Request" CommandName="req" CommandArgument='<%# Eval("id") %>' Visible='<%# isrequestenabled(Eval("hrmr_status"), Eval("startmonth"))%>' />
                                                            <asp:Button ID="btnDelete" CssClass="btn-danger btn-xs" runat="server" Text="Delete" CommandName="del" CommandArgument='<%# Eval("id") %>' />
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
</asp:Content>
