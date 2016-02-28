using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;

namespace SMA.Compras
{
    public interface IagregarEditarRecepcion
    {
        //void SeleccionarCliente(Int32 Codigo);
        void BuscarArticulo(Int64 Codigo);
        void BusquedaProveedor(Int64 Codigo);
        void BuscarReferencia(Int64 DocumentoID);
        
    }
}
