using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using System.Data.SqlClient;

namespace SMA.DA
{
   public static class UnidadInventarioDA
    {
       public static List<cUnidadInventario> Listar()
       {
           try
           {
               //Declaramos la conexion hacia la base de datos
               using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspListarUnidadInventario";
                   //Creamos el command para la insercion
                   SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;
                   //Ejecutamos el lector 
                   SqlDataReader Reader = Cmd.ExecuteReader();


                   List<cUnidadInventario> Lista = new List<cUnidadInventario>();
                   while (Reader.Read())
                   {
                       cUnidadInventario Unidad = new cUnidadInventario();
                       Unidad.Codigo = Reader.GetInt32(Reader.GetOrdinal("ID"));
                       Unidad.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                       

                       //Agregamos el articulo a la lista
                       Lista.Add(Unidad);
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
