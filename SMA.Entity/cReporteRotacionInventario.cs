using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cReporteRotacionInventario
    {
        private String _CodigoArticulo;
        private String _DescripcionArticulo;
        private Decimal _Cantidad;
        private Decimal _Existencia;
        private Decimal _StockMax;
        private String _Movimientos;

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
        public Decimal Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        public Decimal Existencia
        {
            get { return _Existencia; }
            set { _Existencia = value; }
        }
        public Decimal StockMax
        {
            get { return _StockMax; }
            set { _StockMax = value; }
        }
        public String Movimientos
        {
            get { return _Movimientos; }
            set { _Movimientos = value; }
        }


    }
}
