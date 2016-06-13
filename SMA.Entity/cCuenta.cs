using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
   public abstract class cCuenta
    {
        private Int32 _Codigo;

        public Int32 Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        private Object _CodigoConcepto;

        public Object CodigoConcepto
        {
            get { return _CodigoConcepto; }
            set { _CodigoConcepto = value; }
        }
       
        private Int64 _CodigoFactura;

        public Int64 CodigoFactura
        {
            get { return _CodigoFactura; }
            set { _CodigoFactura = value; }
        }

        private Object _CodigoDocumento;

        public Object CodigoDocumento
        {
            get { return _CodigoDocumento; }
            set { _CodigoDocumento = value; }
        }
        private String _CodigoReferencia;

        public String CodigoReferencia
        {
            get { return _CodigoReferencia; }
            set { _CodigoReferencia = value; }
        }

        private Boolean _Estatus;

        public Boolean Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
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
        private Decimal _Monto;

        public Decimal Monto
        {
            get { return _Monto; }
            set { _Monto = value; }
        }
        private String _Notas;

        public String Notas
        {
            get { return _Notas; }
            set { _Notas = value; }
        }

        private Decimal _Balance;

        public Decimal Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }

     
    }
}
