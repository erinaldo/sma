using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
   public class cProveedor: cColaborador
    {
        private String _ContactoCompras;

        public String ContactoCompras
        {
            get { return _ContactoCompras; }
            set { _ContactoCompras = value; }
        }
        private String _ContactoPagos;

        public String ContactoPagos
        {
            get { return _ContactoPagos; }
            set { _ContactoPagos = value; }
        }

        private Object _UltFechaPago;

        public Object UltFechaPago
        {
            get { return _UltFechaPago; }
            set { _UltFechaPago = value; }
        }
        private String _UltDocPago;

        public String UltDocPago
        {
            get { return _UltDocPago; }
            set { _UltDocPago = value; }
        }
        private Decimal _UltMontoPago;

        public Decimal UltMontoPago
        {
            get { return _UltMontoPago; }
            set { _UltMontoPago = value; }
        }
        private Object _UltFechaCompra;

        public Object UltFechaCompra
        {
            get { return _UltFechaCompra; }
            set { _UltFechaCompra = value; }
        }
        private String _UltDocCompra;

        public String UltDocCompra
        {
            get { return _UltDocCompra; }
            set { _UltDocCompra = value; }
        }
        private Decimal _UltMontoCompra;

        public Decimal UltMontoCompra
        {
            get { return _UltMontoCompra; }
            set { _UltMontoCompra = value; }
        }
    }
}
