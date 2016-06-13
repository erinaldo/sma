using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace SMA.DA
{
    public static class ModuloDA
    {
        public static List<cModulo> Listar()
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarMod";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecutamos el lector 
                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cModulo> Lista = new List<cModulo>();
                    while (Reader.Read())
                    {
                        cModulo Modulo = new cModulo();
                        Modulo.Codigo = Reader.GetInt16(Reader.GetOrdinal("Codigo"));
                        Modulo.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Modulo.Notas = Reader.IsDBNull(Reader.GetOrdinal("Notas")) ? null : Reader.GetString(Reader.GetOrdinal("Notas"));
                        //Agregamos el articulo a la lista
                        Lista.Add(Modulo);
                    }
                    //Cerramos la conexion
                    Conn.Close();
                    //Retornamos la lista de clientes
                    return Lista;
                }
            }

            catch (MySqlException Ex)
            {
                throw Ex;

            }

        }
    }
}
