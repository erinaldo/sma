using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using System.Data.SqlClient;


namespace SMA.DA
{
    public static class ParametroNCFDA
    {
        public static cParametroNCF BuscarPorID(int ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarParametroNCFporID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("ParametroID", ID);
                    SqlDataReader Reader = Cmd.ExecuteReader();

                    cParametroNCF Parametro = new cParametroNCF();
                    while (Reader.Read())
                    {
                        Parametro.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Parametro.NumeroInicial = Reader.GetString(Reader.GetOrdinal("NumeroInicial"));
                        Parametro.Cantidad = Reader.GetInt32(Reader.GetOrdinal("Cantidad"));
                        Parametro.Estatus = Reader.GetBoolean(Reader.GetOrdinal("Estatus"));
                        Parametro.ComprobanteID = Reader.GetInt32(Reader.GetOrdinal("ComprobanteID"));
                        Parametro.UltimoNumero = Reader.GetString(Reader.GetOrdinal("UltimoNumero"));
                        Parametro.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Parametro.FechaModificacion = Reader.GetDateTime(Reader.GetOrdinal("FechaModificacion"));
                    }
                    Conn.Close();
                    return Parametro;
                }
            }
            catch (SqlException Ex)
            {
                return null;
                throw Ex;

            }
        }


        public static List<cParametroNCF> Listar(Int32 ID)
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarComprobantesNCF";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametro
                    Cmd.Parameters.AddWithValue("TipoComprobante", ID);

                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cParametroNCF> Lista = new List<cParametroNCF>();
                    while (Reader.Read())
                    {
                        cParametroNCF Parametro = new cParametroNCF();
                        Parametro.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Parametro.NumeroInicial = Reader.GetString(Reader.GetOrdinal("NumeroInicial"));
                        Parametro.Cantidad = Reader.GetInt32(Reader.GetOrdinal("Cantidad"));
                        Parametro.Contador = Reader.GetInt32(Reader.GetOrdinal("Contador"));
                        Parametro.UltimoNumero = Reader.GetString(Reader.GetOrdinal("UltimoNumero"));
                        Parametro.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Parametro.FechaModificacion = Reader.GetDateTime(Reader.GetOrdinal("FechaModificacion"));
                        Parametro.Estatus = Reader.GetString(Reader.GetOrdinal("Estatus"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Parametro);
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

        public static void Crear(cParametroNCF Parametro)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarParametroNCF";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("NumeroInicial", Parametro.NumeroInicial);
                    Cmd.Parameters.AddWithValue("Cantidad", Parametro.Cantidad);
                    Cmd.Parameters.AddWithValue("Contador", Parametro.Contador);
                    Cmd.Parameters.AddWithValue("Estatus", Parametro.Estatus);
                    Cmd.Parameters.AddWithValue("ComprobanteID", Parametro.ComprobanteID);
                    Cmd.Parameters.AddWithValue("UltimoNumero", Parametro.UltimoNumero);
                    Cmd.Parameters.AddWithValue("FechaCreacion", Parametro.FechaCreacion);
                    Cmd.Parameters.AddWithValue("FechaModificacion", Parametro.FechaModificacion);

                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }
        public static void Actualizar(cParametroNCF Parametro)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspActualizarParametroNCF";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("ParametroID", Parametro.ID);
                    Cmd.Parameters.AddWithValue("NumeroInicial", Parametro.NumeroInicial);
                    Cmd.Parameters.AddWithValue("Cantidad", Parametro.Cantidad);
                    Cmd.Parameters.AddWithValue("Contador", Parametro.Contador);
                    Cmd.Parameters.AddWithValue("Estatus", Parametro.Estatus);
                    Cmd.Parameters.AddWithValue("ComprobanteID", Parametro.ComprobanteID);
                    Cmd.Parameters.AddWithValue("UltimoNumero", Parametro.UltimoNumero);
                    Cmd.Parameters.AddWithValue("FechaCreacion", Parametro.FechaCreacion);
                    Cmd.Parameters.AddWithValue("FechaModificacion", Parametro.FechaModificacion);

                    Cmd.ExecuteNonQuery();
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

        public static Boolean Disponibilidad(int ComprobanteID)
        {
            try
            {
                //Verifica si existe un parametro del tipo de comprobante seleccionado disponible
                List<cParametroNCF> Resultado = (from c in Listar(ComprobanteID)
                                                 where (String)c.Estatus == "Activo"
                                                 select c).ToList();
                if (Resultado.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(SqlException Ex)
            {
                throw Ex;
            }
            
        }

    }
}
