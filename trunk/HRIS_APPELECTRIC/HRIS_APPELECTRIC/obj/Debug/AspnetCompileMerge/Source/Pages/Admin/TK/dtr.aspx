<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="dtr.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.TK.dtr" %>

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
                <h3 class="m-0 text-dark">Daily Time Records<small> DTR List</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="dtr.aspx" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
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
                                                <center><h1>NO DATA AVAILABLE</h1></center>
                                            </EmptyDataTemplate>
                                            <Columns>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkbtn_1" CssClass="h8" Text='Name' runat="server" CommandName="Sort" CommandArgument="Emp_Name"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtSearchEmp_Name" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <span class=""><%# Eval("Emp_Name")%></span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkbtn_2" CssClass="h8" Text='Employee ID' runat="server" CommandName="Sort" CommandArgument="EmpID"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtSearchEmpID" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <span class=""><%# Eval("EmpID")%></span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkbtn_3" CssClass="h8" Width="120px" Text='Business Date' runat="server" CommandName="Sort" CommandArgument="BussDate"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtSearchBussDate" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <span class=""><%# Eval("BussDate")%></span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkbtn_4" CssClass="h8" Text='DateIn' runat="server" CommandName="Sort" CommandArgument="DateIn"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtSearchDateIn" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <span class=""><%# Eval("DateIn")%></span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkbtn_5" CssClass="h8" Text='TimeIn' runat="server" CommandName="Sort" CommandArgument="DTimeIn"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtSearchDTimeIn" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <span class=""><%# Eval("DTimeIn")%></span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkbtn_6" CssClass="h8" Text='DateOut' runat="server" CommandName="Sort" CommandArgument="DateOut"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtSearchDateOut" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <span class=""><%# Eval("DateOut")%></span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkbtn_7" CssClass="h8" Text='TimeOut' runat="server" CommandName="Sort" CommandArgument="DTimeOut"></asp:LinkButton><br />
                                                        <asp:TextBox ID="txtSearchDTimeOut" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <span class=""><%# Eval("DTimeOut")%></span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                 <%--<asp:TemplateField>
                                                                                            <HeaderTemplate>
                                                                                                <asp:LinkButton ID="lblReset" Text='' runat="server" CommandName="Reset" CommandArgument="Reset"></asp:LinkButton><br />
                                                                            
                                                                                            </HeaderTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Button ID="btnAction" CssClass="btn-success btn-xs" runat="server" Text="Action"  CommandName="action" CommandArgument='<%# Eval("id") %>'  />
                                                                                                <asp:Button ID="btnUpdate" CssClass="btn-success btn-xs" runat="server" Text="Update"   CommandName="upd" CommandArgument='<%# Eval("id") %>'  />
                                                                                                <asp:Button ID="btnDelete" CssClass="btn-danger btn-xs" runat="server" Text="Delete"  CommandName="del" CommandArgument='<%# Eval("id") %>'  />
                                                                                            </ItemTemplate>
                                                                       
                                                                                        </asp:TemplateField> --%> 
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
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
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
                                    

                                    <label for="upd_TimeIn"  id ="lblTIn" runat ="server" class="required">Time In<span class="required">*</span><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required" ControlToValidate="upd_TimeIn"
                                                ForeColor="Red" ValidationGroup="updTimeInOut"></asp:RequiredFieldValidator></label>
                                    <input type="time" id="upd_TimeIn" name="upd_TimeIn"  style="width:200px;" runat="server">

                                    <label for="upd_TimeOut" id ="lblTOut" runat ="server" class="required">Time Out<span class="required">*</span><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" ControlToValidate="upd_TimeOut"
                                                ForeColor="Red" ValidationGroup="updTimeInOut"></asp:RequiredFieldValidator></label>
                                    <input type="time" id="upd_TimeOut" name="upd_TimeOut"  style="width:200px;" runat="server">
                                </div>

                            </div>


                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnsaveUpdate" runat="server" Text="Update" CssClass="btn btn-primary"
                                OnClick="btnsaveUpdate_Click" OnClientClick="Confirm1()" ValidationGroup="updTimeInOut"></asp:Button>


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
</asp:Content>
