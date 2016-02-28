using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using System.Data.SqlClient;

namespace SMA.DA
{
   
    public static class CuentaCobrarDA
    {
        public static void Crear(cCuentasCobrar Cuenta)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarCuentaCobrar";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("ConceptoID", Cuenta.ConceptoID);
                    Cmd.Parameters.AddWithValue("ClienteID", Cuenta.ClienteID);
                    Cmd.Parameters.AddWithValue("FacturaID", Cuenta.FacturaID);
                    Cmd.Parameters.AddWithValue("DocumentoID", Cuenta.DocumentoID);
                    Cmd.Parameters.AddWithValue("FechaEmision", Cuenta.FechaEmision);
                    Cmd.Parameters.AddWithValue("FechaVencimiento", Cuenta.FechaVencimiento);
                    Cmd.Parameters.AddWithValue("ReferenciaID", Cuenta.ReferenciaID);
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

        public static void Actualizar(cCuentasCobrar Cuenta)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspActualizarCuentaCobrar";
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

        public static List<cCuentasCobrar> ListaCargosGenerales(Int64 ID)
    {
            //Lista los cargos generales(Documentos) de los clientes 
        try
        {
            //Declaramos la conexion hacia la base de datos
            using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
            {
                Conn.Open();
                //Nombre del procedimiento
                string StoreProc = "uspListarCargosGeneralesCxC";
                //Creamos el command para la insercion
                SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                Cmd.CommandType = CommandType.StoredProcedure;
                //Variable
                Cmd.Parameters.AddWithValue("ClienteID", ID);
                //Ejecutamos el lector
 
                SqlDataReader Reader = Cmd.ExecuteReader();


                List<cCuentasCobrar> Lista = new List<cCuentasCobrar>();
                while (Reader.Read())
                {
                    cCuentasCobrar Cuenta = new cCuentasCobrar();
                    Cuenta.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                    Cuenta.ConceptoID = Reader.GetString(Reader.GetOrdinal("Concepto"));
                    Cuenta.ClienteID = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                    Cuenta.DocumentoID = Reader.IsDBNull(Reader.GetOrdinal("DocumentoID"))? null:Reader.GetString(Reader.GetOrdinal("DocumentoID"));
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

        public static List<cCuentasCobrar> ListaCargosPagos(String Referencia, Int64 ClienteID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarCargosPagosCxC";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("Referencia", Referencia);
                    Cmd.Parameters.AddWithValue("ClienteID", ClienteID);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cCuentasCobrar> Lista = new List<cCuentasCobrar>();
                    while (Reader.Read())
                    {
                        cCuentasCobrar Cuenta = new cCuentasCobrar();
                        Cuenta.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Cuenta.ConceptoID = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.ClienteID = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.DocumentoID = Reader.IsDBNull(Reader.GetOrdinal("DocumentoID"))?null:Reader.GetString(Reader.GetOrdinal("DocumentoID"));
                        Cuenta.FacturaID = Reader.IsDBNull(Reader.GetOrdinal("FacturaID"))?-1:Reader.GetInt64(Reader.GetOrdinal("FacturaID"));
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

        public static cCuentasCobrar BuscarPorID(Int64 ID)
        {
            //Buscamos un movimiento especifico por el codigo unico de la base de datos
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarMovCxCporID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("CuentaID", ID);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();

                    cCuentasCobrar Cuenta = new cCuentasCobrar();
                    while (Reader.Read())
                    {
                        Cuenta.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Cuenta.ConceptoID = Reader.GetInt32(Reader.GetOrdinal("ConceptoID"));
                        Cuenta.ClienteID = Reader.GetInt64(Reader.GetOrdinal("ClienteID"));
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

        public static cCuentasCobrar BuscarPorID(String Documento)
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
                    string StoreProc = "uspBuscarCargosGeneralesporDocID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("DocumentoID", Documento);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();

                    cCuentasCobrar Cuenta = new cCuentasCobrar();
                    while (Reader.Read())
                    {
                        Cuenta.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Cuenta.ConceptoID = Reader.GetInt32(Reader.GetOrdinal("ConceptoID"));
                        Cuenta.ClienteID = Reader.GetInt64(Reader.GetOrdinal("ClienteID"));
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

        public static List<cCuentasCobrar> ListaDocumentosCxC(Int64 ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListaDocumentosCxC";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("ClienteID", ID);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cCuentasCobrar> Lista = new List<cCuentasCobrar>();
                    while (Reader.Read())
                    {
                        cCuentasCobrar Cuenta = new cCuentasCobrar();
                        Cuenta.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Cuenta.ConceptoID = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.ClienteID = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
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

        public static Boolean Existe(String Documento, Int64 ClienteID)
        {
            //Buscamos si un documento existe en la base de datos
            List<cCuentasCobrar> Cuenta=(from C in ListaCargosGenerales(ClienteID)
                                             where C.DocumentoID.ToString()==Documento
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
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspImpresionReciboCuentaCobrar";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("ID", ID);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();

                    List<cCuentasCobrar> Lista=new List<cCuentasCobrar>();

                    while (Reader.Read())
                    {

                        cCuentasCobrar Cuenta = new cCuentasCobrar();
                        Cuenta.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Cuenta.ConceptoID = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.ClienteID = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        //Cuenta.FacturaID = Reader.IsDBNull(Reader.GetOrdinal("FacturaID")) ? -1 : Reader.GetInt64(Reader.GetOrdinal("FacturaID"));
                        Cuenta.DocumentoID = Reader.IsDBNull(Reader.GetOrdinal("DocumentoID")) ? null : Reader.GetString(Reader.GetOrdinal("DocumentoID"));
                        Cuenta.ReferenciaID = Reader.IsDBNull(Reader.GetOrdinal("ReferenciaID")) ? null : Reader.GetString(Reader.GetOrdinal("ReferenciaID"));
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
            catch (SqlException Ex)
            {
                throw Ex;

            }

        }


        public static List<cCuentasCobrar> FiltrarCuentas(  Int32 IndicadorFechaEmision,
                                                            Int32 IndicadorFechaVencimiento,
                                                            Int32 IndicadorConcepto,
                                                            String CriterioMonto,
                                                            String CriterioBalance,
                                                            Decimal Monto,
                                                            Decimal Balance,
                                                            Int32 ConceptoID,
                                                            Int64 ClienteID,
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
                    string StoreProc = "uspFiltroCuentaCobrar";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("ClienteID", ClienteID);
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


                    List<cCuentasCobrar> Lista = new List<cCuentasCobrar>();
                    while (Reader.Read())
                    {
                        cCuentasCobrar Cuenta = new cCuentasCobrar();
                        Cuenta.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Cuenta.ConceptoID = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.ClienteID = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
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
                                                                    Int64 ClienteDesde,
                                                                    Int64 ClienteHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspReporteEstadoCuentaGeneralCliente";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("FechaCorte", FechaCorte);
                    Cmd.Parameters.AddWithValue("ClienteDesde", ClienteDesde);
                    Cmd.Parameters.AddWithValue("ClienteHasta", ClienteHasta);
                    Cmd.Parameters.AddWithValue("IndicadorCorte", IndicadorCorte);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteEstadoCuenta> Lista = new List<cReporteEstadoCuenta>();
                    while (Reader.Read())
                    {
                        cReporteEstadoCuenta Cuenta = new cReporteEstadoCuenta();
                        Cuenta.ClienteID = Reader.GetInt64(Reader.GetOrdinal("ClienteID"));
                        Cuenta.NombreCliente = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.Direccion = Reader.IsDBNull(Reader.GetOrdinal("Direccion")) ? null : Reader.GetString(Reader.GetOrdinal("Direccion"));
                        Cuenta.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia"))? null:  Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Cuenta.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Cuenta.RNC = Reader.GetString(Reader.GetOrdinal("RNC"));
                        Cuenta.Telefono = Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Cuenta.Fax = Reader.GetString(Reader.GetOrdinal("Fax"));
                        Cuenta.ContactoCobros = Reader.GetString(Reader.GetOrdinal("ContactoCobros"));
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
                                                                  Int64 ClienteDesde,
                                                                  Int64 ClienteHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspReporteEstadoCuentaDetalladoCliente";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("FechaCorte", FechaCorte);
                    Cmd.Parameters.AddWithValue("ClienteDesde", ClienteDesde);
                    Cmd.Parameters.AddWithValue("ClienteHasta", ClienteHasta);
                    Cmd.Parameters.AddWithValue("IndicadorCorte", IndicadorCorte);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteEstadoCuenta> Lista = new List<cReporteEstadoCuenta>();
                    while (Reader.Read())
                    {
                        cReporteEstadoCuenta Cuenta = new cReporteEstadoCuenta();
                        Cuenta.ClienteID = Reader.GetInt64(Reader.GetOrdinal("ClienteID"));
                        Cuenta.NombreCliente = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.Direccion = Reader.IsDBNull(Reader.GetOrdinal("Direccion")) ? null : Reader.GetString(Reader.GetOrdinal("Direccion"));
                        Cuenta.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia")) ? null : Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Cuenta.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Cuenta.RNC = Reader.GetString(Reader.GetOrdinal("RNC"));
                        Cuenta.Telefono = Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Cuenta.Fax = Reader.GetString(Reader.GetOrdinal("Fax"));
                        Cuenta.ContactoCobros = Reader.GetString(Reader.GetOrdinal("ContactoCobros"));
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
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspCobranzaGeneral";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("FechaCorte", FechaCorte);
                    Cmd.Parameters.AddWithValue("ClienteDesde", ClienteDesde);
                    Cmd.Parameters.AddWithValue("ClienteHasta", ClienteHasta);
                    Cmd.Parameters.AddWithValue("IndicadorCorte", IndicadorCorte);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteEstadoCuenta> Lista = new List<cReporteEstadoCuenta>();
                    while (Reader.Read())
                    {
                        cReporteEstadoCuenta Cuenta = new cReporteEstadoCuenta();
                        Cuenta.ClienteID = Reader.GetInt64(Reader.GetOrdinal("ClienteID"));
                        Cuenta.NombreCliente = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.Telefono = Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Cuenta.ContactoCobros = Reader.GetString(Reader.GetOrdinal("ContactoCobros"));
                        Cuenta.ConceptoID = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.DocumentoID = Reader.GetString(Reader.GetOrdinal("DocumentoID"));
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
                                                             Int64 ClienteDesde,
                                                             Int64 ClienteHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspAntiguedadSaldoCuenCobrar";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("FechaCorte", FechaCorte);
                    Cmd.Parameters.AddWithValue("ClienteDesde", ClienteDesde);
                    Cmd.Parameters.AddWithValue("ClienteHasta", ClienteHasta);
                    Cmd.Parameters.AddWithValue("FechaReferencia", FechaReferencia);
                    Cmd.Parameters.AddWithValue("IndicadorFecha",IndicadorFecha);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cAntiguedadSaldo> Lista = new List<cAntiguedadSaldo>();
                    while (Reader.Read())
                    {
                        cAntiguedadSaldo Cuenta = new cAntiguedadSaldo();
                        Cuenta.ID=Reader.GetInt64(Reader.GetOrdinal("ID"));
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
            catch (SqlException Ex)
            {
                throw Ex;

            }

        }

        public static List<cAntiguedadSaldoDetalle> AntiguedadSaldoDetalle(String IndicadorFecha,
                                                            DateTime FechaReferencia,
                                                            DateTime? FechaCorte,
                                                            Int64 ClienteDesde,
                                                            Int64 ClienteHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspAntiguedadSaldoCuenCobrarDetalle";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("FechaCorte", FechaCorte);
                    Cmd.Parameters.AddWithValue("ClienteDesde", ClienteDesde);
                    Cmd.Parameters.AddWithValue("ClienteHasta", ClienteHasta);
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
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspReportePorConceptoCuenCobrar";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("ClienteDesde", ClienteDesde);
                    Cmd.Parameters.AddWithValue("ClienteHasta", ClienteHasta);
                    Cmd.Parameters.AddWithValue("FechaInicial", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaFinal", FechaHasta);
                    Cmd.Parameters.AddWithValue("CriterioCantidad", CriterioCantidad);
                    Cmd.Parameters.AddWithValue("Conceptos", Conceptos);
                    Cmd.Parameters.AddWithValue("ValorMonto", ValorMonto);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cCuentasCobrar> Lista = new List<cCuentasCobrar>();
                    while (Reader.Read())
                    {
                        cCuentasCobrar Cuenta = new cCuentasCobrar();
                        Cuenta.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Cuenta.ConceptoID = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.ClienteID = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
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

        public static List<cReporteResumenCuentaCobrar> ReporteResumenCuentaCobrar(Int64? ClienteID,
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
                    string StoreProc = "uspResumenMovCuentaCobrar";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("ClienteID", ClienteID);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
  
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteResumenCuentaCobrar> Lista = new List<cReporteResumenCuentaCobrar>();
                    while (Reader.Read())
                    {
                        cReporteResumenCuentaCobrar Cuenta = new cReporteResumenCuentaCobrar();
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

        public static List<cReporteEstadoCuenta> ReporteResumenCuentaCobrarDetalle(Int64? ClienteID,
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
                    string StoreProc = "uspResumenMovCuentasCobrarDetalle";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("ClienteID", ClienteID);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteEstadoCuenta> Lista = new List<cReporteEstadoCuenta>();
                    while (Reader.Read())
                    {
                        cReporteEstadoCuenta Cuenta = new cReporteEstadoCuenta();
                        Cuenta.ClienteID = Reader.GetInt64(Reader.GetOrdinal("ClienteID"));
                        Cuenta.NombreCliente = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.Direccion = Reader.IsDBNull(Reader.GetOrdinal("Direccion")) ? null : Reader.GetString(Reader.GetOrdinal("Direccion"));
                        Cuenta.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia")) ? null : Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Cuenta.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Cuenta.RNC = Reader.GetString(Reader.GetOrdinal("RNC"));
                        Cuenta.Telefono = Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Cuenta.Fax = Reader.GetString(Reader.GetOrdinal("Fax"));
                        Cuenta.ContactoCobros = Reader.GetString(Reader.GetOrdinal("ContactoCobros"));
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

        public static List<cReporteEstadoCuenta> ReporteDocumentosPorCobrar(Int64? ClienteDesde, Int64? ClienteHasta, DateTime FechaCorte)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspReporteDocumentoPorCobrar";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("ClienteDesde", ClienteDesde);
                    Cmd.Parameters.AddWithValue("ClienteHasta", ClienteHasta);
                    Cmd.Parameters.AddWithValue("FechaCorte", FechaCorte);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteEstadoCuenta> Lista = new List<cReporteEstadoCuenta>();
                    while (Reader.Read())
                    {
                        cReporteEstadoCuenta Cuenta = new cReporteEstadoCuenta();
                        Cuenta.ClienteID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Cuenta.NombreCliente = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.ContactoCobros = Reader.IsDBNull(Reader.GetOrdinal("ContactoCobros")) ? null : Reader.GetString(Reader.GetOrdinal("ContactoCobros"));
                        Cuenta.ConceptoID = Reader.GetString(Reader.GetOrdinal("Concepto"));
                        Cuenta.DocumentoID = Reader.GetString(Reader.GetOrdinal("DocumentoID"));
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
            catch (SqlException Ex)
            {
                throw Ex;

            }

        }

        public static List<cReporteEstadoCuenta> ReporteAbonoPorPeriodo(DateTime FechaDesde,
                                                                    DateTime FechaHasta,
                                                                    DateTime? FechaCorte,
                                                                    Int64 ClienteDesde,
                                                                    Int64 ClienteHasta)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspAbonoPorPeriodoCuentaCobrar";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Variable
                    Cmd.Parameters.AddWithValue("FechaCorte", FechaCorte);
                    Cmd.Parameters.AddWithValue("ClienteDesde", ClienteDesde);
                    Cmd.Parameters.AddWithValue("ClienteHasta", ClienteHasta);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    //Ejecutamos el lector

                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cReporteEstadoCuenta> Lista = new List<cReporteEstadoCuenta>();
                    while (Reader.Read())
                    {
                        cReporteEstadoCuenta Cuenta = new cReporteEstadoCuenta();
                        Cuenta.ClienteID = Reader.GetInt64(Reader.GetOrdinal("ClienteID"));
                        Cuenta.NombreCliente = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cuenta.Direccion = Reader.IsDBNull(Reader.GetOrdinal("Direccion")) ? null : Reader.GetString(Reader.GetOrdinal("Direccion"));
                        Cuenta.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia")) ? null : Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Cuenta.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Cuenta.RNC = Reader.GetString(Reader.GetOrdinal("RNC"));
                        Cuenta.Telefono = Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Cuenta.Fax = Reader.GetString(Reader.GetOrdinal("Fax"));
                        Cuenta.ContactoCobros = Reader.GetString(Reader.GetOrdinal("ContactoCobros"));
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
    }
}
