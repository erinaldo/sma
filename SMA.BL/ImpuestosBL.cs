using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.DA;
using SMA.Entity;

namespace SMA.BL
{
   public class ImpuestosBL
    {
       public List<cImpuesto> Listar()
       {
           try
           {
               return ImpuestosDA.Listar();
           }
           catch(Exception Ex)
           {
               throw Ex;
           }
       }

       public cImpuesto BuscarPorID(Int32 ID)
       {
           try
           {
               return ImpuestosDA.BuscarPorID(ID);
           }
           catch(Exception Ex)
           {
               return null;
               throw Ex;
           }
       }
    }
}
