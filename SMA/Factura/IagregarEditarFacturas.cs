using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;

namespace SMA.Factura
{
    public interface IagregarEditarFacturas
    {
        //void SeleccionarCliente(Int32 Codigo);
        void BuscarArticulo(Int64 Codigo);
        void BusquedaCliente(Int32 Codigo);
        void BuscarReferencia(Int64 DocumentoID);
    }
}
