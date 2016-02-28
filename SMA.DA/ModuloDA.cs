using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using System.Data.SqlClient;

namespace SMA.DA
{
    public static class ModuloDA
    {
        public static List<cModulo> Listar()
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarModulos";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cModulo> Lista = new List<cModulo>();
                    while (Reader.Read())
                    {
                        cModulo Modulo = new cModulo();
                        Modulo.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
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

            catch (SqlException Ex)
            {
                throw Ex;

            }

        }
    }
}
