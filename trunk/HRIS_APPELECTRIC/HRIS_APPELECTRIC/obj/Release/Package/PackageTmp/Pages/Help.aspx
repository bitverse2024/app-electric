<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Help" %>

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
                <h2 class="m-0 text-dark">What is HRIS <small></small></h2>
                <section class="card">
                    <div class="card-body">
                        <div class="content">
                            <div class="container-fluid">
                                <div class="box box-body">
                                    <div class="row">
                                        <div class="col-lg-9">
                                            <asp:Panel ID="Panel1" runat="server">

                                                <asp:Label ID="lblPar" runat="server" CssClass="h4"
                                                    Text="HRIS is capable of storing, processing and managing of employee data. <br /> It allows users to manage their Employees Information, Employees' DTRs and even process the Company's Payroll. HRIS can help lessen the time spent of the HR Department on clerical works and helps to ensure the accuracy of Employees' data."></asp:Label>
                                                <br />
                                                <br />

                                                <asp:Button ID="Button1" runat="server" Text="LEARN MORE" CssClass="btn-info" />
                                            </asp:Panel>
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
