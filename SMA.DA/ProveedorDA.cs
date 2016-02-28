using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using System.Data.SqlClient;

namespace SMA.DA
{
    public static class ProveedorDA
    {
        public static void Crear(cProveedor Proveedor)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarProveedor";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("NombreComercial", Proveedor.NombreComercial);
                    Cmd.Parameters.AddWithValue("RNC", Proveedor.RNC);
                    Cmd.Parameters.AddWithValue("EstatusID", Proveedor.EstatusID);
                    Cmd.Parameters.AddWithValue("Direccion", Proveedor.Direccion);
                    Cmd.Parameters.AddWithValue("Provincia", Proveedor.Provincia);
                    Cmd.Parameters.AddWithValue("Ciudad", Proveedor.Ciudad);
                    Cmd.Parameters.AddWithValue("Telefono", Proveedor.Telefono);
                    Cmd.Parameters.AddWithValue("Telefono2", Proveedor.Telefono2);
                    Cmd.Parameters.AddWithValue("Fax", Proveedor.Fax);
                    Cmd.Parameters.AddWithValue("Correo", Proveedor.Correo);
                    //Cmd.Parameters.AddWithValue("FechaCreacion",Proveedor.FechaCreacion );
                    Cmd.Parameters.AddWithValue("FechaModificacion", DateTime.Now.Date);
                    Cmd.Parameters.AddWithValue("FechaCreacion", DateTime.Now.Date);
                    Cmd.Parameters.AddWithValue("Observaciones", Proveedor.Observaciones);
                    Cmd.Parameters.AddWithValue("DiasCredito", Proveedor.DiasCredito);
                    Cmd.Parameters.AddWithValue("LimiteCredito", Proveedor.LimiteCredito);
                    Cmd.Parameters.AddWithValue("Descuento", Proveedor.Descuento);
                    //Cmd.Parameters.AddWithValue("ClasificacionID", Proveedor.ClasificacionID);
                    Cmd.Parameters.AddWithValue("Balance", Proveedor.Balance);
                    Cmd.Parameters.AddWithValue("ContactoCompras", Proveedor.ContactoCompras);
                    Cmd.Parameters.AddWithValue("ContactoPagos", Proveedor.ContactoPagos);
                    Cmd.Parameters.AddWithValue("PaginaWeb", Proveedor.PaginaWeb);
                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static void Actualizar(cProveedor Proveedor)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspActualizarProveedor";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("ProveedorID", Proveedor.ID);
                    Cmd.Parameters.AddWithValue("NombreComercial", Proveedor.NombreComercial);
                    Cmd.Parameters.AddWithValue("RNC", Proveedor.RNC);
                    Cmd.Parameters.AddWithValue("EstatusID", Proveedor.EstatusID);
                    Cmd.Parameters.AddWithValue("Direccion", Proveedor.Direccion);
                    Cmd.Parameters.AddWithValue("Provincia", Proveedor.Provincia);
                    Cmd.Parameters.AddWithValue("Ciudad", Proveedor.Ciudad);
                    Cmd.Parameters.AddWithValue("Telefono", Proveedor.Telefono);
                    Cmd.Parameters.AddWithValue("Telefono2", Proveedor.Telefono2);
                    Cmd.Parameters.AddWithValue("Fax", Proveedor.Fax);
                    Cmd.Parameters.AddWithValue("Correo", Proveedor.Correo);
                    //Cmd.Parameters.AddWithValue("FechaCreacion",Proveedor.FechaCreacion );
                    //Cmd.Parameters.AddWithValue("FechaModificacion", DateTime.Now.Date);
                    //Cmd.Parameters.AddWithValue("Observaciones", Proveedor.Observaciones);
                    //Cmd.Parameters.AddWithValue("FechaCreacion", DateTime.Now.Date);
                    //Cmd.Parameters.AddWithValue("FechaModificacion", DateTime.Now.Date);
                    Cmd.Parameters.AddWithValue("Observaciones", Proveedor.Observaciones);
                    Cmd.Parameters.AddWithValue("DiasCredito", Proveedor.DiasCredito);
                    Cmd.Parameters.AddWithValue("LimiteCredito", Proveedor.LimiteCredito);
                    Cmd.Parameters.AddWithValue("Descuento", Proveedor.Descuento);
                    //Cmd.Parameters.AddWithValue("ClasificacionID", Proveedor.ClasificacionID);
                    //Cmd.Parameters.AddWithValue("Balance", Proveedor.Balance);
                    Cmd.Parameters.AddWithValue("ContactoCompras", Proveedor.ContactoCompras);
                    Cmd.Parameters.AddWithValue("ContactoPagos", Proveedor.ContactoPagos);
                    Cmd.Parameters.AddWithValue("PaginaWeb", Proveedor.PaginaWeb);
                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static cProveedor BuscarPorID(Int64 ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarProveedorPorID";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("ProveedorID", ID);
                    SqlDataReader Reader = Cmd.ExecuteReader();

                    cProveedor Proveedor = new cProveedor();
                    while (Reader.Read())
                    {
                        Proveedor.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Proveedor.NombreComercial = Reader.GetString(Reader.GetOrdinal("NombreComercial"));
                        Proveedor.RNC = Reader.IsDBNull(Reader.GetOrdinal("RNC")) ? null : Reader.GetString(Reader.GetOrdinal("RNC"));
                        Proveedor.Direccion = Reader.IsDBNull(Reader.GetOrdinal("Direccion")) ? null : Reader.GetString(Reader.GetOrdinal("Direccion"));
                        Proveedor.Ciudad = Reader.IsDBNull(Reader.GetOrdinal("Ciudad")) ? null : Reader.GetString(Reader.GetOrdinal("Ciudad"));
                        Proveedor.Provincia = Reader.IsDBNull(Reader.GetOrdinal("Provincia")) ? null : Reader.GetString(Reader.GetOrdinal("Provincia"));
                        Proveedor.Telefono = Reader.IsDBNull(Reader.GetOrdinal("Telefono")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono"));
                        Proveedor.Fax = Reader.IsDBNull(Reader.GetOrdinal("Fax")) ? null : Reader.GetString(Reader.GetOrdinal("Fax"));
                        Proveedor.Correo = Reader.IsDBNull(Reader.GetOrdinal("Correo")) ? null : Reader.GetString(Reader.GetOrdinal("Correo"));
                       
                        Proveedor.Observaciones = Reader.IsDBNull(Reader.GetOrdinal("Observaciones")) ? null : Reader.GetString(Reader.GetOrdinal("Observaciones"));
                        Proveedor.Telefono2 = Reader.IsDBNull(Reader.GetOrdinal("Telefono2")) ? null : Reader.GetString(Reader.GetOrdinal("Telefono2"));
                        Proveedor.PaginaWeb = Reader.IsDBNull(Reader.GetOrdinal("PaginaWeb")) ? null : Reader.GetString(Reader.GetOrdinal("PaginaWeb"));
                        Proveedor.EstatusID = Reader.IsDBNull(Reader.GetOrdinal("EstatusID")) ? false : Reader.GetBoolean(Reader.GetOrdinal("EstatusID"));
                        Proveedor.LimiteCredito = Reader.IsDBNull(Reader.GetOrdinal("LimiteCredito")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("LimiteCredito"));
                        Proveedor.DiasCredito = Reader.IsDBNull(Reader.GetOrdinal("DiasCredito")) ? 0 : Reader.GetInt32(Reader.GetOrdinal("DiasCredito"));
                        Proveedor.ContactoPagos = Reader.IsDBNull(Reader.GetOrdinal("ContactoPagos")) ? null : Reader.GetString(Reader.GetOrdinal("ContactoPagos"));
                        Proveedor.ContactoCompras = Reader.IsDBNull(Reader.GetOrdinal("ContactoCompras")) ? null : Reader.GetString(Reader.GetOrdinal("ContactoCompras"));
                        Proveedor.Descuento = Reader.IsDBNull(Reader.GetOrdinal("Descuento")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Descuento"));
                        Proveedor.UltFechaPago = Reader.IsDBNull(Reader.GetOrdinal("UltFechaPago")) ? "" : Reader.GetValue(Reader.GetOrdinal("UltFechaPago"));
                        Proveedor.UltFechaCompra = Reader.IsDBNull(Reader.GetOrdinal("UltFechaCompra")) ? "" : Reader.GetValue(Reader.GetOrdinal("UltFechaCompra"));
                        Proveedor.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Proveedor.FechaModificacion = Reader.GetDateTime(Reader.GetOrdinal("FechaModificacion"));
                        Proveedor.UltDocCompra = Reader.IsDBNull(Reader.GetOrdinal("UltDocCompra")) ? "-1" : Reader.GetString(Reader.GetOrdinal("UltDocCompra"));
                        Proveedor.UltDocPago = Reader.IsDBNull(Reader.GetOrdinal("UltDocPago")) ? "-1" : Reader.GetString(Reader.GetOrdinal("UltDocPago"));
                        Proveedor.UltMontoPago = Reader.IsDBNull(Reader.GetOrdinal("UltMontoPago")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("UltMontoPago"));
                        Proveedor.UltMontoCompra = Reader.IsDBNull(Reader.GetOrdinal("UltMontoCompra")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("UltMontoCompra"));
                        Proveedor.Balance = Reader.IsDBNull(Reader.GetOrdinal("Balance")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Balance"));
                    }
                    Conn.Close();
                    return Proveedor;
                }
            }
            catch (SqlException Ex)
            {
               
                throw Ex;

            }
        }

        public static List<cProveedor> Listar()
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarProveedor";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cProveedor> Lista = new List<cProveedor>();
                    while (Reader.Read())
                    {
                        cProveedor Proveedor = new cProveedor();
                        Proveedor.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
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
            catch (SqlException Ex)
            {
                return null;
                throw Ex;

            }

        }

        public static Boolean Existe(Int64 ID)
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

        public static void Eliminar(Int64 ID)
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

        public static List<cProveedor> Filtrar(Int64? CodigoDesde,
                                           Int64? CodigoHasta,
                                           //Int32? VendedorID,
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
                    string StoreProc = "uspFiltroProveedor";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    Cmd.Parameters.AddWithValue("CodigoDesde", CodigoDesde);
                    Cmd.Parameters.AddWithValue("CodigoHasta", CodigoHasta);
                    //Cmd.Parameters.AddWithValue("VendedorID", VendedorID);
                    Cmd.Parameters.AddWithValue("Nombre", Nombre);
                    Cmd.Parameters.AddWithValue("EstatusID", EstatusID);
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cProveedor> Lista = new List<cProveedor>();
                    while (Reader.Read())
                    {
                        cProveedor Proveedor = new cProveedor();
                        Proveedor.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
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
            catch (SqlException Ex)
            {
                throw Ex;

            }

        }

        public static List<cProveedor> Catalogo(Int64 CodigoDesde, Int64 CodigoHasta, Boolean? Estatus)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspCatalogoProveedores";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametro
                    Cmd.Parameters.AddWithValue("ProveedorDesde", CodigoDesde);
                    Cmd.Parameters.AddWithValue("ProveedorHasta", CodigoHasta);
                    Cmd.Parameters.AddWithValue("Estatus", Estatus);
                    
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cProveedor> Lista = new List<cProveedor>();
                    while (Reader.Read())
                    {
                        cProveedor Proveedor = new cProveedor();
                        Proveedor.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
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
                        Proveedor.UltFechaCompra = Reader.IsDBNull(Reader.GetOrdinal("UltFechaCompra")) ? DateTime.Now : Reader.GetDateTime(Reader.GetOrdinal("UltFechaCompra"));
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
            catch (SqlException Ex)
            {
                throw Ex;

            }

        }
    }
}
