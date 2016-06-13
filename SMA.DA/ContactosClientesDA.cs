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
    public static class ContactosClientesDA
    {
        public static void Crear(cContactos Contacto)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarCtosCltes";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("p_Nombre", Contacto.Nombre);
                    Cmd.Parameters.AddWithValue("p_Cargo", Contacto.Cargo);
                    Cmd.Parameters.AddWithValue("p_Correo", Contacto.Correo);
                    Cmd.Parameters.AddWithValue("p_Telefono1", Contacto.Telefono1);
                    Cmd.Parameters.AddWithValue("p_Telefono2", Contacto.Telefono2);
                    Cmd.Parameters.AddWithValue("p_Fax1", Contacto.Fax1);
                    Cmd.Parameters.AddWithValue("p_Fax2", Contacto.Fax2);
                    Cmd.Parameters.AddWithValue("p_Notas", Contacto.Notas);
                    Cmd.Parameters.AddWithValue("p_CodigoDpto", Contacto.CodigoDepartamento);
                    Cmd.Parameters.AddWithValue("p_CodigoClte", Contacto.CodigoCliente);
                    Cmd.ExecuteNonQuery();
                    Conn.Close();
                }


            }
            catch (MySqlException Ex)
            {
                throw Ex;
            }
        }

        public static void Actualizar(cContactos Contacto)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspActualizarCtosCltes";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("p_Nombre", Contacto.Nombre);
                    Cmd.Parameters.AddWithValue("p_Cargo", Contacto.Cargo);
                    Cmd.Parameters.AddWithValue("p_Correo", Contacto.Correo);
                    Cmd.Parameters.AddWithValue("p_Telefono1", Contacto.Telefono1);
                    Cmd.Parameters.AddWithValue("p_Telefono2", Contacto.Telefono2);
                    Cmd.Parameters.AddWithValue("p_Fax1", Contacto.Fax1);
                    Cmd.Parameters.AddWithValue("p_Fax2", Contacto.Fax2);
                    Cmd.Parameters.AddWithValue("p_Notas", Contacto.Notas);
                    Cmd.Parameters.AddWithValue("p_CodigoDpto", Contacto.CodigoDepartamento);
                    Cmd.Parameters.AddWithValue("p_CodigoClte", Contacto.CodigoCliente);

                    Cmd.ExecuteNonQuery();
                }


            }
            catch (MySqlException Ex)
            {
                throw Ex;
            }
        }

        public static cContactos BuscarPorID(Int32 ID)
        {
            try
            {
                //Declaramos la conexion hacia la   base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarCtoCltePorCodigo";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("p_Codigo", ID);
                    MySqlDataReader Reader = Cmd.ExecuteReader();

                    cContactos Contacto = new cContactos();
                    while (Reader.Read())
                    {
                        Contacto.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                        Contacto.Nombre = Reader.GetString(Reader.GetOrdinal("Nombre"));
                        Contacto.CodigoDepartamento = Reader.GetSByte(Reader.GetOrdinal("CodigoDpto"));
                        Contacto.Cargo = Reader.GetString(Reader.GetOrdinal("Cargo"));
                        Contacto.Correo = Reader.IsDBNull(Reader.GetOrdinal("Correo")) ? null : Reader.GetString(Reader.GetOrdinal("Correo"));
                        Contacto.Telefono1 = Reader.IsDBNull(Reader.GetOrdinal("Telefono1")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono1"));
                        Contacto.Telefono2 = Reader.IsDBNull(Reader.GetOrdinal("Telefono2")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono2"));
                        Contacto.Fax1 = Reader.IsDBNull(Reader.GetOrdinal("Fax1")) ? null : Reader.GetString(Reader.GetOrdinal("Fax1"));
                        Contacto.Fax2 = Reader.IsDBNull(Reader.GetOrdinal("Fax2")) ? null : Reader.GetString(Reader.GetOrdinal("Fax2"));
                        Contacto.Notas = Reader.IsDBNull(Reader.GetOrdinal("Notas")) ? null : Reader.GetString(Reader.GetOrdinal("Notas"));
                    }
                    Conn.Close();
                    return Contacto;
                }
            }
            catch (MySqlException Ex)
            {
                throw Ex;
            }
        }

        public static List<cContactos> Listar(Int32 CodigoCliente)
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarCtosCltes";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametro
                    Cmd.Parameters.AddWithValue("p_Codigo", CodigoCliente);

                    //Ejecutamos el lector 
                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cContactos> Lista = new List<cContactos>();
                    while (Reader.Read())
                    {
                        cContactos Contacto = new cContactos();
                        Contacto.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                        Contacto.Nombre = Reader.GetString(Reader.GetOrdinal("Nombre"));
                        Contacto.CodigoDepartamento = Reader.IsDBNull(Reader.GetOrdinal("Departamento")) ? null :Reader.GetString(Reader.GetOrdinal("Departamento"));
                        Contacto.Cargo = Reader.IsDBNull(Reader.GetOrdinal("Cargo"))? null :Reader.GetString(Reader.GetOrdinal("Cargo"));
                        Contacto.Correo = Reader.IsDBNull(Reader.GetOrdinal("Correo")) ? null : Reader.GetString(Reader.GetOrdinal("Correo"));
                        Contacto.Telefono1 = Reader.IsDBNull(Reader.GetOrdinal("Telefono1")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono1"));
                        Contacto.Telefono2 = Reader.IsDBNull(Reader.GetOrdinal("Telefono2")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono2"));
                        Contacto.Fax1 = Reader.IsDBNull(Reader.GetOrdinal("Fax1")) ? null : Reader.GetString(Reader.GetOrdinal("Fax1"));
                        Contacto.Fax2 = Reader.IsDBNull(Reader.GetOrdinal("Fax2")) ? null : Reader.GetString(Reader.GetOrdinal("Fax2"));
                        Contacto.Notas = Reader.IsDBNull(Reader.GetOrdinal("Notas")) ? null : Reader.GetString(Reader.GetOrdinal("Notas"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Contacto);
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

        public static Boolean Existe(Int32 ID)
        {
            //Buscamos si un Articulo existe en la base de datos
            Int32 result;
            string Valor = BuscarPorID(ID).Codigo.ToString();
            if (Valor != "0")
            {
                return Int32.TryParse(Valor, out result);
            }
            else
            {
                return false;
            }
        }

        public static void Eliminar(Int32 ID)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspEliminarCtosCltes";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("p_Codigo", ID);

                    Cmd.ExecuteNonQuery();

                    Conn.Close();
                }
            }
            catch(MySqlException Ex)
            {
                throw Ex;
            }
        }

        public static List<cDepartamentos> ListarDepartamentos()
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarDptos";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecutamos el lector 
                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cDepartamentos> Lista = new List<cDepartamentos>();
                    while (Reader.Read())
                    {
                        cDepartamentos Departamento = new cDepartamentos();
                        Departamento.Codigo = Reader.GetSByte(Reader.GetOrdinal("Codigo"));
                        Departamento.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        //Familia.Notas = Reader.IsDBNull(Reader.GetOrdinal("Notas")) ? null : Reader.GetString(Reader.GetOrdinal("Notas"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Departamento);
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
        
    }
}
