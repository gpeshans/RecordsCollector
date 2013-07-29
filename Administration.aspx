<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administration.aspx.cs"
    Inherits="RecordsCollectorApp.Administration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="css/master.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link rel="Stylesheet" href="css/styles.css" />
</head>
<body>
    <div class="container">
        <div class="top-content">
            <div class="logo">
                <img src="images\finki-logo-9.png" alt="" />
            </div>
            <div class="masthead">
                <h3 class="muted">
                    Страна за администрација</h3>
                <div class="navbar">
                    <div class="navbar-inner">
                        <div class="container">
                            <ul class="nav">
                                <li><a>Зачувани снимки</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <!-- /.navbar -->
            </div>
        </div>
        <div class="main-content">
            <div id="main">
                <form id="form1" runat="server">
                <div class="buttons">
                    <asp:Button ID="DownloadButton" runat="server" Text="Download" OnClick="DownloadButton_Click" />
                    <br />
                    <br />
                    <asp:Button ID="DeleteAllButton" runat="server" Text="Delete All" OnClick="DeleteAllButton_Click" />
                    <br />
                    <br />
                </div>
                </form>
            </div>
        </div>
    </div>
    <!-- Le javascript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/bootstrap.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>
