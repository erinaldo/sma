using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public abstract class cDocumento
    {
        private Int64 _ID;

        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private Int64 _DocumentoID;

        public Int64 DocumentoID
        {
            get { return _DocumentoID; }
            set { _DocumentoID = value; }
        }

        private String _TipoDocumento;

        public String TipoDocumento
        {
            get { return _TipoDocumento; }
            set { _TipoDocumento = value; }
        }

        private DateTime _FechaCreacion;

        public DateTime FechaCreacion
        {
            get { return _FechaCreacion; }
            set { _FechaCreacion = value; }
        }
        private Decimal _SubTotal;

        public Decimal SubTotal
        {
            get { return _SubTotal; }
            set { _SubTotal = value; }
        }
        private Decimal _ImpuestosTotal;

        public Decimal ImpuestosTotal
        {
            get { return _ImpuestosTotal; }
            set { _ImpuestosTotal = value; }
        }
        private decimal _TotalGeneral;

        public decimal TotalGeneral
        {
            get { return _TotalGeneral; }
            set { _TotalGeneral = value; }
        }
        private Object _EstatusID;

        public Object EstatusID
        {
            get { return _EstatusID; }
            set { _EstatusID = value; }
        }
        private String _Observacion;

        public String Observacion
        {
            get { return _Observacion; }
            set { _Observacion = value; }
        }

        private DateTime _FechaEnvio;

        public DateTime FechaEnvio
        {
            get { return _FechaEnvio; }
            set { _FechaEnvio = value; }
        }

        private DateTime _FechaVencimiento;

        public DateTime FechaVencimiento
        {
            get { return _FechaVencimiento; }
            set { _FechaVencimiento = value; }
        }

        private Int64 _Referencia;

        public Int64 Referencia
        {
            get { return _Referencia; }
            set { _Referencia = value; }
        }

        private Object _CondicionVenta;

        public Object CondicionVenta
        {
            get { return _CondicionVenta; }
            set { _CondicionVenta = value; }
        }

        private String _DireccionEnvio;

        public String DireccionEnvio
        {
            get { return _DireccionEnvio; }
            set { _DireccionEnvio = value; }
        }
    }
}
