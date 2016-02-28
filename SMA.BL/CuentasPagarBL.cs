using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using SMA.DA;

namespace SMA.BL
{
    public class CuentasPagarBL
    {
        public List<cCuentasPagar> ListarCargosGenerales(Int64 ID)
        {
            try
            {
                //Retornamos la lista de cargos generales que no posee referencia
                return CuentaPagarDA.ListaCargosGenerales(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cCuentasPagar> ListaPagoCargos(String Referencia,Int64 ProveedorID)
        {
            if (Referencia != null)
            {
                try
                {
                    return CuentaPagarDA.ListaCargosPagos(Referencia,ProveedorID);
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

        public void GuardarCambios(cCuentasPagar Cuenta)
        {
            try
            {
                if (ValidacionDocumentos(Cuenta))
                {
                    //Si el almacen existe entonces actualizamos 
                    if (CuentaPagarDA.Existe(Cuenta.ID))
                    {
                        CuentaPagarDA.Actualizar(Cuenta);
                    }


                    else
                    //Si el almacen es nuevo entonces creamos
                    {

                        if ((CuentaPagarDA.Existe(Cuenta.DocumentoID.ToString(), (Int32)Cuenta.ProveedorID))==false || (ConcCxPDA.BuscarPorID((Int32)Cuenta.ConceptoID).Referencia == "S"))
                        {
                            if (ValidacionReferencia(Cuenta))
                            {
                                CuentaPagarDA.Crear(Cuenta);
                            }
                        }
                       
                        else
                        {
                            throw new Exception("El documento ya existe para el proveedor seleccionado, favor revise nuevamente");
                        }

                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        private Boolean ValidacionDocumentos(cCuentasPagar Cuenta)
        {
            //Validacion de documento vacio
            if (Cuenta.DocumentoID.ToString() == String.Empty)
            {
                throw new Exception("Debe especificar un numero de documento");
            }
            else
            {
                return true;
            }


        }
        private Boolean ValidacionReferencia(cCuentasPagar Cuenta)
        {
            //Validamos si la referencia existe en caso de que el concepto asi lo requiera 
            Int32 Concepto = Convert.ToInt32(Cuenta.ConceptoID);
            if (ConcCxPDA.BuscarPorID(Concepto).Referencia == "S")
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
        public List<cCuentasPagar> ListaDocumentosCxP(Int64 ID)
        {
            try
            {
                return CuentaPagarDA.ListaDocumentosCxP(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public cCuentasPagar BuscarPorID(Int64 ID)
        {
            //Buscamos un movimiento especifico por el ID de la base de datos
            try
            {
                return CuentaPagarDA.BuscarPorID(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public cCuentasPagar BuscarPorID(String DocumentoID)
        {
            //Buscamos un cargo general por el documento que lo identifica
            try
            {
                cCuentasPagar Cuenta = CuentaPagarDA.BuscarPorID(DocumentoID);
                //Int64 Codigo; //Variable de comprobacion

                //Validamos que retornamos un valor no nulo
                if (Cuenta.ID == 0)
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

        public void CancelarDocumento(cCuentasPagar Cuenta)
        {
            //Cancelacion de un abono
            //Localizamos el concepto para verificar el tipo
            cConcepto Concepto = ConcCxPDA.BuscarPorID((Int32)Cuenta.ConceptoID);

            //Tipo Abono
            if (Concepto.Tipo.ToString() == "A")
            {
                //Verificamos si el documento es tipo Nota de Credito y si esta cancelado
                if (Concepto.Descripcion.ToString() == "Nota de Credito")
                {
                    //Documento Nota de Credito
                    cCompras stNotaCredito = ComprasDA.BuscarPorID(Cuenta.FacturaID, "D");
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
                if (Concepto.Descripcion.ToString() == "Compras")
                {
                    cCompras stFactura = ComprasDA.BuscarPorID(Cuenta.FacturaID, "R");

                    //Si la factura esta cancelada cancelamos la transaccion
                    if (stFactura.EstatusID.ToString() == "C")
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
                    List<cCuentasPagar> ListaPagos = (from c in ListaPagoCargos(Cuenta.FacturaID.ToString(), (Int64)Cuenta.ProveedorID)
                                                       select c).ToList();

                    //Si tiene Cargos o pagos relacionados
                    if (ListaPagos.Count == 0)
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

        public List<cCuentasPagar> FiltrarCuentas(Nullable<Int32> IndicadorFechaEmision,
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
                return CuentaPagarDA.FiltrarCuentas(IndicadorFechaEmision, IndicadorFechaVencimiento, IndicadorConcepto, CriterioMonto, CriterioBalance, Monto, Balance, ConceptoID, ProveedorID, FechaDesde, FechaHasta);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cReporteEstadoCuenta> EstadoCuentaGeneral(DateTime FechaDesde,
                                                                    DateTime FechaHasta,
                                                                    DateTime FechaCorte,
                                                                    Int32 IndicadorCorte,
                                                                    Int32 ProveedorDesde,
                                                                    Int32 ProveedorHasta)
        {

            //Arroja el reporte estado de cuenta general para un cliente o grupos de clientes
            try
            {
                return CuentaPagarDA.EstadoCuentaGeneral(FechaDesde, FechaHasta, FechaCorte, IndicadorCorte, ProveedorDesde, ProveedorHasta);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cReporteEstadoCuenta> EstadoCuentaDetallado(DateTime FechaDesde,
                                                                   DateTime FechaHasta,
                                                                   DateTime FechaCorte,
                                                                   Int32 IndicadorCorte,
                                                                   Int32 ProveedorDesde,
                                                                   Int32 ProveedorHasta)
        {

            //Arroja el reporte estado de cuenta general para un cliente o grupos de clientes
            try
            {
                return CuentaPagarDA.EstadoCuentaDetallado(FechaDesde, FechaHasta, FechaCorte, IndicadorCorte, ProveedorDesde, ProveedorHasta);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public List<cCuentasPagar> ReportePorConcepto(Int64 ProveedorDesde,
                                                            Int64 ProveedorHasta,
                                                            DateTime? FechaDesde,
                                                            DateTime? FechaHasta,
                                                            String CriterioCantidad,
                                                            String Conceptos,
                                                            Double ValorMonto)
        {
            try
            {
                return CuentaPagarDA.ReportePorConcepto(ProveedorDesde, ProveedorHasta, FechaDesde, FechaHasta, CriterioCantidad, Conceptos, ValorMonto);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cReporteResumenCuentaPagar> ResumenCuentaPagar(Int32? ProveedorID,
                                                             DateTime? FechaDesde,
                                                             DateTime? FechaHasta)
        {
            //Resumen de cuentas por pagar
            try
            {
                return CuentaPagarDA.ReporteResumenCuentaPagar(ProveedorID, FechaDesde, FechaHasta);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public  List<cReporteEstadoCuentaPagar> ReporteResumenCuentaPagarDetalle(Int32? ProveedorID,
                                                            DateTime? FechaDesde,
                                                            DateTime? FechaHasta)
        {
            //RESUMEN DETALLADO DE CUENTAS POR PAGAR
            try
            {
                return CuentaPagarDA.ReporteResumenCuentaPagarDetalle(ProveedorID, FechaDesde, FechaHasta);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cReporteEstadoCuentaPagar> ReportePagosPorPeriodo(DateTime FechaDesde,
                                                                 DateTime FechaHasta,
                                                                 DateTime? FechaCorte,
                                                                 Int32 ProveedorDesde,
                                                                 Int32 ProveedorHasta)
        
        {
            try
            {
                return CuentaPagarDA.ReportePagosPorPeriodo(FechaDesde, FechaHasta, FechaCorte, ProveedorDesde, ProveedorHasta);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cAntiguedadSaldo> AntiguedadSaldo(String IndicadorFecha,
                                                             DateTime FechaReferencia,
                                                             DateTime? FechaCorte,
                                                             Int64 ProveedorDesde,
                                                             Int64 ProveedorHasta)
        {
            try
            {
                return CuentaPagarDA.AntiguedadSaldo(IndicadorFecha, FechaReferencia, FechaCorte, ProveedorDesde, ProveedorHasta);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cAntiguedadSaldoDetalle> AntiguedadSaldoDetalle(String IndicadorFecha,
                                                             DateTime FechaReferencia,
                                                             DateTime? FechaCorte,
                                                             Int64 ProveedorDesde,
                                                             Int64 ProveedorHasta)
        {
            try
            {
                return CuentaPagarDA.AntiguedadSaldoDetalle(IndicadorFecha, FechaReferencia, FechaCorte, ProveedorDesde, ProveedorHasta);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
