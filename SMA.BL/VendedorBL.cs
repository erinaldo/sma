using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using SMA.DA;

namespace SMA.BL
{
    public class VendedorBL
    {
        public void GuardarCambios(cVendedor Vendedor)
        {
            try
            {
                //Si el almacen existe entonces actualizamos 
                if (VendedorDA.Existe(Vendedor.Codigo))
                {
                    VendedorDA.Actualizar(Vendedor);
                }
                else
                //Si el almacen es nuevo entonces creamos
                {
                    VendedorDA.Crear(Vendedor);
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cVendedor> Listar()
        {
            try
            {
                return VendedorDA.Listar();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public cVendedor BuscarPorID(int ID)
        {
            try
            {
                return VendedorDA.BuscarPorID(ID);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
