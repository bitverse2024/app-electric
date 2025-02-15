﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DTRSetting.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.Employees._201.DTRSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <SCRIPT type="text/javascript">
       <!--
       function isNumberKey(evt)
       {
          var charCode = (evt.which) ? evt.which : evt.keyCode;
          if (charCode != 46 && charCode > 31 
            && (charCode < 48 || charCode > 57))
             return false;

          return true;
       }
       //-->
    </SCRIPT>
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
                <h3 class="m-0 text-dark"><%=getname() %><small> DTR Setting</small></h3>
                <section class="card">
                    <div class="card-header">
                        <a href="<%= ResolveUrl("~/Pages/Admin/Employees/EmployeeView.aspx?empid="+empno+"")%>" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">Employee View</span></a>
                        <%--<a href="DTRSetting.aspx" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h6">DTR Setting</span></a>--%>
                    </div>
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <label class="control-label required">Grace Period</label>
                                            <div class="controls">
                                                <%--<input class="form-control" maxlength="50" name="Assets[item]" id="txtGrace" type="text" runat="server" />--%>
                                                <input class="form-control" id="txtGrace" name="DTRSettings[txtGrace]" type="number" min="1" max="60" onkeypress="return isNumberKey(event)"  runat="server" />
                                                                
                                            </div>
                                           <div style="padding-top:5px">
                                                <asp:CheckBox ID="chkLate" runat="server" Text="Disregard Lates" CssClass="checkbox-inline" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <asp:Button ID="btnCreate" Width="80" class="btn btn-primary" runat="server" Text="Save"
                                                OnClick="btnCreate_Click" OnClientClick="Confirm1()"></asp:Button>
                                            <asp:Button ID="btnReset" class="btn btn-danger" Width="80" runat="server" Text="Reset"
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

</asp:Content>
