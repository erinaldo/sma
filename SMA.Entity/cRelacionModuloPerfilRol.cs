using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cRelacionModuloPerfilRol
    {
        private Int32 _Codigo;

        public Int32 Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        private String _DescripcionRol;

        public String DescripcionRol
        {
            get { return _DescripcionRol; }
            set { _DescripcionRol = value; }
        }
        private Int16 _CodigoRol;

        public Int16 CodigoRol
        {
            get { return _CodigoRol; }
            set { _CodigoRol = value; }
        }
        private Int32 _ModuloPerfilID;

        public Int32 ModuloPerfilID
        {
            get { return _ModuloPerfilID; }
            set { _ModuloPerfilID = value; }
        }
    }
}
