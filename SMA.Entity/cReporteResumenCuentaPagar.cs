﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
   public class cReporteResumenCuentaPagar: cCuentasPagar
    {
        private String _Tipo;

        public String Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }
    }
}
