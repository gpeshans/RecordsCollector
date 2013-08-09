using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Ionic.Zip;
using System.Data;
using HtmlAgilityPack;
using RecordsCollectorApp.ServiceReference1;

namespace RecordsCollectorApp
{
    public partial class Administration : System.Web.UI.Page
    {
        DataBaseAccessServiceClient client = new DataBaseAccessServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null || Session["pass"] == null)
            {
                Response.Redirect("~/AdminLogin.aspx");
            }
            if (Session["admin"].ToString() != "PEDATeam" && Session["pass"].ToString() != "//webdavclient//")
            {
                Response.Redirect("~/AdminLogin.aspx");
            }

            if (!IsPostBack)
            {
                BindGridview();
                SetRecordCounts();
            }
        }

        protected void BindGridview()
        {
            string[] filesPath = Directory.GetFiles(Server.MapPath("~/Files/"));
            List<ListItem> files = new List<ListItem>();
            foreach (string path in filesPath)
            {
                files.Add(new ListItem("~/Files/" + Path.GetFileName(path)));
            }
            gvDetails.DataSource = files;
            gvDetails.DataBind();
        }

        protected void DownloadButton_Click(object sender, EventArgs e)
        {
            using (ZipFile zip = new ZipFile())
            {
                foreach (GridViewRow gvrow in gvDetails.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("chkSelect");
                    if (chk.Checked)
                    {
                        string fullName = ((HyperLink)gvrow.Cells[1].Controls[0]).Text; ;
                        string fileName = fullName.Split('/')[fullName.Split('/').Length - 1];
                        string filePath = Server.MapPath("~/Files/" + fileName);
                        zip.AddFile(filePath, "files");
                    }
                }
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=DownloadedSelectedFiles.zip");
                Response.ContentType = "application/zip";
                zip.Save(Response.OutputStream);
                Response.End();
            }
        }

        protected void DeleteAllButton_Click(object sender, EventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/Files"));
            foreach (FileInfo file in directory.GetFiles())
            {
                string filePath = Server.MapPath("~/Files/" + file.Name);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            BindGridview();
        }
        protected void DownloadAllButton_Click(object sender, EventArgs e)
        {
            using (ZipFile zip = new ZipFile())
            {
                foreach (GridViewRow gvrow in gvDetails.Rows)
                {
                    string fullName = ((HyperLink)gvrow.Cells[1].Controls[0]).Text;
                    string fileName = fullName.Split('/')[fullName.Split('/').Length - 1];
                    string filePath = Server.MapPath("~/Files/" + fileName);
                    zip.AddFile(filePath, "files");
                }
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=DownloadedAllFiles.zip");
                Response.ContentType = "application/zip";
                zip.Save(Response.OutputStream);
                Response.End();
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in gvDetails.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkSelect");
                if (chk.Checked)
                {
                    string fullName = ((HyperLink)gvrow.Cells[1].Controls[0]).Text;
                    string fileName = fullName.Split('/')[fullName.Split('/').Length - 1];
                    string filePath = Server.MapPath("~/Files/" + fileName);
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }
            }

            BindGridview();
        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/AdminLogin.aspx");
        }

        protected void SetRecordCounts()
        {
            lblNamesCount.Text += client.CountNamesRecords().ToString();
            lblNumbersCount.Text += client.CountNumbersRecords().ToString();
        }
    }
}