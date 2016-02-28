using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;

namespace SMA.Inventario
{
    interface IGestionInventario
    {
        //void ActualizarGrid();
        //void BuscarArticulo(string CodigoArticulo);
        void Filtrar(List<cInventario> ListaFiltrada);
    }
}
