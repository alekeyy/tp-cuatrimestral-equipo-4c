using Dominio;
using System;

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
            }
        }
    }
}