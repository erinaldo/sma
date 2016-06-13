using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cReporteEstadoCuenta: cCuentasCobrar
    {

        private String _NombreCliente;
        private String _RNC;
        private String _Direccion;
        private String _Provincia;
        private String _Ciudad;
        private String _Telefono;
        private String _Fax;
        private String _ContactoCobros;
        private Decimal _LimiteCredito;
        private Decimal _BalanceDisponible;
        private Int32 _DiasCredito;
        private Decimal _Abonos;
        private DateTime _FechaReferencia;
        private DateTime _FechaInicio;
        private DateTime _FechaFin;

        public DateTime FechaInicio
        {
            get { return _FechaInicio; }
            set { _FechaInicio = value; }
        }

        public DateTime FechaFin
        {
            get { return _FechaFin; }
            set { _FechaFin = value; }
        }

        public String NombreCliente
        {
            get { return _NombreCliente; }
            set { _NombreCliente = value; }
        }
        public String RNC
        {
            get { return _RNC; }
            set { _RNC = value; }
        }
        public String Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        public String Provincia
        {
            get { return _Provincia; }
            set { _Provincia = value; }
        }
        public String Ciudad
        {
            get { return _Ciudad; }
            set { _Ciudad = value; }
        }
        public String Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        public String ContactoCobros
        {
            get { return _ContactoCobros; }
            set { _ContactoCobros = value; }
        }
        public Decimal LimiteCredito
        {
            get { return _LimiteCredito; }
            set { _LimiteCredito = value; }
        }
        public Decimal BalanceDisponible
        {
            get { return _BalanceDisponible; }
            set { _BalanceDisponible = value; }
        }
        public Int32 DiasCredito
        {
            get { return _DiasCredito; }
            set { _DiasCredito = value; }
        }
        public Decimal Abonos
        {
            get { return _Abonos; }
            set { _Abonos = value; }
        }
        public DateTime FechaReferencia
        {
            get { return _FechaReferencia; }
            set { _FechaReferencia = value; }
        }


    }
}
