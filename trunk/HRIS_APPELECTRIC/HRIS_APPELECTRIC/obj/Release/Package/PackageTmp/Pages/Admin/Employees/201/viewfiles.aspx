<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="viewfiles.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees._201.viewfiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6"></div>
                <div class="col-sm-6"></div>
            </div>
        </div>
    </div>
    <%--<section class="content-header">
     <h1><a href="../EmployeeView.aspx?empid=<%:Session["ACTIVE_EMPNO"].ToString() %>"><%=getname() %></a>
         <small>201 Files</small>
     </h1>
     <ol class="breadcrumb">
        <li><a href="../EmployeeMaster.aspx"><i class="fa fa-dashboard"></i> Employees</a></li>
        <li class="active">201 Files</li>
    </ol>
</section>--%>
    <div class="col-md-12">
        <div class="content">
            <div class="container-fluid">
                <div class="container"></div>
                <h3 class="m-0 text-dark"><%=getname() %><small> Files</small></h3>
                <section class="card">

                    <div class="card-header">
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/CreateEmployee.aspx")%>" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/EmployeeMaster.aspx")%>" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                        <a href="<%=ResolveUrl("~/Pages/Admin/Employees/EmployeeView.aspx?empid="+empno+"")%>" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Employee View</span></a>

                    </div>
                    <div class="card-body">
                        <div class="box-body">
                            <section class="connectedSortable">

                                <legend>
                                    <h3>201 Files
                         
                                    </h3>
                                </legend>
                                <div class="form">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <label class="required">Select Category: </label>
                                            <asp:DropDownList ID="drpdwnCategory" CssClass="form-control" runat="server" Font-Bold="true">
                                                <asp:ListItem>Common</asp:ListItem>
                                                <asp:ListItem>NBI</asp:ListItem>
                                                <asp:ListItem>SSS</asp:ListItem>
                                                <asp:ListItem>PAGIBIG</asp:ListItem>
                                                <asp:ListItem>Police Clearance</asp:ListItem>
                                                <asp:ListItem>Birth Certificate</asp:ListItem>
                                                <asp:ListItem>Medical</asp:ListItem>
                                                <asp:ListItem>COE</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <%--<div id="Div1" runat="server" class="form-group form-group-sm col-md-10 col-md-offset-1">--%>
                                        <div class="col-lg-6">
                                                <label class="required">Select File: </label>
                                                <asp:FileUpload ID="fuUploader" runat="server" CssClass="form-control btn-default" Height="45px" />
                                                <asp:RequiredFieldValidator ID="validatorUploader" runat="server" ControlToValidate="fuUploader" ValidationGroup="uploadGroup" ForeColor="Red" ErrorMessage="Select csv file to upload."></asp:RequiredFieldValidator>

                                        </div>
                                        <div class="col-lg-6" style="padding-top:35px">
                                             <asp:LinkButton ID="LinkButton2" runat="server"
                                                        CssClass="btn btn-primary" ValidationGroup="uploadGroup"
                                                        OnClick="btnUploadImage_Click" OnClientClick="Confirm()">Upload</asp:LinkButton>
                                            </div>
                                        </div>
                                    <%--</form>--%>
                                </div>
                            </section>
                            <br />

                            <div id="files-grid" class="grid-view">

                                <asp:GridView ID="GridFilesList" runat="server" AutoGenerateColumns="False"
                                    ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                    GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                    ForeColor="Black" OnRowCommand="GridFilesList_RowCommand"
                                    OnPageIndexChanging="GridFilesList_PageIndexChanging"
                                    ViewStateMode="Enabled" ShowHeaderWhenEmpty="true">
                                    <EmptyDataTemplate>
                                        <center><h1>NO FILES AVAILABLE</h1></center>
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lnkFileID" CssClass="" Text='File ID' runat="server" CommandName="Sort" CommandArgument="FileID"></asp:LinkButton><br />
                                                <asp:TextBox ID="txtSearchFileID" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <span class=""><%# Eval("FileID") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lnkFilename" CssClass="" Text='File Name' runat="server" CommandName="Sort" CommandArgument="Filename"></asp:LinkButton><br />
                                                <asp:TextBox ID="txtSearchFilename" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <span class=""><%# Eval("Filename") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lnkCateg" CssClass="" Text='Category' runat="server" CommandName="Sort" CommandArgument="Category"></asp:LinkButton><br />
                                                <asp:TextBox ID="txtSearchCateg" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <span class=""><%# Eval("Category") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderStyle-Width="10%">
                                            <ItemTemplate>
                                                <center>
                                                                            <%--<asp:Button ID="btnDL" CssClass="btn-success btn-xs" runat="server" Text="Download"  CommandName="dl_file" CommandArgument='<%# Eval("FileID") %>'  />
                                                                            <asp:Button ID="btnDelete" CssClass="btn-danger btn-xs" runat="server" Text="Delete" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;" CommandName="del" CommandArgument='<%# Eval("FileID") %>'  />--%>
                                                                            <asp:LinkButton ID="btnDL" runat="server" ForeColor="Black" Font-Size="Medium" CommandName="dl_file" CommandArgument='<%# Eval("FileID") %>'><i class="fa fa-download"></i></asp:LinkButton>&ensp;
                                                                            <asp:LinkButton ID="btnDelete" runat="server" ForeColor="Black" Font-Size="Medium" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;"  CommandName="del" CommandArgument='<%# Eval("FileID") %>'><i class="fa fa-trash"></i></asp:LinkButton>
                                                                        </center>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <%--<asp:CommandField HeaderText="Cancel Item" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-xs btn-danger"  /> --%>
                                    </Columns>
                                </asp:GridView>
                                <%--<table class="items table table-striped table-bordered table-condensed">
    <thead>
    <tr>
    <th id="dependent-grid_c0"><a href="/dataland/index.php?r=employee/viewdependent&amp;id=1&amp;Dependent_sort=Name">Name<span class="caret"></span></a></th><th id="dependent-grid_c1"><a href="/dataland/index.php?r=employee/viewdependent&amp;id=1&amp;Dependent_sort=Relationship">Relationship<span class="caret"></span></a></th><th id="dependent-grid_c2"><a href="/dataland/index.php?r=employee/viewdependent&amp;id=1&amp;Dependent_sort=DOB">Birthdate<span class="caret"></span></a></th><th id="dependent-grid_c3"><a href="/dataland/index.php?r=employee/viewdependent&amp;id=1&amp;Dependent_sort=Age">Age<span class="caret"></span></a></th><th id="dependent-grid_c4"><a href="/dataland/index.php?r=employee/viewdependent&amp;id=1&amp;Dependent_sort=Occupation">Occupation<span class="caret"></span></a></th><th class="button-column" id="dependent-grid_c5">&nbsp;</th></tr>
    <tr class="filters">
    <td><div class="filter-container"><input name="Dependent[Name]" type="text" maxlength="100" /></div></td><td><div class="filter-container"><input name="Dependent[Relationship]" type="text" maxlength="8" /></div></td><td><div class="filter-container"><input name="Dependent[DOB]" type="text" /></div></td><td><div class="filter-container"><input name="Dependent[Age]" type="text" maxlength="50" /></div></td><td><div class="filter-container"><input name="Dependent[Occupation]" type="text" maxlength="50" /></div></td><td>&nbsp;</td></tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td>Name</td><td>Mom</td><td>01/25/1989</td><td>30</td><td>Occupation</td><td class="button-column"><a class="view" title="View" rel="tooltip" href="/dataland/index.php?r=dependent/view&amp;id=5"><i class="icon-eye-open"></i></a> <a class="update" title="Update" rel="tooltip" href="/dataland/index.php?r=dependent/update&amp;id=5"><i class="icon-pencil"></i></a> <a class="delete" title="Delete" rel="tooltip" href="/dataland/index.php?r=dependent/delete&amp;id=5"><i class="icon-trash"></i></a></td></tr>
    <tr class="even">
    <td>TES TINGG</td><td>MOTHER</td><td>02/14/1969</td><td>50</td><td>TESTING</td><td class="button-column"><a class="view" title="View" rel="tooltip" href="/dataland/index.php?r=dependent/view&amp;id=6"><i class="icon-eye-open"></i></a> <a class="update" title="Update" rel="tooltip" href="/dataland/index.php?r=dependent/update&amp;id=6"><i class="icon-pencil"></i></a> <a class="delete" title="Delete" rel="tooltip" href="/dataland/index.php?r=dependent/delete&amp;id=6"><i class="icon-trash"></i></a></td></tr>
    <tr class="odd">
    <td>testing</td><td>dad</td><td>02/01/2019</td><td>0</td><td>Occupation</td><td class="button-column"><a class="view" title="View" rel="tooltip" href="/dataland/index.php?r=dependent/view&amp;id=7"><i class="icon-eye-open"></i></a> <a class="update" title="Update" rel="tooltip" href="/dataland/index.php?r=dependent/update&amp;id=7"><i class="icon-pencil"></i></a> <a class="delete" title="Delete" rel="tooltip" href="/dataland/index.php?r=dependent/delete&amp;id=7"><i class="icon-trash"></i></a></td></tr>
    </tbody>
    </table><div class="keys" style="display:none" title="/dataland/index.php?r=employee/viewdependent&amp;id=1"><span>5</span><span>6</span><span>7</span></div>--%>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</asp:Content>
