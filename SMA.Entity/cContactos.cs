using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
   public class cContactos
    {
        private Int32 _Codigo;

        public Int32 Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        private String _Nombre;

        public String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        private String _Cargo;

        public String Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }
        private String _Correo;

        public String Correo
        {
            get { return _Correo; }
            set { _Correo = value; }
        }
        private String _Telefono1;

        public String Telefono1
        {
            get { return _Telefono1; }
            set { _Telefono1 = value; }
        }
        private String _Telefono2;

        public String Telefono2
        {
            get { return _Telefono2; }
            set { _Telefono2 = value; }
        }
        private String _Fax1;

        public String Fax1
        {
            get { return _Fax1; }
            set { _Fax1 = value; }
        }
        private String _Fax2;

        public String Fax2
        {
            get { return _Fax2; }
            set { _Fax2 = value; }
        }
        private String _Notas;

        public String Notas
        {
            get { return _Notas; }
            set { _Notas = value; }
        }
        private Object _CodigoDepartamento;

        public Object CodigoDepartamento
        {
            get { return _CodigoDepartamento; }
            set { _CodigoDepartamento = value; }
        }
        private Int32 _CodigoCliente;

        public Int32 CodigoCliente
        {
            get { return _CodigoCliente; }
            set { _CodigoCliente = value; }
        }
    }
}
