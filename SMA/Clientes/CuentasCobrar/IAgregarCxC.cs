using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.Clientes.CuentasPagar
{
    interface IAgregarCxC
    {
        void SeleccionarDocumento(String Documento);   //Seleccion de documento para transaccion
        void SeleccionarReferencia(String Referencia); //Seleccion de Referencia para transaccion   
        void SeleccionarCliente(Int64 ClienteID);   //Seleccion de Cliente para transaccion
    }
}
