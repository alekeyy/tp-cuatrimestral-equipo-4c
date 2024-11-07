using accesoDatos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioXIncidenciaNegocio
    {
        public List<UsuarioXIncidencia> listar()
        {
            List<UsuarioXIncidencia> lista = new List<UsuarioXIncidencia>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT UI.ID, UI.Nombre, UI.IDIncidencia, UI.IDCliente, UI.IDTelefonista, U.Apellido + ' ' + U.Nombre as Telefonista, UI.Descripcion FROM USUARIOS_X_INCIDENCIA UI, USUARIO U WHERE IDTelefonista = U.ID;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    UsuarioXIncidencia aux = new UsuarioXIncidencia();
                    aux.ID = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.IDIncidencia = (int)datos.Lector["IDIncidencia"];
                    aux.IDCliente = (int)datos.Lector["IDCliente"];
                    aux.IDTelefonista = (int)datos.Lector["IDTelefonista"];
                    aux.Telefonista = (string)datos.Lector["Telefonista"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
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
    }
}
