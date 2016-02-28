using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Inventario
{
    interface IfrmGestionCombos
    {
        void AgregarArticulo(int InventarioID, Double Cantidad, Double PrecioPublico, int AlmacenID);
        void Refrescar(int ArticuloComboID);
        
    }
}
