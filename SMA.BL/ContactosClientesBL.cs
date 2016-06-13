using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using SMA.DA;

namespace SMA.BL
{
   public class ContactosClientesBL
    {
       public void GuardarCambios(cContactos Contacto)
       {
           //GUARDAMOS LOS CAMBIOS ENVIADOS
           try
           {
               //SI EXISTE EL CONTACTO ACTUALIZAMOS 
               if(ContactosClientesDA.Existe(Contacto.Codigo))
               {
                   ContactosClientesDA.Actualizar(Contacto);
               }
               else
               {
                   //AGREGAMOS UN NUEVO CONTACTO
                   ContactosClientesDA.Crear(Contacto);
               }
           }
           catch(Exception Ex)
           {
               throw Ex;
           }
       }

       public cContactos BuscarPorID(Int32 Codigo)
       {
           try
           {
               return ContactosClientesDA.BuscarPorID(Codigo);
           }
           catch(Exception Ex)
           {
               throw Ex;
           }
       }

       public List<cContactos> Listar(Int32 Codigo)
       {
           try
           {
               return ContactosClientesDA.Listar(Codigo);
           }
           catch(Exception Ex)
           {
               throw Ex;
           }
       }

       public void Eliminar(Int32 Codigo)
       {
           //ELIMINA UN CONTACTO POR CODIGO
           try
           {
               ContactosClientesDA.Eliminar(Codigo);
           }
           catch(Exception Ex)
           {
               throw Ex;
           }
       }

       public List<cDepartamentos> ListarDepartamentos()
       {
           try
           {
               return ContactosClientesDA.ListarDepartamentos();
           }
           catch(Exception Ex)
           {
               throw Ex;
           }
       }
    }
}
