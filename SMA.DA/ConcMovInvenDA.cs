using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SMA.Entity;

namespace SMA.DA
{
    public static class ConcMovInventDA
    {
        public static void Crear(cConcMovInvent ConcMovInvent)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarConcMovInvent";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("Descripcion", ConcMovInvent.Descripcion);
                    Cmd.Parameters.AddWithValue("Entrada", ConcMovInvent.Entrada);
                    Cmd.Parameters.AddWithValue("Autom", ConcMovInvent.Autom);
                    Cmd.Parameters.AddWithValue("Observacion", ConcMovInvent.Observacion);
                    Cmd.Parameters.AddWithValue("Relacion", ConcMovInvent.Relacion);
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static void Actualizar(cConcMovInvent ConcMovInvent)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspActualizarConcMovInvent";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("ConceptoID", ConcMovInvent.ID);
                    Cmd.Parameters.AddWithValue("Observacion", ConcMovInvent.Observacion);
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static cConcMovInvent BuscarPorID(int ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarConcMovInventPorID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("ID", ID);
                    SqlDataReader Reader = Cmd.ExecuteReader();

                    cConcMovInvent ConcMovInvent = new cConcMovInvent();
                    while (Reader.Read())
                    {
                        ConcMovInvent.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        ConcMovInvent.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        ConcMovInvent.Entrada = Reader.GetBoolean(Reader.GetOrdinal("Entrada"));
                        ConcMovInvent.Observacion = Reader.IsDBNull(Reader.GetOrdinal("Observacion")) ? null : Reader.GetString(Reader.GetOrdinal("Observacion"));
                        ConcMovInvent.Autom = Reader.GetBoolean(Reader.GetOrdinal("Autom"));
                        ConcMovInvent.MovInterno = Reader.GetBoolean(Reader.GetOrdinal("MovInterno"));
                        ConcMovInvent.Relacion = Reader.GetString(Reader.GetOrdinal("Relacion"));
                    }
                    Conn.Close();
                    return ConcMovInvent;
                }
            }
            catch (SqlException Ex)
            {
                return null;
                throw Ex;

            }
        }

        public static List<cConcMovInvent> Listar()
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarConcMovInven";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cConcMovInvent> Lista = new List<cConcMovInvent>();
                    while (Reader.Read())
                    {
                        cConcMovInvent ConcMovInvent = new cConcMovInvent();
                        ConcMovInvent.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        ConcMovInvent.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        ConcMovInvent.Entrada = Reader.GetString(Reader.GetOrdinal("Entrada"));
                        ConcMovInvent.Observacion = Reader.IsDBNull(Reader.GetOrdinal("Observacion")) ?null : Reader.GetString(Reader.GetOrdinal("Observacion"));
                        ConcMovInvent.Autom = Reader.GetString(Reader.GetOrdinal("Autom"));
                        ConcMovInvent.MovInterno = Reader.GetString(Reader.GetOrdinal("MovInterno"));
                        ConcMovInvent.Relacion = Reader.GetString(Reader.GetOrdinal("Relacion"));
                        //Agregamos el articulo a la lista
                        Lista.Add(ConcMovInvent);
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



        public static Boolean Existe(int ID)
        {
            //Buscamos si un Articulo existe en la base de datos
            int result;
            string Valor = BuscarPorID(ID).ID.ToString();
            if (Valor != "0")
            {
                return int.TryParse(Valor, out result);
            }
            else
            {
                return false;
            }
        }
    }
}
