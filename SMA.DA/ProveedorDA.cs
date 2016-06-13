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
    public static class ProveedorDA
    {
        public static void Crear(cProveedor Proveedor)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarProv";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("p_NombreComercial", Proveedor.NombreComercial);
                    Cmd.Parameters.AddWithValue("p_RNC", Proveedor.RNC);
                    Cmd.Parameters.AddWithValue("p_Estatus", Proveedor.EstatusID);
                    Cmd.Parameters.AddWithValue("p_Direccion", Proveedor.Direccion);
                    Cmd.Parameters.AddWithValue("p_Provincia", Proveedor.Provincia);
                    Cmd.Parameters.AddWithValue("p_Ciudad", Proveedor.Ciudad);
                    Cmd.Parameters.AddWithValue("p_Telefono", Proveedor.Telefono);
                    //Cmd.Parameters.AddWithValue("Telefono2", Proveedor.Telefono2);
                    Cmd.Parameters.AddWithValue("p_Fax", Proveedor.Fax);
                    Cmd.Parameters.AddWithValue("p_Correo", Proveedor.Correo);
                    //Cmd.Parameters.AddWithValue("FechaCreacion",Proveedor.FechaCreacion );
                    //Cmd.Parameters.AddWithValue("FechaModificacion", DateTime.Now.Date);
                    //Cmd.Parameters.AddWithValue("FechaCreacion", DateTime.Now.Date);
                    Cmd.Parameters.AddWithValue("p_Observacion", Proveedor.Observaciones);
                    Cmd.Parameters.AddWithValue("p_DiasCredito", Proveedor.DiasCredito);
                    Cmd.Parameters.AddWithValue("p_LimiteCredito", Proveedor.LimiteCredito);
                    Cmd.Parameters.AddWithValue("p_Descuento", Proveedor.Descuento);
                    //Cmd.Parameters.AddWithValue("ClasificacionID", Proveedor.ClasificacionID);
                    Cmd.Parameters.AddWithValue("p_Balance", Proveedor.Balance);
                    //Cmd.Parameters.AddWithValue("ContactoCompras", Proveedor.ContactoCompras);
                    //Cmd.Parameters.AddWithValue("ContactoPagos", Proveedor.ContactoPagos);
                    Cmd.Parameters.AddWithValue("p_PaginaWeb", Proveedor.PaginaWeb);
                    Cmd.ExecuteNonQuery();
                }


            }
            catch (MySqlException Ex)
            {
                throw Ex;
            }
        }

        public static void Actualizar(cProveedor Proveedor)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspActualizarProv";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("p_Codigo", Proveedor.Codigo);
                    Cmd.Parameters.AddWithValue("p_NombreComercial", Proveedor.NombreComercial);
                    Cmd.Parameters.AddWithValue("p_RNC", Proveedor.RNC);
                    Cmd.Parameters.AddWithValue("p_Estatus", Proveedor.EstatusID);
                    Cmd.Parameters.AddWithValue("p_Direccion", Proveedor.Direccion);
                    Cmd.Parameters.AddWithValue("p_Provincia", Proveedor.Provincia);
                    Cmd.Parameters.AddWithValue("p_Ciudad", Proveedor.Ciudad);
                    Cmd.Parameters.AddWithValue("p_Telefono", Proveedor.Telefono);
                    //Cmd.Parameters.AddWithValue("Telefono2", Proveedor.Telefono2);
                    Cmd.Parameters.AddWithValue("p_Fax", Proveedor.Fax);
                    Cmd.Parameters.AddWithValue("p_Correo", Proveedor.Correo);
                    //Cmd.Parameters.AddWithValue("FechaCreacion",Proveedor.FechaCreacion );
                    //Cmd.Parameters.AddWithValue("FechaModificacion", DateTime.Now.Date);
                    //Cmd.Parameters.AddWithValue("Observaciones", Proveedor.Observaciones);
                    //Cmd.Parameters.AddWithValue("FechaCreacion", DateTime.Now.Date);
                    //Cmd.Parameters.AddWithValue("FechaModificacion", DateTime.Now.Date);
                    Cmd.Parameters.AddWithValue("p_Observacion", Proveedor.Observaciones);
                    Cmd.Parameters.AddWithValue("p_DiasCredito", Proveedor.DiasCredito);
                    Cmd.Parameters.AddWithValue("p_LimiteCredito", Proveedor.LimiteCredito);
                    Cmd.Parameters.AddWithValue("p_Descuento", Proveedor.Descuento);
                    //Cmd.Parameters.AddWithValue("ClasificacionID", Proveedor.ClasificacionID);
                    //Cmd.Parameters.AddWithValue("Balance", Proveedor.Balance);
                    //Cmd.Parameters.AddWithValue("ContactoCompras", Proveedor.ContactoCompras);
                    //Cmd.Parameters.AddWithValue("ContactoPagos", Proveedor.ContactoPagos);
                    Cmd.Parameters.AddWithValue("p_PaginaWeb", Proveedor.PaginaWeb);
                    Cmd.ExecuteNonQuery();
                }


            }
            catch (MySqlException Ex)
            {
                throw Ex;
            }
        }

        public static cProveedor BuscarPorID(Int32 ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarProvPorCodigo";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("p_Codigo", ID);
                    MySqlDataReader Reader = Cmd.ExecuteReader();

                    cProveedor Proveedor = new cProveedor();
                    while (Reader.Read())
                    {
                        Proveedor.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                        Proveedor.NombreComercial = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Proveedor.RNC = Reader.IsDBNull(Reader.GetOrdinal("RNC")) ? null : Reader.GetString(Reader.GetOrdinal("RNC"));
                        Proveedor.Direccion = Reader.IsDBNull(Reader.GetOrdinal("Direccion")) ? null : Reader.GetString(Reader.GetOrdinal("Direccion"));
                        Proveedor.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Proveedor.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia")) ? null : Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Proveedor.Telefono = Reader.IsDBNull(Reader.GetOrdinal("Telefono")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Proveedor.Fax = Reader.IsDBNull(Reader.GetOrdinal("Fax")) ? null : Reader.GetString(Reader.GetOrdinal("Fax"));
                        Proveedor.Correo = Reader.IsDBNull(Reader.GetOrdinal("Correo")) ? null : Reader.GetString(Reader.GetOrdinal("Correo"));
                        Proveedor.Observaciones = Reader.IsDBNull(Reader.GetOrdinal("Observacion")) ? null : Reader.GetString(Reader.GetOrdinal("Observacion"));
                        //Proveedor.Telefono2 = Reader.IsDBNull(Reader.GetOrdinal("Telefono2")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono2"));
                        Proveedor.PaginaWeb = Reader.IsDBNull(Reader.GetOrdinal("PaginaWeb")) ? null : Reader.GetString(Reader.GetOrdinal("PaginaWeb"));
                        Proveedor.EstatusID = Reader.IsDBNull(Reader.GetOrdinal("Estatus")) ? false : Reader.GetBoolean(Reader.GetOrdinal("Estatus"));
                        Proveedor.LimiteCredito = Reader.IsDBNull(Reader.GetOrdinal("LimiteCredito")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("LimiteCredito"));
                        Proveedor.DiasCredito = Reader.IsDBNull(Reader.GetOrdinal("DiasCredito")) ? 0 : Reader.GetInt32(Reader.GetOrdinal("DiasCredito"));
                        //Proveedor.ContactoPagos = Reader.IsDBNull(Reader.GetOrdinal("ContactoPagos")) ? null : Reader.GetString(Reader.GetOrdinal("ContactoPagos"));
                        //Proveedor.ContactoCompras = Reader.IsDBNull(Reader.GetOrdinal("ContactoCompras")) ? null : Reader.GetString(Reader.GetOrdinal("ContactoCompras"));
                        Proveedor.Descuento = Reader.IsDBNull(Reader.GetOrdinal("Descuento")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Descuento"));
                        Proveedor.UltFechaPago = Reader.IsDBNull(Reader.GetOrdinal("UltFchPago")) ? "" : Reader.GetValue(Reader.GetOrdinal("UltFchPago"));
                        Proveedor.UltFechaCompra = Reader.IsDBNull(Reader.GetOrdinal("UltFchCompra")) ? "" : Reader.GetValue(Reader.GetOrdinal("UltFchCompra"));
                        Proveedor.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Proveedor.FechaModificacion = Reader.GetDateTime(Reader.GetOrdinal("FechaModificado"));
                        Proveedor.UltDocCompra = Reader.IsDBNull(Reader.GetOrdinal("UltDocCompra")) ? "-1" : Reader.GetString(Reader.GetOrdinal("UltDocCompra"));
                        Proveedor.UltDocPago = Reader.IsDBNull(Reader.GetOrdinal("UltDocPago")) ? "-1" : Reader.GetString(Reader.GetOrdinal("UltDocPago"));
                        Proveedor.UltMontoPago = Reader.IsDBNull(Reader.GetOrdinal("UltMntPago")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("UltMntPago"));
                        Proveedor.UltMontoCompra = Reader.IsDBNull(Reader.GetOrdinal("UltMntCompra")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("UltMntCompra"));
                        Proveedor.Balance = Reader.IsDBNull(Reader.GetOrdinal("Balance")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Balance"));
                    }
                    Conn.Close();
                    return Proveedor;
                }
            }
            catch (MySqlException Ex)
            {
               
                throw Ex;

            }
        }

        public static List<cProveedor> Listar()
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarProv";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecutamos el lector 
                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cProveedor> Lista = new List<cProveedor>();
                    while (Reader.Read())
                    {
                        cProveedor Proveedor = new cProveedor();
                        Proveedor.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                        Proveedor.NombreComercial = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Proveedor.RNC = Reader.IsDBNull(Reader.GetOrdinal("RNC")) ? null : Reader.GetString(Reader.GetOrdinal("RNC"));
                        Proveedor.Telefono = Reader.IsDBNull(Reader.GetOrdinal("Telefono")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Proveedor.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Proveedor.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia")) ? null : Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Proveedor.Balance = Reader.IsDBNull(Reader.GetOrdinal("Balance")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Balance"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Proveedor);
                    }
                    //Cerramos la conexion
                    Conn.Close();
                    //Retornamos la lista de Proveedors
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

        public static void Eliminar(Int32 ID)
        {
            //Cambia el estatus del Proveedor en la base de datos.
            try
            {
                //Creamos un objeto Proveedor
                cProveedor Proveedor = new cProveedor();

                //Buscamos los datos del Proveedor por su ID
                Proveedor = BuscarPorID(ID);

                //Intercambiamos los estatus del Proveedor
                if ((Boolean)Proveedor.EstatusID == true)
                {
                    Proveedor.EstatusID = false;
                }

                //Actualizamos la informacion del Proveedor
                Actualizar(Proveedor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public static List<cProveedor> Filtrar(Int32? CodigoDesde,
                                           Int32? CodigoHasta,
                                           //Int32? VendedorID,
                                           String Nombre,
                                           Boolean? EstatusID)
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspFiltroProv";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    Cmd.Parameters.AddWithValue("CodigoDesde", CodigoDesde);
                    Cmd.Parameters.AddWithValue("CodigoHasta", CodigoHasta);
                    //Cmd.Parameters.AddWithValue("VendedorID", VendedorID);
                    Cmd.Parameters.AddWithValue("Nombre", Nombre);
                    Cmd.Parameters.AddWithValue("Estatus", EstatusID);
                    //Ejecutamos el lector 
                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cProveedor> Lista = new List<cProveedor>();
                    while (Reader.Read())
                    {
                        cProveedor Proveedor = new cProveedor();
                        Proveedor.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                        Proveedor.NombreComercial = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Proveedor.RNC = Reader.IsDBNull(Reader.GetOrdinal("RNC")) ? null : Reader.GetString(Reader.GetOrdinal("RNC"));
                        Proveedor.Telefono = Reader.IsDBNull(Reader.GetOrdinal("Telefono")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Proveedor.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Proveedor.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia")) ? null : Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Proveedor.Balance = Reader.IsDBNull(Reader.GetOrdinal("Balance")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Balance"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Proveedor);
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

        public static List<cProveedor> Catalogo(Int64 CodigoDesde, Int64 CodigoHasta, Boolean? Estatus)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspCatalogProv";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametro
                    Cmd.Parameters.AddWithValue("p_ProveedorDesde", CodigoDesde);
                    Cmd.Parameters.AddWithValue("p_ProveedorHasta", CodigoHasta);
                    Cmd.Parameters.AddWithValue("p_Estatus", Estatus);
                    
                    //Ejecutamos el lector 
                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cProveedor> Lista = new List<cProveedor>();
                    while (Reader.Read())
                    {
                        cProveedor Proveedor = new cProveedor();
                        Proveedor.Codigo = Reader.GetInt32(Reader.GetOrdinal("Codigo"));
                        Proveedor.NombreComercial = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Proveedor.RNC = Reader.IsDBNull(Reader.GetOrdinal("RNC")) ? null : Reader.GetString(Reader.GetOrdinal("RNC"));
                        Proveedor.Telefono = Reader.IsDBNull(Reader.GetOrdinal("Telefono")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Proveedor.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Proveedor.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia")) ? null : Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Proveedor.Fax = Reader.IsDBNull(Reader.GetOrdinal("Fax")) ? null : Reader.GetString(Reader.GetOrdinal("Fax"));
                        Proveedor.Correo = Reader.IsDBNull(Reader.GetOrdinal("Correo")) ? null : Reader.GetString(Reader.GetOrdinal("Correo"));
                        Proveedor.Descuento = Reader.IsDBNull(Reader.GetOrdinal("Descuento")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Descuento"));
                        Proveedor.LimiteCredito = Reader.IsDBNull(Reader.GetOrdinal("LimiteCredito")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("LimiteCredito"));
                        Proveedor.DiasCredito = Reader.IsDBNull(Reader.GetOrdinal("DiasCredito")) ? 0 : Reader.GetInt32(Reader.GetOrdinal("DiasCredito"));
                        Proveedor.UltFechaCompra = Reader.IsDBNull(Reader.GetOrdinal("UltFchCompra")) ? DateTime.Now : Reader.GetDateTime(Reader.GetOrdinal("UltFchCompra"));
                        //Cliente.Balance = Reader.IsDBNull(Reader.GetOrdinal("Balance")) ? 0.00 : Reader.GetDouble(Reader.GetOrdinal("Balance"));

                        //Agregamos el articulo a la lista
                        Lista.Add(Proveedor);
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
