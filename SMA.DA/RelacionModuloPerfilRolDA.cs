using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using System.Data.SqlClient;

namespace SMA.DA
{
    public static class RelacionModuloPerfilRolDA
    {
        public static List<cRelacionModuloPerfilRol> ListarRelacionPerfilRol(Int32 RelacionID)
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarRelacionPerfilModuloRol";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("ID", RelacionID);

                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cRelacionModuloPerfilRol> Lista = new List<cRelacionModuloPerfilRol>();
                    while (Reader.Read())
                    {
                        cRelacionModuloPerfilRol Relacion = new cRelacionModuloPerfilRol();
                        //Relacion.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Relacion.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Relacion.DescripcionRol = Reader.GetString(Reader.GetOrdinal("Rol"));
                        Relacion.RolID = Reader.GetInt32(Reader.GetOrdinal("RolID"));
                        Relacion.ModuloPerfilID = Reader.GetInt32(Reader.GetOrdinal("ModuloPerfilID"));
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




        public static void CrearRelacionModuloPerfilRol(cRelacionModuloPerfilRol Relacion)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarRelacionModuloPerfilRol";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("ModuloPerfilID", Relacion.ModuloPerfilID);
                    Cmd.Parameters.AddWithValue("RolID", Relacion.RolID);

                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static void EliminarRelacionModuloPerfilRol(Int32 RelacionID)
        {

            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspEliminarRolAsignado";
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

        public static Boolean Existe(Int32 RelacionID, Int32 RolID)
        {
            //COMPROBAMOS LA EXISTENCIA DE LA RELACION
            List<cRelacionModuloPerfilRol> Lista = (from C in ListarRelacionPerfilRol(RelacionID)
                                                 where (Int32)C.RolID == RolID
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
        //        using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
        //        {
        //            Conn.Open();
        //            //Nombre del procedimiento
        //            string StoreProc = "uspListarRelacionPerfilModuloRol";
        //            //Creamos el command para la insercion
        //            SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
        //            Cmd.CommandType = CommandType.StoredProcedure;

        //            //Parametros
        //            Cmd.Parameters.AddWithValue("ID", RelacionID);

        //            //Ejecutamos el lector 
        //            SqlDataReader Reader = Cmd.ExecuteReader();


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

        //    catch (SqlException Ex)
        //    {
        //        throw Ex;

        //    }
        //}
       
    }
}
