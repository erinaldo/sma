using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using SMA.DA;

namespace SMA.BL
{
   public class PerfilBL
    {
       public List<cPerfiles> Listar()
       {
           //LISTA DE PERFILES
           try
           {
               return PerfilesDA.Listar();
           }
           catch(Exception Ex)
           {
               throw Ex;
           }
       }

       public cPerfiles BuscarPorID(int ID)
       {
           try
           {
              return PerfilesDA.BuscarPorID(ID);
           }
           catch(Exception Ex)
           {
               throw Ex;
           }
       }

       public void GuardarCambios(cPerfiles Perfil)
       {
           //Si el almacen existe entonces actualizamos 
           if (PerfilesDA.Existe(Perfil.ID))
           {
               PerfilesDA.Actualizar(Perfil);
           }
           else
           //Si el almacen es nuevo entonces creamos
           {
               PerfilesDA.Crear(Perfil);
           }
       }

       public void Eliminar(Int32 ID)
       {
           try
           {
               PerfilesDA.Eliminar(ID);
           }
           catch(Exception Ex)
           {
               throw new Exception("No se puede eliminar el perfil, existen usuarios asociados al mismo");
           }
       }

      

    }
}
