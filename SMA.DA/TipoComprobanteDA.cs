using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Entity;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace SMA.DA
{
    public static class TipoComprobanteDA
    {
        public static List<cTipoComprobanteFiscal> Listar()
        {

            try
            {
                //Declaramos la conexion hacia la base de datos
                using (MySqlConnection Conn = new MySqlConnection(cConexion.CadenaConexion()))
                {
                    Conn.Open();
                    //Nombre del procedimiento
                    string StoreProc = "uspListarTipoComproFiscal";
                    //Creamos el command para la insercion
                    MySqlCommand Cmd = new MySqlCommand(StoreProc, Conn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //Ejecutamos el lector 
                    MySqlDataReader Reader = Cmd.ExecuteReader();


                    List<cTipoComprobanteFiscal> Lista = new List<cTipoComprobanteFiscal>();
                    while (Reader.Read())
                    {
                        cTipoComprobanteFiscal TipoComprobanteFiscal = new cTipoComprobanteFiscal();
                        TipoComprobanteFiscal.Codigo = Reader.GetSByte(Reader.GetOrdinal("Codigo"));
                        TipoComprobanteFiscal.Descripcion = Reader.GetString(Reader.GetOrdinal("Descripcion"));
                        TipoComprobanteFiscal.Notas = Reader.GetString(Reader.GetOrdinal("Nota"));
                        

                        //Agregamos el articulo a la lista
                        Lista.Add(TipoComprobanteFiscal);
                    }
                    //Cerramos la conexion
                    Conn.Close();
                    //Retornamos la lista
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
