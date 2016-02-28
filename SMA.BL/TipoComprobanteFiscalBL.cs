using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using SMA.DA;

namespace SMA.BL
{
    public class TipoComprobanteFiscalBL
    {
        public List<cTipoComprobanteFiscal> Listar()
        {
            //Lista tipos de comprobantes fiscales
            try
            {
                return TipoComprobanteDA.Listar();
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
