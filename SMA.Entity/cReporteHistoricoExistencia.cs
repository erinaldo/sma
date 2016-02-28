using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cReporteHistoricoExistencia:cMovInventario
    {
        private string _DescripcionArticulo;

        public string DescripcionArticulo
        {
            get { return _DescripcionArticulo; }
            set { _DescripcionArticulo = value; }
        }

    }
}
