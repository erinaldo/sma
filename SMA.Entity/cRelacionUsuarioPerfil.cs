using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
   public class cRelacionUsuarioPerfil
    {
        private Int32 _Codigo;

        public Int32 Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        private Object _UsuarioCodigo;

        public Object UsuarioCodigo
        {
            get { return _UsuarioCodigo; }
            set { _UsuarioCodigo = value; }
        }
        private Object _PerfilCodigo;

        public Object PerfilCodigo
        {
            get { return _PerfilCodigo; }
            set { _PerfilCodigo = value; }
        }
    }
}
