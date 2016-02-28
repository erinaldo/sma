using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cCuentasPagar:cCuenta
    {
        private Object _ProveedorID;

        public Object ProveedorID
        {
            get { return _ProveedorID; }
            set { _ProveedorID = value; }
        }
    }
}
