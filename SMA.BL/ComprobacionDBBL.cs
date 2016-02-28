using SMA.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.BL
{
    public class ComprobacionDBBL
    {
        public void CrearDB()
        {
            try
            {
                ComprobacionDB.CrearDB();
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        //public void InsertarDatos()
        //{
        //   if (ComprobacionDB.ValidacionBaseDatos()==true)
        //   {
        //       ComprobacionDB.InsertarDatos();
        //   }
        //}
      
    }
}
