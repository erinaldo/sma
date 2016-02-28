using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cRelacionModuloPerfil
    {
        private Int32 _ID;

        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private Object _PerfilID;

        public Object PerfilID
        {
            get { return _PerfilID; }
            set { _PerfilID = value; }
        }

        private String _DescripcionPerfil;

        public String DescripcionPerfil
        {
            get { return _DescripcionPerfil; }
            set { _DescripcionPerfil = value; }
        }

        private Object _ModuloID;

        public Object ModuloID
        {
            get { return _ModuloID; }
            set { _ModuloID = value; }
        }

        private String _DescripcionModulo;

        public String DescripcionModulo
        {
            get { return _DescripcionModulo; }
            set { _DescripcionModulo = value; }
        }

    }
}
