using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.DA;
using SMA.Entity;

namespace SMA.BL
{
   public class DetalleCompraBL
    {
       public void Crear(List<cDetalleCompra> ListaDetalle)
       {
           try
           {
               DetalleCompraDA.Crear(ListaDetalle);
           }
           catch (Exception Ex)
           {
               throw Ex;
           }
       }

       public List<cDetalleCompra> ListarDetalle(Int64 CompraID, String TipoDocumento)
       {
           //Devuelve el resultado de los detalles de una factura
           try
           {
               return DetalleCompraDA.ListarDetalle(CompraID, TipoDocumento);
           }
           catch (Exception Ex)
           {
               throw Ex;
           }
       }

       public List<cDetalleCompra> ListarDetalleDevolucion(String CodigoArticulo, Int64 DocumentoID)
       {
           //Devuelve el articulo si pertenece al documento de referencia de recepcion
           try
           {
               return DetalleCompraDA.ListarDetalleDevolucion(CodigoArticulo, DocumentoID);
           }
           catch (Exception Ex)
           {
               throw Ex;
           }
       }
    }
}
