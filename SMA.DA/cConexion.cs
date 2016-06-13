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
            return "Server=127.0.0.1;Database=smadb;Uid=root;Pwd=eduardo170983;";
            //return "Data Source=.\\SQLEXPRESS;Initial Catalog=SMADB;Integrated Security=True";
            //return "Data Source=LAGUARIDA-PC;Initial Catalog=SMADB;Integrated Security=True";
        }
    }
}
