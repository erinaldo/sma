using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using System.Data.SqlClient;

namespace SMA.DA
{
    public static class AsignacionNCFDA
    {
       public static void Crear(cAsigancionNCF Asignacion)
        {
            try
            {

                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspInsertarAsignacionNCF";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    //Parametros
                    Cmd.Parameters.AddWithValue("ComprobanteID", Asignacion.ComprobanteID);
                    Cmd.Parameters.AddWithValue("FacturaID", Asignacion.FacturaID);
                    Cmd.Parameters.AddWithValue("FechaAsignacion", Asignacion.FechaAsignacion);
                    Cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
        }
    }
}
