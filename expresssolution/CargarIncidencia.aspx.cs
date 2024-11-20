using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using Seguridad;
using System.Security.Cryptography;

namespace expresssolution
{
    public partial class CargarIncidencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioNegocio usuarios = new UsuarioNegocio();
            ddlCliente.Enabled = true;
            ddlTelefonista.Enabled = true;
            // los comentarios en la incidencia solo se pueden ingresar
            // una vez que se cierra o se resuelve la misma.
            txtComentarioIncidencia.Enabled = false;
            Usuario aux = ((Usuario)Session["usuario"]);
            try
            {
                PrioridadNegocio prioridad = new PrioridadNegocio();
                ddlPrioridadIncidencia.DataSource = prioridad.listar();
                ddlPrioridadIncidencia.DataValueField = "Id";
                ddlPrioridadIncidencia.DataTextField = "Descripcion";
                ddlPrioridadIncidencia.DataBind();

                TipoNegocio tipo = new TipoNegocio();
                ddlTipoIncidencia.DataSource = tipo.listar();
                ddlTipoIncidencia.DataValueField = "Id";
                ddlTipoIncidencia.DataTextField = "Descripcion";
                ddlTipoIncidencia.DataBind();

                EstadoNegocio estados = new EstadoNegocio();
                ddlEstadoIncidencia.DataSource = estados.listar();
                ddlEstadoIncidencia.DataValueField = "Id";
                ddlEstadoIncidencia.DataTextField = "Descripcion";
                ddlEstadoIncidencia.DataBind();
                // hay que hacer un metodo que use la session para verificar la pantalla anterior
                // esto para saber si se esta modificando una incidencia o cargando una nueva
                // (por defecto se cargan en abierto, si la carga un cliente)
                // (pero si la carga un supervisor/administrador, ya asignan un telefonista, por lo cual estado seria asignado)
                // (pero si la carga un telefonista, ya asignan el mismo, por lo cual estado tambien seria asignado)
                ddlEstadoIncidencia.Enabled = false;

                ddlCliente.DataSource = usuarios.listarEspecifico(1);
                ddlCliente.DataValueField = "Id";
                ddlCliente.DataTextField = "Nombre";
                ddlCliente.DataBind();

                ddlTelefonista.DataSource = usuarios.listarEspecifico(2);
                ddlTelefonista.DataValueField = "Id";
                ddlTelefonista.DataTextField = "Nombre";
                ddlTelefonista.DataBind();


                int contador;
                // verifica si el usuario actual es un cliente, en caso de que si
                if (seguridad.EsCliente(aux))
                {
                    // en cuanto encuentra el indice en el cual se encuentra ese usuario 
                    // precarga su nombre e inhabilita la opcion de seleccionar para que no pueda ser modificada.
                    contador = 0;
                    foreach (Usuario recipiente in usuarios.listarEspecifico(1))
                    {
                        if (recipiente.ID == aux.ID)
                        {
                            ddlCliente.SelectedIndex = contador;
                            ddlCliente.Enabled = false;
                            break;
                        }
                        contador++;
                    }
                }

                if (seguridad.EsTelefonista(aux))
                {
                    contador = 0;
                    foreach (Usuario recipiente in usuarios.listarEspecifico(2))
                    {
                        if (recipiente.ID == aux.ID)
                        {
                            ddlTelefonista.SelectedIndex = contador;
                            ddlTelefonista.Enabled = false;
                            break;
                        }
                        contador++;
                    }
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
                //empezar a trabajar el manejo de la carga de incidencia.
                UsuarioXIncidencia nueva = new UsuarioXIncidencia();
                Incidencia actualizacion = new Incidencia();
                //cliente solo puede cargar estos datos y tiene que esperar a que los usuarios capacitados verifiquen su incidencia.
                nueva.IDIncidencia = 1;
                nueva.IDCliente = int.Parse(ddlCliente.SelectedValue);
                nueva.Descripcion = txtDescripcionIncidencia.Text;
                 
                // si es un usuario que no es cliente el que carga la incidencia, 
                // se procede a precargar los demas datos para enviar a la BBDD.
                if (!(seguridad.EsCliente(Session["usuario"])))
                {
                    nueva.Nombre = txtNombreIncidencia.Text;
                    actualizacion.IDEstado = int.Parse(ddlEstadoIncidencia.SelectedValue); // agregar un verificador para saber cual fue la pagina anterior, si es principal, esta cargando, si es lista incidencias, esta modificandp.
                    actualizacion.IDTipoIncidencia = int.Parse(ddlTipoIncidencia.SelectedValue);
                    actualizacion.IDPrioridadIncidencia = int.Parse(ddlPrioridadIncidencia.SelectedValue);
                    nueva.IDTelefonista = int.Parse(ddlTelefonista.SelectedValue);
                    actualizacion.Comentarios = txtComentarioIncidencia.Text;
                }

                UsuarioXIncidenciaNegocio nuevaNegocio = new UsuarioXIncidenciaNegocio();
                nuevaNegocio.cargarIncidencia(nueva);

                if (!(seguridad.EsCliente(Session["usuario"])))
                {
                    nuevaNegocio.actualizarIncidencia(nueva, actualizacion);
                }

                Response.Redirect("Principal.aspx", false);
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void ddlEstadoIncidencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            // preparacion de inicio de acciones modificar
            if (ddlEstadoIncidencia.SelectedIndex == 3 || ddlEstadoIncidencia.SelectedIndex == 6)
            {
                txtComentarioIncidencia.Enabled = true;
            }
        }
    }
}