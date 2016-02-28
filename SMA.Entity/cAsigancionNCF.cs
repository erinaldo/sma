using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
   public  class cAsigancionNCF
    {

        private Int32 _ID;

        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private Object _ComprobanteID;

        public Object ComprobanteID
        {
            get { return _ComprobanteID; }
            set { _ComprobanteID = value; }
        }
        private String _NCFAsignado;

        public String NCFAsignado
        {
            get { return _NCFAsignado; }
            set { _NCFAsignado = value; }
        }
        private Int64 _FacturaID;

        public Int64 FacturaID
        {
            get { return _FacturaID; }
            set { _FacturaID = value; }
        }
        private DateTime _FechaAsignacion;

        public DateTime FechaAsignacion
        {
            get { return _FechaAsignacion; }
            set { _FechaAsignacion = value; }
        }

    }
}
