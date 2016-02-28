using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
   public class cRelacionUsuarioPerfil
    {
        private Int32 _ID;

        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private Object _UsuarioID;

        public Object UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
        private Object _PerfilID;

        public Object PerfilID
        {
            get { return _PerfilID; }
            set { _PerfilID = value; }
        }
    }
}
