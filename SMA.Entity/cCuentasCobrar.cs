using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cCuentasCobrar:cCuenta
    {
        private Object _ClienteID;

        public Object ClienteID
        {
            get { return _ClienteID; }
            set { _ClienteID = value; }
        }

        
    }
}
