using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
   public class cUsuario
    {
        int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        String _LoginUsuario;

        public String LoginUsuario
        {
            get { return _LoginUsuario; }
            set { _LoginUsuario = value; }
        }
        String _PassUsuario;

        public String PassUsuario
        {
            get { return _PassUsuario; }
            set { _PassUsuario = value; }
        }
        Boolean _Estatus;

        public Boolean Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }
        String _Nombre;

        public String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        String _Telefono;

        public String Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        DateTime _FechaCreacion;

        public DateTime FechaCreacion
        {
            get { return _FechaCreacion; }
            set { _FechaCreacion = value; }
        }
        DateTime _FechaModificacion;

        public DateTime FechaModificacion
        {
            get { return _FechaModificacion; }
            set { _FechaModificacion = value; }
        }
        Boolean _ResetPassOnLogin;

        public Boolean ResetPassOnLogin
        {
            get { return _ResetPassOnLogin; }
            set { _ResetPassOnLogin = value; }
        }
        Object _FechaUltimoLogin;

        public Object FechaUltimoLogin
        {
            get { return _FechaUltimoLogin; }
            set { _FechaUltimoLogin = value; }
        }
    }
}
