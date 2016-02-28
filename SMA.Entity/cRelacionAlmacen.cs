using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMA.Entity
{
    public class cRelacionAlmacen
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private Object _AlmacenID;

        public Object AlmacenID
        {
            get { return _AlmacenID; }
            set { _AlmacenID = value; }
        }
        private Object _InventarioID;

        public Object InventarioID
        {
            get { return _InventarioID; }
            set { _InventarioID = value; }
        }
        private Double _Existencia;

        public Double Existencia
        {
            get { return _Existencia; }
            set { _Existencia = value; }
        }
    }
}
