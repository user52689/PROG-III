using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ComponentModel;


namespace Datos
{
    public class AccesoDatos
    {
        readonly string rutaBD = ConfigurationManager.ConnectionStrings["ConexionClinica"].ConnectionString;
        SqlConnection conexion = null;

        public SqlConnection ObtenerConexion()
        {
            conexion = new SqlConnection(rutaBD);

            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al intentar abrir la conexión: {ex.Message}");
                return null;
            }
        }

        private SqlDataAdapter ObtenerAdaptador(string consulta, SqlConnection cn)
        {
            SqlDataAdapter adp = new SqlDataAdapter(consulta, cn);

            try
            {
                return adp;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener adaptador: {ex.Message}");
                return null;
            }
        }

        public DataTable ObtenerTabla(string tabla, string consulta)
        {
            DataSet ds = new DataSet();

            try
            {
                conexion = ObtenerConexion();
                SqlDataAdapter adp = ObtenerAdaptador(consulta, conexion);
                adp.Fill(ds, tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la tabla con la consulta proporcionada.", ex);
            }
            return ds.Tables[tabla];
        }



        public DataTable ObtenerTablaConComando(string tabla, SqlCommand cmd)
        {
            DataSet ds = new DataSet();

            try
            {
                conexion = ObtenerConexion();

                cmd.Connection = conexion;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds, tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("No se encontro el registro.", ex);
            }

            return ds.Tables[tabla];
        }


        public int EjecutarProcedimientoAlmacenado(SqlCommand cmd, string sp)
        {
            int filasCambiadas;
            try
            {
                conexion = ObtenerConexion();
                SqlCommand _cmd = cmd;
                _cmd.Connection = conexion;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = sp;

                filasCambiadas = _cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar el procedimiento almacenado.", ex);
            }
            return filasCambiadas;
        }


        public bool ExisteRegistro(string consulta)
        {
            bool estado = false;

            try
            {
                conexion = ObtenerConexion();
                SqlCommand cmd = new SqlCommand(consulta, conexion);
                SqlDataReader datos = cmd.ExecuteReader();

                if (datos.Read())
                {
                    estado = true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al verificar si existe un registro con la consulta proporcionada.", ex);
            }
            return estado;
        }


        public bool ExisteRegistroConComando(SqlCommand cmd)
        {
            bool estado = false;

            try
            {
                using (conexion = ObtenerConexion())
                {
                    cmd.Connection = conexion;
                    SqlDataReader datos = cmd.ExecuteReader();

                    if (datos.Read())
                    {
                        estado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar si existe un registro con el comando proporcionado.", ex);
            }
            return estado;
        }


        public int ObtenerMaximo(String consulta)
        {
            int max = 0;
            conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                max = Convert.ToInt32(datos[0].ToString());
            }
            return max;
        }

        public int EjecutarComando(SqlCommand cmd)
        {
            int filasAfectadas = 0;

            try
            {
                using (conexion = ObtenerConexion())
                {
                    cmd.Connection = conexion;
                    cmd.CommandType = CommandType.Text;
                    filasAfectadas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar el comando.", ex);
            }

            return filasAfectadas;
        }
    }
}