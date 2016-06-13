using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cPerfil
    {
        int _Codigo;

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
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

        private DateTime _FechaCreacion;

        public DateTime FechaCreacion
        {
            get { return _FechaCreacion; }
            set { _FechaCreacion = value; }
        }
        private DateTime _FechaModificacion;

        public DateTime FechaModificacion
        {
            get { return _FechaModificacion; }
            set { _FechaModificacion = value; }
        }
    }
}
