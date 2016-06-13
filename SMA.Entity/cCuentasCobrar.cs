using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cCuentasCobrar:cCuenta
    {
        private Object _CodigoCliente;

        public Object CodigoCliente
        {
            get { return _CodigoCliente; }
            set { _CodigoCliente = value; }
        }

        
    }
}
