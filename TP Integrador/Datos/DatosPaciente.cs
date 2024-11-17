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
    public class DatosPaciente
    {
        readonly AccesoDatos ad = new AccesoDatos();
        DataTable dt = new DataTable();
        DataSet ds  = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlConnection conexion = new SqlConnection();
        SqlDataAdapter adapter = new SqlDataAdapter();

      public List<Paciente> FiltrarPacientesPorDNI(string dni)
  {
      DataTable dt = ad.FiltrarPacientePorDni(dni); 
      List<Paciente> listaPacientes = new List<Paciente>();

      foreach (DataRow row in dt.Rows)
      {
          Paciente paciente = new Paciente
          {

              DNI = row["DNI_pac"].ToString(),
              Nombre = row["Nombre_pac"].ToString(),
              Apellido = row["Apellido_pac"].ToString(),
              Genero = Convert.ToInt32(row["Genero_pac"]),
              Nacionalidad = int.TryParse(row["Nacionalidad_pac"].ToString(), out int nacionalidad) ? nacionalidad : 0,
              FechaNacimiento = DateTime.TryParse(row["FechaNacimiento_pac"].ToString(), out DateTime fechaNacimiento) ? fechaNacimiento : DateTime.MinValue,
              Direccion = row["Direccion_pac"].ToString(),
              Localidad = int.TryParse(row["Localidad_pac"].ToString(), out int localidad) ? localidad : 0,
              Provincia = int.TryParse(row["Provincia_pac"].ToString(), out int provincia) ? provincia : 0,
              CorreoElectronico = row["CorreoElectronico_pac"].ToString(),
              Telefono = row["Telefono_pac"].ToString()
          };
          listaPacientes.Add(paciente);
      }

      return listaPacientes;
  }


  public List<Paciente> ObtenerListaPacientes()
  {
      string consulta = "SELECT * FROM Pacientes";
      DataTable dt = ad.ObtenerTabla("Pacientes", consulta);

      List<Paciente> listaPaciente = new List<Paciente>();

      foreach (DataRow row in dt.Rows)
      {
          Paciente paciente = new Paciente
          {

              DNI = row["DNI_pac"].ToString(),
              Nombre = row["Nombre_pac"].ToString(),
              Apellido = row["Apellido_pac"].ToString(),
              Genero = Convert.ToInt32(row["Genero_pac"]),
              Nacionalidad = int.TryParse(row["Nacionalidad_pac"].ToString(), out int nacionalidad) ? nacionalidad : 0,
              FechaNacimiento = DateTime.TryParse(row["FechaNacimiento_pac"].ToString(), out DateTime fechaNacimiento) ? fechaNacimiento : DateTime.MinValue,
              Direccion = row["Direccion_pac"].ToString(),
              Localidad = int.TryParse(row["Localidad_pac"].ToString(), out int localidad) ? localidad : 0,
              Provincia = int.TryParse(row["Provincia_pac"].ToString(), out int provincia) ? provincia : 0,
              CorreoElectronico = row["CorreoElectronico_pac"].ToString(),
              Telefono = row["Telefono_pac"].ToString()
          };
          listaPaciente.Add(paciente);
      }

      return listaPaciente;
  }

   
  public bool AgregarPaciente(Paciente paciente)
  {
      try
      {
          using (SqlConnection conexion = ad.ObtenerConexion())
          {
              if (conexion == null) throw new Exception("No se pudo establecer la conexión con la base de datos.");

              SqlCommand cmd = new SqlCommand("SP_AgregarPaciente", conexion)
              {
                  CommandType = CommandType.StoredProcedure
              };

              // Agregar parámetros del procedimiento almacenado
              cmd.Parameters.AddWithValue("@DNI_pac", paciente.DNI);
              cmd.Parameters.AddWithValue("@Nombre_pac", paciente.Nombre);
              cmd.Parameters.AddWithValue("@Apellido_pac", paciente.Apellido);
              cmd.Parameters.AddWithValue("@Genero_pac", paciente.Genero);
              cmd.Parameters.AddWithValue("@Nacionalidad_pac", paciente.Nacionalidad);
              cmd.Parameters.AddWithValue("@FechaNacimiento_pac", paciente.FechaNacimiento);
              cmd.Parameters.AddWithValue("@Direccion_pac", paciente.Direccion);
              cmd.Parameters.AddWithValue("@Localidad_pac", paciente.Localidad);
              cmd.Parameters.AddWithValue("@Provincia_pac", paciente.Provincia);
              cmd.Parameters.AddWithValue("@CorreoElectronico_pac", paciente.CorreoElectronico);
              cmd.Parameters.AddWithValue("@Telefono_pac", paciente.Telefono);

              // Ejecutar el comando
              int filasAfectadas = cmd.ExecuteNonQuery();
              return filasAfectadas > 0;
          }
      }
      catch (Exception ex)
      {
          Console.WriteLine("Error al agregar el paciente: " + ex.Message);
          return false;
      }
  }

  public bool ExistePaciente(string dni)
  {
      string consulta = "SELECT * FROM Pacientes WHERE DNI_pac = @DNI";
      SqlCommand cmd = new SqlCommand(consulta);
      cmd.Parameters.AddWithValue("@DNI", dni);

      using (SqlConnection conexion = ad.ObtenerConexion())
      {
          if (conexion == null)
          {
              Console.WriteLine("No conectado");
              return false;
          }

          cmd.Connection = conexion;

          try
          {
              conexion.Open();
              using (SqlDataReader reader = cmd.ExecuteReader())
              {
                  return reader.HasRows; 
              }
          }
          catch (Exception ex)
          {
              Console.WriteLine("Error al verificar la existencia del paciente: " + ex.Message);
              return false;
          }
          finally
          {
              conexion.Close();
          }
      }
  }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------Obtener paciente
        public DataTable GetTablaPacientesDatos() //Muestra todos los pacientes con todos los campos
        {
            string consulta = "SELECT * " +
                              "FROM Pacientes";

            return ad.ObtenerTabla("Pacientes", consulta);

        }
        public DataTable FiltrarPacienteDNIBajaDatos(string DNI)                 //Muestra un paciente y solo los campos para la Baja
        {
            string consulta = "SELECT DNI_pac, Nombre_pac, Apellido_pac " +
                              "FROM Pacientes " +
                              "WHERE DNI_pac = @DNI";
            cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@DNI", DNI);
            return ad.ObtenerTablaConComando("Pacientes", cmd);
        }


        //public DataTable FiltrarPacienteDNIModificacionDatos(string DNI) //Muestra un paciente y todos los campos para la modificacion
        //{
        //    string consulta = "SELECT * " +
        //           "FROM Pacientes " +
        //           "WHERE DNI_pac = @DNI";
        //    SqlCommand cmd = new SqlCommand(consulta);
        //    cmd.Parameters.AddWithValue("@DNI", DNI);
        //    return ad.ObtenerTablaConComando("Pacientes", cmd);
        //}

        public DataTable FiltrarPacienteDNIModificacionDatos(string DNI)
        {
            string consulta = @"SELECT p.DNI_pac, 
                                       p.Nombre_pac,
                                       p.Apellido_pac, 
                                       g.Descripcion_g , 
                                       n.Nombre_pais,
                                       p.FechaNacimiento_pac,
                                       p.Direccion_pac, 
                                       pr.Nombre_prov, 
                                       l.Nombre_loc, 
                                       p.CorreoElectronico_pac,
                                       p.Telefono_pac
                               FROM Pacientes AS p
                               INNER JOIN Generos AS g ON p.Genero_pac = g.IdGenero_g
                               INNER JOIN Paises AS n ON p.Nacionalidad_pac = n.IdPais_p
                               INNER JOIN Localidades AS l ON p.Localidad_pac = l.IdLocalidad_loc
                               INNER JOIN Provincias AS pr ON p.Provincia_pac = pr.IdProvincia_prov
                               WHERE p.DNI_pac = @DNI";

            SqlCommand cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@DNI", DNI);

            if (ad.ExisteRegistroConComando(cmd))
            {
                return ad.ObtenerTablaConComando("Pacientes", cmd);
            }
            return null;

        }

        //------------------------------------------------------------------------------------------------Obtener Genero de los pacientes
        public DataTable ObtenerGeneros()
        {
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT IdGenero_g, Descripcion_g FROM Generos");
            dt = ad.ObtenerTablaConComando("Generos", cmd);
            return dt;
        }

        //------------------------------------------------------------------------------------------------Obtener Nacionalidad de los pacientes
        public DataTable ObtenerNacionalidades()
        {
            cmd = new SqlCommand("SELECT DISTINCT IdPais_p, Nombre_pais FROM Paises");
            dt = ad.ObtenerTablaConComando("Paises", cmd);
            return dt;
        }
        //------------------------------------------------------------------------------------------------Obtener Provincia de los pacientes

        public DataTable ObtenerProvincias()
        {
            cmd = new SqlCommand("SELECT DISTINCT IdProvincia_prov, Nombre_prov FROM Provincias");
            dt = ad.ObtenerTablaConComando("Provincias", cmd);
            return dt;
        }



        //------------------------------------------------------------------------------------------------Obtener Localidad de los pacientes
        public DataTable ObtenerLocalidades()
        {
            cmd = new SqlCommand("SELECT IdLocalidad_loc, Nombre_loc FROM Localidades");
            dt = ad.ObtenerTablaConComando("Localidades", cmd);
            return dt;
        }
        public DataTable ObtenerLocalidadesPorProvincia(int IdProvincia)
        {
            string consulta = "SELECT IdLocalidad_loc, Nombre_loc FROM Localidades WHERE IdProvincia_loc = @IdProvincia";
            cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@IdProvincia", IdProvincia);

            return ad.ObtenerTablaConComando("Localidades", cmd);
        }


        
        //------------------------------------------------------------------------------------------------------------------------------------------------------Eliminar Paciente

        public int EliminarPacienteDatos(Paciente paciente)
        {
            cmd.CommandText = "SP_EliminarPaciente";  
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DNI_pac", paciente.DNI);

            return ad.EjecutarProcedimientoAlmacenado(cmd, "SP_EliminarPaciente");
        }


        //-----------------------------------------------------------------------------------------------Actualizar Paciente
        public DataTable ModificarPacienteDatos(Paciente paciente)
        {
            conexion = ad.ObtenerConexion();

            cmd = new SqlCommand("SP_ModificarPaciente", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@DNI_pac", paciente.DNI);
            cmd.Parameters.AddWithValue("@Nombre_pac", paciente.Nombre);
            cmd.Parameters.AddWithValue("@Apellido_pac", paciente.Apellido);
            cmd.Parameters.AddWithValue("@Genero_pac", paciente.Genero);
            cmd.Parameters.AddWithValue("@Nacionalidad_pac", paciente.Nacionalidad);
            cmd.Parameters.AddWithValue("@FechaNacimiento_pac", paciente.FechaNacimiento);
            cmd.Parameters.AddWithValue("@Direccion_pac", paciente.Direccion);
            cmd.Parameters.AddWithValue("@Localidad_pac", paciente.Localidad);
            cmd.Parameters.AddWithValue("@Provincia_pac", paciente.Provincia);
            cmd.Parameters.AddWithValue("@CorreoElectronico_pac", paciente.CorreoElectronico);
            cmd.Parameters.AddWithValue("@Telefono_pac", paciente.Telefono);

            ad.EjecutarProcedimientoAlmacenado(cmd, "SP_ModificarPaciente");
            if(ad != null)
            {
                return dt;
            }
            return null;
        }

    }
}
