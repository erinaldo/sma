using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMA.Entity;
using System.Data;
using System.Data.SqlClient;

namespace SMA.DA
{
    public static class AlmacenDA
    {

        public static void Crear(cAlmacen Almacen)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarAlmacen";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("Nombre", Almacen.Nombre);
                    Cmd.Parameters.AddWithValue("Telefono", Almacen.Telefono);
                    Cmd.Parameters.AddWithValue("Fax", Almacen.Fax);
                    Cmd.Parameters.AddWithValue("Direccion", Almacen.Direccion);
                    Cmd.Parameters.AddWithValue("Ciudad", Almacen.Ciudad);
                    Cmd.Parameters.AddWithValue("Provincia", Almacen.Provincia);
                    Cmd.Parameters.AddWithValue("Email", Almacen.Email);
                    Cmd.Parameters.AddWithValue("Web", Almacen.Web);
                    Cmd.Parameters.AddWithValue("Observacion", Almacen.Observacion);
                    Cmd.Parameters.AddWithValue("FechaCreacion",DateTime.Now.Date);
                    Cmd.Parameters.AddWithValue("FechaModificacion", DateTime.Now.Date);
                    Cmd.ExecuteNonQuery();
                }

                
            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static void Actualizar(cAlmacen Almacen)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspActualizarAlmacen";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("AlmacenID", Almacen.ID);
                    Cmd.Parameters.AddWithValue("Nombre", Almacen.Nombre);
                    Cmd.Parameters.AddWithValue("Telefono", Almacen.Telefono);
                    Cmd.Parameters.AddWithValue("Fax", Almacen.Fax);
                    Cmd.Parameters.AddWithValue("Direccion", Almacen.Direccion);
                    Cmd.Parameters.AddWithValue("Ciudad", Almacen.Ciudad);
                    Cmd.Parameters.AddWithValue("Provincia", Almacen.Provincia);
                    Cmd.Parameters.AddWithValue("Email", Almacen.Email);
                    Cmd.Parameters.AddWithValue("Web", Almacen.Web);
                    Cmd.Parameters.AddWithValue("Observacion", Almacen.Observacion);
                    Cmd.Parameters.AddWithValue("FechaModificacion", DateTime.Now.Date);
                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static void Eliminar(int ID)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspEliminarAlmacen";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("AlmacenID", ID);
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static cAlmacen BuscarPorID(int ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarAlmacenPorID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("AlmacenID", ID);
                    SqlDataReader Reader = Cmd.ExecuteReader();

                    cAlmacen Almacen = new cAlmacen();
                    while (Reader.Read())
                    {
                        Almacen.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Almacen.Nombre = Reader.GetString(Reader.GetOrdinal("Nombre"));
                        Almacen.Telefono = Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Almacen.Fax = Reader.GetString(Reader.GetOrdinal("Fax"));
                        Almacen.Direccion = Reader.GetString(Reader.GetOrdinal("Direccion"));
                        Almacen.Ciudad = Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Almacen.Provincia = Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Almacen.Email = Reader.GetString(Reader.GetOrdinal("Email"));
                        Almacen.Web = Reader.GetString(Reader.GetOrdinal("Web"));
                        Almacen.Observacion = Reader.GetString(Reader.GetOrdinal("Observacion"));
                        Almacen.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Almacen.FechaModificacion = Reader.GetDateTime(Reader.GetOrdinal("FechaModificacion"));
                    }
                    Conn.Close();
                    return Almacen;
                }
            }
            catch (SqlException Ex)
            {
                return null;
                throw Ex;

            }
        }

        public static List<cAlmacen> Listar()
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarAlmacen";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cAlmacen> Lista = new List<cAlmacen>();
                    while (Reader.Read())
                    {
                        cAlmacen Almacen = new cAlmacen();
                        Almacen.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Almacen.Nombre = Reader.GetString(Reader.GetOrdinal("Nombre"));
                        Almacen.Telefono = Reader.IsDBNull(Reader.GetOrdinal("Telefono"))?null :  Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Almacen.Fax = Reader.GetString(Reader.GetOrdinal("Fax"));
                        Almacen.Direccion = Reader.GetString(Reader.GetOrdinal("Direccion"));
                        Almacen.Ciudad = Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Almacen.Provincia = Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Almacen.Email = Reader.GetString(Reader.GetOrdinal("Email"));
                        Almacen.Web = Reader.GetString(Reader.GetOrdinal("Web"));
                        Almacen.Observacion = Reader.GetString(Reader.GetOrdinal("Observacion"));
                        Almacen.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Almacen.FechaModificacion = Reader.GetDateTime(Reader.GetOrdinal("FechaModificacion"));
                        
                        //Agregamos el articulo a la lista
                        Lista.Add(Almacen);
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
