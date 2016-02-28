using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using SMA.DA;

namespace SMA.BL
{
    public class CuentasCobrarBL
    {
        public  List<cCuentasCobrar> ListarCargosGenerales(Int64 ID)
        {
            try
            {
                //Retornamos la lista de cargos generales que no posee referencia
                return CuentaCobrarDA.ListaCargosGenerales(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cCuentasCobrar> ListaPagoCargos(String Referencia,Int64 ClienteID)
        {
            if (Referencia!=null)
            {
                try
                {
                    return CuentaCobrarDA.ListaCargosPagos(Referencia,ClienteID);
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
            else
            {
                return null;
            }
        }

        public void GuardarCambios(cCuentasCobrar Cuenta)
        {
            try
            {
                if (ValidacionDocumentos(Cuenta))
                {
                    //Si el almacen existe entonces actualizamos 
                    if (CuentaCobrarDA.Existe(Cuenta.ID))
                    {
                        CuentaCobrarDA.Actualizar(Cuenta);
                    }
                    else
                    //Si el almacen es nuevo entonces creamos
                    {
                       
                            if ((CuentaCobrarDA.Existe(Cuenta.DocumentoID.ToString(), (Int64)Cuenta.ClienteID))==false || (ConcCxCDA.BuscarPorID((Int32)Cuenta.ConceptoID).Referencia == "S"))

                            {
                                if (ValidacionReferencia(Cuenta))
                                {
                                    CuentaCobrarDA.Crear(Cuenta);
                                }
                            }
                            else
                            {
                                throw new Exception("El documento ya existe para el cliente seleccionado, favor revise nuevamente");
                            }
                        
                        
                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        private Boolean ValidacionDocumentos(cCuentasCobrar Cuenta)

        {
            //Validacion de documento vacio
            if(Cuenta.DocumentoID==null)
            {
                throw new Exception("Debe especificar un numero de documento");
            }
            else
            {
                return true;
            }

           
        }

        private Boolean ValidacionReferencia(cCuentasCobrar Cuenta)
        {
            //Validamos si la referencia existe en caso de que el concepto asi lo requiera 
            Int32 Concepto =Convert.ToInt32(Cuenta.ConceptoID);
            if (ConcCxCDA.BuscarPorID(Concepto).Referencia == "S")
            {
                if (Cuenta.ReferenciaID.ToString() != String.Empty)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Error al guardar movimiento, Debe especificar la referencia del movimiento");
                }
            }
            else
            {
                return true;
            }
        }

        public List<cCuentasCobrar> ListaDocumentosCxC(Int64 ID)
        {
            try
            {
                return CuentaCobrarDA.ListaDocumentosCxC(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public cCuentasCobrar BuscarPorID(Int64 ID)
        {
            //Buscamos un movimiento especifico por el ID de la base de datos
            try
            {
                return CuentaCobrarDA.BuscarPorID(ID);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public cCuentasCobrar BuscarPorID(String DocumentoID)
        {
            //Buscamos un cargo general por el documento que lo identifica
            try
            {
                cCuentasCobrar Cuenta = CuentaCobrarDA.BuscarPorID(DocumentoID);
                Int64 Codigo; //Variable de comprobacion

                //Validamos que retornamos un valor no nulo
                if(Cuenta.ID==0)
                {
                    //Retornamos un error si no existe resultado
                    throw new Exception("El documento seleccionada no existe, favor verificar");
                    
                }
                else
                {
                    return Cuenta;
                }
                
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cCuentasCobrar> ImpresionComprobanteAbono(Int64 ID)
        {
            //informacion para el reporte de recibo de cuentas por cobrar
            try
            {

               return CuentaCobrarDA.ImpresionComprobanteAbono(ID);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public void CancelarDocumento(cCuentasCobrar Cuenta)
        {
            //Cancelacion de un abono
            //Localizamos el concepto para verificar el tipo
            cConcepto Concepto = ConcCxCDA.BuscarPorID((Int32)Cuenta.ConceptoID);

            //Tipo Abono
            if(Concepto.Tipo.ToString()=="A")
            {
                //Verificamos si el documento es tipo Nota de Credito y si esta cancelado
                if (Concepto.Descripcion.ToString() == "Nota de Credito")
                {
                    //Documento Nota de Credito
                    cFactura stNotaCredito = FacturaDA.BuscarPorID(Cuenta.FacturaID, "D");
                    //Verificamos Si esta Cancelado
                    if (stNotaCredito.EstatusID.ToString() == "C")
                    {
                        //Cancelamos la transaccion
                        Cuenta.Estatus = false;
                        GuardarCambios(Cuenta);
                    }
                    else
                    {
                        throw new Exception("El documento no puede ser cancelado, la nota de credito se encuentra vigente en el sistema");
                    }
                }
                else
                {
                    //Si es un Abono cancelamos la transaccion
                    Cuenta.Estatus = false;
                    GuardarCambios(Cuenta);
                }
            }
            else
            {
                //Verificamos el estatus de la factura en caso de que sea
                if(Concepto.Descripcion.ToString()=="Factura")
                {
                    cFactura stFactura = FacturaDA.BuscarPorID(Cuenta.FacturaID, "F");
                   
                    //Si la factura esta cancelada cancelamos la transaccion
                    if(stFactura.EstatusID.ToString()=="C")
                    {
                        Cuenta.Estatus = false;
                        GuardarCambios(Cuenta);
                    }
                    else
                    {
                        throw new Exception("El documento no puede ser cancelado, la factura se encuentra vigente en el sistema");
                    }
                }
                else
                {
                    //Si es un cargo aplicado verificamos que no tenga pagos vigentes
                    List<cCuentasCobrar> ListaPagos=(from c in ListaPagoCargos(Cuenta.FacturaID.ToString(),(Int64)Cuenta.ClienteID)
                                                     select c).ToList();

                    //Si tiene Cargos o pagos relacionados
                    if(ListaPagos.Count==0)
                    {
                        Cuenta.Estatus = false;
                        GuardarCambios(Cuenta);
                    }
                    else
                    {
                        throw new Exception("El documento no puede ser cancelado, el documento contiene pagos o cargos aplicados");
                    }
                }
            }
        }

        public List<cCuentasCobrar> FiltrarCuentas( Int32 IndicadorFechaEmision,
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
                return CuentaCobrarDA.FiltrarCuentas(IndicadorFechaEmision, IndicadorFechaVencimiento, IndicadorConcepto, CriterioMonto, CriterioBalance, Monto, Balance, ConceptoID, ClienteID, FechaDesde, FechaHasta);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cReporteEstadoCuenta> EstadoCuentaGeneral(DateTime FechaDesde,
                                                                    DateTime FechaHasta,
                                                                    DateTime FechaCorte,
                                                                    Int32 IndicadorCorte,
                                                                    Int64 ClienteDesde,
                                                                    Int64 ClienteHasta)
        {

            //Arroja el reporte estado de cuenta general para un cliente o grupos de clientes
            try
            {
                return CuentaCobrarDA.EstadoCuentaGeneral(FechaDesde, FechaHasta, FechaCorte, IndicadorCorte, ClienteDesde, ClienteHasta);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cReporteEstadoCuenta> EstadoCuentaDetallado(DateTime FechaDesde,
                                                                   DateTime FechaHasta,
                                                                   DateTime FechaCorte,
                                                                   Int32 IndicadorCorte,
                                                                   Int64 ClienteDesde,
                                                                   Int64 ClienteHasta)
        {

            //Arroja el reporte estado de cuenta general para un cliente o grupos de clientes
            try
            {
                return CuentaCobrarDA.EstadoCuentaDetallado(FechaDesde, FechaHasta, FechaCorte, IndicadorCorte, ClienteDesde, ClienteHasta);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cReporteEstadoCuenta> CobranzaGeneral(DateTime FechaDesde,
                                                                   DateTime FechaHasta,
                                                                   DateTime FechaCorte,
                                                                   Int32 IndicadorCorte,
                                                                   Int64 ClienteDesde,
                                                                   Int64 ClienteHasta)
        {

            //Arroja el reporte de cobranza general
            try
            {
                return null;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cAntiguedadSaldo> AntiguedadSaldo(String IndicadorFecha,
                                                             DateTime FechaReferencia,
                                                             DateTime? FechaCorte,
                                                             Int64 ClienteDesde,
                                                             Int64 ClienteHasta)
        {
            try
            {
               return CuentaCobrarDA.AntiguedadSaldo(IndicadorFecha, FechaReferencia, FechaCorte, ClienteDesde, ClienteHasta);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cAntiguedadSaldoDetalle> AntiguedadSaldoDetalle(String IndicadorFecha,
                                                             DateTime FechaReferencia,
                                                             DateTime? FechaCorte,
                                                             Int64 ClienteDesde,
                                                             Int64 ClienteHasta)
        {
            try
            {
                return CuentaCobrarDA.AntiguedadSaldoDetalle(IndicadorFecha, FechaReferencia, FechaCorte, ClienteDesde, ClienteHasta);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cCuentasCobrar> ReportePorConcepto(Int64? ClienteDesde,
                                                              Int64? ClienteHasta,
                                                              DateTime? FechaDesde,
                                                              DateTime? FechaHasta,
                                                              String CriterioCantidad,
                                                              String Conceptos,
                                                              Decimal ValorMonto)
        {
             try
             {
                 return CuentaCobrarDA.ReportePorConcepto(ClienteDesde, ClienteHasta, FechaDesde, FechaHasta, CriterioCantidad, Conceptos, ValorMonto);
             }
             catch(Exception Ex)
             {
                 throw Ex;
             }
        }

        public List<cReporteResumenCuentaCobrar> ReporteResumenCuentaCobrar(Int64? ClienteID,
                                                             DateTime? FechaDesde,
                                                             DateTime? FechaHasta)
         {
            try
            {
                return CuentaCobrarDA.ReporteResumenCuentaCobrar(ClienteID, FechaDesde, FechaHasta);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
         }

        public List<cReporteEstadoCuenta> ReporteResumenCuentaCobrarDetalle(Int64? ClienteID,
                                                            DateTime? FechaDesde,
                                                            DateTime? FechaHasta)
        {
            try
            {
                return CuentaCobrarDA.ReporteResumenCuentaCobrarDetalle(ClienteID, FechaDesde, FechaHasta);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cReporteEstadoCuenta> ReporteDocumentosPorCobrar(Int64? ClienteDesde, Int64? ClienteHasta, DateTime FechaCorte)
        {
            try
            {
                return CuentaCobrarDA.ReporteDocumentosPorCobrar(ClienteDesde, ClienteHasta, FechaCorte);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cReporteEstadoCuenta> ReporteAbonoPorPeriodo(DateTime FechaDesde,
                                                                    DateTime FechaHasta,
                                                                    DateTime? FechaCorte,
                                                                    Int64 ClienteDesde,
                                                                    Int64 ClienteHasta)
        {

            //Arroja el reporte estado de cuenta general para un cliente o grupos de clientes
            try
            {
                return CuentaCobrarDA.ReporteAbonoPorPeriodo(FechaDesde, FechaHasta, FechaCorte,ClienteDesde,ClienteHasta);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
