using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace expresssolution
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TipoUsuarioNegocio tipo = new TipoUsuarioNegocio();

            ddlTipoUsuario.DataSource = tipo.listar();
            ddlTipoUsuario.DataValueField = "Id";
            ddlTipoUsuario.DataTextField = "Descripcion";
            ddlTipoUsuario.DataBind();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            // agregar los correspondientes llamados a BBDD 
            // para que se genere el update de los datos del usuario
            //
            //
            // si el que ingresa a modificar es el administrador 
            // se precargaran los datos del usuario que se paso por parametro en la session
            // se va a modificar ese registro
            //
            //
            // (para saber si el usuario que realiza la accion es admin se verifica la session)
            // (para saber si el admin modifica un usuario se verifica la session,
            // en la cual se cargara en un apartado "session.add("pagAnterior", title <- "nombre de la pagina")...
            // si el title en la session es ListaUsuarios,
            //      entonces es el admin modificando...
            // si el title en la sessin es Registro,
            //      es el admin o el telefonista cargando un usuario...
            // si el title en la session es Registro, pero en la session no hay un usuario activo...
            //      es un cliente tratando de registrarse.
            //
            //
            // en el caso de que el que ingreso a "mi perfil"
            // es otro tipo de usuario se precargaran los datos de dicho usuario
            // y se modificaran sus propios datos en la BBDD
            // en este caso el title en la session deberia ser Principal.
            // (tambien aplica para el administrador si el mismo entra a su perfil)
            //
            //
            // para esto se creo el procedimiento almacenado MODIFICAR_USUARIO
            // que recibe un todos los datos y actua en base al id que usa en la clausula WHERE
            //
            //
            // si se quisiera cambiar el rango de un telefonista
            // primeramente se deberia verificar que este no cuente con incidencias asignadas sin cerrar
            // esto se soluciona con el procedimiento almacenado en TELEFONISTA_SIN_INCIDENCIAS
            // el mismo recibe un id y cuenta las incidencias que tiene asignadas.


            try
            {
                Response.Redirect("Principal.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Principal.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}