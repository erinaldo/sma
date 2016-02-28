using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.DA;
using SMA.Entity;

namespace SMA.BL
{
   public class ClienteBL
    {
        public void GuardarCambios(cCliente Cliente)
        {
            try
            {
                //Si el almacen existe entonces actualizamos 
                if (ClienteDA.Existe(Cliente.ID))
                {
                        ClienteDA.Actualizar(Cliente);
                }
                else
                //Si el almacen es nuevo entonces creamos
                {
                    ClienteDA.Crear(Cliente);
                }
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cCliente> Listar()
        {
            //Lista de almacenes
            try
            {
                return ClienteDA.Listar();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public cCliente BuscarPorID(Int64 ID)
        {
            return ClienteDA.BuscarPorID(ID);
        }

        public void Eliminar(Int64 ID)
        {
            
            if (ValidacionDocumentos(ID)) //Validamos si el cliente posee movimientos
            {
                ClienteDA.Eliminar(ID); //Eliminamos al cliente de la base de datos
            }
            else
            {
                throw  new Exception("El cliente seleccionado posee movimientos, no puede ser eliminado");
            }
        }

        private Boolean ValidacionDocumentos(Int64 ID)
        {
            //Validamos si el cliente seleccionado no posee documentos relacionados
            if(CuentaCobrarDA.ListaCargosGenerales(ID).Count==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<cCliente> Filtrar(Int64? CodigoDesde,
                                            Int64? CodigoHasta,
                                            Int32? VendedorID,
                                            String Nombre,
                                            Boolean? EstatusID)
        {
            //Filtro de Clientes
            try
            {
                return ClienteDA.Filtrar(CodigoDesde,CodigoHasta,VendedorID,Nombre,EstatusID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cCliente> Catalogo(Int64 CodigoDesde, Int64 CodigoHasta, Int32? VendedorID, Boolean? Estatus)
        {
           try
           {
               return ClienteDA.Catalogo(CodigoDesde, CodigoHasta, VendedorID, Estatus);
           }
           catch(Exception Ex)
           {
               throw Ex;
           }
        }
    }
}
