using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cCobranzaGeneral
    {
        private String _Concepto;

        public String Concepto
        {
            get { return _Concepto; }
            set { _Concepto = value; }
        }
        private Int32 _Codigo;

        public Int32 Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        private String _NombreComercial;

        public String NombreComercial
        {
            get { return _NombreComercial; }
            set { _NombreComercial = value; }
        }
        private String _Telefono;

        public String Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        private Object _Documento;

        public Object Documento
        {
            get { return _Documento; }
            set { _Documento = value; }
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
        private Double _Cargos;

        public Double Cargos
        {
            get { return _Cargos; }
            set { _Cargos = value; }
        }
        private Double _Abonos;

        public Double Abonos
        {
            get { return _Abonos; }
            set { _Abonos = value; }
        }
        private Double _Balance;

        public Double Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }
        private String _ContactoVentas;

        public String ContactoVentas
        {
            get { return _ContactoVentas; }
            set { _ContactoVentas = value; }
        }
        private String _ContactoCobros;

        public String ContactoCobros
        {
            get { return _ContactoCobros; }
            set { _ContactoCobros = value; }
        }

    }
}
