using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Inventario.Reportes
{
    public interface IReportes
    {
        void SeleccionarCodigoDesde(String Codigo);
        void SeleccionarCodigoHasta(String Codigo);
        void SeleccionarCliente(Int64 Codigo, Int32 Indicador);
    }
}
