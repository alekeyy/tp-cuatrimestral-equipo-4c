using accesoDatos;
using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class UsuarioXIncidenciaNegocio
    {
        public void cargarIncidencia(UsuarioXIncidencia nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO USUARIOS_X_INCIDENCIA(IDIncidencia, IDCliente, Descripcion) VALUES (@IDIncidencia, @IDCliente, @Descripcion)");

                datos.setearParametro("@IDIncidencia", (object)nueva.IDIncidencia ?? DBNull.Value);
                datos.setearParametro("@IDCliente", (object)nueva.IDCliente ?? DBNull.Value);
                datos.setearParametro("@Descripcion", !string.IsNullOrEmpty(nueva.Descripcion) ? nueva.Descripcion : (object)DBNull.Value);
                datos.ejecutarAccion();
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

        public void actualizarIncidencia(UsuarioXIncidencia nueva, Incidencia actualizacion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("EXEC PR_MODIFICAR_INCIDENCIA @NOMBRE, @IDTELEFONISTA, @DESCRIPCION, @IDINCIDENCIA, @IDTIPOINCIDENCIA, @IDPRIORIDADINCIDENCIA, @IDESTADO, @COMENTARIOS");

                datos.setearParametro("@NOMBRE", !string.IsNullOrEmpty(nueva.Nombre) ? nueva.Nombre : (object)DBNull.Value);
                datos.setearParametro("@IDTELEFONISTA", (object)nueva.IDTelefonista ?? DBNull.Value);
                datos.setearParametro("@DESCRIPCION", !string.IsNullOrEmpty(nueva.Descripcion) ? nueva.Descripcion : (object)DBNull.Value);

                datos.setearParametro("@IDINCIDENCIA", (int)nueva.IDIncidencia == -1 ? (object)DBNull.Value : (int)nueva.IDIncidencia);
                datos.setearParametro("@IDTIPOINCIDENCIA", (object)actualizacion.IDTipoIncidencia ?? DBNull.Value);
                datos.setearParametro("@IDPRIORIDADINCIDENCIA", (object)actualizacion.IDPrioridadIncidencia ?? DBNull.Value);
                datos.setearParametro("@IDESTADO", (object)actualizacion.IDEstado ?? DBNull.Value);
                datos.setearParametro("@COMENTARIOS", !string.IsNullOrEmpty(actualizacion.Comentarios) ? actualizacion.Comentarios : (object)DBNull.Value);
                datos.ejecutarAccion();


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

        public List<UsuarioXIncidencia> listarIncidenciasModificado(int id, int tipoUsuario)
        {
            List<UsuarioXIncidencia> lista = new List<UsuarioXIncidencia>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                switch (tipoUsuario)
                {
                    case 1:
                        datos.setearConsulta("SELECT UI.ID, UI.Nombre, UI.IDIncidencia, UI.IDCliente, UI.IDTelefonista, U.Apellido + ' ' + U.Nombre as Telefonista, UI.Descripcion FROM USUARIO U right join USUARIOS_X_INCIDENCIA AS UI on UI.IDTelefonista = U.ID where UI.IDCliente = " + id);
                        break;
                    case 2:
                        datos.setearConsulta("SELECT UI.ID, UI.Nombre, UI.IDIncidencia, UI.IDCliente, UI.IDTelefonista, U.Apellido + ' ' + U.Nombre as Telefonista, UI.Descripcion FROM USUARIOS_X_INCIDENCIA UI, USUARIO U WHERE UI.IDTelefonista = U.ID AND UI.IDTelefonista = " + id);
                        break;
                    case 3:
                        datos.setearConsulta("SELECT UI.ID, UI.Nombre, UI.IDIncidencia, UI.IDCliente, UI.IDTelefonista, U.Apellido + ' ' + U.Nombre as Telefonista, UI.Descripcion FROM USUARIO U right join USUARIOS_X_INCIDENCIA AS UI on UI.IDTelefonista = U.ID");
                        break;
                    case 4:
                        datos.setearConsulta("SELECT UI.ID, UI.Nombre, UI.IDIncidencia, UI.IDCliente, UI.IDTelefonista, U.Apellido + ' ' + U.Nombre as Telefonista, UI.Descripcion FROM USUARIO U right join USUARIOS_X_INCIDENCIA AS UI on UI.IDTelefonista = U.ID");
                        break;
                }
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    UsuarioXIncidencia aux = new UsuarioXIncidencia();
                    aux.ID = (object)datos.Lector["Id"] == DBNull.Value ? 0 : (int)datos.Lector["Id"];
                    aux.Nombre = (object)datos.Lector["Nombre"] == DBNull.Value ? "------------" : (string)datos.Lector["Nombre"];
                    aux.IDIncidencia = (object)datos.Lector["IDIncidencia"] == DBNull.Value ? 0 : (int)datos.Lector["IDIncidencia"];
                    aux.IDCliente = (object)datos.Lector["IDCliente"] == DBNull.Value ? 0 : (int)datos.Lector["IDCliente"];
                    aux.IDTelefonista = (object)datos.Lector["IDTelefonista"] == DBNull.Value ? 0 : (int)datos.Lector["IDTelefonista"];
                    aux.Telefonista = (object)datos.Lector["Telefonista"] == DBNull.Value ? "------------" : (string)datos.Lector["Telefonista"];
                    aux.Descripcion = (object)datos.Lector["Descripcion"] == DBNull.Value ? "------------" : (string)datos.Lector["Descripcion"];
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

        public UsuarioXIncidencia buscarUsuarioXIncidencia(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            UsuarioXIncidencia usuarioXIncidencia = new UsuarioXIncidencia();
            try
            {

                datos.setearConsulta("EXEC PR_BUSCAR_USUARIO_X_INCIDENCIA @ID");
                datos.setearParametro("@ID", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    usuarioXIncidencia.Nombre = (object)datos.Lector["Nombre"] == (object)DBNull.Value ? "" : (string)datos.Lector["Nombre"];

                    usuarioXIncidencia.IDIncidencia = (object)datos.Lector["IDIncidencia"] == (object)DBNull.Value ? 1 : (int)datos.Lector["IDIncidencia"];

                    usuarioXIncidencia.IDCliente = (object)datos.Lector["IDCliente"] == (object)DBNull.Value ? 1 : (int)datos.Lector["IDCliente"];

                    usuarioXIncidencia.IDTelefonista = (object)datos.Lector["IDTelefonista"] == (object)DBNull.Value ? 1 : (int)datos.Lector["IDTelefonista"];

                    usuarioXIncidencia.Descripcion = (object)datos.Lector["Descripcion"] == (object)DBNull.Value ? "" : (string)datos.Lector["Descripcion"];
                }

                return usuarioXIncidencia;
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
