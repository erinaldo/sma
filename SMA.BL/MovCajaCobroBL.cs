using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.DA;
using SMA.Entity;

namespace SMA.BL
{
    public class MovCajaCobroBL
    {
        public Int32 Crear(cMovCajaCobro Movimiento)
        {
            if (ValidacionInformacionTarjeta(Movimiento))
            {
                try
                {
                    return MovCajaCobroDA.Crear(Movimiento);
                }
                catch (Exception Ex)
                {
                    
                    throw Ex;
                }
            }
            else
            {
                throw new Exception("Debe completar la informacion de la tarjeta de credito para completar la transacción");
            }
        }

        private Boolean ValidacionInformacionTarjeta(cMovCajaCobro Movimiento)
        {

            //Validamos el campo de monto de tarjeta
            //Si tenemos un valor en la tarjeta y el numero de la tarjeta esta vacio o la fecha de expiracion entonces retornamos falso
         if(Movimiento.MontoTarjeta>0 && 
                                        (Movimiento.NumeroTarjeta.ToString().Length!=4 
                                        || Movimiento.FechaExpiracion.Length!=4)
                                      &&
             (Movimiento.EmisorID==-1 || Movimiento.TipoTarjetaID==-1))
         {
             return false;
         }
         else
         {
             return true;
         }
        }
        
        public List<cMovCajaCobro> ReporteCuadre(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                return MovCajaCobroDA.ReporteCaja(FechaDesde, FechaHasta);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
