using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cReporteResumenComisionVenta
    {
        private Int32 _CodigoVendedor;

        public Int32 CodigoVendedor
        {
            get { return _CodigoVendedor; }
            set { _CodigoVendedor = value; }
        }
        private String _NombreVendedor;

        public String NombreVendedor
        {
            get { return _NombreVendedor; }
            set { _NombreVendedor = value; }
        }
        private String _TipoDocumento;

        public String TipoDocumento
        {
            get { return _TipoDocumento; }
            set { _TipoDocumento = value; }
        }
        private Int32 _CantidadVentas;

        public Int32 CantidadVentas
        {
            get { return _CantidadVentas; }
            set { _CantidadVentas = value; }
        }
        private Int32 _CantidadArticulos;

        public Int32 CantidadArticulos
        {
            get { return _CantidadArticulos; }
            set { _CantidadArticulos = value; }
        }
        private Decimal _SubTotal;

        public Decimal SubTotal
        {
            get { return _SubTotal; }
            set { _SubTotal = value; }
        }
        private Decimal _ComisionTotal;

        public Decimal ComisionTotal
        {
            get { return _ComisionTotal; }
            set { _ComisionTotal = value; }
        }

        private DateTime _FechaInicial;

        public DateTime FechaInicial
        {
            get { return _FechaInicial; }
            set { _FechaInicial = value; }
        }
        private DateTime _FechaFin;

        public DateTime FechaFin
        {
            get { return _FechaFin; }
            set { _FechaFin = value; }
        }
    }
}
