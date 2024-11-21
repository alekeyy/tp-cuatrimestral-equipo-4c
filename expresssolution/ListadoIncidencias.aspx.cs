using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Seguridad;


namespace expresssolution
{
    public partial class ListadoIncidencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UsuarioXIncidenciaNegocio negocio = new UsuarioXIncidenciaNegocio();
                Usuario aux = ((Usuario)Session["usuario"]);
                dgvListaIncidenciasAsignadas.DataSource = negocio.listarIncidenciasModificado(aux.ID, aux.tipoUsuario.Id);
                dgvListaIncidenciasAsignadas.DataBind();
                if (seguridad.EsCliente(aux))
                {
                    dgvListaIncidenciasAsignadas.Columns[0].Visible = false;
                    dgvListaIncidenciasAsignadas.Columns[2].Visible = false;
                    dgvListaIncidenciasAsignadas.Columns[3].Visible = false;
                    dgvListaIncidenciasAsignadas.Columns[5].Visible = false;
                }
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
                Session["PaginaAnterior"] = "";
                Response.Redirect("CargarIncidencia.aspx", false);
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
        }
        protected void dgvListaIncidenciasAsignadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["PaginaAnterior"] = Title.ToString();
                Session["IdAModificar"] = (int)dgvListaIncidenciasAsignadas.SelectedDataKey.Value;
                Response.Redirect("CargarIncidencia.aspx", false);
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}