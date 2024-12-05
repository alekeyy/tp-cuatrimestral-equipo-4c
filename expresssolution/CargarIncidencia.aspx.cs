using Dominio;
using Negocio;
using Seguridad;
using System;

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
                txtDescripcionIncidencia.Enabled = true;
                btnAgregar.Text = "Agregar";
                btnAgregar.Enabled = false;
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


                //---------APARTADO DE MODIFICACION DE INCIDENCIAS--------------------------------------------------------
                if ((string)Session["PaginaAnterior"] == "Incidencias" && !IsPostBack)
                {
                    bandera = false;
                    Session["PaginaAnterior"] = Title.ToString();
                    //POR LOGICA NO SE DEBERIA PODER MODIFICAR EL CLIENTE QUE CARGO LA INCIDENCIA
                    ddlEstadoIncidencia.Enabled = true;
                    txtDescripcionIncidencia.Enabled = false;
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

                    btnAgregar.Enabled = true;
                }

                if (bandera && !IsPostBack)
                {
                    // se "borra" el registro de la pagina anterior
                    Session["PaginaAnterior"] = "";
                }


                //---------APARTADO DE CARGA DE CLIENTE--------------------------------------------------------
                // verifica si el usuario actual es un cliente, en caso de que si
                if (seguridad.EsCliente(aux))
                {
                    // en cuanto encuentra el indice en el cual se encuentra ese usuario 
                    // precarga su nombre e inhabilita la opcion de seleccionar para que no pueda ser modificada.
                    btnAgregar.Text = "aceptar";
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

                //---------APARTADO DE CARGA DE INCIDENCIAS TELEFONISTA--------------------------------------------------------
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

                //-----------------------VALIDACIONES GENERALES--------------------------------------------------------
                if (IsPostBack)
                {

                    // modificacion para que el postback no vuelva a reactivar la ddl de clientes impidiendo asi su modificacion.
                    if ((string)Session["PaginaAnterior"] == "Cargar Incidencia")
                    {
                        ddlCliente.Enabled = false;
                        btnAgregar.Text = "Modificar";
                    }

                    if (seguridad.verificadorNullVacioEnBlanco(txtDescripcionIncidencia.Text))
                    {
                        lblDescripcionObligatoria.Text = "*";
                        lblDescripcionObligatoria.ForeColor = seguridad.escalasDeColores("");
                        lblValidadorObligatorio.Text = "Es obligatorio rellenar los campos marcados";
                        lblValidadorObligatorio.ForeColor = seguridad.escalasDeColores("");

                        btnAgregar.Enabled = false;
                    }
                    else if (seguridad.verificadorMaximoCaracteres(txtDescripcionIncidencia.Text))
                    {
                        lblDescripcionObligatoria.Text = " (La cantidad de caracteres no puede superar los 300)";
                        lblDescripcionObligatoria.ForeColor = seguridad.escalasDeColores("");
                        lblValidadorObligatorio.Text = "";

                        btnAgregar.Enabled = false;
                    }
                    else
                    {
                        lblDescripcionObligatoria.Text = "";
                        lblValidadorObligatorio.Text = "";

                        btnAgregar.Enabled = true;
                    }

                    if (!seguridad.EsCliente(aux))
                    {
                        if (ddlEstadoIncidencia.SelectedIndex == 2 || ddlEstadoIncidencia.SelectedIndex == 5)
                        {
                            txtComentarioIncidencia.Enabled = true;
                            if (seguridad.verificadorNullVacioEnBlanco(txtComentarioIncidencia.Text))
                            {
                                lblComentarioObligatorio.Text = "*";
                                lblComentarioObligatorio.ForeColor = seguridad.escalasDeColores("");
                                lblValidadorObligatorio.Text = "Es obligatorio rellenar los campos marcados";
                                lblValidadorObligatorio.ForeColor = seguridad.escalasDeColores("");

                                btnAgregar.Enabled = false;
                            }
                            else if (seguridad.verificadorMaximoCaracteres(txtComentarioIncidencia.Text))
                            {
                                lblComentarioObligatorio.Text = " (La cantidad de caracteres no puede superar los 300)";
                                lblComentarioObligatorio.ForeColor = seguridad.escalasDeColores("");
                                lblValidadorObligatorio.Text = "";

                                btnAgregar.Enabled = false;
                            }
                            else
                            {
                                lblComentarioObligatorio.Text = "";
                                lblValidadorObligatorio.Text = "";

                                btnAgregar.Enabled = true;
                            }
                        }
                        else
                        {
                            lblComentarioObligatorio.Text = "";
                            lblValidadorObligatorio.Text = "";
                            txtComentarioIncidencia.Text = "";
                            txtComentarioIncidencia.Enabled = false;
                            btnAgregar.Enabled = true;
                        }
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
                    if (seguridad.EsCliente(Session["usuario"]))
                    {
                        Response.Redirect("Principal.aspx", false);
                    }
                    else
                    {
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

    }
}