using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SMA.Entity;

namespace SMA.DA
{
   public static class MovCajaCobroDA
    {
       public static Int32 Crear(cMovCajaCobro Movimiento)
       {
           try
           {

               //Declaramos la conexion hacia la base de datos
               using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspInsertarMovCobroCaja";
                   //Creamos el command para la insercion
                   SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;

                   //Parametros
                   Cmd.Parameters.AddWithValue("Fecha", Movimiento.Fecha);
                   Cmd.Parameters.AddWithValue("FacturaID", Movimiento.FacturaID);
                   Cmd.Parameters.AddWithValue("MontoEfectivo", Movimiento.MontoEfectivo);
                   Cmd.Parameters.AddWithValue("MontoTarjeta", Movimiento.MontoTarjeta);
                   Cmd.Parameters.AddWithValue("NumeroTarjeta", Movimiento.NumeroTarjeta);
                   Cmd.Parameters.AddWithValue("FechaExpiracion", Movimiento.FechaExpiracion);
                   Cmd.Parameters.AddWithValue("TipoTarjetaID", Movimiento.TipoTarjetaID);
                   Cmd.Parameters.AddWithValue("EmisorID", Movimiento.EmisorID);
                                    

                   Int32 TicketID = Convert.ToInt32(Cmd.ExecuteScalar());
                   //Cerra la conexion
                   Conn.Close();

                   return TicketID;
               }


           }
           catch (SqlException Ex)
           {
               return -1;
               throw Ex;
           }
       } 

       public static List<cMovCajaCobro> ReporteCaja(DateTime FechaDesde, DateTime FechaHasta)
       {
           try
           {
               //Declaramos la conexion hacia la base de datos
               using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspReporteCajaCobro";
                   //Creamos el command para la insercion
                   SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;

                   Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                   Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);

                   //Ejecutamos el lector 
                   SqlDataReader Reader = Cmd.ExecuteReader();


                   List<cMovCajaCobro> Lista = new List<cMovCajaCobro>();
                   while (Reader.Read())
                   {
                       cMovCajaCobro Movimiento = new cMovCajaCobro();
                       Movimiento.Fecha = Reader.GetDateTime(Reader.GetOrdinal("Fecha"));
                       Movimiento.MontoEfectivo = Reader.IsDBNull(Reader.GetOrdinal("MontoEfectivo")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("MontoEfectivo"));
                       Movimiento.MontoTarjeta = Reader.IsDBNull(Reader.GetOrdinal("MontoTarjeta")) ? 0: Reader.GetDecimal(Reader.GetOrdinal("MontoTarjeta"));
                       Movimiento.FacturaID = Reader.GetInt64(Reader.GetOrdinal("FacturaID"));
                       //Agregamos el articulo a la lista
                       Lista.Add(Movimiento);
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
