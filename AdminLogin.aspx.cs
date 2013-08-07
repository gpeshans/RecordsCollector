using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecordsCollectorApp
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Text = "";
                txtPassword.Text = "";
                txtUsername.Text = "";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "PEDATeam" && txtPassword.Text == "//webdavclient//")
            {
                Session["admin"] = txtUsername.Text;
                Session["pass"] = txtPassword.Text;
                Response.Redirect("~/Administration.aspx");
            }
            else
            {
                lblError.Text = "Погрешено корисничко име или лозинка!";
            }
        }
    }
}