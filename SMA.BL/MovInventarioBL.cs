using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using SMA.DA;


namespace SMA.BL
{
   public  class MovInventarioBL
    {
       public List<cMovInventario> Listar(Int64 ID)
       {
           return MovInventarioDA.Listar(ID);
       }

       public void GuardarCambios(cMovInventario Movimiento)
       {
           //Comprobamos si el movimiento existe, si existe entonces actualizamos la informacion
           //Si el movimiento no existe entonces lo insertamos
           if(MovInventarioDA.Existe(Movimiento.ID))
           {
               
               MovInventarioDA.Actualizar(Movimiento);
           }
           else
           {
         
                       MovInventarioDA.Crear(Movimiento);

           }
               
           
       }

 
       //private Boolean ValidacionAlmacenes(int Concepto, cMovInventario Movimiento)

       //{
       //    //Validamos que el movimiento sea interno
       //    Boolean MovimientoInterno = Convert.ToBoolean(ConcMovInventDA.BuscarPorID(Concepto).MovInterno);
           
       //    if (MovimientoInterno)
       //    {
       //        //Si el movimiento es interno debe indicar el almacen de destino
       //        if (Movimiento.AlmacenDestinoID == Movimiento.AlmacenOrigenID)
       //        {
       //            return false;
       //        }
       //        else
       //        {
       //            return true;
       //        }
       //    }
       //    else
       //    {
       //        return true;
       //    }
       //}

       private Boolean ValidacionExistencia(cMovInventario Movimiento)
       {

           return false;
           
           ////Validamos que el almacen tenga la cantidad necesaria para realizar el movimiento
           //if (ExistenciaAlmacenes(Movimiento) != -1)
           //{
           //    if (ExistenciaAlmacenes(Movimiento) >= Movimiento.Cantidad)
           //    {
           //        return true;
           //    }
           //    else
           //    {
           //        return false;
           //    }
           //}
           //else
           //{
           //    return true;
           //}
       }

       //private double ExistenciaAlmacenes(cMovInventario Movimiento)
       //{
       //    //Buscamos la existencia del articulo en el almacen de origen

       //    //Buscamos el detalle de concepto de movimiento
       //    cConcMovInvent Concepto = ConcMovInventDA.BuscarPorID(Convert.ToInt32(Movimiento.ConceptoID));

       //    //int AlmacenDestino=Convert.ToInt32(Movimiento.AlmacenDestinoID);

       //    //ID del Articulo en inventario
       //    int InventarioID = Convert.ToInt32(Movimiento.InventarioID);

       //    //Si el concepto es de salida entonces buscamos el almacen de origen para verificar que existe la cantidad
       //    //necesaria para realizar el movimiento
       //    if (Convert.ToBoolean(Concepto.Entrada) == false)
       //    {
       //        //Almacen de origen del movimiento
       //        int AlmacenOrigen = Convert.ToInt32(Movimiento.AlmacenOrigenID);

       //        //Buscamos la existencia del articlo en el almacen de origen
       //        return RelacionAlmacenDA.ExistenciaAlmacen(InventarioID, AlmacenOrigen);
       //    }
       //    else
       //    {
       //        return -1;
       //    }
       //}

       public cMovInventario BuscarPorID(int MovimientoID)
       {

           try
           {
               return MovInventarioDA.BuscarPorID(MovimientoID);
           }
           catch(Exception Ex)
           {
               throw Ex;
           }
       }

       public List<cReporteMovimientoInventario> ReporteMovimientoInventario(String CodigoDesde, String CodigoHasta,DateTime? FechaDesde, DateTime? FechaHasta,
                                                                                     Int64? DocumentoDesde, Int64? DocumentoHasta, Int32? Familia, String Movimiento, String Cliente, String Proveedor)
       {
           try
           {
               return MovInventarioDA.ReporteMovimientoInventario(CodigoDesde, CodigoHasta, FechaDesde, FechaHasta, DocumentoDesde, DocumentoHasta, Familia, Movimiento,Cliente,Proveedor);
           }
           catch(Exception Ex)
           {
               throw Ex;
           }
       }

       public List<cReporteKardexInventario> ReporteKardexInventario(String CodigoDesde, String CodigoHasta, Int32? Familia)
       {
           try
           {
               return MovInventarioDA.ReporteKardexInventario(CodigoDesde, CodigoHasta, Familia);
           }
           catch(Exception Ex)
           {
               throw Ex;
           }
       }

       public List<cReporteRotacionInventario> ReporteRotacionInventario(String CodigoDesde, String CodigoHasta,DateTime? FechaDesde, DateTime? FechaHasta, 
                                                                                     Int32? DocumentoDesde, Int32? DocumentoHasta, Int32? Familia, String Movimiento)
       {
           try
           {
               return MovInventarioDA.ReporteRotacionInventario(CodigoDesde, CodigoHasta, FechaDesde, FechaHasta, DocumentoDesde, DocumentoHasta, Familia, Movimiento);
           }
           catch(Exception Ex)
           {
               throw Ex;
           }
       }

       public List<cReporteUtilidadVentas> ReporteUtilidadVentas(String CodigoDesde, String CodigoHasta, DateTime? FechaDesde, DateTime? FechaHasta,
                                                                                     Int32? DocumentoDesde, Int32? DocumentoHasta, Int32? Familia, String Movimiento)
       {
           try
           {
               return MovInventarioDA.ReporteUtilidadVentas(CodigoDesde, CodigoHasta, FechaDesde, FechaHasta, DocumentoDesde, DocumentoHasta, Familia, Movimiento);
           }
           catch (Exception Ex)
           {
               throw Ex;
           }
       }

       public List<cReporteVentasPorCliente> ReporteVentasporCliente(String CodigoDesde, String CodigoHasta,
                                                                                     DateTime? FechaDesde, DateTime? FechaHasta, 
                                                                                     Int32? DocumentoDesde, Int32? DocumentoHasta, 
                                                                                     Int32? Familia, String Movimiento, Int32? ClienteDesde, 
                                                                                     Int32? ClienteHasta)
       {
           try
           {
               return MovInventarioDA.ReporteVentasPorCliente(CodigoDesde, CodigoHasta, FechaDesde, FechaHasta, DocumentoDesde, DocumentoHasta, Familia, Movimiento, ClienteDesde, ClienteHasta);
           }
           catch(Exception Ex)
           {
               throw Ex;
           }
       }

        public List<cReporteVentasPorClienteDetalle> ReporteVentasporClienteDetalle(String CodigoDesde, String CodigoHasta,
                                                                                     DateTime? FechaDesde, DateTime? FechaHasta, 
                                                                                     Int32? DocumentoDesde, Int32? DocumentoHasta, 
                                                                                     Int32? Familia, String Movimiento, Int32? ClienteDesde, 
                                                                                     Int32? ClienteHasta)
       {
            try
            {
                return MovInventarioDA.ReporteVentasPorClienteDetalle(CodigoDesde, CodigoHasta, FechaDesde, FechaHasta, DocumentoDesde, DocumentoHasta, Familia, Movimiento, ClienteDesde, ClienteHasta);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
       }


        public List<cReporteVentasPorCliente> ReporteComprasPorProveedor(String CodigoDesde, String CodigoHasta,
                                                                                      DateTime? FechaDesde, DateTime? FechaHasta,
                                                                                      Int32? DocumentoDesde, Int32? DocumentoHasta,
                                                                                      Int32? Familia, String Movimiento, Int32? ProveedorDesde,
                                                                                      Int32? ProveedorHasta)
        {
            try
            {
                return MovInventarioDA.ReporteComprasPorProveedor(CodigoDesde, CodigoHasta, FechaDesde, FechaHasta, DocumentoDesde, DocumentoHasta, Familia, Movimiento, ProveedorDesde, ProveedorHasta);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cReporteVentasPorClienteDetalle> ReporteComprasPorProveedorDetalle(String CodigoDesde, String CodigoHasta,
                                                                                      DateTime? FechaDesde, DateTime? FechaHasta,
                                                                                      Int32? DocumentoDesde, Int32? DocumentoHasta,
                                                                                      Int32? Familia, String Movimiento, Int32? ProveedorDesde,
                                                                                      Int32? ProveedorHasta)
        {
            try
            {
                return MovInventarioDA.ReporteComprasPorProveedorDetalle(CodigoDesde, CodigoHasta, FechaDesde, FechaHasta, DocumentoDesde, DocumentoHasta, Familia, Movimiento, ProveedorDesde, ProveedorHasta);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

       public  List<cReporteHistoricoExistencia> ReporteHistoricoExistencias(String CodigoDesde, String CodigoHasta,
                                                                            DateTime? FechaDesde, DateTime? FechaHasta,
                                                                            Int32? Familia, String Movimiento)
        {
           try
           {
               return MovInventarioDA.ReporteHistoricoExistencias(CodigoDesde, CodigoHasta, FechaDesde, FechaHasta, Familia, Movimiento);
           }
           catch(Exception Ex)
           {
               throw Ex;
           }
        }

       public  List<cInventario> ReporteProductosObsoletos(Int32? Familia, Int32? Marca, DateTime Fecha)
       {
           try
           {
               return MovInventarioDA.ReporteProductosObsoletos(Familia, Marca, Fecha);
           }
           catch(Exception Ex)
           {
               throw Ex;
           }
       }

       

    }
}
