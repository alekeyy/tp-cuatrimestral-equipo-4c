using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

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
                EstadoNegocio estado = new EstadoNegocio();


                ddlPrioridadIncidencia.DataSource = prioridad.listar();
                ddlPrioridadIncidencia.DataValueField = "Id";
                ddlPrioridadIncidencia.DataTextField = "Descripcion";
                ddlPrioridadIncidencia.DataBind();

                ddlTipoIncidencia.DataSource = tipo.listar();
                ddlTipoIncidencia.DataValueField = "Id";
                ddlTipoIncidencia.DataTextField = "Descripcion";
                ddlTipoIncidencia.DataBind();

                ddlEstadoIncidencia.DataSource = estado.listar();
                ddlEstadoIncidencia.DataValueField = "Id";
                ddlEstadoIncidencia.DataTextField = "Descripcion";
                ddlEstadoIncidencia.DataBind();

                // -- Cargar Telefonista y Cliente, con los valores 1- Cliente, 2-Telefonista de tipos de usuario

                UsuarioNegocio cliente = new UsuarioNegocio();
                ddlCliente.DataSource = cliente.listar(1);
                ddlCliente.DataValueField = "Id";
                ddlCliente.DataTextField = "Nombre";
                ddlCliente.DataBind();

                UsuarioNegocio telefonista = new UsuarioNegocio();
                ddlTelefonista.DataSource = telefonista.listar(2);
                ddlTelefonista.DataValueField = "Id";
                ddlTelefonista.DataTextField = "Nombre";
                ddlTelefonista.DataBind();

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
                IncidenciaNegocio negocio = new IncidenciaNegocio();
                Incidencia incidencia = new Incidencia();

                incidencia.Comentarios = txtDescripcionIncidencia.Text;
                incidencia.ID = negocio.agregar(incidencia);

                UsuarioXIncidenciaNegocio negocioReporte = new UsuarioXIncidenciaNegocio();
                UsuarioXIncidencia reporte = new UsuarioXIncidencia();
                reporte.IDCliente = ((Usuario)Session["usuario"]).ID;
                negocioReporte.agregar(reporte, incidencia);

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