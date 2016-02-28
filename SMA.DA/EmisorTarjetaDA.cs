using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SMA.Entity;


namespace SMA.DA
{
   public static class EmisorTarjetaDA
    {
       public static List<cEmisorTarjeta> Listar()
       {

           try
           {
               //Declaramos la conexion hacia la base de datos
               using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspListarEmisorTarjeta";
                   //Creamos el command para la insercion
                   SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;
                   //Ejecutamos el lector 
                   SqlDataReader Reader = Cmd.ExecuteReader();


                   List<cEmisorTarjeta> Lista = new List<cEmisorTarjeta>();
                   while (Reader.Read())
                   {
                       cEmisorTarjeta Emisor = new cEmisorTarjeta();
                       Emisor.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                       Emisor.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                       //Emisor.Notas = Reader.GetString(Reader.GetOrdinal("Notas"));

                       //Agregamos el articulo a la lista
                       Lista.Add(Emisor);
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
