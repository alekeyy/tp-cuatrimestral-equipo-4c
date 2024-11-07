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
                if(usuario.TipoUsuario == "ADMINISTRADOR")
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
                if (usuario.TipoUsuario == "TELEFONISTA")
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
                if (usuario.TipoUsuario == "SUPERVISOR")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
