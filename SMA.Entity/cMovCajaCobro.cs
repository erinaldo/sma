using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cMovCajaCobro
    {
        private Int64 _ID;

        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private DateTime _Fecha;

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        private Int64 _FacturaID;

        public Int64 FacturaID
        {
            get { return _FacturaID; }
            set { _FacturaID = value; }
        }
        private Decimal _MontoEfectivo;

        public Decimal MontoEfectivo
        {
            get { return _MontoEfectivo; }
            set { _MontoEfectivo = value; }
        }
        private Decimal _MontoTarjeta;

        public Decimal MontoTarjeta
        {
            get { return _MontoTarjeta; }
            set { _MontoTarjeta = value; }
        }
        private Int32 _NumeroTarjeta;

        public Int32 NumeroTarjeta
        {
            get { return _NumeroTarjeta; }
            set { _NumeroTarjeta = value; }
        }
        private String _FechaExpiracion;

        public String FechaExpiracion
        {
            get { return _FechaExpiracion; }
            set { _FechaExpiracion = value; }
        }
        private Int32 _EmisorID;

        public Int32 EmisorID
        {
            get { return _EmisorID; }
            set { _EmisorID = value; }
        }
        private Int32 _TipoTarjetaID;

        public Int32 TipoTarjetaID
        {
            get { return _TipoTarjetaID; }
            set { _TipoTarjetaID = value; }
        }

        private Int32 _NumeroAprobacion;

        public Int32 NumeroAprobacion
        {
            get { return _NumeroAprobacion; }
            set { _NumeroAprobacion = value; }
        }
    }
}
