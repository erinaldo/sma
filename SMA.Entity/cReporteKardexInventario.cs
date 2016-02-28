using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cReporteKardexInventario
    {
        private String _CodigoArticulo;
        private String _DescripcionArticulo;
        private DateTime _Fecha;
        private String _DescripcionConcepto;
        private Object _Documento;
        private Decimal _Entrada;
        private Decimal _Salida;
        private Decimal _Costo;
        private Decimal _Precio;
        private Decimal _SaldoInicial;
        private Decimal _Balance;
        private Object _FechaUltCompra;
        private Int32 _StockMin;
        private Int32 _StockMax;
        private Decimal _Existencia;

        public String CodigoArticulo
        {
            get { return _CodigoArticulo; }
            set { _CodigoArticulo = value; }
        }
        public String DescripcionArticulo
        {
            get { return _DescripcionArticulo; }
            set { _DescripcionArticulo = value; }
        }
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        public String DescripcionConcepto
        {
            get { return _DescripcionConcepto; }
            set { _DescripcionConcepto = value; }
        }
        public Object Documento
        {
            get { return _Documento; }
            set { _Documento = value; }
        }
        public Decimal Entrada
        {
            get { return _Entrada; }
            set { _Entrada = value; }
        }
        public Decimal Salida
        {
            get { return _Salida; }
            set { _Salida = value; }
        }
        public Decimal Costo
        {
            get { return _Costo; }
            set { _Costo = value; }
        }
        public Decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }
        public Decimal SaldoInicial
        {
            get { return _SaldoInicial; }
            set { _SaldoInicial = value; }
        }
        public Decimal Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }
        public Object FechaUltCompra
        {
            get { return _FechaUltCompra; }
            set { _FechaUltCompra = value; }
        }
        public Int32 StockMin
        {
            get { return _StockMin; }
            set { _StockMin = value; }
        }
        public Int32 StockMax
        {
            get { return _StockMax; }
            set { _StockMax = value; }
        }
        public Decimal Existencia
        {
            get { return _Existencia; }
            set { _Existencia = value; }
        }

    }
}
