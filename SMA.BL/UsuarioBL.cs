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
            if (UsuarioDA.Existe(Usuario.Codigo))
            {
                UsuarioDA.Actualizar(Usuario);
            }
            else
            //Si el Usuario es nuevo entonces creamos
            {
                UsuarioDA.Crear(Usuario);
            }
        }

        public cUsuario BuscarPorCodigo(Int32 Codigo)
        {
            //Buscamos el usuario por codigo
            try
            {
                return UsuarioDA.BuscarPorID(Codigo);
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

        public void Eliminar(Int32 Codigo)
        {
            try
            {
                UsuarioDA.Eliminar(Codigo);
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

        public List<cRolesModulosUsuarios> ListarPermisos(Int32 UsuarioCodigo)
        {
            //RETORNAMOS LOS MODULOS Y PERMISOS RELACIONADOS AL USUARIO Y AL PERFIL QUE PERTENECE EL USUARIO
            try
            {
               return UsuarioDA.ListarPermisos(UsuarioCodigo);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public void ActualizarUltimoLogin(Int32 UsuarioCodigo)
        {
            try
            {
                //ACTUALIZAMOS LA FECHA DE ULTIMO LOGIN
                cUsuario Usuario = BuscarPorCodigo(UsuarioCodigo);
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
