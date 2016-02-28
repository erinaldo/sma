using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Factura.Reportes
{
   public interface IBusqueda
    {
       void SeleccionarDocumentoDesde(Int32 Documento);     //Seleccion de Documento en busqueda
       void SeleccionarDocumentoHasta(Int32 Documento);     //Seleccion de Documento en busqueda
       void SeleccionarClienteDesde(Int32 Codigo);          //Seleccion de Cliente en busqueda
       void SeleccionarClienteHasta(Int32 Codigo);          //Seleccion de Cliente en busqueda
    }
}
