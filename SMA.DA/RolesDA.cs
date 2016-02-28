using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using System.Data.SqlClient;

namespace SMA.DA
{
    public static class RolesDA
    {
        public static List<cRoles> Listar()
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarRoles";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cRoles> Lista = new List<cRoles>();
                    while (Reader.Read())
                    {
                        cRoles Rol = new cRoles();
                        Rol.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Rol.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        
                        //Agregamos el articulo a la lista
                        Lista.Add(Rol);
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
