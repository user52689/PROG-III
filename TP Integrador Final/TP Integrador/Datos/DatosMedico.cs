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
                    if (filasAfectadas > 0)
                    {
                        foreach (var item in medico.Diaxhora)
                        {
                            bool respusta = AgregarMedicoDiaHora(item.dia, item.hora);
                            if (!respusta)
                            {
                                return false;
                            }
                        }

                    }
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

            foreach (var item in medico.Diaxhora)
            {
                bool respuesta = ModificarMedicoDiaHora(medico, item.dia, item.hora);
                if (!respuesta)
                {
                    return null;
                }
            }
            if (ad != null)
            {
                return dt;
            }
            return null;
        }

        //-----------------------------------------------------------------------------------------------------------------------LISTADO
        public DataTable GetTablaMedicosDatos() //Todos los medicos
        {
            string consulta = @"SELECT m.Legajo_med," +
                                        "m.DNI_med, " +
                                        "m.Nombre_med, " +
                                        "m.Apellido_med, " +
                                        "g.Descripcion_g , " +
                                        "n.Nombre_pais , " +
                                        "m.FechaNacimiento_med, " +
                                        "m.Direccion_med, " +
                                        "pr.Nombre_prov, " +
                                        "l.Nombre_loc , " +
                                        "m.CorreoElectronico_med, " +
                                        "m.Telefono_med, " +
                                        "es.Nombre_esp " +
                                        "FROM Medicos AS m " +
                                        "INNER JOIN Generos AS g ON m.Genero_med = g.IdGenero_g " +
                                        "INNER JOIN Paises AS n ON m.Nacionalidad_med = n.IdPais_p " +
                                        "INNER JOIN Localidades AS l ON m.Localidad_med = l.IdLocalidad_loc " +
                                        "INNER JOIN Provincias AS pr ON m.Provincia_med = pr.IdProvincia_prov " +
                                        "INNER JOIN Especialidades as es ON m.Especialidad_med = es.IdEspecialidad_esp " +
                                        "WHERE m.Estado_med = 1";

            return (ad.ObtenerTabla("Medicos", consulta));
        }
        public DataTable FiltrarMedicoLegajoBajaDatos(int Legajo) //Medico filtrado para la baja
        {
            string consulta = "SELECT Legajo_med," +
                                     "DNI_med, Nombre_med," +
                                     "Apellido_med " +
                                     "FROM Medicos " +
                                     "WHERE Legajo_med = @Legajo AND Estado_med = 1";
            conexion = ad.ObtenerConexion();
            cmd = new SqlCommand(consulta, conexion);
            cmd.Parameters.AddWithValue("@Legajo", Legajo);
            return ad.ObtenerTablaConComando("Medicos", cmd);
        }

        public DataTable FiltrarMedicoLegajoDatos(int Legajo) //Medico filtrado para la modificacion
        {
            string consulta = @"SELECT TOP 1 m.Legajo_med, 
                                       m.DNI_med, 
                                       m.Nombre_med, 
                                       m.Apellido_med, 
                                       g.Descripcion_g, 
                                       n.Nombre_pais, 
                                       m.FechaNacimiento_med, 
                                       m.Direccion_med, 
                                       pr.Nombre_prov, 
                                       l.Nombre_loc, 
                                       m.CorreoElectronico_med, 
                                       m.Telefono_med, 
                                       es.Nombre_esp,
                                       STRING_AGG(d.NombreDia_d, ', ') AS Dias,
                                       h.Horario_h
                                FROM Medicos AS m
                                INNER JOIN Generos AS g ON m.Genero_med = g.IdGenero_g 
                                INNER JOIN Paises AS n ON m.Nacionalidad_med = n.IdPais_p 
                                INNER JOIN Localidades AS l ON m.Localidad_med = l.IdLocalidad_loc 
                                INNER JOIN Provincias AS pr ON m.Provincia_med = pr.IdProvincia_prov 
                                INNER JOIN Especialidades AS es ON m.Especialidad_med = es.IdEspecialidad_esp 
                                INNER JOIN MedicoXDias AS md ON m.Legajo_med = md.Legajo_med_mxd
                                INNER JOIN Dias AS d ON md.IdDia_d_mxd = d.IdDia_d
                                INNER JOIN Horarios AS h ON md.IdHorario_h_mxd = h.Id_h
                                WHERE m.Legajo_med = @Legajo 
                                  AND md.Estado_mxd = 1 
                                  AND m.Estado_med = 1
                                GROUP BY m.Legajo_med, 
                                         m.DNI_med, 
                                         m.Nombre_med, 
                                         m.Apellido_med, 
                                         g.Descripcion_g, 
                                         n.Nombre_pais, 
                                         m.FechaNacimiento_med, 
                                         m.Direccion_med, 
                                         pr.Nombre_prov, 
                                         l.Nombre_loc, 
                                         m.CorreoElectronico_med, 
                                         m.Telefono_med, 
                                         es.Nombre_esp, 
                                         h.Horario_h;";

            conexion = ad.ObtenerConexion();
            cmd = new SqlCommand(consulta, conexion);
            cmd.Parameters.AddWithValue("@Legajo", Legajo);

            if (ad.ExisteRegistroConComando(cmd))
            {
                return ad.ObtenerTablaConComando("Medicos", cmd);
            }

            return null;
        }
        //---------------------------------------------------------------------------------------------agregar a tabla medicoxdias
        public bool AgregarMedicoDiaHora(int dia, int hora)
        {
            try
            {
                using (SqlConnection conexion = ad.ObtenerConexion())
                {
                    if (conexion == null) throw new Exception("No se pudo establecer la conexión con la base de datos.");

                    string consulta = "INSERT INTO MedicoXDias (Legajo_med_mxd, IdDia_d_mxd, IdHorario_h_mxd, Estado_mxd) " +
                                      "VALUES (@Legajo_med_mxd, @IdDia_d_mxd, @IdHorario_h_mxd, @Estado_mxd)";

                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    cmd.Parameters.AddWithValue("@Legajo_med_mxd", ((ObtenerMaximoLegajoDatos()) - 1));
                    cmd.Parameters.AddWithValue("@IdDia_d_mxd", dia);
                    cmd.Parameters.AddWithValue("@IdHorario_h_mxd", hora);
                    cmd.Parameters.AddWithValue("@Estado_mxd", 1);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el médico: " + ex.Message);
                return false;
            }
        }

        public bool ModificarMedicoDiaHora(Medico medico, int dia, int hora)
        {
            try
            {
                using (SqlConnection conexion = ad.ObtenerConexion())
                {
                    if (conexion == null) throw new Exception("No se pudo establecer la conexión con la base de datos.");

                    string consulta = @"
                    IF EXISTS (
                        SELECT 1 
                        FROM MedicoXDias 
                        WHERE Legajo_med_mxd = @Legajo_med_mxd 
                          AND IdDia_d_mxd = @IdDia_d_mxd 
                          AND IdHorario_h_mxd = @IdHorario_h_mxd
                    )
                    BEGIN
                        -- Si ya existe, actualiza el estado a true (1)
                        UPDATE MedicoXDias
                        SET Estado_mxd = 1
                        WHERE Legajo_med_mxd = @Legajo_med_mxd 
                          AND IdDia_d_mxd = @IdDia_d_mxd 
                          AND IdHorario_h_mxd = @IdHorario_h_mxd;
                    END
                    ELSE
                    BEGIN
                        -- Si no existe, inserta una nueva fila
                        INSERT INTO MedicoXDias (Legajo_med_mxd, IdDia_d_mxd, IdHorario_h_mxd, Estado_mxd)
                        VALUES (@Legajo_med_mxd, @IdDia_d_mxd, @IdHorario_h_mxd, @Estado_mxd);
                    END";

                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    cmd.Parameters.AddWithValue("@Legajo_med_mxd", medico.Legajo);
                    cmd.Parameters.AddWithValue("@IdDia_d_mxd", dia);
                    cmd.Parameters.AddWithValue("@IdHorario_h_mxd", hora);
                    cmd.Parameters.AddWithValue("@Estado_mxd", 1);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el médico: " + ex.Message);
                return false;
            }
        }

        //--------------------------------------------------------------------------------------------------------------------Metodos

        public int ObtenerMaximoLegajoDatos()
        {
            string consulta = "SELECT ISNULL(MAX(Legajo_med), 0) FROM Medicos";
            return ad.ObtenerMaximo(consulta) + 1;
        }
    }
}