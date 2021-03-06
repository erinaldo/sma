﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cConcepto
    {
        private Int16 _Codigo;

        public Int16 Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        private String _Tipo;

        public String Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }
        private String _Automatico;

        public String Automatico
        {
            get { return _Automatico; }
            set { _Automatico = value; }
        }
        private string _Notas;

        public string Notas
        {
            get { return _Notas; }
            set { _Notas = value; }
        }

        private String _Referencia;

        public String Referencia
        {
            get { return _Referencia; }
            set { _Referencia = value; }
        }

    }
}
