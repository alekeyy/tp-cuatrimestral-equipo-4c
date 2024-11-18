using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accesoDatos;
using Dominio;

namespace Negocio
{
    public class IncidenciaNegocio
    {
        public List<Incidencia> listar()
        {
            List<Incidencia> lista = new List<Incidencia>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT ID, IDTipoIncidencia, IDPrioridadIncidencia, IDEstado, Comentarios from Incidencias;");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Incidencia aux = new Incidencia();
                    aux.ID = (int)datos.Lector["ID"];
                    aux.IDTipoIncidencia = (int)datos.Lector["IDTipoIncidencia"];
                    aux.IDPrioridadIncidencia = (int)datos.Lector["IDPrioridadIncidencia"];
                    aux.IDEstado = (int)datos.Lector["IDEstado"];
                    aux.Comentarios = (string)datos.Lector["Comentarios"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch  (Exception ex)
            {
                throw ex;
            }
        }
        public int agregar(Incidencia aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("EXEC SubirIncidencia @Comentario");
                datos.setearParametro("@Comentario", aux.Comentarios);
                return datos.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
