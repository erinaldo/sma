using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cTipoComprobanteFiscal
    {
        private SByte _Codigo;

        public SByte Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        private String _Descripcion;

        public String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        private String _Notas;

        public String Notas
        {
            get { return _Notas; }
            set { _Notas = value; }
        }


    }
}
