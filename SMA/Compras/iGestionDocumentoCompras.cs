using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Compras
{
    interface iGestionDocumentoCompras
    {
        void BusquedaProveedor(Int64 Codigo);
        void SeleccionDocumento(string Documento,Int32 Indicador);
        void SeleccionProveedor(Int64 Codigo, Int32 Indicador);
        void BusquedaArticulo(Int64 Codigo);
        void SeleccionFamilia(Int32 Codigo);
    }
}
