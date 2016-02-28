using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cReporteFactura
    {
        private DateTime _FechaCreacion;

        public DateTime FechaCreacion
        {
            get { return _FechaCreacion; }
            set { _FechaCreacion = value; }
        }
        private Decimal _SubTotal;

        public Decimal SubTotal
        {
            get { return _SubTotal; }
            set { _SubTotal = value; }
        }
        private Decimal _ImpuestosTotal;

        public Decimal ImpuestosTotal
        {
            get { return _ImpuestosTotal; }
            set { _ImpuestosTotal = value; }
        }
        private Decimal _DescuentoTotal;

        public Decimal DescuentoTotal
        {
            get { return _DescuentoTotal; }
            set { _DescuentoTotal = value; }
        }
        private Decimal _TotalGeneral;

        public Decimal TotalGeneral
        {
            get { return _TotalGeneral; }
            set { _TotalGeneral = value; }
        }
        private String _Observacion;

        public String Observacion
        {
            get { return _Observacion; }
            set { _Observacion = value; }
        }
        private String _Descripcion;

        public String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private String _CodigoArticulo;

        public String CodigoArticulo
        {
            get { return _CodigoArticulo; }
            set { _CodigoArticulo = value; }
        }

        private String _NombreCliente;

        public String NombreCliente
        {
            get { return _NombreCliente; }
            set { _NombreCliente = value; }
        }
        private String _RNC;

        public String RNC
        {
            get { return _RNC; }
            set { _RNC = value; }
        }
        private String _Direccion;

        public String Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        private String _Provincia;

        public String Provincia
        {
            get { return _Provincia; }
            set { _Provincia = value; }
        }
        private String _Ciudad;

        public String Ciudad
        {
            get { return _Ciudad; }
            set { _Ciudad = value; }
        }
        private String _Telefono;

        public String Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        private String _Fax;

        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        private Int64 _FacturaID;

        public Int64 FacturaID
        {
            get { return _FacturaID; }
            set { _FacturaID = value; }
        }
        private Int64 _ClienteID;

        public Int64 ClienteID
        {
            get { return _ClienteID; }
            set { _ClienteID = value; }
        }
        private Decimal _Cantidad;

        public Decimal Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        private Decimal _DescuentoValor;

        public Decimal DescuentoValor
        {
            get { return _DescuentoValor; }
            set { _DescuentoValor = value; }
        }

        private Decimal _Precio;

        public Decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        private Decimal _ImpuestoValor;

        public Decimal ImpuestoValor
        {
            get { return _ImpuestoValor; }
            set { _ImpuestoValor = value; }
        }

        private String _DireccionEnvio;

        public String DireccionEnvio
        {
            get { return _DireccionEnvio; }
            set { _DireccionEnvio = value; }
        }
        private Decimal _ImporteTotal;

        public Decimal ImporteTotal
        {
            get { return _ImporteTotal; }
            set { _ImporteTotal = value; }
        }

        private String _NCF;

        public String NCF
        {
            get { return _NCF; }
            set { _NCF = value; }
        }

        private String _TipoComprobante;

        public String TipoComprobante
        {
            get { return _TipoComprobante; }
            set { _TipoComprobante = value; }
        }

        private Int64 _ID;

        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private String _RazonSocial;

        public String RazonSocial
        {
            get { return _RazonSocial; }
            set { _RazonSocial = value; }
        }
        private String _TelefonoEmpresa;

        public String TelefonoEmpresa
        {
            get { return _TelefonoEmpresa; }
            set { _TelefonoEmpresa = value; }
        }
        private String _FaxEmpresa;

        public String FaxEmpresa
        {
            get { return _FaxEmpresa; }
            set { _FaxEmpresa = value; }
        }
        private String _DireccionEmpresa;

        public String DireccionEmpresa
        {
            get { return _DireccionEmpresa; }
            set { _DireccionEmpresa = value; }
        }
        private String _CiudadEmpresa;

        public String CiudadEmpresa
        {
            get { return _CiudadEmpresa; }
            set { _CiudadEmpresa = value; }
        }
        private String _ProvinciaEmpresa;

        public String ProvinciaEmpresa
        {
            get { return _ProvinciaEmpresa; }
            set { _ProvinciaEmpresa = value; }
        }
        private String _RNCEmpresa;

        public String RNCEmpresa
        {
            get { return _RNCEmpresa; }
            set { _RNCEmpresa = value; }
        }

        private String _Estatus;

        public String Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }

        private DateTime _FechaVencimiento;

        public DateTime FechaVencimiento
        {
            get { return _FechaVencimiento; }
            set { _FechaVencimiento = value; }
        }

        private String _Vendedor;

        public String Vendedor
        {
            get { return _Vendedor; }
            set { _Vendedor = value; }
        }

        private DateTime _FechaDesde;

        public DateTime FechaDesde
        {
            get { return _FechaDesde; }
            set { _FechaDesde = value; }
        }

        private DateTime _FechaHasta;

        public DateTime FechaHasta
        {
            get { return _FechaHasta; }
            set { _FechaHasta = value; }
        }

        private String _Codicion;

        public String Codicion
        {
            get { return _Codicion; }
            set { _Codicion = value; }
        }

        


    }
}
