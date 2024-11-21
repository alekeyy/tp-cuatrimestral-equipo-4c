using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

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
                return "Debil";
            }else
            {
                switch (palabra.Length)
                {
                    case 6:
                        return "Basica";
                    case 7:
                        return "Decente";
                    case 8:
                        return "Media";
                    case 9:
                        return "Fuerte";
                    default:
                        return "Excelente";
                }
            }
        }
    }
}
