using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cReporteMovimientoInventario
    {
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
        private DateTime _Fecha;

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        private String _Documento;

        public String Documento
        {
            get { return _Documento; }
            set { _Documento = value; }
        }

        private String _DescripcionConcepto;
        public String DescripcionConcepto
        {
            get { return _DescripcionConcepto; }
            set { _DescripcionConcepto = value; }
        }
        
        private Decimal _Cantidad;
        public Decimal Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        
        private Decimal _CostoUnitario;

        public Decimal CostoUnitario
        {
            get { return _CostoUnitario; }
            set { _CostoUnitario = value; }
        }
        private Decimal _CostoTotal;

        public Decimal CostoTotal
        {
            get { return _CostoTotal; }
            set { _CostoTotal = value; }
        }
        private Decimal _PrecioUnitario;

        public Decimal PrecioUnitario
        {
            get { return _PrecioUnitario; }
            set { _PrecioUnitario = value; }
        }
        private Decimal _PrecioTotal;

        public Decimal PrecioTotal
        {
            get { return _PrecioTotal; }
            set { _PrecioTotal = value; }
        }

        private String _ClienteProveedor;

        public String ClienteProveedor
        {
            get { return _ClienteProveedor; }
            set { _ClienteProveedor = value; }
        }

        private String _CodigoDesde;

        public String CodigoDesde
        {
            get { return _CodigoDesde; }
            set { _CodigoDesde = value; }
        }
        private String _CodigoHasta;

        public String CodigoHasta
        {
            get { return _CodigoHasta; }
            set { _CodigoHasta = value; }
        }

        private Object _FechaDesde;

        public Object FechaDesde
        {
            get { return _FechaDesde; }
            set { _FechaDesde = value; }
        }
        private Object _FechaHasta;

        public Object FechaHasta
        {
            get { return _FechaHasta; }
            set { _FechaHasta = value; }
        }

        private Object _DocumentoDesde;

        public Object DocumentoDesde
        {
            get { return _DocumentoDesde; }
            set { _DocumentoDesde = value; }
        }
        private Object _DocumentoHasta;

        public Object DocumentoHasta
        {
            get { return _DocumentoHasta; }
            set { _DocumentoHasta = value; }
        }

    }
}
