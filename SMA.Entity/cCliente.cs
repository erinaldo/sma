using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
   public class cCliente: cColaborador
    {
        private String _ContactoVentas;
        private int _TipoComprobanteID;
        private String _ContactoCobros;
        private Object _VendedorID;
        private Object _UltFechaPago;
        private Object _UltDocPago;
        private Decimal _UltMontoPago;
        private Object _UltFechaVenta;
        private Object _UltDocVenta;
        private Decimal _UltMontoVenta;

        public int TipoComprobanteID
        {
            get { return _TipoComprobanteID; }
            set { _TipoComprobanteID = value; }
        }

        public String ContactoVentas
        {
            get { return _ContactoVentas; }
            set { _ContactoVentas = value; }
        }
       
        public String ContactoCobros
        {
            get { return _ContactoCobros; }
            set { _ContactoCobros = value; }
        }

        public Object VendedorID
        {
            get { return _VendedorID; }
            set { _VendedorID = value; }
        }

        public Object UltFechaPago
        {
            get { return _UltFechaPago; }
            set { _UltFechaPago = value; }
        }
        
        public Object UltDocPago
        {
            get { return _UltDocPago; }
            set { _UltDocPago = value; }
        }
        
        public Decimal UltMontoPago
        {
            get { return _UltMontoPago; }
            set { _UltMontoPago = value; }
        }
        
        public Object UltFechaVenta
        {
            get { return _UltFechaVenta; }
            set { _UltFechaVenta = value; }
        }
        
        public Object UltDocVenta
        {
            get { return _UltDocVenta; }
            set { _UltDocVenta = value; }
        }

        public Decimal UltMontoVenta
        {
            get { return _UltMontoVenta; }
            set { _UltMontoVenta = value; }
        }
        
    }
}
