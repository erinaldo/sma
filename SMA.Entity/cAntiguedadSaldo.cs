using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
   public class cAntiguedadSaldo
    {
        private Int64 _ID;
        private String _NombreComercial;
        private Decimal _TotalFactura;
        private Decimal _Corriente;
        private Decimal _Dias0a30;
        private Decimal _Dias31a60;
        private Decimal _Dias61a90;
        private Decimal _Mas91Dias;
        private DateTime _FechaReferencia;

        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public String NombreComercial
        {
            get { return _NombreComercial; }
            set { _NombreComercial = value; }
        }
        public Decimal TotalFactura
        {
            get { return _TotalFactura; }
            set { _TotalFactura = value; }
        }        
        public Decimal Corriente
        {
            get { return _Corriente; }
            set { _Corriente = value; }
        }
        public Decimal Dias0a30
        {
            get { return _Dias0a30; }
            set { _Dias0a30 = value; }
        }
        public Decimal Dias31a60
        {
            get { return _Dias31a60; }
            set { _Dias31a60 = value; }
        }
        public Decimal Dias61a90
        {
            get { return _Dias61a90; }
            set { _Dias61a90 = value; }
        }
        public Decimal Mas91Dias
        {
            get { return _Mas91Dias; }
            set { _Mas91Dias = value; }
        }
        public DateTime FechaReferencia
        {
            get { return _FechaReferencia; }
            set { _FechaReferencia = value; }
        }
    }
}
