using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.DA;
using SMA.Entity;

namespace SMA.BL
{
    public class ParametroNCFBL
    {
        public cParametroNCF BuscarPorID(Int32 ID)
        {
            //Busca un parametro por su codigo unico
            try
            {
               return ParametroNCFDA.BuscarPorID(ID);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cParametroNCF> Listar(Int32 ID)
        {
            //Lista de parametros de comprobantes por tipos.
            try
            {
                return ParametroNCFDA.Listar(ID);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public void GuardarCambios(cParametroNCF Parametro)
        {
            try
            {
                //Si existe entonces actualizamos 
                if (ParametroNCFDA.Existe(Parametro.ID))
                {
                    ParametroNCFDA.Actualizar(Parametro);
                }
                else
                //Si es nuevo entonces creamos
                {
                    ParametroNCFDA.Crear(Parametro);
                }
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Eliminar(cParametroNCF Parametro)
        {
            Parametro.Estatus = false; //Actualizamos el estatus del parametro
            GuardarCambios(Parametro); //Guardamos los cambios
        }

        public Boolean Disponibilidad(Int32 ComprobanteID)
        {
            //Verifica la disponibilidad de comprobantes fiscales del tipo seleccionado
            if (ComprobanteID > 0)
            {
                if (ParametroNCFDA.Disponibilidad(ComprobanteID))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
