using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using SMA.DA;

namespace SMA.BL
{
    public class DetalleFacturaBL
    {
        public void Crear(List<cDetalleFactura> ListaDetalle)
        {
            //Inserta el detalle de una factura 
            try
            {
                DetalleFacturaDA.Crear(ListaDetalle);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cDetalleFactura>ListarDetalle(Int64 FacturaID, 
                                                  String TipoDocumento)
        {
            //Devuelve el resultado de los detalles de una factura
            try
            {
                return DetalleFacturaDA.ListarDetalle(FacturaID, TipoDocumento);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cDetalleFactura> ListarDetalleDevolucion(String CodigoArticulo, Int64 DocumentoID)
        {
            try
            {
               return DetalleFacturaDA.ListarDetalleDevolucion(CodigoArticulo, DocumentoID);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
