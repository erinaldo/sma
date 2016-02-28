using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cRolesModulosUsuarios
    {
        private String _LoginUsuario;

        public String LoginUsuario
        {
            get { return _LoginUsuario; }
            set { _LoginUsuario = value; }
        }
        private String _PassUsuario;

        public String PassUsuario
        {
            get { return _PassUsuario; }
            set { _PassUsuario = value; }
        }
        private String _Modulo;

        public String Modulo
        {
            get { return _Modulo; }
            set { _Modulo = value; }
        }
        private String _Rol;

        public String Rol
        {
            get { return _Rol; }
            set { _Rol = value; }
        }

        private String _NombreUsuario;

        public String NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }



    }
}
