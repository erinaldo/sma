using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
   public class cEmpresa
    {
        private Int32 _ID;

        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private String _RazonSocial;

        public String RazonSocial
        {
            get { return _RazonSocial; }
            set { _RazonSocial = value; }
        }
        private String _Telefono;

        public String Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        private String _Fax;

        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        private String _Direccion;

        public String Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        private String _Ciudad;

        public String Ciudad
        {
            get { return _Ciudad; }
            set { _Ciudad = value; }
        }
        private String _Provincia;

        public String Provincia
        {
            get { return _Provincia; }
            set { _Provincia = value; }
        }
        private String _RNC;

        public String RNC
        {
            get { return _RNC; }
            set { _RNC = value; }
        }
    }
}
