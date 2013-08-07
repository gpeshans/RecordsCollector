<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administration.aspx.cs"
    Inherits="RecordsCollectorApp.Administration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Page</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="shortcut icon" type="image/x-icon" href="/images/favicon.ico" />
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
                    Страна за администрација <a href="Default.aspx" class="btn"><i class="icon-home"></i>
                    </a>
                </h3>
                <div class="navbar">
                    <div class="navbar-inner">
                        <div class="container">
                            <ul class="nav">
                                <li><a>Зачувани снимки </a></li>
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
                <div style="text-align: center; width: 100%;">
                    <asp:GridView ID="gvDetails" CellPadding="5" runat="server" AutoGenerateColumns="False"
                        HorizontalAlign="Center" BackColor="White" CssClass="table table-striped table-bordered table-condensed">
                        <Columns>
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:HyperLinkField DataTextField="Text" HeaderText="FileName" DataNavigateUrlFields="Text" />
                        </Columns>
                        <HeaderStyle BackColor="" Font-Bold="true" ForeColor="GrayText" />
                    </asp:GridView>
                    <br />
                    <br />
                    <div style="text-align: center; width: 100; margin: 0 auto;">
                        <div style="float: left;">
                            <div style="float: left; margin: 0 30px;">
                                <asp:Button ID="DownloadButton" Text="Download Selected" class="btn" runat="server"
                                    OnClick="DownloadButton_Click" />
                            </div>
                            <div style="float: right; margin: 0 30px;">
                                <asp:Button ID="DownloadAllButton" runat="server" Text="Download All" class="btn"
                                    OnClick="DownloadAllButton_Click" />
                            </div>
                        </div>
                        <div style="float: right;">
                            <div style="float: left; margin: 0 30px;">
                                <asp:Button ID="DeleteButton" runat="server" Text="Delete Selected" class="btn" OnClick="DeleteButton_Click" />
                            </div>
                            <div style="float: right; margin: 0 30px;">
                                <asp:Button ID="DeleteAllButton" runat="server" Text="Delete All" class="btn" OnClick="DeleteAllButton_Click" />
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <asp:Button ID="ButtonLogOut" runat="server" Text="LogOut" class="btn btn-danger btn-small"
                        OnClick="ButtonLogOut_Click" />
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
