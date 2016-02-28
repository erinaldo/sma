using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
   public class cReporteVentasPorClienteDetalle: cReporteVentasPorCliente
    {
        private Object _DocumentoID;

        public Object DocumentoID
        {
            get { return _DocumentoID; }
            set { _DocumentoID = value; }
        }

        private DateTime _Fecha;

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
    }
}
