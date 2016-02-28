using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using System.Data.SqlClient;

namespace SMA.DA
{
    public static class TipoComprobanteDA
    {
        public static List<cTipoComprobanteFiscal> Listar()
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (SqlConnection Conn = new SqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarTipoComprobanteFiscal";
                    //Creamos el command para la insercion
                    SqlCommand Cmd = new SqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecutamos el lector 
                    SqlDataReader Reader = Cmd.ExecuteReader();


                    List<cTipoComprobanteFiscal> Lista = new List<cTipoComprobanteFiscal>();
                    while (Reader.Read())
                    {
                        cTipoComprobanteFiscal TipoComprobanteFiscal = new cTipoComprobanteFiscal();
                        TipoComprobanteFiscal.ID = Reader.GetInt32(Reader.GetOrdinal("ID"));
                        TipoComprobanteFiscal.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        TipoComprobanteFiscal.Notas = Reader.GetString(Reader.GetOrdinal("Notas"));
                        TipoComprobanteFiscal.FechaCreacion = Reader.GetDateTime(Reader.GetOrdinal("FechaCreacion"));
                        TipoComprobanteFiscal.FechaModificacion = Reader.GetDateTime(Reader.GetOrdinal("FechaModificacion"));

                        //Agregamos el articulo a la lista
                        Lista.Add(TipoComprobanteFiscal);
                    }
                    //Cerramos la conexion
                    Conn.Close();
                    //Retornamos la lista
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
