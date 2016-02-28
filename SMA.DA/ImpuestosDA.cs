using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using System.Data.SqlClient;

namespace SMA.DA
{
    public static class ImpuestosDA
    {
        public static List<cImpuesto> Listar()
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarImpuestos";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cImpuesto> Lista = new List<cImpuesto>();
                    while (Reader.Read())
                    {
                        cImpuesto Impuesto = new cImpuesto();
                        Impuesto.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Impuesto.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Impuesto.Valor = Reader.GetDecimal(Reader.GetOrdinal("Valor"));
                        Impuesto.Notas = Reader.IsDBNull(Reader.GetOrdinal("Notas"))? null: Reader.GetString(Reader.GetOrdinal("Notas"));


                        //Agregamos el articulo a la lista
                        Lista.Add(Impuesto);
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

        public static cImpuesto BuscarPorID(Int32 ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarImpuestoPorID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("ImpuestoID", ID);
                    SqlDataReader Reader = Cmd.ExecuteReader();

                    cImpuesto Impuesto = new cImpuesto();
                    while (Reader.Read())
                    {
                        Impuesto.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Impuesto.Notas = Reader.IsDBNull(Reader.GetOrdinal("Notas"))? null:  Reader.GetString(Reader.GetOrdinal("Notas"));
                        Impuesto.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Impuesto.Valor = Reader.GetDecimal(Reader.GetOrdinal("Valor"));

                    }
                    Conn.Close();
                    return Impuesto;
                }
            }
            catch (SqlException Ex)
            {
                return null;
                throw Ex;
            }
        }
    }
}
