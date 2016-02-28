using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using System.Data.SqlClient;

namespace SMA.DA
{
   public static class PerfilesDA
    {
        public static void Crear(cPerfiles Perfil)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarPerfil";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros

                    Cmd.Parameters.AddWithValue("CodigoPerfil", Perfil.CodigoPerfil);
                    Cmd.Parameters.AddWithValue("Descripcion", Perfil.Descripcion);
                    //Cmd.Parameters.AddWithValue("Estatus", Perfil.Estatus);
                    Cmd.Parameters.AddWithValue("Notas", Perfil.Notas);
                    
                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static cPerfiles BuscarPorID(int ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarPerfilPorID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("ID", ID);
                    SqlDataReader Reader = Cmd.ExecuteReader();

                    cPerfiles Perfil = new cPerfiles();
                    while (Reader.Read())
                    {
                        Perfil.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Perfil.CodigoPerfil = Reader.GetString(Reader.GetOrdinal("CodigoPerfil"));
                        Perfil.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Perfil.Notas = Reader.IsDBNull(Reader.GetOrdinal("Notas"))? null: Reader.GetString(Reader.GetOrdinal("Notas"));
                    }
                    Conn.Close();
                    return Perfil;
                }
            }
            catch (SqlException Ex)
            {
                
                throw Ex;

            }
        }

        public static Boolean Existe(int ID)
        {
            //Buscamos si un perfil existe en la base de datos
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

        public static void Actualizar(cPerfiles Perfil)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspActualizarPerfil";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("ID", Perfil.ID);
                    Cmd.Parameters.AddWithValue("CodigoPerfil", Perfil.CodigoPerfil);
                    Cmd.Parameters.AddWithValue("Descripcion", Perfil.Descripcion);
                    Cmd.Parameters.AddWithValue("Notas", Perfil.Notas);
                    //Cmd.Parameters.AddWithValue("Estatus", Perfil.Estatus);
                    
                    // Cmd.Parameters.AddWithValue("FechaModificacion", DateTime.Now.Date);

                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static List<cPerfiles> Listar()
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarPerfiles";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cPerfiles> Lista = new List<cPerfiles>();
                    while (Reader.Read())
                    {
                        cPerfiles Perfil = new cPerfiles();
                        Perfil.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        //Perfil.Estatus = Reader.GetBoolean(Reader.GetOrdinal("Estatus"));
                        Perfil.CodigoPerfil = Reader.GetString(Reader.GetOrdinal("CodigoPerfil"));
                        Perfil.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
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
                    string StoreProc = "uspEliminarRelacionUsuarioPerfil";
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


    }
}
