using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using System.Data.SqlClient;

namespace SMA.DA
{
   public static class EmpresaDA
    {
       public static cEmpresa Lista()
       {
           try
           {
               //Declaramos la conexion hacia la base de datos
               using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspEmpresa";
                   //Creamos el command para la insercion
                   SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;
                   
                   SqlDataReader Reader = Cmd.ExecuteReader();

                   cEmpresa Empresa = new cEmpresa();
                   while (Reader.Read())
                   {
                       Empresa.ID = Reader.IsDBNull(Reader.GetOrdinal("ID"))? -1:Reader.GetInt32(Reader.GetOrdinal("ID"));
                       Empresa.RazonSocial = Reader.IsDBNull(Reader.GetOrdinal("RazonSocial")) ? null : Reader.GetString(Reader.GetOrdinal("RazonSocial"));
                       Empresa.Telefono = Reader.IsDBNull(Reader.GetOrdinal("Telefono")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono"));
                       Empresa.Fax = Reader.IsDBNull(Reader.GetOrdinal("Fax")) ? null : Reader.GetString(Reader.GetOrdinal("Fax"));
                       Empresa.Direccion = Reader.IsDBNull(Reader.GetOrdinal("Direccion")) ? null : Reader.GetString(Reader.GetOrdinal("Direccion"));
                       Empresa.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                       Empresa.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia")) ? null : Reader.GetString(Reader.GetOrdinal("Provincia"));
                       Empresa.RNC = Reader.IsDBNull(Reader.GetOrdinal("RNC")) ? null : Reader.GetString(Reader.GetOrdinal("RNC"));
                   }
                   Conn.Close();
                   return Empresa;
               }
           }
           catch (SqlException Ex)
           {
               return null;
               throw Ex;

           }
       }

       public static void Actualizar(cEmpresa Empresa)
       {
           try
           {

               //Declaramos la conexion hacia la base de datos
               using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspActualizarEmpresa";
                   //Creamos el command para la insercion
                   SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;

                   //Parametros
                   Cmd.Parameters.AddWithValue("ID", Empresa.ID);
                   Cmd.Parameters.AddWithValue("RazonSocial", Empresa.RazonSocial);
                   Cmd.Parameters.AddWithValue("RNC", Empresa.RNC);
                   Cmd.Parameters.AddWithValue("Direccion", Empresa.Direccion);
                   Cmd.Parameters.AddWithValue("Provincia", Empresa.Provincia);
                   Cmd.Parameters.AddWithValue("Ciudad", Empresa.Ciudad);
                   Cmd.Parameters.AddWithValue("Telefono", Empresa.Telefono);
                   Cmd.Parameters.AddWithValue("Fax", Empresa.Fax);

                   Cmd.ExecuteNonQuery();
               }


           }
           catch (SqlException Ex)
           {
               throw Ex;
           }
       }

    }
}
