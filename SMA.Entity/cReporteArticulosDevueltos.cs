using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cReporteArticulosDevueltos
    {
        private Int64 _DocumentoID;

        public Int64 DocumentoID
        {
            get { return _DocumentoID; }
            set { _DocumentoID = value; }
        }
        private DateTime _FechaCreacion;

        public DateTime FechaCreacion
        {
            get { return _FechaCreacion; }
            set { _FechaCreacion = value; }
        }
        private DateTime _FechaVencimiento;

        public DateTime FechaVencimiento
        {
            get { return _FechaVencimiento; }
            set { _FechaVencimiento = value; }
        }
        private String _CodigoArticulo;

        public String CodigoArticulo
        {
            get { return _CodigoArticulo; }
            set { _CodigoArticulo = value; }
        }
        private String _DescripcionArticulo;

        public String DescripcionArticulo
        {
            get { return _DescripcionArticulo; }
            set { _DescripcionArticulo = value; }
        }
        private String _DescripcionFamilia;

        public String DescripcionFamilia
        {
            get { return _DescripcionFamilia; }
            set { _DescripcionFamilia = value; }
        }
        private String _NombreComercial;

        public String NombreComercial
        {
            get { return _NombreComercial; }
            set { _NombreComercial = value; }
        }
        private Decimal _CantidadFacturada;

        public Decimal CantidadFacturada
        {
            get { return _CantidadFacturada; }
            set { _CantidadFacturada = value; }
        }
        private Decimal _CantidadDevuelta;

        public Decimal CantidadDevuelta
        {
            get { return _CantidadDevuelta; }
            set { _CantidadDevuelta = value; }
        }

        public Object FechaInicial { get; set; }
        public Object FechaFin { get; set; }
        public Object DocumentoDesde { get; set; }
        public Object DocumentoHasta { get; set; }
        
    }
}
