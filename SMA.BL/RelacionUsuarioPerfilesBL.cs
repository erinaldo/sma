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
        public List<cRelacionUsuarioPerfil> Listar(Int32 UsuarioCodigo)
        {
            try
            {
                return RelacionUsuarioPerfilesDA.Listar(UsuarioCodigo);
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
                if (RelacionUsuarioPerfilesDA.Existe((Int16)Relacion.PerfilCodigo, (Int32)Relacion.UsuarioCodigo))
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

        public void Eliminar(Int32 Codigo)
        {
            //ELIMINA LA RELACION ENTRE UN PERFIL Y UN USUARIO
            try
            {
                RelacionUsuarioPerfilesDA.Eliminar(Codigo);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        
    }
}
