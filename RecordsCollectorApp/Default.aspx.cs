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
        string[] list = Directory.GetFiles(Server.MapPath("~/Files").ToString());
        HyperLink link = null;

        foreach (var item in list)
        {
            string pom = item.Split('/')[item.Split('/').Length - 1];
            link.NavigateUrl = Server.MapPath("~\\RecordsCollectorApp\\Files\\" + pom);
            Literal1.Controls.Add(link);
        }

        //ListBox1.DataSource = list;
        //ListBox1.DataBind();
    }
}