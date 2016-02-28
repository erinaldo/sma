using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cRelacionModuloPerfilRol
    {
        private Int32 _ID;

        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private String _DescripcionRol;

        public String DescripcionRol
        {
            get { return _DescripcionRol; }
            set { _DescripcionRol = value; }
        }
        private Int32 _RolID;

        public Int32 RolID
        {
            get { return _RolID; }
            set { _RolID = value; }
        }
        private Int32 _ModuloPerfilID;

        public Int32 ModuloPerfilID
        {
            get { return _ModuloPerfilID; }
            set { _ModuloPerfilID = value; }
        }
    }
}
