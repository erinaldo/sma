using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
   public class cVendedor
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private String _Nombre;

        public String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        private String _Apellido;

        public String Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }
        private String _Telefono;

        public String Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        private String _Celular;

        public String Celular
        {
            get { return _Celular; }
            set { _Celular = value; }
        }
        private String _Cedula;

        public String Cedula
        {
            get { return _Cedula; }
            set { _Cedula = value; }
        }
        private Decimal _Comision;

        public Decimal Comision
        {
            get { return _Comision; }
            set { _Comision = value; }
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

        private Boolean _Eliminado;

        public Boolean Eliminado
        {
            get { return _Eliminado; }
            set { _Eliminado = value; }
        }

    }
}
