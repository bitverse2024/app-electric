﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="mrlist.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.mrlist" %>

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
                    <h3 class="m-0 text-dark">HR-MR<small> Manpower Request</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="../../Default.aspx" class="btn btn-default"><i class="fa fa-arrow-circle-o-left"></i><span class="h6">Back to List</span></a>
                            <a class="btn btn-default" href="mrlist.aspx"><i class="fa fa-refresh"></i><span class="h6">Refresh</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">
                                        <div class="search-form" style="display: none">

                                            <div class="wide form">
                                                    <input type="hidden" value="manpowerrequest/index" name="r" />
                                                    <div class="row">
                                                        <label for="Manpowerrequest_id">ID</label>
                                                        <input name="Manpowerrequest[id]" id="Manpowerrequest_id" type="text" />
                                                    </div>

                                                    <div class="row">
                                                        <label for="Manpowerrequest_hrmrid">Hrmr Id</label>
                                                        <input name="Manpowerrequest[hrmrid]" id="Manpowerrequest_hrmrid" type="text" />
                                                    </div>

                                                    <div class="row">
                                                        <label for="Manpowerrequest_division">Division</label>
                                                        <input size="60" maxlength="70" name="Manpowerrequest[division]" id="Manpowerrequest_division" type="text" />
                                                    </div>

                                                    <div class="row">
                                                        <label for="Manpowerrequest_department">Department</label>
                                                        <input size="60" maxlength="70" name="Manpowerrequest[department]" id="Manpowerrequest_department" type="text" />
                                                    </div>

                                                    <div class="row">
                                                        <label for="Manpowerrequest_dateneeded">Date Needed</label>
                                                        <input size="15" maxlength="15" name="Manpowerrequest[dateneeded]" id="Manpowerrequest_dateneeded" type="text" />
                                                    </div>

                                                    <div class="row">
                                                        <label for="Manpowerrequest_workexperience">Work Experience</label>
                                                        <input size="60" maxlength="200" name="Manpowerrequest[workexperience]" id="Manpowerrequest_workexperience" type="text" />
                                                    </div>

                                                    <div class="row">
                                                        <label for="Manpowerrequest_skills">Skills</label>
                                                        <input size="60" maxlength="200" name="Manpowerrequest[skills]" id="Manpowerrequest_skills" type="text" />
                                                    </div>

                                                    <div class="row">
                                                        <label for="Manpowerrequest_requestedby">Requested by</label>
                                                        <input size="60" maxlength="100" name="Manpowerrequest[requestedby]" id="Manpowerrequest_requestedby" type="text" />
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
                                                OnPageIndexChanging="GridViewList_PageIndexChanging"
                                                ViewStateMode="Enabled">
                                                <EmptyDataTemplate>
                                                    <center><h1>NO REQUEST AT THIS MOMENT</h1></center>
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
                                                            <asp:LinkButton ID="linkbtn_3" CssClass="h8" Text='Position' runat="server" CommandName="Sort" CommandArgument="PositionName"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchPos" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"  AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("PositionName")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="linkbtn_4" CssClass="h8" Text='Work Experience' runat="server" CommandName="Sort" CommandArgument="workexperience"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchWorkExperience" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("workexperience")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="linkbtn_2" CssClass="h8" Text='Skills' runat="server" CommandName="Sort" CommandArgument="skills"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchSkills" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("skills")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="linkbtn_5" CssClass="h8" Text='Requested By' runat="server" CommandName="Sort" CommandArgument="requestedby"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchRequestedBy" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%" AutoPostBack="true"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <span class=""><%# Eval("requestedby")%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lblReset" Text='Action' runat="server" CommandName="Reset" CommandArgument="Reset"></asp:LinkButton><br />

                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%--<asp:Button ID="btnAction" CssClass="btn-success btn-xs" runat="server" Text="Action"  CommandName="action" CommandArgument='<%# Eval("id") %>'  />--%>
                                                            <%--<asp:Button ID="btnUpdate" CssClass="btn-success btn-xs" runat="server" Text="Update"   CommandName="upd" CommandArgument='<%# Eval("id") %>'  />--%>
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
