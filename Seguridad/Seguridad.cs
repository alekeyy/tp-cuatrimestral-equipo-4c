using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;
using System.Drawing;
using accesoDatos;
using System.Runtime.Remoting.Messaging;
using System.Runtime.InteropServices;

namespace Seguridad
{
    public class seguridad
    {
        public static bool SessionActiva(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            if (usuario != null && usuario.ID != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool EsAdmin(Object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            if (usuario != null)
            {
                if(usuario.tipoUsuario.Descripcion == "ADMINISTRADOR")
                {
                    return true;
                }
            }
            return false;
        }
        public static bool EsTelefonista(Object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            if (usuario != null)
            {
                if (usuario.tipoUsuario.Descripcion == "TELEFONISTA")
                {
                    return true;
                }
            }
            return false;
        }
        public static bool EsSupervisor(Object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            if (usuario != null)
            {
                if (usuario.tipoUsuario.Descripcion == "SUPERVISOR")
                {
                    return true;
                }
            }
            return false;
        }

        public static bool EsCliente(Object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            if (usuario != null)
            {
                if (usuario.tipoUsuario.Descripcion == "CLIENTE")
                {
                    return true;
                }
            }
            return false;
        }

        public static bool verificadorNullVacioEnBlanco(string palabra)
        {
            if (string.IsNullOrEmpty(palabra) || string.IsNullOrWhiteSpace(palabra))
                return true;
            return false;
        }

        public static bool verificadorFormatoEmail(string palabra)
        {
            if (palabra.Length < 7 || !palabra.Contains("@"))
                return true;
            return false;
        }

        public static string verificadorFortalezaContraseña(string palabra)
        {
            if (palabra.Length <= 5)
            {
                return "Debil!";
            }else
            {
                switch (palabra.Length)
                {
                    case 6:
                        return "Basica!";
                    case 7:
                        return "Decente!";
                    case 8:
                        return "Media!";
                    case 9:
                        return "Fuerte!";
                    default:
                        return "Excelente!";
                }
            }
        }

        public static Color escalasDeColores(string palabra)
        {
            if (palabra.Length <= 5)
            {
                return Color.Red;
            }
            else
            {
                switch (palabra.Length)
                {
                    case 6:
                        return Color.OrangeRed;
                    case 7:
                        return Color.YellowGreen;
                    case 8:
                        return  Color.YellowGreen;
                    case 9:
                        return  Color.Green;
                    default:
                        return  Color.Green;
                }
            }
        }

        public static bool validacionEmailRegistrado(string palabra)
        {
            AccesoDatos datos = new AccesoDatos();
            int cantidad = 0;
            datos.setearConsulta("SELECT COUNT(Email) AS REGISTRADO FROM USUARIO WHERE Email = @EMAIL");
            datos.setearParametro("@EMAIL", (object)palabra ?? DBNull.Value);
            datos.ejecutarLectura();

            if (datos.Lector.Read())
            {
                cantidad = (int)datos.Lector["REGISTRADO"];
            }

            if(cantidad != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool verificadorMaximoCaracteres(string palabra)
        {
            if (palabra.Length > 300)
            {
                return true;
            }
            return false;
        }
    }
}
