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

                    // -> SE VERIFICA SI HAY UN USUARIO EN SESION
                    //    PORQUE DE HABERLO SIGNIFICA QUE ES OTRO USUARIO TRATANDO DE CARGAR UNO NUEVO
                    //    Y DE SER ASI, NO SE DEBE GUARDAR EL NUEVO USUARIO EN SESION, SOLO REDIRECCIONAR.
                    // 
                    //    SI NO HUBIERA UN USUARIO EN SESSION, ES UN USUARIO NUEVO TRATANDO DE REGISTRARSE.
                    //    ENTONCES SI SE GUARDAN SUS DATOS EN SESSION.
                    if ((Usuario)Session["Usuario"] == null)
                        Session["Usuario"] = usuario;
                    /* }
                    */
                    Response.Redirect("Principal.aspx", false);
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