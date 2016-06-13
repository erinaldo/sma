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
   public static class RelacionModuloPerfilDA
    {
       public static List<cRelacionModuloPerfil> ListarRelacionPerfilModulo(Int16 PerfilID)
       {

           try
           {
               //Declaramos la conexion hacia la base de datos
               using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspListarRelPerfMod";
                   //Creamos el command para la insercion
                   MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;
                   
                   //Parametros
                   Cmd.Parameters.AddWithValue("p_Codigo", PerfilID);

                   //Ejecutamos el lector 
                   MySqlDataReader Reader = Cmd.ExecuteReader();


                   List<cRelacionModuloPerfil> Lista = new List<cRelacionModuloPerfil>();
                   while (Reader.Read())
                   {
                       cRelacionModuloPerfil Relacion = new cRelacionModuloPerfil();
                       //Relacion.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                       Relacion.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                       Relacion.DescripcionModulo = Reader.GetString(Reader.GetOrdinal("Modulo"));
                       Relacion.DescripcionPerfil = Reader.GetString(Reader.GetOrdinal("Perfil"));
                       Relacion.PerfilID = Reader.GetInt16(Reader.GetOrdinal("CodigoPerf"));
                       Relacion.ModuloID = Reader.GetInt16(Reader.GetOrdinal("CodigoMod"));

                       //Agregamos el articulo a la lista
                       Lista.Add(Relacion);
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

       public static void CrearRelacionModuloPerfil(cRelacionPerfilModulo Relacion)
       {
           try
           {

               //Declaramos la conexion hacia la base de datos
               using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
               {
                   Conn.Open();
                   //Nombre del procedimiento
                   string StoreProc = "uspInsertarRelPerfMod";
                   //Creamos el command para la insercion
                   MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                   Cmd.CommandType = CommandType.StoredProcedure;

                   //Parametros
                   Cmd.Parameters.AddWithValue("p_CodigoMod", Relacion.ModuloID);
                   Cmd.Parameters.AddWithValue("p_CodigoPerf", Relacion.PerfilID);
                   
                   Cmd.ExecuteNonQuery();
               }


           }
           catch (MySqlException Ex)
           {
               throw Ex;
           }
       }

       public static void EliminarRelacionModuloPerfil(Int32 RelacionID)
       {
         
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspEliminarRelacionModuloPerfil";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("p_Codigo", RelacionID);

                    Cmd.ExecuteNonQuery();
                }


            }
            catch (MySqlException Ex)
            {
                throw Ex;
            }
        }

       public static Boolean Existe(Int16 PerfilID, Int16 ModuloID)
       {
           //COMPROBAMOS LA EXISTENCIA DE LA RELACION
           List<cRelacionModuloPerfil> Lista = (from C in RelacionModuloPerfilDA.ListarRelacionPerfilModulo(PerfilID)
                                                where (Int16)C.ModuloID == ModuloID
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
