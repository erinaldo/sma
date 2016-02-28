using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using System.Data.SqlClient;

namespace SMA.DA
{
   public static class RelacionModuloPerfilDA
    {
       public static List<cRelacionModuloPerfil> ListarRelacionPerfilModulo(Int32 PerfilID)
       {

           try
           {
               //Declaramos la conexion hacia la base de datos
               using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspListarRelacionModuloPerfil";
                   //Creamos el command para la insercion
                   SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;
                   
                   //Parametros
                   Cmd.Parameters.AddWithValue("PerfilID", PerfilID);

                   //Ejecutamos el lector 
                   SqlDataReader Reader = Cmd.ExecuteReader();


                   List<cRelacionModuloPerfil> Lista = new List<cRelacionModuloPerfil>();
                   while (Reader.Read())
                   {
                       cRelacionModuloPerfil Relacion = new cRelacionModuloPerfil();
                       //Relacion.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                       Relacion.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                       Relacion.DescripcionModulo = Reader.GetString(Reader.GetOrdinal("Modulo"));
                       Relacion.DescripcionPerfil = Reader.GetString(Reader.GetOrdinal("Perfil"));
                       Relacion.PerfilID = Reader.GetInt32(Reader.GetOrdinal("PerfilID"));
                       Relacion.ModuloID = Reader.GetInt32(Reader.GetOrdinal("ModuloID"));

                       //Agregamos el articulo a la lista
                       Lista.Add(Relacion);
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

       public static void CrearRelacionModuloPerfil(cRelacionPerfilModulo Relacion)
       {
           try
           {

               //Declaramos la conexion hacia la base de datos
               using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspInsertarRelacionModuloPerfil";
                   //Creamos el command para la insercion
                   SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;

                   //Parametros
                   Cmd.Parameters.AddWithValue("ModuloID", Relacion.ModuloID);
                   Cmd.Parameters.AddWithValue("PerfilID", Relacion.PerfilID);
                   
                   Cmd.ExecuteNonQuery();
               }


           }
           catch (SqlException Ex)
           {
               throw Ex;
           }
       }

       public static void EliminarRelacionModuloPerfil(Int32 RelacionID)
       {
         
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspEliminarRelacionModuloPerfil";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("ID", RelacionID);

                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

       public static Boolean Existe(Int32 PerfilID, Int32 ModuloID)
       {
           //COMPROBAMOS LA EXISTENCIA DE LA RELACION
           List<cRelacionModuloPerfil> Lista = (from C in RelacionModuloPerfilDA.ListarRelacionPerfilModulo(PerfilID)
                                                where (Int32)C.ModuloID == ModuloID
                                                select C).ToList();

           //SI EL VALOR ES IGUAL A 0 ENTONCES NO EXISTE RELACION
           if(Lista.Count==0)
           {
               return false;
           }
           else
           {
               return true;
           }
       }
       
    }
}
