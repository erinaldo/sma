using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMA.Entity;
using System.Data;
using System.Data.SqlClient;
using System.IO;


namespace SMA.DA
{
    public static class InventarioDA
    {
        public static void Crear(cInventario Inventario)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarInventario";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("CodigoArticulo", Inventario.CodigoArticulo);
                    Cmd.Parameters.AddWithValue("UltCosto", Inventario.UltCosto);
                    Cmd.Parameters.AddWithValue("Descripcion", Inventario.Descripcion);
                    Cmd.Parameters.AddWithValue("TipoArticulo", Inventario.TipoArticulo);
                    // Cmd.Parameters.AddWithValue("UbicacionID", Inventario.UbicacionID);
                    Cmd.Parameters.AddWithValue("PrecioPublico", Inventario.PrecioPublico);
                    Cmd.Parameters.AddWithValue("Precio2", Inventario.Precio2);
                    Cmd.Parameters.AddWithValue("Precio3", Inventario.Precio3);
                    Cmd.Parameters.AddWithValue("Precio4", Inventario.Precio4);
                    Cmd.Parameters.AddWithValue("ImpuestoID", Inventario.ImpuestoID);
                    Cmd.Parameters.AddWithValue("StockMax", Inventario.StockMax);
                    Cmd.Parameters.AddWithValue("StockMin", Inventario.StockMin);
                    Cmd.Parameters.AddWithValue("Existencia", Inventario.Existencia);
                    //Cmd.Parameters.AddWithValue("ImagenURL", Inventario.ImagenURL);
                    Cmd.Parameters.AddWithValue("FamiliaID", Inventario.FamiliaID);
                    Cmd.Parameters.AddWithValue("MarcaID", Inventario.MarcaID);
                    Cmd.Parameters.AddWithValue("Notas", Inventario.Notas);
                    Cmd.Parameters.AddWithValue("FechaCreacion", DateTime.Now.Date);
                    Cmd.Parameters.AddWithValue("FechaModificacion", DateTime.Now.Date);
                    Cmd.Parameters.AddWithValue("EstatusID", Inventario.EstatusID);
                    Cmd.Parameters.AddWithValue("UnidadEntradaID", Inventario.UnidadEntradaID);
                    Cmd.Parameters.AddWithValue("UnidadSalidaID", Inventario.UnidadSalidaID);
                    Cmd.Parameters.AddWithValue("FechaVencimiento", Inventario.FechaVencimiento);
                    Cmd.Parameters.AddWithValue("AvisarVencimiento", Inventario.AvisarVencimiento);
                    Cmd.Parameters.AddWithValue("FacturarSinExistencia", Inventario.FacturarSinExistencia);
                    Cmd.Parameters.AddWithValue("ProveedorID1", Inventario.ProveedorID1);
                    Cmd.Parameters.AddWithValue("ProveedorID2", Inventario.ProveedorID2);
                    Cmd.Parameters.AddWithValue("Imagen", Inventario.Imagen);
                    //Ejecutamos el comando en la DB
                    Cmd.ExecuteNonQuery();
                    //Cerramos la conexion
                    Conn.Close();
                }
            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static void Actualizar(cInventario Inventario)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspActualizarInventario";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("InventarioID", Inventario.ID);
                    Cmd.Parameters.AddWithValue("Descripcion", Inventario.Descripcion);
                    Cmd.Parameters.AddWithValue("TipoArticulo", Inventario.TipoArticulo);
                    Cmd.Parameters.AddWithValue("PrecioPublico", Inventario.PrecioPublico);
                    Cmd.Parameters.AddWithValue("Precio2", Inventario.Precio2);
                    Cmd.Parameters.AddWithValue("Precio3", Inventario.Precio3);
                    Cmd.Parameters.AddWithValue("Precio4", Inventario.Precio4);
                    Cmd.Parameters.AddWithValue("ImpuestoID", Inventario.ImpuestoID);
                    Cmd.Parameters.AddWithValue("StockMax", Inventario.StockMax);
                    Cmd.Parameters.AddWithValue("StockMin", Inventario.StockMin);
                    Cmd.Parameters.AddWithValue("FamiliaID", Inventario.FamiliaID);
                    Cmd.Parameters.AddWithValue("MarcaID", Inventario.MarcaID);
                    Cmd.Parameters.AddWithValue("Notas", Inventario.Notas);
                    Cmd.Parameters.AddWithValue("FechaModificacion", DateTime.Now.Date);
                    Cmd.Parameters.AddWithValue("EstatusID", Inventario.EstatusID);
                    Cmd.Parameters.AddWithValue("UnidadEntradaID", Inventario.UnidadEntradaID);
                    Cmd.Parameters.AddWithValue("UnidadSalidaID", Inventario.UnidadSalidaID);
                    Cmd.Parameters.AddWithValue("FechaVencimiento", Inventario.FechaVencimiento);
                    Cmd.Parameters.AddWithValue("AvisarVencimiento", Inventario.AvisarVencimiento);
                    Cmd.Parameters.AddWithValue("FacturarSinExistencia", Inventario.FacturarSinExistencia);
                    Cmd.Parameters.AddWithValue("ProveedorID1", Inventario.ProveedorID1);
                    Cmd.Parameters.AddWithValue("ProveedorID2", Inventario.ProveedorID2);
                    Cmd.Parameters.AddWithValue("Imagen", Inventario.Imagen);
                    //Ejecutamos el comando en la DB
                    Cmd.ExecuteNonQuery();
                    //Cerramos la conexion
                    Conn.Close();
                }
            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static List<cInventario> Listar()
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarInventario";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cInventario> Lista = new List<cInventario>();
                    while (Reader.Read())
                    {
                        cInventario Inventario = new cInventario();
                        Inventario.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Inventario.CodigoArticulo = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));
                        Inventario.FamiliaID = Reader.GetString(Reader.GetOrdinal("Familia"));
                        Inventario.MarcaID = Reader.GetString(Reader.GetOrdinal("Marca"));
                        Inventario.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Inventario.TipoArticulo = Reader.GetString(Reader.GetOrdinal("TipoArticulo"));
                        Inventario.PrecioPublico = Reader.GetDecimal(Reader.GetOrdinal("PrecioPublico"));
                        Inventario.Existencia = Reader.IsDBNull(Reader.GetOrdinal("Existencia")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Existencia"));


                        //Agregamos el articulo a la lista
                        Lista.Add(Inventario);
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

        public static cInventario BuscarPorID(Int64 ID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarInventarioPorID";

                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("InventarioID", ID);
                    SqlDataReader Reader = Cmd.ExecuteReader();

                    cInventario Inventario = new cInventario();
                    while (Reader.Read())
                    {
                        Inventario.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Inventario.CodigoArticulo = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));
                        Inventario.Descripcion = Reader.IsDBNull(Reader.GetOrdinal("Descripcion")) ? null : Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Inventario.TipoArticulo = Reader.GetString(Reader.GetOrdinal("TipoArticulo"));
                        Inventario.FechaUltCompra = Reader.IsDBNull(Reader.GetOrdinal("FechaUltCompra")) ? " " : Reader.GetValue(Reader.GetOrdinal("FechaUltCompra")).ToString();
                        Inventario.FechaUltVenta = Reader.IsDBNull(Reader.GetOrdinal("FechaUltVenta")) ? " " : Reader.GetValue(Reader.GetOrdinal("FechaUltVenta")).ToString();
                        Inventario.MontoUltCompra = Reader.IsDBNull(Reader.GetOrdinal("MontoUltCompra")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("MontoUltCompra"));
                        Inventario.MontoUltVenta = Reader.IsDBNull(Reader.GetOrdinal("MontoUltVenta")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("MontoUltVenta"));
                        Inventario.CantUltCompra = Reader.IsDBNull(Reader.GetOrdinal("CantUltCompra")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("CantUltCompra"));
                        Inventario.CantUltVenta = Reader.IsDBNull(Reader.GetOrdinal("CantUltVenta")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("CantUltVenta"));
                        //Inventario.UbicacionID = Reader.GetInt32(Reader.GetOrdinal("UbicacionID"));
                        Inventario.UltCosto = Reader.IsDBNull(Reader.GetOrdinal("UltCosto")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("UltCosto"));
                        Inventario.PrecioPublico = Reader.IsDBNull(Reader.GetOrdinal("PrecioPublico")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("PrecioPublico"));
                        Inventario.Precio2 = Reader.IsDBNull(Reader.GetOrdinal("Precio2")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Precio2"));
                        Inventario.Precio3 = Reader.IsDBNull(Reader.GetOrdinal("Precio3")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Precio3"));
                        Inventario.Precio4 = Reader.IsDBNull(Reader.GetOrdinal("Precio4")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Precio4"));
                        Inventario.ImpuestoID = Reader.GetInt32(Reader.GetOrdinal("ImpuestoID"));
                        Inventario.StockMax = Reader.IsDBNull(Reader.GetOrdinal("StockMax")) ? 0 : Reader.GetInt32(Reader.GetOrdinal("StockMax"));
                        Inventario.StockMin = Reader.IsDBNull(Reader.GetOrdinal("StockMin")) ? 0 : Reader.GetInt32(Reader.GetOrdinal("StockMin"));
                        Inventario.Existencia = Reader.IsDBNull(Reader.GetOrdinal("Existencia")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Existencia"));
                        Inventario.ImagenURL = Reader.IsDBNull(Reader.GetOrdinal("ImagenURL")) ? null : Reader.GetString(Reader.GetOrdinal("ImagenURL"));
                        Inventario.FamiliaID = Reader.IsDBNull(Reader.GetOrdinal("FamiliaID")) ? -1 : Reader.GetInt32(Reader.GetOrdinal("FamiliaID"));
                        Inventario.MarcaID = Reader.IsDBNull(Reader.GetOrdinal("MarcaID")) ? -1 : Reader.GetInt32(Reader.GetOrdinal("MarcaID"));
                        Inventario.CostoPromedio = Reader.IsDBNull(Reader.GetOrdinal("CostoPromedio"))? 0 :Reader.GetDecimal(Reader.GetOrdinal("CostoPromedio"));
                        Inventario.Notas = Reader.IsDBNull(Reader.GetOrdinal("Notas")) ? null : Reader.GetString(Reader.GetOrdinal("Notas"));
                        Inventario.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Inventario.FechaModificacion = Reader.GetDateTime(Reader.GetOrdinal("FechaModificacion"));
                        Inventario.EstatusID = Reader.GetInt32(Reader.GetOrdinal("EstatusID"));
                        Inventario.UnidadEntradaID = Reader.IsDBNull(Reader.GetOrdinal("UnidadEntradaID")) ? -1 : Reader.GetInt32(Reader.GetOrdinal("UnidadEntradaID"));
                        Inventario.UnidadSalidaID = Reader.IsDBNull(Reader.GetOrdinal("UnidadSalidaID")) ? -1 : Reader.GetInt32(Reader.GetOrdinal("UnidadSalidaID"));
                        Inventario.FechaVencimiento = Reader.IsDBNull(Reader.GetOrdinal("FechaVencimiento")) ? DateTime.Now.Date : Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
                        Inventario.AvisarVencimiento = Reader.GetBoolean(Reader.GetOrdinal("AvisarVencimiento"));
                        Inventario.FacturarSinExistencia = Reader.GetBoolean(Reader.GetOrdinal("FacturarSinExistencia"));
                        Inventario.ProveedorID1 = Reader.IsDBNull(Reader.GetOrdinal("ProveedorID1")) ? -1 : Reader.GetInt64(Reader.GetOrdinal("ProveedorID1"));
                        Inventario.ProveedorID2 = Reader.IsDBNull(Reader.GetOrdinal("ProveedorID2")) ? -1 : Reader.GetInt64(Reader.GetOrdinal("ProveedorID2"));
                        byte[] Imagen = Reader.IsDBNull(Reader.GetOrdinal("Imagen")) ? null : (byte[])Reader["Imagen"];
                        if (Imagen != null)
                        {
                            using (MemoryStream ms = new MemoryStream(Imagen))
                            {
                                Inventario.Imagen = Imagen;
                            }
                        }
                        else
                        {
                            Inventario.Imagen = null;
                        }

                    }
                    Conn.Close();
                    return Inventario;
                }
            }
            catch (SqlException Ex)
            {
                return null;
                throw Ex;

            }

        }

        public static cInventario BuscarPorID(string ID)
            {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspBuscarInventarioPorCodigo";

                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Parametros
                    Cmd.Parameters.AddWithValue("CodigoArticulo", ID);
                    SqlDataReader Reader = Cmd.ExecuteReader();

                    cInventario Inventario = new cInventario();
                    while (Reader.Read())
                    {
                        Inventario.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Inventario.CodigoArticulo = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));
                        Inventario.Descripcion = Reader.IsDBNull(Reader.GetOrdinal("Descripcion")) ? null : Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Inventario.TipoArticulo = Reader.GetString(Reader.GetOrdinal("TipoArticulo"));
                        Inventario.FechaUltCompra = Reader.IsDBNull(Reader.GetOrdinal("FechaUltCompra")) ? " " : Reader.GetValue(Reader.GetOrdinal("FechaUltCompra"));
                        Inventario.FechaUltVenta = Reader.IsDBNull(Reader.GetOrdinal("FechaUltVenta")) ? " " : Reader.GetValue(Reader.GetOrdinal("FechaUltVenta"));
                        Inventario.MontoUltCompra = Reader.IsDBNull(Reader.GetOrdinal("MontoUltCompra")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("MontoUltCompra"));
                        Inventario.MontoUltVenta = Reader.IsDBNull(Reader.GetOrdinal("MontoUltVenta")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("MontoUltVenta"));
                        Inventario.CantUltCompra = Reader.IsDBNull(Reader.GetOrdinal("CantUltCompra")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("CantUltCompra"));
                        Inventario.CantUltVenta = Reader.IsDBNull(Reader.GetOrdinal("CantUltVenta")) ? 0: Reader.GetDecimal(Reader.GetOrdinal("CantUltVenta"));
                        //Inventario.UbicacionID = Reader.GetInt32(Reader.GetOrdinal("UbicacionID"));
                        Inventario.UltCosto = Reader.IsDBNull(Reader.GetOrdinal("UltCosto")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("UltCosto"));
                        Inventario.PrecioPublico = Reader.IsDBNull(Reader.GetOrdinal("PrecioPublico")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("PrecioPublico"));
                        Inventario.Precio2 = Reader.IsDBNull(Reader.GetOrdinal("Precio2")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Precio2"));
                        Inventario.Precio3 = Reader.IsDBNull(Reader.GetOrdinal("Precio3")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Precio3"));
                        Inventario.Precio4 = Reader.IsDBNull(Reader.GetOrdinal("Precio4")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Precio4"));
                        Inventario.ImpuestoID = Reader.GetInt32(Reader.GetOrdinal("ImpuestoID"));
                        Inventario.StockMax = Reader.IsDBNull(Reader.GetOrdinal("StockMax")) ? 0 : Reader.GetInt32(Reader.GetOrdinal("StockMax"));
                        Inventario.StockMin = Reader.IsDBNull(Reader.GetOrdinal("StockMin")) ? 0 : Reader.GetInt32(Reader.GetOrdinal("StockMin"));
                        Inventario.Existencia = Reader.IsDBNull(Reader.GetOrdinal("Existencia")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Existencia"));
                        Inventario.ImagenURL = Reader.IsDBNull(Reader.GetOrdinal("ImagenURL")) ? null : Reader.GetString(Reader.GetOrdinal("ImagenURL"));
                        Inventario.FamiliaID = Reader.IsDBNull(Reader.GetOrdinal("FamiliaID")) ? -1 : Reader.GetInt32(Reader.GetOrdinal("FamiliaID"));
                        Inventario.MarcaID = Reader.IsDBNull(Reader.GetOrdinal("MarcaID")) ? -1 : Reader.GetInt32(Reader.GetOrdinal("MarcaID"));
                        Inventario.CostoPromedio = Reader.IsDBNull(Reader.GetOrdinal("CostoPromedio")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("CostoPromedio"));
                        Inventario.Notas = Reader.IsDBNull(Reader.GetOrdinal("Notas")) ? null : Reader.GetString(Reader.GetOrdinal("Notas"));
                        Inventario.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        Inventario.FechaModificacion = Reader.GetDateTime(Reader.GetOrdinal("FechaModificacion"));
                        Inventario.EstatusID = Reader.GetInt32(Reader.GetOrdinal("EstatusID"));
                        Inventario.UnidadEntradaID = Reader.IsDBNull(Reader.GetOrdinal("UnidadEntradaID")) ? -1 : Reader.GetInt32(Reader.GetOrdinal("UnidadEntradaID"));
                        Inventario.UnidadSalidaID = Reader.IsDBNull(Reader.GetOrdinal("UnidadSalidaID")) ? -1 : Reader.GetInt32(Reader.GetOrdinal("UnidadSalidaID"));
                        Inventario.FechaVencimiento = Reader.IsDBNull(Reader.GetOrdinal("FechaVencimiento")) ? DateTime.Now.Date : Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
                        Inventario.AvisarVencimiento = Reader.GetBoolean(Reader.GetOrdinal("AvisarVencimiento"));
                        Inventario.FacturarSinExistencia = Reader.GetBoolean(Reader.GetOrdinal("FacturarSinExistencia"));
                        Inventario.ProveedorID1 = Reader.IsDBNull(Reader.GetOrdinal("ProveedorID1")) ? -1 : Reader.GetInt64(Reader.GetOrdinal("ProveedorID1"));
                        Inventario.ProveedorID2 = Reader.IsDBNull(Reader.GetOrdinal("ProveedorID2")) ? -1 : Reader.GetInt64(Reader.GetOrdinal("ProveedorID2"));
                        byte[] Imagen = Reader.IsDBNull(Reader.GetOrdinal("Imagen")) ? null : (byte[])Reader["Imagen"];
                        if (Imagen != null)
                        {
                            using (MemoryStream ms = new MemoryStream(Imagen))
                            {
                                Inventario.Imagen = Imagen;
                            }
                        }
                        else
                        {
                            Inventario.Imagen = null;
                        }

                    }
                    Conn.Close();
                    return Inventario;
                }
            }
            catch (SqlException Ex)
            {
                throw Ex;
            }

        }

        public static void Eliminar(Int64 ID)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspEliminarInventario";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("ID", ID);

                    Cmd.ExecuteNonQuery();
                    //Cerramos la conexion
                    Conn.Close();
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

        public static Boolean Existe(string Codigo)
        {
            //Comprobacion de si existe el codigo del articulo
            var Resultado = (from c in Listar()
                             where c.CodigoArticulo == Codigo
                             select c).ToList();
            if (Resultado.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<cInventario> Filtrar(string CodigoDesde,
                                                String CodigoHasta,
                                                Int32? FamiliaID,
                                                Int32? MarcaID,
                                                String TipoArticulo,
                                                Int32? IndicadorCreacion,
                                                Int32? IndicadorModificacion,
                                                DateTime? FechaDesde,
                                                DateTime? FechaHasta,
                                                String CriterioCantidad,
                                                Decimal Cantidad,
                                                String Descripcion)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspFiltroInventarios";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("CodigoDesde", CodigoDesde);
                    Cmd.Parameters.AddWithValue("CodigoHasta", CodigoHasta);
                    Cmd.Parameters.AddWithValue("FamiliaID", FamiliaID);
                    Cmd.Parameters.AddWithValue("MarcaID", MarcaID);
                    Cmd.Parameters.AddWithValue("Cantidad", Cantidad);
                    Cmd.Parameters.AddWithValue("TipoArticulo", TipoArticulo);
                    Cmd.Parameters.AddWithValue("IndicadorCreacion", IndicadorCreacion);
                    Cmd.Parameters.AddWithValue("IndicadorModificacion", IndicadorModificacion);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    Cmd.Parameters.AddWithValue("Descripcion", Descripcion);
                    Cmd.Parameters.AddWithValue("CriterioCantidad", CriterioCantidad);

                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cInventario> Lista = new List<cInventario>();
                    while (Reader.Read())
                    {
                        cInventario Inventario = new cInventario();
                        Inventario.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Inventario.CodigoArticulo = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));
                        Inventario.FamiliaID = Reader.GetString(Reader.GetOrdinal("Familia"));
                        Inventario.MarcaID = Reader.GetString(Reader.GetOrdinal("Marca"));
                        Inventario.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Inventario.TipoArticulo = Reader.GetString(Reader.GetOrdinal("TipoArticulo"));
                        Inventario.PrecioPublico = Reader.GetDecimal(Reader.GetOrdinal("PrecioPublico"));
                        Inventario.Existencia = Reader.GetDecimal(Reader.GetOrdinal("Existencia"));


                        //Agregamos el articulo a la lista
                        Lista.Add(Inventario);
                    }
                    //Cerramos la conexion
                    Conn.Close();
                    //Retornamos la lista de clientes
                    return Lista;
                }
            }
            catch(SqlException Ex)
            {
                return null;
                throw Ex;

            }
        }

public static void ActualizarPrecios(Int32 IndPrecioPublico,
        Int32 IndPrecio2,
        Int32 IndPrecio3,
        Int32 IndPrecio4,
        Int32 IndPorcentaje,
        Int32 IndPorCosto,
        Int32 IndPorUltimoCosto,
        Int32 IndCostoPromedio,
        Int32 IndMonto,
        //Double Porcentaje,
        Decimal Monto,
        Int32? FamiliaID,
        Int32? MarcaID,
        String TipoProducto,
        DateTime? FechaDesde,
        DateTime? FechaHasta,
        String CodigoArticuloDesde,
        String CodigoArticuloHasta)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspActualizarPrecioInventario";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("IndPrecioPublico", IndPrecioPublico);
                    Cmd.Parameters.AddWithValue("IndPrecio2", IndPrecio2);
                    Cmd.Parameters.AddWithValue("IndPrecio3", IndPrecio3);
                    Cmd.Parameters.AddWithValue("IndPrecio4", IndPrecio4);
                    Cmd.Parameters.AddWithValue("IndPorcentaje", IndPorcentaje);
                    Cmd.Parameters.AddWithValue("IndPorCosto", IndPorCosto);
                    Cmd.Parameters.AddWithValue("IndPorUltimoCosto", IndPorUltimoCosto);
                    Cmd.Parameters.AddWithValue("IndCostoPromedio", IndCostoPromedio);
                    Cmd.Parameters.AddWithValue("IndMonto", IndMonto);
                    //Cmd.Parameters.AddWithValue("Porcentaje", Porcentaje);
                    Cmd.Parameters.AddWithValue("Monto", Monto);
                    Cmd.Parameters.AddWithValue("FamiliaID", FamiliaID);
                    Cmd.Parameters.AddWithValue("MarcaID", MarcaID);
                    Cmd.Parameters.AddWithValue("TipoProducto", TipoProducto);
                    //Cmd.Parameters.AddWithValue("IndFecha", IndFecha);
                    Cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                    Cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                    Cmd.Parameters.AddWithValue("CodigoArticuloDesde", CodigoArticuloDesde);
                    Cmd.Parameters.AddWithValue("CodigoArticuloHasta", CodigoArticuloHasta);

                    Cmd.ExecuteNonQuery();
                    //Cerramos la conexion
                    Conn.Close();
                }
            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }


    public static List<cInventario> ReporteExistenciaCosto(String CodigoDesde, String CodigoHasta, 
                                                            Int32? FamiliaID, String OrdenadaPor)

        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListaExistenciaCosto";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    Cmd.Parameters.AddWithValue("CodigoDesde", CodigoDesde);
                    Cmd.Parameters.AddWithValue("CodigoHasta", CodigoHasta);
                    Cmd.Parameters.AddWithValue("Familia", FamiliaID);
                    Cmd.Parameters.AddWithValue("OrdenadaPor", OrdenadaPor);
                   

                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cInventario> Lista = new List<cInventario>();
                    while (Reader.Read())
                    {
                        cInventario Inventario = new cInventario();
                        //Inventario.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        Inventario.CodigoArticulo = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));
                        Inventario.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Inventario.UltCosto = Reader.GetDecimal(Reader.GetOrdinal("UltCosto"));
                        Inventario.Existencia = Reader.IsDBNull(Reader.GetOrdinal("Existencia")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Existencia"));
                        Inventario.FechaUltCompra = Reader.IsDBNull(Reader.GetOrdinal("FechaUltCompra")) ? "" : Reader.GetString(Reader.GetOrdinal("FechaUltCompra"));
                        Inventario.CostoPromedio = Reader.GetDecimal(Reader.GetOrdinal("CostoPromedio"));
 
                        //Agregamos el articulo a la lista
                        Lista.Add(Inventario);
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

    public static List<cInventario> ReporteCatalogoProductos(String CodigoDesde, String CodigoHasta, Int32? FamiliaID, Int32? MarcaID, String TipoArticulo, String OrdenadaPor)
    {
        try
        {
            //Declaramos la conexion hacia la base de datos
            using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
            {
                Conn.Open();
                //Nombre del procedimiento
                string StoreProc = "uspCatalogoProductos";
                //Creamos el command para la insercion
                SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                Cmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                Cmd.Parameters.AddWithValue("CodigoDesde", CodigoDesde);
                Cmd.Parameters.AddWithValue("CodigoHasta", CodigoHasta);
                Cmd.Parameters.AddWithValue("FamiliaID", FamiliaID);
                Cmd.Parameters.AddWithValue("MarcaID", MarcaID);
                Cmd.Parameters.AddWithValue("TipoArticulo", TipoArticulo);
                Cmd.Parameters.AddWithValue("OrdenadaPor", OrdenadaPor);

                //Ejecutamos el lector 
                SqlDataReader Reader = Cmd.ExecuteReader();


                List<cInventario> Lista = new List<cInventario>();
                while (Reader.Read())
                {
                    cInventario Inventario = new cInventario();
                    Inventario.CodigoArticulo = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));
                    Inventario.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                    Inventario.FamiliaID = Reader.GetString(Reader.GetOrdinal("Familia"));
                    Inventario.MarcaID = Reader.GetString(Reader.GetOrdinal("Marca"));
                    Inventario.TipoArticulo = Reader.GetString(Reader.GetOrdinal("TipoArticulo"));
                    Inventario.PrecioPublico = Reader.GetDecimal(Reader.GetOrdinal("PrecioPublico"));
                    Inventario.Precio4 = Reader.GetDecimal(Reader.GetOrdinal("PrecioMinimo"));
                    Inventario.StockMax = Reader.GetInt32(Reader.GetOrdinal("StockMax"));
                    Inventario.StockMin = Reader.GetInt32(Reader.GetOrdinal("StockMin"));
                    Inventario.Existencia = Reader.GetDecimal(Reader.GetOrdinal("Existencia"));
                    Inventario.FechaUltCompra = Reader.IsDBNull(Reader.GetOrdinal("FechaUltCompra")) ? DateTime.Now : Reader.GetDateTime(Reader.GetOrdinal("FechaUltCompra"));
                    Inventario.FechaUltVenta = Reader.IsDBNull(Reader.GetOrdinal("FechaUltVenta")) ? DateTime.Now : Reader.GetDateTime(Reader.GetOrdinal("FechaUltVenta"));
                    Inventario.UnidadSalidaID = Reader.GetString(Reader.GetOrdinal("Unidad"));
                    Inventario.ImpuestoID = Reader.GetString(Reader.GetOrdinal("Impuestos"));
                    Inventario.UltCosto = Reader.IsDBNull(Reader.GetOrdinal("UltCosto")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("UltCosto"));
                    Inventario.CostoPromedio = Reader.IsDBNull(Reader.GetOrdinal("CostoPromedio")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("CostoPromedio"));
                    //Agregamos el articulo a la lista
                    Lista.Add(Inventario);
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
    
    public static List<cInventario> ReporteListaPrecios(String CodigoDesde, String CodigoHasta, Int32? FamiliaID, String IndicadorPrecio1, String IndicadorPrecio2, Int32? ConExistencia, String TipoArticulo, String OrdenadaPor)
    {
        try
        {
            //Declaramos la conexion hacia la base de datos
            using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
            {
                Conn.Open();
                //Nombre del procedimiento
                string StoreProc = "uspListaPreciosProductos";
                //Creamos el command para la insercion
                SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                Cmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                Cmd.Parameters.AddWithValue("CodigoDesde", CodigoDesde);
                Cmd.Parameters.AddWithValue("CodigoHasta", CodigoHasta);
                Cmd.Parameters.AddWithValue("FamiliaID", FamiliaID);
                Cmd.Parameters.AddWithValue("ConExistencia",ConExistencia);
                Cmd.Parameters.AddWithValue("IndicadorPrecio1",IndicadorPrecio1);
                Cmd.Parameters.AddWithValue("IndicadorPrecio2",IndicadorPrecio2);
                Cmd.Parameters.AddWithValue("TipoArticulo", TipoArticulo);
                Cmd.Parameters.AddWithValue("OrdenadaPor", OrdenadaPor);

                //Ejecutamos el lector 
                SqlDataReader Reader = Cmd.ExecuteReader();


                List<cInventario> Lista = new List<cInventario>();
                while (Reader.Read())
                {
                    cInventario Inventario = new cInventario();
                    Inventario.CodigoArticulo = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));
                    Inventario.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                    Inventario.FamiliaID = Reader.GetString(Reader.GetOrdinal("Familia"));
                    Inventario.MarcaID = Reader.GetString(Reader.GetOrdinal("Marca"));
                    Inventario.TipoArticulo = Reader.GetString(Reader.GetOrdinal("TipoArticulo"));
                    Inventario.PrecioPublico = Reader.IsDBNull(Reader.GetOrdinal("Precio_1")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Precio_1"));
                    Inventario.Precio4 = Reader.IsDBNull(Reader.GetOrdinal("Precio_2")) ? 0 : Reader.GetDecimal(Reader.GetOrdinal("Precio_2"));
                    Inventario.Existencia = Reader.GetDecimal(Reader.GetOrdinal("Existencia"));
                    Inventario.UnidadSalidaID = Reader.GetString(Reader.GetOrdinal("Unidad"));
                    Inventario.ImpuestoID = Reader.GetString(Reader.GetOrdinal("Impuestos"));
                    Inventario.FamiliaID = Reader.GetString(Reader.GetOrdinal("Familia"));
                    Inventario.MarcaID = Reader.GetString(Reader.GetOrdinal("Marca"));

                    //Agregamos el articulo a la lista
                    Lista.Add(Inventario);
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

    public static List<cInventario> ReporteInventarioFisico(String CodigoDesde, String CodigoHasta, Int32? FamiliaID, Int32? MarcaID,String OrdenadaPor)
    {
        try
        {
            //Declaramos la conexion hacia la base de datos
            using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
            {
                Conn.Open();
                //Nombre del procedimiento
                string StoreProc = "uspInventarioFisico";
                //Creamos el command para la insercion
                SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                Cmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                Cmd.Parameters.AddWithValue("CodigoDesde", CodigoDesde);
                Cmd.Parameters.AddWithValue("CodigoHasta", CodigoHasta);
                Cmd.Parameters.AddWithValue("FamiliaID", FamiliaID);
                Cmd.Parameters.AddWithValue("MarcaID", MarcaID);
                Cmd.Parameters.AddWithValue("OrdenadaPor", OrdenadaPor);

                //Ejecutamos el lector 
                SqlDataReader Reader = Cmd.ExecuteReader();


                List<cInventario> Lista = new List<cInventario>();
                while (Reader.Read())
                {
                    cInventario Inventario = new cInventario();
                    Inventario.CodigoArticulo = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));
                    Inventario.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                    Inventario.FamiliaID = Reader.GetString(Reader.GetOrdinal("Familia"));
                    Inventario.MarcaID = Reader.GetString(Reader.GetOrdinal("Marca"));
                    Inventario.Existencia = Reader.GetDecimal(Reader.GetOrdinal("Existencia"));
                    Inventario.UnidadSalidaID = Reader.GetString(Reader.GetOrdinal("Unidad"));
                    //Agregamos el articulo a la lista
                    Lista.Add(Inventario);
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

    public static List<cInventario> ReporteProductosVencidos(String CodigoDesde, String CodigoHasta, Int32? Familia, Int32? Marca, String OrdenarPor, Int32? IndicadorVencimiento)
    {
        try
        {
            //Declaramos la conexion hacia la base de datos
            using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
            {
                Conn.Open();
                //Nombre del procedimiento
                string StoreProc = "uspReporteProductosVencidos";
                //Creamos el command para la insercion
                SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                Cmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                Cmd.Parameters.AddWithValue("CodigoDesde", CodigoDesde);
                Cmd.Parameters.AddWithValue("CodigoHasta", CodigoHasta);
                Cmd.Parameters.AddWithValue("OrdenadaPor", OrdenarPor);
                Cmd.Parameters.AddWithValue("Familia", Familia);
                Cmd.Parameters.AddWithValue("Marca", Marca);
                Cmd.Parameters.AddWithValue("IndicadorVencimiento", IndicadorVencimiento);


                //Ejecutamos el lector 
                SqlDataReader Reader = Cmd.ExecuteReader();


                List<cInventario> Lista = new List<cInventario>();
                while (Reader.Read())
                {
                    cInventario Resultado = new cInventario();

                    Resultado.CodigoArticulo = Reader.GetString(Reader.GetOrdinal("CodigoArticulo"));
                    Resultado.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                    Resultado.Existencia = Reader.GetDecimal(Reader.GetOrdinal("Existencia"));
                    Resultado.FechaVencimiento = Reader.GetDateTime(Reader.GetOrdinal("FechaVencimiento"));
                    Resultado.FamiliaID = Reader.GetString(Reader.GetOrdinal("Familia"));
                    Resultado.MarcaID = Reader.GetString(Reader.GetOrdinal("Marca"));

                    //Agregamos el articulo a la lista
                    Lista.Add(Resultado);
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
