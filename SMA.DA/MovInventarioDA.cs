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
    public static class MovInventarioDA
    {
        public static void Crear(cMovInventario Movimiento)
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
                    Cmd.Parameters.AddWithValue("Fecha", Movimiento.Fecha);
                    Cmd.Parameters.AddWithValue("ConceptoID", Movimiento.ConceptoID);
                    Cmd.Parameters.AddWithValue("Cantidad", Movimiento.Cantidad);
                    Cmd.Parameters.AddWithValue("Costo", Movimiento.Costo);
                    Cmd.Parameters.AddWithValue("DocumentoID", Movimiento.DocumentoID);
                   // Cmd.Parameters.AddWithValue("Estatus", Movimiento.Estatus);
                    Cmd.Parameters.AddWithValue("InventarioID", Movimiento.InventarioID);
                    Cmd.Parameters.AddWithValue("Notas", Movimiento.Notas);
                    Cmd.Parameters.AddWithValue("Precio", Movimiento.Precio);
                    Cmd.Parameters.AddWithValue("ModificarPrecio", Movimiento.ModificarPrecio);
                    Cmd.Parameters.AddWithValue("CliPv", Movimiento.CliPv);
                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static void Actualizar(cMovInventario Movimiento)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspActualizarMovimiento";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("ConceptoID", Movimiento.ID);
                    Cmd.Parameters.AddWithValue("Notas", Movimiento.Notas);

                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static cMovInventario BuscarPorID(Int64 ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarMovInventarioPorID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("MovimientoID", ID);
                    SqlDataReader Reader = Cmd.ExecuteReader();

                    cMovInventario Movimiento = new cMovInventario();
                    while (Reader.Read())
                    {
                        Movimiento.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Movimiento.Cantidad = Reader.GetDecimal(Reader.GetOrdinal("Cantidad"));
                        Movimiento.ConceptoID = Reader.GetInt32(Reader.GetOrdinal("ConceptoID"));
                        Movimiento.Costo = Reader.GetDecimal(Reader.GetOrdinal("Costo"));
                        Movimiento.DocumentoID = Reader.IsDBNull(Reader.GetOrdinal("DocumentoID")) ? 0 : Reader.GetInt64(Reader.GetOrdinal("DocumentoID"));
                        Movimiento.Estatus = Reader.GetInt32(Reader.GetOrdinal("Estatus"));
                        Movimiento.Fecha = Reader.GetDateTime(Reader.GetOrdinal("Fecha"));
                        Movimiento.InventarioID = Reader.GetInt64(Reader.GetOrdinal("InventarioID"));
                        Movimiento.Notas = Reader.GetString(Reader.GetOrdinal("Notas"));
                        Movimiento.Precio = Reader.GetDecimal(Reader.GetOrdinal("Precio"));
                    }
                    Conn.Close();
                    return Movimiento;
                }
            }
            catch (SqlException Ex)
            {
                return null;
                throw Ex;
                

            }
        }

        public static List<cMovInventario> Listar(Int64 ID)
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarMovInventario";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("ID", ID);

                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cMovInventario> Lista = new List<cMovInventario>();
                    while (Reader.Read())
                    {
                        cMovInventario Movimiento = new cMovInventario();

                        Movimiento.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Movimiento.Fecha = Reader.GetDateTime(Reader.GetOrdinal("Fecha"));
                        Movimiento.ConceptoID = Reader.GetString(Reader.GetOrdinal("ConceptoID"));
                        Movimiento.Cantidad = Reader.GetDecimal(Reader.GetOrdinal("Cantidad"));
                        //Movimiento.InventarioID = Reader.GetString(Reader.GetOrdinal("DescripcionArticulo"));
                        Movimiento.DocumentoID = Reader.IsDBNull(Reader.GetOrdinal("DocumentoID"))? 0 : Reader.GetInt64(Reader.GetOrdinal("DocumentoID"));
                        Movimiento.Precio = Reader.IsDBNull(Reader.GetOrdinal("Precio")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Precio"));
                        Movimiento.Costo = Reader.GetDecimal(Reader.GetOrdinal("Costo"));
                        Movimiento.Balance = Reader.IsDBNull(Reader.GetOrdinal("Balance")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Balance"));

                      
                        //Agregamos el articulo a la lista
                        Lista.Add(Movimiento);
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

        public static Boolean Existe(Int64 ID)
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

        public static List<cReporteMovimientoInventario> ReporteMovimientoInventario(String CodigoDesde, String CodigoHasta,
                                                                                     DateTime? FechaDesde, DateTime? FechaHasta,
                                                                                     Int64? DocumentoDesde, Int64? DocumentoHasta, 
                                                                                     Int32? Familia, String Movimiento, String Cliente, 
                                                                                     String Proveedor)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspReporteMovimientoInventario";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("CodigoDesde", CodigoDesde);
                    Cmd.Parameters.AddWithValue("CodigoHasta", CodigoHasta);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    Cmd.Parameters.AddWithValue("DocumentoDesde", DocumentoDesde);
                    Cmd.Parameters.AddWithValue("DocumentoHasta", DocumentoHasta);
                    Cmd.Parameters.AddWithValue("Familia", Familia);
                    Cmd.Parameters.AddWithValue("Movimiento", Movimiento);
                    Cmd.Parameters.AddWithValue("NombreProveedor", Proveedor);
                    Cmd.Parameters.AddWithValue("NombreCliente", Cliente);
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteMovimientoInventario> Lista = new List<cReporteMovimientoInventario>();
                    while (Reader.Read())
                    {
                        cReporteMovimientoInventario Resultado = new cReporteMovimientoInventario();

                        Resultado.Fecha = Reader.GetDateTime(Reader.GetOrdinal("Fecha"));
                        Resultado.CodigoArticulo = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));
                        Resultado.DescripcionArticulo = Reader.GetString(Reader.GetOrdinal("DescripcionArticulo"));
                        Resultado.DescripcionConcepto = Reader.GetString(Reader.GetOrdinal("DescripcionConcepto"));
                        Resultado.ClienteProveedor = Reader.IsDBNull(Reader.GetOrdinal("ClienteProveedor"))? "N/A":Reader.GetString(Reader.GetOrdinal("ClienteProveedor"));
                        Resultado.Documento = Reader.IsDBNull(Reader.GetOrdinal("DocumentoID")) ? "N/A" : Reader.GetString(Reader.GetOrdinal("DocumentoID"));
                        Resultado.Cantidad = Reader.GetDecimal(Reader.GetOrdinal("Cantidad"));
                        Resultado.CostoUnitario = Reader.IsDBNull(Reader.GetOrdinal("Costo")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Costo"));
                        Resultado.CostoTotal = Resultado.CostoUnitario * Resultado.Cantidad;
                        Resultado.PrecioUnitario = Reader.IsDBNull(Reader.GetOrdinal("Precio")) ? 0: Reader.GetDecimal(Reader.GetOrdinal("Precio"));
                        Resultado.PrecioTotal = Resultado.PrecioUnitario * Resultado.Cantidad;
                        Resultado.FechaDesde = FechaDesde;
                        Resultado.FechaHasta = FechaHasta;
                        Resultado.DocumentoDesde = DocumentoDesde;
                        Resultado.DocumentoHasta = DocumentoHasta;
                        Resultado.CodigoDesde = CodigoDesde;
                        Resultado.CodigoHasta = CodigoHasta;
                        //Agregamos el articulo a la lista
                        Lista.Add(Resultado);
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

        public static List<cReporteKardexInventario> ReporteKardexInventario(String CodigoDesde, String CodigoHasta, Int32? Familia)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspReporteKardex";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("CodigoDesde", CodigoDesde);
                    Cmd.Parameters.AddWithValue("CodigoHasta", CodigoHasta);
                    Cmd.Parameters.AddWithValue("Familia", Familia);

                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteKardexInventario> Lista = new List<cReporteKardexInventario>();
                    while (Reader.Read())
                    {
                        cReporteKardexInventario Resultado = new cReporteKardexInventario();

                        Resultado.Fecha = Reader.GetDateTime(Reader.GetOrdinal("Fecha"));
                        Resultado.CodigoArticulo = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));
                        Resultado.DescripcionArticulo = Reader.GetString(Reader.GetOrdinal("DescripcionArticulo"));
                        Resultado.DescripcionConcepto = Reader.GetString(Reader.GetOrdinal("DescripcionConcepto"));
                        Resultado.Documento = Reader.IsDBNull(Reader.GetOrdinal("Documento")) ? "N/A" : Reader.GetString(Reader.GetOrdinal("Documento"));
                        Resultado.Entrada = Reader.GetDecimal(Reader.GetOrdinal("Entrada"));
                        Resultado.Salida = Reader.GetDecimal(Reader.GetOrdinal("Salida"));
                        Resultado.Costo = Reader.GetDecimal(Reader.GetOrdinal("Costo"));
                        Resultado.Precio = Reader.IsDBNull(Reader.GetOrdinal("Precio"))? 0:Reader.GetDecimal(Reader.GetOrdinal("Precio"));
                        Resultado.Balance = Reader.GetDecimal(Reader.GetOrdinal("Balance"));
                        Resultado.SaldoInicial = Reader.GetDecimal(Reader.GetOrdinal("SaldoInicial"));
                        Resultado.FechaUltCompra = Reader.IsDBNull(Reader.GetOrdinal("FechaUltCompra")) ? null : Reader.GetString(Reader.GetOrdinal("FechaUltCompra"));
                        Resultado.StockMax = Reader.IsDBNull(Reader.GetOrdinal("StockMax")) ? 0 : Reader.GetInt32(Reader.GetOrdinal("StockMax"));
                        Resultado.StockMin = Reader.IsDBNull(Reader.GetOrdinal("StockMin")) ? 0 : Reader.GetInt32(Reader.GetOrdinal("StockMin"));
                        Resultado.Existencia = Reader.IsDBNull(Reader.GetOrdinal("Existencia")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Existencia"));
                        //Agregamos el articulo a la lista
                        Lista.Add(Resultado);
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

        public static List<cReporteRotacionInventario> ReporteRotacionInventario(String CodigoDesde, String CodigoHasta,
                                                                                     DateTime? FechaDesde, DateTime? FechaHasta, 
                                                                                     Int64? DocumentoDesde, Int64? DocumentoHasta, 
                                                                                     Int32? Familia, String Movimiento)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspRotacionInventario";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("CodigoDesde", CodigoDesde);
                    Cmd.Parameters.AddWithValue("CodigoHasta", CodigoHasta);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    Cmd.Parameters.AddWithValue("DocumentoDesde", DocumentoDesde);
                    Cmd.Parameters.AddWithValue("DocumentoHasta", DocumentoHasta);
                    Cmd.Parameters.AddWithValue("Familia", Familia);
                    Cmd.Parameters.AddWithValue("Movimiento", Movimiento);

                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteRotacionInventario> Lista = new List<cReporteRotacionInventario>();
                    while (Reader.Read())
                    {
                        cReporteRotacionInventario Resultado = new cReporteRotacionInventario();

                        
                        Resultado.CodigoArticulo = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));
                        Resultado.DescripcionArticulo = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Resultado.Cantidad = Reader.GetDecimal(Reader.GetOrdinal("Cantidad"));
                        Resultado.Existencia = Reader.GetDecimal(Reader.GetOrdinal("Existencia"));
                        Resultado.StockMax = Reader.GetInt32(Reader.GetOrdinal("StockMax"));
                        Resultado.Movimientos = Reader.GetString(Reader.GetOrdinal("Conceptos"));
                        //Agregamos el articulo a la lista
                        Lista.Add(Resultado);
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

        public static List<cReporteUtilidadVentas> ReporteUtilidadVentas(String CodigoDesde, String CodigoHasta,
                                                                                     DateTime? FechaDesde, DateTime? FechaHasta,
                                                                                     Int64? DocumentoDesde, Int64? DocumentoHasta, 
                                                                                     Int32? Familia, String Movimiento)

        {
         try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspReporteVentasUtilidad";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("CodigoDesde", CodigoDesde);
                    Cmd.Parameters.AddWithValue("CodigoHasta", CodigoHasta);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    Cmd.Parameters.AddWithValue("DocumentoDesde", DocumentoDesde);
                    Cmd.Parameters.AddWithValue("DocumentoHasta", DocumentoHasta);
                    Cmd.Parameters.AddWithValue("Familia", Familia);
                    Cmd.Parameters.AddWithValue("Movimiento", Movimiento);

                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteUtilidadVentas> Lista = new List<cReporteUtilidadVentas>();
                    while (Reader.Read())
                    {
                        cReporteUtilidadVentas Resultado = new cReporteUtilidadVentas();

                        
                        Resultado.CodigoArticulo = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));
                        Resultado.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Resultado.Cantidad = Reader.GetDouble(Reader.GetOrdinal("Cantidad"));
                        Resultado.PrecioTotal = Reader.GetDouble(Reader.GetOrdinal("PrecioTotal"));
                        Resultado.CostoTotal = Reader.GetDouble(Reader.GetOrdinal("CostoTotal"));
                        Resultado.Movimientos = Reader.GetString(Reader.GetOrdinal("ConceptoMov"));
                        Resultado.Utilidad = Resultado.PrecioTotal - Resultado.CostoTotal;
                        Resultado.PorcientoUtilidad = (Resultado.Utilidad / Resultado.CostoTotal);
                        Resultado.Margen = (Resultado.Utilidad / Resultado.PrecioTotal) * 100;
                        //Agregamos el articulo a la lista
                        Lista.Add(Resultado);
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

        public static List<cReporteVentasPorCliente> ReporteVentasPorCliente(String CodigoDesde, String CodigoHasta,
                                                                                     DateTime? FechaDesde, DateTime? FechaHasta,
                                                                                     Int64? DocumentoDesde, Int64? DocumentoHasta,
                                                                                     Int32? Familia, String Movimiento, Int64? ClienteDesde,
                                                                                     Int64? ClienteHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspReporteVentasPorCliente";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("CodigoDesde", CodigoDesde);
                    Cmd.Parameters.AddWithValue("CodigoHasta", CodigoHasta);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    Cmd.Parameters.AddWithValue("DocumentoDesde", DocumentoDesde);
                    Cmd.Parameters.AddWithValue("DocumentoHasta", DocumentoHasta);
                    Cmd.Parameters.AddWithValue("Familia", Familia);
                    Cmd.Parameters.AddWithValue("Movimiento", Movimiento);
                    Cmd.Parameters.AddWithValue("ClienteDesde", ClienteDesde);
                    Cmd.Parameters.AddWithValue("ClienteHasta", ClienteHasta);
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteVentasPorCliente> Lista = new List<cReporteVentasPorCliente>();
                    while (Reader.Read())
                    {
                        cReporteVentasPorCliente Resultado = new cReporteVentasPorCliente();


                        Resultado.CodigoArticulo = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));
                        Resultado.DescripcionArticulo = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Resultado.Cantidad = Reader.GetDouble(Reader.GetOrdinal("Cantidad"));
                        Resultado.NombreComercial = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Resultado.PrecioTotal = Reader.GetDouble(Reader.GetOrdinal("PrecioTotal"));
                        Resultado.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Resultado.Unidad = Reader.GetString(Reader.GetOrdinal("Unidad"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Resultado);
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

        public static List<cReporteVentasPorClienteDetalle> ReporteVentasPorClienteDetalle(String CodigoDesde, String CodigoHasta,
                                                                                    DateTime? FechaDesde, DateTime? FechaHasta,
                                                                                    Int64? DocumentoDesde, Int64? DocumentoHasta,
                                                                                    Int32? Familia, String Movimiento, Int64? ClienteDesde,
                                                                                    Int64? ClienteHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspReporteVentasPorClienteDetallado";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("CodigoDesde", CodigoDesde);
                    Cmd.Parameters.AddWithValue("CodigoHasta", CodigoHasta);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    Cmd.Parameters.AddWithValue("DocumentoDesde", DocumentoDesde);
                    Cmd.Parameters.AddWithValue("DocumentoHasta", DocumentoHasta);
                    Cmd.Parameters.AddWithValue("Familia", Familia);
                    Cmd.Parameters.AddWithValue("Movimiento", Movimiento);
                    Cmd.Parameters.AddWithValue("ClienteDesde", ClienteDesde);
                    Cmd.Parameters.AddWithValue("ClienteHasta", ClienteHasta);
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteVentasPorClienteDetalle> Lista = new List<cReporteVentasPorClienteDetalle>();
                    while (Reader.Read())
                    {
                        cReporteVentasPorClienteDetalle Resultado = new cReporteVentasPorClienteDetalle();


                        Resultado.CodigoArticulo = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));
                        Resultado.DescripcionArticulo = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Resultado.Cantidad = Reader.GetDouble(Reader.GetOrdinal("Cantidad"));
                        Resultado.NombreComercial = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Resultado.PrecioTotal = Reader.GetDouble(Reader.GetOrdinal("PrecioTotal"));
                        Resultado.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Resultado.Unidad = Reader.GetString(Reader.GetOrdinal("Unidad"));
                        Resultado.DocumentoID = Reader.GetInt64(Reader.GetOrdinal("DocumentoID"));
                        Resultado.Fecha = Reader.GetDateTime(Reader.GetOrdinal("Fecha"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Resultado);
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

        public static List<cReporteVentasPorCliente> ReporteComprasPorProveedor(String CodigoDesde, String CodigoHasta,
                                                                                    DateTime? FechaDesde, DateTime? FechaHasta,
                                                                                    Int64? DocumentoDesde, Int64? DocumentoHasta,
                                                                                    Int32? Familia, String Movimiento, Int64? ProveedorDesde,
                                                                                    Int64? ProveedorHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspReporteComprasPorProveedor";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("CodigoDesde", CodigoDesde);
                    Cmd.Parameters.AddWithValue("CodigoHasta", CodigoHasta);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    Cmd.Parameters.AddWithValue("DocumentoDesde", DocumentoDesde);
                    Cmd.Parameters.AddWithValue("DocumentoHasta", DocumentoHasta);
                    Cmd.Parameters.AddWithValue("Familia", Familia);
                    Cmd.Parameters.AddWithValue("Movimiento", Movimiento);
                    Cmd.Parameters.AddWithValue("ProveedorDesde", ProveedorDesde);
                    Cmd.Parameters.AddWithValue("ProveedorHasta", ProveedorHasta);
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteVentasPorCliente> Lista = new List<cReporteVentasPorCliente>();
                    while (Reader.Read())
                    {
                        cReporteVentasPorCliente Resultado = new cReporteVentasPorCliente();


                        Resultado.CodigoArticulo = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));
                        Resultado.DescripcionArticulo = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Resultado.Cantidad = Reader.GetDouble(Reader.GetOrdinal("Cantidad"));
                        Resultado.NombreComercial = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Resultado.PrecioTotal = Reader.GetDouble(Reader.GetOrdinal("CostoTotal"));
                        Resultado.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Resultado.Unidad = Reader.GetString(Reader.GetOrdinal("Unidad"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Resultado);
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

        public static List<cReporteVentasPorClienteDetalle> ReporteComprasPorProveedorDetalle(String CodigoDesde, String CodigoHasta,
                                                                            DateTime? FechaDesde, DateTime? FechaHasta,
                                                                            Int64? DocumentoDesde, Int64? DocumentoHasta,
                                                                            Int32? Familia, String Movimiento, Int64? ProveedorDesde,
                                                                            Int64? ProveedorHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspReporteComprasPorProveedorDetallado";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("CodigoDesde", CodigoDesde);
                    Cmd.Parameters.AddWithValue("CodigoHasta", CodigoHasta);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    Cmd.Parameters.AddWithValue("DocumentoDesde", DocumentoDesde);
                    Cmd.Parameters.AddWithValue("DocumentoHasta", DocumentoHasta);
                    Cmd.Parameters.AddWithValue("Familia", Familia);
                    Cmd.Parameters.AddWithValue("Movimiento", Movimiento);
                    Cmd.Parameters.AddWithValue("ProveedorDesde", ProveedorDesde);
                    Cmd.Parameters.AddWithValue("ProveedorHasta", ProveedorHasta);
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteVentasPorClienteDetalle> Lista = new List<cReporteVentasPorClienteDetalle>();
                    while (Reader.Read())
                    {
                        cReporteVentasPorClienteDetalle Resultado = new cReporteVentasPorClienteDetalle();


                        Resultado.CodigoArticulo = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));
                        Resultado.DescripcionArticulo = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Resultado.Cantidad = Reader.GetDouble(Reader.GetOrdinal("Cantidad"));
                        Resultado.NombreComercial = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Resultado.PrecioTotal = Reader.GetDouble(Reader.GetOrdinal("CostoTotal"));
                        Resultado.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Resultado.Unidad = Reader.GetString(Reader.GetOrdinal("Unidad"));
                        Resultado.DocumentoID = Reader.GetInt64(Reader.GetOrdinal("DocumentoID"));
                        Resultado.Fecha = Reader.GetDateTime(Reader.GetOrdinal("Fecha"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Resultado);
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

        public static List<cReporteHistoricoExistencia> ReporteHistoricoExistencias(String CodigoDesde, String CodigoHasta,
                                                                            DateTime? FechaDesde, DateTime? FechaHasta,
                                                                            Int32? Familia, String Movimiento)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspReporteHistoricoExistencia";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("CodigoDesde", CodigoDesde);
                    Cmd.Parameters.AddWithValue("CodigoHasta", CodigoHasta);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    Cmd.Parameters.AddWithValue("Familia", Familia);
                    Cmd.Parameters.AddWithValue("Movimiento", Movimiento);
                    
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteHistoricoExistencia> Lista = new List<cReporteHistoricoExistencia>();
                    while (Reader.Read())
                    {
                        cReporteHistoricoExistencia Resultado = new cReporteHistoricoExistencia();

                        Resultado.InventarioID = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));
                        Resultado.DescripcionArticulo = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Resultado.ConceptoID = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Resultado.Cantidad = Reader.GetDecimal(Reader.GetOrdinal("Cantidad"));
                        Resultado.Balance = Reader.GetDecimal(Reader.GetOrdinal("Balance"));
                        Resultado.DocumentoID = Reader.IsDBNull(Reader.GetOrdinal("DocumentoID"))? "N/A" :Reader.GetValue(Reader.GetOrdinal("DocumentoID"));
                        Resultado.Fecha = Reader.GetDateTime(Reader.GetOrdinal("Fecha"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Resultado);
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


        public static List<cInventario> ReporteProductosObsoletos(Int32? Familia, Int32? Marca, DateTime Fecha)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspReporteProductosObsoletos";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("Familia", Familia);
                    Cmd.Parameters.AddWithValue("Marca", Marca);
                    Cmd.Parameters.AddWithValue("Fecha", Fecha);
                    
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cInventario> Lista = new List<cInventario>();
                    while (Reader.Read())
                    {
                        cInventario Resultado = new cInventario();

                        Resultado.CodigoArticulo = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));
                        Resultado.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Resultado.Existencia = Reader.GetDecimal(Reader.GetOrdinal("Existencia"));
                        Resultado.FechaUltVenta = Reader.GetDateTime(Reader.GetOrdinal("Fecha"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Resultado);
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
