using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using SMA.DA;

namespace SMA.BL
{
    public class EmpresaBL
    {
        public cEmpresa Lista()
        {
            return EmpresaDA.Lista();
        }

        public void Actualizar(cEmpresa Empresa)
        {
            EmpresaDA.Actualizar(Empresa);
        }
    }
}
