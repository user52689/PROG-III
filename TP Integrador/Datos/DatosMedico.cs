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
        readonly AccesoDatos ad = new AccesoDatos();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlConnection conexion = new SqlConnection();
        SqlDataAdapter adapter = new SqlDataAdapter();


        //------------------------------------------------------------------------------------Obtener medicos
        public DataTable GetTablaMedicosDatos() //Todos los medicos
        {
            string consulta = "SELECT * " +
                              "FROM Medicos";
            return ad.ObtenerTabla("Medicos", consulta);
        }
        public DataTable FiltrarMedicoLegajoBajaDatos(int Legajo) //Medico filtrado para la baja de medico
        {
            string consulta = "SELECT Legajo_med, DNI_med Nombre_med, Apellido_med " +
                              "FROM Medicos " +
                              "WHERE Legajo_med = @Legajo";
            SqlCommand cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@Legajo", Legajo);
            return ad.ObtenerTablaConComando("Medicos", cmd);
        }

        public DataTable FiltrarMedicoLegajoDatos(int Legajo)
        {
            // Consulta para obtener los datos completos del médico y sus relaciones
                   string consulta = @"
         SELECT m.Legajo_med, 
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
             WHERE m.Legajo_med = @Legajo";

            // Crear el comando SQL
            SqlCommand cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@Legajo", Legajo);

            // Ejecutar la consulta y obtener la tabla
            if (ad.ExisteRegistroConComando(cmd))
            {
                return ad.ObtenerTablaConComando("Medicos", cmd);
            }

            return null;
        }
        //--------------------------------------------------------------------------------------Eliminar Medicos

        public int EliminarMedicosDatos(Medico medico)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_EliminarMedico";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Legajo_med", medico.Legajo);

            return ad.EjecutarProcedimientoAlmacenado(cmd, "SP_EliminarMedico");
        }

        //------------------------------------------------------------------------------------------------
        // Obtener Genero de los medicos
        public DataTable ObtenerGeneros()
        {
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT IdGenero_g, Descripcion_g FROM Generos");
            dt = ad.ObtenerTablaConComando("Generos", cmd);
            return dt;
        }
        //obtener especialidad del medico
        public DataTable obtenerEspecialidades()
        {
            cmd = new SqlCommand("SELECT DISTINCT IdEspecialidad_esp, Nombre_esp from Especialidades");
            dt = ad.ObtenerTablaConComando("Especialidades", cmd);
            return dt;
        }


        // Obtener Nacionalidad de los medicos
        public DataTable ObtenerNacionalidades()
        {
            cmd = new SqlCommand("SELECT DISTINCT IdPais_p, Nombre_pais FROM Paises");
            dt = ad.ObtenerTablaConComando("Paises", cmd);
            return dt;
        }

       
        // Obtener Provincia de los medicos
        public DataTable ObtenerProvincias()
        {
            cmd = new SqlCommand("SELECT DISTINCT IdProvincia_prov, Nombre_prov FROM Provincias");
            dt = ad.ObtenerTablaConComando("Provincias", cmd);
            return dt;
        }

       
        // Obtener Localidad de los medicos
        public DataTable ObtenerLocalidades()
        {
            cmd = new SqlCommand("SELECT IdLocalidad_loc, Nombre_loc FROM Localidades");
            dt = ad.ObtenerTablaConComando("Localidades", cmd);
            return dt;
        }

        // Obtener Localidades por Provincia (based on the selected IdProvincia)
        public DataTable ObtenerLocalidadesPorProvincia(int IdProvincia)
        {
            string consulta = "SELECT IdLocalidad_loc, Nombre_loc FROM Localidades WHERE IdProvincia_loc = @IdProvincia";
            cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@IdProvincia", IdProvincia);

            return ad.ObtenerTablaConComando("Localidades", cmd);
        }

     


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

            ad.EjecutarProcedimientoAlmacenado(cmd, "SP_ModificarMedico");
            if (ad != null)
            {
                return dt;
            }
            return null;
        }

public List<Medico> ObtenerListaMedicos()
        {
            string consulta = "SELECT * FROM Medicos";
            DataTable dt = ad.ObtenerTabla("Medicos", consulta);


            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No se encontraron registros en la tabla Medicos.");
            }

            List<Medico> listaMedicos = new List<Medico>();

            foreach (DataRow row in dt.Rows)
            {
                Medico medico = new Medico
                {
                    Legajo = row["Legajo_med"].ToString(),
                    DNI = row["DNI_med"].ToString(),
                    Nombre = row["Nombre_med"].ToString(),
                    Apellido = row["Apellido_med"].ToString(),
                    Genero = row["Genero_med"].ToString(),
                    Nacionalidad = Convert.ToInt32(row["Nacionalidad_med"]),
                    FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento_med"]),
                    Direccion = row["Direccion_med"].ToString(),
                    Localidad = Convert.ToInt32(row["Localidad_med"]),
                    Provincia = Convert.ToInt32(row["Provincia_med"]),
                    CorreoElectronico = row["CorreoElectronico_med"].ToString(),
                    Telefono = row["Telefono_med"]?.ToString(),
                    Especialidad = Convert.ToInt32(row["Especialidad_med"])
                };
                listaMedicos.Add(medico);
            }

            return listaMedicos;
        }





        public List<Medico> FiltrarMedicosPorLegajo(string legajo)
        {

            DataTable dt = ad.filtrarLegajo(legajo);


            List<Medico> listaMedicos = new List<Medico>();

            foreach (DataRow row in dt.Rows)
            {
                Medico medico = new Medico
                {
                    Legajo = row["Legajo_med"].ToString(),
                    DNI = row["DNI_med"].ToString(),
                    Nombre = row["Nombre_med"].ToString(),
                    Apellido = row["Apellido_med"].ToString(),
                    Genero = row["Genero_med"].ToString(),
                    Nacionalidad = Convert.ToInt32(row["Nacionalidad_med"]),
                    FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento_med"]),
                    Direccion = row["Direccion_med"].ToString(),
                    Localidad = Convert.ToInt32(row["Localidad_med"]),
                    Provincia = Convert.ToInt32(row["Provincia_med"]),
                    CorreoElectronico = row["CorreoElectronico_med"].ToString(),
                    Telefono = row["Telefono_med"].ToString(),
                    Especialidad = Convert.ToInt32(row["Especialidad_med"])
                };
                listaMedicos.Add(medico);
            }

            return listaMedicos;
        }











        
    }
}
