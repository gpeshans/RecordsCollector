using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecordsCollectorApp
{
    public partial class Administration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string fileName = Request.QueryString["name"].ToString();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            Response.TransmitFile(Server.MapPath("~/Files/" + fileName));
            Response.End();
        }
    }
}