using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cReporteUtilidadVentas
    {
        private String _CodigoArticulo;

        public String CodigoArticulo
        {
            get { return _CodigoArticulo; }
            set { _CodigoArticulo = value; }
        }
        private String _Descripcion;

        public String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        private Double _Cantidad;

        public Double Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        private Double _CostoTotal;

        public Double CostoTotal
        {
            get { return _CostoTotal; }
            set { _CostoTotal = value; }
        }
        private Double _PrecioTotal;

        public Double PrecioTotal
        {
            get { return _PrecioTotal; }
            set { _PrecioTotal = value; }
        }
        private Double _Utilidad;

        public Double Utilidad
        {
            get { return _Utilidad; }
            set { _Utilidad = value; }
        }
        private Double _PorcientoUtilidad;

        public Double PorcientoUtilidad
        {
            get { return _PorcientoUtilidad; }
            set { _PorcientoUtilidad = value; }
        }
        private Double _Margen;

        public Double Margen
        {
            get { return _Margen; }
            set { _Margen = value; }
        }

        private String _Movimientos;

        public String Movimientos
        {
            get { return _Movimientos; }
            set { _Movimientos = value; }
        }
    }
}
