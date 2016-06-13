using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
  public abstract class cColaborador
    {
        private Int32 _Codigo;
        private String _NombreComercial;
        private String _RNC;
        private Object _EstatusID;
        private String _Direccion;
        private String _Provincia;
        private String _Ciudad;
        private String _Telefono;
        private String _Telefono2;
        private String _Fax;
        private String _Correo;
        private DateTime _FechaCreacion;
        private DateTime _FechaModificacion;
        private String _Observaciones;
        private int _DiasCredito;
        private Decimal _LimiteCredito;
        private Decimal _Descuento;
        private Decimal _Balance;
        private string _PaginaWeb;

        public Int32 Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
       
        public String NombreComercial
        {
            get { return _NombreComercial; }
            set { _NombreComercial = value; }
        }

        public String RNC
        {
            get { return _RNC; }
            set { _RNC = value; }
        }
        
        public Object EstatusID
        {
            get { return _EstatusID; }
            set { _EstatusID = value; }
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

        public String Telefono2
        {
            get { return _Telefono2; }
            set { _Telefono2 = value; }
        }

        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        
        public String Correo
        {
            get { return _Correo; }
            set { _Correo = value; }
        }

        public DateTime FechaCreacion
        {
            get { return _FechaCreacion; }
            set { _FechaCreacion = value; }
        }
        
        public DateTime FechaModificacion
        {
            get { return _FechaModificacion; }
            set { _FechaModificacion = value; }
        }
        
        public String Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        public int DiasCredito
        {
            get { return _DiasCredito; }
            set { _DiasCredito = value; }
        }

        public Decimal LimiteCredito
        {
            get { return _LimiteCredito; }
            set { _LimiteCredito = value; }
        }

        public Decimal Descuento
        {
            get { return _Descuento; }
            set { _Descuento = value; }
        }

        public Decimal Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }

        public string PaginaWeb
        {
            get { return _PaginaWeb; }
            set { _PaginaWeb = value; }
        }

    }
}
