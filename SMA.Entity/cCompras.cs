using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cCompras: cDocumento
    {
        private Object _ProveedorID;

        public Object ProveedorID
        {
            get { return _ProveedorID; }
            set { _ProveedorID = value; }
        }

        private String _NCF;

        public String NCF
        {
            get { return _NCF; }
            set { _NCF = value; }
        }

    }
}
