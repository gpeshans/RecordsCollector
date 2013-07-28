using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/Files"));
        int counter = 0;
        foreach (FileInfo file in directory.GetFiles())
        {
            HyperLink link = new HyperLink();
            link.ID = "Link" + counter++;
            link.Text = file.Name;
            link.NavigateUrl = "Administration.aspx?name=" + file.Name;

            form1.Controls.Add(link);
            form1.Controls.Add(new LiteralControl("<br/>"));
        }
    }
}