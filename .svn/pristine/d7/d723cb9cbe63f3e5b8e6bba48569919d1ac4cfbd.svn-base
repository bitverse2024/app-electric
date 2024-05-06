<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="applicantuploadfiles.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.HRRecruitment.applicantuploadfiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    <h3 class="m-0 text-dark">Applicant Files<small> applicantprofileview.aspx?id=<%=applicantInfo["id"] %>"><%=applicantInfo["FullName"] %></small></h3>
                    <section class="card">
                        <div class="card-header">
                            <a href="createapplicant.aspx" class="btn btn-default"><i class="fa fa-plus"></i><span class="h5">Create</span></a>
                            <a href="../../Default_kioskapplicant.aspx" class="btn btn-default"><i class="fa fa-th-list"></i><span class="h5">List</span></a>
                            <a href="applicantprofileview.aspx?id=<%=applicantInfo["id"] %>" class="btn btn-default"><i class="fa fa-arrow-left"></i><span class="h5">Back to Applicant View</span></a>
                        </div>
                        <div class="card-body">
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="box-body">
                                        <section class="connectedSortable">

                                            <h3>Applicant Files
                                            </h3>
                                            <hr>
                                            <div class="form">
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <span class="input-group-lg">Select Category: </span>
                                                        <asp:DropDownList ID="drpdwnCategory" runat="server" Font-Bold="true">
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
                                                <div class="row">
                                                    <%--<div id="Div1" runat="server" class="form-group form-group-sm col-md-10 col-md-offset-1">--%>
                                                    <div class="col-lg-6">
                                                        <div class="input-group">
                                                            <span class="input-group-lg">Select File: </span>
                                                            <asp:FileUpload ID="fuUploader" runat="server" CssClass="form-control btn-default" />
                                                            <asp:RequiredFieldValidator ID="validatorUploader" runat="server" ControlToValidate="fuUploader" ValidationGroup="uploadGroup" ForeColor="Red" ErrorMessage="Select csv file to upload."></asp:RequiredFieldValidator>
                                                            <%--<asp:RegularExpressionValidator ID="validatorFileUpload" 
                                    ControlToValidate="fuUploader" ValidationGroup="uploadGroup" runat="server" 
                                    ErrorMessage="Only image with .jpg, .jpeg or .png is allowed." 
                                    ValidationExpression="^.*\.(jpg|JPG|JPEG|jpeg|png|PNG)$"></asp:RegularExpressionValidator>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row submit">
                                                    <div class="col-lg-6">
                                                        <%--<input type="submit" name="yt0" value="upload" />--%>
                                                        <asp:LinkButton ID="btnUploadImage" runat="server"
                                                            CssClass="btn btn-primary btn-block" ValidationGroup="uploadGroup"
                                                            OnClick="btnUploadImage_Click">Upload</asp:LinkButton>
                                                    </div>
                                                </div>

                                                <%--<div class="row">
            <div class="col-lg-6">
            <label for="UploadFile_fileupload">Choose File</label> 
            <input id="ytUploadFile_fileupload" type="hidden" value="" name="UploadFile[fileupload]"><input name="UploadFile[fileupload]" id="UploadFile_fileupload" type="file">            </div>
        </div>
        
        <div class="row submit">
            <div class="col-lg-6">
            <input type="submit" name="yt0" value="upload">            
            </div>
        </div>--%>
                                            </div>
                                        </section>

                                        <div id="comments">
                                            <div id="files-grid" class="grid-view">

                                                <asp:GridView ID="GridFilesList" runat="server" AutoGenerateColumns="False"
                                                    ShowFooter="True" CssClass="items table table-striped table-bordered table-condensed"
                                                    GridLines="None" AllowPaging="True" Font-Names="Segoe UI"
                                                    ForeColor="Black" OnRowCommand="GridFilesList_RowCommand"
                                                    OnPageIndexChanging="GridFilesList_PageIndexChanging"
                                                    ViewStateMode="Enabled">
                                                    <EmptyDataTemplate>
                                                        <center><h1>NO Files AVAILABLE</h1></center>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkFileID" Text='FileID' runat="server" CommandName="Sort" CommandArgument="FileID"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchFileID" runat="server" OnTextChanged="txtItem_TextChanged" Width="90px"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFileID" Text='<%# Eval("FileID") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkFilename" Text='Filename' runat="server" CommandName="Sort" CommandArgument="Filename"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchFilename" runat="server" OnTextChanged="txtItem_TextChanged" Width="90px"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFilename" Text='<%# Eval("Filename") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lnkCateg" Text='Category' runat="server" CommandName="Sort" CommandArgument="Category"></asp:LinkButton><br />
                                                                <asp:TextBox ID="txtSearchCateg" runat="server" OnTextChanged="txtItem_TextChanged" Width="90px"></asp:TextBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCatege" Text='<%# Eval("Category") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="lblReset" Text='Reset' runat="server" CommandName="Reset" CommandArgument="Reset"></asp:LinkButton><br />

                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnDL" CssClass="btn-success btn-xs" runat="server" Text="Download" CommandName="dl_file" CommandArgument='<%# Eval("FileID") %>' />
                                                                <asp:Button ID="btnDelete" CssClass="btn-danger btn-xs" runat="server" Text="Delete" CommandName="del" CommandArgument='<%# Eval("FileID") %>' />
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <%--<asp:CommandField HeaderText="Cancel Item" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-xs btn-danger"  /> --%>
                                                    </Columns>
                                                </asp:GridView>

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
        <!-- /.row (main row) -->
    </aside>
</asp:Content>
