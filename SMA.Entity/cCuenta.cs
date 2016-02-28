using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
   public abstract class cCuenta
    {
        private Int64 _ID;

        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private Object _ConceptoID;

        public Object ConceptoID
        {
            get { return _ConceptoID; }
            set { _ConceptoID = value; }
        }
       
        private Int64 _FacturaID;

        public Int64 FacturaID
        {
            get { return _FacturaID; }
            set { _FacturaID = value; }
        }

        private Object _DocumentoID;

        public Object DocumentoID
        {
            get { return _DocumentoID; }
            set { _DocumentoID = value; }
        }
        private String _ReferenciaID;

        public String ReferenciaID
        {
            get { return _ReferenciaID; }
            set { _ReferenciaID = value; }
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
