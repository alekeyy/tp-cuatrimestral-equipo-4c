using accesoDatos;
using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class TipoUsuarioNegocio
    {
        public List<TipoUsuario> listar()
        {
            List<TipoUsuario> lista = new List<TipoUsuario>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, TipoUsuario FROM TIPO_USUARIO");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TipoUsuario aux = new TipoUsuario();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["TipoUsuario"];
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
