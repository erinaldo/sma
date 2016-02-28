using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cFactura: cDocumento
    {
        private Object _ClienteID;

        public Object ClienteID
        {
            get { return _ClienteID; }
            set { _ClienteID = value; }
        }
           
        private decimal _DescuentoTotal;

        public decimal DescuentoTotal
        {
            get { return _DescuentoTotal; }
            set { _DescuentoTotal = value; }
        }

        private Object _VendedorID;

        public Object VendedorID
        {
            get { return _VendedorID; }
            set { _VendedorID = value; }
        }

    }
}
