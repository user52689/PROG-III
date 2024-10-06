using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace TP6_GRUPO_4.Conexion
{
    public class AccesoDatos
    {
        private readonly string rutaConexion = "Data Source=localhost\\sqlexpress; Initial Catalog=Neptuno; Integrated Security=true";

        public string RutaConexion { get => rutaConexion; }

        public SqlConnection EstablecerConexion()
        {
            SqlConnection cn = new SqlConnection(RutaConexion);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió algún error: " + ex.Message);
                return null;
            }
        }
        public SqlDataAdapter ObtenerAdaptador(string consulta)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consulta, EstablecerConexion());
                return adaptador;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió algún error: " + ex.Message);
                return null;
            }
        }
        public int EjecutarProcedimientoAlmacenado(SqlCommand cmd, String NombreSP)
        {
            SqlConnection cn = EstablecerConexion();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            int FilasCambiadas = cmd.ExecuteNonQuery();
            cn.Close();
            return FilasCambiadas;
        }
    }
}