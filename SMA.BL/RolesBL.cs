using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.DA;
using SMA.Entity;

namespace SMA.BL
{
    public class RolesBL
    {
      public List<cRoles> Listar(Int32 CodigoModulo)
        {
          try
          {
              return RolesDA.Listar(CodigoModulo);
          }
          catch(Exception Ex)
          {
              throw Ex;
          }
        }
    }
}
