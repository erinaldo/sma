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
        public List<cRelacionModuloPerfil> ListarRelacionPerfilModulo(Int16 PerfilID)
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
                if (Existe((Int16)Relacion.PerfilID, (Int16)Relacion.ModuloID) == false)
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

        private Boolean Existe(Int16 PerfilID, Int16 ModuloID)
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
