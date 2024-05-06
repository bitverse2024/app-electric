<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.HRRecruitment.signup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <!-- Tell the browser to be responsive to screen width -->
    <link href="~/dist/css/AdminLTE.css" rel="stylesheet" type="text/css" />
    <!-- iCheck -->
    <link rel="stylesheet" href="~/plugins/iCheck/square/blue.css" type="text/css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->
    <!-- Google Font -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic" type="text/css" />
    <script src="https://www.google.com/recaptcha/api.js" async defer></script>

</head>
<body class="hold-transition login-page" id="signin">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <div class="container">
            <div class="row" style="">
                <div class="col-lg-12">
                    <div class="login-box">
                        <div class="login-logo">
                            <!-- <a href="#"><b>CavDeal</b></a> -->
                            <b>APP ELECTRIC</b>
                        </div>
                        <!-- /.login-logo -->
                        <div class="login-card-body rounded" style="background: #00a157; color: black; border-radius: 10px 10px 0px 0px;">
                            <div style="padding-top:10px"></div>
                            <div class="login-card-body bg-white">
                                <h4>PERSONAL DETAILS</h4>
                                <div class="form-group has-feedback">
                                    <input maxlength="45" class="form-control" placeholder="First Name" style="border: 1px solid gray; min-height: 35px;" name="SignUpForm[firstname]" id="SignUpForm_firstname" type="text" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="SignUpForm_firstname" ForeColor="Red" Display="Dynamic" ErrorMessage="Required" ValidationGroup="SignUpGroup"></asp:RequiredFieldValidator>
                                    <div class="callout callout-danger" id="SignUpForm_firstname_em_" style="display: none"></div>
                                    <span class="glyphicon glyphicon-user form-control-feedback"></span>
                                </div>

                                <div class="form-group has-feedback">
                                    <input maxlength="45" class="form-control" placeholder="Middle Name" style="border: 1px solid gray; min-height: 35px;" name="SignUpForm[middlename]" id="SignUpForm_middlename" type="text" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="SignUpForm_middlename" ForeColor="Red" Display="Dynamic" ErrorMessage="Required" ValidationGroup="SignUpGroup"></asp:RequiredFieldValidator>
                                    <div class="callout callout-danger" id="SignUpForm_middlename_em_" style="display: none"></div>
                                    <span class="glyphicon glyphicon-user form-control-feedback"></span>
                                </div>

                                <div class="form-group has-feedback">
                                    <input maxlength="45" class="form-control" placeholder="Last Name" style="border: 1px solid gray; min-height: 35px;" name="SignUpForm[surname]" id="SignUpForm_surname" type="text" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="SignUpForm_surname" ForeColor="Red" Display="Dynamic" ErrorMessage="Required" ValidationGroup="SignUpGroup"></asp:RequiredFieldValidator>
                                    <div class="callout callout-danger" id="SignUpForm_surname_em_" style="display: none"></div>
                                    <span class="glyphicon glyphicon-user form-control-feedback"></span>
                                </div>

                                <div class="form-group has-feedback">
                                    <input maxlength="45" class="form-control" placeholder="Password" style="border: 1px solid gray; min-height: 35px;" name="SignUpForm[password]" id="SignUpForm_password" type="password" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="SignUpForm_password" ForeColor="Red" Display="Dynamic" ErrorMessage="Required" ValidationGroup="SignUpGroup"></asp:RequiredFieldValidator>
                                    <div class="callout callout-danger" id="SignUpForm_password_em_" style="display: none"></div>
                                    <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                                </div>

                                <div class="form-group has-feedback">
                                    <input maxlength="45" class="form-control" placeholder="E-mail" style="border: 1px solid gray; min-height: 35px;" name="SignUpForm[email]" id="SignUpForm_email" type="text" runat="server" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="SignUpForm_email"
                                        ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                        Display="Dynamic" ErrorMessage="Invalid email address" ValidationGroup="SignUpGroup"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="SignUpForm_email" ForeColor="Red" Display="Dynamic" ErrorMessage="Required" ValidationGroup="SignUpGroup"></asp:RequiredFieldValidator>
                                    <div class="callout callout-danger" id="SignUpForm_email_em_" style="display: none"></div>
                                    <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                                </div>

                            </div>
                            <div class="social-auth-links text-center">
                                <input class="btn bg btn-block" style="background: #989898; color: black; font-weight: bold; font-family: Century gothic; border-radius: 0px;" type="submit" name="yt0" value="SIGN UP" onserverclick="SignUpButton_Click" runat="server" validationgroup="SignUpGroup" />
                                <div align="center">
                                    <a href="../Login.aspx" class="btn bg btn-block" style="background: white; color: #31668a; font-weight: bold; font-family: Century gothic; border-radius: 0px;">BACK</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>




</body>
</html>
