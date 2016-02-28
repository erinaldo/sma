using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMA.Entity
{
    public class cInventario
    {
        private Int64 _ID;
        private string _CodigoArticulo;
        private string _Descripcion;
        private string _TipoArticulo;
        private int _UbicacionID;
        private Decimal _UltCosto;
        private Decimal _PrecioPublico;
        private Decimal _Precio2;
        private Decimal _Precio3;
        private Decimal _Precio4;
        private Object _ImpuestoID;
        private int _StockMax;
        private int _StockMin;
        private Decimal _Existencia;
        private string _ImagenURL;
        private Object _FamiliaID;
        private Object _MarcaID;
        private Decimal _CostoPromedio;
        private string _Notas;
        private DateTime _FechaCreacion;
        private DateTime _FechaModificacion;
        private Object _EstatusID;
        private Object _UnidadEntradaID;
        private Object _UnidadSalidaID;
        private Object _FechaVencimiento;
        private Boolean _AvisarVencimiento;
        private Boolean _FacturarSinExistencia;
        private Object _ProveedorID1;
        private Object _ProveedorID2;
        private byte[] _Imagen;
        private Object _FechaUltVenta;
        private Decimal _MontoUltVenta;
        private Decimal _CantUltVenta;
        private Decimal _MontoUltCompra;
        private Decimal _CantUltCompra;

        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string CodigoArticulo
        {
            get { return _CodigoArticulo; }
            set { _CodigoArticulo = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public string TipoArticulo
        {
            get { return _TipoArticulo; }
            set { _TipoArticulo = value; }
        }
        public int UbicacionID
        {
            get { return _UbicacionID; }
            set { _UbicacionID = value; }
        }
        public Decimal UltCosto
        {
            get { return _UltCosto; }
            set { _UltCosto = value; }
        }
        public Decimal PrecioPublico
        {
            get { return _PrecioPublico; }
            set { _PrecioPublico = value; }
        }
        public Decimal Precio2
        {
            get { return _Precio2; }
            set { _Precio2 = value; }
        }
        public Decimal Precio3
        {
            get { return _Precio3; }
            set { _Precio3 = value; }
        }
        public Decimal Precio4
        {
            get { return _Precio4; }
            set { _Precio4 = value; }
        }
        public Object ImpuestoID
        {
            get { return _ImpuestoID; }
            set { _ImpuestoID = value; }
        }
        public int StockMax
        {
            get { return _StockMax; }
            set { _StockMax = value; }
        }
        public int StockMin
        {
            get { return _StockMin; }
            set { _StockMin = value; }
        }
        public Decimal Existencia
        {
            get { return _Existencia; }
            set { _Existencia = value; }
        }
        public string ImagenURL
        {
            get { return _ImagenURL; }
            set { _ImagenURL = value; }
        }
        public Object FamiliaID
        {
            get { return _FamiliaID; }
            set { _FamiliaID = value; }
        }
        public Object MarcaID
        {
            get { return _MarcaID; }
            set { _MarcaID = value; }
        }
        public Decimal CostoPromedio
        {
            get { return _CostoPromedio; }
            set { _CostoPromedio = value; }
        }
        public string Notas
        {
            get { return _Notas; }
            set { _Notas = value; }
        }
        public DateTime FechaCreacion
        {
            get { return _FechaCreacion; }
            set { _FechaCreacion = value; }
        }
        public DateTime FechaModificacion
        {
            get { return _FechaModificacion; }
            set { _FechaModificacion = value; }
        }
        public Object EstatusID
        {
            get { return _EstatusID; }
            set { _EstatusID = value; }
        }
        public Object UnidadEntradaID
        {
            get { return _UnidadEntradaID; }
            set { _UnidadEntradaID = value; }
        }
        public Object UnidadSalidaID
        {
            get { return _UnidadSalidaID; }
            set { _UnidadSalidaID = value; }
        }
        public Object FechaVencimiento
        {
            get { return _FechaVencimiento; }
            set { _FechaVencimiento = value; }
        }
        public Boolean AvisarVencimiento
        {
            get { return _AvisarVencimiento; }
            set { _AvisarVencimiento = value; }
        }
        public Boolean FacturarSinExistencia
        {
            get { return _FacturarSinExistencia; }
            set { _FacturarSinExistencia = value; }
        }
        public Object ProveedorID1
        {
            get { return _ProveedorID1; }
            set { _ProveedorID1 = value; }
        }
        public Object ProveedorID2
        {
            get { return _ProveedorID2; }
            set { _ProveedorID2 = value; }
        }
        public byte[] Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }
        public Object FechaUltVenta
        {
            get { return _FechaUltVenta; }
            set { _FechaUltVenta = value; }
        }
        public Decimal MontoUltVenta
        {
            get { return _MontoUltVenta; }
            set { _MontoUltVenta = value; }
        }
        public Decimal CantUltVenta
        {
            get { return _CantUltVenta; }
            set { _CantUltVenta = value; }
        }
        private Object _FechaUltCompra;
        public Object FechaUltCompra
{
  get { return _FechaUltCompra; }
  set { _FechaUltCompra = value; }
}
        public Decimal MontoUltCompra
{
    get { return _MontoUltCompra; }
    set { _MontoUltCompra = value; }
}
        public Decimal CantUltCompra
{
    get { return _CantUltCompra; }
    set { _CantUltCompra = value; }
}
    }
}
