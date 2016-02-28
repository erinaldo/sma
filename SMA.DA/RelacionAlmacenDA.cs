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
    public static class RelacionAlmacenDA
    {
        public static void Crear(cRelacionAlmacen Relacion)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarMovInventario";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("AlmacenID", Relacion.AlmacenID);
                    Cmd.Parameters.AddWithValue("Existencia", Relacion.Existencia);
                    Cmd.Parameters.AddWithValue("InventarioID", Relacion.InventarioID);
                    

                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }

        }

        public static List<cRelacionAlmacen> Listar(int InventarioID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarRelacionAlmacen";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("InventarioID", InventarioID);

                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cRelacionAlmacen> Lista = new List<cRelacionAlmacen>();
                    while (Reader.Read())
                    {
                        cRelacionAlmacen Relacion = new cRelacionAlmacen();

                        Relacion.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Relacion.AlmacenID = Reader.GetString(Reader.GetOrdinal("AlmacenID"));
                        Relacion.Existencia = Reader.GetDouble(Reader.GetOrdinal("Existencia"));
                        Relacion.InventarioID = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Relacion);
                    }
                    //Cerramos la conexion
                    Conn.Close();
                    //Retornamos la lista de clientes
                    return Lista;
                }
            }
            catch(SqlException Ex)
            {
                return null;
                throw Ex;
            }
        }

        public static List<cRelacionAlmacen> BuscarPorID(int InventarioID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarRelAlmacenPorID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("InventarioID", InventarioID);

                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cRelacionAlmacen> Lista = new List<cRelacionAlmacen>();
                    while (Reader.Read())
                    {
                        cRelacionAlmacen Relacion = new cRelacionAlmacen();

                        Relacion.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Relacion.AlmacenID = Reader.GetInt32(Reader.GetOrdinal("AlmacenID"));
                        Relacion.Existencia = Reader.GetDouble(Reader.GetOrdinal("Existencia"));
                        Relacion.InventarioID = Reader.GetInt32(Reader.GetOrdinal("InventarioID"));

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
                return null;
                throw Ex;
            }
        }

        public static Decimal ExistenciaAlmacen(Int64 InventarioID, int AlmacenID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "ufnExistenciaAlmacenPorInventarioID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("InventarioID", InventarioID);
                    Cmd.Parameters.AddWithValue("AlmacenID", AlmacenID);

                    SqlParameter ValorRetornado = new SqlParameter("@Resultado", SqlDbType.Float);
                    ValorRetornado.Direction = ParameterDirection.ReturnValue;

                    Cmd.Parameters.Add(ValorRetornado);


                    //Ejecutamos el lector 
                    Cmd.ExecuteNonQuery();

                    Object Resultado = Cmd.Parameters["@Resultado"].Value;

                    Conn.Close();

                    if(DBNull.Value!=Resultado)
                    {
                        return (Decimal)Resultado;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch (SqlException Ex)
            {
                return -1;
                    throw Ex;
            }
        }
    }

}
