using Dominio;
using EmailService;
using Negocio;
using Seguridad;
using System;

namespace expresssolution
{
    public partial class Recuperar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnRecuperar.Enabled = false;
            if (IsPostBack)
            {
                if (seguridad.verificadorNullVacioEnBlanco(txtEmail.Text))
                {
                    txtValidacionCorreo.Text = "*";
                    txtValidacionCorreo.ForeColor = seguridad.escalasDeColores("");
                    txtEmail.Text = "";
                }
                else if (seguridad.verificadorFormatoEmail(txtEmail.Text))
                {
                    txtValidacionCorreo.Text = " (Formato correcto -> correo@algo.com <-)";
                    txtValidacionCorreo.ForeColor = seguridad.escalasDeColores("");
                }
                else
                {
                    txtValidacionCorreo.Text = "";
                }

                if (!(seguridad.validacionEmailRegistrado(txtEmail.Text)))
                {
                    txtValidacionCorreo.Text = "No se encuentra registrado este Email.";
                    txtValidacionCorreo.ForeColor = seguridad.escalasDeColores("");
                }

                // check correo
                if (seguridad.validacionEmailRegistrado(txtEmail.Text) && !seguridad.verificadorNullVacioEnBlanco(txtEmail.Text) && !seguridad.verificadorFormatoEmail(txtEmail.Text))
                {
                    txtCamposObligatorios.Text = "";
                    btnRecuperar.Enabled = true;
                }
            }
        }

        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                emailService emailService = new emailService();

                string email = txtEmail.Text;

                Usuario recuperado = negocio.BuscarCorreo(email);
                string passNueva = PassRandom();
                if (!(recuperado.Email is null))
                {

                    emailService.armarCorreo(email, "RECUPERAR CONTRASEÑA", "Estimado " + recuperado.Nombre + " se le ha otorgado la siguiente contraseña para iniciar sesion: " + passNueva + ".");
                    emailService.enviarCorreo();
                    negocio.CambiarContraseña(recuperado.ID, passNueva);
                    Session["Exito"] = "Se ha enviado correctamente el correo para recuperar la contraseña.";
                    Response.Redirect("Exito.aspx", false);
                }

                //label nuevo que diga solicitado con exito
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        public string PassRandom()
        {
            Random random = new Random();
            string letras = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string pass = "";
            for (int i = 0; i < 5; i++)
            {
                pass += (random.Next(10, 500)).ToString();
                pass += letras[random.Next(0, 53)];
            }
            return pass;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Principal.aspx", false);
        }
    }
}