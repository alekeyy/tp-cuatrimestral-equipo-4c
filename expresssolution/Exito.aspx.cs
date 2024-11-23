using System;

namespace expresssolution
{
    public partial class Exito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AccionExitosa.Text = (string)Session["Exito"];
        }
    }
}