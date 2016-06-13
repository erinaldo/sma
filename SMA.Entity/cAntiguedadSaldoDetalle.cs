using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
   public class cAntiguedadSaldoDetalle: cAntiguedadSaldo
    {
        private String _Concepto;

        public String Concepto
        {
            get { return _Concepto; }
            set { _Concepto = value; }
        }
        private String _CodigoDocumento;

        public String CodigoDocumento
        {
            get { return _CodigoDocumento; }
            set { _CodigoDocumento = value; }
        }
        private DateTime _FechaEmision;

        public DateTime FechaEmision
        {
            get { return _FechaEmision; }
            set { _FechaEmision = value; }
        }
        private DateTime _FechaVencimiento;

        public DateTime FechaVencimiento
        {
            get { return _FechaVencimiento; }
            set { _FechaVencimiento = value; }
        }
    }
}
