using accesoDatos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
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
                datos.setearConsulta("SELECT U.ID, U.IDTipoUsuario, TU.TipoUsuario, U.Nombre, U.Apellido, U.Email FROM USUARIO U, TIPO_USUARIO TU WHERE U.IDTipoUsuario = TU.ID ORDER BY U.IDTipoUsuario DESC;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.ID = (int)datos.Lector["Id"];
                    aux.tipoUsuario = new TipoUsuario();
                    aux.tipoUsuario.Id = (int)datos.Lector["IDTipoUsuario"];
                    aux.tipoUsuario.Descripcion = (string)datos.Lector["TipoUsuario"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
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

        public List<Usuario> listarEspecifico(int tipoUsuario) // Agregue el 3, para listar todos los que no sean clientes
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                switch (tipoUsuario)
                {
                    case 1:
                        datos.setearConsulta("SELECT U.ID, U.IDTipoUsuario, TU.TipoUsuario, U.Nombre + ' ' + U.Apellido AS NombreCompleto, U.Email FROM USUARIO U, TIPO_USUARIO TU WHERE U.IDTipoUsuario = TU.ID AND U.IDTipoUsuario = 1 ORDER BY U.IDTipoUsuario DESC;");
                        break;
                    case 2:
                        datos.setearConsulta("SELECT U.ID, U.IDTipoUsuario, TU.TipoUsuario, U.Nombre + ' ' + U.Apellido AS NombreCompleto, U.Email FROM USUARIO U, TIPO_USUARIO TU WHERE U.IDTipoUsuario = TU.ID AND U.IDTipoUsuario = 2 ORDER BY U.IDTipoUsuario DESC;");
                        break;
                    case 3:
                        datos.setearConsulta("SELECT U.ID, U.IDTipoUsuario, TU.TipoUsuario, U.Nombre + ' ' + U.Apellido AS NombreCompleto, U.Email FROM USUARIO U, TIPO_USUARIO TU WHERE U.IDTipoUsuario = TU.ID AND U.IDTipoUsuario > 1 ORDER BY U.IDTipoUsuario DESC;");
                        break;
                }

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.ID = (int)datos.Lector["Id"];
                    aux.tipoUsuario = new TipoUsuario();
                    aux.tipoUsuario.Id = (int)datos.Lector["IDTipoUsuario"];
                    aux.tipoUsuario.Descripcion = (string)datos.Lector["TipoUsuario"];
                    aux.Nombre = (string)datos.Lector["NombreCompleto"];
                    aux.Email = (string)datos.Lector["Email"];
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
                datos.setearConsulta("SELECT U.ID, U.IDTipoUsuario, TU.TipoUsuario, U.Nombre, U.Apellido, U.Email FROM USUARIO U, TIPO_USUARIO TU WHERE @Email = U.Email AND @Pass = U.Pass AND U.IDTipoUsuario = TU.ID");
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Pass", usuario.Pass);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    usuario.ID = (int)datos.Lector["ID"];
                    usuario.tipoUsuario = new TipoUsuario();
                    usuario.tipoUsuario.Descripcion = (string)datos.Lector["TipoUsuario"];
                    usuario.tipoUsuario.Id = (int)datos.Lector["IDTipoUsuario"];
                    usuario.Nombre = (string)datos.Lector["Nombre"];
                    usuario.Apellido = (string)datos.Lector["Apellido"];
                    usuario.Email = (string)datos.Lector["Email"];
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Registrarse(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("EXEC RegistrarUsuario @Nombre, @Apellido, @Email, @Pass");
                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Apellido", usuario.Apellido);
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Pass", usuario.Pass);
                return datos.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public Usuario BuscarUsuario(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuario usuario = new Usuario();
            try
            {

                datos.setearConsulta("EXEC BUSCAR_USUARIO @ID");
                datos.setearParametro("@ID", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    usuario.ID = id;
                    usuario.tipoUsuario = new TipoUsuario();
                    usuario.tipoUsuario.Id = (int)datos.Lector["IDTipoUsuario"];
                    usuario.Nombre = (string)datos.Lector["Nombre"];
                    usuario.Apellido = (string)datos.Lector["Apellido"];
                    usuario.Email = (string)datos.Lector["Email"];
                    usuario.Pass = (string)datos.Lector["Pass"];
                }

                return usuario;
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
        
        public int VerificarIncidenciasTelefonista(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuario usuario = new Usuario();
            try
            {

                datos.setearConsulta("SELECT DBO.TELEFONISTA_SIN_INCIDENCIAS (@ID)");
                datos.setearParametro("@ID", id);

                return datos.ejecutarAccionScalar();
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
        
        public void ModificarUsuario(Usuario modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsulta("EXEC MODIFICAR_USUARIO @ID, @ID_TIPO_USUARIO, @NOMBRE, @APELLIDO, @EMAIL, @PASS");
                datos.setearParametro("@ID", modificar.ID);
                datos.setearParametro("@ID_TIPO_USUARIO", modificar.tipoUsuario.Id);
                datos.setearParametro("@NOMBRE", modificar.Nombre);
                datos.setearParametro("@APELLIDO", modificar.Apellido);
                datos.setearParametro("@EMAIL", modificar.Email);
                datos.setearParametro("@PASS", modificar.Pass);
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
    } 
}
