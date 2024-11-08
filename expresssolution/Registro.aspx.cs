using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace expresssolution
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Usuario)Session["usuario"] != null)
            {
                btnRegistrarse.Text = "Crear Usuario";
            }
        }
        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();

            try
            {

                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPass.Text;
                usuario.tipoUsuario = new TipoUsuario();
                usuario.tipoUsuario.Id = 1;
                usuario.tipoUsuario.Descripcion = "CLIENTE";
                usuario.ID = negocio.Registrarse(usuario);
                if(usuario.ID > 0)
                {
                    if ((Usuario)Session["Usuario"] == null)
                    {
                        Session["Usuario"] = usuario;
                        Response.Redirect("Principal.aspx", false);
                    } else
                    {
                        Response.Redirect("Exito.aspx", false);
                    }
                }
                else
                {
                    Session["Error"] = "No se pudo proceder con el registro.";
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session["Error"] =  ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                // si es igual a null significa que un usuario intenta registrarse
                // si es distinto a null, es otro usuario tratando de cargar un usuario
                // 
                // no hace falta realizar mas evaluaciones ya que un usuario "cliente"
                // no podra acceder a registro si ya esta registrado.
                if ((Usuario)Session["Usuario"] == null)
                    Response.Redirect("Default.aspx", false);
                else
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