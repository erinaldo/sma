using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using System.Data.SqlClient;


namespace SMA.DA
{
   public static class DetalleFacturaDA
    {

        public static void Crear(List<cDetalleFactura> ListaDetalle)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarDetalleFactura";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Recorremos la lista
                    foreach (cDetalleFactura Detalle in ListaDetalle)
                    {
                        //Parametros
                        Cmd.Parameters.AddWithValue("FacturaID", Detalle.FacturaID);
                        Cmd.Parameters.AddWithValue("ArticuloID", Detalle.ArticuloID);
                        Cmd.Parameters.AddWithValue("TipoDocumento", Detalle.TipoDocumento);
                        Cmd.Parameters.AddWithValue("Cantidad", Detalle.Cantidad);
                        Cmd.Parameters.AddWithValue("Precio", Detalle.Precio);
                        Cmd.Parameters.AddWithValue("Costo", Detalle.Costo);
                        Cmd.Parameters.AddWithValue("ImpuestosValor", Detalle.ImpuestoValor);
                        Cmd.Parameters.AddWithValue("DescuentoValor", Detalle.DescuentoValor);
                        Cmd.Parameters.AddWithValue("UnidadVentaID", Detalle.UnidadVentaID);
                        Cmd.Parameters.AddWithValue("TipoProducto", Detalle.TipoProducto);
                        Cmd.Parameters.AddWithValue("ValorComision", Detalle.ValorComision);
                        Cmd.Parameters.AddWithValue("ComisionVenta", Detalle.ComisionVenta);
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

       public static List<cDetalleFactura> ListarDetalle(Int64 FacturaID,String TipoDocumento)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarDetalleFacturaPorTipoDocID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("TipoDocumento", TipoDocumento);
                    Cmd.Parameters.AddWithValue("FacturaID",FacturaID); 

                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cDetalleFactura> Lista = new List<cDetalleFactura>();
                    while (Reader.Read())
                    {
                        cDetalleFactura Detalle = new cDetalleFactura();
                        Detalle.ArticuloID = Reader.GetInt64(Reader.GetOrdinal("ArticuloID"));
                        Detalle.Cantidad = Reader.GetDecimal(Reader.GetOrdinal("Cantidad"));
                        Detalle.Precio = Reader.GetDecimal(Reader.GetOrdinal("Precio"));
                        Detalle.Costo = Reader.GetDecimal(Reader.GetOrdinal("Costo"));
                        Detalle.ImpuestoValor = Reader.GetDecimal(Reader.GetOrdinal("ImpuestoValor"));
                        Detalle.DescuentoValor = Reader.GetDecimal(Reader.GetOrdinal("DescuentoValor"));
                        Detalle.UnidadVentaID = Reader.GetInt32(Reader.GetOrdinal("UnidadVentaID"));
                        Detalle.TipoProducto = Reader.GetString(Reader.GetOrdinal("TipoProducto"));
                        Detalle.ComisionVenta = Reader.GetDecimal(Reader.GetOrdinal("ComisionVenta"));
                        Detalle.ValorComision = Reader.GetDecimal(Reader.GetOrdinal("ValorComision"));

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

       public static List<cDetalleFactura> ListarDetalleDevolucion(String CodigoArticulo, Int64 DocumentoID)
       {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarArticuloDevolucion";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("CodigoArticulo",CodigoArticulo);
                    Cmd.Parameters.AddWithValue("DocumentoID",DocumentoID); 

                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cDetalleFactura> Lista = new List<cDetalleFactura>();
                    while (Reader.Read())
                    {
                        cDetalleFactura Detalle = new cDetalleFactura();
                        Detalle.ArticuloID = Reader.GetInt64(Reader.GetOrdinal("ArticuloID"));
                        Detalle.Cantidad = Reader.GetDecimal(Reader.GetOrdinal("Cantidad"));
                        Detalle.Precio = Reader.GetDecimal(Reader.GetOrdinal("Precio"));
                        Detalle.Costo = Reader.GetDecimal(Reader.GetOrdinal("Costo"));
                        Detalle.ImpuestoValor = Reader.GetDecimal(Reader.GetOrdinal("ImpuestoValor"));
                        Detalle.DescuentoValor = Reader.GetDecimal(Reader.GetOrdinal("DescuentoValor"));
                        Detalle.UnidadVentaID = Reader.GetInt32(Reader.GetOrdinal("UnidadVentaID"));
                        Detalle.TipoProducto = Reader.GetString(Reader.GetOrdinal("TipoProducto"));
                        Detalle.ComisionVenta = Reader.GetDecimal(Reader.GetOrdinal("ComisionVenta"));
                        Detalle.ValorComision = Reader.GetDecimal(Reader.GetOrdinal("ValorComision"));

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
