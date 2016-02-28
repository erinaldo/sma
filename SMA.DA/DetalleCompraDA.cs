using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using System.Data.SqlClient;


namespace SMA.DA
{
public static    class DetalleCompraDA
    {
    public static void Crear(List<cDetalleCompra> ListaDetalle)
    {
        try
        {

            //Declaramos la conexion hacia la base de datos
            using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
            {
                Conn.Open();
                //Nombre del procedimiento
                string StoreProc = "uspInsertarDetalleCompra";
                //Creamos el command para la insercion
                SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                Cmd.CommandType = CommandType.StoredProcedure;

                //Recorremos la lista
                foreach (cDetalleCompra Detalle in ListaDetalle)
                {
                    //Parametros
                    Cmd.Parameters.AddWithValue("CompraID", Detalle.CompraID);
                    Cmd.Parameters.AddWithValue("ArticuloID", Detalle.ArticuloID);
                    Cmd.Parameters.AddWithValue("Cantidad", Detalle.Cantidad);
                    Cmd.Parameters.AddWithValue("Precio", Detalle.Precio);
                    Cmd.Parameters.AddWithValue("TipoDocumento", Detalle.TipoDocumento);
                    //Cmd.Parameters.AddWithValue("Costo", Detalle.Costo);
                    Cmd.Parameters.AddWithValue("ImpuestosValor", Detalle.ImpuestoValor);
                    //Cmd.Parameters.AddWithValue("DescuentoValor", Detalle.DescuentoValor);
                    Cmd.Parameters.AddWithValue("UnidadCompraID", Detalle.UnidadCompraID);
                    Cmd.Parameters.AddWithValue("TipoProducto", Detalle.TipoProducto);
                    Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                }
            }


        }
        catch (SqlException Ex)
        {
            throw Ex;
        }
    }


    public static List<cDetalleCompra> ListarDetalle(Int64 CompraID, String TipoDocumento)
    {
        try
        {
            //Declaramos la conexion hacia la base de datos
            using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
            {
                Conn.Open();
                //Nombre del procedimiento
                string StoreProc = "uspBuscarDetalleCompraPorTipoDocID";
                //Creamos el command para la insercion
                SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                Cmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                Cmd.Parameters.AddWithValue("TipoDocumento", TipoDocumento);
                Cmd.Parameters.AddWithValue("CompraID", CompraID);

                //Ejecutamos el lector 
                SqlDataReader Reader = Cmd.ExecuteReader();


                List<cDetalleCompra> Lista = new List<cDetalleCompra>();
                while (Reader.Read())
                {
                    cDetalleCompra Detalle = new cDetalleCompra();
                    Detalle.ArticuloID = Reader.GetInt64(Reader.GetOrdinal("ArticuloID"));
                    Detalle.Cantidad = Reader.GetDecimal(Reader.GetOrdinal("Cantidad"));
                    Detalle.Precio = Reader.GetDecimal(Reader.GetOrdinal("Precio"));
                    //Detalle.Costo = Reader.GetDouble(Reader.GetOrdinal("Costo"));
                    Detalle.ImpuestoValor = Reader.GetDecimal(Reader.GetOrdinal("ImpuestoValor"));
                    //Detalle.DescuentoValor = Reader.GetDouble(Reader.GetOrdinal("DescuentoValor"));
                    Detalle.UnidadCompraID = Reader.GetInt32(Reader.GetOrdinal("UnidadCompraID"));
                    Detalle.TipoProducto = Reader.GetString(Reader.GetOrdinal("TipoProducto"));
                    //Detalle.ComisionVenta = Reader.GetDecimal(Reader.GetOrdinal("ComisionVenta"));
                    //Detalle.ValorComision = Reader.GetDouble(Reader.GetOrdinal("ValorComision"));

                    //Agregamos el articulo a la lista
                    Lista.Add(Detalle);
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

    public static List<cDetalleCompra> ListarDetalleDevolucion(String CodigoArticulo, Int64 DocumentoID)
    {
        try
        {
            //Declaramos la conexion hacia la base de datos
            using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
            {
                Conn.Open();
                //Nombre del procedimiento
                string StoreProc = "uspBuscarArticuloDevolucionCompra";
                //Creamos el command para la insercion
                SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                Cmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                Cmd.Parameters.AddWithValue("CodigoArticulo", CodigoArticulo);
                Cmd.Parameters.AddWithValue("DocumentoID", DocumentoID);

                //Ejecutamos el lector 
                SqlDataReader Reader = Cmd.ExecuteReader();


                List<cDetalleCompra> Lista = new List<cDetalleCompra>();
                while (Reader.Read())
                {
                    cDetalleCompra Detalle = new cDetalleCompra();
                    Detalle.ArticuloID = Reader.GetInt64(Reader.GetOrdinal("ArticuloID"));
                    Detalle.Cantidad = Reader.GetDecimal(Reader.GetOrdinal("Cantidad"));
                    Detalle.Precio = Reader.GetDecimal(Reader.GetOrdinal("Precio"));
                    //Detalle.Costo = Reader.GetDecimal(Reader.GetOrdinal("Costo"));
                    Detalle.ImpuestoValor = Reader.GetDecimal(Reader.GetOrdinal("ImpuestoValor"));
                    //Detalle.DescuentoValor = Reader.GetDecimal(Reader.GetOrdinal("DescuentoValor"));
                    Detalle.UnidadCompraID = Reader.GetInt32(Reader.GetOrdinal("UnidadCompraID"));
                    Detalle.TipoProducto = Reader.GetString(Reader.GetOrdinal("TipoProducto"));
                    //Detalle.ComisionVenta = Reader.GetDecimal(Reader.GetOrdinal("ComisionVenta"));
                    //Detalle.ValorComision = Reader.GetDecimal(Reader.GetOrdinal("ValorComision"));

                    //Agregamos el articulo a la lista
                    Lista.Add(Detalle);
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
    }
}
