<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="addannouncement.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Announcement.addannouncement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to add this announcement?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <aside class="right-side">
        <!-- Small boxes (Stat box) -->
        <div class="row">
            <div class="col-lg-12">
                <div id="content">

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
                                <h3 class="m-0 text-dark">Add Announcement<small></small></h3>
                                <section class="card">
                                    <div class="card-header">
                                        <a href="addannouncement.aspx" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Add Announcement</span></a>
                                        <a href="announcements.aspx" class="btn btn-default"><i class="fa fa-list"></i><span class="h6">List</span></a>
                                        <a class="btn btn-default" href="#"><i class="fa fa-search"></i><span class="h6">Search</span></a>

                                    </div>
                                    <div class="card-body">
                                        <div class="content">
                                            <div class="container-fluid">
                                                <div class="box-body">
                                                    <div class="form">

                                                        <fieldset>
                                                            <legend>
                                                                <p class="note">Fields with <span class="required text-red">*</span> are required.</p>
                                                            </legend>


                                                            <div class="container showgrid">
                                                                <div class="form col-lg-6">
                                                                    <label for="Announcements_description" class="required">Description <span class="required text-red">*</span></label>
                                                                    <textarea class="form-control" maxlength="500" name="Announcements[description]" id="Announcements_description" runat="server"></textarea>
                                                                </div>
                                                            </div>
                                                            &ensp;

	                                                        <div class="form-actions">
                                                                &ensp;&ensp;
                                                                <asp:Button ID="btnAdd" Width="80" class="btn btn-primary" runat="server" Text="Create"
                                                                    OnClick="btnAdd_Click" ValidationGroup="CreateCompanyGroup" OnClientClick="Confirm()"></asp:Button>
                                                                &ensp;
                                                                <asp:Button ID="btnReset" class="btn btn-danger" Width="80" runat="server" Text="Reset"></asp:Button>
                                                            </div>
                                                        </fieldset>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </section>

                            </div>
                            <!-- content -->
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div id="sidebar">
                    </div>
                    <!-- sidebar -->
                </div>
            </div>
        </div>
        <!-- /.row (main row) -->
    </aside>
</asp:Content>
