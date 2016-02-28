using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using System.Data.SqlClient;

namespace SMA.DA
{
    public static class VendedorDA
    {
        public static void Crear(cVendedor Vendedor)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarVendedor";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("Nombre", Vendedor.Nombre);
                    Cmd.Parameters.AddWithValue("Apellido", Vendedor.Apellido);
                    Cmd.Parameters.AddWithValue("Telefono", Vendedor.Telefono);
                    Cmd.Parameters.AddWithValue("Celular", Vendedor.Celular);
                    Cmd.Parameters.AddWithValue("Comision", Vendedor.Comision);
                    Cmd.Parameters.AddWithValue("Cedula", Vendedor.Cedula);
                    Cmd.Parameters.AddWithValue("FechaCreacion", DateTime.Now);
                    Cmd.Parameters.AddWithValue("FechaModificacion",DateTime.Now);                   
                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static List<cVendedor> Listar()
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarVendedor";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cVendedor> Lista = new List<cVendedor>();
                    while (Reader.Read())
                    {
                        cVendedor Vendedor = new cVendedor();
                        Vendedor.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Vendedor.Nombre = Reader.GetString(Reader.GetOrdinal("Nombre"));
                        Vendedor.Cedula = Reader.IsDBNull(Reader.GetOrdinal("Cedula")) ? null : Reader.GetString(Reader.GetOrdinal("Cedula"));
                        Vendedor.Telefono = Reader.IsDBNull(Reader.GetOrdinal("Telefono")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Vendedor.Celular = Reader.IsDBNull(Reader.GetOrdinal("Celular")) ? null : Reader.GetString(Reader.GetOrdinal("Celular"));
                        Vendedor.Comision = Reader.IsDBNull(Reader.GetOrdinal("Comision")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Comision"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Vendedor);
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

        public static void Actualizar(cVendedor Vendedor)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspActualizarVendedor";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("ID", Vendedor.ID);
                    Cmd.Parameters.AddWithValue("Nombre", Vendedor.Nombre);
                    Cmd.Parameters.AddWithValue("Apellido", Vendedor.Apellido);
                    Cmd.Parameters.AddWithValue("Telefono", Vendedor.Telefono);
                    Cmd.Parameters.AddWithValue("Celular", Vendedor.Celular);
                    Cmd.Parameters.AddWithValue("Cedula", Vendedor.Cedula);
                    Cmd.Parameters.AddWithValue("Comision", Vendedor.Comision);
                    Cmd.Parameters.AddWithValue("Eliminado", Vendedor.Eliminado);
                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static cVendedor BuscarPorID(int ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarVendedorPorID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("ID", ID);
                    SqlDataReader Reader = Cmd.ExecuteReader();

                    cVendedor Vendedor = new cVendedor();
                    while (Reader.Read())
                    {
                        Vendedor.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Vendedor.Nombre = Reader.GetString(Reader.GetOrdinal("Nombre"));
                        Vendedor.Apellido = Reader.GetString(Reader.GetOrdinal("Apellido"));
                        Vendedor.Cedula = Reader.GetString(Reader.GetOrdinal("Cedula"));
                        Vendedor.Celular = Reader.GetString(Reader.GetOrdinal("Celular"));
                        Vendedor.Telefono = Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Vendedor.Comision = Reader.GetDecimal(Reader.GetOrdinal("Comision"));
                    }
                    //Cerramos la conexion
                    Conn.Close();
                    //Retornamos los datos
                    return Vendedor;
                }
            }
            catch (SqlException Ex)
            {
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
