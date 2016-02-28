using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using System.Data.SqlClient;

namespace SMA.DA
{
    public static class ComprasDA
    {
        public static Int64 Crear(cCompras Compra)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarCompra";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("ProveedorID", Compra.ProveedorID);
                    Cmd.Parameters.AddWithValue("TipoDocumento", Compra.TipoDocumento);
                    Cmd.Parameters.AddWithValue("FechaCreacion", Compra.FechaCreacion);
                    Cmd.Parameters.AddWithValue("FechaVencimiento", Compra.FechaVencimiento);
                    Cmd.Parameters.AddWithValue("DireccionEnvio", Compra.DireccionEnvio);
                    Cmd.Parameters.AddWithValue("Condicion", Compra.CondicionVenta);
                    Cmd.Parameters.AddWithValue("FechaRecepcion", Compra.FechaEnvio);
                    //Cmd.Parameters.AddWithValue("FechaEnvio", Compra.FechaEnvio);
                    Cmd.Parameters.AddWithValue("SubTotal", Compra.SubTotal);
                    Cmd.Parameters.AddWithValue("ImpuestosTotal", Compra.ImpuestosTotal);
                    Cmd.Parameters.AddWithValue("TotalGeneral", Compra.TotalGeneral);
                    Cmd.Parameters.AddWithValue("EstatusID", Compra.EstatusID); //Estatus inicial Original 
                    Cmd.Parameters.AddWithValue("Observacion", Compra.Observacion);
                    Cmd.Parameters.AddWithValue("NCF", Compra.NCF);
                    Cmd.Parameters.AddWithValue("Referencia", Compra.Referencia);
                   

                    Int64 CompraID = Convert.ToInt64(Cmd.ExecuteScalar());
                    //Cerra la conexion
                    Conn.Close();

                    return CompraID;
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }


        public static cCompras BuscarPorID(Int64 ID, String TipoDocumento)
        {
            //Buscamos un documento relacionado a compras por su numero de documento y tipo 
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarCompraPorTipoID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("DocumentoID", ID);
                    Cmd.Parameters.AddWithValue("TipoDocumento", TipoDocumento);

                    SqlDataReader Reader = Cmd.ExecuteReader();

                    cCompras Compra = new cCompras();
                    while (Reader.Read())
                    {
                        Compra.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Compra.DocumentoID = Reader.GetInt64(Reader.GetOrdinal("DocumentoID"));
                        Compra.ProveedorID = Reader.GetInt64(Reader.GetOrdinal("ProveedorID"));
                        Compra.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Compra.FechaEnvio = Reader.GetDateTime(Reader.GetOrdinal("FechaEnvio"));
                        Compra.ImpuestosTotal = Reader.GetDecimal(Reader.GetOrdinal("ImpuestosTotal"));
                        Compra.SubTotal = Reader.GetDecimal(Reader.GetOrdinal("Subtotal"));
                        Compra.TotalGeneral = Reader.GetDecimal(Reader.GetOrdinal("TotalGeneral"));
                        Compra.EstatusID = Reader.IsDBNull(Reader.GetOrdinal("EstatusID")) ? null : Reader.GetString(Reader.GetOrdinal("EstatusID"));
                    }
                    Conn.Close();
                    return Compra;
                }
            }
            catch (SqlException Ex)
            {
                return null;
                throw Ex;

            }
        }

        public static List<cCompras> Listar(String TipoDocumento)
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListaCompras";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("TipoDocumento", TipoDocumento);

                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cCompras> Lista = new List<cCompras>();
                    while (Reader.Read())
                    {
                        cCompras Compra = new cCompras();
                        Compra.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Compra.DocumentoID = Reader.GetInt64(Reader.GetOrdinal("DocumentoID"));
                        Compra.ProveedorID = Reader.GetString(Reader.GetOrdinal("NombreProveedor"));
                        Compra.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Compra.EstatusID = Reader.GetString(Reader.GetOrdinal("Estatus"));
                        Compra.TotalGeneral = Reader.GetDecimal(Reader.GetOrdinal("TotalGeneral"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Compra);
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

        public static cCompras BuscarPorID(Int64 ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarCompraPorID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("FacturaID", ID);
                    SqlDataReader Reader = Cmd.ExecuteReader();

                    cCompras Compra = new cCompras();
                    while (Reader.Read())
                    {
                        Compra.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Compra.DocumentoID = Reader.GetInt64(Reader.GetOrdinal("DocumentoID"));
                        Compra.ProveedorID = Reader.GetInt64(Reader.GetOrdinal("ProveedorID"));
                        Compra.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Compra.FechaEnvio = Reader.GetDateTime(Reader.GetOrdinal("FechaEnvio"));
                        Compra.ImpuestosTotal = Reader.GetDecimal(Reader.GetOrdinal("ImpuestosTotal"));
                        Compra.SubTotal = Reader.GetDecimal(Reader.GetOrdinal("Subtotal"));
                        //Factura.DescuentoTotal = Reader.GetDecimal(Reader.GetOrdinal("DescuentoTotal"));
                        Compra.TotalGeneral = Reader.GetDecimal(Reader.GetOrdinal("TotalGeneral"));
                        Compra.EstatusID = Reader.GetString(Reader.GetOrdinal("EstatusID"));

                    }
                    Conn.Close();
                    return Compra;
                }
            }
            catch (SqlException Ex)
            {

                throw Ex;

            }
        }
        //public static Boolean Existe(int ID)
        //{
        //    //Buscamos si un Articulo existe en la base de datos
        //    int result;
        //    string Valor = BuscarPorID(ID).ID.ToString();
        //    if (Valor != "0")
        //    {
        //        return int.TryParse(Valor, out result);
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public static void Cancelar(Int64 ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspCancelarCompra";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("FacturaID", ID);
                    //Ejecutamos el comando
                    Cmd.ExecuteNonQuery();
                    //Cerra la conexion
                    Conn.Close();
                }
            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static List<cReporteFactura> Reporte(Int64 ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspImpresionCompraPorID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("CompraID", ID);

                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();



                    List<cReporteFactura> Lista = new List<cReporteFactura>();
                    while (Reader.Read())
                    {
                        cReporteFactura Compra = new cReporteFactura();
                        Compra.Cantidad = Reader.GetDecimal(Reader.GetOrdinal("Cantidad"));
                        Compra.Precio = Reader.GetDecimal(Reader.GetOrdinal("Precio"));
                        Compra.ImpuestoValor = Reader.GetDecimal(Reader.GetOrdinal("ImpuestoValor"));
                        Compra.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Compra.CodigoArticulo = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));
                        Compra.NombreCliente = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Compra.RNC = Reader.IsDBNull(Reader.GetOrdinal("RNC")) ? null : Reader.GetString(Reader.GetOrdinal("RNC"));
                        Compra.Direccion = Reader.IsDBNull(Reader.GetOrdinal("Direccion")) ? null : Reader.GetString(Reader.GetOrdinal("Direccion"));
                        Compra.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia")) ? null : Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Compra.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Compra.Telefono = Reader.IsDBNull(Reader.GetOrdinal("Telefono")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Compra.Fax = Reader.IsDBNull(Reader.GetOrdinal("Fax")) ? null : Reader.GetString(Reader.GetOrdinal("Fax"));
                        Compra.ClienteID = Reader.GetInt64(Reader.GetOrdinal("ProveedorID"));
                        Compra.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Compra.SubTotal = Reader.GetDecimal(Reader.GetOrdinal("Subtotal"));
                        Compra.ImpuestosTotal = Reader.GetDecimal(Reader.GetOrdinal("ImpuestosTotal"));
                        //Compra.DescuentoTotal = Reader.GetDecimal(Reader.GetOrdinal("DescuentoTotal"));
                        Compra.TotalGeneral = Reader.GetDecimal(Reader.GetOrdinal("TotalGeneral"));
                        Compra.Observacion = Reader.IsDBNull(Reader.GetOrdinal("Observacion")) ? null : Reader.GetString(Reader.GetOrdinal("Observacion")); 
                        Compra.FacturaID = Reader.GetInt64(Reader.GetOrdinal("CompraID"));
                        //Compra.DireccionEnvio = Reader.IsDBNull(Reader.GetOrdinal("DireccionEnvio")) ? null : Reader.GetString(Reader.GetOrdinal("DireccionEnvio"));
                        Compra.ImporteTotal = Reader.GetDecimal(Reader.GetOrdinal("ImporteTotal"));
                        Compra.NCF = Reader.IsDBNull(Reader.GetOrdinal("NCF")) ? null : Reader.GetString(Reader.GetOrdinal("NCF"));
                        //Compra.TipoComprobante = Reader.IsDBNull(Reader.GetOrdinal("TipoComprobante")) ? null : Reader.GetString(Reader.GetOrdinal("TipoComprobante"));
                        Compra.RazonSocial = Reader.GetString(Reader.GetOrdinal("RazonSocial"));
                        Compra.DireccionEmpresa = Reader.GetString(Reader.GetOrdinal("DireccionEmpresa"));
                        Compra.TelefonoEmpresa = Reader.GetString(Reader.GetOrdinal("TelefonoEmpresa"));
                        Compra.CiudadEmpresa = Reader.GetString(Reader.GetOrdinal("CiudadEmpresa"));
                        Compra.FaxEmpresa = Reader.GetString(Reader.GetOrdinal("FaxEmpresa"));
                        Compra.ProvinciaEmpresa = Reader.GetString(Reader.GetOrdinal("ProvinciaEmpresa"));
                        Compra.RNCEmpresa = Reader.GetString(Reader.GetOrdinal("RNCEmpresa"));
                        Compra.Estatus = Reader.GetString(Reader.GetOrdinal("Estatus"));
                        Compra.FechaVencimiento = Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
                        Compra.DireccionEnvio=Reader.IsDBNull(Reader.GetOrdinal("DireccionEnvio"))?null: Reader.GetString(Reader.GetOrdinal("DireccionEnvio"));
                        //Compra.Vendedor = Reader.GetString(Reader.GetOrdinal("Vendedor"));
                        //Agregamos el articulo a la lista
                        Lista.Add(Compra);
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

        public static List<cCompras> FiltrarRecepcion(String TipoDocumento,
                                           Int64? ProveedorID,
                                           Int64? DocumentoDesde,
                                           Int64? DocumentoHasta,
                                           DateTime? FechaDesde,
                                           DateTime? FechaHasta,
                                           String CriterioCantidad,
                                           Decimal ValorFactura,
                                           Boolean IndGenerada,
                                           Boolean IndCancelada,
                                           Boolean IndDevuelta)
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspFiltroCompra";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    Cmd.Parameters.AddWithValue("TipoDocumento", TipoDocumento);
                    Cmd.Parameters.AddWithValue("ProveedorID", ProveedorID);
                    Cmd.Parameters.AddWithValue("DocumentoDesde", DocumentoDesde);
                    Cmd.Parameters.AddWithValue("DocumentoHasta", DocumentoHasta);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    Cmd.Parameters.AddWithValue("IndGenerada", IndGenerada);
                    Cmd.Parameters.AddWithValue("IndCancelada", IndCancelada);
                    Cmd.Parameters.AddWithValue("IndDevuelta", IndDevuelta);
                    Cmd.Parameters.AddWithValue("CriterioCantidad", CriterioCantidad);
                    Cmd.Parameters.AddWithValue("ValorFactura", ValorFactura);

                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cCompras> Lista = new List<cCompras>();
                    while (Reader.Read())
                    {
                        cCompras Compra = new cCompras();
                        Compra.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Compra.DocumentoID = Reader.GetInt64(Reader.GetOrdinal("DocumentoID"));
                        Compra.ProveedorID = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Compra.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Compra.EstatusID = Reader.GetString(Reader.GetOrdinal("Estatus"));
                        Compra.TotalGeneral = Reader.GetDecimal(Reader.GetOrdinal("TotalGeneral"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Compra);
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


        public static List<cCompras> Filtrar(
                                           String TipoDocumento,
                                           Int64? ProveedorID,
                                           Int64? DocumentoDesde,
                                           Int64? DocumentoHasta,
                                           DateTime? FechaDesde,
                                           DateTime? FechaHasta,
                                           String CriterioCantidad,
                                           Decimal ValorFactura,
                                           Boolean IndGenerada,
                                           Boolean IndCancelada,
                                           Boolean IndRecibida)
        {
            //FILTRO DE ORDENES DE COMPRA

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspFiltrarOrdenCompra";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    Cmd.Parameters.AddWithValue("TipoDocumento", TipoDocumento);
                    Cmd.Parameters.AddWithValue("ProveedorID", ProveedorID);
                    Cmd.Parameters.AddWithValue("DocumentoDesde", DocumentoDesde);
                    Cmd.Parameters.AddWithValue("DocumentoHasta", DocumentoHasta);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    Cmd.Parameters.AddWithValue("IndGenerada", IndGenerada);
                    Cmd.Parameters.AddWithValue("IndCancelada", IndCancelada);
                    Cmd.Parameters.AddWithValue("IndRecibida", IndRecibida);
                    Cmd.Parameters.AddWithValue("CriterioCantidad", CriterioCantidad);
                    Cmd.Parameters.AddWithValue("ValorFactura", ValorFactura);
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cCompras> Lista = new List<cCompras>();
                    while (Reader.Read())
                    {
                        cCompras Compra = new cCompras();
                        Compra.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Compra.DocumentoID = Reader.GetInt64(Reader.GetOrdinal("DocumentoID"));
                        Compra.ProveedorID = Reader.GetString(Reader.GetOrdinal("NombreCliente"));
                        Compra.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Compra.EstatusID = Reader.GetString(Reader.GetOrdinal("Estatus"));
                        Compra.TotalGeneral = Reader.GetDecimal(Reader.GetOrdinal("TotalGeneral"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Compra);
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

        public static List<cCompras> Filtrar(
                                          String TipoDocumento,
                                          Int64? ProveedorID,
                                          Int64? DocumentoDesde,
                                          Int64? DocumentoHasta,
                                          DateTime? FechaDesde,
                                          DateTime? FechaHasta,
                                          String CriterioCantidad,
                                          Decimal ValorFactura,
                                          Boolean IndGenerada,
                                          Boolean IndCancelada)
        {
            //FILTRO DE DEVOLUCIONES EN COMPRAS
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspFiltroDevolucionCompra";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    Cmd.Parameters.AddWithValue("TipoDocumento", TipoDocumento);
                    Cmd.Parameters.AddWithValue("ProveedorID", ProveedorID);
                    Cmd.Parameters.AddWithValue("DocumentoDesde", DocumentoDesde);
                    Cmd.Parameters.AddWithValue("DocumentoHasta", DocumentoHasta);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    Cmd.Parameters.AddWithValue("IndGenerada", IndGenerada);
                    Cmd.Parameters.AddWithValue("IndCancelada", IndCancelada);
                    Cmd.Parameters.AddWithValue("ValorFactura", ValorFactura);
                    Cmd.Parameters.AddWithValue("CriterioCantidad", CriterioCantidad);
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cCompras> Lista = new List<cCompras>();
                    while (Reader.Read())
                    {
                        cCompras Factura = new cCompras();
                        Factura.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Factura.DocumentoID = Reader.GetInt64(Reader.GetOrdinal("DocumentoID"));
                        Factura.ProveedorID = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Factura.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Factura.EstatusID = Reader.GetString(Reader.GetOrdinal("Estatus"));
                        Factura.TotalGeneral = Reader.GetDecimal(Reader.GetOrdinal("TotalGeneral"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Factura);
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

        public static List<cReporteFactura> ResumenNCF(DateTime FechaDesde, DateTime FechaHasta, Int64 ProveedorID)
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspResumenNCFCompras";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    Cmd.Parameters.AddWithValue("ProveedorID",ProveedorID);

                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteFactura> Lista = new List<cReporteFactura>();
                    while (Reader.Read())
                    {
                        cReporteFactura Factura = new cReporteFactura();
                        Factura.FacturaID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Factura.NombreCliente = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Factura.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Factura.RNC = Reader.IsDBNull(Reader.GetOrdinal("RNC")) ? null : Reader.GetString(Reader.GetOrdinal("RNC"));
                        //Factura.EstatusID = Reader.GetString(Reader.GetOrdinal("Estatus"));
                        Factura.TotalGeneral = Reader.GetDecimal(Reader.GetOrdinal("TotalGeneral"));
                        // Factura.DescuentoTotal = Reader.GetDecimal(Reader.GetOrdinal("DescuentoTotal"));
                        Factura.ImpuestosTotal = Reader.GetDecimal(Reader.GetOrdinal("ImpuestosTotal"));
                        //Factura.SubTotal = Reader.GetDecimal(Reader.GetOrdinal("SubTotal"));
                        //Factura.TipoComprobante = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Factura.NCF = Reader.IsDBNull(Reader.GetOrdinal("NCF")) ? null : Reader.GetString(Reader.GetOrdinal("NCF"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Factura);
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
        public static List<cReporteResumenFactura> ResumenCompras(Int64? DocumentoDesde, 
                                                    Int64? DocumentoHasta, 
                                                    Int32? FamiliaID,  
                                                    DateTime? FechaDesde, 
                                                    DateTime? FechaHasta, 
                                                    Int64? ProveedorDesde, 
                                                    Int64? ProveedorHasta, 
                                                    String TipoDocumento)
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspResumenCompras";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    Cmd.Parameters.AddWithValue("ProveedorDesde", ProveedorDesde);
                    Cmd.Parameters.AddWithValue("ProveedorHasta", ProveedorHasta);
                    Cmd.Parameters.AddWithValue("FamiliaID", FamiliaID);
                    Cmd.Parameters.AddWithValue("DocumentoDesde", DocumentoDesde);
                    Cmd.Parameters.AddWithValue("DocumentoHasta", DocumentoHasta);
                    Cmd.Parameters.AddWithValue("TipoDocumento", TipoDocumento);
                    
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteResumenFactura> Lista = new List<cReporteResumenFactura>();
                    while (Reader.Read())
                    {
                        cReporteResumenFactura Factura = new cReporteResumenFactura();
                        Factura.ID = Reader.GetInt64(Reader.GetOrdinal("DocumentoID"));
                        Factura.ClienteID = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Factura.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Factura.EstatusID = Reader.GetString(Reader.GetOrdinal("Estatus"));
                        Factura.TotalGeneral = Reader.GetDecimal(Reader.GetOrdinal("TotalGeneral"));
                        //Factura.DescuentoTotal = Reader.GetDecimal(Reader.GetOrdinal("DescuentoTotal"));
                        Factura.ImpuestosTotal = Reader.GetDecimal(Reader.GetOrdinal("ImpuestosTotal"));
                        Factura.SubTotal = Reader.GetDecimal(Reader.GetOrdinal("SubTotal"));
                        //Factura.Costo = Reader.GetDecimal(Reader.GetOrdinal("Costo"));
                        //Factura.VendedorID = Reader.IsDBNull(Reader.GetOrdinal("NombreVendedor")) ? "" : Reader.GetString(Reader.GetOrdinal("NombreVendedor"));
                        Factura.FechaInicial = Reader.IsDBNull(Reader.GetOrdinal("FechaInicial")) ? "" : Reader.GetValue(Reader.GetOrdinal("FechaInicial"));
                        Factura.FechaFin = Reader.IsDBNull(Reader.GetOrdinal("FechaFin")) ? "" : Reader.GetValue(Reader.GetOrdinal("FechaFin"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Factura);
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

        public static List<cCompras> Listar(String TipoDocumento,DateTime FechaDesde, DateTime FechaHasta)
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListaDocumentoCompra";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("TipoDocumento", TipoDocumento);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);

                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cCompras> Lista = new List<cCompras>();
                    while (Reader.Read())
                    {
                        cCompras Compra = new cCompras();
                        Compra.ID = Reader.GetInt64(Reader.GetOrdinal("ProveedorID"));
                        Compra.ProveedorID = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Compra.NCF=Reader.GetString(Reader.GetOrdinal("RNC"));
                        Compra.ImpuestosTotal = Reader.GetDecimal(Reader.GetOrdinal("Impuesto"));
                        Compra.SubTotal = Reader.GetDecimal(Reader.GetOrdinal("Importe"));
                        Compra.TotalGeneral = Reader.GetDecimal(Reader.GetOrdinal("Total"));
                       

                        //Agregamos el articulo a la lista
                        Lista.Add(Compra);
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

        public static List<cReporteArticulosDevueltos> ReporteArticulosDevueltos(Int64? DocumentoDesde, Int64? DocumentoHasta, DateTime? FechaDesde, DateTime? FechaHasta, Int64? CodigoProveedor, String CodigoArticulo, Int32? Familia)
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspResumenArticulosDevueltosCompras";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    Cmd.Parameters.AddWithValue("DocumentoDesde", DocumentoDesde);
                    Cmd.Parameters.AddWithValue("DocumentoHasta", DocumentoHasta);
                    Cmd.Parameters.AddWithValue("CodigoProveedor", CodigoProveedor);
                    Cmd.Parameters.AddWithValue("CodigoArticulo", CodigoArticulo);
                    Cmd.Parameters.AddWithValue("Familia", Familia);

                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteArticulosDevueltos> Lista = new List<cReporteArticulosDevueltos>();
                    while (Reader.Read())
                    {
                        cReporteArticulosDevueltos Resumen = new cReporteArticulosDevueltos();
                        Resumen.DocumentoID = Reader.GetInt64(Reader.GetOrdinal("DocumentoID"));
                        Resumen.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Resumen.FechaVencimiento = Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
                        Resumen.CodigoArticulo = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));
                        Resumen.DescripcionArticulo = Reader.GetString(Reader.GetOrdinal("DescripcionArticulo"));
                        Resumen.DescripcionFamilia = Reader.GetString(Reader.GetOrdinal("DescripcionFamilia"));
                        Resumen.NombreComercial = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Resumen.CantidadFacturada = Reader.GetDecimal(Reader.GetOrdinal("CantidadFacturada"));
                        Resumen.CantidadDevuelta = Reader.GetDecimal(Reader.GetOrdinal("CantidadDevuelta"));
                        Resumen.FechaInicial = Reader.IsDBNull(Reader.GetOrdinal("FechaInicial")) ? "" : Reader.GetValue(Reader.GetOrdinal("FechaInicial"));
                        Resumen.FechaFin = Reader.IsDBNull(Reader.GetOrdinal("FechaFinal")) ? "" : Reader.GetValue(Reader.GetOrdinal("FechaFinal"));
                        Resumen.DocumentoDesde = Reader.IsDBNull(Reader.GetOrdinal("DocumentoDesde")) ? "" : Reader.GetValue(Reader.GetOrdinal("DocumentoDesde"));
                        Resumen.DocumentoHasta = Reader.IsDBNull(Reader.GetOrdinal("DocumentoHasta")) ? "" : Reader.GetValue(Reader.GetOrdinal("DocumentoHasta"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Resumen);
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
