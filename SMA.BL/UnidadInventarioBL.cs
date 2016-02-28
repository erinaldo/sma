using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using SMA.DA;
namespace SMA.BL
{
    public class UnidadInventarioBL
    {
        public List<cUnidadInventario> Listar()
        {
            return UnidadInventarioDA.Listar();
        }
    }
}
