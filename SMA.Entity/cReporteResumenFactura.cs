using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
   public class cReporteResumenFactura: cFactura
    {
        private Decimal _Costo;

        public Decimal Costo
        {
            get { return _Costo; }
            set { _Costo = value; }
        }

        private Object _FechaInicial;

        public Object FechaInicial
        {
            get { return _FechaInicial; }
            set { _FechaInicial = value; }
        }

        private Object _FechaFin;

        public Object FechaFin
        {
            get { return _FechaFin; }
            set { _FechaFin = value; }
        }

    }
}
