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
    public static class MarcaDA
    {
        public static void Crear(cMarca Marca)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarMarca";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("Descripcion", Marca.Descripcion);
                    Cmd.Parameters.AddWithValue("Notas", Marca.Notas);

                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static void Actualizar(cMarca Marca)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspActualizarMarca";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("MarcaID", Marca.Codigo);
                    Cmd.Parameters.AddWithValue("Descripcion", Marca.Descripcion);
                    Cmd.Parameters.AddWithValue("Notas", Marca.Notas);

                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
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
                    string StoreProc = "uspEliminarMarca";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("MarcaID", ID);

                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static cMarca BuscarPorID(int ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarMarcaPorID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("MarcaID", ID);
                    SqlDataReader Reader = Cmd.ExecuteReader();

                    cMarca Marca = new cMarca();
                    while (Reader.Read())
                    {
                        Marca.Codigo = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Marca.Notas = Reader.GetString(Reader.GetOrdinal("Notas"));
                        Marca.Descripcion = Reader.IsDBNull(Reader.GetOrdinal("Notas"))?null:Reader.GetString(Reader.GetOrdinal("Descripcion"));

                    }
                    Conn.Close();
                    return Marca;
                }
            }
            catch (SqlException Ex)
            {
                return null;
                throw Ex;

            }
        }

        public static List<cMarca> Listar()
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarMarca";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cMarca> Lista = new List<cMarca>();
                    while (Reader.Read())
                    {
                        cMarca Marca = new cMarca();
                        Marca.Codigo = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Marca.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Marca.Notas = Reader.IsDBNull(Reader.GetOrdinal("Notas"))?null:Reader.GetString(Reader.GetOrdinal("Notas"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Marca);
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
    }
}
