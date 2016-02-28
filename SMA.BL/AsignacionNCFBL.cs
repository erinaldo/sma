using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.DA;
using SMA.Entity;

namespace SMA.BL
{
    public class AsignacionNCFBL
    {
        public void Crear(cAsigancionNCF Asignacion)
        {
            try
            {
                AsignacionNCFDA.Crear(Asignacion);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
