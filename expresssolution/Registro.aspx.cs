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
                usuario.tipoUsuario.Descripcion = "CLIENTE";
                usuario.ID = negocio.Registrarse(usuario);
                if(usuario.ID > 0)
                {
                    /* que verifique si no se esta logueado ya, ejemplo un telefonista creando un usuario
                     * if(logueado){
                        Response.Redirect("ListadoIncidencias.aspx", false);
                     * } else { */
                    Session.Add("Usuario", usuario);
                    /* }
                    */
                    Response.Redirect("Perfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "No se pudo proceder con el registro.");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}