using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMA.DA;
using SMA.Entity;

namespace SMA.BL
{
    public class AlmacenBL
    {
        public void GuardarCambios(cAlmacen Almacen)
        {
            //Si el almacen existe entonces actualizamos 
             if (AlmacenDA.Existe(Almacen.ID))
             {
                 AlmacenDA.Actualizar(Almacen);
             }
             else
                 //Si el almacen es nuevo entonces creamos
             {
                 AlmacenDA.Crear(Almacen);
             }
        }    

        public List<cAlmacen> Listar()
        {
            //Lista de almacenes
            try
            {
                return AlmacenDA.Listar();
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }
    
        public cAlmacen BuscarPorID(int ID)
        {
            return AlmacenDA.BuscarPorID(ID);
        }

        public void Eliminar(int ID)
        {
            //Antes de marcar el almacen como eliminado comprobamos que no contenga articulos con existencia
            if (ValidacionExistencia(ID))
            {
                AlmacenDA.Eliminar(ID);
            }
            else
            {
                Exception Ex = new Exception("El almacen no puede ser eliminado ya que contiene articulos en su existencia");
                throw Ex;
            }
        }

        private Boolean ValidacionExistencia(int ID)
        {
            //Validamos que el Almacen no contenga articulos en existencia
            return true;
        }
    
    }
}
