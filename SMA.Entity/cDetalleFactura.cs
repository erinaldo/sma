using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
   public class cDetalleFactura
    {
        private Int64 _ID;
        private String _TipoDocumento;
        private Int64 _FacturaID;
        private Int64 _ArticuloID;
        private Decimal _Cantidad;
        private Decimal _Precio;
        private Decimal _Costo;
        private Decimal _ImpuestoValor;
        private Decimal _DescuentoValor;
        private int _UnidadVentaID;
        private String _TipoProducto;
        private Decimal _ComisionVenta;
        private Decimal _ValorComision;

        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public String TipoDocumento
        {
            get { return _TipoDocumento; }
            set { _TipoDocumento = value; }
        }
        public Int64 FacturaID
        {
            get { return _FacturaID; }
            set { _FacturaID = value; }
        }
        public Int64 ArticuloID
        {
            get { return _ArticuloID; }
            set { _ArticuloID = value; }
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
        public Decimal Costo
        {
            get { return _Costo; }
            set { _Costo = value; }
        }
        public Decimal ImpuestoValor
        {
            get { return _ImpuestoValor; }
            set { _ImpuestoValor = value; }
        }
        public Decimal DescuentoValor
        {
            get { return _DescuentoValor; }
            set { _DescuentoValor = value; }
        }
        public int UnidadVentaID
        {
            get { return _UnidadVentaID; }
            set { _UnidadVentaID = value; }
        }
        public String TipoProducto
        {
            get { return _TipoProducto; }
            set { _TipoProducto = value; }
        }
        public Decimal ComisionVenta
        {
            get { return _ComisionVenta; }
            set { _ComisionVenta = value; }
        }
        public Decimal ValorComision
        {
            get { return _ValorComision; }
            set { _ValorComision = value; }
        }
    }
}
