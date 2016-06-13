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
    public static class RelacionModuloPerfilRolDA
    {
        public static List<cRelacionModuloPerfilRol> ListarRelacionPerfilRol(Int32 RelacionID)
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarRelPerfModRol";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("p_CodigoModPerf", RelacionID);

                    //Ejecutamos el lector 
                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cRelacionModuloPerfilRol> Lista = new List<cRelacionModuloPerfilRol>();
                    while (Reader.Read())
                    {
                        cRelacionModuloPerfilRol Relacion = new cRelacionModuloPerfilRol();
                        //Relacion.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Relacion.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                        Relacion.DescripcionRol = Reader.GetString(Reader.GetOrdinal("Rol"));
                        Relacion.CodigoRol = Reader.GetInt16(Reader.GetOrdinal("CodigoRol"));
                        Relacion.ModuloPerfilID = Reader.GetInt32(Reader.GetOrdinal("CodigoModPerf"));
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




        public static void CrearRelacionModuloPerfilRol(cRelacionModuloPerfilRol Relacion)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarRelPerfModRol";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("p_CodigoModPerf", Relacion.ModuloPerfilID);
                    Cmd.Parameters.AddWithValue("p_CodigoRol", Relacion.CodigoRol);

                    Cmd.ExecuteNonQuery();
                }


            }
            catch (MySqlException Ex)
            {
                throw Ex;
            }
        }

        public static void EliminarRelacionModuloPerfilRol(Int32 RelacionID)
        {

            try
            {

                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspEliminarRolAsignado";
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

        public static Boolean Existe(Int32 RelacionID, Int16 RolID)
        {
            //COMPROBAMOS LA EXISTENCIA DE LA RELACION
            List<cRelacionModuloPerfilRol> Lista = (from C in ListarRelacionPerfilRol(RelacionID)
                                                 where (Int16)C.CodigoRol == RolID
                                                 select C).ToList();

            //SI EL VALOR
            if (Lista.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //public static List<cRelacionModuloPerfilRol> ListarRelacionPerfilModuloRoles(Int32 RelacionID)
        //{


        //    try
        //    {
        //        //Declaramos la conexion hacia la base de datos
        //        using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
        //        {
        //            Conn.Open();
        //            //Nombre del procedimiento
        //            string StoreProc = "uspListarRelacionPerfilModuloRol";
        //            //Creamos el command para la insercion
        //            MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
        //            Cmd.CommandType = CommandType.StoredProcedure;

        //            //Parametros
        //            Cmd.Parameters.AddWithValue("ID", RelacionID);

        //            //Ejecutamos el lector 
        //            MySqlDataReader Reader = Cmd.ExecuteReader();


        //            List<cRelacionModuloPerfilRol> Lista = new List<cRelacionModuloPerfilRol>();
        //            while (Reader.Read())
        //            {
        //                cRelacionModuloPerfilRol Relacion = new cRelacionModuloPerfilRol();
        //                Relacion.RolID = Reader.GetInt32(Reader.GetOrdinal("RolID"));
        //                Relacion.ModuloPerfilID = Reader.GetInt32(Reader.GetOrdinal("ModuloPerfilID"));
        //                Relacion.DescripcionRol = Reader.GetString(Reader.GetOrdinal("Rol"));
        //                Relacion.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
        //                //Agregamos el articulo a la lista
        //                Lista.Add(Relacion);
        //            }
        //            //Cerramos la conexion
        //            Conn.Close();
        //            //Retornamos la lista de clientes
        //            return Lista;
        //        }
        //    }

        //    catch (MySqlException Ex)
        //    {
        //        throw Ex;

        //    }
        //}
       
    }
}
