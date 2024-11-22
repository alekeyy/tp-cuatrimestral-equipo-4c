using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace expresssolution
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                // Cargar Clientes
                dgvListaClientes.DataSource = negocio.listarEspecifico(1);
                dgvListaClientes.DataBind();

                // Cargar Usuarios
                dgvListaUsuarios.DataSource = negocio.listarEspecifico(3);
                dgvListaUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }

            if (!IsPostBack)
            {
                if (Seguridad.seguridad.EsAdmin(Session["usuario"])) 
                {
                    dgvListaUsuarios.Columns[4].Visible = true;
                } else
                {
                    dgvListaUsuarios.Columns[4].Visible = false;
                }
            }
        }

        protected void dgvListaClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvListaClientes.PageIndex = e.NewPageIndex;
            dgvListaClientes.DataBind();
        }

        protected void dgvListaUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvListaUsuarios.PageIndex = e.NewPageIndex;
            dgvListaUsuarios.DataBind();
        }

        protected void dgvListaClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["PaginaAnterior"] = Title.ToString();
                Session["IdAModificar"] = (int)dgvListaClientes.SelectedDataKey.Value;
                Response.Redirect("Perfil.aspx", false);
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvListaUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["PaginaAnterior"] = Title.ToString();
                Session["IdAModificar"] = (int)dgvListaUsuarios.SelectedDataKey.Value;
                Response.Redirect("Perfil.aspx", false);
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
        }

    }
}