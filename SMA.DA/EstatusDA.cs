using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SMA.Entity;

namespace SMA.DA
{
    public static class EstatusDA
    {
        public static List<cEstatus> Listar()
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarEstatus";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cEstatus> Lista = new List<cEstatus>();
                    while (Reader.Read())
                    {
                        cEstatus Estatus = new cEstatus();
                        Estatus.Codigo = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Estatus.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Estatus.Notas = Reader.GetString(Reader.GetOrdinal("Notas"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Estatus);
                    }
                    //Cerramos la conexion
                    Conn.Close();
                    //Retornamos la lista de clientes
                    return Lista;
                }
            }
            catch (SqlException Ex)
            {
                return null;
                throw Ex;

            }

        }
    }
}
