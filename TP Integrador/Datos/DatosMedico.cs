using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosMedico
    {
        public readonly AccesoDatos ad = new AccesoDatos();
        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        public SqlCommand cmd = new SqlCommand();
        public SqlConnection conexion = new SqlConnection();
        public SqlDataAdapter adapter = new SqlDataAdapter();


        //----------------------------------------------------------------------------------------------------------------------------ALTA
        public bool Agregar_Med(Medico medico)
        {
            try
            {
                using (SqlConnection conexion = ad.ObtenerConexion())
                {
                    if (conexion == null) throw new Exception("No se pudo establecer la conexión con la base de datos.");

                    SqlCommand cmd = new SqlCommand("SP_AgregarMedico", conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@DNI_med", medico.DNI);
                    cmd.Parameters.AddWithValue("@Nombre_med", medico.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido_med", medico.Apellido);
                    cmd.Parameters.AddWithValue("@Genero_med", medico.Genero);
                    cmd.Parameters.AddWithValue("@Nacionalidad_med", medico.Nacionalidad);
                    cmd.Parameters.AddWithValue("@FechaNacimiento_med", medico.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Direccion_med", medico.Direccion);
                    cmd.Parameters.AddWithValue("@Localidad_med", medico.Localidad);
                    cmd.Parameters.AddWithValue("@Provincia_med", medico.Provincia);
                    cmd.Parameters.AddWithValue("@CorreoElectronico_med", medico.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@Telefono_med", medico.Telefono);
                    cmd.Parameters.AddWithValue("@Especialidad_med", medico.Especialidad);
                    cmd.Parameters.AddWithValue("@Estado_med", medico.Estado);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el medico: " + ex.Message);
                return false;
            }
        }


        
        //-----------------------------------------------------------------------------------------------------------------------BAJA
        public int EliminarMedicosDatos(Medico medico)
        {
            string consulta = "UPDATE Medicos SET Estado_med = 0 WHERE Legajo_med = @Legajo_med";

            conexion = ad.ObtenerConexion();

            cmd = new SqlCommand(consulta, conexion);
            cmd.Parameters.AddWithValue("@Legajo_med", medico.Legajo);

            int filasAfectadas = cmd.ExecuteNonQuery();

            return filasAfectadas;
        }

        //-------------------------------------------------------------------------------------------------------------------------------MODIFICACION
        public DataTable ModificarMedicoDatos(Medico medico)
        {
            conexion = ad.ObtenerConexion();

            cmd = new SqlCommand("SP_ModificarMedico", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };

           
            cmd.Parameters.AddWithValue("@Legajo_med", medico.Legajo);
            cmd.Parameters.AddWithValue("@DNI_med", medico.DNI);
            cmd.Parameters.AddWithValue("@Nombre_med", medico.Nombre);
            cmd.Parameters.AddWithValue("@Apellido_med", medico.Apellido);
            cmd.Parameters.AddWithValue("@Genero_med", medico.Genero);
            cmd.Parameters.AddWithValue("@Nacionalidad_med", medico.Nacionalidad);
            cmd.Parameters.AddWithValue("@FechaNacimiento_med", medico.FechaNacimiento);
            cmd.Parameters.AddWithValue("@Direccion_med", medico.Direccion);
            cmd.Parameters.AddWithValue("@Localidad_med", medico.Localidad);
            cmd.Parameters.AddWithValue("@Provincia_med", medico.Provincia);
            cmd.Parameters.AddWithValue("@CorreoElectronico_med", medico.CorreoElectronico);
            cmd.Parameters.AddWithValue("@Telefono_med", medico.Telefono);
            cmd.Parameters.AddWithValue("@Especialidad_med", medico.Especialidad);
            cmd.Parameters.AddWithValue("@Estado_med", medico.Estado);

            ad.EjecutarProcedimientoAlmacenado(cmd, "SP_ModificarMedico");
            if (ad != null)
            {
                return dt;
            }
            return null;
        }

        //-----------------------------------------------------------------------------------------------------------------------LISTADO
        public DataTable GetTablaMedicosDatos() //Todos los medicos
        {
            string consulta = "SELECT * FROM Medicos";

            dt = ad.ObtenerTabla("Medicos", consulta);

            return dt;
        }
        public DataTable FiltrarMedicoLegajoBajaDatos(int Legajo) //Medico filtrado para la baja
        {
            string consulta = "SELECT Legajo_med, DNI_med, Nombre_med, Apellido_med " +
                              "FROM Medicos " +
                              "WHERE Legajo_med = @Legajo AND Estado_med = 1";
            conexion = ad.ObtenerConexion();
            cmd = new SqlCommand(consulta, conexion);
            cmd.Parameters.AddWithValue("@Legajo", Legajo);
            return ad.ObtenerTablaConComando("Medicos", cmd);
        }

        public DataTable FiltrarMedicoLegajoDatos(int Legajo) //Medico filtrado para la modificacion
        {
            string consulta = @"SELECT m.Legajo_med, 
                                        m.DNI_med, 
                                        m.Nombre_med, 
                                        m.Apellido_med, 
                                        g.Descripcion_g , 
                                        n.Nombre_pais , 
                                        m.FechaNacimiento_med,  
                                        m.Direccion_med, 
                                        pr.Nombre_prov, 
                                        l.Nombre_loc , 
                                        m.CorreoElectronico_med, 
                                        m.Telefono_med, 
                                        es.Nombre_esp
                                        FROM Medicos AS m
                                        INNER JOIN GENEROS AS g ON m.Genero_med = g.IdGenero_g
                                        INNER JOIN Paises AS n ON m.Nacionalidad_med = n.IdPais_p
                                        INNER JOIN Localidades AS l ON m.Localidad_med = l.IdLocalidad_loc
                                        INNER JOIN Provincias AS pr ON m.Provincia_med = pr.IdProvincia_prov
                                        INNER JOIN Especialidades as es ON m.Especialidad_med = es.IdEspecialidad_esp
                                        WHERE m.Legajo_med = @Legajo AND Estado_med = 1";

            conexion = ad.ObtenerConexion();
            cmd = new SqlCommand(consulta, conexion);
            cmd.Parameters.AddWithValue("@Legajo", Legajo);

            if (ad.ExisteRegistroConComando(cmd))
            {
                return ad.ObtenerTablaConComando("Medicos", cmd);
            }

            return null;
        }


        //------------------------------------------------------------------------------------------------Cargar DDL
        public DataTable ObtenerGeneros()
        {
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT IdGenero_g, Descripcion_g FROM Generos");
            dt = ad.ObtenerTablaConComando("Generos", cmd);
            return dt;
        }
        public DataTable ObtenerNacionalidades()
        {
            cmd = new SqlCommand("SELECT DISTINCT IdPais_p, Nombre_pais FROM Paises");
            dt = ad.ObtenerTablaConComando("Paises", cmd);
            return dt;
        }
        public DataTable ObtenerProvincias()
        {
            cmd = new SqlCommand("SELECT DISTINCT IdProvincia_prov, Nombre_prov FROM Provincias");
            dt = ad.ObtenerTablaConComando("Provincias", cmd);
            return dt;
        }
        public DataTable ObtenerLocalidadesPorProvincia(int IdProvincia)
        {
            string consulta = "SELECT IdLocalidad_loc, Nombre_loc FROM Localidades WHERE IdProvincia_loc = @IdProvincia";
            cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@IdProvincia", IdProvincia);

            return ad.ObtenerTablaConComando("Localidades", cmd);
        }
        public DataTable ObtenerEspecialidades()
        {
            cmd = new SqlCommand("SELECT DISTINCT IdEspecialidad_esp, Nombre_esp from Especialidades");
            dt = ad.ObtenerTablaConComando("Especialidades", cmd);
            return dt;
        }

        //--------------------------------------------------------------------------------------------------------------------Metodos

        public int ObtenerMaximoLegajoDatos()
        {
            string consulta = "SELECT COUNT(*) FROM Medicos";
            return (ad.ObtenerMaximo(consulta) + 1);
        }
    }
}
