using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cRelacionPerfilModulo
    {
        private String _DescripcionModulo;

        public String DescripcionModulo
        {
            get { return _DescripcionModulo; }
            set { _DescripcionModulo = value; }
        }
        
        private Int32 _ModuloID;

        public Int32 ModuloID
        {
            get { return _ModuloID; }
            set { _ModuloID = value; }
        }
        private Int32 _PerfilID;

        public Int32 PerfilID
        {
            get { return _PerfilID; }
            set { _PerfilID = value; }
        }
    }
}
