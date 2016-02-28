using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Inventario
{
    public interface IGeneral
    {
        void SeleccionarArticulo(String Codigo,Int16 Indicador);
        void SeleccionarFamilia(Int32 Codigo);
        void SeleccionarMarca(Int32 Codigo);
    }
}
