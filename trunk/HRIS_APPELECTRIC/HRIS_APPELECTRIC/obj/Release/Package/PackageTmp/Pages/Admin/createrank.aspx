<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="createrank.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.createrank" %>

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
                    <h3 class="m-0 text-dark">Admin<small> Create Rank</small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="createrank.aspx" class="btn btn-default"><i class="fa fa-plus"></i><span class="h6">Create</span></a>
                            <a href="ranklist.aspx" class="btn btn-default"><i class="fa fa-th-list"></i><span class="h6">List</span></a>
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


                                                <div class="row">
                                                    <div class="col-lg-6">

                                                        <div class="control-group ">
                                                            <label class="control-label required" for="Rank_RankName">
                                                                Rank Name <span class="required text-red">*<asp:RequiredFieldValidator ID="validatorUploader" runat="server" ControlToValidate="Rank_RankName" ValidationGroup="CreateRankGroup" ForeColor="Red" ErrorMessage="Field Required">
                                                                </asp:RequiredFieldValidator></span></label>
                                                            <div class="controls">
                                                                <input class="form-control" maxlength="255" name="Rank[RankName]" id="Rank_RankName" type="text" runat="server">
                                                            </div>
                                                        </div>
                                                        <div class="control-group ">
                                                            <label class="required" for="Rank_RankDesc">Rank Description</label>
                                                            <div class="controls">
                                                                <input class="form-control" maxlength="255" name="Rank[RankDesc]" id="Rank_RankDesc" type="text" runat="server">
                                                            </div>
                                                        </div>
                                                        <div class="control-group ">
                                                            <label class="required" for="Rank_GracePeriod">Grace Period</label>
                                                            <div class="controls">
                                                                <input class="form-control" maxlength="2" name="Rank[GracePeriod]" id="Rank_GracePeriod" type="text" runat="server">
                                                            </div>
                                                        </div>
                                                        <div class="control-group ">
                                                            <label class="required" for="Rank_allowance1">Meal Allowance Reg</label>
                                                            <div class="controls">
                                                                <input class="form-control" maxlength="5" name="Rank[allowance1]" id="Rank_allowance1" type="text" runat="server">
                                                            </div>
                                                        </div>
                                                        <div class="control-group ">
                                                            <label class="required" for="Rank_allowance2">Meal Allowance RES/Hol</label>
                                                            <div class="controls">
                                                                <input class="form-control" maxlength="5" name="Rank[allowance2]" id="Rank_allowance2" type="text" runat="server">
                                                            </div>
                                                        </div>
                                                        <div class="control-group ">
                                                            <div class="controls">
                                                                <span class="">
                                                                    <label class="checkbox" for="Rank_Ot">
                                                                        <input id="ytRank_Ot" type="hidden" value="0" name="Rank[Ot]"><input size="1" maxlength="1" value="1" name="Rank[Ot]" runat="server" id="Rank_Ot" type="checkbox"></input></input>
                                                                        With Overtime</label></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-actions">
                                                    <asp:Button ID="btnCreate" class="btn btn-primary" runat="server" Text="Create"
                                                        OnClick="btnCreate_Click" ValidationGroup="CreateRankGroup" OnClientClick="Confirm()"></asp:Button>
                                                    <asp:Button ID="btnReset" class="btn btn-danger" Width="80px" runat="server" Text="Reset"
                                                    OnClick="btnReset_Click"></asp:Button>
                                                </div>
                                            </fieldset>


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
