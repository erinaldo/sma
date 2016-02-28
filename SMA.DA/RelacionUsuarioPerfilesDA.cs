using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using System.Data.SqlClient;

namespace SMA.DA
{
    public static class RelacionUsuarioPerfilesDA
    {
        public static List<cRelacionUsuarioPerfil> Listar(int UsuarioID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarPerfilesPorUsuarioID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("UsuarioID", UsuarioID);

                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cRelacionUsuarioPerfil> Lista = new List<cRelacionUsuarioPerfil>();
                    while (Reader.Read())
                    {
                        cRelacionUsuarioPerfil Relacion = new cRelacionUsuarioPerfil();

                        Relacion.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Relacion.UsuarioID = Reader.GetString(Reader.GetOrdinal("Usuario"));
                        Relacion.PerfilID = Reader.GetString(Reader.GetOrdinal("Perfil"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Relacion);
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

        public static List<cRelacionUsuarioPerfil> BuscarPorID(int UsuarioID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarRelacionUsuarioPerfil";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("UsuarioID", UsuarioID);

                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cRelacionUsuarioPerfil> Lista = new List<cRelacionUsuarioPerfil>();
                    while (Reader.Read())
                    {
                        cRelacionUsuarioPerfil Relacion = new cRelacionUsuarioPerfil();

                        Relacion.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Relacion.UsuarioID = Reader.GetInt32(Reader.GetOrdinal("UsuarioID"));
                        Relacion.PerfilID = Reader.GetInt32(Reader.GetOrdinal("PerfilID"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Relacion);
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

        public static void Crear(cRelacionUsuarioPerfil Relacion)
        {
            try
            {
                
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarRelacionUsuarioPerfil";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("UsuarioID", Relacion.UsuarioID);
                    Cmd.Parameters.AddWithValue("PerfilID", Relacion.PerfilID);
                    Cmd.ExecuteNonQuery();
                }
             
            }
            catch(SqlException Ex)
            {
                throw Ex;
            }
           
    
        }

        public static Boolean Existe(Int32 PerfilID,Int32 UsuarioID)
        {
            //VERIFICAMOS SI LA RELACION EXISTE
            List<cRelacionUsuarioPerfil> Relacion = (from c in BuscarPorID(UsuarioID)
                                               where (Int32) c.PerfilID == PerfilID
                                               select c).ToList();
            if(Relacion.Count>=1)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
