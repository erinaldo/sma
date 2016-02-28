using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace SMA.DA
{
    public static class ComprobacionDB
    {

        public static void CrearDB()
        {
            try
            {
                //Validamos si la base de datos existe
                //Si no existe entonces la creamos
                if (ValidacionBaseDatos() == false)
                {
                    //Declaramos la conexion hacia la base de datos
                    using (SqlConnection Conn = new SqlConnection("server=(local)\\SQLEXPRESS;Trusted_Connection=yes"))
                    {
                        //archivo con la definicion de la base de datos
                        string script = File.ReadAllText(@"C:\Sistema de Gestion Comercial\SMA.sql");

                        // split script on GO command
                        IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$",
                                           RegexOptions.Multiline | RegexOptions.IgnoreCase);

                        //Abrimos la conexion
                        Conn.Open();
                        foreach (string commandString in commandStrings)
                        {
                            if (commandString.Trim() != "")
                            {
                                using (var command = new SqlCommand(commandString, Conn))
                                {
                                    //Creamos la base de datos
                                    command.ExecuteNonQuery();

                                }
                            }
                        }
                        Conn.Close();
                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //public static void InsertarDatos()
        //{
        //    //Insertamos los datos de la base de datos por defecto

        //    //Declaramos la conexion hacia la base de datos
        //    using (SqlConnection Conn = new SqlConnection("server=(local)\\SQLEXPRESS;Trusted_Connection=yes"))
        //    {
        //        //Archivo con los datos
        //        string script = File.ReadAllText(@"C:\Sistema de Gestion Comercial\Datos.sql");

        //        // split script on GO command
        //        IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$",
        //                           RegexOptions.Multiline | RegexOptions.IgnoreCase);

        //        Conn.Open();
        //        foreach (string commandString in commandStrings)
        //        {
        //            if (commandString.Trim() != "")
        //            {
        //                using (var command = new SqlCommand(commandString, Conn))
        //                {
        //                    command.ExecuteNonQuery();
        //                }
        //            }
        //        }
        //        Conn.Close();
        //    }

        //}
    
        public static bool ValidacionBaseDatos()
        {
            //Validacion de la existencia de la base de datos
            string sqlCreateDBQuery;
            bool result = false;
           
            

            try
            {
            //Creamos la conexion a la base de datos
            SqlConnection tmpConn = new SqlConnection("server=(local)\\SQLEXPRESS;Trusted_Connection=yes");
                //SqlConnection tmpConn = new SqlConnection("server=LAGUARIDA-PC;Trusted_Connection=yes");
                //Query que verifica la existencia de la base de datos
            sqlCreateDBQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", "SMADB");
            
            using (tmpConn)
            {
                using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
                {
                    //Abrimos la conexion
                    tmpConn.Open();
                    //Ejecutamos el query y devuelve el resultado con el ID de la base de datos
                    int databaseID = (int)sqlCmd.ExecuteScalar();
                    //Cerramos la conexion
                    tmpConn.Close();

                    result = (databaseID > 0);
                }
            }
            
            }
            catch(Exception Ex)
            {
                result = false;
            }

            return result;
        }



    }

}
  
  


