using Dominio;
using Negocio;
using Seguridad;
using System;

namespace expresssolution
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    TipoUsuarioNegocio tipo = new TipoUsuarioNegocio();
                    ddlTipoUsuario.Enabled = true;
                    ddlTipoUsuario.DataSource = tipo.listar();
                    ddlTipoUsuario.DataValueField = "Id";
                    ddlTipoUsuario.DataTextField = "Descripcion";
                    ddlTipoUsuario.DataBind();
                }

                if (Session["Usuario"] != null)
                {
                    Usuario actual = (Usuario)Session["Usuario"];

                    if (seguridad.EsAdmin(actual))
                    {
                        if ((string)Session["PaginaAnterior"] == "Lista de usuarios" || 
                            (string)Session["PaginaAnterior"] == "Modificando" && 
                            (int)actual.ID == (int)Session["IdAModificar"])
                        {
                            UsuarioNegocio negocio = new UsuarioNegocio();
                            Usuario modificar = new Usuario();

                            // se asigna como pagina anterior la pagina actual.
                            Session["PaginaAnterior"] = "Modificando";


                            // se precargan los datos
                            if (!IsPostBack)
                            {
                                // se busca el usuario por id
                                modificar = negocio.BuscarUsuario((int)Session["IdAModificar"]);
                                ddlTipoUsuario.SelectedIndex = modificar.tipoUsuario.Id - 1;
                                ddlTipoUsuario.DataBind();
                                txtNombre.Text = modificar.Nombre;
                                txtApellido.Text = modificar.Apellido;
                                txtEmail.Text = modificar.Email;
                                Session["UsuarioAModificar"] = modificar;
                            }

                            // toca verificar si el usuario modificado es un telefonista
                            // si es se actua, sino se sigue con normalidad.
                            if (ddlTipoUsuario.SelectedIndex == 0)
                            {
                                ddlTipoUsuario.Enabled = false;
                            }

                            if (ddlTipoUsuario.SelectedIndex == (2 - 1))
                            // se pone 2 que es el nivel de telefonista, se le resta uno para transformarlo en indice.
                            {
                                if (negocio.VerificarIncidenciasTelefonista(modificar.ID) > 0)
                                {
                                    lblTelefonistaOcupado.Text = "No se puede cambiar el tipo de usuario a este telefonista, porque todavia cuenta con incidencias asignadas a el. Primero debera concluirlas.";

                                    lblTelefonistaOcupado.ForeColor = System.Drawing.Color.Red;
                                    ddlTipoUsuario.Enabled = false;
                                }
                            }

                        }
                        else
                        {
                            ddlTipoUsuario.Enabled = false;
                            ddlTipoUsuario.SelectedIndex = actual.tipoUsuario.Id - 1;
                            ddlTipoUsuario.DataBind();
                            txtNombre.Text = actual.Nombre;
                            txtApellido.Text = actual.Apellido;
                            txtEmail.Text = actual.Email;


                            Session["UsuarioAModificar"] = actual;
                        }
                    }
                    else
                    {
                        ddlTipoUsuario.Enabled = false;
                        ddlTipoUsuario.SelectedIndex = actual.tipoUsuario.Id - 1;
                        ddlTipoUsuario.DataBind();
                        txtNombre.Text = actual.Nombre;
                        txtApellido.Text = actual.Apellido;
                        txtEmail.Text = actual.Email;


                        Session["UsuarioAModificar"] = actual;
                    }
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
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
            //      
            // si el title en la sessin es Registro, <------ se elimino esta opcion por el formato de registro.
            //      es el admin o el telefonista cargando un usuario...
            // si el title en la session es Registro, pero en la session no hay un usuario activo...
            //      es un cliente tratando de registrarse. <------ se elimino esta opcion por el formato de registro.
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
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario modificar = new Usuario();

                modificar.ID = ((Usuario)Session["UsuarioAModificar"]).ID;
                modificar.tipoUsuario = new TipoUsuario();
                modificar.tipoUsuario.Id = ddlTipoUsuario.SelectedIndex + 1;
                modificar.tipoUsuario.Descripcion = ddlTipoUsuario.SelectedValue;
                modificar.Nombre = txtNombre.Text;
                modificar.Apellido = txtApellido.Text;
                modificar.Email = txtEmail.Text;

                //modificaciones para poder cambiar la contraseña (solo puede cambiarsela el propio usuario, ej no un admin a un cliente)
                if (txtContraNueva.Text == "")
                {
                    modificar.Pass = ((Usuario)Session["UsuarioAModificar"]).Pass;
                }
                else
                {
                    if (negocio.VerificarContraseña(modificar.ID, txtContra.Text))
                    {
                        modificar.Pass = txtContraNueva.Text;
                    }
                    else
                    {
                        Session["Error"] = "La contraseña ingresada no es la correcta"; // esto deberia validarse antes del click
                        Response.Redirect("Error.aspx", false);
                    }
                }
                // puede agregarse el campo para modificar la contraseña solo hay que agregar unas modificaciones en "perfil.aspx" y agregar textbox y label.
                // ya que la sentencia sql carga la pass, simplemente no se permite modificarla.

                negocio.ModificarUsuario(modificar);

                Session["Exito"] = "Datos guardados exitosamente.";
                Response.Redirect("Exito.aspx", false);
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
            finally
            {
                Session["PaginaAnterior"] = "";
                Session["IdAModificar"] = null;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Session["PaginaAnterior"] = "";
                Session["IdAModificar"] = null;
                Response.Redirect("Principal.aspx", false);
            }
            catch (Exception ex)
            {
                Session["PaginaAnterior"] = "";
                Session["IdAModificar"] = null;
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}