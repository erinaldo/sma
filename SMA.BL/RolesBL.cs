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
      public List<cRoles> Listar()
        {
          try
          {
              return RolesDA.Listar();
          }
          catch(Exception Ex)
          {
              throw Ex;
          }
        }
    }
}
