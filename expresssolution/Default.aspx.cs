using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace expresssolution
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUnete_Click(object sender, EventArgs e)
        {
            if ((Usuario)Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx", false);
            } else
            {
                Session.Add("error", "Ya te encuentras logueado.");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}