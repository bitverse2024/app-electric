<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="appraisal.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees.appraisal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                <h3 class="m-0 text-dark">Employees<small> Appraisal</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="appraisal.aspx" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
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
                                            ViewStateMode="Enabled">
                                            <EmptyDataTemplate>
                                                <center><h1>NO EMPLOYEE AVAILABLE</h1></center>
                                            </EmptyDataTemplate>
                                            <Columns>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblid" Text='<%# Eval("emp_id") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkbtn_1" CssClass="h8" Text='Name' runat="server" CommandName="Sort" CommandArgument="Emp_Name"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtSearchEmp_Name" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <span class=""><%# Eval("emp_FullName")%></span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkbtn_2" CssClass="h8" Text='Employee ID' runat="server" CommandName="Sort" CommandArgument="EmpID"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtSearchEmpID" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <span class=""><%# Eval("emp_EmpID")%></span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <span class="h8">Non
                                                    <br>
                                                            Supervisory
                                                    <br>
                                                            Staff</span>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnWOCompensation1" runat="server" ForeColor="Black" Font-Size="Large" CommandName="WOCompensation" CommandArgument='<%# Eval("emp_id") %>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                                        &nbsp;
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <span class="h8">Non
                                                    <br>
                                                            Supervisory
                                                    <br>
                                                            Staff</span>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnWOCompensation2" runat="server" ForeColor="Black" Font-Size="Large" CommandName="WOCompensation" CommandArgument='<%# Eval("emp_id") %>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                                        &nbsp;
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <span class="h8">Non
                                                    <br>
                                                            Supervisory
                                                    <br>
                                                            Staff</span>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnWOCompensation3" runat="server" ForeColor="Black" Font-Size="Large" CommandName="WOCompensation" CommandArgument='<%# Eval("emp_id") %>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                                        &nbsp;
                                                    </ItemTemplate>
                                                </asp:TemplateField>




                                                <%--<asp:TemplateField>
                                                                                            <HeaderTemplate>
                                                                                                <asp:LinkButton ID="lblReset" Text='Reset' runat="server" CommandName="Reset" CommandArgument="Reset"></asp:LinkButton><br />
                                                                            
                                                                                            </HeaderTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Button ID="btnAction" CssClass="btn-success btn-xs" runat="server" Text="Action"  CommandName="action" CommandArgument='<%# Eval("emp_id") %>'  />
                                                                                                <asp:Button ID="btnUpdate" CssClass="btn-success btn-xs" runat="server" Text="Update"   CommandName="upd" CommandArgument='<%# Eval("emp_id") %>'  />
                                                                                                <asp:Button ID="btnDelete" CssClass="btn-danger btn-xs" runat="server" Text="Delete"  CommandName="del" CommandArgument='<%# Eval("emp_id") %>'  />
                                                                                            </ItemTemplate>
                                                                       
                                                                                        </asp:TemplateField>    --%>
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
</asp:Content>
