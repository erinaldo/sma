using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Entity
{
    public class cDepartamentos
    {
        private SByte _Codigo;

public SByte Codigo
{
  get { return _Codigo; }
  set { _Codigo = value; }
}
        private String _Descripcion;

public String Descripcion
{
  get { return _Descripcion; }
  set { _Descripcion = value; }
}
    }
}
