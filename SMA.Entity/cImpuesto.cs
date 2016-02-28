using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
   public class cImpuesto
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        private Decimal _Valor;

        public Decimal Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }
        private string _Notas;

        public string Notas
        {
            get { return _Notas; }
            set { _Notas = value; }
        }
    }
}
