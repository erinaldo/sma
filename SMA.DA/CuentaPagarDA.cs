using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using System.Data.SqlClient;

namespace SMA.DA
{
    public static class CuentaPagarDA
    {
        public static void Crear(cCuentasPagar Cuenta)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarCuentaPagar";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("ConceptoID", Cuenta.ConceptoID);
                    Cmd.Parameters.AddWithValue("ProveedorID", Cuenta.ProveedorID);
                    Cmd.Parameters.AddWithValue("FacturaID", Cuenta.FacturaID);
                    Cmd.Parameters.AddWithValue("DocumentoID", Cuenta.DocumentoID);
                    Cmd.Parameters.AddWithValue("FechaEmision", Cuenta.FechaEmision);
                    Cmd.Parameters.AddWithValue("FechaVencimiento", Cuenta.FechaVencimiento);
                    Cmd.Parameters.AddWithValue("ReferenciaID", Cuenta.ReferenciaID);
                    Cmd.Parameters.AddWithValue("Estatus", Cuenta.Estatus);
                    Cmd.Parameters.AddWithValue("Monto", Cuenta.Monto);
                    Cmd.Parameters.AddWithValue("Notas", Cuenta.Notas);
                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static void Actualizar(cCuentasPagar Cuenta)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspActualizarCuentaPagar";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("CuentaID", Cuenta.ID);
                    Cmd.Parameters.AddWithValue("Notas", Cuenta.Notas);
                    Cmd.Parameters.AddWithValue("Estatus", Cuenta.Estatus);
                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static List<cCuentasPagar> ListaCargosGenerales(Int64 ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarCargosGeneralesCxP";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("ProveedorID", ID);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cCuentasPagar> Lista = new List<cCuentasPagar>();
                    while (Reader.Read())
                    {
                        cCuentasPagar Cuenta = new cCuentasPagar();
                        Cuenta.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Cuenta.ConceptoID = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.ProveedorID = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.DocumentoID = Reader.IsDBNull(Reader.GetOrdinal("DocumentoID")) ? null : Reader.GetString(Reader.GetOrdinal("DocumentoID"));
                        Cuenta.FechaEmision = Reader.GetDateTime(Reader.GetOrdinal("FechaEmision"));
                        Cuenta.FechaVencimiento = Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
                        Cuenta.Monto = Reader.GetDecimal(Reader.GetOrdinal("Monto"));
                        Cuenta.Balance = Reader.GetDecimal(Reader.GetOrdinal("Balance"));
                        //Agregamos el articulo a la lista
                        Lista.Add(Cuenta);
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

        public static List<cCuentasPagar> ListaCargosPagos(String Referencia,Int64 ProveedorID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarCargosPagosCxP";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("Referencia", Referencia);
                    Cmd.Parameters.AddWithValue("ProveedorID", ProveedorID);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cCuentasPagar> Lista = new List<cCuentasPagar>();
                    while (Reader.Read())
                    {
                        cCuentasPagar Cuenta = new cCuentasPagar();
                        Cuenta.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Cuenta.ConceptoID = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.ProveedorID = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.DocumentoID = Reader.IsDBNull(Reader.GetOrdinal("DocumentoID")) ? null : Reader.GetString(Reader.GetOrdinal("DocumentoID"));
                        Cuenta.FacturaID = Reader.IsDBNull(Reader.GetOrdinal("FacturaID")) ? -1 : Reader.GetInt64(Reader.GetOrdinal("FacturaID"));
                        Cuenta.FechaEmision = Reader.GetDateTime(Reader.GetOrdinal("fechaEmision"));
                        Cuenta.FechaVencimiento = Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
                        Cuenta.Monto = Reader.GetDecimal(Reader.GetOrdinal("Monto"));
                        //Agregamos el articulo a la lista
                        Lista.Add(Cuenta);
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

        public static cCuentasPagar BuscarPorID(Int64 ID)
        {
            //Buscamos un movimiento especifico por el codigo unico de la base de datos
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarMovCxPporID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("CuentaID", ID);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();

                    cCuentasPagar Cuenta = new cCuentasPagar();
                    while (Reader.Read())
                    {
                        Cuenta.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Cuenta.ConceptoID = Reader.GetInt32(Reader.GetOrdinal("ConceptoID"));
                        Cuenta.ProveedorID = Reader.GetInt64(Reader.GetOrdinal("ProveedorID"));
                        Cuenta.FacturaID = Reader.IsDBNull(Reader.GetOrdinal("FacturaID")) ? -1 : Reader.GetInt64(Reader.GetOrdinal("FacturaID"));
                        Cuenta.DocumentoID = Reader.IsDBNull(Reader.GetOrdinal("DocumentoID")) ? null : Reader.GetString(Reader.GetOrdinal("DocumentoID"));
                        Cuenta.ReferenciaID = Reader.IsDBNull(Reader.GetOrdinal("ReferenciaID")) ? null : Reader.GetString(Reader.GetOrdinal("ReferenciaID"));
                        Cuenta.Estatus = Reader.GetBoolean(Reader.GetOrdinal("Estatus"));
                        Cuenta.FechaEmision = Reader.GetDateTime(Reader.GetOrdinal("fechaEmision"));
                        Cuenta.FechaVencimiento = Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
                        Cuenta.Monto = Reader.GetDecimal(Reader.GetOrdinal("Monto"));
                        Cuenta.Notas = Reader.GetString(Reader.GetOrdinal("Notas"));
                    }
                    Conn.Close();
                    return Cuenta;
                }
            }
            catch (SqlException Ex)
            {
                throw Ex;

            }

        }

        public static cCuentasPagar BuscarPorID(String Documento)
        {
            //Buscamos un cargo general por el documento que lo identifica 
            //El monto referencia al balance del documento
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarCargosGeneralesCxPporDocID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("DocumentoID", Documento);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();

                    cCuentasPagar Cuenta = new cCuentasPagar();
                    while (Reader.Read())
                    {
                        Cuenta.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Cuenta.ConceptoID = Reader.GetInt32(Reader.GetOrdinal("ConceptoID"));
                        Cuenta.ProveedorID = Reader.GetInt64(Reader.GetOrdinal("ProveedorID"));
                        Cuenta.FacturaID = Reader.IsDBNull(Reader.GetOrdinal("FacturaID")) ? -1 : Reader.GetInt64(Reader.GetOrdinal("FacturaID"));
                        Cuenta.DocumentoID = Reader.IsDBNull(Reader.GetOrdinal("DocumentoID")) ? null : Reader.GetString(Reader.GetOrdinal("DocumentoID"));
                        Cuenta.ReferenciaID = Reader.IsDBNull(Reader.GetOrdinal("ReferenciaID")) ? null : Reader.GetString(Reader.GetOrdinal("ReferenciaID"));
                        Cuenta.Estatus = Reader.GetBoolean(Reader.GetOrdinal("Estatus"));
                        Cuenta.FechaEmision = Reader.GetDateTime(Reader.GetOrdinal("fechaEmision"));
                        Cuenta.FechaVencimiento = Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
                        Cuenta.Monto = Reader.GetDecimal(Reader.GetOrdinal("Monto"));
                        Cuenta.Notas = Reader.GetString(Reader.GetOrdinal("Notas"));
                    }
                    Conn.Close();
                    return Cuenta;
                }
            }
            catch (SqlException Ex)
            {
                throw Ex;

            }

        }

        public static List<cCuentasPagar> ListaDocumentosCxP(Int64 ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListaDocumentosCxP";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("ProveedorID", ID);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cCuentasPagar> Lista = new List<cCuentasPagar>();
                    while (Reader.Read())
                    {
                        cCuentasPagar Cuenta = new cCuentasPagar();
                        Cuenta.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Cuenta.ConceptoID = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.ProveedorID = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.DocumentoID = Reader.GetString(Reader.GetOrdinal("DocumentoID"));
                        Cuenta.FechaEmision = Reader.GetDateTime(Reader.GetOrdinal("fechaEmision"));
                        Cuenta.FechaVencimiento = Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
                        Cuenta.Monto = Reader.GetDecimal(Reader.GetOrdinal("Monto"));
                        Cuenta.Balance = Reader.GetDecimal(Reader.GetOrdinal("Balance"));
                        //Agregamos el articulo a la lista
                        Lista.Add(Cuenta);
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

        public static Boolean Existe(String Documento, Int64 ProveedorID)
        {
            //Buscamos si un documento existe en la base de datos
            List<cCuentasPagar> Cuenta = (from C in ListaCargosGenerales(ProveedorID)
                                           where C.DocumentoID.ToString() == Documento
                                           select C).ToList();
            if (Cuenta.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static List<cCuentasPagar> FiltrarCuentas(Nullable<Int32> IndicadorFechaEmision,
                                                           Nullable<Int32> IndicadorFechaVencimiento,
                                                           Nullable<Int32> IndicadorConcepto,
                                                           String CriterioMonto,
                                                           String CriterioBalance,
                                                           Decimal Monto,
                                                           Decimal Balance,
                                                           Nullable<Int32> ConceptoID,
                                                           Int64 ProveedorID,
                                                           DateTime FechaDesde,
                                                           DateTime FechaHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspFiltroCuentaPagar";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("ProveedorID", ProveedorID);
                    Cmd.Parameters.AddWithValue("IndicadorFechaEmision", IndicadorFechaEmision);
                    Cmd.Parameters.AddWithValue("IndicadorFechaVencimiento", IndicadorFechaVencimiento);
                    Cmd.Parameters.AddWithValue("IndicadorConcepto", IndicadorConcepto);
                    Cmd.Parameters.AddWithValue("CriterioMonto", CriterioMonto);
                    Cmd.Parameters.AddWithValue("CriterioBalance", CriterioBalance);
                    Cmd.Parameters.AddWithValue("Monto", Monto);
                    Cmd.Parameters.AddWithValue("Balance", Balance);
                    Cmd.Parameters.AddWithValue("ConceptoID", ConceptoID);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cCuentasPagar> Lista = new List<cCuentasPagar>();
                    while (Reader.Read())
                    {
                        cCuentasPagar Cuenta = new cCuentasPagar();
                        Cuenta.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Cuenta.ConceptoID = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.ProveedorID = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.DocumentoID = Reader.IsDBNull(Reader.GetOrdinal("DocumentoID")) ? null : Reader.GetString(Reader.GetOrdinal("DocumentoID"));
                        Cuenta.FechaEmision = Reader.GetDateTime(Reader.GetOrdinal("FechaEmision"));
                        Cuenta.FechaVencimiento = Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
                        Cuenta.Monto = Reader.GetDecimal(Reader.GetOrdinal("Monto"));
                        Cuenta.Balance = Reader.GetDecimal(Reader.GetOrdinal("Balance"));
                        //Agregamos el articulo a la lista
                        Lista.Add(Cuenta);
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

        public static List<cReporteEstadoCuenta> EstadoCuentaGeneral(DateTime FechaDesde,
                                                                    DateTime FechaHasta,
                                                                    DateTime FechaCorte,
                                                                    Int32 IndicadorCorte,
                                                                    Int64 ProveedorDesde,
                                                                    Int64 ProveedorHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspReporteEstadoCuentaGeneralProveedor";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("FechaCorte", FechaCorte);
                    Cmd.Parameters.AddWithValue("ProveedorDesde", ProveedorDesde);
                    Cmd.Parameters.AddWithValue("ProveedorHasta", ProveedorHasta);
                    Cmd.Parameters.AddWithValue("IndicadorCorte", IndicadorCorte);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteEstadoCuenta> Lista = new List<cReporteEstadoCuenta>();
                    while (Reader.Read())
                    {
                        cReporteEstadoCuenta Cuenta = new cReporteEstadoCuenta();
                        Cuenta.ClienteID = Reader.GetInt64(Reader.GetOrdinal("ProveedorID"));
                        Cuenta.NombreCliente = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.Direccion = Reader.IsDBNull(Reader.GetOrdinal("Direccion")) ? null : Reader.GetString(Reader.GetOrdinal("Direccion"));
                        Cuenta.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia"))? null:  Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Cuenta.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Cuenta.RNC = Reader.GetString(Reader.GetOrdinal("RNC"));
                        Cuenta.Telefono = Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Cuenta.Fax = Reader.GetString(Reader.GetOrdinal("Fax"));
                        Cuenta.ContactoCobros = Reader.GetString(Reader.GetOrdinal("ContactoPagos"));
                        Cuenta.LimiteCredito = Reader.GetDecimal(Reader.GetOrdinal("LimiteCredito"));
                        Cuenta.DiasCredito = Reader.GetInt32(Reader.GetOrdinal("DiasCredito"));
                        Cuenta.BalanceDisponible = Reader.GetDecimal(Reader.GetOrdinal("BalanceDisponible"));
                        Cuenta.ConceptoID = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.DocumentoID = Reader.GetString(Reader.GetOrdinal("DocumentoID"));
                        Cuenta.ReferenciaID = Reader.IsDBNull(Reader.GetOrdinal("ReferenciaID")) ? null : Reader.GetString(Reader.GetOrdinal("ReferenciaID"));
                        Cuenta.FechaEmision = Reader.GetDateTime(Reader.GetOrdinal("FechaEmision"));
                        Cuenta.FechaVencimiento = Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
                        Cuenta.Monto = Reader.GetDecimal(Reader.GetOrdinal("Cargos"));
                        Cuenta.Abonos = Reader.GetDecimal(Reader.GetOrdinal("Abono"));
                        Cuenta.Balance = Reader.GetDecimal(Reader.GetOrdinal("BalanceDocumento"));
                        //Agregamos el articulo a la lista
                        Lista.Add(Cuenta);
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

        public static List<cReporteEstadoCuenta> EstadoCuentaDetallado(DateTime FechaDesde,
                                                                 DateTime FechaHasta,
                                                                 DateTime FechaCorte,
                                                                 Int32 IndicadorCorte,
                                                                 Int64 ProveedorDesde,
                                                                 Int64 ProveedorHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspReporteEstadoCuentaDetalladoProveedor";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("FechaCorte", FechaCorte);
                    Cmd.Parameters.AddWithValue("ProveedorDesde", ProveedorDesde);
                    Cmd.Parameters.AddWithValue("ProveedorHasta", ProveedorHasta);
                    Cmd.Parameters.AddWithValue("IndicadorCorte", IndicadorCorte);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteEstadoCuenta> Lista = new List<cReporteEstadoCuenta>();
                    while (Reader.Read())
                    {
                        cReporteEstadoCuenta Cuenta = new cReporteEstadoCuenta();
                        Cuenta.ClienteID = Reader.GetInt64(Reader.GetOrdinal("ProveedorID"));
                        Cuenta.NombreCliente = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.Direccion = Reader.IsDBNull(Reader.GetOrdinal("Direccion")) ? null : Reader.GetString(Reader.GetOrdinal("Direccion"));
                        Cuenta.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia")) ? null : Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Cuenta.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Cuenta.RNC = Reader.GetString(Reader.GetOrdinal("RNC"));
                        Cuenta.Telefono = Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Cuenta.Fax = Reader.GetString(Reader.GetOrdinal("Fax"));
                        Cuenta.ContactoCobros = Reader.GetString(Reader.GetOrdinal("ContactoPagos"));
                        Cuenta.LimiteCredito = Reader.GetDecimal(Reader.GetOrdinal("LimiteCredito"));
                        Cuenta.DiasCredito = Reader.GetInt32(Reader.GetOrdinal("DiasCredito"));
                        Cuenta.BalanceDisponible = Reader.GetDecimal(Reader.GetOrdinal("BalanceDisponible"));
                        Cuenta.ConceptoID = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.DocumentoID = Reader.GetString(Reader.GetOrdinal("DocumentoID"));
                        Cuenta.ReferenciaID = Reader.IsDBNull(Reader.GetOrdinal("ReferenciaID")) ? null : Reader.GetString(Reader.GetOrdinal("ReferenciaID"));
                        Cuenta.FechaEmision = Reader.GetDateTime(Reader.GetOrdinal("FechaEmision"));
                        Cuenta.FechaVencimiento = Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
                        Cuenta.Monto = Reader.GetDecimal(Reader.GetOrdinal("Cargos"));
                        Cuenta.Abonos = Reader.GetDecimal(Reader.GetOrdinal("Abono"));
                        Cuenta.Balance = Reader.GetDecimal(Reader.GetOrdinal("BalanceDocumento"));
                        //Agregamos el articulo a la lista
                        Lista.Add(Cuenta);
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

        public static List<cCuentasPagar> ReportePorConcepto(Int64 ProveedorDesde,
                                                              Int64 ProveedorHasta,
                                                              DateTime? FechaDesde,
                                                              DateTime? FechaHasta,
                                                              String CriterioCantidad,
                                                              String Conceptos,
                                                              Double ValorMonto)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspReportePorConceptoCuenPagar";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("ProveedorDesde", ProveedorDesde);
                    Cmd.Parameters.AddWithValue("ProveedorHasta", ProveedorHasta);
                    Cmd.Parameters.AddWithValue("FechaInicial", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaFinal", FechaHasta);
                    Cmd.Parameters.AddWithValue("CriterioCantidad", CriterioCantidad);
                    Cmd.Parameters.AddWithValue("Conceptos", Conceptos);
                    Cmd.Parameters.AddWithValue("ValorMonto", ValorMonto);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cCuentasPagar> Lista = new List<cCuentasPagar>();
                    while (Reader.Read())
                    {
                        cCuentasPagar Cuenta = new cCuentasPagar();
                        Cuenta.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Cuenta.ConceptoID = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.ProveedorID = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.DocumentoID = Reader.IsDBNull(Reader.GetOrdinal("DocumentoID")) ? null : Reader.GetString(Reader.GetOrdinal("DocumentoID"));
                        Cuenta.FechaEmision = Reader.GetDateTime(Reader.GetOrdinal("FechaEmision"));
                        Cuenta.FechaVencimiento = Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
                        Cuenta.ReferenciaID = Reader.IsDBNull(Reader.GetOrdinal("ReferenciaID")) ? null : Reader.GetString(Reader.GetOrdinal("ReferenciaID"));
                        Cuenta.Monto = Reader.GetDecimal(Reader.GetOrdinal("Monto"));
                        //Agregamos el articulo a la lista
                        Lista.Add(Cuenta);
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

        public static List<cReporteResumenCuentaPagar> ReporteResumenCuentaPagar(Int64? ProveedorID,
                                                             DateTime? FechaDesde,
                                                             DateTime? FechaHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspResumenMovCuentaPagar";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("ProveedorID", ProveedorID);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);

                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteResumenCuentaPagar> Lista = new List<cReporteResumenCuentaPagar>();
                    while (Reader.Read())
                    {
                        cReporteResumenCuentaPagar Cuenta = new cReporteResumenCuentaPagar();
                        Cuenta.Tipo = Reader.IsDBNull(Reader.GetOrdinal("Tipo")) ? null : Reader.GetString(Reader.GetOrdinal("Tipo"));
                        Cuenta.ConceptoID = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.Monto = Reader.GetDecimal(Reader.GetOrdinal("Monto"));
                        //Agregamos el articulo a la lista
                        Lista.Add(Cuenta);
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

        public static List<cReporteEstadoCuentaPagar> ReporteResumenCuentaPagarDetalle(Int64? ProveedorID,
                                                            DateTime? FechaDesde,
                                                            DateTime? FechaHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspResumenMovCuentasPagarDetalle";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("ProveedorID", ProveedorID);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteEstadoCuentaPagar> Lista = new List<cReporteEstadoCuentaPagar>();
                    while (Reader.Read())
                    {
                        cReporteEstadoCuentaPagar Cuenta = new cReporteEstadoCuentaPagar();
                        Cuenta.ProveedorID = Reader.GetInt64(Reader.GetOrdinal("ProveedorID"));
                        Cuenta.NombreProveedor = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.Direccion = Reader.IsDBNull(Reader.GetOrdinal("Direccion")) ? null : Reader.GetString(Reader.GetOrdinal("Direccion"));
                        Cuenta.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia")) ? null : Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Cuenta.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Cuenta.RNC = Reader.GetString(Reader.GetOrdinal("RNC"));
                        Cuenta.Telefono = Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Cuenta.Fax = Reader.GetString(Reader.GetOrdinal("Fax"));
                        Cuenta.ContactoCobros = Reader.GetString(Reader.GetOrdinal("ContactoPagos"));
                        Cuenta.LimiteCredito = Reader.GetDecimal(Reader.GetOrdinal("LimiteCredito"));
                        Cuenta.DiasCredito = Reader.GetInt32(Reader.GetOrdinal("DiasCredito"));
                        Cuenta.BalanceDisponible = Reader.GetDecimal(Reader.GetOrdinal("BalanceDisponible"));
                        Cuenta.ConceptoID = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.DocumentoID = Reader.GetString(Reader.GetOrdinal("DocumentoID"));
                        Cuenta.ReferenciaID = Reader.IsDBNull(Reader.GetOrdinal("ReferenciaID")) ? null : Reader.GetString(Reader.GetOrdinal("ReferenciaID"));
                        Cuenta.FechaEmision = Reader.GetDateTime(Reader.GetOrdinal("FechaEmision"));
                        Cuenta.FechaVencimiento = Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
                        Cuenta.Monto = Reader.GetDecimal(Reader.GetOrdinal("Cargos"));
                        Cuenta.Abonos = Reader.GetDecimal(Reader.GetOrdinal("Abono"));
                        Cuenta.Balance = Reader.GetDecimal(Reader.GetOrdinal("BalanceDocumento"));
                        //Agregamos el articulo a la lista
                        Lista.Add(Cuenta);
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

        public static List<cReporteEstadoCuentaPagar> ReportePagosPorPeriodo(DateTime FechaDesde,
                                                                 DateTime FechaHasta,
                                                                 DateTime? FechaCorte,
                                                                 Int64 ProveedorDesde,
                                                                 Int64 ProveedorHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspPagosPorPeriodoCuentaPagar";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("FechaCorte", FechaCorte);
                    Cmd.Parameters.AddWithValue("ProveedorDesde", ProveedorDesde);
                    Cmd.Parameters.AddWithValue("ProveedorHasta", ProveedorHasta);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteEstadoCuentaPagar> Lista = new List<cReporteEstadoCuentaPagar>();
                    while (Reader.Read())
                    {
                        cReporteEstadoCuentaPagar Cuenta = new cReporteEstadoCuentaPagar();
                        Cuenta.ProveedorID = Reader.GetInt64(Reader.GetOrdinal("ProveedorID"));
                        Cuenta.NombreProveedor = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.Direccion = Reader.IsDBNull(Reader.GetOrdinal("Direccion")) ? null : Reader.GetString(Reader.GetOrdinal("Direccion"));
                        Cuenta.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia")) ? null : Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Cuenta.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Cuenta.RNC = Reader.GetString(Reader.GetOrdinal("RNC"));
                        Cuenta.Telefono = Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Cuenta.Fax = Reader.GetString(Reader.GetOrdinal("Fax"));
                        Cuenta.ContactoCobros = Reader.GetString(Reader.GetOrdinal("ContactoPagos"));
                        Cuenta.LimiteCredito = Reader.GetDecimal(Reader.GetOrdinal("LimiteCredito"));
                        Cuenta.DiasCredito = Reader.GetInt32(Reader.GetOrdinal("DiasCredito"));
                        Cuenta.BalanceDisponible = Reader.GetDecimal(Reader.GetOrdinal("BalanceDisponible"));
                        Cuenta.ConceptoID = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.DocumentoID = Reader.GetString(Reader.GetOrdinal("DocumentoID"));
                        Cuenta.ReferenciaID = Reader.IsDBNull(Reader.GetOrdinal("ReferenciaID")) ? null : Reader.GetString(Reader.GetOrdinal("ReferenciaID"));
                        Cuenta.FechaEmision = Reader.GetDateTime(Reader.GetOrdinal("FechaEmision"));
                        Cuenta.FechaVencimiento = Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
                        Cuenta.Monto = Reader.GetDecimal(Reader.GetOrdinal("Cargos"));
                        Cuenta.Abonos = Reader.GetDecimal(Reader.GetOrdinal("Abono"));
                        Cuenta.Balance = Reader.GetDecimal(Reader.GetOrdinal("BalanceDocumento"));
                        //Agregamos el articulo a la lista
                        Lista.Add(Cuenta);
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

        public static List<cAntiguedadSaldo> AntiguedadSaldo(String IndicadorFecha,
                                                             DateTime FechaReferencia,
                                                             DateTime? FechaCorte,
                                                             Int64 ProveeodrDesde,
                                                             Int64 ProveedorHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspAntiguedadSaldoCuenPagar";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("FechaCorte", FechaCorte);
                    Cmd.Parameters.AddWithValue("ProveedorDesde", ProveeodrDesde);
                    Cmd.Parameters.AddWithValue("ProveedorHasta", ProveedorHasta);
                    Cmd.Parameters.AddWithValue("FechaReferencia", FechaReferencia);
                    Cmd.Parameters.AddWithValue("IndicadorFecha", IndicadorFecha);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cAntiguedadSaldo> Lista = new List<cAntiguedadSaldo>();
                    while (Reader.Read())
                    {
                        cAntiguedadSaldo Cuenta = new cAntiguedadSaldo();
                        Cuenta.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Cuenta.NombreComercial = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.Corriente = Reader.GetDecimal(Reader.GetOrdinal("Corriente"));
                        Cuenta.Dias0a30 = Reader.GetDecimal(Reader.GetOrdinal("1-30"));
                        Cuenta.Dias31a60 = Reader.GetDecimal(Reader.GetOrdinal("31-60"));
                        Cuenta.Dias61a90 = Reader.GetDecimal(Reader.GetOrdinal("61-90"));
                        Cuenta.Mas91Dias = Reader.GetDecimal(Reader.GetOrdinal("91 o Mas"));
                        Cuenta.TotalFactura = Reader.GetDecimal(Reader.GetOrdinal("TotalFactura"));
                        Cuenta.FechaReferencia = Reader.GetDateTime(Reader.GetOrdinal("FechaReferencia"));
                        //Agregamos el articulo a la lista
                        Lista.Add(Cuenta);
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

        public static List<cAntiguedadSaldoDetalle> AntiguedadSaldoDetalle(String IndicadorFecha,
                                                            DateTime FechaReferencia,
                                                            DateTime? FechaCorte,
                                                            Int64 ProveedorDesde,
                                                            Int64 ProveedorHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspAntiguedadSaldoCuenPagarDetalle";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("FechaCorte", FechaCorte);
                    Cmd.Parameters.AddWithValue("ProveedorDesde", ProveedorDesde);
                    Cmd.Parameters.AddWithValue("ProveedorHasta", ProveedorHasta);
                    Cmd.Parameters.AddWithValue("FechaReferencia", FechaReferencia);
                    Cmd.Parameters.AddWithValue("IndicadorFecha", IndicadorFecha);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cAntiguedadSaldoDetalle> Lista = new List<cAntiguedadSaldoDetalle>();
                    while (Reader.Read())
                    {
                        cAntiguedadSaldoDetalle Cuenta = new cAntiguedadSaldoDetalle();
                        Cuenta.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Cuenta.NombreComercial = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.DocumentoID = Reader.GetString(Reader.GetOrdinal("DocumentoID"));
                        Cuenta.Concepto = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.FechaEmision = Reader.GetDateTime(Reader.GetOrdinal("FechaEmision"));
                        Cuenta.FechaVencimiento = Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
                        Cuenta.Corriente = Reader.GetDecimal(Reader.GetOrdinal("Corriente"));
                        Cuenta.Dias0a30 = Reader.GetDecimal(Reader.GetOrdinal("1-30"));
                        Cuenta.Dias31a60 = Reader.GetDecimal(Reader.GetOrdinal("31-60"));
                        Cuenta.Dias61a90 = Reader.GetDecimal(Reader.GetOrdinal("61-90"));
                        Cuenta.Mas91Dias = Reader.GetDecimal(Reader.GetOrdinal("91 o Mas"));
                        Cuenta.TotalFactura = Reader.GetDecimal(Reader.GetOrdinal("TotalFactura"));
                        Cuenta.FechaReferencia = Reader.GetDateTime(Reader.GetOrdinal("FechaReferencia"));
                        //Agregamos el articulo a la lista
                        Lista.Add(Cuenta);
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
