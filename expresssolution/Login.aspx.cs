using Dominio;
using Negocio;
using Seguridad;
using System;

namespace expresssolution
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (seguridad.verificadorNullVacioEnBlanco(txtEmail.Text))
                {
                    txtCorreoObligatorio.Text = "*";
                    txtCorreoObligatorio.ForeColor = seguridad.escalasDeColores("");
                    txtEmail.Text = "";
                    txtObligatorio.Text = "los campos marcados son obligatorios";
                    txtObligatorio.ForeColor = seguridad.escalasDeColores("");
                }
                else if (seguridad.verificadorFormatoEmail(txtEmail.Text))
                {
                    txtFormatoCorreo.Text = " (formato correcto -> correo@algo.com <-)";
                    txtFormatoCorreo.ForeColor = seguridad.escalasDeColores("");
                    txtCorreoObligatorio.Text = "";
                }
                else
                {
                    txtFormatoCorreo.Text = "";
                    txtCorreoObligatorio.Text = "";
                }

                if (seguridad.verificadorNullVacioEnBlanco(txtPass.Text))
                {
                    txtPassObligatoria.Text = "*";
                    txtPassObligatoria.ForeColor = seguridad.escalasDeColores("");
                    txtPass.Text = "";
                    txtObligatorio.Text = "los campos marcados son obligatorios";
                    txtObligatorio.ForeColor = seguridad.escalasDeColores("");
                }
                else
                {
                    txtPassObligatoria.Text = "";
                }

                if (!seguridad.verificadorNullVacioEnBlanco(txtEmail.Text) && !seguridad.verificadorNullVacioEnBlanco(txtPass.Text))
                {
                    txtObligatorio.Text = "";
                }
            }
            else
            {
                txtObligatorio.Text = "";
            }

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();

            try
            {
                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPass.Text;

                if (negocio.Login(usuario))
                {
                    Session["Usuario"] = usuario;
                    Response.Redirect("Principal.aspx", false);
                }
                else
                {
                    Session["Error"] = "Usuario o contraseña incorrectos";
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
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
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}