﻿using accesoDatos;
using Dominio;
using System;

namespace Negocio
{
    public class IncidenciaNegocio
    {
        public Incidencia buscarIncidencia(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            Incidencia incidencia = new Incidencia();
            try
            {

                datos.setearConsulta("EXEC PR_BUSCAR_INCIDENCIA @ID");
                datos.setearParametro("@ID", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    incidencia.IDIncidencia = id;
                    incidencia.IDTipoIncidencia = (object)datos.Lector["IDTipoIncidencia"] == (object)DBNull.Value ? 1 : (int)datos.Lector["IDTipoIncidencia"];
                    incidencia.IDPrioridadIncidencia = (object)datos.Lector["IDPrioridadIncidencia"] == (object)DBNull.Value ? 1 : (int)datos.Lector["IDPrioridadIncidencia"];
                    incidencia.IDEstado = (object)datos.Lector["IDEstado"] == (object)DBNull.Value ? 1 : (int)datos.Lector["IDEstado"];
                }

                return incidencia;
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
