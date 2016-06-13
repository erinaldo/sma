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
    public static class RolesDA
    {
        public static List<cRoles> Listar(Int32 CodigoModulo)
        {
            //BUSCAMOS LOS ROLES RELACIONADOS CON EL MODULO
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarRolPorCodigoMod";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    
                    //Parametro
                    Cmd.Parameters.AddWithValue("p_CodigoModulo", CodigoModulo);

                    //Ejecutamos el lector 
                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cRoles> Lista = new List<cRoles>();
                    while (Reader.Read())
                    {
                        cRoles Rol = new cRoles();
                        Rol.Codigo = Reader.GetInt16(Reader.GetOrdinal("Codigo"));
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

            catch (MySqlException Ex)
            {
                throw Ex;

            }

        }
    }
}
