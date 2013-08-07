<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="RecordsCollectorApp.AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
    <link rel="shortcut icon" type="image/x-icon" href="/images/favicon.ico" />
    <meta name="description" content="">
    <meta name="author" content="">
    <!-- Le styles -->
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /* Override some defaults */
        html, body
        {
            background-color: #eee;
        }
        body
        {
            padding-top: 40px;
        }
        .container
        {
            width: 300px;
        }
        
        /* The white background content wrapper */
        .container > .content
        {
            background-color: #fff;
            padding: 20px;
            margin: 0 -20px;
            -webkit-border-radius: 10px 10px 10px 10px;
            -moz-border-radius: 10px 10px 10px 10px;
            border-radius: 10px 10px 10px 10px;
            -webkit-box-shadow: 0 1px 2px rgba(0,0,0,.15);
            -moz-box-shadow: 0 1px 2px rgba(0,0,0,.15);
            box-shadow: 0 1px 2px rgba(0,0,0,.15);
        }
        
        .login-form
        {
            margin-left: 65px;
        }
        
        legend
        {
            margin-right: -50px;
            font-weight: bold;
            color: #404040;
        }
    </style>
</head>
<body>
    <div class="container">
        <div class="content">
            <div class="row">
                <div class="login-form">
                    <h2>
                        Login <a href="Default.aspx" class="btn"><i class="icon-home"></i></a>
                    </h2>
                    <form id="form1" runat="server">
                    <fieldset>
                        <div class="clearfix">
                            <asp:Literal ID="Literal2" runat="server">Username:</asp:Literal>
                            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                        </div>
                        <div class="clearfix">
                            <asp:Literal ID="Literal1" runat="server">Password:</asp:Literal>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="clearfix">
                            <asp:Label ID="lblError" runat="server" Text="" style="color: #FF0000"></asp:Label>                    
                        </div>
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Sign in"
                            OnClick="btnSubmit_Click" />
                    </fieldset>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <!-- /container -->
</body>
</html>
