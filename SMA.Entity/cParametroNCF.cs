using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cParametroNCF
    {
        private Int32 _ID;

        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private String _NumeroInicial;

        public String NumeroInicial
        {
            get { return _NumeroInicial; }
            set { _NumeroInicial = value; }
        }
        private Int32 _Cantidad;

        public Int32 Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        private Int32 _Contador;

        public Int32 Contador
        {
            get { return _Contador; }
            set { _Contador = value; }
        }
        private Object _Estatus;

        public Object Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }
        private Object _ComprobanteID;

        public Object ComprobanteID
        {
            get { return _ComprobanteID; }
            set { _ComprobanteID = value; }
        }
        private String _UltimoNumero;

        public String UltimoNumero
        {
            get { return _UltimoNumero; }
            set { _UltimoNumero = value; }
        }
        private DateTime _FechaCreacion;

        public DateTime FechaCreacion
        {
            get { return _FechaCreacion; }
            set { _FechaCreacion = value; }
        }
        private DateTime _FechaModificacion;

        public DateTime FechaModificacion
        {
            get { return _FechaModificacion; }
            set { _FechaModificacion = value; }
        }
    }
}
