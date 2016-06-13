using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.DA;
using SMA.Entity;

namespace SMA.BL
{
    public class RelacionModuloPerfilRolBL
    {
        public List<cRelacionModuloPerfilRol> ListarRelacionPerfilRol(Int32 RelacionID)
        {
            try
            {
                return RelacionModuloPerfilRolDA.ListarRelacionPerfilRol(RelacionID);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public void CrearRelacionModuloPerfilRol(cRelacionModuloPerfilRol Relacion)
        {
            //CREA RELACION ENTRE PERFIL MODULO Y ROLES
            try
            {
                //COMPROBAMOS SI LA RELACION EXISTE
                if (Existe(Relacion.ModuloPerfilID, Relacion.CodigoRol)==false)
                {
                    RelacionModuloPerfilRolDA.CrearRelacionModuloPerfilRol(Relacion);
                }
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public void EliminarRelacionModuloPerfilRol(Int32 RelacionID)
        {
            //ELIMINA LA RELACION EXISTENTE ENTRE MODULO PERFIL Y ROL
            try
            {
                RelacionModuloPerfilRolDA.EliminarRelacionModuloPerfilRol(RelacionID);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        private Boolean Existe(Int32 RelacionID,Int16 RolID)
        {
            try
            {
              return  RelacionModuloPerfilRolDA.Existe(RelacionID, RolID);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
