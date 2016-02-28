using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using SMA.DA;

namespace SMA.BL
{
    public class RelacionAlmacenBL
    {
        public List<cRelacionAlmacen> Listar(int InventarioID)
        {
            return RelacionAlmacenDA.Listar(InventarioID);
        }


        public List<cRelacionAlmacen> BuscarPorID(int InventarioID)
        {
            return RelacionAlmacenDA.BuscarPorID(InventarioID);
        }

        public Decimal ExistenciaAlmacen(Int64 InventarioID, int AlmacenID)
        {
            //Retorna el valor en existencia del articulo en el almacen seleccionado
            try
            {
                return RelacionAlmacenDA.ExistenciaAlmacen(InventarioID, AlmacenID);
            }
            catch(Exception Ex)
            {
               throw Ex;
            }
        }

        //public cRelacionAlmacen BuscarPorID(Int32 ID, Int32 InventarioID)
        //{
        //    //Buscamos la relacion del almacen especifica para un articulo por el ID de la linea que 
        //    //guarda la existencia de un articulo
        //    cRelacionAlmacen Relacion=(from C in BuscarPorID(InventarioID)
        //                               where C.ID==ID
        //                                   select C).FirstOrDefault();
        //    return Relacion;

        //}
        
    }
}
