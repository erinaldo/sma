using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cDetalleCompra
    {

        private Int64 _ID;

        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private String _TipoDocumento;

        public String TipoDocumento
        {
            get { return _TipoDocumento; }
            set { _TipoDocumento = value; }
        }

        private Int64 _CompraID;

        public Int64 CompraID
        {
            get { return _CompraID; }
            set { _CompraID = value; }
        }

        private Int64 _ArticuloID;

        public Int64 ArticuloID
        {
            get { return _ArticuloID; }
            set { _ArticuloID = value; }
        }

        private Decimal _Cantidad;

        public Decimal Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        private Decimal _Precio;

        public Decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }
        
        private Decimal _ImpuestoValor;

        public Decimal ImpuestoValor
        {
            get { return _ImpuestoValor; }
            set { _ImpuestoValor = value; }
        }
       
        private int _UnidadCompraID;

        public int UnidadCompraID
        {
            get { return _UnidadCompraID; }
            set { _UnidadCompraID = value; }
        }
        private String _TipoProducto;

        public String TipoProducto
        {
            get { return _TipoProducto; }
            set { _TipoProducto = value; }
        }
    }
}
