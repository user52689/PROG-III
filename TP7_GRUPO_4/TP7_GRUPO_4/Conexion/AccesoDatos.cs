using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TP7_GRUPO_4.Conexion
{
    public class AccesoDatos
    {
        private readonly string rutaConexion = "Data Source=localhost\\sqlexpress; Initial Catalog=BDSucursales; Integrated Security=true";

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
    }
}