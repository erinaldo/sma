using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMA.Entity
{
    public class cRelacionCombos
    {
        private Int64 _ID;
        private Object _InventComboID;
        private Object _InventarioID;
        private Object _AlmacenID;
        private Decimal _Cantidad;
        private Decimal _Precio;
        //Descripcion de Articulo componente solo es utilizado para visualizacion
        private string _Descripcion;

        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public Object InventComboID
        {
            get { return _InventComboID; }
            set { _InventComboID = value; }
        }
        public Object InventarioID
        {
            get { return _InventarioID; }
            set { _InventarioID = value; }
        }
        public Object AlmacenID
        {
            get { return _AlmacenID; }
            set { _AlmacenID = value; }
        }
        public Decimal Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        public Decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

    }
}
