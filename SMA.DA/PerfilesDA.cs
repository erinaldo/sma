using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace SMA.DA
{
   public static class PerfilesDA
    {
        public static void Crear(cPerfil Perfil)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarPerfUsr";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros

                    //Cmd.Parameters.AddWithValue("CodigoPerfil", Perfil.CodigoPerfil);
                    Cmd.Parameters.AddWithValue("p_Descripcion", Perfil.Descripcion);
                    //Cmd.Parameters.AddWithValue("Estatus", Perfil.Estatus);
                    Cmd.Parameters.AddWithValue("p_Notas", Perfil.Notas);
                    
                    Cmd.ExecuteNonQuery();
                }


            }
            catch (MySqlException Ex)
            {
                throw Ex;
            }
        }

        public static cPerfil BuscarPorID(int ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarPerfUsrPorCodigo";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("p_Codigo", ID);
                    MySqlDataReader Reader = Cmd.ExecuteReader();

                    cPerfil Perfil = new cPerfil();
                    while (Reader.Read())
                    {
                        Perfil.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                        //Perfil.CodigoPerfil = Reader.GetString(Reader.GetOrdinal("CodigoPerfil"));
                        Perfil.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Perfil.Notas = Reader.IsDBNull(Reader.GetOrdinal("Notas"))? null: Reader.GetString(Reader.GetOrdinal("Notas"));
                    }
                    Conn.Close();
                    return Perfil;
                }
            }
            catch (MySqlException Ex)
            {
                
                throw Ex;

            }
        }

        public static Boolean Existe(int ID)
        {
            //Buscamos si un perfil existe en la base de datos
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

        public static void Actualizar(cPerfil Perfil)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspActualizarPerfUsr";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("p_Codigo", Perfil.Codigo);
                   // Cmd.Parameters.AddWithValue("CodigoPerfil", Perfil.CodigoPerfil);
                    Cmd.Parameters.AddWithValue("p_Descripcion", Perfil.Descripcion);
                    Cmd.Parameters.AddWithValue("p_Notas", Perfil.Notas);
                    //Cmd.Parameters.AddWithValue("Estatus", Perfil.Estatus);
                    
                    // Cmd.Parameters.AddWithValue("FechaModificacion", DateTime.Now.Date);

                    Cmd.ExecuteNonQuery();
                }


            }
            catch (MySqlException Ex)
            {
                throw Ex;
            }
        }

        public static List<cPerfil> Listar()
        {
            //LISTADO DE PERFILES DE USUARIOS
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarPerfUsr";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecutamos el lector 
                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cPerfil> Lista = new List<cPerfil>();
                    while (Reader.Read())
                    {
                        cPerfil Perfil = new cPerfil();
                        Perfil.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                        //Perfil.Estatus = Reader.GetBoolean(Reader.GetOrdinal("Estatus"));
                        //Perfil.CodigoPerfil = Reader.GetString(Reader.GetOrdinal("CodigoPerfil"));
                        Perfil.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Perfil.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Perfil.FechaModificacion = Reader.GetDateTime(Reader.GetOrdinal("FechaModificado"));
                        Perfil.Notas = Reader.IsDBNull(Reader.GetOrdinal("Notas"))? null: Reader.GetString(Reader.GetOrdinal("Notas"));
                        //Agregamos el articulo a la lista
                        Lista.Add(Perfil);
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

       public static void Eliminar(Int16 Codigo)
        {
           try
           {

               //Declaramos la conexion hacia la base de datos
               using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspEliminarPerfUsr";
                   //Creamos el command para la insercion
                   MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;

                   //Parametros
                   Cmd.Parameters.AddWithValue("p_Codigo", Codigo);

                   Cmd.ExecuteNonQuery();
               }
           }
           catch(MySqlException Ex)
           {
               throw Ex;
           }
        }

        


    }
}
