﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMA.Entity
{
    public abstract class cComponente
    {
        private int _Codigo;

        public int Codigo
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
        private string _Notas;

        public string Notas
        {
            get { return _Notas; }
            set { _Notas = value; }
        }

    }
}
