using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cReporteComisionVentaDetalle: cReporteResumenComisionVenta
    {
        private DateTime _FechaCreacion;

        public DateTime FechaCreacion
        {
            get { return _FechaCreacion; }
            set { _FechaCreacion = value; }
        }
        private Decimal _Comision;

        public Decimal Comision
        {
            get { return _Comision; }
            set { _Comision = value; }
        }
        private String _NombreComercial;

        public String NombreComercial
        {
            get { return _NombreComercial; }
            set { _NombreComercial = value; }
        }
    }
}
