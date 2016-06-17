using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace SMA.DA
{
   
    public static class CuentaCobrarDA
    {
        public static void Crear(cCuentasCobrar Cuenta)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarCuentaCobrar";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("p_CodigoConcepto", Cuenta.CodigoConcepto);
                    Cmd.Parameters.AddWithValue("p_CodigoCliente", Cuenta.CodigoCliente);
                    Cmd.Parameters.AddWithValue("p_CodigoFactura", Cuenta.CodigoFactura);
                    Cmd.Parameters.AddWithValue("p_CodigoDocumento", Cuenta.CodigoDocumento);
                    Cmd.Parameters.AddWithValue("p_FechaEmision", Cuenta.FechaEmision);
                    Cmd.Parameters.AddWithValue("p_FechaVencimiento", Cuenta.FechaVencimiento);
                    Cmd.Parameters.AddWithValue("p_CodigoReferencia", Cuenta.CodigoReferencia);
                    Cmd.Parameters.AddWithValue("p_Monto", Cuenta.Monto);
                    Cmd.Parameters.AddWithValue("p_Notas", Cuenta.Notas);
                    Cmd.ExecuteNonQuery();
                }


            }
            catch (MySqlException Ex)
            {
                throw Ex;
            }
        }

        public static void Actualizar(cCuentasCobrar Cuenta)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspActualizarCuenCobrar";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("p_Codigo", Cuenta.Codigo);
                    Cmd.Parameters.AddWithValue("p_Notas", Cuenta.Notas);
                    Cmd.Parameters.AddWithValue("p_Estatus", Cuenta.Estatus);
                    Cmd.ExecuteNonQuery();
                }


            }
            catch (MySqlException Ex)
            {
                throw Ex;
            }
        }

        public static List<cCuentasCobrar> ListaCargosGenerales(Int64 ID)
    
        {
            //Lista los cargos generales(Documentos) de los clientes 
        try
        {
            //Declaramos la conexion hacia la base de datos
            using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
            {
                Conn.Open();
                //Nombre del procedimiento
                string StoreProc = "uspListarCargosGeneralesCxC";
                //Creamos el command para la insercion
                MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                Cmd.CommandType = CommandType.StoredProcedure;
                //Variable
                Cmd.Parameters.AddWithValue("p_Codigo", ID);
                //Ejecutamos el lector
 
                MySqlDataReader Reader = Cmd.ExecuteReader();


                List<cCuentasCobrar> Lista = new List<cCuentasCobrar>();
                while (Reader.Read())
                {
                    cCuentasCobrar Cuenta = new cCuentasCobrar();
                    Cuenta.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                    Cuenta.CodigoConcepto = Reader.GetString(Reader.GetOrdinal("Concepto"));
                    Cuenta.CodigoCliente = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                    Cuenta.CodigoDocumento = Reader.IsDBNull(Reader.GetOrdinal("CodigoDocumento"))? null:Reader.GetString(Reader.GetOrdinal("CodigoDocumento"));
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
        catch (MySqlException Ex)
        {
            throw Ex;

        }

    }

        public static List<cCuentasCobrar> ListaCargosPagos(String CodigoReferencia, Int32 CodigoCliente)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarCargosPagosCxC";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("p_CodigoReferencia", CodigoReferencia);
                    Cmd.Parameters.AddWithValue("p_CodigoCliente", CodigoCliente);
                    //Ejecutamos el lector

                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cCuentasCobrar> Lista = new List<cCuentasCobrar>();
                    while (Reader.Read())
                    {
                        cCuentasCobrar Cuenta = new cCuentasCobrar();
                        Cuenta.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                        Cuenta.CodigoConcepto = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.CodigoCliente = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.CodigoDocumento = Reader.IsDBNull(Reader.GetOrdinal("CodigoDocumento"))?null:Reader.GetString(Reader.GetOrdinal("CodigoDocumento"));
                        Cuenta.CodigoFactura = Reader.IsDBNull(Reader.GetOrdinal("CodigoFactura")) ? -1 : Reader.GetInt64(Reader.GetOrdinal("CodigoFactura"));
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
            catch (MySqlException Ex)
            {
                throw Ex;

            }

        }

        public static cCuentasCobrar BuscarPorID(Int32 ID)
        {
            //Buscamos un movimiento especifico por el codigo unico de la base de datos
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarMovCuenCobrar";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("p_Codigo", ID);
                    //Ejecutamos el lector

                    MySqlDataReader Reader = Cmd.ExecuteReader();

                    cCuentasCobrar Cuenta = new cCuentasCobrar();
                    while (Reader.Read())
                    {
                        Cuenta.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                        Cuenta.CodigoConcepto = Reader.GetInt16(Reader.GetOrdinal("CodigoConcepto"));
                        Cuenta.CodigoCliente = Reader.GetInt32(Reader.GetOrdinal("CodigoCliente"));
                        Cuenta.CodigoFactura = Reader.IsDBNull(Reader.GetOrdinal("CodigoFactura")) ? -1 : Reader.GetInt32(Reader.GetOrdinal("CodigoFactura"));
                        Cuenta.CodigoDocumento = Reader.IsDBNull(Reader.GetOrdinal("CodigoDocumento")) ? null : Reader.GetString(Reader.GetOrdinal("CodigoDocumento"));
                        Cuenta.CodigoReferencia = Reader.IsDBNull(Reader.GetOrdinal("CodigoReferencia")) ? null : Reader.GetString(Reader.GetOrdinal("CodigoReferencia"));
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
            catch (MySqlException Ex)
            {
                throw Ex;

            }

        }

        public static cCuentasCobrar BuscarPorID(String Documento)
        {
            //Buscamos un cargo general por el documento que lo identifica 
            //El monto referencia al balance del documento
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarCargosGralporCodDoc";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("p_CodigoDocumento", Documento);
                    //Ejecutamos el lector

                    MySqlDataReader Reader = Cmd.ExecuteReader();

                    cCuentasCobrar Cuenta = new cCuentasCobrar();
                    while (Reader.Read())
                    {
                        Cuenta.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                        Cuenta.CodigoConcepto = Reader.GetInt16(Reader.GetOrdinal("CodigoConcepto"));
                        Cuenta.CodigoCliente = Reader.GetInt32(Reader.GetOrdinal("CodigoCliente"));
                        Cuenta.CodigoFactura = Reader.IsDBNull(Reader.GetOrdinal("CodigoFactura")) ? -1 : Reader.GetInt32(Reader.GetOrdinal("CodigoFactura"));
                        Cuenta.CodigoDocumento = Reader.IsDBNull(Reader.GetOrdinal("CodigoDocumento")) ? null : Reader.GetString(Reader.GetOrdinal("CodigoDocumento"));
                        Cuenta.CodigoReferencia = Reader.IsDBNull(Reader.GetOrdinal("CodigoReferencia")) ? null : Reader.GetString(Reader.GetOrdinal("CodigoReferencia"));
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
            catch (MySqlException Ex)
            {
                throw Ex;

            }

        }

        public static List<cCuentasCobrar> ListaDocumentosCxC(Int32 ID)
        {
            //CARGAMOS LOS DOCUMENTOS DE CUENTAS POR COBRAR CON BALANCE MAYOR A 0
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarDocCxC";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("p_Codigo", ID);
                    //Ejecutamos el lector

                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cCuentasCobrar> Lista = new List<cCuentasCobrar>();
                    while (Reader.Read())
                    {
                        cCuentasCobrar Cuenta = new cCuentasCobrar();
                        Cuenta.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                        Cuenta.CodigoConcepto = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.CodigoCliente = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.CodigoDocumento = Reader.GetString(Reader.GetOrdinal("CodigoDocumento"));
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
            catch (MySqlException Ex)
            {
                throw Ex;

            }

        }

        public static Boolean Existe(Int32 ID)
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

        public static Boolean Existe(String Documento, Int32 CodigoCliente)
        {
            //Buscamos si un documento existe en la base de datos
            List<cCuentasCobrar> Cuenta=(from C in ListaCargosGenerales(CodigoCliente)
                                             where C.CodigoDocumento.ToString()==Documento
                                             select C).ToList();
            if(Cuenta.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static List<cCuentasCobrar> ImpresionComprobanteAbono(Int64 ID)
        {
            //Buscamos un movimiento especifico por el codigo unico de la base de datos
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspImpresionReciboCuentaCobrar";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("Codigo", ID);
                    //Ejecutamos el lector

                    MySqlDataReader Reader = Cmd.ExecuteReader();

                    List<cCuentasCobrar> Lista=new List<cCuentasCobrar>();

                    while (Reader.Read())
                    {

                        cCuentasCobrar Cuenta = new cCuentasCobrar();
                        Cuenta.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                        Cuenta.CodigoConcepto = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.CodigoCliente = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        //Cuenta.FacturaID = Reader.IsDBNull(Reader.GetOrdinal("CodigoFactura")) ? -1 : Reader.GetInt64(Reader.GetOrdinal("CodigoFactura"));
                        Cuenta.CodigoDocumento = Reader.IsDBNull(Reader.GetOrdinal("CodigoDocumento")) ? null : Reader.GetString(Reader.GetOrdinal("CodigoDocumento"));
                        Cuenta.CodigoReferencia = Reader.IsDBNull(Reader.GetOrdinal("CodigoReferencia")) ? null : Reader.GetString(Reader.GetOrdinal("CodigoReferencia"));
                        //Cuenta.Estatus = Reader.GetBoolean(Reader.GetOrdinal("Estatus"));
                        Cuenta.FechaEmision = Reader.GetDateTime(Reader.GetOrdinal("fechaEmision"));
                        //Cuenta.FechaVencimiento = Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
                        Cuenta.Monto = Reader.GetDecimal(Reader.GetOrdinal("Monto"));
                        Cuenta.Notas = Reader.GetString(Reader.GetOrdinal("Notas"));

                        Lista.Add(Cuenta);
                    }
                    Conn.Close();
                    return Lista;
                }
            }
            catch (MySqlException Ex)
            {
                throw Ex;

            }

        }


        public static List<cCuentasCobrar> FiltrarCuentas(  Int16 IndicadorFechaEmision,
                                                            Int16 IndicadorFechaVencimiento,
                                                            Int16 IndicadorConcepto,
                                                            String CriterioMonto,
                                                            String CriterioBalance,
                                                            Decimal Monto,
                                                            Decimal Balance,
                                                            Int16 ConceptoID,
                                                            Int32 ClienteID,
                                                            DateTime FechaDesde,
                                                            DateTime FechaHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspFiltroCuentaCobrar";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("p_CodigoCliente", ClienteID);
                    Cmd.Parameters.AddWithValue("p_IndicadorFechaEmision", IndicadorFechaEmision);
                    Cmd.Parameters.AddWithValue("p_IndicadorFechaVencimiento", IndicadorFechaVencimiento);
                    Cmd.Parameters.AddWithValue("p_IndicadorConcepto", IndicadorConcepto);
                    Cmd.Parameters.AddWithValue("p_CriterioMonto", CriterioMonto);
                    Cmd.Parameters.AddWithValue("p_CriterioBalance", CriterioBalance);
                    Cmd.Parameters.AddWithValue("p_Monto", Monto);
                    Cmd.Parameters.AddWithValue("p_Balance", Balance);
                    Cmd.Parameters.AddWithValue("p_CodigoConcepto", ConceptoID);
                    Cmd.Parameters.AddWithValue("p_FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("p_FechaHasta", FechaHasta);
                    //Ejecutamos el lector

                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cCuentasCobrar> Lista = new List<cCuentasCobrar>();
                    while (Reader.Read())
                    {
                        cCuentasCobrar Cuenta = new cCuentasCobrar();
                        Cuenta.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                        Cuenta.CodigoConcepto = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.CodigoCliente = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.CodigoDocumento = Reader.IsDBNull(Reader.GetOrdinal("CodigoDocumento")) ? null : Reader.GetString(Reader.GetOrdinal("CodigoDocumento"));
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
            catch (MySqlException Ex)
            {
                throw Ex;

            }

        }

        public static List<cReporteEstadoCuenta> EstadoCuentaGeneral(DateTime FechaDesde,
                                                                    DateTime FechaHasta,
                                                                    DateTime FechaCorte,
                                                                    Int32 IndicadorCorte,
                                                                    Int32 ClienteDesde,
                                                                    Int32 ClienteHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspRptEstadoCtaGralClte";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("p_FechaCorte", FechaCorte);
                    Cmd.Parameters.AddWithValue("p_ClienteDesde", ClienteDesde);
                    Cmd.Parameters.AddWithValue("p_ClienteHasta", ClienteHasta);
                    Cmd.Parameters.AddWithValue("p_IndicadorCorte", IndicadorCorte);
                    Cmd.Parameters.AddWithValue("p_FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("p_FechaHasta", FechaHasta);
                    //Ejecutamos el lector

                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteEstadoCuenta> Lista = new List<cReporteEstadoCuenta>();
                    while (Reader.Read())
                    {
                        cReporteEstadoCuenta Cuenta = new cReporteEstadoCuenta();
                        Cuenta.CodigoCliente = Reader.GetInt64(Reader.GetOrdinal("CodigoCliente"));
                        Cuenta.NombreCliente = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.Direccion = Reader.IsDBNull(Reader.GetOrdinal("Direccion")) ? null : Reader.GetString(Reader.GetOrdinal("Direccion"));
                        Cuenta.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia"))? null:  Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Cuenta.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Cuenta.RNC = Reader.GetString(Reader.GetOrdinal("RNC"));
                        Cuenta.Telefono = Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Cuenta.Fax = Reader.GetString(Reader.GetOrdinal("Fax"));
                        //Cuenta.ContactoCobros = Reader.GetString(Reader.GetOrdinal("ContactoCobros"));
                        Cuenta.LimiteCredito = Reader.GetDecimal(Reader.GetOrdinal("LimiteCredito"));
                        Cuenta.DiasCredito = Reader.GetInt32(Reader.GetOrdinal("DiasCredito"));
                        Cuenta.BalanceDisponible = Reader.GetDecimal(Reader.GetOrdinal("BalanceDisponible"));
                        Cuenta.CodigoConcepto = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.CodigoDocumento = Reader.GetString(Reader.GetOrdinal("CodigoDocumento"));
                        Cuenta.CodigoReferencia = Reader.IsDBNull(Reader.GetOrdinal("CodigoReferencia")) ? null : Reader.GetString(Reader.GetOrdinal("CodigoReferencia"));
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
            catch (MySqlException Ex)
            {
                throw Ex;

            }

        }

        public static List<cReporteEstadoCuenta> EstadoCuentaDetallado(DateTime FechaDesde,
                                                                  DateTime FechaHasta,
                                                                  DateTime FechaCorte,
                                                                  Int16 IndicadorCorte,
                                                                  Int32 ClienteDesde,
                                                                  Int32 ClienteHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspRptEstCtaDetClte";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("p_FechaCorte", FechaCorte);
                    Cmd.Parameters.AddWithValue("p_ClienteDesde", ClienteDesde);
                    Cmd.Parameters.AddWithValue("p_ClienteHasta", ClienteHasta);
                    Cmd.Parameters.AddWithValue("p_IndicadorCorte", IndicadorCorte);
                    Cmd.Parameters.AddWithValue("p_FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("p_FechaHasta", FechaHasta);
                    //Ejecutamos el lector

                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteEstadoCuenta> Lista = new List<cReporteEstadoCuenta>();
                    while (Reader.Read())
                    {
                        cReporteEstadoCuenta Cuenta = new cReporteEstadoCuenta();
                        Cuenta.CodigoCliente = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                        Cuenta.NombreCliente = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.Direccion = Reader.IsDBNull(Reader.GetOrdinal("Direccion")) ? null : Reader.GetString(Reader.GetOrdinal("Direccion"));
                        Cuenta.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia")) ? null : Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Cuenta.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Cuenta.RNC = Reader.GetString(Reader.GetOrdinal("RNC"));
                        Cuenta.Telefono = Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Cuenta.Fax = Reader.GetString(Reader.GetOrdinal("Fax"));
                        //Cuenta.ContactoCobros = Reader.GetString(Reader.GetOrdinal("ContactoCobros"));
                        Cuenta.LimiteCredito = Reader.GetDecimal(Reader.GetOrdinal("LimiteCredito"));
                        Cuenta.DiasCredito = Reader.GetInt32(Reader.GetOrdinal("DiasCredito"));
                        Cuenta.BalanceDisponible = Reader.GetDecimal(Reader.GetOrdinal("BalanceDisponible"));
                        Cuenta.CodigoConcepto = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.CodigoDocumento = Reader.GetString(Reader.GetOrdinal("CodigoDocumento"));
                        Cuenta.CodigoReferencia = Reader.IsDBNull(Reader.GetOrdinal("CodigoReferencia")) ? null : Reader.GetString(Reader.GetOrdinal("CodigoReferencia"));
                        Cuenta.FechaEmision = Reader.GetDateTime(Reader.GetOrdinal("FechaEmision"));
                        Cuenta.FechaVencimiento = Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
                        Cuenta.Monto = Reader.GetDecimal(Reader.GetOrdinal("Cargos"));
                        Cuenta.Abonos = Reader.GetDecimal(Reader.GetOrdinal("Abono"));
                        Cuenta.Balance = Reader.GetDecimal(Reader.GetOrdinal("BalanceDocumento"));
                        Cuenta.FechaInicio = FechaDesde;
                        Cuenta.FechaFin = FechaHasta;
                        //Agregamos el articulo a la lista
                        Lista.Add(Cuenta);
                    }
                    //Cerramos la conexion
                    Conn.Close();
                    //Retornamos la lista de clientes
                    return Lista;
                }
            }
            catch (MySqlException Ex)
            {
                throw Ex;

            }

        }

        public static List<cReporteEstadoCuenta> CobranzaGeneral(DateTime FechaDesde,
                                                                 DateTime FechaHasta,
                                                                 int IndicadorCorte, 
                                                                 DateTime FechaCorte,
                                                                 Int64 ClienteDesde,
                                                                 Int64 ClienteHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspCobranzaGeneral";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("FechaCorte", FechaCorte);
                    Cmd.Parameters.AddWithValue("ClienteDesde", ClienteDesde);
                    Cmd.Parameters.AddWithValue("ClienteHasta", ClienteHasta);
                    Cmd.Parameters.AddWithValue("IndicadorCorte", IndicadorCorte);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    //Ejecutamos el lector

                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteEstadoCuenta> Lista = new List<cReporteEstadoCuenta>();
                    while (Reader.Read())
                    {
                        cReporteEstadoCuenta Cuenta = new cReporteEstadoCuenta();
                        Cuenta.CodigoCliente = Reader.GetInt64(Reader.GetOrdinal("CodigoCliente"));
                        Cuenta.NombreCliente = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.Telefono = Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Cuenta.ContactoCobros = Reader.GetString(Reader.GetOrdinal("ContactoCobros"));
                        Cuenta.CodigoConcepto = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.CodigoDocumento = Reader.GetString(Reader.GetOrdinal("CodigoDocumento"));
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
            catch (MySqlException Ex)
            {
                throw Ex;

            }

        }

        public static List<cAntiguedadSaldo> AntiguedadSaldo(String IndicadorFecha,
                                                             DateTime FechaReferencia,
                                                             DateTime? FechaCorte,
                                                             Int32 ClienteDesde,
                                                             Int32 ClienteHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspAntiguedadSaldoCuenCobrar";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("p_FechaCorte", FechaCorte);
                    Cmd.Parameters.AddWithValue("p_ClienteDesde", ClienteDesde);
                    Cmd.Parameters.AddWithValue("p_ClienteHasta", ClienteHasta);
                    Cmd.Parameters.AddWithValue("p_FechaReferencia", FechaReferencia);
                    Cmd.Parameters.AddWithValue("p_IndicadorFecha",IndicadorFecha);
                    //Ejecutamos el lector

                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cAntiguedadSaldo> Lista = new List<cAntiguedadSaldo>();
                    while (Reader.Read())
                    {
                        cAntiguedadSaldo Cuenta = new cAntiguedadSaldo();
                        Cuenta.Codigo=Reader.GetInt64(Reader.GetOrdinal("Codigo"));
                        Cuenta.NombreComercial=Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.Corriente=Reader.GetDecimal(Reader.GetOrdinal("Corriente"));
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
            catch (MySqlException Ex)
            {
                throw Ex;

            }

        }

        public static List<cAntiguedadSaldoDetalle> AntiguedadSaldoDetalle(String IndicadorFecha,
                                                            DateTime FechaReferencia,
                                                            DateTime? FechaCorte,
                                                            Int32 ClienteDesde,
                                                            Int32 ClienteHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspAntiguedadSaldoCuenCobrarDetalle";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("p_FechaCorte", FechaCorte);
                    Cmd.Parameters.AddWithValue("p_ClienteDesde", ClienteDesde);
                    Cmd.Parameters.AddWithValue("p_ClienteHasta", ClienteHasta);
                    Cmd.Parameters.AddWithValue("p_FechaReferencia", FechaReferencia);
                    Cmd.Parameters.AddWithValue("p_IndicadorFecha", IndicadorFecha);
                    //Ejecutamos el lector

                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cAntiguedadSaldoDetalle> Lista = new List<cAntiguedadSaldoDetalle>();
                    while (Reader.Read())
                    {
                        cAntiguedadSaldoDetalle Cuenta = new cAntiguedadSaldoDetalle();
                        Cuenta.Codigo = Reader.GetInt64(Reader.GetOrdinal("Codigo"));
                        Cuenta.NombreComercial = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.CodigoDocumento = Reader.GetString(Reader.GetOrdinal("CodigoDocumento"));
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
            catch (MySqlException Ex)
            {
                throw Ex;

            }

        }

        public static List<cCuentasCobrar> ReportePorConcepto(Int64? ClienteDesde,
                                                              Int64? ClienteHasta,
                                                              DateTime? FechaDesde,
                                                              DateTime? FechaHasta,
                                                              String CriterioCantidad,
                                                              String Conceptos,
                                                              Decimal ValorMonto)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspRptPorCptoCuenCobrar";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("p_ClienteDesde", ClienteDesde);
                    Cmd.Parameters.AddWithValue("p_ClienteHasta", ClienteHasta);
                    Cmd.Parameters.AddWithValue("p_FechaInicial", FechaDesde);
                    Cmd.Parameters.AddWithValue("p_FechaFinal", FechaHasta);
                    Cmd.Parameters.AddWithValue("p_CriterioCantidad", CriterioCantidad);
                    Cmd.Parameters.AddWithValue("p_Conceptos", Conceptos);
                    Cmd.Parameters.AddWithValue("p_ValorMonto", ValorMonto);
                    //Ejecutamos el lector

                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cCuentasCobrar> Lista = new List<cCuentasCobrar>();
                    while (Reader.Read())
                    {
                        cCuentasCobrar Cuenta = new cCuentasCobrar();
                        Cuenta.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                        Cuenta.CodigoConcepto = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.CodigoCliente = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.CodigoDocumento = Reader.IsDBNull(Reader.GetOrdinal("CodigoDocumento")) ? null : Reader.GetString(Reader.GetOrdinal("CodigoDocumento"));
                        Cuenta.FechaEmision = Reader.GetDateTime(Reader.GetOrdinal("FechaEmision"));
                        Cuenta.FechaVencimiento = Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
                        Cuenta.CodigoReferencia = Reader.IsDBNull(Reader.GetOrdinal("CodigoReferencia")) ? null : Reader.GetString(Reader.GetOrdinal("CodigoReferencia"));
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
            catch (MySqlException Ex)
            {
                throw Ex;

            }

        }

        public static List<cReporteResumenCuentaCobrar> ReporteResumenCuentaCobrar(Int32? ClienteID,
                                                             DateTime? FechaDesde,
                                                             DateTime? FechaHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspRptResumenMovCuenCobrar";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("p_CodigoCliente", ClienteID);
                    Cmd.Parameters.AddWithValue("p_FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("p_FechaHasta", FechaHasta);
  
                    //Ejecutamos el lector

                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteResumenCuentaCobrar> Lista = new List<cReporteResumenCuentaCobrar>();
                    while (Reader.Read())
                    {
                        cReporteResumenCuentaCobrar Cuenta = new cReporteResumenCuentaCobrar();
                        Cuenta.Tipo = Reader.IsDBNull(Reader.GetOrdinal("Tipo")) ? null : Reader.GetString(Reader.GetOrdinal("Tipo"));
                        Cuenta.CodigoConcepto = Reader.GetString(Reader.GetOrdinal("Concepto"));
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
            catch (MySqlException Ex)
            {
                throw Ex;

            }

        }

        public static List<cReporteEstadoCuenta> ReporteResumenCuentaCobrarDetalle(Int32? ClienteID,
                                                             DateTime? FechaDesde,
                                                             DateTime? FechaHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspRptResumenMovCuentasCobrarDetalle";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("p_CodigoCliente", ClienteID);
                    Cmd.Parameters.AddWithValue("p_FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("p_FechaHasta", FechaHasta);
                    //Ejecutamos el lector

                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteEstadoCuenta> Lista = new List<cReporteEstadoCuenta>();
                    while (Reader.Read())
                    {
                        cReporteEstadoCuenta Cuenta = new cReporteEstadoCuenta();
                        Cuenta.CodigoCliente = Reader.GetInt64(Reader.GetOrdinal("CodigoCliente"));
                        Cuenta.NombreCliente = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.Direccion = Reader.IsDBNull(Reader.GetOrdinal("Direccion")) ? null : Reader.GetString(Reader.GetOrdinal("Direccion"));
                        Cuenta.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia")) ? null : Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Cuenta.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Cuenta.RNC = Reader.GetString(Reader.GetOrdinal("RNC"));
                        Cuenta.Telefono = Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Cuenta.Fax = Reader.GetString(Reader.GetOrdinal("Fax"));
                        Cuenta.LimiteCredito = Reader.GetDecimal(Reader.GetOrdinal("LimiteCredito"));
                        Cuenta.DiasCredito = Reader.GetInt32(Reader.GetOrdinal("DiasCredito"));
                        Cuenta.BalanceDisponible = Reader.GetDecimal(Reader.GetOrdinal("BalanceDisponible"));
                        Cuenta.CodigoConcepto = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.CodigoDocumento = Reader.GetString(Reader.GetOrdinal("CodigoDocumento"));
                        Cuenta.CodigoReferencia = Reader.IsDBNull(Reader.GetOrdinal("CodigoReferencia")) ? null : Reader.GetString(Reader.GetOrdinal("CodigoReferencia"));
                        Cuenta.FechaEmision = Reader.GetDateTime(Reader.GetOrdinal("FechaEmision"));
                        Cuenta.FechaVencimiento = Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
                        Cuenta.Monto = Reader.GetDecimal(Reader.GetOrdinal("Cargos"));
                        Cuenta.Abonos = Reader.GetDecimal(Reader.GetOrdinal("Abono"));
                        Cuenta.Balance = Reader.GetDecimal(Reader.GetOrdinal("BalanceDocumento"));
                        Cuenta.FechaInicio = FechaDesde.Value;
                        Cuenta.FechaFin = FechaHasta.Value;
                        //Agregamos el articulo a la lista
                        Lista.Add(Cuenta);
                    }
                    //Cerramos la conexion
                    Conn.Close();
                    //Retornamos la lista de clientes
                    return Lista;
                }
            }
            catch (MySqlException Ex)
            {
                throw Ex;

            }

        }

        public static List<cReporteEstadoCuenta> ReporteDocumentosPorCobrar(Int32? ClienteDesde, Int32? ClienteHasta, DateTime FechaCorte)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspRptDocPorCobrar";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("p_ClienteDesde", ClienteDesde);
                    Cmd.Parameters.AddWithValue("p_ClienteHasta", ClienteHasta);
                    Cmd.Parameters.AddWithValue("p_FechaCorte", FechaCorte);
                    //Ejecutamos el lector

                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteEstadoCuenta> Lista = new List<cReporteEstadoCuenta>();
                    while (Reader.Read())
                    {
                        cReporteEstadoCuenta Cuenta = new cReporteEstadoCuenta();
                        Cuenta.CodigoCliente = Reader.GetInt64(Reader.GetOrdinal("Codigo"));
                        Cuenta.NombreCliente = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        //Cuenta.ContactoCobros = Reader.IsDBNull(Reader.GetOrdinal("ContactoCobros")) ? null : Reader.GetString(Reader.GetOrdinal("ContactoCobros"));
                        Cuenta.CodigoConcepto = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.CodigoDocumento = Reader.GetString(Reader.GetOrdinal("CodigoDocumento"));
                        Cuenta.FechaReferencia = Reader.IsDBNull(Reader.GetOrdinal("FechaCorte"))? DateTime.Now :Reader.GetDateTime(Reader.GetOrdinal("FechaCorte"));
                        Cuenta.FechaEmision = Reader.GetDateTime(Reader.GetOrdinal("FechaEmision"));
                        Cuenta.FechaVencimiento = Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
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
            catch (MySqlException Ex)
            {
                throw Ex;

            }

        }

        public static List<cReporteEstadoCuenta> ReporteAbonoPorPeriodo(DateTime FechaDesde,
                                                                    DateTime FechaHasta,
                                                                    DateTime? FechaCorte,
                                                                    Int32 ClienteDesde,
                                                                    Int32 ClienteHasta,
                                                                    Int16 IndicadorCorte)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspAbonoPorPeriodoCuentaCobrar";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("p_FechaCorte", FechaCorte);
                    Cmd.Parameters.AddWithValue("p_ClienteDesde", ClienteDesde);
                    Cmd.Parameters.AddWithValue("p_ClienteHasta", ClienteHasta);
                    Cmd.Parameters.AddWithValue("p_FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("p_FechaHasta", FechaHasta);
                    Cmd.Parameters.AddWithValue("p_IndicadorCorte", IndicadorCorte);
                    //Ejecutamos el lector

                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteEstadoCuenta> Lista = new List<cReporteEstadoCuenta>();
                    while (Reader.Read())
                    {
                        cReporteEstadoCuenta Cuenta = new cReporteEstadoCuenta();
                        Cuenta.CodigoCliente = Reader.GetInt32(Reader.GetOrdinal("CodigoCliente"));
                        Cuenta.NombreCliente = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.Direccion = Reader.IsDBNull(Reader.GetOrdinal("Direccion")) ? null : Reader.GetString(Reader.GetOrdinal("Direccion"));
                        Cuenta.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia")) ? null : Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Cuenta.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Cuenta.RNC = Reader.GetString(Reader.GetOrdinal("RNC"));
                        Cuenta.Telefono = Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Cuenta.Fax = Reader.GetString(Reader.GetOrdinal("Fax"));
                        //Cuenta.ContactoCobros = Reader.GetString(Reader.GetOrdinal("ContactoCobros"));
                        Cuenta.LimiteCredito = Reader.GetDecimal(Reader.GetOrdinal("LimiteCredito"));
                        Cuenta.DiasCredito = Reader.GetInt32(Reader.GetOrdinal("DiasCredito"));
                        Cuenta.BalanceDisponible = Reader.GetDecimal(Reader.GetOrdinal("BalanceDisponible"));
                        Cuenta.CodigoConcepto = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.CodigoDocumento = Reader.GetString(Reader.GetOrdinal("CodigoDocumento"));
                        Cuenta.CodigoReferencia = Reader.IsDBNull(Reader.GetOrdinal("CodigoReferencia")) ? null : Reader.GetString(Reader.GetOrdinal("CodigoReferencia"));
                        Cuenta.FechaEmision = Reader.GetDateTime(Reader.GetOrdinal("FechaEmision"));
                        Cuenta.FechaVencimiento = Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
                        Cuenta.Monto = Reader.GetDecimal(Reader.GetOrdinal("Cargos"));
                        Cuenta.Abonos = Reader.GetDecimal(Reader.GetOrdinal("Abono"));
                        Cuenta.Balance = Reader.GetDecimal(Reader.GetOrdinal("BalanceDocumento"));
                        Cuenta.FechaInicio = Reader.GetDateTime(Reader.GetOrdinal("p_FechaDesde"));
                        Cuenta.FechaFin = Reader.GetDateTime(Reader.GetOrdinal("p_FechaHasta"));
                        //Agregamos el articulo a la lista
                        Lista.Add(Cuenta);
                    }
                    //Cerramos la conexion
                    Conn.Close();
                    //Retornamos la lista de clientes
                    return Lista;
                }
            }
            catch (MySqlException Ex)
            {
                throw Ex;

            }

        }
    }
}
