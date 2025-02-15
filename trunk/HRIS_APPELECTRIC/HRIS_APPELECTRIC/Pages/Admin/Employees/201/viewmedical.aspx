﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="viewmedical.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees._201.viewmedical" %>

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
                <h3 class="m-0 text-dark"><%=getname() %><small> Medical</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/CreateEmployee.aspx")%>" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/EmployeeMaster.aspx")%>" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/EmployeeView.aspx?empid="+empno+"")%>" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Employee View</span></a>

                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="box-body">
                                    <div class='printableArea'>
                                        <div id="list">
                                            <div id="medical-grid" class="grid-view">
                                                <div class="summary">Displaying <%=gridrangecount%> of <%=gridtotalcount%> results.</div>
                                                <asp:GridView ID="GridViewList" runat="server" AutoGenerateColumns="False"
                                                    ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                    GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                    ForeColor="Black" OnRowCommand="GridViewList_RowCommand"
                                                    OnPageIndexChanging="GridViewList_PageIndexChanging"
                                                    ViewStateMode="Enabled" ShowHeaderWhenEmpty="true">
                                                    <EmptyDataTemplate>
                                                        <center><h1>NO MEDICAL AVAILABLE</h1></center>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblid" Text='<%# Eval("id") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="LinkButton1" CssClass="h8" Text='Ref Date' runat="server" CommandName="Sort" CommandArgument="RefDate"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchRefDate" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <span class=""><%# Eval("RefDate") %></span>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="LinkButton2" CssClass="h8" Text='Hospital/Clinic' runat="server" CommandName="Sort" CommandArgument="FName"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchFName" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <span class=""><%# Eval("FName") %></span>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="LinkButton3" CssClass="h8" Text='Diagnosis' runat="server" CommandName="Sort" CommandArgument="Diagnosis"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchDiagnosis" runat="server" OnTextChanged="txtItem_TextChanged" Width="100%"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <span class=""><%# Eval("Diagnosis") %></span>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderStyle-Width="15%">
                                                            <ItemTemplate>
                                                                <center>
                                                                                <asp:LinkButton ID="LinkButton4" runat="server" ForeColor="Black" Font-Size="Large" CommandName="dl" CommandArgument='<%# Eval("id") %>'><i class="fa fa-download"></i></asp:LinkButton> &nbsp;
                                                                                <asp:LinkButton ID="btnView" runat="server" ForeColor="Black" Font-Size="Large" CommandName="view" CommandArgument='<%# Eval("id") %>'><i class="fa fa-eye"></i></asp:LinkButton> &nbsp;
                                                                                <asp:LinkButton ID="btnUpdate" runat="server" ForeColor="Black" Font-Size="Medium" CommandName="upd" CommandArgument='<%# Eval("id") %>'><i class="fa fa-edit"></i></asp:LinkButton>&ensp;
                                                                                <asp:LinkButton ID="btnDelete" runat="server" ForeColor="Black" Font-Size="Medium" OnClientClick="if (!confirm('Are you sure you want to permanently remove this item?')) return false;"  CommandName="del" CommandArgument='<%# Eval("id") %>'><i class="fa fa-trash"></i></asp:LinkButton>
                                                                            </center>
                                                                <%-- <asp:Button ID="btnDL" CssClass="btn-default btn-xs" runat="server" Text="Download"  CommandName="dl" CommandArgument='<%# Eval("id") %>'  />
                                                                            <asp:Button ID="btnView" CssClass="btn-success btn-xs" runat="server" Text="View"  CommandName="view" CommandArgument='<%# Eval("id") %>'  />
                                                                            <asp:Button ID="btnUpdate" CssClass="btn-success btn-xs" runat="server" Text="Update"   CommandName="upd" CommandArgument='<%# Eval("id") %>'  />
                                                                            <asp:Button ID="btnDelete" CssClass="btn-danger btn-xs" runat="server" Text="Delete"  CommandName="del" CommandArgument='<%# Eval("id") %>'  />--%>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>


                                                    </Columns>
                                                </asp:GridView>

                                                <div class="keys" style="display: none" title="/dataland-new/index.php?r=employee/viewmedical&amp;id=1"></div>
                                            </div>
                                        </div>

                                        <div class="form">
                                            <legend>
                                                <p class="note">Fields with <span class="required text-red">**</span> are required.</p>
                                            </legend>


                                            <div class="showgrid">
                                                <div class="row">
                                                    <div class="col-lg-6">


                                                        <label for="RefDate" class="required">
                                                            Ref Date <span class="required text-red">**
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRefDate" ValidationGroup="uploadGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <input class="form-control" id="txtRefDate" name="Medical[RefDate]" type="date" runat="server" />
                                                        <label for="Diagnosis" class="required">
                                                            Diagnosis <span class="required text-red">**
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Diagnosis" ValidationGroup="uploadGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <input class="form-control" maxlength="50" name="Medical[Diagnosis]" id="Diagnosis" type="text" runat="server" />

                                                        <label for="FName" class="required">
                                                            Hospital/Clinic <span class="required text-red">**
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FName" ValidationGroup="uploadGroup" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                                        <input class="form-control" maxlength="75" name="Medical[Name]" id="FName" type="text" runat="server" />

                                                        <label for="Medical_Remarks" class="required">Remarks</label>
                                                        <input class="form-control" maxlength="100" name="Medical[Remarks]" id="Remarks" type="text" runat="server" />


                                                    </div>
                                                    <div class="col-lg-6">
                                                        <span class="required text-red">*
                                                            <asp:CheckBox ID="Xray" runat="server" CssClass="checkbox-inline" Text="Xray"></asp:CheckBox></span><br />
                                                        <span class="required text-red">*
                                                            <asp:CheckBox ID="CBC" runat="server" CssClass="checkbox-inline" Text="CBC"></asp:CheckBox></span><br />
                                                        <span class="required text-red">*
                                                            <asp:CheckBox ID="Urinalysis" runat="server" CssClass="checkbox-inline" Text="Urinalysis"></asp:CheckBox></span><br />
                                                        <span class="required text-red">*
                                                            <asp:CheckBox ID="Fecalysis" runat="server" CssClass="checkbox-inline" Text="Fecalysis"></asp:CheckBox></span><br />
                                                        <span class="required text-red">*
                                                            <asp:CheckBox ID="ECG" runat="server" CssClass="checkbox-inline" Text="ECG"></asp:CheckBox></span><br />
                                                        <span class="required text-red">*
                                                            <asp:CheckBox ID="DrugTest" runat="server" CssClass="checkbox-inline" Text="DrugTest"></asp:CheckBox></span><br />
                                                        <span class="required text-red">*
                                                            <asp:CheckBox ID="BloodType" runat="server" CssClass="checkbox-inline" Text="BloodType"></asp:CheckBox></span><br />
                                                        <span class="required text-red">*
                                                            <asp:CheckBox ID="Pregnancy" runat="server" CssClass="checkbox-inline" Text="Pregnancy"></asp:CheckBox></span><br />
                                                        <span class="required text-red">*
                                                            <asp:CheckBox ID="HepaB" runat="server" CssClass="checkbox-inline" Text="HepaB"></asp:CheckBox></span><br />
                                                        <div class="input-group">
                                                            <span class="input-group-lg required" style="padding-top:10px">Select File: </span>
                                                            <asp:FileUpload ID="fuUploader" runat="server" Height="45px" CssClass="form-control btn-default" />
                                                            <asp:RequiredFieldValidator ID="validatorUploader" CssClass="required" runat="server" ControlToValidate="fuUploader" ValidationGroup="uploadGroup" ForeColor="Red" ErrorMessage="Select Image to upload."></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="validatorFileUpload"
                                                                ControlToValidate="fuUploader" ValidationGroup="uploadGroup" runat="server"
                                                                ErrorMessage="Only image with .jpg, .jpeg or .png is allowed."
                                                                ValidationExpression="^.*\.(jpg|JPG|JPEG|jpeg|png|PNG)$"></asp:RegularExpressionValidator>

                                                        </div>



                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-actions">
                                                <asp:Button ID="btnCreate" Width="80" class="btn btn-primary" runat="server" Text="Create"
                                                    OnClick="btnCreate_Click" ValidationGroup="uploadGroup" OnClientClick="Confirm()"></asp:Button>
                                                <asp:Button ID="btnReset" Width="80" class="btn btn-danger" runat="server" Text="Reset"
                                                    OnClick="btnReset_Click"></asp:Button>
                                            </div>


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
                                <div class="col-lg-6">
                                    <label for="upd_RefDate" class="required">
                                        Ref Date <span class="required text-red">**
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="upd_RefDate" ValidationGroup="uploadGroup1" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                    <input class="form-control datetimepicker" id="upd_RefDate" name="Medical[RefDate]" type="text" runat="server" />
                                    <label for="upd_Diagnosis" class="required">
                                        Diagnosis <span class="required text-red">**
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="upd_Diagnosis" ValidationGroup="uploadGroup1" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                    <input class="form-control" maxlength="50" name="Medical[Diagnosis]" id="upd_Diagnosis" type="text" runat="server" />

                                    <label for="upd_FName" class="required">
                                        Hospital/Clinic <span class="required text-red">**
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="upd_FName" ValidationGroup="uploadGroup1" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator></span></label>
                                    <input class="form-control" maxlength="75" name="Medical[Name]" id="upd_FName" type="text" runat="server" />

                                    <label for="upd_Remarks" class="required">Remarks</label>
                                    <input class="form-control" maxlength="100" name="Medical[Remarks]" id="upd_Remarks" type="text" runat="server" />
                                </div>
                                <div class="col-lg-6">
                                    <span class="">
                                        <asp:CheckBox ID="upd_Xray" runat="server" CssClass="checkbox-inline" Text="Xray"></asp:CheckBox></span><br />
                                    <span class="">
                                        <asp:CheckBox ID="upd_CBC" runat="server" CssClass="checkbox-inline" Text="CBC"></asp:CheckBox></span><br />
                                    <span class="">
                                        <asp:CheckBox ID="upd_Urinalysis" runat="server" CssClass="checkbox-inline" Text="Urinalysis"></asp:CheckBox></span><br />
                                    <span class="">
                                        <asp:CheckBox ID="upd_Fecalysis" runat="server" CssClass="checkbox-inline" Text="Fecalysis"></asp:CheckBox></span><br />
                                    <span class="">
                                        <asp:CheckBox ID="upd_ECG" runat="server" CssClass="checkbox-inline" Text="ECG"></asp:CheckBox></span><br />
                                    <span class="">
                                        <asp:CheckBox ID="upd_DrugTest" runat="server" CssClass="checkbox-inline" Text="DrugTest"></asp:CheckBox></span><br />
                                    <span class="">
                                        <asp:CheckBox ID="upd_BloodType" runat="server" CssClass="checkbox-inline" Text="BloodType"></asp:CheckBox></span><br />
                                    <span class="">
                                        <asp:CheckBox ID="upd_Pregnancy" runat="server" CssClass="checkbox-inline" Text="Pregnancy"></asp:CheckBox></span><br />
                                    <span class="">
                                        <asp:CheckBox ID="upd_HepaB" runat="server" CssClass="checkbox-inline" Text="HepaB"></asp:CheckBox></span><br />
                                    <div class="input-group">
                                        <span class="input-group-lg required">Select File: </span>
                                        <asp:FileUpload ID="upd_fuUploader" runat="server" CssClass="form-control btn-default" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                            ControlToValidate="fuUploader" ValidationGroup="uploadGroup1" runat="server"
                                            ErrorMessage="Only image with .jpg, .jpeg or .png is allowed."
                                            ValidationExpression="^.*\.(jpg|JPG|JPEG|jpeg|png|PNG)$"></asp:RegularExpressionValidator>

                                    </div>
                                </div>
                            </div>

                        </div>


                        </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnsaveUpdate" runat="server" Text="Update" CssClass="btn btn-primary"
                            OnClick="btnsaveUpdate_Click" OnClientClick="Confirm1()" ValidationGroup="uploadGroup1"></asp:Button>


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
                                    <label for="vw_RefDate" class="required">Ref Date</label>
                                    <input class="form-control datetimepicker" id="vw_RefDate" name="Medical[RefDate]" type="text" runat="server" disabled="disabled" />
                                    <label for="vw_Diagnosis" class="required">Diagnosis</label>
                                    <input class="form-control" maxlength="50" name="Medical[Diagnosis]" id="vw_Diagnosis" type="text" runat="server" disabled="disabled" />

                                    <label for="vw_FName" class="required">Hospital/Clinic</label>
                                    <input class="form-control" maxlength="75" name="Medical[Name]" id="vw_FName" type="text" runat="server" disabled="disabled" />

                                    <label for="vw_Remarks" class="required">Remarks</label>
                                    <input class="form-control" maxlength="100" name="Medical[Remarks]" id="vw_Remarks" type="text" runat="server" disabled="disabled" />
                                </div>
                                <div class="col-lg-6">
                                    <span class="">
                                        <asp:CheckBox ID="vw_Xray" runat="server" Text="Xray" CssClass="checkbox-inline" Enabled="False"></asp:CheckBox></span><br />
                                    <span class="">
                                        <asp:CheckBox ID="vw_CBC" runat="server" Text="CBC" CssClass="checkbox-inline" Enabled="False"></asp:CheckBox></span><br />
                                    <span class="">
                                        <asp:CheckBox ID="vw_Urinalysis" runat="server" CssClass="checkbox-inline" Text="Urinalysis" Enabled="False"></asp:CheckBox></span><br />
                                    <span class="">
                                        <asp:CheckBox ID="vw_Fecalysis" runat="server" CssClass="checkbox-inline" Text="Fecalysis" Enabled="False"></asp:CheckBox></span><br />
                                    <span class="">
                                        <asp:CheckBox ID="vw_ECG" runat="server" CssClass="checkbox-inline" Text="ECG" Enabled="False"></asp:CheckBox></span><br />
                                    <span class="">
                                        <asp:CheckBox ID="vw_DrugTest" runat="server" CssClass="checkbox-inline" Text="DrugTest" Enabled="False"></asp:CheckBox></span><br />
                                    <span class="">
                                        <asp:CheckBox ID="vw_BloodType" runat="server" CssClass="checkbox-inline" Text="BloodType" Enabled="False"></asp:CheckBox></span><br />
                                    <span class="">
                                        <asp:CheckBox ID="vw_Pregnancy" runat="server" CssClass="checkbox-inline" Text="Pregnancy" Enabled="False"></asp:CheckBox></span><br />
                                    <span class="">
                                        <asp:CheckBox ID="vw_HepaB" runat="server" CssClass="checkbox-inline" Text="HepaB" Enabled="False"></asp:CheckBox></span><br />
                                    <label for="vw_FilePath">File Path:</label>
                                    <input class="form-control" maxlength="100" id="vw_FilePath" type="text" runat="server" disabled="disabled" />
                                </div>

                            </div>


                        </div>
                        <div class="modal-footer">
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
