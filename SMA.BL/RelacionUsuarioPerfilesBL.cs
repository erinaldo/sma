using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.DA;
using SMA.Entity;

namespace SMA.BL
{
    public class RelacionUsuarioPerfilesBL
    {
        public List<cRelacionUsuarioPerfil> Listar(Int32 UsuarioID)
        {
            try
            {
                return RelacionUsuarioPerfilesDA.Listar(UsuarioID);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public void Crear(cRelacionUsuarioPerfil Relacion)
        {
            try
            {
                if (RelacionUsuarioPerfilesDA.Existe((Int32)Relacion.PerfilID, (Int32)Relacion.UsuarioID))
                {
                    RelacionUsuarioPerfilesDA.Crear(Relacion);
                }
                else
                {
                    throw new Exception("El perfil ya se encuentra registrado para el usuario seleccionado");
                }
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        
    }
}
