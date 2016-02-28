using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SMA.Entity;

namespace SMA.DA
{
    public static class FamiliaDA
    {
        public static void Crear(cFamilia Familia)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarFamilia";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    
                    //Parametros
                   Cmd.Parameters.AddWithValue("Descripcion", Familia.Descripcion);
                    Cmd.Parameters.AddWithValue("Notas",Familia.Notas);

                    Cmd.ExecuteNonQuery();
                }


            }
            catch(SqlException Ex)
            {
                throw Ex;
            }
        }

        public static void Actualizar(cFamilia Familia)
        {
             try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspActualizarFamilia";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    
                    //Parametros
                    Cmd.Parameters.AddWithValue("FamiliaID",Familia.ID);
                   Cmd.Parameters.AddWithValue("Descripcion", Familia.Descripcion);
                    Cmd.Parameters.AddWithValue("Notas",Familia.Notas);

                    Cmd.ExecuteNonQuery();
                }


            }
            catch(SqlException Ex)
            {
                throw Ex;
            }
        }

        public static void Eliminar(int ID)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspEliminarFamilia";
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

        public static cFamilia BuscarPorID(int ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarFamiliaPorID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("FamiliaID", ID);
                    SqlDataReader Reader = Cmd.ExecuteReader();

                    cFamilia Familia = new cFamilia();
                    while (Reader.Read())
                    {
                        Familia.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Familia.Notas =Reader.IsDBNull(Reader.GetOrdinal("Notas"))?null: Reader.GetString(Reader.GetOrdinal("Notas"));
                        Familia.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        
                    }
                    Conn.Close();
                    return Familia;
                }
            }
            catch (SqlException Ex)
            {
                return null;
                throw Ex;

            }
        }

        public static List<cFamilia> Listar()
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarFamilia";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cFamilia> Lista = new List<cFamilia>();
                    while (Reader.Read())
                    {
                        cFamilia Familia = new cFamilia();
                        Familia.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Familia.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Familia.Notas = Reader.IsDBNull(Reader.GetOrdinal("Notas"))? null: Reader.GetString(Reader.GetOrdinal("Notas"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Familia);
                    }
                    //Cerramos la conexion
                    Conn.Close();
                    //Retornamos la lista de clientes
                    return Lista;
                }
            }
            catch (SqlException Ex)
            {
                return null;
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
    }
}
