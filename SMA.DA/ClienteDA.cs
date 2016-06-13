using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMA.Entity;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace SMA.DA
{
    public static class ClienteDA
    {
        public static void Crear(cCliente Cliente)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarClte";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("p_NombreComercial", Cliente.NombreComercial);
                    Cmd.Parameters.AddWithValue("p_RNC", Cliente.RNC);
                    Cmd.Parameters.AddWithValue("p_Estatus", 1); //Cliente Activo
                    Cmd.Parameters.AddWithValue("p_Direccion", Cliente.Direccion);
                    Cmd.Parameters.AddWithValue("p_Provincia", Cliente.Provincia);
                    Cmd.Parameters.AddWithValue("p_Ciudad", Cliente.Ciudad);
                    Cmd.Parameters.AddWithValue("p_Telefono", Cliente.Telefono);
                    Cmd.Parameters.AddWithValue("p_Telefono2", Cliente.Telefono2);
                    Cmd.Parameters.AddWithValue("p_Fax", Cliente.Fax);
                    Cmd.Parameters.AddWithValue("p_Correo", Cliente.Correo);
                    //Cmd.Parameters.AddWithValue("p_FechaCreacion", DateTime.Now.Date);
                    //Cmd.Parameters.AddWithValue("p_FechaModificacion", DateTime.Now.Date);
                    Cmd.Parameters.AddWithValue("p_Observacion", Cliente.Observaciones);
                    Cmd.Parameters.AddWithValue("p_CodigoComprobante", Cliente.TipoComprobanteID);
                    Cmd.Parameters.AddWithValue("p_DiasCredito", Cliente.DiasCredito);
                    Cmd.Parameters.AddWithValue("p_LimiteCredito", Cliente.LimiteCredito);
                    Cmd.Parameters.AddWithValue("p_Descuento", Cliente.Descuento);
                    //Cmd.Parameters.AddWithValue("ClasificacionID", Cliente.ClasificacionID);
                    Cmd.Parameters.AddWithValue("p_Balance", Cliente.Balance);
                    Cmd.Parameters.AddWithValue("p_CodigoVend", Cliente.VendedorID);
                    //Cmd.Parameters.AddWithValue("ContactoVentas", Cliente.ContactoVentas);
                    //Cmd.Parameters.AddWithValue("ContactoCobros", Cliente.ContactoCobros);
                    Cmd.Parameters.AddWithValue("p_PaginaWeb", Cliente.PaginaWeb);
                    Cmd.ExecuteNonQuery();
                    Conn.Close();
                }


            }
            catch (MySqlException Ex)
            {
                throw Ex;
            }
        }

        public static void Actualizar(cCliente Cliente)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspActualizarClte";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("p_Codigo", Cliente.Codigo);
                    Cmd.Parameters.AddWithValue("p_NombreComercial", Cliente.NombreComercial);
                    Cmd.Parameters.AddWithValue("p_RNC", Cliente.RNC);
                    Cmd.Parameters.AddWithValue("p_Estatus", Cliente.EstatusID); //Cliente Activo
                    Cmd.Parameters.AddWithValue("p_Direccion", Cliente.Direccion);
                    Cmd.Parameters.AddWithValue("p_Provincia", Cliente.Provincia);
                    Cmd.Parameters.AddWithValue("p_Ciudad", Cliente.Ciudad);
                    Cmd.Parameters.AddWithValue("p_Telefono", Cliente.Telefono);
                    Cmd.Parameters.AddWithValue("p_Telefono2", Cliente.Telefono2);
                    Cmd.Parameters.AddWithValue("p_Fax", Cliente.Fax);
                    Cmd.Parameters.AddWithValue("p_Correo", Cliente.Correo);
                    //Cmd.Parameters.AddWithValue("FechaCreacion", DateTime.Now.Date);
                    //Cmd.Parameters.AddWithValue("FechaModificacion", DateTime.Now.Date);
                    Cmd.Parameters.AddWithValue("p_Observacion", Cliente.Observaciones);
                    Cmd.Parameters.AddWithValue("p_CodigoComprobante", Cliente.TipoComprobanteID);
                    Cmd.Parameters.AddWithValue("p_DiasCredito", Cliente.DiasCredito);
                    Cmd.Parameters.AddWithValue("p_LimiteCredito", Cliente.LimiteCredito);
                    Cmd.Parameters.AddWithValue("p_Descuento", Cliente.Descuento);
                    //Cmd.Parameters.AddWithValue("ClasificacionID", Cliente.ClasificacionID);
                    //Cmd.Parameters.AddWithValue("Balance", Cliente.Balance);
                    Cmd.Parameters.AddWithValue("p_CodigoVend", Cliente.VendedorID);
                    //Cmd.Parameters.AddWithValue("p_ContactoVentas", Cliente.ContactoVentas);
                    //Cmd.Parameters.AddWithValue("p_ContactoCobros", Cliente.ContactoCobros);
                    Cmd.Parameters.AddWithValue("p_PaginaWeb", Cliente.PaginaWeb);

                    Cmd.ExecuteNonQuery();
                }


            }
            catch (MySqlException Ex)
            {
                throw Ex;
            }
        }

        public static cCliente BuscarPorID(Int32 ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarCltePorCodigo";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("p_Codigo", ID);
                    MySqlDataReader Reader = Cmd.ExecuteReader();

                    cCliente Cliente = new cCliente();
                    while (Reader.Read())
                    {
                        Cliente.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                        Cliente.NombreComercial = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Cliente.RNC = Reader.IsDBNull(Reader.GetOrdinal("RNC")) ? null : Reader.GetString(Reader.GetOrdinal("RNC"));
                        Cliente.Direccion = Reader.IsDBNull(Reader.GetOrdinal("Direccion")) ? null : Reader.GetString(Reader.GetOrdinal("Direccion"));
                        Cliente.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Cliente.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia")) ? null : Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Cliente.Telefono = Reader.IsDBNull(Reader.GetOrdinal("Telefono")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Cliente.Fax = Reader.IsDBNull(Reader.GetOrdinal("Fax")) ? null : Reader.GetString(Reader.GetOrdinal("Fax"));
                        Cliente.Correo = Reader.IsDBNull(Reader.GetOrdinal("Correo")) ? null : Reader.GetString(Reader.GetOrdinal("Correo"));
                        Cliente.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Cliente.FechaModificacion = Reader.GetDateTime(Reader.GetOrdinal("FechaModificado"));
                        Cliente.Observaciones = Reader.IsDBNull(Reader.GetOrdinal("Observacion")) ? null : Reader.GetString(Reader.GetOrdinal("Observacion"));
                        //Cliente.Telefono2 = Reader.IsDBNull(Reader.GetOrdinal("Telefono2")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono2"));
                        Cliente.PaginaWeb = Reader.IsDBNull(Reader.GetOrdinal("PaginaWeb")) ? null : Reader.GetString(Reader.GetOrdinal("PaginaWeb"));
                        Cliente.EstatusID = Reader.IsDBNull(Reader.GetOrdinal("Estatus")) ? false : Reader.GetBoolean(Reader.GetOrdinal("Estatus"));
                        Cliente.LimiteCredito = Reader.IsDBNull(Reader.GetOrdinal("LimiteCredito")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("LimiteCredito"));
                        Cliente.DiasCredito = Reader.IsDBNull(Reader.GetOrdinal("DiasCredito")) ? 0 : Reader.GetInt32(Reader.GetOrdinal("DiasCredito"));
                        //Cliente.ContactoCobros = Reader.IsDBNull(Reader.GetOrdinal("ContactoCobros")) ? null : Reader.GetString(Reader.GetOrdinal("ContactoCobros"));
                        //Cliente.ContactoVentas = Reader.IsDBNull(Reader.GetOrdinal("ContactoVentas")) ? null : Reader.GetString(Reader.GetOrdinal("ContactoVentas"));
                        Cliente.VendedorID = Reader.IsDBNull(Reader.GetOrdinal("CodigoVend")) ? -1 : Reader.GetInt32(Reader.GetOrdinal("CodigoVend"));
                        Cliente.TipoComprobanteID = Reader.IsDBNull(Reader.GetOrdinal("CodigoComprobante")) ? (sbyte)-1 : Reader.GetSByte(Reader.GetOrdinal("CodigoComprobante"));
                        Cliente.Descuento = Reader.IsDBNull(Reader.GetOrdinal("Descuento")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Descuento"));
                        Cliente.UltFechaPago = Reader.IsDBNull(Reader.GetOrdinal("UltFchPago")) ? "" : Reader.GetValue(Reader.GetOrdinal("UltFchPago"));
                        Cliente.UltFechaVenta = Reader.IsDBNull(Reader.GetOrdinal("UltFchVenta")) ? "" : Reader.GetValue(Reader.GetOrdinal("UltFchVenta"));
                        Cliente.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Cliente.FechaModificacion = Reader.GetDateTime(Reader.GetOrdinal("FechaModificado"));
                        Cliente.UltDocVenta = Reader.IsDBNull(Reader.GetOrdinal("UltDocVenta")) ? "" : Reader.GetValue(Reader.GetOrdinal("UltDocVenta"));
                        Cliente.UltDocPago = Reader.IsDBNull(Reader.GetOrdinal("UltDocPago")) ? "" : Reader.GetValue(Reader.GetOrdinal("UltDocPago"));
                        Cliente.UltMontoPago = Reader.IsDBNull(Reader.GetOrdinal("UltMntPago")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("UltMntPago"));
                        Cliente.UltMontoVenta = Reader.IsDBNull(Reader.GetOrdinal("UltMntVenta")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("UltMntVenta"));
                        Cliente.Balance = Reader.IsDBNull(Reader.GetOrdinal("Balance")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Balance"));
                    }
                    Conn.Close();
                    return Cliente;
                }
            }
            catch (MySqlException Ex)
            {
                throw Ex;
            }
        }

        public static List<cCliente> Listar()
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarCltes";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecutamos el lector 
                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cCliente> Lista = new List<cCliente>();
                    while (Reader.Read())
                    {
                        cCliente Cliente = new cCliente();
                        Cliente.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
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
            catch(MySqlException Ex)
            {
                throw Ex;
            }
        }

        public static List<cCliente> Filtrar(Int32 CodigoDesde,
                                            Int32 CodigoHasta)
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspFiltroClte";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    Cmd.Parameters.AddWithValue("p_CodigoDesde", CodigoDesde);
                    Cmd.Parameters.AddWithValue("p_CodigoHasta", CodigoHasta);
                    //Ejecutamos el lector 
                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cCliente> Lista = new List<cCliente>();
                    while (Reader.Read())
                    {
                        cCliente Cliente = new cCliente();
                        Cliente.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                        Cliente.NombreComercial = Reader.GetString(Reader.GetOrdinal("NombreComercial"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Cliente);
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

        public static List<cCliente> Catalogo(Int64 CodigoDesde, Int64 CodigoHasta, Int32? VendedorID, Boolean? Estatus)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspCatalogoClientes";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametro
                    Cmd.Parameters.AddWithValue("ClienteDesde", CodigoDesde);
                    Cmd.Parameters.AddWithValue("ClienteHasta", CodigoHasta);
                    Cmd.Parameters.AddWithValue("Estatus", Estatus);
                    Cmd.Parameters.AddWithValue("VendedorID", VendedorID);
                    //Ejecutamos el lector 
                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cCliente> Lista = new List<cCliente>();
                    while (Reader.Read())
                    {
                        cCliente Cliente = new cCliente();
                        Cliente.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
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
            catch (MySqlException Ex)
            {
                throw Ex;

            }

        }
    }
}
