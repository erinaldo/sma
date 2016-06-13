using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.DA;
using SMA.Entity;

namespace SMA.BL
{
   public class ProveedorBL
    {

        public void GuardarCambios(cProveedor Proveedor)
        {
            //Si el almacen existe entonces actualizamos 
            if (ProveedorDA.Existe(Proveedor.Codigo))
            {
                ProveedorDA.Actualizar(Proveedor);
            }
            else
            //Si el almacen es nuevo entonces creamos
            {
                ProveedorDA.Crear(Proveedor);
            }
        }

        public List<cProveedor> Listar()
        {
            //Lista de almacenes
            try
            {
                return ProveedorDA.Listar();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public cProveedor BuscarPorID(Int32 ID)
        {
            return ProveedorDA.BuscarPorID(ID);
        }

        public void Eliminar(Int32 ID)
        {
            //Antes de marcar el almacen como eliminado comprobamos que no contenga articulos con existencia
            if (ValidacionExistencia(ID))
            {
                ProveedorDA.Eliminar(ID);
            }
            else
            {
                Exception Ex = new Exception("No se pudo completar la operacion, por favor vuelva a intentarlo");
                throw Ex;
            }
        }

        private Boolean ValidacionExistencia(Int64 ID)
        {
            //Validamos que el Almacen no contenga articulos en existencia
            return true;
        }

        public List<cProveedor> Filtrar(Int32? CodigoDesde,
                                             Int32? CodigoHasta,
                                             String Nombre,
                                             Boolean? EstatusID)
        {
            //Filtro de Clientes
            try
            {
                return ProveedorDA.Filtrar(CodigoDesde, CodigoHasta, Nombre, EstatusID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cProveedor> Catalogo(Int32 CodigoDesde, Int32 CodigoHasta, Boolean? Estatus)
        {
            try
            {
              return  ProveedorDA.Catalogo(CodigoDesde, CodigoHasta, Estatus);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
