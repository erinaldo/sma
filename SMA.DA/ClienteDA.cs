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
    public static class ClienteDA
    {
        public static void Crear(cCliente Cliente)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarCliente";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("NombreComercial", Cliente.NombreComercial);
                    Cmd.Parameters.AddWithValue("RNC", Cliente.RNC);
                    Cmd.Parameters.AddWithValue("EstatusID", 1); //Cliente Activo
                    Cmd.Parameters.AddWithValue("Direccion", Cliente.Direccion);
                    Cmd.Parameters.AddWithValue("Provincia", Cliente.Provincia);
                    Cmd.Parameters.AddWithValue("Ciudad", Cliente.Ciudad);
                    Cmd.Parameters.AddWithValue("Telefono", Cliente.Telefono);
                    Cmd.Parameters.AddWithValue("Telefono2", Cliente.Telefono2);
                    Cmd.Parameters.AddWithValue("Fax", Cliente.Fax);
                    Cmd.Parameters.AddWithValue("Correo", Cliente.Correo);
                    Cmd.Parameters.AddWithValue("FechaCreacion", DateTime.Now.Date);
                    Cmd.Parameters.AddWithValue("FechaModificacion", DateTime.Now.Date);
                    Cmd.Parameters.AddWithValue("Observaciones", Cliente.Observaciones);
                    Cmd.Parameters.AddWithValue("TipoComprobanteID", Cliente.TipoComprobanteID);
                    Cmd.Parameters.AddWithValue("DiasCredito", Cliente.DiasCredito);
                    Cmd.Parameters.AddWithValue("LimiteCredito", Cliente.LimiteCredito);
                    Cmd.Parameters.AddWithValue("Descuento", Cliente.Descuento);
                    //Cmd.Parameters.AddWithValue("ClasificacionID", Cliente.ClasificacionID);
                    Cmd.Parameters.AddWithValue("Balance", Cliente.Balance);
                    Cmd.Parameters.AddWithValue("VendedorID", Cliente.VendedorID);
                    Cmd.Parameters.AddWithValue("ContactoVentas", Cliente.ContactoVentas);
                    Cmd.Parameters.AddWithValue("ContactoCobros", Cliente.ContactoCobros);
                    Cmd.Parameters.AddWithValue("PaginaWeb", Cliente.PaginaWeb);
                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static void Actualizar(cCliente Cliente)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspActualizarCliente";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("ClienteID", Cliente.ID);
                    Cmd.Parameters.AddWithValue("NombreComercial", Cliente.NombreComercial);
                    Cmd.Parameters.AddWithValue("RNC", Cliente.RNC);
                    Cmd.Parameters.AddWithValue("EstatusID", Cliente.EstatusID); //Cliente Activo
                    Cmd.Parameters.AddWithValue("Direccion", Cliente.Direccion);
                    Cmd.Parameters.AddWithValue("Provincia", Cliente.Provincia);
                    Cmd.Parameters.AddWithValue("Ciudad", Cliente.Ciudad);
                    Cmd.Parameters.AddWithValue("Telefono", Cliente.Telefono);
                    Cmd.Parameters.AddWithValue("Telefono2", Cliente.Telefono2);
                    Cmd.Parameters.AddWithValue("Fax", Cliente.Fax);
                    Cmd.Parameters.AddWithValue("Correo", Cliente.Correo);
                    //Cmd.Parameters.AddWithValue("FechaCreacion", DateTime.Now.Date);
                    //Cmd.Parameters.AddWithValue("FechaModificacion", DateTime.Now.Date);
                    Cmd.Parameters.AddWithValue("Observaciones", Cliente.Observaciones);
                    Cmd.Parameters.AddWithValue("TipoComprobanteID", Cliente.TipoComprobanteID);
                    Cmd.Parameters.AddWithValue("DiasCredito", Cliente.DiasCredito);
                    Cmd.Parameters.AddWithValue("LimiteCredito", Cliente.LimiteCredito);
                    Cmd.Parameters.AddWithValue("Descuento",Cliente.Descuento);
                    //Cmd.Parameters.AddWithValue("ClasificacionID", Cliente.ClasificacionID);
                    //Cmd.Parameters.AddWithValue("Balance", Cliente.Balance);
                    Cmd.Parameters.AddWithValue("VendedorID", Cliente.VendedorID);
                    Cmd.Parameters.AddWithValue("ContactoVentas", Cliente.ContactoVentas);
                    Cmd.Parameters.AddWithValue("ContactoCobros", Cliente.ContactoCobros);
                    Cmd.Parameters.AddWithValue("PaginaWeb", Cliente.PaginaWeb);

                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static cCliente BuscarPorID(Int64 ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarClientePorID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("ClienteID", ID);
                    SqlDataReader Reader = Cmd.ExecuteReader();

                    cCliente Cliente = new cCliente();
                    while (Reader.Read())
                    {
                        Cliente.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Cliente.NombreComercial = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cliente.RNC = Reader.IsDBNull(Reader.GetOrdinal("RNC")) ? null : Reader.GetString(Reader.GetOrdinal("RNC"));
                        Cliente.Direccion = Reader.IsDBNull(Reader.GetOrdinal("Direccion")) ? null : Reader.GetString(Reader.GetOrdinal("Direccion"));
                        Cliente.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Cliente.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia")) ? null : Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Cliente.Telefono = Reader.IsDBNull(Reader.GetOrdinal("Telefono")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Cliente.Fax = Reader.IsDBNull(Reader.GetOrdinal("Fax")) ? null : Reader.GetString(Reader.GetOrdinal("Fax"));
                        Cliente.Correo = Reader.IsDBNull(Reader.GetOrdinal("Correo")) ? null : Reader.GetString(Reader.GetOrdinal("Correo"));
                        Cliente.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Cliente.FechaModificacion = Reader.GetDateTime(Reader.GetOrdinal("FechaModificacion"));
                        Cliente.Observaciones = Reader.IsDBNull(Reader.GetOrdinal("Observaciones")) ? null : Reader.GetString(Reader.GetOrdinal("Observaciones"));
                        Cliente.Telefono2 = Reader.IsDBNull(Reader.GetOrdinal("Telefono2")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono2"));
                        Cliente.PaginaWeb = Reader.IsDBNull(Reader.GetOrdinal("PaginaWeb")) ? null : Reader.GetString(Reader.GetOrdinal("PaginaWeb"));
                        Cliente.EstatusID = Reader.IsDBNull(Reader.GetOrdinal("EstatusID")) ? false : Reader.GetBoolean(Reader.GetOrdinal("EstatusID"));
                        Cliente.LimiteCredito = Reader.IsDBNull(Reader.GetOrdinal("LimiteCredito")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("LimiteCredito"));
                        Cliente.DiasCredito = Reader.IsDBNull(Reader.GetOrdinal("DiasCredito")) ? 0 : Reader.GetInt32(Reader.GetOrdinal("DiasCredito"));
                        Cliente.ContactoCobros = Reader.IsDBNull(Reader.GetOrdinal("ContactoCobros")) ? null : Reader.GetString(Reader.GetOrdinal("ContactoCobros"));
                        Cliente.ContactoVentas = Reader.IsDBNull(Reader.GetOrdinal("ContactoVentas")) ? null : Reader.GetString(Reader.GetOrdinal("ContactoVentas"));
                        Cliente.VendedorID = Reader.IsDBNull(Reader.GetOrdinal("VendedorID")) ? -1 : Reader.GetInt32(Reader.GetOrdinal("VendedorID"));
                        Cliente.TipoComprobanteID = Reader.IsDBNull(Reader.GetOrdinal("TipoComprobanteID")) ? -1 : Reader.GetInt32(Reader.GetOrdinal("TipoComprobanteID"));
                        Cliente.Descuento = Reader.IsDBNull(Reader.GetOrdinal("Descuento")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Descuento"));
                        Cliente.UltFechaPago = Reader.IsDBNull(Reader.GetOrdinal("UltFechaPago")) ? "" : Reader.GetValue(Reader.GetOrdinal("UltFechaPago"));
                        Cliente.UltFechaVenta = Reader.IsDBNull(Reader.GetOrdinal("UltFechaVenta")) ? "" : Reader.GetValue(Reader.GetOrdinal("UltFechaVenta"));
                        Cliente.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Cliente.FechaModificacion = Reader.GetDateTime(Reader.GetOrdinal("FechaModificacion"));
                        Cliente.UltDocVenta = Reader.IsDBNull(Reader.GetOrdinal("UltDocVenta")) ? "" : Reader.GetValue(Reader.GetOrdinal("UltDocVenta"));
                        Cliente.UltDocPago = Reader.IsDBNull(Reader.GetOrdinal("UltDocPago")) ? "" : Reader.GetValue(Reader.GetOrdinal("UltDocPago"));
                        Cliente.UltMontoPago = Reader.IsDBNull(Reader.GetOrdinal("UltMontoPago")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("UltMontoPago"));
                        Cliente.UltMontoVenta = Reader.IsDBNull(Reader.GetOrdinal("UltMontoVenta")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("UltMontoVenta"));
                        Cliente.Balance = Reader.IsDBNull(Reader.GetOrdinal("Balance")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Balance"));
                    }
                    Conn.Close();
                    return Cliente;
                }
            }
            catch (SqlException Ex)
            {
                return null;
                throw Ex;

            }
        }

        public static List<cCliente> Listar()
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarCliente";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cCliente> Lista = new List<cCliente>();
                    while (Reader.Read())
                    {
                        cCliente Cliente = new cCliente();
                        Cliente.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Cliente.NombreComercial = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cliente.RNC = Reader.IsDBNull(Reader.GetOrdinal("RNC")) ? null : Reader.GetString(Reader.GetOrdinal("RNC"));
                        Cliente.Telefono = Reader.IsDBNull(Reader.GetOrdinal("Telefono")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Cliente.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Cliente.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia")) ? null : Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Cliente.Balance = Reader.IsDBNull(Reader.GetOrdinal("Balance")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Balance"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Cliente);
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

        public static Boolean Existe(Int64 ID)
        {
            //Buscamos si un Articulo existe en la base de datos
            Int64 result;
            string Valor = BuscarPorID(ID).ID.ToString();
            if (Valor != "0")
            {
                return Int64.TryParse(Valor, out result);
            }
            else
            {
                return false;
            }
        }

        public static void Eliminar(Int64 ID)
        {
            //Cambia el estatus del cliente en la base de datos.
            try
            {
                //Creamos un objeto cliente
                cCliente Cliente=new cCliente();

                //Buscamos los datos del cliente por su ID
                Cliente=BuscarPorID(ID);

                //Intercambiamos los estatus del cliente
                if ((Boolean)Cliente.EstatusID == true)
                {
                    Cliente.EstatusID = false;
                }

                //Actualizamos la informacion del cliente
                Actualizar(Cliente);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public static List<cCliente> Filtrar(Int64? CodigoDesde,
                                            Int64? CodigoHasta,
                                            Int32? VendedorID,
                                            String Nombre,
                                            Boolean? EstatusID)
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspFiltroCliente";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    Cmd.Parameters.AddWithValue("CodigoDesde", CodigoDesde);
                    Cmd.Parameters.AddWithValue("CodigoHasta", CodigoHasta);
                    Cmd.Parameters.AddWithValue("VendedorID", VendedorID);
                    Cmd.Parameters.AddWithValue("Nombre", Nombre);
                    Cmd.Parameters.AddWithValue("EstatusID", EstatusID);
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cCliente> Lista = new List<cCliente>();
                    while (Reader.Read())
                    {
                        cCliente Cliente = new cCliente();
                        Cliente.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Cliente.NombreComercial = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cliente.RNC = Reader.IsDBNull(Reader.GetOrdinal("RNC")) ? null : Reader.GetString(Reader.GetOrdinal("RNC"));
                        Cliente.Telefono = Reader.IsDBNull(Reader.GetOrdinal("Telefono")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Cliente.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Cliente.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia")) ? null : Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Cliente.Balance = Reader.IsDBNull(Reader.GetOrdinal("Balance")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Balance"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Cliente);
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

        public static List<cCliente> Catalogo(Int64 CodigoDesde, Int64 CodigoHasta, Int32? VendedorID, Boolean? Estatus)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspCatalogoClientes";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametro
                    Cmd.Parameters.AddWithValue("ClienteDesde", CodigoDesde);
                    Cmd.Parameters.AddWithValue("ClienteHasta", CodigoHasta);
                    Cmd.Parameters.AddWithValue("Estatus", Estatus);
                    Cmd.Parameters.AddWithValue("VendedorID", VendedorID);
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cCliente> Lista = new List<cCliente>();
                    while (Reader.Read())
                    {
                        cCliente Cliente = new cCliente();
                        Cliente.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Cliente.NombreComercial = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cliente.RNC = Reader.IsDBNull(Reader.GetOrdinal("RNC")) ? null : Reader.GetString(Reader.GetOrdinal("RNC"));
                        Cliente.Telefono = Reader.IsDBNull(Reader.GetOrdinal("Telefono")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Cliente.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Cliente.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia")) ? null : Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Cliente.Fax = Reader.IsDBNull(Reader.GetOrdinal("Fax")) ? null : Reader.GetString(Reader.GetOrdinal("Fax"));
                        Cliente.Correo = Reader.IsDBNull(Reader.GetOrdinal("Correo")) ? null : Reader.GetString(Reader.GetOrdinal("Correo"));
                        Cliente.Descuento = Reader.IsDBNull(Reader.GetOrdinal("Descuento")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Descuento"));
                        Cliente.LimiteCredito = Reader.IsDBNull(Reader.GetOrdinal("LimiteCredito")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("LimiteCredito"));
                        Cliente.DiasCredito = Reader.IsDBNull(Reader.GetOrdinal("DiasCredito")) ? 0 : Reader.GetInt32(Reader.GetOrdinal("DiasCredito"));
                        Cliente.UltFechaVenta = Reader.IsDBNull(Reader.GetOrdinal("UltFechaVenta")) ? "" : Reader.GetValue(Reader.GetOrdinal("UltFechaVenta"));
                        //Cliente.Balance = Reader.IsDBNull(Reader.GetOrdinal("Balance")) ? 0.00 : Reader.GetDouble(Reader.GetOrdinal("Balance"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Cliente);
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
    }
}
