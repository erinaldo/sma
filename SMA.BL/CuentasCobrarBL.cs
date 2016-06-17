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
        public  List<cCuentasCobrar> ListarCargosGenerales(Int32 CodigoCliente)
        {
            try
            {
                //Retornamos la lista de cargos generales que no posee referencia
                ///<remarks>
                ///La lista de cargos generales son escencialmente cargos que no tienen referencia
                ///osea son los cargos a los que se les hace referencia
                ///</remarks
                return CuentaCobrarDA.ListaCargosGenerales(CodigoCliente);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cCuentasCobrar> ListaPagoCargos(String CodigoReferencia,Int32 CodigoCliente)
        {
            if (CodigoReferencia!=null)
            {
                try
                {
                    return CuentaCobrarDA.ListaCargosPagos(CodigoReferencia,CodigoCliente);
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
                    if (CuentaCobrarDA.Existe(Cuenta.Codigo))
                    {
                        CuentaCobrarDA.Actualizar(Cuenta);
                    }
                    else
                    //Si el almacen es nuevo entonces creamos
                    {
                       
                            if ((CuentaCobrarDA.Existe(Cuenta.CodigoDocumento.ToString(), (Int32)Cuenta.CodigoCliente))==false || (ConcCxCDA.BuscarPorID((Int16)Cuenta.CodigoConcepto).Referencia == "S"))

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
            if(Cuenta.CodigoDocumento==null)
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
            Byte Concepto =Convert.ToByte(Cuenta.CodigoConcepto);
            if (ConcCxCDA.BuscarPorID(Concepto).Referencia == "S")
            {
                if (Cuenta.CodigoReferencia.ToString() != String.Empty)
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

        public List<cCuentasCobrar> ListaDocumentosCxC(Int32 ID)
        {
            //CARGAMOS LOS DOCUMENTOS DE CUENTAS POR COBRAR CON BALANCE MAYOR A 0
            try
            {
                return CuentaCobrarDA.ListaDocumentosCxC(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public cCuentasCobrar BuscarPorID(Int32 ID)
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
                Int32 Codigo; //Variable de comprobacion

                //Validamos que retornamos un valor no nulo
                if(Cuenta.Codigo==0)
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

        public List<cCuentasCobrar> ImpresionComprobanteAbono(Int32 ID)
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
            cConcepto Concepto = ConcCxCDA.BuscarPorID((Int16)Cuenta.CodigoConcepto);

            //Tipo Abono
            if(Concepto.Tipo.ToString()=="A")
            {
                //Verificamos si el documento es tipo Nota de Credito y si esta cancelado
                if (Concepto.Descripcion.ToString() == "Nota de Credito")
                {
                    //Documento Nota de Credito
                    cFactura stNotaCredito = FacturaDA.BuscarPorID(Cuenta.CodigoFactura, "D");
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
                    cFactura stFactura = FacturaDA.BuscarPorID(Cuenta.CodigoFactura, "F");
                   
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
                    List<cCuentasCobrar> ListaPagos=(from c in ListaPagoCargos(Cuenta.CodigoFactura.ToString(),(Int32)Cuenta.CodigoCliente)
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

        public List<cCuentasCobrar> FiltrarCuentas( Int16 IndicadorFechaEmision,
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
                                                                    Int32 ClienteDesde,
                                                                    Int32 ClienteHasta)
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
                                                                   Int16 IndicadorCorte,
                                                                   Int32 ClienteDesde,
                                                                   Int32 ClienteHasta)
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
                                                             Int32 ClienteDesde,
                                                             Int32 ClienteHasta)
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
                                                             Int32 ClienteDesde,
                                                             Int32 ClienteHasta)
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

        public List<cCuentasCobrar> ReportePorConcepto(Int32 ClienteDesde,
                                                              Int32 ClienteHasta,
                                                              DateTime FechaDesde,
                                                              DateTime FechaHasta,
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

        public List<cReporteResumenCuentaCobrar> ReporteResumenCuentaCobrar(Int32? ClienteID,
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

        public List<cReporteEstadoCuenta> ReporteResumenCuentaCobrarDetalle(Int32? ClienteID,
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

        public List<cReporteEstadoCuenta> ReporteDocumentosPorCobrar(Int32? ClienteDesde, Int32? ClienteHasta, DateTime FechaCorte)
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
                                                                    Int32 ClienteDesde,
                                                                    Int32 ClienteHasta,
                                                                    Int16 IndicadorCorte)
        {

            //Arroja el reporte estado de cuenta general para un cliente o grupos de clientes
            try
            {
                return CuentaCobrarDA.ReporteAbonoPorPeriodo(FechaDesde, FechaHasta, FechaCorte,ClienteDesde,ClienteHasta,IndicadorCorte);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
