using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMA.DA
{
    class cConexion
    {
        //Clase que almacena la cadena de conexion a la base de datos
        public static String CadenaConexion()
        {
            //Cadena de conexion para la base de datos
            //return "Data Source=MANYLAPTOP-PC\\MANYLAPTOP;Initial Catalog=GymDB;Integrated Security=True";
            //return "Data Source=.\\SQLEXPRESS;Initial Catalog=SMADB;Integrated Security=True";
            return "Data Source=LAGUARIDA-PC;Initial Catalog=SMADB;Integrated Security=True";
        }
    }
}
