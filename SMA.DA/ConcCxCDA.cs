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
   public static class ConcCxCDA
    {
        public static void Crear(cConcepto Concepto)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarConcCxC";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("p_Descripcion", Concepto.Descripcion);
                    Cmd.Parameters.AddWithValue("p_Tipo", Concepto.Tipo);
                    Cmd.Parameters.AddWithValue("p_Automatico", Concepto.Automatico);
                    Cmd.Parameters.AddWithValue("p_Notas", Concepto.Notas);
                    Cmd.Parameters.AddWithValue("p_Referencia", Concepto.Referencia);
                    Cmd.ExecuteNonQuery();
                }


            }
            catch (MySqlException Ex)
            {
                throw Ex;
            }
        }

        public static void Actualizar(cConcepto Concepto)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspActualizarConcCxC";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("p_Codigo", Concepto.Codigo);
                    Cmd.Parameters.AddWithValue("p_Descripcion", Concepto.Descripcion);
                    Cmd.Parameters.AddWithValue("p_Notas", Concepto.Notas);
                    Cmd.Parameters.AddWithValue("p_Referencia", Concepto.Referencia);
                    Cmd.ExecuteNonQuery();
                }


            }
            catch (MySqlException Ex)
            {
                throw Ex;
            }
        }

        public static cConcepto BuscarPorID(Int16 ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarConcCxCPorCodigo";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("p_Codigo", ID);
                    MySqlDataReader Reader = Cmd.ExecuteReader();

                    cConcepto Concepto = new cConcepto();
                    while (Reader.Read())
                    {
                        Concepto.Codigo = Reader.GetByte(Reader.GetOrdinal("Codigo"));
                        Concepto.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Concepto.Tipo = Reader.GetString(Reader.GetOrdinal("Tipo"));
                        Concepto.Notas = Reader.IsDBNull(Reader.GetOrdinal("Notas")) ? null : Reader.GetString(Reader.GetOrdinal("Notas"));
                        Concepto.Automatico = Reader.GetString(Reader.GetOrdinal("Automatico"));
                        Concepto.Referencia = Reader.GetString(Reader.GetOrdinal("Referencia"));
                    }
                    Conn.Close();
                    return Concepto;
                }
            }
            catch (MySqlException Ex)
            {

                throw Ex;

            }
        }

        public static List<cConcepto> Listar()
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarConcCxC";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecutamos el lector 
                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cConcepto> Lista = new List<cConcepto>();
                    while (Reader.Read())
                    {
                        cConcepto Concepto = new cConcepto();
                        Concepto.Codigo = Reader.GetInt16(Reader.GetOrdinal("Codigo"));
                        Concepto.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Concepto.Tipo = Reader.GetString(Reader.GetOrdinal("Tipo"));
                        Concepto.Notas = Reader.IsDBNull(Reader.GetOrdinal("Notas")) ? null : Reader.GetString(Reader.GetOrdinal("Notas"));
                        Concepto.Automatico = Reader.GetString(Reader.GetOrdinal("Automatico"));
                        Concepto.Referencia = Reader.GetString(Reader.GetOrdinal("Referencia"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Concepto);
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



        public static Boolean Existe(Int16 ID)
        {
            //Buscamos si un Articulo existe en la base de datos
            Int16 result;
            string Valor = BuscarPorID(ID).Codigo.ToString();
            if (Valor != "0")
            {
                return Int16.TryParse(Valor, out result);
            }
            else
            {
                return false;
            }
        }

    }
}
