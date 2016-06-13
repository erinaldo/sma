using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cDireccionCliente
    {
        private Int32 _Codigo;

        public Int32 Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        private String _CodigoDireccion;

        public String CodigoDireccion
        {
            get { return _CodigoDireccion; }
            set { _CodigoDireccion = value; }
        }
        private String _Nombre;

        public String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        private String _Direccion;

        public String Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        private String _CodigoPostal;

        public String CodigoPostal
        {
            get { return _CodigoPostal; }
            set { _CodigoPostal = value; }
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
        private String _Pais;

        public String Pais
        {
            get { return _Pais; }
            set { _Pais = value; }
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
        private String _Correo;

        public String Correo
        {
            get { return _Correo; }
            set { _Correo = value; }
        }
        private String _Notas;

        public String Notas
        {
            get { return _Notas; }
            set { _Notas = value; }
        }
    }
}
