using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;

namespace SMA.DA
{
    public static class RelacionUsuarioPerfilesDA
    {
        public static List<cRelacionUsuarioPerfil> Listar(Int32 UsuarioCodigo)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarRelPerfPorUsrCodigo";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("p_CodigoUsr", UsuarioCodigo);

                    //Ejecutamos el lector 
                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cRelacionUsuarioPerfil> Lista = new List<cRelacionUsuarioPerfil>();
                    while (Reader.Read())
                    {
                        cRelacionUsuarioPerfil Relacion = new cRelacionUsuarioPerfil();

                        Relacion.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                        Relacion.UsuarioCodigo = Reader.GetString(Reader.GetOrdinal("Usuario"));
                        Relacion.PerfilCodigo = Reader.GetString(Reader.GetOrdinal("Perfil"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Relacion);
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

        public static List<cRelacionUsuarioPerfil> BuscarPorCodigo(Int32 UsuarioCodigo)
        {
            //BUSCA LA RELACION EXISTENTE ENTRE UN USUARIO Y LOS PERFILES
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarRelUsrPerf";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("p_CodigoUsr", UsuarioCodigo);

                    //Ejecutamos el lector 
                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cRelacionUsuarioPerfil> Lista = new List<cRelacionUsuarioPerfil>();
                    while (Reader.Read())
                    {
                        cRelacionUsuarioPerfil Relacion = new cRelacionUsuarioPerfil();

                        Relacion.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                        Relacion.UsuarioCodigo = Reader.GetInt32(Reader.GetOrdinal("CodigoUsr"));
                        Relacion.PerfilCodigo = Reader.GetInt32(Reader.GetOrdinal("CodigoPerf"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Relacion);
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

        public static void Crear(cRelacionUsuarioPerfil Relacion)
        {
            //INSERTA UNA RELACION ENTRE UN USUARIO Y UN PERFIL
            try
            {
                
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarRelPerfUsr";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("p_CodigoUsr", Relacion.UsuarioCodigo);
                    Cmd.Parameters.AddWithValue("p_CodigoPerf", Relacion.PerfilCodigo);
                    Cmd.ExecuteNonQuery();
                }
             
            }
            catch(MySqlException Ex)
            {
                throw Ex;
            }
           
    
        }

        public static Boolean Existe(Int16 PerfilCodigo,Int32 UsuarioCodigo)
        {
            //VERIFICAMOS SI LA RELACION EXISTE
            List<cRelacionUsuarioPerfil> Relacion = (from c in BuscarPorCodigo(UsuarioCodigo)
                                               where (Int32) c.PerfilCodigo == PerfilCodigo
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
        public static void Eliminar(Int32 Codigo)
        {
            //ELIMINA LA RELACION ENTRE UN PERFIL Y UN USUARIO
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspEliminarRelPerfUsr";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("p_Codigo", Codigo);

                    Cmd.ExecuteNonQuery();
                }


            }
            catch (MySqlException Ex)
            {
                throw Ex;
            }
        }
    }
}
