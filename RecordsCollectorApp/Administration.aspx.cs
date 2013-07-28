using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Ionic.Zip;

namespace RecordsCollectorApp
{
    public partial class Administration : System.Web.UI.Page
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
                link.NavigateUrl = "Download.aspx?name=" + file.Name;

                form1.Controls.Add(link);
                form1.Controls.Add(new LiteralControl("<br/>"));                
            }            
        }

        protected void DownloadButton_Click(object sender, EventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/Files"));
            ZipFile zip = new ZipFile();
            foreach (var item in directory.GetFiles())
            {
                string filePath = Server.MapPath("~/Files/" + item.Name);
                zip.AddFile(filePath, "files");
            }

            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=DownloadedFiles.zip");
            Response.ContentType = "application/zip";
            zip.Save(Response.OutputStream);
            Response.End();
        }
    }
}