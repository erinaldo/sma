using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.DA;
using SMA.Entity;

namespace SMA.BL
{
    public class ModuloBL
    {
        public List<cModulo> Listar()
        {
            try
            {
               return ModuloDA.Listar();
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
