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
    public static class RelacionCombosDA
    {
        public static List<cRelacionCombos> Listar(Int64 InventarioID)
        {
            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarComponentesCombos";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("InventarioCombo", InventarioID);

                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cRelacionCombos> Lista = new List<cRelacionCombos>();
                    while (Reader.Read())
                    {
                        cRelacionCombos Relacion = new cRelacionCombos();

                        Relacion.ID = Reader.GetInt64(Reader.GetOrdinal("ID"));
                        Relacion.AlmacenID = Reader.GetInt32(Reader.GetOrdinal("AlmacenID"));
                        Relacion.Cantidad = Reader.GetDecimal(Reader.GetOrdinal("Cantidad"));
                        Relacion.InventarioID = Reader.GetInt64(Reader.GetOrdinal("InventarioID"));
                        Relacion.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        Relacion.Precio = Reader.GetDecimal(Reader.GetOrdinal("PrecioPublico"));
                        //Agregamos el articulo a la lista
                        Lista.Add(Relacion);
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

        public static void Crear(cRelacionCombos Relacion)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarRelCombos";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("AlmacenID", Relacion.AlmacenID);
                    Cmd.Parameters.AddWithValue("Cantidad", Relacion.Cantidad);
                    Cmd.Parameters.AddWithValue("InventarioID", Relacion.InventarioID);
                    Cmd.Parameters.AddWithValue("InventComboID", Relacion.InventComboID);

                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }

        }

        public static void ActualizarCantidad(Int64 InventarioID, Int64 InventarioComboID, Decimal Cantidad)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspActualizarCantidadCombo";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("InventarioID", InventarioID );
                    Cmd.Parameters.AddWithValue("InventarioComboID", InventarioComboID);
                    Cmd.Parameters.AddWithValue("Cantidad", Cantidad);

                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static void Eliminar(Int64 InventarioID, Int64 InventarioComboID)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspEliminarRelacionCombo";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("InventarioID", InventarioID);
                    Cmd.Parameters.AddWithValue("InventarioComboID", InventarioComboID);

                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }

        public static Boolean Existe(Int64 InventarioID, Int64 InventarioComboID)
        {
            var Relacion = (from C in Listar(InventarioComboID)
                            where (Int64)C.InventarioID == InventarioID
                            select C).ToList();

            if (Relacion.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Boolean ValidacionAlmacen(Int64 InventarioComboID, int AlmacenID)
        {
            //Llamamos a la lista de articulos contenidos en el combo
            List<cRelacionCombos> Relacion = (from C in Listar(InventarioComboID)
                                                select C).ToList();

            //Variable de control
            int Conteo = 0;
            if (Relacion.Count > 0)
            {
                //Realizamos una busqueda de todos los elementos del combo, si alguno es diferente al almacen
                //del articulo que se adicionara entonces inicializamos la cuenta de la variable de control
                foreach (cRelacionCombos Elemento in Relacion)
                {
                    if ((int)Elemento.AlmacenID != AlmacenID)
                    {
                        Conteo += 1;
                    }
                }
            }
            if (Conteo>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
