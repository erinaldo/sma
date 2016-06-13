using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;


namespace SMA.DA
{
   public static class UsuarioDA
    {
       public static void Crear(cUsuario Usuario)
       {
           try
           {

               //Declaramos la conexion hacia la base de datos
               using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspInsertarUsr";
                   //Creamos el command para la insercion
                   MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;

                   //Parametros
                   Cmd.Parameters.AddWithValue("p_Nombre", Usuario.Nombre);
                   Cmd.Parameters.AddWithValue("p_Telefono", Usuario.Telefono);
                   Cmd.Parameters.AddWithValue("p_Login", Usuario.Login);
                   Cmd.Parameters.AddWithValue("p_Pass", Usuario.Pass);
                   Cmd.Parameters.AddWithValue("p_Estatus", Usuario.Estatus);
                   Cmd.Parameters.AddWithValue("p_ResetPassOnLogin", Usuario.ResetPassOnLogin);
                   Cmd.ExecuteNonQuery();
               }


           }
           catch (MySqlException Ex)
           {
               throw Ex;
           }
       }

       public static cUsuario BuscarPorID(int ID)
       {
           try
           {
               //Declaramos la conexion hacia la base de datos
               using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspBuscarUsrPorCodigo";
                   //Creamos el command para la insercion
                   MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;
                   //Parametros
                   Cmd.Parameters.AddWithValue("p_Codigo", ID);
                   MySqlDataReader Reader = Cmd.ExecuteReader();

                   cUsuario Usuario = new cUsuario();
                   while (Reader.Read())
                   {
                       Usuario.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                       Usuario.Nombre = Reader.GetString(Reader.GetOrdinal("Nombre"));
                       Usuario.Telefono = Reader.GetString(Reader.GetOrdinal("Telefono"));
                       Usuario.Pass = Reader.GetString(Reader.GetOrdinal("Pass"));
                       Usuario.Login = Reader.GetString(Reader.GetOrdinal("Login"));
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
           catch (MySqlException Ex)
           {
               
               throw Ex;

           }
       }

       public static Boolean Existe(int ID)
       {
           //Buscamos si un Articulo existe en la base de datos
           int result;
           string Valor = BuscarPorID(ID).Codigo.ToString();
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
               using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspActualizarUsr";
                   //Creamos el command para la insercion
                   MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;

                   //Parametros
                   Cmd.Parameters.AddWithValue("p_Codigo", Usuario.Codigo);
                   Cmd.Parameters.AddWithValue("p_Nombre", Usuario.Nombre);
                   Cmd.Parameters.AddWithValue("p_Telefono", Usuario.Telefono);
                   Cmd.Parameters.AddWithValue("p_Login", Usuario.Login);
                   Cmd.Parameters.AddWithValue("p_Pass", Usuario.Pass);
                   Cmd.Parameters.AddWithValue("p_Estatus", Usuario.Estatus);
                   Cmd.Parameters.AddWithValue("p_FechaUltimoLogin", ObtenerFecha(Usuario.FechaUltimoLogin));
                   Cmd.Parameters.AddWithValue("p_ResetPassOnLogin", Usuario.ResetPassOnLogin);
                   //Cmd.Parameters.AddWithValue("FechaModificacion", DateTime.Now.Date);
                   
                   Cmd.ExecuteNonQuery();
               }


           }
           catch (MySqlException Ex)
           {
               throw Ex;
           }
       }

       private static Nullable<DateTime> ObtenerFecha(object p)
       {
           //FUNCION QUE DEVUELVE LA FECHA DE ULTIMO LOGIN DE EXISTIR
           DateTime Valor;
           if(p!=null && DateTime.TryParse(p.ToString(),out Valor))
           {
               return Convert.ToDateTime(p);
           }
           else
           {
               return null;
           }
       }

       public static List<cUsuario> Listar()
       {

           try
           {
               //Declaramos la conexion hacia la base de datos
               using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspListarUsr";
                   //Creamos el command para la insercion
                   MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;
                   //Ejecutamos el lector 
                   MySqlDataReader Reader = Cmd.ExecuteReader();


                   List<cUsuario> Lista = new List<cUsuario>();
                   while (Reader.Read())
                   {
                       cUsuario Usuario = new cUsuario();
                       Usuario.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                       Usuario.Nombre = Reader.GetString(Reader.GetOrdinal("Nombre"));
                       Usuario.Telefono = Reader.IsDBNull(Reader.GetOrdinal("Telefono")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono"));
                       Usuario.Login = Reader.GetString(Reader.GetOrdinal("Login"));
                       Usuario.Pass = Reader.GetString(Reader.GetOrdinal("Pass"));
                       Usuario.Estatus = Reader.GetBoolean(Reader.GetOrdinal("Estatus"));
                       Usuario.FechaUltimoLogin = Reader.IsDBNull(Reader.GetOrdinal("FechaUltimoLogin")) ? "" : Reader.GetValue(Reader.GetOrdinal("FechaUltimoLogin"));
                       Usuario.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                       //Usuario.FechaModificacion = Reader.GetDateTime(Reader.GetOrdinal("FechaModificacion"));
                       Usuario.ResetPassOnLogin = Reader.IsDBNull(Reader.GetOrdinal("ResetPassOnLogin"))? false: Reader.GetBoolean(Reader.GetOrdinal("ResetPassOnLogin"));;
                       //Agregamos el articulo a la lista
                       Lista.Add(Usuario);
                   }
                   //Cerramos la conexion
                   Conn.Close();
                   //Retornamos la lista de clientes
                   return Lista;
               }
           }

           catch (MySqlException Ex)
           {
               throw Ex;

           }

       }

       public static void Eliminar(Int32 ID)
       {
           try
           {

               //Declaramos la conexion hacia la base de datos
               using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspEliminarUsr";
                   //Creamos el command para la insercion
                   MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;

                   //Parametros
                   Cmd.Parameters.AddWithValue("p_Codigo", ID);
                   
                   Cmd.ExecuteNonQuery();
               }


           }
           catch (MySqlException Ex)
           {
               throw Ex;
           }
       }

       public static cUsuario ValidarLogin(String Usuario, String PassWord)
       {
           try
           {
               cUsuario _Usuario=(from c in Listar()
                                where c.Login.Equals(Usuario)
                                && c.Pass.Equals(PassWord)
                                      select c).FirstOrDefault();
               return _Usuario;
           }
           catch(MySqlException Ex)
           {
               throw Ex;
           }
       }

       public static List<cRolesModulosUsuarios> ListarPermisos(Int32 UsuarioID)
       {

           try
           {
               //Declaramos la conexion hacia la base de datos
               using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspListarPermisosPorCodigoUsr";
                   //Creamos el command para la insercion
                   MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;

                   //Parametros
                   Cmd.Parameters.AddWithValue("p_CodigoUsr", UsuarioID);

                   //Ejecutamos el lector 
                   MySqlDataReader Reader = Cmd.ExecuteReader();


                   List<cRolesModulosUsuarios> Lista = new List<cRolesModulosUsuarios>();
                   while (Reader.Read())
                   {
                       cRolesModulosUsuarios Permisos = new cRolesModulosUsuarios();
                      
                       Permisos.LoginUsuario = Reader.GetString(Reader.GetOrdinal("Login"));
                       Permisos.PassUsuario = Reader.GetString(Reader.GetOrdinal("Pass"));
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

           catch (MySqlException Ex)
           {
               throw Ex;

           }
       }
    }
}
