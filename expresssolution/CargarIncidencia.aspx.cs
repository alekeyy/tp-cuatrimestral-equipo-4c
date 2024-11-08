using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace expresssolution
{
    public partial class CargarIncidencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                TipoNegocio tipo = new TipoNegocio();
                PrioridadNegocio prioridad = new PrioridadNegocio();

                ddlPrioridadIncidencia.DataSource = prioridad.listar();
                ddlPrioridadIncidencia.DataValueField = "Id";
                ddlPrioridadIncidencia.DataTextField = "Descripcion";
                ddlPrioridadIncidencia.DataBind();

            ddlTipoIncidencia.DataSource = tipo.listar();
            ddlTipoIncidencia.DataValueField = "Id";
            ddlTipoIncidencia.DataTextField = "Descripcion";
            ddlTipoIncidencia.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Principal.aspx", false);
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}