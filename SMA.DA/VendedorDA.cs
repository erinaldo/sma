using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SMA.DA
{
    public static class VendedorDA
    {
        public static void Crear(cVendedor Vendedor)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarVend";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("p_Nombre", Vendedor.Nombre);
                    Cmd.Parameters.AddWithValue("p_Apellido", Vendedor.Apellido);
                    Cmd.Parameters.AddWithValue("p_Telefono", Vendedor.Telefono);
                    Cmd.Parameters.AddWithValue("p_Celular", Vendedor.Celular);
                    Cmd.Parameters.AddWithValue("p_Comision", Vendedor.Comision);
                    Cmd.Parameters.AddWithValue("p_Cedula", Vendedor.Cedula);
                    Cmd.ExecuteNonQuery();
                }


            }
            catch (MySqlException Ex)
            {
                throw Ex;
            }
        }

        public static List<cVendedor> Listar()
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarVend";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecutamos el lector 
                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cVendedor> Lista = new List<cVendedor>();
                    while (Reader.Read())
                    {
                        cVendedor Vendedor = new cVendedor();
                        Vendedor.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
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
            catch (MySqlException Ex)
            {
                throw Ex;

            }
        }

        public static void Actualizar(cVendedor Vendedor)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspActualizarVend";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("p_Codigo", Vendedor.Codigo);
                    Cmd.Parameters.AddWithValue("p_Nombre", Vendedor.Nombre);
                    Cmd.Parameters.AddWithValue("p_Apellido", Vendedor.Apellido);
                    Cmd.Parameters.AddWithValue("p_Telefono", Vendedor.Telefono);
                    Cmd.Parameters.AddWithValue("p_Celular", Vendedor.Celular);
                    Cmd.Parameters.AddWithValue("p_Cedula", Vendedor.Cedula);
                    Cmd.Parameters.AddWithValue("p_Comision", Vendedor.Comision);
                    Cmd.Parameters.AddWithValue("p_Eliminado", Vendedor.Eliminado);
                    Cmd.ExecuteNonQuery();
                }


            }
            catch (MySqlException Ex)
            {
                throw Ex;
            }
        }

        public static cVendedor BuscarPorID(int ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarVendPorCodigo";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("p_Codigo", ID);
                    MySqlDataReader Reader = Cmd.ExecuteReader();

                    cVendedor Vendedor = new cVendedor();
                    while (Reader.Read())
                    {
                        Vendedor.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
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
            catch (MySqlException Ex)
            {
                throw Ex;
            }
        }

        public static Boolean Existe(int ID)
        {
            //Buscamos si un Articulo existe en la base de datos
            int result;
            string Valor = BuscarPorID(ID).Codigo.ToString();
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
