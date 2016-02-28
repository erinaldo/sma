using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using System.Data.SqlClient;

namespace SMA.DA
{
   public static class FacturaDA
    {
        public static Int64 Crear(cFactura Factura)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarFactura";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("ClienteID", Factura.ClienteID);
                    Cmd.Parameters.AddWithValue("TipoDocumento", Factura.TipoDocumento);
                    Cmd.Parameters.AddWithValue("FechaCreacion", Factura.FechaCreacion);
                    Cmd.Parameters.AddWithValue("FechaEnvio", Factura.FechaEnvio);
                    Cmd.Parameters.AddWithValue("FechaVencimiento", Factura.FechaVencimiento);
                    Cmd.Parameters.AddWithValue("SubTotal", Factura.SubTotal);
                    Cmd.Parameters.AddWithValue("ImpuestosTotal", Factura.ImpuestosTotal);
                    Cmd.Parameters.AddWithValue("CondicionVenta", Factura.CondicionVenta);
                    Cmd.Parameters.AddWithValue("DescuentoTotal", Factura.DescuentoTotal);
                    Cmd.Parameters.AddWithValue("TotalGeneral", Factura.TotalGeneral);
                    Cmd.Parameters.AddWithValue("EstatusID", Factura.EstatusID); //Estatus inicial Original 
                    Cmd.Parameters.AddWithValue("Observacion", Factura.Observacion);
                    Cmd.Parameters.AddWithValue("DireccionEnvio", Factura.DireccionEnvio);
                    Cmd.Parameters.AddWithValue("Referencia", Factura.Referencia);
                    
                    Cmd.Parameters.AddWithValue("VendedorID", Factura.VendedorID);

                    Int64 FacturaID = Convert.ToInt64(Cmd.ExecuteScalar());
                    //Cerra la conexion
                    Conn.Close();

             return FacturaID;
                }

               
            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static cFactura BuscarPorID(Int64 ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarFacturaPorID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("FacturaID", ID);
                    SqlDataReader Reader = Cmd.ExecuteReader();

                    cFactura Factura = new cFactura();
                    while (Reader.Read())
                    {
                        Factura.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Factura.DocumentoID = Reader.GetInt64(Reader.GetOrdinal("DocumentoID"));
                        Factura.ClienteID = Reader.GetInt64(Reader.GetOrdinal("ClienteID"));
                        Factura.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Factura.FechaEnvio = Reader.GetDateTime(Reader.GetOrdinal("FechaEnvio"));
                        Factura.ImpuestosTotal = Reader.GetDecimal(Reader.GetOrdinal("ImpuestosTotal"));
                        Factura.SubTotal = Reader.GetDecimal(Reader.GetOrdinal("Subtotal"));
                        Factura.DescuentoTotal = Reader.GetDecimal(Reader.GetOrdinal("DescuentoTotal"));
                        Factura.TotalGeneral = Reader.GetDecimal(Reader.GetOrdinal("TotalGeneral"));
                        Factura.EstatusID = Reader.GetString(Reader.GetOrdinal("EstatusID"));

                    }
                    Conn.Close();
                    return Factura;
                }
            }
            catch (SqlException Ex)
            {
                
                throw Ex;

            }
        }

        public static cFactura BuscarPorID(Int64 DocumentoID, String TipoDocumento)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarFacturaPorTipoID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("DocumentoID", DocumentoID);
                    Cmd.Parameters.AddWithValue("TipoDocumento", TipoDocumento);
                    SqlDataReader Reader = Cmd.ExecuteReader();

                    cFactura Factura = new cFactura();
                    while (Reader.Read())
                    {
                        Factura.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Factura.ClienteID = Reader.GetInt64(Reader.GetOrdinal("ClienteID"));
                        Factura.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Factura.FechaEnvio = Reader.GetDateTime(Reader.GetOrdinal("FechaEnvio"));
                        Factura.ImpuestosTotal = Reader.GetDecimal(Reader.GetOrdinal("ImpuestosTotal"));
                        Factura.SubTotal = Reader.GetDecimal(Reader.GetOrdinal("Subtotal"));
                        Factura.DescuentoTotal = Reader.GetDecimal(Reader.GetOrdinal("DescuentoTotal"));
                        Factura.TotalGeneral = Reader.GetDecimal(Reader.GetOrdinal("TotalGeneral"));
                        Factura.EstatusID = Reader.GetString(Reader.GetOrdinal("EstatusID"));
                        Factura.VendedorID = Reader.GetInt32(Reader.GetOrdinal("VendedorID"));
                    }
                    Conn.Close();
                    return Factura;
                }
            }
            catch (SqlException Ex)
            {
                
                throw Ex;

            }
        }

        public static List<cFactura> Listar(String TipoDocumento)
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListaFactura";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("TipoDocumento", TipoDocumento);

                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cFactura> Lista = new List<cFactura>();
                    while (Reader.Read())
                    {
                        cFactura Factura = new cFactura();
                        Factura.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Factura.DocumentoID = Reader.GetInt64(Reader.GetOrdinal("DocumentoID"));
                        Factura.ClienteID = Reader.GetString(Reader.GetOrdinal("NombreCliente"));
                        Factura.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Factura.FechaVencimiento = Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
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

        public static void Cancelar(Int64 ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspCancelarFactura";
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
            catch(SqlException Ex)
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
                    string StoreProc = "uspImpresionFacturaPorID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    
                    //Parametros
                    Cmd.Parameters.AddWithValue("FacturaID", ID);

                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();



                    List<cReporteFactura> Lista = new List<cReporteFactura>();
                    while (Reader.Read())
                    {
                        cReporteFactura Factura = new cReporteFactura(); Factura.Cantidad = Reader.GetDecimal(Reader.GetOrdinal("Cantidad"));
                        Factura.Precio = Reader.GetDecimal(Reader.GetOrdinal("Precio"));
                        Factura.CodigoArticulo = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));
                        Factura.ImpuestoValor = Reader.GetDecimal(Reader.GetOrdinal("ImpuestoValor"));
                        Factura.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Factura.NombreCliente = Reader.GetString(Reader.GetOrdinal("NombreCliente"));
                        Factura.RNC = Reader.IsDBNull(Reader.GetOrdinal("RNC")) ? null : Reader.GetString(Reader.GetOrdinal("RNC"));
                        Factura.Direccion = Reader.IsDBNull(Reader.GetOrdinal("Direccion")) ? null : Reader.GetString(Reader.GetOrdinal("Direccion"));
                        Factura.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia")) ? null : Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Factura.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Factura.Telefono = Reader.IsDBNull(Reader.GetOrdinal("Telefono")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Factura.Fax = Reader.IsDBNull(Reader.GetOrdinal("Fax")) ? null : Reader.GetString(Reader.GetOrdinal("Fax"));
                        Factura.ClienteID = Reader.GetInt64(Reader.GetOrdinal("ClienteID"));
                        Factura.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Factura.SubTotal = Reader.GetDecimal(Reader.GetOrdinal("Subtotal"));
                        Factura.ImpuestosTotal = Reader.GetDecimal(Reader.GetOrdinal("ImpuestosTotal"));
                        Factura.DescuentoTotal = Reader.GetDecimal(Reader.GetOrdinal("DescuentoTotal"));
                        Factura.TotalGeneral = Reader.GetDecimal(Reader.GetOrdinal("TotalGeneral"));
                        Factura.Observacion = Reader.GetString(Reader.GetOrdinal("Observacion"));
                        Factura.FacturaID = Reader.GetInt64(Reader.GetOrdinal("FacturaID"));
                        Factura.DireccionEnvio = Reader.IsDBNull(Reader.GetOrdinal("DireccionEnvio")) ? null : Reader.GetString(Reader.GetOrdinal("DireccionEnvio"));
                        Factura.ImporteTotal = Reader.GetDecimal(Reader.GetOrdinal("ImporteTotal"));
                        Factura.NCF = Reader.IsDBNull(Reader.GetOrdinal("NCF_Asignado")) ? null : Reader.GetString(Reader.GetOrdinal("NCF_Asignado"));
                        Factura.TipoComprobante = Reader.IsDBNull(Reader.GetOrdinal("TipoComprobante")) ? null : Reader.GetString(Reader.GetOrdinal("TipoComprobante"));
                        Factura.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Factura.RazonSocial = Reader.GetString(Reader.GetOrdinal("RazonSocial"));
                        Factura.DireccionEmpresa = Reader.GetString(Reader.GetOrdinal("DireccionEmpresa"));
                        Factura.TelefonoEmpresa = Reader.GetString(Reader.GetOrdinal("TelefonoEmpresa"));
                        Factura.CiudadEmpresa = Reader.GetString(Reader.GetOrdinal("CiudadEmpresa"));
                        Factura.FaxEmpresa = Reader.GetString(Reader.GetOrdinal("FaxEmpresa"));
                        Factura.ProvinciaEmpresa = Reader.GetString(Reader.GetOrdinal("ProvinciaEmpresa"));
                        Factura.RNCEmpresa = Reader.GetString(Reader.GetOrdinal("RNCEmpresa"));
                        Factura.Estatus = Reader.GetString(Reader.GetOrdinal("Estatus"));
                        Factura.FechaVencimiento = Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
                        Factura.Vendedor =Reader.IsDBNull(Reader.GetOrdinal("Vendedor"))? null: Reader.GetString(Reader.GetOrdinal("Vendedor"));
                        Factura.Codicion = Reader.GetString(Reader.GetOrdinal("Condicion"));
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

        public static List<cFactura> FiltrarFactura( String TipoDocumento,
                                             Int64? ClienteID,
                                            Int64? DocumentoDesde,
                                            Int64? DocumentoHasta,
                                            DateTime? FechaDesde,
                                            DateTime? FechaHasta,
                                            Boolean IndGenerada,
                                            Boolean IndCancelada,
                                            Boolean IndDevuelta,
                                            String CriterioCantidad,
                                            Decimal ValorFactura)
       {

           try
           {
               //Declaramos la conexion hacia la base de datos
               using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspFiltroFactura";
                   //Creamos el command para la insercion
                   SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;

                  
                   Cmd.Parameters.AddWithValue("TipoDocumento", TipoDocumento);
                   Cmd.Parameters.AddWithValue("ClienteID", ClienteID);
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


                   List<cFactura> Lista = new List<cFactura>();
                   while (Reader.Read())
                   {
                       cFactura Factura = new cFactura();
                       Factura.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                       Factura.DocumentoID = Reader.GetInt64(Reader.GetOrdinal("DocumentoID"));
                       Factura.ClienteID = Reader.GetString(Reader.GetOrdinal("NombreCliente"));
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

        public static List<cFactura> Filtrar(
                                            String TipoDocumento,
                                            Int64 ClienteID,
                                            Int64 DocumentoDesde,
                                            Int64 DocumentoHasta,
                                            DateTime FechaDesde,
                                            DateTime FechaHasta,
                                            Boolean IndGenerada,
                                            Boolean IndCancelada,
                                            Boolean IndFacturada)
       {

           try
           {
               //Declaramos la conexion hacia la base de datos
               using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspFiltroCotizacion";
                   //Creamos el command para la insercion
                   SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;

                   Cmd.Parameters.AddWithValue("TipoDocumento", TipoDocumento);
                   Cmd.Parameters.AddWithValue("ClienteID", ClienteID);
                   Cmd.Parameters.AddWithValue("DocumentoDesde", DocumentoDesde);
                   Cmd.Parameters.AddWithValue("DocumentoHasta", DocumentoHasta);
                   Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                   Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                   Cmd.Parameters.AddWithValue("IndGenerada", IndGenerada);
                   Cmd.Parameters.AddWithValue("IndCancelada", IndCancelada);
                   Cmd.Parameters.AddWithValue("IndFacturada", IndFacturada);
                   //Ejecutamos el lector 
                   SqlDataReader Reader = Cmd.ExecuteReader();


                   List<cFactura> Lista = new List<cFactura>();
                   while (Reader.Read())
                   {
                       cFactura Factura = new cFactura();
                       Factura.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                       Factura.DocumentoID = Reader.GetInt64(Reader.GetOrdinal("DocumentoID"));
                       Factura.ClienteID = Reader.GetString(Reader.GetOrdinal("NombreCliente"));
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

        public static List<cFactura> Filtrar(
                                           String TipoDocumento,
                                           Int64 ClienteID,
                                           Int64 DocumentoDesde,
                                           Int64 DocumentoHasta,
                                           DateTime FechaDesde,
                                           DateTime FechaHasta,
                                           Boolean IndGenerada,
                                           Boolean IndCancelada)
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspFiltroDevolucion";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    Cmd.Parameters.AddWithValue("TipoDocumento", TipoDocumento);
                    Cmd.Parameters.AddWithValue("ClienteID", ClienteID);
                    Cmd.Parameters.AddWithValue("DocumentoDesde", DocumentoDesde);
                    Cmd.Parameters.AddWithValue("DocumentoHasta", DocumentoHasta);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    Cmd.Parameters.AddWithValue("IndGenerada", IndGenerada);
                    Cmd.Parameters.AddWithValue("IndCancelada", IndCancelada);
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cFactura> Lista = new List<cFactura>();
                    while (Reader.Read())
                    {
                        cFactura Factura = new cFactura();
                        Factura.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Factura.DocumentoID = Reader.GetInt64(Reader.GetOrdinal("DocumentoID"));
                        Factura.ClienteID = Reader.GetString(Reader.GetOrdinal("NombreCliente"));
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

       public static List<cReporteResumenFactura> ResumenFacturas(Int64? DocumentoDesde, 
                                                                  Int64? DocumentoHasta, 
                                                                  Int32? FamiliaID, 
                                                                  String TipoArticulo, 
                                                                  DateTime? FechaDesde, 
                                                                   DateTime? FechaHasta, 
                                                                   Int64? ClienteDesde, 
                                                                   Int64? ClienteHasta,
                                                                   String TipoDocumento,
                                                                   Int32? VendedorID)
       {

           try
           {
               //Declaramos la conexion hacia la base de datos
               using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspResumenFacturas";
                   //Creamos el command para la insercion
                   SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;

                   //Parametros
                   Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                   Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                   Cmd.Parameters.AddWithValue("ClienteDesde", ClienteDesde);
                   Cmd.Parameters.AddWithValue("ClienteHasta", ClienteHasta);
                   Cmd.Parameters.AddWithValue("TipoArticulo", TipoArticulo);
                   Cmd.Parameters.AddWithValue("FamiliaID", FamiliaID);
                   Cmd.Parameters.AddWithValue("DocumentoDesde", DocumentoDesde);
                   Cmd.Parameters.AddWithValue("DocumentoHasta", DocumentoHasta);
                   Cmd.Parameters.AddWithValue("TipoDocumento", TipoDocumento);
                   Cmd.Parameters.AddWithValue("Vendedor", VendedorID);
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
                       Factura.DescuentoTotal = Reader.GetDecimal(Reader.GetOrdinal("DescuentoTotal"));
                       Factura.ImpuestosTotal = Reader.GetDecimal(Reader.GetOrdinal("ImpuestosTotal"));
                       Factura.SubTotal = Reader.GetDecimal(Reader.GetOrdinal("SubTotal"));
                       Factura.Costo = Reader.GetDecimal(Reader.GetOrdinal("Costo"));
                       Factura.VendedorID = Reader.IsDBNull(Reader.GetOrdinal("NombreVendedor")) ? "" : Reader.GetString(Reader.GetOrdinal("NombreVendedor"));
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
               return null;
               throw Ex;

           }

       }


       public static List<cReporteFactura> ResumenNCF(DateTime FechaDesde, DateTime FechaHasta, Int64? ClienteDesde, Int64? ClienteHasta)
       {

           try
           {
               //Declaramos la conexion hacia la base de datos
               using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspReporteRelacionNCF";
                   //Creamos el command para la insercion
                   SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;

                   //Parametros
                   Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                   Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                   Cmd.Parameters.AddWithValue("ClienteDesde", ClienteDesde);
                   Cmd.Parameters.AddWithValue("ClienteHasta", ClienteHasta);

                   //Ejecutamos el lector 
                   SqlDataReader Reader = Cmd.ExecuteReader();


                   List<cReporteFactura> Lista = new List<cReporteFactura>();
                   while (Reader.Read())
                   {
                       cReporteFactura Factura = new cReporteFactura();
                       Factura.FacturaID = Reader.GetInt64(Reader.GetOrdinal("DocumentoID"));
                       Factura.NombreCliente = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                       Factura.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                       Factura.RNC = Reader.IsDBNull(Reader.GetOrdinal("RNC")) ? null : Reader.GetString(Reader.GetOrdinal("RNC"));
                       Factura.Estatus = Reader.GetString(Reader.GetOrdinal("Estatus"));
                       Factura.TotalGeneral = Reader.GetDecimal(Reader.GetOrdinal("TotalGeneral"));
                       //Factura.DescuentoTotal = Reader.GetDecimal(Reader.GetOrdinal("DescuentoTotal"));
                       Factura.ImpuestosTotal = Reader.GetDecimal(Reader.GetOrdinal("ImpuestosTotal"));
                       Factura.SubTotal = Reader.GetDecimal(Reader.GetOrdinal("SubTotal"));
                       Factura.TipoComprobante = Reader.GetString(Reader.GetOrdinal("TipoComprobantes"));
                       Factura.NCF = Reader.IsDBNull(Reader.GetOrdinal("NCF_Asignado"))? null :Reader.GetString(Reader.GetOrdinal("NCF_Asignado"));
                       Factura.FechaDesde = Reader.GetDateTime(Reader.GetOrdinal("FechaInicial"));
                       Factura.FechaHasta = Reader.GetDateTime(Reader.GetOrdinal("FechaFin"));

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

       public static Int64 ControlDocumento(String TipoDocumento)
       {
           try
           {
               //Declaramos la conexion hacia la base de datos
               using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "ufnControlDocumentoVenta";
                   //Creamos el command para la insercion
                   SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;

                   //Parametro
                   Cmd.Parameters.AddWithValue("TipoDocumento", TipoDocumento);
                   //Obtenemos el ultimo numero de documento para venta
                   Int64 FacturaID = Convert.ToInt64(Cmd.ExecuteScalar());
                   //Cerra la conexion
                   Conn.Close();

                   //Devolvemos el ultimo documento registrado para el tipo seleccionado
                   return FacturaID;
               }
           }
           catch (SqlException Ex)
           {
               
               throw Ex;

           }
       }


       public static List<cReporteResumenComisionVenta> ReporteComisionVenta(Int32? VendedorDesde, Int32? VendedorHasta, DateTime? FechaDesde, DateTime? FechaHasta)
       {

           try
           {
               //Declaramos la conexion hacia la base de datos
               using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspResumenComisionVenta";
                   //Creamos el command para la insercion
                   SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;

                   //Parametros
                   Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                   Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                   Cmd.Parameters.AddWithValue("VendedorDesde", VendedorDesde);
                   Cmd.Parameters.AddWithValue("VendedorHasta", VendedorHasta);
                   
                   //Ejecutamos el lector 
                   SqlDataReader Reader = Cmd.ExecuteReader();


                   List<cReporteResumenComisionVenta> Lista = new List<cReporteResumenComisionVenta>();
                   while (Reader.Read())
                   {
                       cReporteResumenComisionVenta Comision = new cReporteResumenComisionVenta();
                       Comision.NombreVendedor = Reader.GetString(Reader.GetOrdinal("NombreVendedor"));
                       Comision.CodigoVendedor = Reader.GetInt32(Reader.GetOrdinal("CodigoVendedor"));
                       Comision.TipoDocumento = Reader.GetString(Reader.GetOrdinal("TipoDocumento"));
                       Comision.CantidadVentas = Reader.GetInt32(Reader.GetOrdinal("CantidadVentas"));
                       Comision.CantidadArticulos = Reader.GetInt32(Reader.GetOrdinal("CantidadArticulos"));
                       Comision.SubTotal = Reader.GetDecimal(Reader.GetOrdinal("SubTotal"));
                       Comision.ComisionTotal = Reader.GetDecimal(Reader.GetOrdinal("ComisionTotal"));
                       Comision.FechaInicial = Reader.GetDateTime(Reader.GetOrdinal("FechaInicial"));
                       Comision.FechaFin = Reader.GetDateTime(Reader.GetOrdinal("FechaFin"));
                       Comision.SubTotal = Reader.GetDecimal(Reader.GetOrdinal("SubTotal"));
                       
                       

                       //Agregamos el articulo a la lista
                       Lista.Add(Comision);
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

       public static List<cReporteComisionVentaDetalle> ReporteComisionVentaDetalle(Int32? VendedorDesde, Int32? VendedorHasta, DateTime? FechaDesde, DateTime? FechaHasta)
       {

           try
           {
               //Declaramos la conexion hacia la base de datos
               using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspResumenComisionVentaDetalle";
                   //Creamos el command para la insercion
                   SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;

                   //Parametros
                   Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                   Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                   Cmd.Parameters.AddWithValue("VendedorDesde", VendedorDesde);
                   Cmd.Parameters.AddWithValue("VendedorHasta", VendedorHasta);

                   //Ejecutamos el lector 
                   SqlDataReader Reader = Cmd.ExecuteReader();


                   List<cReporteComisionVentaDetalle> Lista = new List<cReporteComisionVentaDetalle>();
                   while (Reader.Read())
                   {
                       cReporteComisionVentaDetalle Comision = new cReporteComisionVentaDetalle();
                       Comision.NombreVendedor = Reader.GetString(Reader.GetOrdinal("NombreVendedor"));
                       Comision.CodigoVendedor = Reader.GetInt32(Reader.GetOrdinal("CodigoVendedor"));
                       Comision.TipoDocumento = Reader.GetString(Reader.GetOrdinal("TipoDocumento"));
                       Comision.CantidadVentas = Reader.GetInt32(Reader.GetOrdinal("CantidadVentas"));
                       Comision.CantidadArticulos = Reader.GetInt32(Reader.GetOrdinal("CantidadArticulos"));
                       Comision.SubTotal = Reader.GetDecimal(Reader.GetOrdinal("SubTotal"));
                       Comision.ComisionTotal = Reader.GetDecimal(Reader.GetOrdinal("ComisionTotal"));
                       Comision.FechaInicial = Reader.GetDateTime(Reader.GetOrdinal("FechaInicial"));
                       Comision.FechaFin = Reader.GetDateTime(Reader.GetOrdinal("FechaFin"));
                       Comision.SubTotal = Reader.GetDecimal(Reader.GetOrdinal("SubTotal"));
                       Comision.NombreComercial = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                       Comision.Comision = Reader.GetDecimal(Reader.GetOrdinal("ComisionVenta"));
                       Comision.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));


                       //Agregamos el articulo a la lista
                       Lista.Add(Comision);
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

       public static List<cReporteArticulosDevueltos> ReporteArticulosDevueltos(Int64? DocumentoDesde, 
                                                                                Int64? DocumentoHasta, 
                                                                                DateTime? FechaDesde, 
                                                                                DateTime? FechaHasta, 
                                                                                Int64? CodigoCliente, 
                                                                                Int32? VendedorID, 
                                                                                String CodigoArticulo,
                                                                                Int32? Familia,
                                                                                String TipoArticulo )
       {

           try
           {
               //Declaramos la conexion hacia la base de datos
               using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspResumenArticulosDevueltos";
                   //Creamos el command para la insercion
                   SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;

                   //Parametros
                   Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                   Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                   Cmd.Parameters.AddWithValue("DocumentoDesde", DocumentoDesde);
                   Cmd.Parameters.AddWithValue("DocumentoHasta",DocumentoHasta);
                   Cmd.Parameters.AddWithValue("CodigoCliente", CodigoCliente);
                   Cmd.Parameters.AddWithValue("VendedorID", VendedorID);
                   Cmd.Parameters.AddWithValue("CodigoArticulo", CodigoArticulo);
                   Cmd.Parameters.AddWithValue("Familia", Familia);
                   Cmd.Parameters.AddWithValue("TipoArticulo", TipoArticulo);

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
                       Resumen.FechaInicial = Reader.IsDBNull(Reader.GetOrdinal("FechaInicial"))? "": Reader.GetValue(Reader.GetOrdinal("FechaInicial"));
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


       public static List<cReporteDetalladoDocumento> ReporteDetalladoDocumentos(Int64? DocumentoDesde, Int64? DocumentoHasta, DateTime? FechaCreacionDesde, 
                                                                             DateTime? FechaCreacionHasta, DateTime? FechaVencimientoDesde, DateTime? FechaVencimientoHasta, 
                                                                             Int64? ClienteDesde, Int64? ClienteHasta, String TipoDocumento, Int32? VendedorID)
       {

           try
           {
               //Declaramos la conexion hacia la base de datos
               using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspReporteDetalladoDocumentosVentas";
                   //Creamos el command para la insercion
                   SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;

                   //Parametros
                   Cmd.Parameters.AddWithValue("FechaCreacionDesde", FechaCreacionDesde);
                   Cmd.Parameters.AddWithValue("FechaCreacionHasta", FechaCreacionHasta);
                   Cmd.Parameters.AddWithValue("ClienteDesde", ClienteDesde);
                   Cmd.Parameters.AddWithValue("ClienteHasta", ClienteHasta);
                   Cmd.Parameters.AddWithValue("FechaVencimientoDesde", FechaVencimientoDesde);
                   Cmd.Parameters.AddWithValue("FechaVencimientoHasta", FechaVencimientoHasta);
                   Cmd.Parameters.AddWithValue("DocumentoDesde", DocumentoDesde);
                   Cmd.Parameters.AddWithValue("DocumentoHasta", DocumentoHasta);
                   Cmd.Parameters.AddWithValue("TipoDocumento", TipoDocumento);
                   Cmd.Parameters.AddWithValue("VendedorID", VendedorID);
                   //Ejecutamos el lector 
                   SqlDataReader Reader = Cmd.ExecuteReader();


                   List<cReporteDetalladoDocumento> Lista = new List<cReporteDetalladoDocumento>();
                   while (Reader.Read())
                   {
                       cReporteDetalladoDocumento Factura = new cReporteDetalladoDocumento();
                       Factura.DocumentoID = Reader.GetInt64(Reader.GetOrdinal("DocumentoID"));
                       Factura.NombreComercial = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                       Factura.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                       Factura.TotalGeneral = Reader.GetDecimal(Reader.GetOrdinal("TotalGeneral"));
                       Factura.DescuentoTotal = Reader.GetDecimal(Reader.GetOrdinal("DescuentoTotal"));
                       Factura.ImpuestosTotal = Reader.GetDecimal(Reader.GetOrdinal("ImpuestosTotal"));
                       Factura.SubTotal = Reader.GetDecimal(Reader.GetOrdinal("SubTotal"));
                       //Factura.Costo = Reader.GetDecimal(Reader.GetOrdinal("Costo"));
                       Factura.NombreVendedor = Reader.IsDBNull(Reader.GetOrdinal("NombreVendedor")) ? "" : Reader.GetString(Reader.GetOrdinal("NombreVendedor"));
                       Factura.FechaCreacionDesde = Reader.IsDBNull(Reader.GetOrdinal("FechaCreacionDesde")) ? "" : Reader.GetValue(Reader.GetOrdinal("FechaCreacionDesde"));
                       Factura.FechaCreacionHasta = Reader.IsDBNull(Reader.GetOrdinal("FechaCreacionHasta")) ? "" : Reader.GetValue(Reader.GetOrdinal("FechaCreacionHasta"));
                       Factura.FechaVencimientoDesde = Reader.IsDBNull(Reader.GetOrdinal("FechaVencimientoDesde")) ? "" : Reader.GetValue(Reader.GetOrdinal("FechaVencimientoDesde"));
                       Factura.FechaVencimientoHasta = Reader.IsDBNull(Reader.GetOrdinal("FechaVencimientoHasta")) ? "" : Reader.GetValue(Reader.GetOrdinal("FechaVencimientoHasta"));
                       Factura.DocumentoDesde = Reader.IsDBNull(Reader.GetOrdinal("DocumentoDesde")) ? "" : Reader.GetValue(Reader.GetOrdinal("DocumentoDesde"));
                       Factura.DocumentoHasta = Reader.IsDBNull(Reader.GetOrdinal("DocumentoHasta")) ? "" : Reader.GetValue(Reader.GetOrdinal("DocumentoHasta"));
                       Factura.CodigoArticulo = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));
                       Factura.DescripcionArticulo = Reader.GetString(Reader.GetOrdinal("DescripcionArticulo"));
                       Factura.Cantidad = Reader.GetDecimal(Reader.GetOrdinal("Cantidad"));
                       Factura.Precio = Reader.GetDecimal(Reader.GetOrdinal("Precio"));
                       Factura.ComisionVenta = Reader.GetDecimal(Reader.GetOrdinal("ComisionVenta"));
                       Factura.DescuentoValor = Reader.GetDecimal(Reader.GetOrdinal("DescuentoValor"));
                       Factura.ImpuestoValor = Reader.GetDecimal(Reader.GetOrdinal("ImpuestoValor"));
                       Factura.TipoProducto = Reader.GetString(Reader.GetOrdinal("TipoProducto"));
                       Factura.Referencia = Reader.GetInt64(Reader.GetOrdinal("Referencia"));
                       Factura.ValorComision = Reader.GetDecimal(Reader.GetOrdinal("ValorComision"));
                       
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


    }
}
