using System;
using Entidades;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace Datos
{
    public class DatosTurnos
    {
        public DataTable ObtenerDatosMedico(int legajoMedico)
        {
            string query = @"SELECT Legajo_med AS LegajoMedico, Nombre_med AS Nombre, Apellido_med AS Apellido
                             FROM Medicos 
                             WHERE Legajo_med = @LegajoMedico";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@LegajoMedico", legajoMedico);

            AccesoDatos accesoDatos = new AccesoDatos();
            return accesoDatos.ObtenerTablaConComando("Medico", cmd);
        }

        public List<Turno> ObtenerTurnosPorMedico(int idMedico)
        {
            string query = @"SELECT 
                                t.IdTurno_tu AS IdTurno,  
                                t.IdPaciente_tu AS IdPaciente,
                                p.Nombre_pac AS PacienteNombre,
                                p.Apellido_pac AS PacienteApellido,
                                t.IdMedico_tu AS IdLegajoMedico,
                                e.Nombre_esp AS Especialidad,
                                t.FechaTurno_tu AS FechaTurno,
                                et.Nombre_et AS EstadoTurno,
                                t.Estado_tur AS AsistenciaTurno,
                                t.Observacion
                             FROM Turnos t
                             JOIN Pacientes p ON t.IdPaciente_tu = p.DNI_pac
                             JOIN Medicos m ON t.IdMedico_tu = m.Legajo_med
                             JOIN Especialidades e ON m.Especialidad_med = e.IdEspecialidad_esp
                             JOIN EstadoTurnos et ON t.IdEstadoTurno_tu = et.IdEstadoTurno_et
                             WHERE t.IdMedico_tu = @IdMedico";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@IdMedico", idMedico);

            AccesoDatos accesoDatos = new AccesoDatos();
            DataTable dataTable = accesoDatos.ObtenerTablaConComando("Turnos", cmd);

            List<Turno> turnos = new List<Turno>();
            foreach (DataRow row in dataTable.Rows)
            {
                Turno turno = new Turno(
                    Convert.ToInt32(row["IdTurno"]),
                    row["IdPaciente"].ToString(),
                    row["PacienteNombre"].ToString(),
                    row["PacienteApellido"].ToString(),
                    Convert.ToInt32(row["IdLegajoMedico"]),
                    row["Especialidad"].ToString(),
                    Convert.ToDateTime(row["FechaTurno"]),
                    row["EstadoTurno"].ToString(),
                    Convert.ToBoolean(row["AsistenciaTurno"]),
                    row["Observacion"].ToString()
                );
                turnos.Add(turno);
            }
            return turnos;
        }

        public void ActualizarTurno(int idTurno, int estadoAsistencia, string observacion)
        {
            try
            {
                string query = @"
            UPDATE Turnos 
            SET IdEstadoTurno_tu = @EstadoAsistencia, 
                Estado_tur = 1, 
                Observacion = @Observacion
            WHERE IdTurno_tu = @IdTurno";

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionClinica"].ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EstadoAsistencia", estadoAsistencia);
                    command.Parameters.AddWithValue("@Observacion", observacion);
                    command.Parameters.AddWithValue("@IdTurno", idTurno);

                    connection.Open();
                    int filasAfectadas = command.ExecuteNonQuery();
                    if (filasAfectadas == 0)
                    {
                        throw new Exception("No se encontró el turno para actualizar.");
                    }
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error al actualizar el turno en la base de datos.", ex);
            }
        }

        public DateTime ObtenerFechaTurno(string idPaciente)
        {
            DateTime fechaTurno = DateTime.MinValue;
            string consulta = "SELECT FechaTurno_tu FROM Turnos WHERE IdPaciente_tu = @idPaciente";

            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionClinica"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(consulta, conexion);
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);

                conexion.Open();
                var result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    fechaTurno = Convert.ToDateTime(result);
                }
            }
            return fechaTurno;
        }
        public DataTable ObtenerTurnosPorFechasYMedico(int legajoMedico, DateTime fechaInicio, DateTime fechaFin)
        {
            string consulta = @"
    SELECT 
        t.IdTurno_tu AS IdTurno,  
        t.IdPaciente_tu AS IdPaciente,
        p.Nombre_pac AS PacienteNombre,
        p.Apellido_pac AS PacienteApellido,
        t.IdMedico_tu AS IdLegajoMedico,
        e.Nombre_esp AS Especialidad,
        t.FechaTurno_tu AS FechaTurno,
        et.Nombre_et AS EstadoTurno,
        t.Estado_tur AS AsistenciaTurno,
        t.Observacion
    FROM Turnos t
    JOIN Pacientes p ON t.IdPaciente_tu = p.DNI_pac
    JOIN Medicos m ON t.IdMedico_tu = m.Legajo_med
    JOIN Especialidades e ON m.Especialidad_med = e.IdEspecialidad_esp
    JOIN EstadoTurnos et ON t.IdEstadoTurno_tu = et.IdEstadoTurno_et
    WHERE 
        t.FechaTurno_tu BETWEEN @FechaInicio AND @FechaFin
        AND t.IdMedico_tu = @LegajoMedico"; // Filtro por médico

            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionClinica"].ConnectionString))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@FechaFin", fechaFin);
                comando.Parameters.AddWithValue("@LegajoMedico", legajoMedico); // Agregar el parámetro del legajo

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable tablaTurnos = new DataTable();
                adaptador.Fill(tablaTurnos);
                return tablaTurnos;
            }
        }


    }
}