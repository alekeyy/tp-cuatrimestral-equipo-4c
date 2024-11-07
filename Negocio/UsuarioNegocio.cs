using accesoDatos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> listar()
        {
            List<Usuario> lista = new List<Usuario>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT U.ID, TU.TipoUsuario, U.Nombre, U.Apellido FROM USUARIO U, TIPO_USUARIO TU WHERE U.IDTipoUsuario = TU.ID ORDER BY TU.TipoUsuario ASC;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.ID = (int)datos.Lector["Id"];
                    aux.TipoUsuario = (string)datos.Lector["TipoUsuario"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    lista.Add(aux);
                }
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Login(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("sELECT U.ID, TU.TipoUsuario, U.Nombre, U.Apellido FROM USUARIO U, TIPO_USUARIO TU WHERE @Email = U.Email AND @Pass = U.Pass AND U.IDTipoUsuario = TU.ID;");
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Pass", usuario.Pass);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    usuario.ID = (int)datos.Lector["ID"];
                    usuario.TipoUsuario = (string)datos.Lector["TipoUsuario"];
                    usuario.Nombre = (string)datos.Lector["Nombre"];
                    usuario.Apellido = (string)datos.Lector["Apellido"];
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
