using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.DA;
using SMA.Entity;

namespace SMA.BL
{
    public class UsuarioBL
    {
        public void GuardarCambios(cUsuario Usuario)
        {
            //Si el usuario existe entonces actualizamos 
            if (UsuarioDA.Existe(Usuario.ID))
            {
                UsuarioDA.Actualizar(Usuario);
            }
            else
            //Si el Usuario es nuevo entonces creamos
            {
                UsuarioDA.Crear(Usuario);
            }
        }

        public cUsuario BuscarPorID(Int32 ID)
        {
            //Buscamos el usuario por codigo
            try
            {
                return UsuarioDA.BuscarPorID(ID);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cUsuario> Listar()
        {
            //LISTA LOS USUARIOS
            try
            {
                return UsuarioDA.Listar();
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public void Eliminar(Int32 ID)
        {
            try
            {
                UsuarioDA.Eliminar(ID);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public cUsuario ObtenerUsuario(String Usuario, String PassWord)
        {
            try
            {
                return UsuarioDA.ValidarLogin(Usuario, PassWord);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public List<cRolesModulosUsuarios> ListarPermisos(Int32 UsuarioID)
        {
            //RETORNAMOS LOS MODULOS Y PERMISOS RELACIONADOS AL USUARIO Y AL PERFIL QUE PERTENECE EL USUARIO
            try
            {
               return UsuarioDA.ListarPermisos(UsuarioID);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public void ActualizarUltimoLogin(Int32 UsuarioID)
        {
            try
            {
                //ACTUALIZAMOS LA FECHA DE ULTIMO LOGIN
                cUsuario Usuario = BuscarPorID(UsuarioID);
                Usuario.FechaUltimoLogin = DateTime.Now;
                GuardarCambios(Usuario);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
