using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMA.Entity
{
   public class cMovInventario
    {
        private Int64 _ID;
        private DateTime _Fecha;
        private Object _InventarioID;
        private Decimal _Cantidad;
        private Object _ConceptoID;
        private Object _DocumentoID;
        private Decimal _Costo;
        private Decimal _Precio;
        private String _Notas;
        private Object _Estatus;
        private Decimal _Balance;
        private Boolean _ModificarPrecio;
        private Object _CliPv;

        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        public Object InventarioID
        {
            get { return _InventarioID; }
            set { _InventarioID = value; }
        }
        public Decimal Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        public Object ConceptoID
        {
            get { return _ConceptoID; }
            set { _ConceptoID = value; }
        }
        public Object DocumentoID
        {
            get { return _DocumentoID; }
            set { _DocumentoID = value; }
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
        public String Notas
        {
            get { return _Notas; }
            set { _Notas = value; }
        }
        public Object Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }
        public Decimal Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }
        public Boolean ModificarPrecio
        {
            get { return _ModificarPrecio; }
            set { _ModificarPrecio = value; }
        }
        public Object CliPv
        {
            get { return _CliPv; }
            set { _CliPv = value; }
        }


    }
}
