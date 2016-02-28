using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using System.Data.SqlClient;


namespace SMA.DA
{
   public static class UsuarioDA
    {
       public static void Crear(cUsuario Usuario)
       {
           try
           {

               //Declaramos la conexion hacia la base de datos
               using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspInsertarUsuario";
                   //Creamos el command para la insercion
                   SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;

                   //Parametros
                   Cmd.Parameters.AddWithValue("Nombre", Usuario.Nombre);
                   Cmd.Parameters.AddWithValue("Telefono", Usuario.Telefono);
                   Cmd.Parameters.AddWithValue("LoginUsuario", Usuario.LoginUsuario);
                   Cmd.Parameters.AddWithValue("PassUsuario", Usuario.PassUsuario);
                   Cmd.Parameters.AddWithValue("Estatus", Usuario.Estatus);
                   Cmd.Parameters.AddWithValue("ResetPassOnLogin", Usuario.ResetPassOnLogin);
                   Cmd.Parameters.AddWithValue("FechaCreacion", DateTime.Now.Date);
                   Cmd.Parameters.AddWithValue("FechaModificacion", DateTime.Now.Date);
                   Cmd.ExecuteNonQuery();
               }


           }
           catch (SqlException Ex)
           {
               throw Ex;
           }
       }

       public static cUsuario BuscarPorID(int ID)
       {
           try
           {
               //Declaramos la conexion hacia la base de datos
               using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspBuscarUsuarioPorID";
                   //Creamos el command para la insercion
                   SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;
                   //Parametros
                   Cmd.Parameters.AddWithValue("ID", ID);
                   SqlDataReader Reader = Cmd.ExecuteReader();

                   cUsuario Usuario = new cUsuario();
                   while (Reader.Read())
                   {
                       Usuario.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                       Usuario.Nombre = Reader.GetString(Reader.GetOrdinal("Nombre"));
                       Usuario.Telefono = Reader.GetString(Reader.GetOrdinal("Telefono"));
                       Usuario.PassUsuario = Reader.GetString(Reader.GetOrdinal("PassUsuario"));
                       Usuario.LoginUsuario = Reader.GetString(Reader.GetOrdinal("LoginUsuario"));
                       Usuario.Estatus = Reader.GetBoolean(Reader.GetOrdinal("Estatus"));
                       Usuario.ResetPassOnLogin = Reader.IsDBNull(Reader.GetOrdinal("ResetPassOnLogin")) ? false : Reader.GetBoolean(Reader.GetOrdinal("ResetPassOnLogin"));
                       Usuario.FechaUltimoLogin = Reader.IsDBNull(Reader.GetOrdinal("FechaUltimoLogin")) ? "" : Reader.GetValue(Reader.GetOrdinal("FechaUltimoLogin"));
                       Usuario.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                       Usuario.FechaModificacion = Reader.GetDateTime(Reader.GetOrdinal("FechaModificacion"));
                   }
                   Conn.Close();
                   return Usuario;
               }
           }
           catch (SqlException Ex)
           {
               
               throw Ex;

           }
       }

       public static Boolean Existe(int ID)
       {
           //Buscamos si un Articulo existe en la base de datos
           int result;
           string Valor = BuscarPorID(ID).ID.ToString();
           if (Valor != "0")
           {
               return int.TryParse(Valor, out result);
           }
           else
           {
               return false;
           }
       }

       public static void Actualizar(cUsuario Usuario)
       {
           try
           {

               //Declaramos la conexion hacia la base de datos
               using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspActualizarUsuario";
                   //Creamos el command para la insercion
                   SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;

                   //Parametros
                   Cmd.Parameters.AddWithValue("ID", Usuario.ID);
                   Cmd.Parameters.AddWithValue("Nombre", Usuario.Nombre);
                   Cmd.Parameters.AddWithValue("Telefono", Usuario.Telefono);
                   Cmd.Parameters.AddWithValue("LoginUsuario", Usuario.LoginUsuario);
                   Cmd.Parameters.AddWithValue("PassUsuario", Usuario.PassUsuario);
                   Cmd.Parameters.AddWithValue("Estatus", Usuario.Estatus);
                   Cmd.Parameters.AddWithValue("FechaUltimoLogin", Usuario.FechaUltimoLogin);
                   Cmd.Parameters.AddWithValue("ResetPassOnLogin", Usuario.ResetPassOnLogin);
                  // Cmd.Parameters.AddWithValue("FechaModificacion", DateTime.Now.Date);
                   
                   Cmd.ExecuteNonQuery();
               }


           }
           catch (SqlException Ex)
           {
               throw Ex;
           }
       }

       public static List<cUsuario> Listar()
       {

           try
           {
               //Declaramos la conexion hacia la base de datos
               using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspListarUsuarios";
                   //Creamos el command para la insercion
                   SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;
                   //Ejecutamos el lector 
                   SqlDataReader Reader = Cmd.ExecuteReader();


                   List<cUsuario> Lista = new List<cUsuario>();
                   while (Reader.Read())
                   {
                       cUsuario Usuario = new cUsuario();
                       Usuario.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                       Usuario.Nombre = Reader.GetString(Reader.GetOrdinal("Nombre"));
                       Usuario.Telefono = Reader.IsDBNull(Reader.GetOrdinal("Telefono")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono"));
                       Usuario.LoginUsuario = Reader.GetString(Reader.GetOrdinal("LoginUsuario"));
                       Usuario.PassUsuario = Reader.GetString(Reader.GetOrdinal("PassUsuario"));
                       Usuario.Estatus = Reader.GetBoolean(Reader.GetOrdinal("Estatus"));
                       Usuario.FechaUltimoLogin = Reader.IsDBNull(Reader.GetOrdinal("FechaUltimoLogin")) ? "" : Reader.GetValue(Reader.GetOrdinal("FechaUltimoLogin"));
                       Usuario.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                       Usuario.FechaModificacion = Reader.GetDateTime(Reader.GetOrdinal("FechaModificacion"));
                       Usuario.ResetPassOnLogin = Reader.GetBoolean(Reader.GetOrdinal("ResetPassOnLogin"));
                       //Agregamos el articulo a la lista
                       Lista.Add(Usuario);
                   }
                   //Cerramos la conexion
                   Conn.Close();
                   //Retornamos la lista de clientes
                   return Lista;
               }
           }

           catch (SqlException Ex)
           {
               throw Ex;

           }

       }

       public static void Eliminar(Int32 ID)
       {
           try
           {

               //Declaramos la conexion hacia la base de datos
               using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspEliminarUsuario";
                   //Creamos el command para la insercion
                   SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;

                   //Parametros
                   Cmd.Parameters.AddWithValue("ID", ID);
                   
                   Cmd.ExecuteNonQuery();
               }


           }
           catch (SqlException Ex)
           {
               throw Ex;
           }
       }

       public static cUsuario ValidarLogin(String Usuario, String PassWord)
       {
           try
           {
               cUsuario _Usuario=(from c in Listar()
                                where c.LoginUsuario.Equals(Usuario)
                                && c.PassUsuario.Equals(PassWord)
                                      select c).FirstOrDefault();
               return _Usuario;
           }
           catch(SqlException Ex)
           {
               throw Ex;
           }
       }

       public static List<cRolesModulosUsuarios> ListarPermisos(Int32 UsuarioID)
       {

           try
           {
               //Declaramos la conexion hacia la base de datos
               using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspListarPermisosPorUsuarioID";
                   //Creamos el command para la insercion
                   SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;

                   //Parametros
                   Cmd.Parameters.AddWithValue("UsuarioID", UsuarioID);

                   //Ejecutamos el lector 
                   SqlDataReader Reader = Cmd.ExecuteReader();


                   List<cRolesModulosUsuarios> Lista = new List<cRolesModulosUsuarios>();
                   while (Reader.Read())
                   {
                       cRolesModulosUsuarios Permisos = new cRolesModulosUsuarios();
                      
                       Permisos.LoginUsuario = Reader.GetString(Reader.GetOrdinal("LoginUsuario"));
                       Permisos.PassUsuario = Reader.GetString(Reader.GetOrdinal("PassUsuario"));
                       Permisos.Modulo = Reader.GetString(Reader.GetOrdinal("Modulo"));
                       Permisos.Rol = Reader.GetString(Reader.GetOrdinal("Permisos"));
                       Permisos.NombreUsuario = Reader.GetString(Reader.GetOrdinal("Nombre"));

                       //Agregamos el articulo a la lista
                       Lista.Add(Permisos);
                   }
                   //Cerramos la conexion
                   Conn.Close();
                   //Retornamos la lista de clientes
                   return Lista;
               }
           }

           catch (SqlException Ex)
           {
               throw Ex;

           }
       }
    }
}
