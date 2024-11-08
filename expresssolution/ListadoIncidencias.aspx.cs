using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;


namespace expresssolution
{
    public partial class ListadoIncidencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UsuarioXIncidenciaNegocio negocio = new UsuarioXIncidenciaNegocio();
                dgvListaIncidenciasAsignadas.DataSource = negocio.listar();
                dgvListaIncidenciasAsignadas.DataBind();
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("CargarIncidencia.aspx");
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
        }

    }
}