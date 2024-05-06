<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ifApprover.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.ifApprover" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function Confirm1() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to update approver access?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <aside class="right-side">
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
                    <h3 class="m-0 text-dark">User<small> Change Password</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a class="btn btn-default" href="AdminPage.aspx"><i class="fa fa-dashboard"></i><span class="h6">Admin</span></a>
                            <a class="btn btn-default" href="<%= ResolveUrl("~/Pages/Admin/userview.aspx?empid="+empno+"")%>"><i
                                class="fa fa-user"></i><span class="h6">Manage Users</span></a>
                            <a class="btn btn-default"  href="<%= ResolveUrl("~/Pages/Admin/useraccess.aspx?empid="+empno+"")%>"><i class="fa fa-pencil"></i><span class="h6">Update User Access</span></a>
                            <a href="<%= ResolveUrl("~/Pages/Admin/userview.aspx?empid="+empno+"")%>" class="btn btn-default"><i class="fa fa-arrow-circle-o-left"></i><span class="h6">Back</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">
                                        <div class="form">
                                            <legend>
                                               <%-- <p class="note">
                                                    Fields with <span class="required text-red">**</span> are required.
                                                </p>--%>
                                            </legend>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <h4 class="box-title">
                                                        <%=getname() %><h4>
                                                            <label for="User_approver" class="required">
                                                                Approver</label><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="User_approver" ValidationGroup="updApp" ForeColor="Red" ErrorMessage="Field Required"></asp:RequiredFieldValidator>
                                                            <select class="form-control" name="User[approver]" id="User_approver" runat="server">
                                                                <option value="empty" selected="selected">---SELECT IF APPROVER---</option>
                                                                <option value="1">YES</option>
                                                                <option value="0">NO</option>
                                                            </select>
                                                </div>
                                            </div>
                                            <div class="form-actions" style="padding-top: 10px">
                                                <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" Text="Save"
                                                    OnClick="btnUpdate_Click" Width="80px" ValidationGroup="updApp" OnClientClick="Confirm1()"></asp:Button>
                                                <asp:Button ID="btnReset" class="btn btn-danger" Width="80px" runat="server" Text="Reset"
                                                    OnClick="btnReset_Click"></asp:Button>
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

</asp:Content>
