using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using SMA.DA;

namespace SMA.BL
{
    public class FacturaBL
    {
        public List<cFactura> Listar(String TipoDocumento)
        {
            //Listamos los documentos por su tipo 
            /*
             * F= Facturas
             * C=Cotizaciones
             * D=Devoluciones
             */
            try
            {
                return FacturaDA.Listar(TipoDocumento);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public Int64 Crear(cFactura Factura)
        {
            try
            {
                //FACTURAS A CREDITO
                if (Factura.TipoDocumento == "F" && (String) Factura.CondicionVenta=="CE")
                {
                    //VALIDAMOS EL BALANCE DEL CLIENTE
                    //LIMITE DE CREDITO
                    decimal LimiteCredito = ClienteDA.BuscarPorID((Int32)Factura.ClienteID).LimiteCredito;
                //BALANCE ACTUAL DE CLIENTE
                    decimal Balance=ClienteDA.BuscarPorID((Int32)Factura.ClienteID).Balance;

                    if((Factura.TotalGeneral+Balance)<=LimiteCredito)
                    {
                        return FacturaDA.Crear(Factura);
                    }
                    else
                    {
                        throw new Exception("El cliente ha excedido el limite de credito permitido");
                    }
                }
                //DEVOLUCION Y COTIZACIONES
                else 
                {
                    return FacturaDA.Crear(Factura);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public cFactura BuscarPorID(Int64 DocumentoID,String TipoDocumento)
        {
            //Buscamos la factura por el numero de documento y tipo
            try
            {
                return FacturaDA.BuscarPorID(DocumentoID, TipoDocumento);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public List <cReporteFactura> Reporte(Int64 ID)
        {
            try
            {
                return FacturaDA.Reporte(ID);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public void Cancelar(Int32 FacturaID)
        {
            try
            {
                cFactura Factura=FacturaDA.BuscarPorID(FacturaID);
                //Si el documento no ha sido cambiado el estatus de Original no puede ser cancelado
                if (Factura.EstatusID.ToString() == "O")
                {
                    //Verificamos si la factura contiene movimientos en Cuentas por Cobrar
                    List<cCuentasCobrar> Cuenta = (from c in CuentaCobrarDA.ListaCargosPagos(Factura.DocumentoID.ToString(), (Int32)Factura.ClienteID)
                                                   where c.CodigoConcepto.ToString() != "Factura"
                                                   select c).ToList();
                    if(Cuenta.Count==0)
                    {
                        FacturaDA.Cancelar(FacturaID);
                    }
                    else
                    {
                        throw new Exception("El documento posee movimientos contabilizados, no puede ser cancelada");
                    }
                    
                }
                else
                {
                    throw new Exception("El documento posee movimientos contabilizados, no puede ser cancelada");
                }
            }
            catch(Exception Ex)
            {
                throw Ex;
            }

        }

        public List<cFactura> FiltrarFactura(String TipoDocumento,
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
            //Filtro de Facturas
            try
            {
                return FacturaDA.FiltrarFactura(TipoDocumento,ClienteID,DocumentoDesde,DocumentoHasta,FechaDesde,FechaHasta,IndGenerada,IndCancelada,IndDevuelta,CriterioCantidad,ValorFactura);
                                                
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }
        
       public List<cFactura> Filtrar(
                                            String TipoDocumento,
                                            Int32 ClienteID,
                                            Int64 DocumentoDesde,
                                            Int64 DocumentoHasta,
                                            DateTime FechaDesde,
                                            DateTime FechaHasta,
                                            Boolean IndGenerada,
                                            Boolean IndCancelada,
                                            Boolean IndFacturada)
        {
           //Filtro de Cotizaciones
           try
           {
               return FacturaDA.Filtrar(TipoDocumento, ClienteID, DocumentoDesde, DocumentoHasta, FechaDesde, FechaHasta, IndGenerada, IndCancelada, IndFacturada);
           }
           catch(Exception Ex)
           {
               throw Ex;
           }
        }

       public List<cFactura> Filtrar(
                                           String TipoDocumento,
                                           Int32 ClienteID,
                                           Int32 DocumentoDesde,
                                           Int32 DocumentoHasta,
                                           DateTime FechaDesde,
                                           DateTime FechaHasta,
                                           Boolean IndGenerada,
                                           Boolean IndCancelada)
       {
           //Filtro de Cotizaciones
           try
           {
               return FacturaDA.Filtrar(TipoDocumento, ClienteID, DocumentoDesde, DocumentoHasta, FechaDesde, FechaHasta, IndGenerada, IndCancelada);
           }
           catch (Exception Ex)
           {
               throw Ex;
           }
       }
       public List<cReporteResumenFactura> ResumenFactura(Int64? DocumentoDesde, 
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
                return FacturaDA.ResumenFacturas(DocumentoDesde, DocumentoHasta, FamiliaID, TipoArticulo, FechaDesde, FechaHasta, ClienteDesde, ClienteHasta,TipoDocumento, VendedorID);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cReporteFactura> ResumenNCF(DateTime FechaDesde, DateTime FechaHasta, Int64? ClienteDesde, Int64? ClienteHasta)
        {
            try
            {
                return FacturaDA.ResumenNCF(FechaDesde, FechaHasta, ClienteDesde,ClienteHasta);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public Int64 ControlDocumento(String TipoDocumento)
        {
            //Devuelve el ultimo numero de la secuencia de acuerdo al tipo de documento
            try
            {
               return FacturaDA.ControlDocumento(TipoDocumento);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cReporteResumenComisionVenta> ReporteComisionVenta(Int32? VendedorDesde, Int32? VendedorHasta, DateTime? FechaDesde, DateTime? FechaHasta)
        {
            try
            {
                return FacturaDA.ReporteComisionVenta(VendedorDesde, VendedorHasta, FechaDesde, FechaHasta);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }


        public List<cReporteComisionVentaDetalle> ReporteComisionVentaDetalle(Int32? VendedorDesde, Int32? VendedorHasta, DateTime? FechaDesde, DateTime? FechaHasta)
        {
            try
            {
                return FacturaDA.ReporteComisionVentaDetalle(VendedorDesde, VendedorHasta, FechaDesde, FechaHasta);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
       
         public  List<cReporteArticulosDevueltos> ReporteArticulosDevueltos(Int64? DocumentoDesde, 
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
                 return FacturaDA.ReporteArticulosDevueltos(DocumentoDesde, DocumentoHasta, FechaDesde, FechaHasta, CodigoCliente, VendedorID, CodigoArticulo, Familia, TipoArticulo);
             }
             catch(Exception Ex)
             {
                 throw Ex;
             }
        }

         public List<cReporteDetalladoDocumento> ReporteDetalladoDocumentos(Int32? DocumentoDesde, Int32? DocumentoHasta, DateTime? FechaCreacionDesde, 
                                                                             DateTime? FechaCreacionHasta, DateTime? FechaVencimientoDesde, DateTime? FechaVencimientoHasta, 
                                                                             Int32? ClienteDesde, Int32? ClienteHasta, String TipoDocumento, Int32? VendedorID)
         {
             try
             {
                 return FacturaDA.ReporteDetalladoDocumentos(DocumentoDesde, DocumentoHasta, FechaCreacionDesde, FechaCreacionHasta, FechaVencimientoDesde, FechaVencimientoHasta, ClienteDesde, ClienteHasta, TipoDocumento, VendedorID);
             }
             catch(Exception Ex)
             {
                 throw Ex;
             }
         }
    }
}
