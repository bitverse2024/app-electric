﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>App Electric | Login</title>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
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
    <body class="hold-transition login-page" id="signin" style="background-image:url('/images/loginbg.png'); background-size:cover; ">
        <form id="form1" runat="server">
        
            <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>
                                                                                                                                                                            <div class="container">
            <div class="row" style="">
                <div class="col-lg-12"> 
                    <div class="login-box">
                        <div class="login-logo">
                            <%--<b>APP ELECTRIC</b>--%>
                            <img src="<%= ResolveUrl("~/images/loginlogo.png")%>" style="width:350px;">
                           <%-- <img src="<%= ResolveUrl("~/images/dataland.png")%>" style="width:230px;">--%>
                        </div>
                        <!-- /.login-logo -->
                        <div class="login-box" style="background:rgb(250,231,6);opacity:0.9;color:black;border-radius:10px 10px 0px 0px;">
                        <div class="login-card-body rounded" style="background:#ffffff" >
                            <b><p class="login-box-msg">Sign in to start your session.</p></b>
                                <div class="form-group has-feedback">
                                    <input maxlength="45" class="form-control" placeholder="Username" style="border: 1px solid gray; min-height:35px;" name="LoginForm[username]" id="LoginForm_username" type="text" runat="server" />            
                                    <asp:RequiredFieldValidator  ID="RequiredFieldValidator5" runat="server" Display="Dynamic" ControlToValidate="LoginForm_username"  ValidationGroup="LoginGroup" ForeColor="Red" ErrorMessage="Username Required" ></asp:RequiredFieldValidator>
                                               
                                    <span class="glyphicon glyphicon-user form-control-feedback"></span>
                                </div>
                                <div class="form-group has-feedback">
                                    <input maxlength="45" class="form-control" placeholder="Password" style="border: 1px solid gray;  min-height:35px;" name="LoginForm[password]" id="LoginForm_password" type="password" runat="server" />            
                                    <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="LoginForm_password"  ValidationGroup="LoginGroup" ForeColor="Red" ErrorMessage="Password Required" ></asp:RequiredFieldValidator>          
                                    <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                                </div>
                                <%--<div class="form-group has-feedback">
			                        <select class="form-control" style="border: 1px solid gray;  min-height:35px;" name="LoginForm[company]" id="LoginForm_company" runat="server">
                                            <option value="">---Select Company---</option>
                                            
                                            
                                    </select>            <br />
                                    <asp:RequiredFieldValidator  ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="LoginForm_company"  ValidationGroup="LoginGroup" ForeColor="Red" ErrorMessage="Company Required" ></asp:RequiredFieldValidator>   		

                                </div>--%>
                                <%--<div class="row">--%>
                                        <div class="col-xs-12">
                                            <div class="checkbox icheck" style="margin-top:0px;">
                                                <label>
                                                    <input type="checkbox" onclick="myFunction()"> Show Password
                                                </label>
                                                <script type="text/javascript">
                                                    function myFunction() {
                                                        var x = document.getElementById("LoginForm_password");
                                                        if (x.type === "password") {
                                                            x.type = "text";
                                                        } else {
                                                            x.type = "password";
                                                        }
                                                    }
                                                </script>
                                            </div>
                                        </div>
                                        <!-- /.col -->
                                        <div class="col-xs-12">
                 
                                        </div>
                                        <!-- /.col -->
                                <%--</div>  --%>        
              
                                
                                    
                                <div class="social-auth-links text-center">
                                    <%--<input id="Submit1" class="btn btn-primary btn-block btn-flat" type="submit" name="yt0" value="Sign me in" onserverclick ="LoginButton_Click" runat="server" validationgroup ="LoginGroup"/>--%>
                                    <%--<a href="HRRecruitment/signup.aspx" class="btn bg btn-block">New Applicant? Sign up here to see job postings!</a>  --%>
                                </div>
                                <%--<div class="g-recaptcha" data-type="image" data-sitekey="6LfWK9gUAAAAAHuakxva6X7Ay-DKY35ONkFf3xGt"></div>--%>
                              

                                
                        </div>
                        <div class="footer">                                                               
                            <input class="btn bg btn-block btn-primary" style="opacity:0.9;color:black;font-weight:bold;font-family:Century gothic;border-radius:0px;" type="submit" name="yt0" value="Sign me in" onserverclick ="LoginButton_Click" runat="server" validationgroup ="LoginGroup"/>            
                            <div align="center">
                                <!-- <a href=/dataland/index.php?r=site/signup class="btn bg btn-block" style="background:white;color:#31668a;font-family:Century gothic;border-radius:0px;">New Applicant? Sign up here to see job postings!</a> -->
                                <%--<a href=/dataland/index.php?r=site/signup class="btn bg btn-block" style="background:#9dcae;color:black;font-family:Century gothic;border-radius:0px;font-weight:bold;">New Applicant? Sign up here to see job postings!</a>--%>         </div>
                        </div>    
                        </div>
                        
                        <!-- /.col -->
                    </div>
                    <!-- /.login-box-body -->
                </div>
            </div>
        </div>
            <!-- /.login-box -->

         <%--   <script type="text/javascript">
                $(function () {
                    $('input').iCheck({
                        checkboxClass: 'icheckbox_square-blue',
                        radioClass: 'iradio_square-blue',
                        increaseArea: '20%' /* optional */
                    });
                });
            </script>--%>
        </form>
    </body>
</html>
