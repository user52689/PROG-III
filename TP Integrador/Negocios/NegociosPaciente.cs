using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data;


namespace Negocios
{
    public class NegociosPaciente
    {
        private readonly AccesoDatos accesoDatos = new AccesoDatos();
        readonly Paciente paciente = new Paciente();
        readonly DatosPaciente datosP = new DatosPaciente();
        DataTable dt = new DataTable();

        public List<Paciente> ObtenerListaPacientes()
        {
            string consulta = "SELECT * FROM Pacientes";
            DataTable dt = accesoDatos.ObtenerTabla("Pacientes", consulta);
            List<Paciente> listaPacientes = new List<Paciente>();

            foreach (DataRow row in dt.Rows)
            {
                Paciente paciente = new Paciente
                {
                    DNI = row["DNI_pac"].ToString(),
                    Nombre = row["Nombre_pac"].ToString(),
                    Apellido = row["Apellido_pac"].ToString(),
                    Genero = Convert.ToInt32(row["Genero_pac"]),
                    Nacionalidad = Convert.ToInt32(row["Nacionalidad_pac"]),
                    FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento_pac"]),
                    Direccion = row["Direccion_pac"].ToString(),
                    Localidad = Convert.ToInt32(row["Localidad_pac"]),
                    Provincia = Convert.ToInt32(row["Provincia_pac"]),
                    CorreoElectronico = row["CorreoElectronico_pac"].ToString(),
                    Telefono = row["Telefono_pac"]?.ToString()
                };
                listaPacientes.Add(paciente);
            }

            return listaPacientes;
        }



        //-----------------------------------------------------------------------------------------------------------------------------Obtener todos los pacientes, y paciente filtrado por dni
        public DataTable GetTablaPacienteNegocios()
        {
            return datosP.GetTablaPacientesDatos();
        }


        public Paciente FiltrarPacientePorDni(string dni)//Muestra todos los campos para el Listado 
        {
            DataTable dt = accesoDatos.FiltrarPacientePorDni(dni);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Paciente
                {
                    DNI = row["DNI_pac"].ToString(),
                    Nombre = row["Nombre_pac"].ToString(),
                    Apellido = row["Apellido_pac"].ToString(),
                    Genero = Convert.ToInt32(row["Genero_pac"]),
                    Nacionalidad = Convert.ToInt32(row["Nacionalidad_pac"]),
                    FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento_pac"]),
                    Direccion = row["Direccion_pac"].ToString(),
                    Localidad = Convert.ToInt32(row["Localidad_pac"]),
                    Provincia = Convert.ToInt32(row["Provincia_pac"]),
                    CorreoElectronico = row["CorreoElectronico_pac"].ToString(),
                    Telefono = row["Telefono_pac"].ToString()
                };
            }
            return null;
        }
        
        //--------------------------------------------------------------------------------------Baja Paciente

        public DataTable FiltrarPacienteDNIBajaNegocios(string DNI)  //Muestra los campos seleccionados para la Baja
        {
            return datosP.FiltrarPacienteDNIBajaDatos(DNI);
        }
        public DataTable FiltrarPacienteDNIModificacionNegocios(string DNI)     //Muestra los campos seleccionados para la Modificacion
        {
            return datosP.FiltrarPacienteDNIModificacionDatos(DNI);
        }

        public int EliminarPacienteNegocio(string DNI)
        {
            paciente.DNI = DNI;

            int estado = 0;

            estado = datosP.EliminarPacienteDatos(paciente);

            return estado;
        }
        
        //---------------------------------------------------------------------------------------Cargas de los ddl 

        //------------------------------------------------Carga de Generos
        public DataTable CargarGenerosNegocio()
        {            
            return dt = datosP.ObtenerGeneros();
        }
        //------------------------------------------------Carga de Nacionalidades
        public DataTable CargarNacionalidadesNegocio()
        {
            return dt = datosP.ObtenerNacionalidades();
        }
        //------------------------------------------------Carga de Provincias
        public DataTable CargarProvinciasNegocio()
        {
            return dt = datosP.ObtenerProvincias();         
        }

        //------------------------------------------------Carga de Localidades
        public DataTable CargarLocalidadesNegocio()
        {
            return dt = datosP.ObtenerLocalidades();
        }
        public DataTable CargarLocalidadesPorProvinciaNegocio(int IdProvincia)
        {
            return dt = datosP.ObtenerLocalidadesPorProvincia(IdProvincia);
        }

        //------------------------------------------------------------------------Actualizar paciente
        public DataTable ModificarPacienteNegocio(Paciente paciente)
        {
            return dt = datosP.ModificarPacienteDatos(paciente);
        }
    }
}
