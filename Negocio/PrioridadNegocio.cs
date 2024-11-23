using accesoDatos;
using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class PrioridadNegocio
    {
        public List<Prioridad> listar()
        {
            List<Prioridad> lista = new List<Prioridad>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Descripcion FROM PRIORIDAD_INCIDENCIA");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Prioridad aux = new Prioridad();
                    aux.Id = (int)datos.Lector["Id"];
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
