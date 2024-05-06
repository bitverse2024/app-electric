<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default_kioskapplicant.aspx.cs" Inherits="HRIS_APPELECTRIC.Default_kioskapplicant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <aside class="right-side">
        <!-- Small boxes (Stat box) -->

        <section class="content-header">
        </section>
        <!-- Main content -->
        <div class="col-md-12">
            <div class="content">
                <div class="container-fluid">
                    <div class="container"></div>
                    <h1 class="m-0 text-dark">Recruitment<small></small></h1>


                    <div class="card card-success card-tabs">
                        <div class="card-header p-0 pt-1">
                            <ul class="nav nav-tabs" role="tablist">
                                <li class="nav-item"><a data-toggle="pill" role="tab" class="nav-link active" id="tab1"
                                    href="#sectionA" aria-controls="sectionA" aria-selected="true">JOB POSTINGS</a></li>
                                <li class="nav-item"><a data-toggle="pill" role="tab" class="nav-link" id="tab2"
                                    href="#sectionB" aria-controls="sectionB" aria-selected="false">APPLICANTS</a></li>
                                <li class="nav-item"><a data-toggle="pill" role="tab" class="nav-link" id="tab3"
                                    href="#sectionC" aria-controls="sectionC" aria-selected="false">SHORTLISTED APPLICANTS</a></li>
                                <li class="nav-item"><a data-toggle="pill" role="tab" class="nav-link" id="tab4"
                                    href="#sectionD" aria-controls="sectionD" aria-selected="false">FAILED APPLICANTS</a></li>
                                <li class="nav-item"><a data-toggle="pill" role="tab" class="nav-link" id="tab5"
                                    href="#sectionE" aria-controls="sectionE" aria-selected="false">BLACKLIST APPLICANTS</a></li>
                            </ul>
                        </div>
                        <div class="card-body">
                            <div class="tab-content">
                                <div id="sectionA" class="tab-pane fade active show" role="tabpanel" aria-labelledby="tab1">
                                    <br />
                                    <!--<h3>Recent Jobs</h3>-->
                                    <!-- Search form -->
                                    <!-- <input class="form-controls" type="text" placeholder="Search Jobs By Title or Position..." aria-label="Search" style="height:34px;width:50%;"> -->
                                    <div class="container" style="overflow-y: scroll; overflow-x: hidden; height: 600px;">
                                        <div class="row col-lg-6">
                                            <%=GetJobOpenings() %>
                                        </div>
                                    </div>
                                </div>
                                <div id="sectionB" class="tab-pane fade">
                                    <a id="A1" class="btn btn-default" runat="server" onserverclick="btnExport_Click">
                                        <i class="fa fa-file-excel-o"></i>
                                        Export to Excel
                                                    </a>
                                    <a id="A3" class="btn btn-default" runat="server" onserverclick="ExportToPDF">
                                        <i class="fa fa-file-excel-o"></i>
                                        Export to PDF
                                                    </a>
                                    <br />
                                    <div class="row">
                                        <section class="col-lg-12">
                                            <div class="box box-primary">
                                                <div class="box-header">
                                                    <h3 class="box-title"><i class="fa fa-file-text"></i> ALL APPLICANTS
                                                    </h3>
                                                </div>
                                                <div class="box-body">



                                                    <div class="box-body">
                                                        <div class="search-form" style="display: none">
                                                            <form class="form-vertical" id="search-division-form" action="/index.php?r=division/index" method="get">
                                                                <input type="hidden" value="division/index" name="r" />
                                                                <div class="row">
                                                                    <div class="col-lg-6">
                                                                        <label for="Division_id">ID</label><input class="form-control" name="Division[id]" id="Division_id" type="text" />
                                                                    </div>
                                                                    <div class="col-lg-6">
                                                                        <label for="Division_DivisionName" class="required">Division Name <span class="required text-red">**</span></label><input class="form-control" maxlength="40" name="Division[DivisionName]" id="Division_DivisionName" type="text" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-actions">
                                                                    <button class="btn btn-primary" type="submit" name="yt0"><i class="icon-search icon-white"></i>Search</button>
                                                                    <button class="btnreset btn-small btn" name="yt1" type="button"><i class="icon-remove-sign white"></i>Reset</button>
                                                                </div>

                                                            </form>


                                                            <script>
                                                                $(".btnreset").click(function () {
                                                                    $(":input", "#search-division-form").each(function () {
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
                                                                    <center><h1>NO APPLICANTS AVAILABLE</h1></center>
                                                                </EmptyDataTemplate>
                                                                <Columns>
                                                                    <asp:TemplateField Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="linkbtn_1" Text='Full Name' runat="server" CommandName="Sort" CommandArgument="FullName"></asp:LinkButton><br />
                                                                            <asp:TextBox ID="txtSearchFullName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Eval("FullName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="linkbtn_2" Text='Position Desired' runat="server" CommandName="Sort" CommandArgument="PositionDesired"></asp:LinkButton><br />
                                                                            <asp:TextBox ID="txtSearchPositionDesired" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Eval("PositionDesired")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="linkbtn_3" Text='Date Applied' runat="server" CommandName="Sort" CommandArgument="DateReceived"></asp:LinkButton><br />
                                                                            <asp:TextBox ID="txtSearchDateApplied" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Eval("DateReceived")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="linkbtn_4" Text='Address' runat="server" CommandName="Sort" CommandArgument="Address"></asp:LinkButton><br />
                                                                            <asp:TextBox ID="txtSearchAddress" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Eval("Address1")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>




                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:LinkButton ID="lblReset" Text='Actions' runat="server" CommandName="Action" CommandArgument="Action"></asp:LinkButton><br />

                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Button ID="btnAddDept" CssClass="btn-success btn-xs" runat="server" Text="View" CommandName="vew" CommandArgument='<%# Eval("id") %>' />
                                                                            <asp:Button ID="btnUpdate" CssClass="btn-success btn-xs" runat="server" Text="Update" CommandName="upd" CommandArgument='<%# Eval("id") %>' />
                                                                            <asp:Button ID="btnDelete" CssClass="btn-danger btn-xs" runat="server" Text="Delete" CommandName="del" CommandArgument='<%# Eval("id") %>' />
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>


                                                                </Columns>
                                                            </asp:GridView>

                                                        </div>


                                                    </div>
                                                </div>
                                            </div>
                                        </section>
                                    </div>
                                </div>
                                <div id="sectionC" class="tab-pane fade">
                                    <a id="A2" class="btn btn-default" runat="server" onserverclick="btnExport_Click">
                                        <i class="fa fa-file-excel-o"></i>
                                        Export to Excel
                                    </a>
                                    <div class="row">
                                        <section class="col-lg-12">
                                            <div class="box box-primary">
                                                <div class="box-header">
                                                    <h3 class="box-title"><i class="fa fa-file-text"></i> SHORTLISTED APPLICANTS
                                                    </h3>
                                                </div>
                                                <div id="display-grid2" class="grid-view">
                                                    <div class="summary">Displaying <%=gridrangecount2%> of <%=gridtotalcount2%> results.</div>
                                                    <asp:GridView ID="GridViewList2" runat="server" AutoGenerateColumns="False"
                                                        ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                        GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                        ForeColor="Black" OnRowCommand="GridViewList2_RowCommand"
                                                        OnPageIndexChanging="GridViewList2_PageIndexChanging"
                                                        ViewStateMode="Enabled">
                                                        <EmptyDataTemplate>
                                                            <center><h1>NO APPLICANTS AVAILABLE</h1></center>
                                                        </EmptyDataTemplate>
                                                        <Columns>
                                                            <asp:TemplateField Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblid2" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="linkbtn_1_2" Text='Full Name' runat="server" CommandName="Sort" CommandArgument="FullName"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtSearchFullName2" runat="server" OnTextChanged="txtItem2_TextChanged" Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Eval("FullName")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="linkbtn_2_2" Text='Position Desired' runat="server" CommandName="Sort" CommandArgument="PositionDesired"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtSearchPositionDesired2" runat="server" OnTextChanged="txtItem2_TextChanged" Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Eval("PositionDesired")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="linkbtn_3_2" Text='Date Applied' runat="server" CommandName="Sort" CommandArgument="DateReceived"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtSearchDateApplied2" runat="server" OnTextChanged="txtItem2_TextChanged" Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Eval("DateReceived")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="linkbtn_4_2" Text='Address' runat="server" CommandName="Sort" CommandArgument="Address"></asp:LinkButton><br />
                                                                    <asp:TextBox ID="txtSearchAddress2" runat="server" OnTextChanged="txtItem2_TextChanged" Width="100%"></asp:TextBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Eval("Address1")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>




                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="lblReset2" Text='Actions' runat="server" CommandName="Action" CommandArgument="Action"></asp:LinkButton><br />

                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnAddDept2" CssClass="btn-success btn-xs" runat="server" Text="View" CommandName="vew" CommandArgument='<%# Eval("id") %>' />
                                                                    <asp:Button ID="btnUpdate2" CssClass="btn-success btn-xs" runat="server" Text="Update" CommandName="upd" CommandArgument='<%# Eval("id") %>' />
                                                                    <asp:Button ID="btnDelete2" CssClass="btn-danger btn-xs" runat="server" Text="Delete" CommandName="del" CommandArgument='<%# Eval("id") %>' />
                                                                </ItemTemplate>

                                                            </asp:TemplateField>


                                                        </Columns>
                                                    </asp:GridView>

                                                </div>
                                            </div>
                                        </section>
                                    </div>
                                </div>
                                <div id="sectionD" class="tab-pane fade">
                                    <br />
                                    <div class="row">
                                        <section class="col-lg-12">
                                            <div class="box box-primary">
                                                <div class="box-header">
                                                    <h3 class="box-title"><i class="fa fa-file-text"></i>FAILED APPLICANTS
                                                    </h3>
                                                </div>
                                                <div class="box-body">
                                                    <div id="display-grid3" class="grid-view">
                                                        <div class="summary">Displaying <%=gridrangecount3%> of <%=gridtotalcount3%> results.</div>
                                                        <asp:GridView ID="GridViewList3" runat="server" AutoGenerateColumns="False"
                                                            ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                            GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                            ForeColor="Black" OnRowCommand="GridViewList3_RowCommand"
                                                            OnPageIndexChanging="GridViewList3_PageIndexChanging"
                                                            ViewStateMode="Enabled">
                                                            <EmptyDataTemplate>
                                                                <center><h1>NO APPLICANTS AVAILABLE</h1></center>
                                                            </EmptyDataTemplate>
                                                            <Columns>
                                                                <asp:TemplateField Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblid3" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="linkbtn_1_3" Text='Full Name' runat="server" CommandName="Sort" CommandArgument="FullName"></asp:LinkButton><br />
                                                                        <asp:TextBox ID="txtSearchFullName3" runat="server" OnTextChanged="txtItem3_TextChanged" Width="100%"></asp:TextBox>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%# Eval("FullName")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="linkbtn_2_3" Text='Position Desired' runat="server" CommandName="Sort" CommandArgument="PositionDesired"></asp:LinkButton><br />
                                                                        <asp:TextBox ID="txtSearchPositionDesired3" runat="server" OnTextChanged="txtItem3_TextChanged" Width="100%"></asp:TextBox>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%# Eval("PositionDesired")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="linkbtn_3_3" Text='Date Applied' runat="server" CommandName="Sort" CommandArgument="DateReceived"></asp:LinkButton><br />
                                                                        <asp:TextBox ID="txtSearchDateApplied3" runat="server" OnTextChanged="txtItem3_TextChanged" Width="100%"></asp:TextBox>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%# Eval("DateReceived")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="linkbtn_4_3" Text='Address' runat="server" CommandName="Sort" CommandArgument="Address"></asp:LinkButton><br />
                                                                        <asp:TextBox ID="txtSearchAddress3" runat="server" OnTextChanged="txtItem3_TextChanged" Width="100%"></asp:TextBox>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%# Eval("Address1")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>




                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="lblReset3" Text='Actions' runat="server" CommandName="Action" CommandArgument="Action"></asp:LinkButton><br />

                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnAddDept3" CssClass="btn-success btn-xs" runat="server" Text="View" CommandName="vew" CommandArgument='<%# Eval("id") %>' />
                                                                        <asp:Button ID="btnUpdate3" CssClass="btn-success btn-xs" runat="server" Text="Update" CommandName="upd" CommandArgument='<%# Eval("id") %>' />
                                                                        <asp:Button ID="btnDelete3" CssClass="btn-danger btn-xs" runat="server" Text="Delete" CommandName="del" CommandArgument='<%# Eval("id") %>' />
                                                                    </ItemTemplate>

                                                                </asp:TemplateField>


                                                            </Columns>
                                                        </asp:GridView>

                                                    </div>
                                                </div>
                                            </div>
                                        </section>
                                    </div>
                                </div>
                                <div id="sectionE" class="tab-pane fade">
                                    <br />
                                    <div class="row">
                                        <section class="col-lg-12">
                                            <div class="box box-primary">
                                                <div class="box-header">
                                                    <h3 class="box-title"><i class="fa fa-file-text"></i> BLACKLISTED APPLICANTS
                                                    </h3>
                                                </div>
                                                <div class="box-body">
                                                    <div id="display-grid4" class="grid-view">
                                                        <div class="summary">Displaying <%=gridrangecount4%> of <%=gridtotalcount4%> results.</div>
                                                        <asp:GridView ID="GridViewList4" runat="server" AutoGenerateColumns="False"
                                                            ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                            GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                            ForeColor="Black" OnRowCommand="GridViewList4_RowCommand"
                                                            OnPageIndexChanging="GridViewList4_PageIndexChanging"
                                                            ViewStateMode="Enabled">
                                                            <EmptyDataTemplate>
                                                                <center><h1>NO APPLICANTS AVAILABLE</h1></center>
                                                            </EmptyDataTemplate>
                                                            <Columns>
                                                                <asp:TemplateField Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblid4" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="linkbtn_1_4" Text='Full Name' runat="server" CommandName="Sort" CommandArgument="FullName"></asp:LinkButton><br />
                                                                        <asp:TextBox ID="txtSearchFullName4" runat="server" OnTextChanged="txtItem4_TextChanged" Width="100%"></asp:TextBox>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%# Eval("FullName")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="linkbtn_2_4" Text='Position Desired' runat="server" CommandName="Sort" CommandArgument="PositionDesired"></asp:LinkButton><br />
                                                                        <asp:TextBox ID="txtSearchPositionDesired4" runat="server" OnTextChanged="txtItem4_TextChanged" Width="100%"></asp:TextBox>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%# Eval("PositionDesired")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="linkbtn_3_4" Text='Date Applied' runat="server" CommandName="Sort" CommandArgument="DateReceived"></asp:LinkButton><br />
                                                                        <asp:TextBox ID="txtSearchDateApplied4" runat="server" OnTextChanged="txtItem4_TextChanged" Width="100%"></asp:TextBox>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%# Eval("DateReceived")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="linkbtn_4_4" Text='Address' runat="server" CommandName="Sort" CommandArgument="Address"></asp:LinkButton><br />
                                                                        <asp:TextBox ID="txtSearchAddress4" runat="server" OnTextChanged="txtItem4_TextChanged" Width="100%"></asp:TextBox>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%# Eval("Address1")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>




                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton ID="lblReset4" Text='Actions' runat="server" CommandName="Action" CommandArgument="Action"></asp:LinkButton><br />

                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnAddDept4" CssClass="btn-success btn-xs" runat="server" Text="View" CommandName="vew" CommandArgument='<%# Eval("id") %>' />
                                                                        <asp:Button ID="btnUpdate4" CssClass="btn-success btn-xs" runat="server" Text="Update" CommandName="upd" CommandArgument='<%# Eval("id") %>' />
                                                                        <asp:Button ID="btnDelete4" CssClass="btn-danger btn-xs" runat="server" Text="Delete" CommandName="del" CommandArgument='<%# Eval("id") %>' />
                                                                    </ItemTemplate>

                                                                </asp:TemplateField>


                                                            </Columns>
                                                        </asp:GridView>

                                                    </div>
                                                </div>
                                            </div>
                                        </section>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                </div>
            </div>
        </div>

        <!-- /.row (main row) -->
    </aside>
</asp:Content>
