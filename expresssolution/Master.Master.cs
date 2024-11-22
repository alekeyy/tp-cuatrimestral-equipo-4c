using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seguridad;

namespace expresssolution
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!(Page is Login || Page is Default || Page is Registro || Page is Error || Page is Recuperar))
            {
                if (!seguridad.SessionActiva(Session["usuario"]))
                {
                    Response.Redirect("Login.aspx", false);
                }
            }
        }
        protected void btnCerrarSession_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
    }
}