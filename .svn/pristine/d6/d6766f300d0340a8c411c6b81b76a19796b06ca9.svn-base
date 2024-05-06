<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuthenPage1.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.AuthenPage1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <link href="~/dist/css/AdminLTE.css" rel="stylesheet" type="text/css" />
  <!-- iCheck -->
  <link rel="stylesheet" href="~/plugins/iCheck/square/blue.css" type="text/css" />
  <!-- Google Font -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic" type="text/css" />
  <script src="https://www.google.com/recaptcha/api.js" async defer></script>
    <style type="text/css">
        .txt
        {
            width: 20px;
            text-align: center;
            font-family: Arial;
        }
        .lbltitle
        {
            font-family: Arial;
            font-size: 20px;
        }
        .lblsub
        {
            font-family: Arial;
            font-size: 16px;
        }
        .box {
            width:400px;
            height:200px;
            background-color:#d9d9d9;
            position:fixed;
            margin-left:-200px; /* half of width */
            margin-top:-150px;  /* half of height */
            top:50%;
            left:50%;
            border:.5px solid grey; 
            border-radius:.5em;
        }
    </style>
    <title></title>
    </head>
<body class="hold-transition login-page" style="background-color: #f0f0f0">
    <form id="form1" runat="server">
    <script type="text/javascript" language="javascript">
        function numeric(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode;
            if (unicode == 8 || unicode == 9 || (unicode >= 48 && unicode <= 57)) {
                return true;
            }
            else {
                return false;
            }
        }
        function moveCursor(fromTextBox, toTextBox) {
            var length = fromTextBox.value.length;
            var maxLength = fromTextBox.getAttribute("MaxLength");

            if (length == maxLength) {
                document.getElementById(toTextBox).focus();
            }
        }
    </script>

    <div class="row" style="">
                <div class="col-lg-12"> 
                    <div class="login-box">
                        <div class="login-logo">
                            <b>App Electric</b>
                           <%-- <img src="<%= ResolveUrl("~/images/dataland.png")%>" style="width:230px;">--%>
                        </div>
                        <!-- /.login-logo -->
                        <div class="login-card-body">
                            <b><p class="login-box-msg">Authentication</p></b>
                                <div class="form-group has-feedback text-center">
                                    <%--<asp:Label ID="Label3" runat="server" CssClass="lblsub" Text="Email address:"></asp:Label>--%>
                                    <asp:Label ID="Label4" runat="server" CssClass="lblsub" Text="">
                                    </asp:Label><%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required"
                                     ForeColor="Red" ControlToValidate="txtCreds" ValidationGroup="email"></asp:RequiredFieldValidator> --%>                                  
                                    <%--<asp:TextBox ID="txtCreds" runat="server" ReadOnly = "true"></asp:TextBox><br />  --%>
                                    <div class="col-xs-12"></div><div class="col-xs-12"></div><div class="col-xs-12"></div>
                                    <asp:Button ID="btnSendCode" runat="server" CssClass="btn-info" Text="Send Code" onclick="btnSendCode_Click" ValidationGroup="email" /><br />
                                    <asp:Label ID="Label1" runat="server" CssClass="lbltitle" Text="An OTP is sent to" Visible="false"></asp:Label>
                                </div>
                                <div class="form-group has-feedback text-center" style="margin-left:auto; margin-right:auto" runat="server" id="div1" visible="false">
                                    <asp:Label ID="Label2" runat="server" CssClass="lblsub" Text="Enter OTP:"></asp:Label><br />
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="txt" MaxLength="1" onkeypress="return numeric(event)" onkeyup="moveCursor(this,'TextBox2')" TabIndex="1"></asp:TextBox>
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="txt" MaxLength="1" onkeypress="return numeric(event)" onkeyup="moveCursor(this,'TextBox3')" TabIndex="2"></asp:TextBox> 
                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="txt" MaxLength="1" onkeypress="return numeric(event)" onkeyup="moveCursor(this,'TextBox4')" TabIndex="3"></asp:TextBox> 
                                    <asp:TextBox ID="TextBox4" runat="server" CssClass="txt" MaxLength="1" onkeypress="return numeric(event)" onkeyup="moveCursor(this,'TextBox5')" TabIndex="4"></asp:TextBox>
                                    <asp:TextBox ID="TextBox5" runat="server" CssClass="txt" MaxLength="1" onkeypress="return numeric(event)" onkeyup="moveCursor(this,'TextBox6')" TabIndex="5"></asp:TextBox> 
                                    <asp:TextBox ID="TextBox6" runat="server" CssClass="txt" MaxLength="1" onkeypress="return numeric(event)" TabIndex="6"></asp:TextBox> 
                                </div>
                                <%--<div class="row">--%>
                                        
                                        <!-- /.col -->
                                <%--</div>  --%>        
              
                                
                                    
                                <div class="social-auth-links text-center" runat="server" id="div2" visible="false">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn-success" onclick="btnSubmit_Click" /><br />
                                    <asp:Label ID="lblCode" runat="server" Text="No code received? " CssClass="lblsub"></asp:Label>
                                    <asp:LinkButton ID="lnkbtnOTP" runat="server" CssClass="lblsub" OnClick="btnReSendCode_Click">Resend OTP</asp:LinkButton> <br />
                                    <asp:Label ID="Label5" runat="server" Text="Entered wrong email address? " CssClass="lblsub"></asp:Label><br />
                                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="lblsub" 
                                        onclick="LinkButton2_Click">Change email</asp:LinkButton>      
                                </div>
                        
                    </div>
                    <!-- /.login-box-body -->
                </div>
            </div>
        </div>
    </form>


</body>
</html>
