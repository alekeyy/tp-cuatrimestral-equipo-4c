using System;

namespace expresssolution
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["Error"] != null)
                {
                    lblError.Text = Session["Error"].ToString();
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}