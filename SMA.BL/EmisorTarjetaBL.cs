using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using SMA.DA;

namespace SMA.BL
{
   public class EmisorTarjetaBL
    {
       public List<cEmisorTarjeta> Listar()
       {
           try
           {
            return   EmisorTarjetaDA.Listar();
           }
           catch(Exception Ex)
           {
               return null;
               throw Ex;
           }
       }
    }
}
