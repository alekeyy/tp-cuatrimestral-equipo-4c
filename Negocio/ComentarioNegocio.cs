using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using accesoDatos;
using Dominio;

namespace Negocio
{
    public class ComentarioNegocio
    {
        public static List<Comentario> ListarComentarios(int IDIncidencia)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Comentario> comentarios = new List<Comentario>();
            try
            {
                datos.setearConsulta("EXEC PR_BUSCAR_COMENTARIOS @ID_INCIDENCIA");
                datos.setearParametro("@ID_INCIDENCIA", IDIncidencia);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Comentario aux = new Comentario();
                    aux.ID = (object)datos.Lector["ID"] == null ? 0 : (int)datos.Lector["ID"];
                    aux.IDIncidencia = (object)datos.Lector["IDIncidencia"] == null ? 0 : (int)datos.Lector["IDIncidencia"];
                    aux.Comentarios = (object)datos.Lector["Comentario"] == null ? "" : (string)datos.Lector["Comentario"];

                    comentarios.Add(aux);
                }

                return comentarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ContarComentarios(int IDIncidencia)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT DBO.FN_CONTAR_COMENTARIOS (@ID_INCIDENCIA)");
                datos.setearParametro("@ID_INCIDENCIA", IDIncidencia);
                return datos.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
