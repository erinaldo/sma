using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cReporteVentasPorCliente
    {
        private Int32 _ID;

        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
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

        private String _NombreComercial;

        public String NombreComercial
        {
            get { return _NombreComercial; }
            set { _NombreComercial = value; }
        }
        private String _Unidad;

        public String Unidad
        {
            get { return _Unidad; }
            set { _Unidad = value; }
        }
        private Double _Cantidad;

        public Double Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        private Double _PrecioTotal;

        public Double PrecioTotal
        {
            get { return _PrecioTotal; }
            set { _PrecioTotal = value; }
        }




    }
}
