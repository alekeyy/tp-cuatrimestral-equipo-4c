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
            try
            {

                int contadorGeneral;
                UsuarioNegocio usuarios = new UsuarioNegocio();
                PrioridadNegocio prioridad = new PrioridadNegocio();
                TipoNegocio tipo = new TipoNegocio();
                EstadoNegocio estados = new EstadoNegocio();
                ddlCliente.Enabled = true;
                ddlTelefonista.Enabled = true;
                btnAgregar.Text = "Agregar";
                // los comentarios en la incidencia solo se pueden ingresar
                // una vez que se cierra o se resuelve la misma.
                txtComentarioIncidencia.Enabled = false;
                Usuario aux = ((Usuario)Session["usuario"]);
                bool bandera = true;

                if (!IsPostBack)
                {
                    ddlPrioridadIncidencia.DataSource = prioridad.listar();
                    ddlPrioridadIncidencia.DataValueField = "Id";
                    ddlPrioridadIncidencia.DataTextField = "Descripcion";
                    ddlPrioridadIncidencia.DataBind();

                    ddlTipoIncidencia.DataSource = tipo.listar();
                    ddlTipoIncidencia.DataValueField = "Id";
                    ddlTipoIncidencia.DataTextField = "Descripcion";
                    ddlTipoIncidencia.DataBind();

                    ddlEstadoIncidencia.DataSource = estados.listar();
                    ddlEstadoIncidencia.DataValueField = "Id";
                    ddlEstadoIncidencia.DataTextField = "Descripcion";
                    ddlEstadoIncidencia.DataBind();

                    ddlEstadoIncidencia.Enabled = false;

                    ddlCliente.DataSource = usuarios.listarEspecifico(1);
                    ddlCliente.DataValueField = "Id";
                    ddlCliente.DataTextField = "Nombre";
                    ddlCliente.DataBind();

                    ddlTelefonista.DataSource = usuarios.listarEspecifico(2);
                    ddlTelefonista.DataValueField = "Id";
                    ddlTelefonista.DataTextField = "Nombre";
                    ddlTelefonista.DataBind();
                }


                if ((string)Session["PaginaAnterior"] == "Incidencias")
                {
                    bandera = false;
                    Session["PaginaAnterior"] = Title.ToString();
                    //POR LOGICA NO SE DEBERIA PODER MODIFICAR EL CLIENTE QUE CARGO LA INCIDENCIA
                    ddlEstadoIncidencia.Enabled = true;
                    btnAgregar.Text = "Modificar";

                    Incidencia incidencia = new Incidencia();
                    UsuarioXIncidencia usuarioXIncidencia = new UsuarioXIncidencia();

                    IncidenciaNegocio incidenciaNegocio = new IncidenciaNegocio();
                    UsuarioXIncidenciaNegocio usuarioXIncidenciaNegocio = new UsuarioXIncidenciaNegocio();

                    incidencia = incidenciaNegocio.buscarIncidencia((int)Session["IdAModificar"]);
                    usuarioXIncidencia = usuarioXIncidenciaNegocio.buscarUsuarioXIncidencia((int)Session["IdAModificar"]);

                    txtNombreIncidencia.Text = usuarioXIncidencia.Nombre;

                    contadorGeneral = 0;
                    foreach (Usuario recipiente in usuarios.listarEspecifico(1))
                    {
                        if (recipiente.ID == usuarioXIncidencia.IDCliente)
                        {
                            ddlCliente.SelectedIndex = contadorGeneral;
                            ddlCliente.Enabled = false;
                            break;
                        }
                        contadorGeneral++;
                    }

                    if (bandera)
                    {
                        // se "borra" el registro de la pagina anterior
                        Session["PaginaAnterior"] = "";
                    }

                    txtDescripcionIncidencia.Text = usuarioXIncidencia.Descripcion;

                    contadorGeneral = 0;
                    ddlEstadoIncidencia.SelectedIndex = contadorGeneral;
                    foreach (Estado recipiente in estados.listar())
                    {
                        if (recipiente.Id == incidencia.IDEstado)
                        {
                            ddlEstadoIncidencia.SelectedIndex = contadorGeneral;
                            break;
                        }
                        contadorGeneral++;
                    }

                    contadorGeneral = 0;
                    ddlTipoIncidencia.SelectedIndex = contadorGeneral;
                    foreach (Tipo recipiente in tipo.listar())
                    {
                        if (recipiente.Id == incidencia.IDTipoIncidencia)
                        {
                            ddlTipoIncidencia.SelectedIndex = contadorGeneral;
                            break;
                        }
                        contadorGeneral++;
                    }

                    contadorGeneral = 0;
                    ddlPrioridadIncidencia.SelectedIndex = contadorGeneral;
                    foreach (Prioridad recipiente in prioridad.listar())
                    {
                        if (recipiente.Id == incidencia.IDPrioridadIncidencia)
                        {
                            ddlPrioridadIncidencia.SelectedIndex = contadorGeneral;
                            break;
                        }
                        contadorGeneral++;
                    }

                    contadorGeneral = 0;
                    ddlTelefonista.SelectedIndex = contadorGeneral;
                    foreach (Usuario recipiente in usuarios.listarEspecifico(2))
                    {
                        if (recipiente.ID == usuarioXIncidencia.IDTelefonista)
                        {
                            ddlTelefonista.SelectedIndex = contadorGeneral;
                            break;
                        }
                        contadorGeneral++;
                    }

                    txtComentarioIncidencia.Text = incidencia.Comentarios;

                }


                // verifica si el usuario actual es un cliente, en caso de que si
                if (seguridad.EsCliente(aux))
                {
                    // en cuanto encuentra el indice en el cual se encuentra ese usuario 
                    // precarga su nombre e inhabilita la opcion de seleccionar para que no pueda ser modificada.
                    contadorGeneral = 0;
                    foreach (Usuario recipiente in usuarios.listarEspecifico(1))
                    {
                        if (recipiente.ID == aux.ID)
                        {
                            ddlCliente.SelectedIndex = contadorGeneral;
                            ddlCliente.Enabled = false;
                            break;
                        }
                        contadorGeneral++;
                    }
                }

                if (seguridad.EsTelefonista(aux))
                {
                    contadorGeneral = 0;
                    foreach (Usuario recipiente in usuarios.listarEspecifico(2))
                    {
                        if (recipiente.ID == aux.ID)
                        {
                            ddlTelefonista.SelectedIndex = contadorGeneral;
                            ddlTelefonista.Enabled = false;
                            break;
                        }
                        contadorGeneral++;
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
            UsuarioXIncidencia nueva = new UsuarioXIncidencia();
            UsuarioXIncidenciaNegocio nuevaNegocio = new UsuarioXIncidenciaNegocio();
            Incidencia actualizacion = new Incidencia();
            try
            {
                // esta verificacion puede sonar redundante 
                // pero en la session solo se guarda este dato si se esta modificando una incidencia.
                // si se esta cargando por primera vez tendra null o vacio en los casos en que fue explicitamente cargado.
                if ((string)Session["PaginaAnterior"] == "Cargar Incidencia")
                {
                    Session["PaginaAnterior"] = "";
                    nueva.IDCliente = int.Parse(ddlCliente.SelectedValue);
                    nueva.IDTelefonista = int.Parse(ddlTelefonista.SelectedValue);
                    nueva.Nombre = txtNombreIncidencia.Text;
                    nueva.Descripcion = txtDescripcionIncidencia.Text;

                    nueva.IDIncidencia = (int)Session["IdAModificar"];
                    actualizacion.IDPrioridadIncidencia = int.Parse(ddlPrioridadIncidencia.SelectedValue);
                    actualizacion.IDTipoIncidencia = int.Parse(ddlTipoIncidencia.SelectedValue);
                    actualizacion.IDEstado = int.Parse(ddlEstadoIncidencia.SelectedValue);
                    actualizacion.Comentarios = txtComentarioIncidencia.Text;

                    nuevaNegocio.actualizarIncidencia(nueva, actualizacion);
                }
                else
                {
                    //cliente solo puede cargar estos datos y tiene que esperar a que los usuarios capacitados verifiquen su incidencia.
                    nueva.IDIncidencia = -1;
                    nueva.IDCliente = int.Parse(ddlCliente.SelectedValue);
                    nueva.Descripcion = txtDescripcionIncidencia.Text;

                    if (!(seguridad.EsCliente(Session["usuario"])))
                    {
                        nueva.Nombre = txtNombreIncidencia.Text;
                        nueva.IDTelefonista = int.Parse(ddlTelefonista.SelectedValue);

                        actualizacion.IDTipoIncidencia = int.Parse(ddlTipoIncidencia.SelectedValue);
                        actualizacion.IDPrioridadIncidencia = int.Parse(ddlPrioridadIncidencia.SelectedValue);
                        actualizacion.IDEstado = int.Parse(ddlEstadoIncidencia.SelectedValue) == 0 ? 4 : int.Parse(ddlEstadoIncidencia.SelectedValue);
                        actualizacion.Comentarios = txtComentarioIncidencia.Text;
                    }

                    nuevaNegocio.cargarIncidencia(nueva);

                    if (!(seguridad.EsCliente(Session["usuario"])))
                    {
                        nuevaNegocio.actualizarIncidencia(nueva, actualizacion);
                    }
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
            ddlCliente.Enabled = false;
            if (ddlEstadoIncidencia.SelectedIndex == 2 || ddlEstadoIncidencia.SelectedIndex == 5)
            {
                txtComentarioIncidencia.Enabled = true;
            }
            else
            {
                txtComentarioIncidencia.Enabled = false;
            }
        }
    }
}