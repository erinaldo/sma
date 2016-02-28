using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMA.Entity
{
   public  class cConcMovInvent
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        private Object _Entrada;

        public Object Entrada
        {
            get { return _Entrada; }
            set { _Entrada = value; }
        }
        private Object _Autom;

        public Object Autom
        {
            get { return _Autom; }
            set { _Autom = value; }
        }
        private string _Observacion;

        private Object _MovInterno;

        public Object MovInterno
        {
            get { return _MovInterno; }
            set { _MovInterno = value; }
        }

        private String _Relacion;

        public String Relacion
        {
            get { return _Relacion; }
            set { _Relacion = value; }
        }

        public string Observacion
        {
            get { return _Observacion; }
            set { _Observacion = value; }
        }
    }
}
