using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;

namespace SMA.Clientes.CuentasPagar
{
    interface IGestionCuentasPagar
    {
        void AplicarFiltro(List<cCuentasPagar> Lista);
    }
}
