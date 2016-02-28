using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;

namespace SMA.Clientes.CuentasPagar
{
    interface IGestionCuentasCobrar
    {
        void AplicarFiltro(List<cCuentasCobrar> Lista);
    }
}
