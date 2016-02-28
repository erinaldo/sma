using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cReporteDetalladoDocumento
    {

        public string NombreComercial { get; set; }

        public Int64 DocumentoID { get; set; }

        public DateTime FechaCreacion { get; set; }

        public Decimal TotalGeneral { get; set; }

        public Decimal DescuentoTotal { get; set; }

        public Decimal ImpuestosTotal { get; set; }

        public Decimal SubTotal { get; set; }

        public string NombreVendedor { get; set; }



        public object FechaCreacionDesde { get; set; }

        public object FechaCreacionHasta { get; set; }

        public object FechaVencimientoDesde { get; set; }

        public object FechaVencimientoHasta { get; set; }

        public object DocumentoDesde { get; set; }

        public object DocumentoHasta { get; set; }

        public string CodigoArticulo { get; set; }

        public string DescripcionArticulo { get; set; }

        public Decimal Cantidad { get; set; }

        public Decimal Precio { get; set; }

        public Decimal ComisionVenta { get; set; }

        public Decimal DescuentoValor { get; set; }

        public Decimal ImpuestoValor { get; set; }

        public string TipoProducto { get; set; }

        public Int64 Referencia { get; set; }

        public Decimal ValorComision { get; set; }
    }
}
