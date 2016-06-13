using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SMA.Entity;

namespace SMA.DA
{
   public static class ConcCxPDA
    {
        public static void Crear(cConcepto Concepto)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarConcCxP";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("Descripcion", Concepto.Descripcion);
                    Cmd.Parameters.AddWithValue("Tipo", Concepto.Tipo);
                    Cmd.Parameters.AddWithValue("Automatico", Concepto.Automatico);
                    Cmd.Parameters.AddWithValue("Notas", Concepto.Notas);
                    Cmd.Parameters.AddWithValue("Referencia", Concepto.Referencia);
                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static void Actualizar(cConcepto Concepto)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspActualizarConcCxP";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("ConceptoID", Concepto.Codigo);
                    Cmd.Parameters.AddWithValue("Descripcion", Concepto.Descripcion);
                    Cmd.Parameters.AddWithValue("Notas", Concepto.Notas);
                    Cmd.Parameters.AddWithValue("Referencia", Concepto.Referencia);
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }
       //TODO Busqueda de Concepto por ID
        public static cConcepto BuscarPorID(Int16 ID)
        {
            
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarConcCxPPorID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("p_Codigo", ID);
                    SqlDataReader Reader = Cmd.ExecuteReader();

                    cConcepto Concepto = new cConcepto();
                    while (Reader.Read())
                    {
                        Concepto.Codigo = Reader.GetInt16(Reader.GetOrdinal("Codigo"));
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
            catch (SqlException Ex)
            {
                
                throw Ex;

            }
        }

        public static List<cConcepto> Listar()
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarConcCxP";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cConcepto> Lista = new List<cConcepto>();
                    while (Reader.Read())
                    {
                        cConcepto Concepto = new cConcepto();
                        Concepto.Codigo = Reader.GetByte(Reader.GetOrdinal("Codigo"));
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
            catch (SqlException Ex)
            {
                throw Ex;
            }

        }



        public static Boolean Existe(Int16 ID)
        {
            //Buscamos si un Articulo existe en la base de datos
            SByte result;
            string Valor = BuscarPorID(ID).Codigo.ToString();
            if (Valor != "0")
            {
                return SByte.TryParse(Valor, out result);
            }
            else
            {
                return false;
            }
        }
    }
}
