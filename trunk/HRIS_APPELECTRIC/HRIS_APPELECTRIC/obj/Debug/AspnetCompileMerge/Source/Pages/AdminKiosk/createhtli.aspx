<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="createhtli.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.AdminKiosk.createhtli" %>
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
                <h3 class="m-0 text-dark">HTLI Directory<small> Add New Contact</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="adminhtli.aspx" class="btn btn-default"><i class="fa fa-th-list"></i><span class="h6">List</span></a>
                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="form">


                                    <fieldset>
                                        <legend>
                                            <p class="note">Fields with <span class="required text-red">*</span> are required.</p>
                                        </legend>



                                        <div class="row">
                                            <div class="col-lg-6">

                                                <div class="control-group ">
                                                    <label class="control-label required" for="Htli_Name">Name <span class="required text-red">*</span></label><div class="controls">
                                                        <input class="form-control" maxlength="50" name="Htli[Name]" id="Htli_Name" type="text" runat="server">
                                                    </div>
                                                </div>
                                                <div class="control-group ">
                                                    <label class="control-label required" for="Htli_Position">Position <span class="required text-red">*</span></label><div class="controls">
                                                        <input class="form-control" maxlength="50" name="Htli[Position]" id="Htli_Position" type="text" runat="server">
                                                    </div>
                                                </div>
                                                <div class="control-group ">
                                                    <label class="control-label required" for="Htli_Cp_Number">Cp Number <span class="required text-red">*</span></label><div class="controls">
                                                        <input class="form-control" maxlength="20" name="Htli[Cp_Number]" id="Htli_Cp_Number" type="text" runat="server">
                                                    </div>
                                                </div>
                                                <div class="control-group ">
                                                    <label class="control-label required" for="Htli_Phone_Number">Phone Number <span class="required text-red">*</span></label><div class="controls">
                                                        <input class="form-control" maxlength="20" name="Htli[Phone_Number]" id="Htli_Phone_Number" type="text" runat="server">
                                                    </div>
                                                </div>
                                                <div class="control-group ">
                                                    <label class="control-label required" for="Htli_Email">Email <span class="required text-red">*</span></label><div class="controls">
                                                        <input class="form-control" maxlength="50" name="Htli[Email]" id="Htli_Email" type="text" runat="server">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="form-actions">
                                            <%--<button class="btn btn-primary" type="submit" name="yt0"><i class="icon-ok icon-white"></i> Create</button>              
        <button class="btn" type="reset" name="yt1"><i class="icon-remove"></i> Reset</button>--%>
                                            <asp:Button ID="btnCreate" class="btn btn-primary" Width="80px" runat="server" Text="Save" OnClick="btnCreate_Click"></asp:Button>
                                            <asp:Button ID="btnReset" class="btn btn-danger" Width="80px" runat="server" Text="Reset" OnClick="btnReset_Click"></asp:Button>
                                        </div>
                                    </fieldset>



                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>

</asp:Content>
