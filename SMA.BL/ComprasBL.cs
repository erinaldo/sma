using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using SMA.DA;

namespace SMA.BL
{
    public class ComprasBL
    {
        public List<cCompras> Listar(String TipoDocumento)
        {
            try
            {
                return ComprasDA.Listar(TipoDocumento);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public static List<cCompras> Listar(String TipoDocumento,DateTime FechaDesde, DateTime FechaHasta)
        {
             try
             {
                 return ComprasDA.Listar(TipoDocumento, FechaDesde, FechaHasta);
             }
             catch(Exception Ex)
             {
                 throw Ex;
             }
        }

        public Int64 Crear(cCompras Compra)
        {
            try
            {
                return ComprasDA.Crear(Compra);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<cReporteFactura> Reporte(Int64 ID)
        {
            try
            {
                return ComprasDA.Reporte(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Cancelar(Int64 CompraID)
        {

            try
            {
                cCompras Factura = ComprasDA.BuscarPorID(CompraID);
                //Si el documento no ha sido cambiado el estatus de Original no puede ser cancelado
                if (Factura.EstatusID.ToString() == "O")
                {
                    //Verificamos si la factura contiene movimientos en Cuentas por Cobrar
                    List<cCuentasPagar> Cuenta = (from c in CuentaPagarDA.ListaCargosPagos(Factura.DocumentoID.ToString(), (Int64)Factura.ProveedorID)
                                                   where c.CodigoConcepto.ToString() != "Compras"
                                                   select c).ToList();
                    if (Cuenta.Count == 0)
                    {
                        ComprasDA.Cancelar(CompraID);
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
            catch (Exception Ex)
            {
                throw Ex;
            }


        }

        public List<cCompras> FiltrarRecepcion(String TipoDocumento,
                                           Int32? ProveedorID,
                                           Int32? DocumentoDesde,
                                           Int32? DocumentoHasta,
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
                return ComprasDA.FiltrarRecepcion(TipoDocumento,ProveedorID,DocumentoDesde,DocumentoHasta,FechaDesde,FechaHasta,CriterioCantidad,ValorFactura,IndGenerada,IndCancelada,IndDevuelta);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

         public  List<cCompras> Filtrar(
                                           String TipoDocumento,
                                           Int32? ProveedorID,
                                           Int32? DocumentoDesde,
                                           Int32? DocumentoHasta,
                                           DateTime? FechaDesde,
                                           DateTime? FechaHasta,
                                           String CriterioCantidad,
                                           Decimal ValorFactura,
                                           Boolean IndGenerada,
                                           Boolean IndCancelada,
                                           Boolean IndRecibida)
        {
             //FILTRO DE ORDENES DE COMPRAS
             try
             {
                 return ComprasDA.Filtrar(TipoDocumento, ProveedorID, DocumentoDesde,DocumentoHasta, FechaDesde, FechaHasta, CriterioCantidad,ValorFactura,IndGenerada, IndCancelada, IndRecibida);
             }
             catch(Exception Ex)
             {
                 throw Ex;
             }
        }


         public List<cCompras> Filtrar(
                                           String TipoDocumento,
                                           Int32? ProveedorID,
                                           Int32? DocumentoDesde,
                                           Int32? DocumentoHasta,
                                           DateTime? FechaDesde,
                                           DateTime? FechaHasta,
                                           String CriterioCantidad,
                                           Decimal ValorFactura,
                                           Boolean IndGenerada,
                                           Boolean IndCancelada)
         {
             //Filtro de Devoluciones
             try
             {
                 return ComprasDA.Filtrar(TipoDocumento,ProveedorID, DocumentoDesde, DocumentoHasta, FechaDesde, FechaHasta,CriterioCantidad,ValorFactura, IndGenerada, IndCancelada);
             }
             catch (Exception Ex)
             {
                 throw Ex;
             }
         }

        public List<cReporteFactura> ResumenNCF(DateTime FechaDesde, DateTime FechaHasta, Int32 ProveedorID)
        {
            try
            {
                return ComprasDA.ResumenNCF(FechaDesde, FechaHasta, ProveedorID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cReporteResumenFactura> ResumenCompras(Int32? DocumentoDesde, 
                                                Int32? DocumentoHasta, 
                                                Int32? FamiliaID, 
                                                DateTime? FechaDesde, 
                                                DateTime? FechaHasta, 
                                                Int32? ProveedorDesde, 
                                                Int32? ProveedorHasta, 
                                                String TipoDocumento)
        {
            try
            {
                return ComprasDA.ResumenCompras(DocumentoDesde, DocumentoHasta, FamiliaID, FechaDesde, FechaHasta, ProveedorDesde, ProveedorHasta, TipoDocumento);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public cCompras BuscarPorID(Int64 DocumentoID, String TipoDocumento)
        {
            //Busqueda de documento por numero de documento y por tipo
            try
            {
                return ComprasDA.BuscarPorID(DocumentoID, TipoDocumento);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public  List<cReporteArticulosDevueltos> ReporteArticulosDevueltos(Int32? DocumentoDesde, Int32? DocumentoHasta, DateTime? FechaDesde, DateTime? FechaHasta, Int32? CodigoProveedor, String CodigoArticulo, Int32? Familia)
        {
            try
            {
                return ComprasDA.ReporteArticulosDevueltos(DocumentoDesde, DocumentoHasta, FechaDesde, FechaHasta, CodigoProveedor, CodigoArticulo, Familia);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

    }
}
