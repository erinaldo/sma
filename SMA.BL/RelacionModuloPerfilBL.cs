using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using SMA.DA;

namespace SMA.BL
{
    public class RelacionModuloPerfilBL

    {
        public List<cRelacionModuloPerfil> ListarRelacionPerfilModulo(Int32 PerfilID)
        {
            try
            {
                return RelacionModuloPerfilDA.ListarRelacionPerfilModulo(PerfilID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        
        public void CrearRelacionModuloPerfil(cRelacionPerfilModulo Relacion)
        {
            try
            {
                //COMPROBAMOS LA EXISTENCIA DE LA RELACION
                if (Existe((Int32)Relacion.PerfilID, (Int32)Relacion.ModuloID) == false)
                {
                    RelacionModuloPerfilDA.CrearRelacionModuloPerfil(Relacion);
                }

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void EliminarRelacionModuloPerfil(Int32 RelacionID)
        {
            try
            {
                RelacionModuloPerfilDA.EliminarRelacionModuloPerfil(RelacionID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private Boolean Existe(Int32 PerfilID, Int32 ModuloID)
        {
            //COMPROBAMOS LA EXISTENCIA DE LA RELACION
            try
            {
                return RelacionModuloPerfilDA.Existe(PerfilID, ModuloID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
