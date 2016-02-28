using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cPerfiles
    {
        int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        String _CodigoPerfil;

        public String CodigoPerfil
        {
            get { return _CodigoPerfil; }
            set { _CodigoPerfil = value; }
        }
        String _Descripcion;

        public String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        Boolean _Estatus;

        public Boolean Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }
        String _Notas;

        public String Notas
        {
            get { return _Notas; }
            set { _Notas = value; }
        }
    }
}
