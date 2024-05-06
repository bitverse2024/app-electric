<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="courseList.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.courseList" %>

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
                    <h3 class="m-0 text-dark">Admin<small> Course</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="AdminPage.aspx" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Back</span></a>
                            <a href="createCourse.aspx" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                            <a href="courseList.aspx" class="btn btn-default"><i class="fa fa-th-list"></i><span class="h6">List</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">

                                        <%-- <a class="btn btn-app search-button">
                    <i class="fa fa-search"></i>
                    Advanced Search
                </a>--%>
                                        <div class="search-form" style="display: none">

                                            <input type="hidden" value="course/index" name="r">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <label for="Course_CourseCode">Course Code</label><input class="form-control" maxlength="6" name="Course[CourseCode]" id="Course_CourseCode" type="text">
                                                    <label for="Course_CourseName">Course Name</label><input class="form-control" maxlength="40" name="Course[CourseName]" id="Course_CourseName" type="text">
                                                </div>
                                                <div class="col-lg-6">
                                                    <label for="Course_Include">Include</label><input class="form-control" maxlength="1" name="Course[Include]" id="Course_Include" type="text">
                                                </div>
                                            </div>
                                            <div class="form-actions">
                                                <button class="btn btn-primary" type="submit" name="yt0"><i class="icon-search icon-white"></i>Search</button>
                                                <button class="btnreset btn-small btn" name="yt1" type="button"><i class="icon-remove-sign white"></i>Reset</button>
                                            </div>



                                            <script>
                                                $(".btnreset").click(function () {
                                                    $(":input", "#search-course-form").each(function () {
                                                        var type = this.type;
                                                        var tag = this.tagName.toLowerCase(); // normalize case
                                                        if (type == "text" || type == "password" || tag == "textarea") this.value = "";
                                                        else if (type == "checkbox" || type == "radio") this.checked = false;
                                                        else if (tag == "select") this.selectedIndex = "";
                                                    });
                                                });
                                            </script>

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
                                                    <center><h1>NO COURSE AVAILABLE</h1></center>
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblid" Text='<%# Eval("CourseCode") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkCourseName" CssClass="h8" Text='Course Name' runat="server" CommandName="Sort" CommandArgument="CourseName"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchCourseName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCourseName" CssClass="" Text='<%# Eval("CourseName") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkIncludeField" CssClass="h8" Text='Include' runat="server" CommandName="Sort" CommandArgument="IncludeField"></asp:LinkButton><br />
                                                            <asp:TextBox ID="txtSearchIncludeField" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncludeField" CssClass="" Text='<%# Eval("IncludeField") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>





                                                    <asp:TemplateField HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <center>
			                                            <asp:LinkButton ID="btnView" runat="server" ForeColor="Black" Font-Size="Large" CommandName="view" CommandArgument='<%# Eval("CourseCode") %>'><i class="fa fa-eye"></i></asp:LinkButton> &nbsp;
			                                            <asp:LinkButton ID="btnUpdate" runat="server" ForeColor="Black" Font-Size="Medium" CommandName="upd" CommandArgument='<%# Eval("CourseCode") %>'><i class="fa fa-edit"></i></asp:LinkButton>&ensp;
			                                            <asp:LinkButton ID="btnDelete" runat="server" ForeColor="Black" Font-Size="Medium" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;"  CommandName="del" CommandArgument='<%# Eval("CourseCode") %>'><i class="fa fa-trash"></i></asp:LinkButton>
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
                                <!-- Input Text to update -->

                                <div class="col-lg-7">
                                        <label for="upd_CourseName" class="required">
                                            Course Name<span class="required">*</span><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" ControlToValidate="upd_CourseName"
                                                ForeColor="Red" ValidationGroup="updCourse"></asp:RequiredFieldValidator></label>
                                    <div class="input-group date">

                                        <input class="form-control" id="upd_CourseName" name="txtCourseName" type="text" runat="server" />
                                    </div>

                                </div>
                            </div>


                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Update" CssClass="btn btn-primary"
                                OnClick="btnsaveUpdate_Click" OnClientClick="Confirm()" ValidationGroup="updCourse"></asp:Button>


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
                                    <label for="vw_CourseName" class="required">Course Name</label>
                                    <input class="form-control" id="vw_CourseName" name="vw_CourseName" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_IncludeField" class="required">Include</label>
                                    <input class="form-control" id="vw_IncludeField" name="vw_IncludeField" type="text" runat="server" disabled="disabled" />
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
